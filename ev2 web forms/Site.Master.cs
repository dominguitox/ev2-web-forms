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
                if (Session["Rol"].ToString() == "Usuario")
                {
                    linklogin.InnerText = "Panel Cliente";
                    linklogin.HRef = ResolveUrl("~/Cliente/InicioCliente.aspx");
                }

                if (Session["Rol"].ToString() == "Administrador")
                {
                    linklogin.InnerText = "Panel Administrador";
                    linklogin.HRef = ResolveUrl("~/Administrador/PanelAdministrador.aspx");


                }

                if (Session["Rol"].ToString() == "Tecnico")
                {
                    linklogin.InnerText = "Panel Técnico";
                    linklogin.HRef = ResolveUrl("~/Tecnico/PanelTecnico.aspx");
                }
            }

           
        }
        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Response.Redirect(ResolveUrl("~/Login.aspx"), false);
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}