
using System;

namespace ev2_web_forms.Cliente
{
    public partial class InicioCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Comprobar autenticacion y rol.
            if (Session["Rol"] == null ||
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
            }
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
