
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace ev2_web_forms.Tecnico
{
    public partial class PanelTecnico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Validar la sesion del tecnico.
            if (Session["Rol"] == null ||
                Session["Rol"].ToString() != "Tecnico" ||
                Session["IdUsuario"] == null)
            {
                Response.Redirect("../Login.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
                return;
            }

            try
            {
                int idUsuario = Convert.ToInt32(Session["IdUsuario"]);

                using (var db = new HelpDeskTIEntities())
                {
                    var tecnico = db.Tecnicos.FirstOrDefault(
                        t => t.IdUsuario == idUsuario && t.Activo);

                    if (tecnico == null)
                    {
                        pnlContenido.Visible = false;

                        lblMensaje.Text =
                            "No existe un perfil tecnico activo asociado a esta cuenta.";

                        return;
                    }

                    Session["IdTecnico"] = tecnico.IdTecnico;

                    if (!IsPostBack)
                    {
                        lblBienvenida.Text =
                            "Bienvenido " +
                            Server.HtmlEncode(Session["Usuario"].ToString());

                        lblEspecialidad.Text =
                            "Especialidad: " +
                            Server.HtmlEncode(
                                tecnico.Especialidad ?? "No especificada");

                        CargarEstados();
                        CargarTickets(tecnico.IdTecnico);
                    }
                }
            }
            catch (Exception)
            {
                pnlContenido.Visible = false;

                lblMensaje.Text =
                    "No fue posible cargar el panel tecnico.";
            }
        }

        // Obtener el identificador del tecnico.
        private int? ObtenerIdTecnico()
        {
            if (Session["IdUsuario"] == null)
                return null;

            int idUsuario = Convert.ToInt32(Session["IdUsuario"]);

            using (var db = new HelpDeskTIEntities())
            {
                var tecnico = db.Tecnicos.FirstOrDefault(
                    t => t.IdUsuario == idUsuario && t.Activo);

                if (tecnico == null)
                    return null;

                return tecnico.IdTecnico;
            }
        }

        // Cargar los estados disponibles.
        private void CargarEstados()
        {
            using (var db = new HelpDeskTIEntities())
            {
                var estados = db.Estados
                    .OrderBy(estado => estado.Orden)
                    .ToList();

                ddlEstado.DataSource = estados;
                ddlEstado.DataTextField = "Nombre";
                ddlEstado.DataValueField = "IdEstado";
                ddlEstado.DataBind();

                ddlEstado.Items.Insert(
                    0,
                    new ListItem("-- Seleccionar estado --", "")
                );
            }
        }

        // Consultar los tickets asignados al tecnico.
        private void CargarTickets(int idTecnico)
        {
            using (var db = new HelpDeskTIEntities())
            {
                var tickets = db.Tickets
                    .Where(t =>
                        t.IdTecnico.HasValue &&
                        t.IdTecnico.Value == idTecnico)
                    .OrderByDescending(t => t.FechaCreacion)
                    .Select(t => new
                    {
                        t.IdTicket,
                        t.Titulo,
                        t.Descripcion,
                        Estado = t.Estados.Nombre,
                        Prioridad = t.Prioridades.Nombre,
                        t.FechaCreacion
                    })
                    .ToList();

                gvTickets.DataSource = tickets;
                gvTickets.DataBind();
            }
        }

        // Seleccionar un ticket.
        protected void gvTickets_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            if (gvTickets.SelectedDataKey == null)
                return;

            try
            {
                int? idTecnico = ObtenerIdTecnico();

                if (!idTecnico.HasValue)
                    return;

                int idTicket = Convert.ToInt32(
                    gvTickets.SelectedDataKey.Value);

                using (var db = new HelpDeskTIEntities())
                {
                    var ticket = db.Tickets.FirstOrDefault(
                        t => t.IdTicket == idTicket &&
                        t.IdTecnico == idTecnico.Value);

                    if (ticket == null)
                    {
                        lblMensaje.Text =
                            "No tienes permisos para gestionar este ticket.";

                        return;
                    }

                    lblTicketSeleccionado.Text =
                        "Ticket N.º " + ticket.IdTicket +
                        " - " + Server.HtmlEncode(ticket.Titulo);

                    ddlEstado.SelectedValue =
                        ticket.IdEstado.ToString();

                    txtSolucion.Text = ticket.Solucion ?? "";

                    pnlActualizar.Visible = true;

                    lblMensaje.Text = "";
                }
            }
            catch (Exception)
            {
                lblMensaje.Text =
                    "No fue posible cargar el ticket seleccionado.";
            }
        }

        // Guardar los cambios del ticket.
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int? idTecnico = ObtenerIdTecnico();

                if (!idTecnico.HasValue ||
                    gvTickets.SelectedDataKey == null)
                {
                    lblMensaje.Text =
                        "No se pudo identificar el ticket o el tecnico.";

                    return;
                }

                int idTicket = Convert.ToInt32(
                    gvTickets.SelectedDataKey.Value);

                int idEstado;

                if (!int.TryParse(ddlEstado.SelectedValue, out idEstado))
                {
                    lblMensaje.Text =
                        "Debes seleccionar un estado valido.";

                    return;
                }

                using (var db = new HelpDeskTIEntities())
                {
                    // Verificar que el ticket pertenezca al tecnico.
                    var ticket = db.Tickets.FirstOrDefault(
                        t => t.IdTicket == idTicket &&
                        t.IdTecnico == idTecnico.Value);

                    if (ticket == null)
                    {
                        lblMensaje.Text =
                            "No tienes permisos para modificar este ticket.";

                        return;
                    }

                    // Verificar que el estado exista.
                    bool estadoExiste = db.Estados.Any(
                        estadoRegistro => estadoRegistro.IdEstado == idEstado);

                    if (!estadoExiste)
                    {
                        lblMensaje.Text =
                            "El estado seleccionado no existe.";

                        return;
                    }

                    // Actualizar informacion.
                    ticket.IdEstado = idEstado;
                    ticket.Solucion = txtSolucion.Text.Trim();
                    ticket.FechaActualizacion = DateTime.Now;

                    // Registrar fecha de cierre si corresponde.
                    var estadoActual = db.Estados.FirstOrDefault(
                        estadoRegistro => estadoRegistro.IdEstado == idEstado);

                    if (estadoActual != null &&
                        estadoActual.Nombre.Equals(
                            "Cerrado",
                            StringComparison.OrdinalIgnoreCase))
                    {
                        ticket.FechaCierre = DateTime.Now;
                    }
                    else
                    {
                        ticket.FechaCierre = null;
                    }

                    db.SaveChanges();
                }

                // Actualizar la interfaz.
                gvTickets.SelectedIndex = -1;

                pnlActualizar.Visible = false;

                CargarTickets(idTecnico.Value);

                lblMensaje.CssClass =
                    "alert alert-success d-block";

                lblMensaje.Text =
                    "El ticket fue actualizado correctamente.";
            }
            catch (Exception)
            {
                lblMensaje.CssClass =
                    "alert alert-danger d-block";

                lblMensaje.Text =
                    "Ocurrio un error al guardar los cambios.";
            }
        }

        // Cancelar la edicion.
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            gvTickets.SelectedIndex = -1;
            pnlActualizar.Visible = false;

            lblMensaje.Text = "";
        }

        // Cerrar sesion.
        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();

            Response.Redirect("../Login.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}
