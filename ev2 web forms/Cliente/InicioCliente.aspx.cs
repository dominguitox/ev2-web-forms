using System;

namespace ev2_web_forms.Cliente
{
    public partial class InicioCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Rol"] == null ||
                Session["Rol"].ToString() != "Cliente")
            {
                Response.Redirect("../Login.aspx");
            }


            lblBienvenida.Text =
                "Bienvenido " + Session["Usuario"].ToString();

        }


        protected void btnCerrar_Click(object sender, EventArgs e)
        {

            Session.Abandon();
            Session.Clear();

            Response.Redirect("../Login.aspx");

        }
    }
}