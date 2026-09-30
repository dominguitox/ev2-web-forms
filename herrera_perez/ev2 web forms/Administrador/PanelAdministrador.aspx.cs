using System;

namespace ev2_web_forms.Administrador
{
    public partial class PanelAdministrador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Rol"] == null ||
                Session["Rol"].ToString() != "Administrador")
            {
                Response.Redirect("../Login.aspx");
            }


            lblAdmin.Text =
                "Bienvenido Administrador";

        }


        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();

            Response.Redirect("../Login.aspx");

        }
    }
}