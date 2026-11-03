using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace ev2_web_forms.Cliente
{
    public partial class InicioCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Comprobar autenticacion y rol.
            if (Session["Rol"] == null ||
                Session["IdUsuario"] == null ||
                Session["Usuario"] == null ||
                Session["Rol"].ToString() != "Usuario")
            {
                Response.Redirect("../Login.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
                return;
            }

            if (!IsPostBack)
            {
                lblBienvenida.Text =
                    "Bienvenido " + Server.HtmlEncode(
                        Session["Usuario"].ToString());
                CargarPrioridades();
                CargarTickets();
            }
        }

        private int ObtenerIdUsuario()
        {
            int idUsuario;
            if (!int.TryParse(Convert.ToString(Session["IdUsuario"]), out idUsuario) || idUsuario <= 0)
                throw new InvalidOperationException("La sesión del usuario no es válida.");

            return idUsuario;
        }

        private void CargarPrioridades()
        {
            using (var db = new HelpDeskTIEntities())
            {
                ddlPrioridad.DataSource = db.Prioridades.OrderBy(p => p.Nivel).ToList();
                ddlPrioridad.DataTextField = "Nombre";
                ddlPrioridad.DataValueField = "IdPrioridad";
                ddlPrioridad.DataBind();
                ddlPrioridad.Items.Insert(0, new ListItem("-- Seleccionar prioridad --", ""));
            }
        }

        private void CargarTickets()
        {
            using (var db = new HelpDeskTIEntities())
            {
                var tickets = db.Tickets
                    .Where(t => t.IdUsuario == ObtenerIdUsuario())
                    .OrderByDescending(t => t.FechaCreacion)
                    .Select(t => new
                    {
                        t.IdTicket,
                        t.Titulo,
                        t.Descripcion,
                        Estado = t.Estados.Nombre,
                        Prioridad = t.Prioridades.Nombre,
                        t.Solucion,
                        t.FechaCreacion
                    })
                    .ToList();

                gvTickets.DataSource = tickets;
                gvTickets.DataBind();
            }
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            string titulo = txtTitulo.Text.Trim();
            string descripcion = txtDescripcion.Text.Trim();
            int idPrioridad;

            if (string.IsNullOrWhiteSpace(titulo) || string.IsNullOrWhiteSpace(descripcion) ||
                titulo.Length > 150 || !int.TryParse(ddlPrioridad.SelectedValue, out idPrioridad))
            {
                MostrarMensaje("Completa título, descripción y prioridad válida.", "alert alert-danger d-block");
                return;
            }

            try
            {
                using (var db = new HelpDeskTIEntities())
                {
                    var prioridadExiste = db.Prioridades.Any(p => p.IdPrioridad == idPrioridad);
                    var estadoInicial = db.Estados.OrderBy(s => s.Orden).FirstOrDefault();

                    if (!prioridadExiste || estadoInicial == null)
                    {
                        MostrarMensaje("Los catálogos de tickets no están configurados.", "alert alert-danger d-block");
                        return;
                    }

                    db.Tickets.Add(new Tickets
                    {
                        Titulo = titulo,
                        Descripcion = descripcion,
                        IdUsuario = ObtenerIdUsuario(),
                        IdEstado = estadoInicial.IdEstado,
                        IdPrioridad = idPrioridad,
                        FechaCreacion = DateTime.Now
                    });
                    db.SaveChanges();
                }

                txtTitulo.Text = string.Empty;
                txtDescripcion.Text = string.Empty;
                ddlPrioridad.SelectedIndex = 0;
                CargarTickets();
                MostrarMensaje("El ticket fue creado correctamente.", "alert alert-success d-block");
            }
            catch (Exception)
            {
                MostrarMensaje("No fue posible crear el ticket.", "alert alert-danger d-block");
            }
        }

        private void MostrarMensaje(string mensaje, string clase)
        {
            lblMensaje.Text = mensaje;
            lblMensaje.CssClass = clase;
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("../Login.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}
