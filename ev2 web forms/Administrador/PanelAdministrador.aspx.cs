
using System;
using System.Linq;

namespace ev2_web_forms.Administrador
{
    public partial class PanelAdministrador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Comprobar que el usuario tenga una sesion
            // y que su rol sea Administrador.
            if (Session["Rol"] == null ||
                Session["Rol"].ToString() != "Administrador" ||
                Session["IdUsuario"] == null)
            {
                Response.Redirect("../Login.aspx");
                return;
            }

            if (!IsPostBack)
            {
                lblAdmin.Text = "Bienvenido Administrador";

                CargarTickets();
            }
        }

        private void CargarTickets()
        {
            try
            {
                // Crear el contexto de Entity Framework.
                using (var db = new HelpDeskTIEntities())
                {
                    // Consultar los tickets almacenados en SQL Server.
                    var tickets = db.Tickets
                        .OrderByDescending(t => t.FechaCreacion)
                        .ToList();

                    // Mostrar los registros en la pagina.
                    gvTickets.DataSource = tickets;
                    gvTickets.DataBind();

                    // Informar el resultado de la consulta.
                    lblResultado.CssClass = "alert alert-success d-block";

                    lblResultado.Text =
                        "Conexion exitosa con HelpDeskTI. " +
                        "Tickets encontrados: " + tickets.Count;
                }
            }
            catch (Exception ex)
            {
                // Mostrar el error para facilitar las pruebas.
                lblResultado.CssClass = "alert alert-danger d-block";

                lblResultado.Text =
                    "No se pudieron cargar los tickets: " +
                    Server.HtmlEncode(ex.GetBaseException().Message);
            }
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();

            Response.Redirect("../Login.aspx");
        }
    }
}
