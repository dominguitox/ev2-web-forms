using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace ev2_web_forms.Administrador
{
    public partial class ConsultasLINQ : System.Web.UI.Page
    {
        // Validar acceso y cargar los estados.
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Rol"] == null ||
                Session["Rol"].ToString() != "Administrador" ||
                Session["IdUsuario"] == null)
            {
                Response.Redirect("../Login.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
                return;
            }

            if (!IsPostBack)
            {
                CargarEstados();
            }
        }

        // Cargar los estados desde SQL Server.
        private void CargarEstados()
        {
            using (var db = new HelpDeskTIEntities())
            {
                var estados = db.Estados
                    .OrderBy(e => e.Orden)
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

        // Limpiar los resultados anteriores.
        private void LimpiarPantalla()
        {
            lblMensaje.Visible = false;
            pnlResultados.Visible = false;
        }

        // Mostrar mensajes al administrador.
        private void MostrarMensaje(string mensaje, string tipo)
        {
            lblMensaje.Text = mensaje;
            lblMensaje.CssClass = "mensaje " + tipo;
            lblMensaje.Visible = true;
        }

        // Mostrar los resultados de cualquier consulta.
        private void MostrarResultados<T>(
            IEnumerable<T> datos,
            string titulo,
            string mensajeSinDatos)
        {
            lblTituloResultado.Text = titulo;

            gvResultados.DataSource = datos;
            gvResultados.DataBind();

            pnlResultados.Visible = true;

            if (gvResultados.Rows.Count == 0)
            {
                MostrarMensaje(mensajeSinDatos, "info");
            }
            else
            {
                MostrarMensaje(
                    "Consulta ejecutada correctamente. Registros encontrados: "
                    + gvResultados.Rows.Count,
                    "success"
                );
            }
        }

        // =====================================================
        // 1. WHERE: FILTRAR TICKETS POR ESTADO
        // =====================================================

        protected void btnWhere_Click(object sender, EventArgs e)
        {
            LimpiarPantalla();

            int idEstado;

            if (!int.TryParse(ddlEstado.SelectedValue, out idEstado))
            {
                MostrarMensaje(
                    "Debes seleccionar un estado.",
                    "error"
                );

                return;
            }

            try
            {
                using (var db = new HelpDeskTIEntities())
                {
                    var resultados = db.Tickets
                        .Where(t => t.IdEstado == idEstado)
                        .OrderByDescending(t => t.FechaCreacion)
                        .Select(t => new
                        {
                            IdTicket = t.IdTicket,
                            Titulo = t.Titulo,
                            Estado = t.Estados.Nombre,
                            Prioridad = t.Prioridades.Nombre,
                            FechaCreacion = t.FechaCreacion
                        })
                        .ToList();

                    MostrarResultados(
                        resultados,
                        "WHERE - Tickets filtrados por estado",
                        "No se encontraron tickets para el estado seleccionado."
                    );
                }
            }
            catch (Exception)
            {
                MostrarMensaje(
                    "Ocurrio un error al ejecutar WHERE.",
                    "error"
                );
            }
        }

        // =====================================================
        // 2. SELECT: SELECCIONAR CAMPOS ESPECIFICOS
        // =====================================================

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            LimpiarPantalla();

            try
            {
                using (var db = new HelpDeskTIEntities())
                {
                    var resultados = db.Tickets
                        .OrderByDescending(t => t.FechaCreacion)
                        .Select(t => new
                        {
                            IdTicket = t.IdTicket,
                            Titulo = t.Titulo,
                            Descripcion = t.Descripcion,
                            Estado = t.Estados.Nombre,
                            Prioridad = t.Prioridades.Nombre,
                            FechaCreacion = t.FechaCreacion
                        })
                        .ToList();

                    MostrarResultados(
                        resultados,
                        "SELECT - Información seleccionada de tickets",
                        "No existen tickets registrados."
                    );
                }
            }
            catch (Exception)
            {
                MostrarMensaje(
                    "Ocurrio un error al ejecutar SELECT.",
                    "error"
                );
            }
        }

        // =====================================================
        // 3. GROUP BY: AGRUPAR TICKETS POR ESTADO
        // =====================================================

        protected void btnGroupBy_Click(object sender, EventArgs e)
        {
            LimpiarPantalla();

            try
            {
                using (var db = new HelpDeskTIEntities())
                {
                    var resultados = db.Tickets
                        .GroupBy(t => t.Estados.Nombre)
                        .Select(grupo => new
                        {
                            Estado = grupo.Key,
                            CantidadTickets = grupo.Count()
                        })
                        .OrderByDescending(x => x.CantidadTickets)
                        .ToList();

                    MostrarResultados(
                        resultados,
                        "GROUP BY - Cantidad de tickets por estado",
                        "No existen tickets para agrupar."
                    );
                }
            }
            catch (Exception)
            {
                MostrarMensaje(
                    "Ocurrio un error al ejecutar GROUP BY.",
                    "error"
                );
            }
        }

        // =====================================================
        // 4. JOIN: RELACIONAR TICKETS Y TECNICOS
        // =====================================================

        protected void btnJoin_Click(object sender, EventArgs e)
        {
            LimpiarPantalla();

            try
            {
                using (var db = new HelpDeskTIEntities())
                {
                    var resultados = db.Tickets
                        .Where(t => t.IdTecnico.HasValue)
                        .Join(
                            db.Tecnicos,
                            ticket => ticket.IdTecnico.Value,
                            tecnico => tecnico.IdTecnico,
                            (ticket, tecnico) => new
                            {
                                IdTicket = ticket.IdTicket,
                                Titulo = ticket.Titulo,
                                IdTecnico = tecnico.IdTecnico,
                                NombreTecnico = tecnico.Usuarios.Nombre,
                                Especialidad = tecnico.Especialidad
                            }
                        )
                        .OrderBy(x => x.IdTicket)
                        .ToList();

                    MostrarResultados(
                        resultados,
                        "JOIN - Tickets y técnicos responsables",
                        "No existen tickets asignados a técnicos."
                    );
                }
            }
            catch (Exception)
            {
                MostrarMensaje(
                    "Ocurrio un error al ejecutar JOIN.",
                    "error"
                );
            }
        }

        // =====================================================
        // 5. FIRST: OBTENER EL PRIMER TICKET
        // =====================================================

        protected void btnFirst_Click(object sender, EventArgs e)
        {
            LimpiarPantalla();

            try
            {
                using (var db = new HelpDeskTIEntities())
                {
                    var consulta = db.Tickets
                        .OrderBy(t => t.FechaCreacion);

                    if (!consulta.Any())
                    {
                        MostrarMensaje(
                            "No existen tickets para ejecutar FIRST.",
                            "info"
                        );

                        return;
                    }

                    Tickets ticket = consulta.First();

                    var resultado = new[]
                    {
                        new
                        {
                            IdTicket = ticket.IdTicket,
                            Titulo = ticket.Titulo,
                            Descripcion = ticket.Descripcion,
                            IdEstado = ticket.IdEstado,
                            IdPrioridad = ticket.IdPrioridad,
                            FechaCreacion = ticket.FechaCreacion
                        }
                    };

                    MostrarResultados(
                        resultado,
                        "FIRST - Primer ticket registrado",
                        "No se encontró información."
                    );
                }
            }
            catch (Exception)
            {
                MostrarMensaje(
                    "Ocurrio un error al ejecutar FIRST.",
                    "error"
                );
            }
        }

        // =====================================================
        // 6. FIND: BUSCAR TICKET POR CLAVE PRIMARIA
        // =====================================================

        protected void btnFind_Click(object sender, EventArgs e)
        {
            LimpiarPantalla();

            int idTicket;

            if (!int.TryParse(txtIdTicket.Text.Trim(), out idTicket)
                || idTicket <= 0)
            {
                MostrarMensaje(
                    "Ingresa un identificador de ticket valido.",
                    "error"
                );

                return;
            }

            try
            {
                using (var db = new HelpDeskTIEntities())
                {
                    Tickets ticket = db.Tickets.Find(idTicket);

                    if (ticket == null)
                    {
                        MostrarMensaje(
                            "No existe un ticket con el ID ingresado.",
                            "info"
                        );

                        return;
                    }

                    var resultado = new[]
                    {
                        new
                        {
                            IdTicket = ticket.IdTicket,
                            Titulo = ticket.Titulo,
                            Descripcion = ticket.Descripcion,
                            IdEstado = ticket.IdEstado,
                            IdPrioridad = ticket.IdPrioridad,
                            IdTecnico = ticket.IdTecnico,
                            FechaCreacion = ticket.FechaCreacion
                        }
                    };

                    MostrarResultados(
                        resultado,
                        "FIND - Ticket encontrado",
                        "No se encontró información."
                    );
                }
            }
            catch (Exception)
            {
                MostrarMensaje(
                    "Ocurrio un error al ejecutar FIND.",
                    "error"
                );
            }
        }

        // =====================================================
        // 7. TOLIST: LISTAR TODOS LOS TICKETS
        // =====================================================

        protected void btnToList_Click(object sender, EventArgs e)
        {
            LimpiarPantalla();

            try
            {
                using (var db = new HelpDeskTIEntities())
                {
                    var resultados = db.Tickets
                        .OrderByDescending(t => t.FechaCreacion)
                        .Select(t => new
                        {
                            IdTicket = t.IdTicket,
                            Titulo = t.Titulo,
                            Estado = t.Estados.Nombre,
                            Prioridad = t.Prioridades.Nombre,
                            IdTecnico = t.IdTecnico,
                            FechaCreacion = t.FechaCreacion
                        })
                        .ToList();

                    MostrarResultados(
                        resultados,
                        "TOLIST - Listado completo de tickets",
                        "No existen tickets registrados."
                    );
                }
            }
            catch (Exception)
            {
                MostrarMensaje(
                    "Ocurrio un error al ejecutar TOLIST.",
                    "error"
                );
            }
        }
    }
}
