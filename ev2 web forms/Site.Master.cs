using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ev2_web_forms
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Rol"] == null )
            {
                btnCerrar.Visible = false;
            }
            else
            {
                btnCerrar.Visible = true;
                if (Session["Rol"].ToString() == "Cliente")
                {
                    linklogin.InnerText = "Panel Cliente";
                    linklogin.HRef = "/Cliente/InicioCliente";
                }

                if (Session["Rol"].ToString() == "Administrador")
                {
                    linklogin.InnerText = "Panel Administrador";
                    linklogin.HRef = "/Administrador/PanelAdministrador";


                }
            }

           
        }
        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Response.Redirect("../Login.aspx");
        }
    }
}