
using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ev2_web_forms.Administrador
{
    public partial class ConsultasLINQ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Verificar que el usuario sea administrador.
            if (Session["Rol"] == null ||
                Session["Rol"].ToString() != "Administrador")
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

        // ==========================================
        // CARGAR ESTADOS DESDE SQL SERVER
        // ==========================================

        private void CargarEstados()
        {
            try
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
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        // ==========================================
        // MOSTRAR RESULTADOS
        // ==========================================

        private void MostrarResultados<T>(
            IEnumerable<T> resultados,
            string titulo)
        {
            var lista = resultados.ToList();

            lblTituloResultado.Text =
                Server.HtmlEncode(titulo);

            gvResultados.DataSource = lista;
            gvResultados.DataBind();

            pnlResultados.Visible = true;

            lblMensaje.CssClass =
                "alert alert-success d-block";

            lblMensaje.Text =
                "Consulta ejecutada correctamente. Registros encontrados: "
                + lista.Count;
        }

        // ==========================================
        // MOSTRAR MENSAJES
        // ==========================================

        private void MostrarMensaje(string mensaje)
        {
            lblMensaje.CssClass =
                "alert alert-warning d-block";

            lblMensaje.Text =
                Server.HtmlEncode(mensaje);

            pnlResultados.Visible = false;
        }

        private void MostrarError(Exception ex)
        {
            lblMensaje.CssClass =
                "alert alert-danger d-block";

            lblMensaje.Text =
                "Error al ejecutar la consulta: " +
                Server.HtmlEncode(ex.GetBaseException().Message);

            pnlResultados.Visible = false;
        }

        // ==========================================
        // 1. WHERE
        // Filtrar tickets por estado
        // ==========================================

        protected void btnWhere_Click(object sender, EventArgs e)
        {
            try
            {
                int idEstado;

                if (!int.TryParse(
                    ddlEstado.SelectedValue,
                    out idEstado))
                {
                    MostrarMensaje(
                        "Debes seleccionar un estado."
                    );

                    return;
                }

                using (var db = new HelpDeskTIEntities())
                {
                    var tickets = db.Tickets
                        .Where(t => t.IdEstado == idEstado)
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

                    MostrarResultados(
                        tickets,
                        "Tickets filtrados por estado (Where)"
                    );
                }
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        // ==========================================
        // 2. SELECT
        // Seleccionar campos específicos
        // ==========================================

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new HelpDeskTIEntities())
                {
                    var tickets = db.Tickets
                        .Select(t => new
                        {
                            t.IdTicket,
                            t.Titulo,
                            Estado = t.Estados.Nombre,
                            Prioridad = t.Prioridades.Nombre,
                            t.FechaCreacion
                        })
                        .ToList();

                    MostrarResultados(
                        tickets,
                        "Información seleccionada (Select)"
                    );
                }
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        // ==========================================
        // 3. GROUP BY
        // Agrupar tickets por estado
        // ==========================================

        protected void btnGroupBy_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new HelpDeskTIEntities())
                {
                    var agrupacion = db.Tickets
                        .GroupBy(t => t.Estados.Nombre)
                        .Select(g => new
                        {
                            Estado = g.Key,
                            CantidadTickets = g.Count()
                        })
                        .OrderBy(g => g.Estado)
                        .ToList();

                    MostrarResultados(
                        agrupacion,
                        "Tickets agrupados por estado (GroupBy)"
                    );
                }
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        // ==========================================
        // 4. JOIN
        // Relacionar tickets con técnicos y usuarios
        // ==========================================

        protected void btnJoin_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new HelpDeskTIEntities())
                {
                    var consulta = db.Tickets
                        .Where(t => t.IdTecnico.HasValue)

                        .Join(
                            db.Tecnicos,

                            ticket => ticket.IdTecnico.Value,

                            tecnico => tecnico.IdTecnico,

                            (ticket, tecnico) => new
                            {
                                Ticket = ticket,
                                Tecnico = tecnico
                            }
                        )

                        .Join(
                            db.Usuarios,

                            x => x.Tecnico.IdUsuario,

                            usuario => usuario.IdUsuario,

                            (x, usuario) => new
                            {
                                x.Ticket.IdTicket,
                                x.Ticket.Titulo,
                                NombreTecnico = usuario.Nombre,
                                x.Tecnico.Especialidad,
                                x.Ticket.FechaCreacion
                            }
                        )
                        .OrderBy(t => t.IdTicket)
                        .ToList();

                    MostrarResultados(
                        consulta,
                        "Tickets relacionados con técnicos (Join)"
                    );
                }
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        // ==========================================
        // 5. FIRST
        // Obtener el ticket más antiguo
        // ==========================================

        protected void btnFirst_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new HelpDeskTIEntities())
                {
                    // Comprobar que existan tickets.
                    if (!db.Tickets.Any())
                    {
                        MostrarMensaje(
                            "No existen tickets registrados."
                        );

                        return;
                    }

                    // Obtener el primer ticket por fecha.
                    var ticket = db.Tickets
                        .OrderBy(t => t.FechaCreacion)
                        .Select(t => new
                        {
                            t.IdTicket,
                            t.Titulo,
                            t.Descripcion,
                            Estado = t.Estados.Nombre,
                            Prioridad = t.Prioridades.Nombre,
                            t.FechaCreacion
                        })
                        .First();

                    MostrarResultados(
                        new[] { ticket },
                        "Ticket más antiguo (First)"
                    );
                }
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        // ==========================================
        // 6. FIND
        // Buscar ticket por clave primaria
        // ==========================================

        protected void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                int idTicket;

                if (!int.TryParse(txtIdTicket.Text, out idTicket))
                {
                    MostrarMensaje(
                        "Debes ingresar un ID de ticket válido."
                    );

                    return;
                }

                using (var db = new HelpDeskTIEntities())
                {
                    // Buscar directamente mediante la clave primaria.
                    var ticket = db.Tickets.Find(idTicket);

                    if (ticket == null)
                    {
                        MostrarMensaje(
                            "No se encontró ningún ticket con ese identificador."
                        );

                        return;
                    }

                    // Construir el resultado mientras el contexto sigue abierto.
                    var resultado = new[]
                    {
                        new
                        {
                            ticket.IdTicket,
                            ticket.Titulo,
                            ticket.Descripcion,
                            Estado = ticket.Estados.Nombre,
                            Prioridad = ticket.Prioridades.Nombre,
                            ticket.FechaCreacion
                        }
                    };

                    MostrarResultados(
                        resultado,
                        "Resultado de búsqueda (Find)"
                    );
                }
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        // ==========================================
        // 7. TOLIST
        // Obtener todos los tickets
        // ==========================================

        protected void btnToList_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new HelpDeskTIEntities())
                {
                    var tickets = db.Tickets
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

                    MostrarResultados(
                        tickets,
                        "Listado completo de tickets (ToList)"
                    );
                }
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }
    }
}
