using System;

namespace ev2_web_forms
{
    public partial class Login : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnIngresar_Click(object sender, EventArgs e)
        {

            string usuario = txtUsuario.Text;
            string clave = txtClave.Text;


            // Inicio de sesión Cliente
            if (usuario == "cliente" && clave == "1234")
            {

                Session["Usuario"] = "Cliente";
                Session["Rol"] = "Cliente";

                Response.Redirect("Cliente/InicioCliente.aspx");

            }


            // Inicio de sesión Administrador
            else if (usuario == "admin" && clave == "1234")
            {

                Session["Usuario"] = "Administrador";
                Session["Rol"] = "Administrador";

                Response.Redirect("Administrador/PanelAdministrador.aspx");

            }


            // Datos incorrectos
            else
            {

                lblMensaje.Text = "Usuario o contraseña incorrectos";

            }

        }

    }
}