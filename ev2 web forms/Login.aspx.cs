
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ev2_web_forms
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        // Calcula el hash SHA-256 de la contraseña.
        private string CalcularHash(string texto)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] datos = Encoding.UTF8.GetBytes(texto);
                byte[] hash = sha256.ComputeHash(datos);

                StringBuilder resultado = new StringBuilder();

                foreach (byte b in hash)
                {
                    resultado.Append(b.ToString("X2"));
                }

                return resultado.ToString();
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            string correo = txtUsuario.Text.Trim();
            string clave = txtClave.Text;

            lblMensaje.Text = "";

            // Validar campos vacios.
            if (string.IsNullOrWhiteSpace(correo) ||
                string.IsNullOrWhiteSpace(clave))
            {
                lblMensaje.Text =
                    "Debes ingresar tu correo y contraseña.";
                return;
            }

            try
            {
                using (var db = new HelpDeskTIEntities())
                {
                    // Buscar usuario en SQL Server.
                    var usuario = db.Usuarios
                        .FirstOrDefault(u => u.Correo == correo);

                    // Comprobar que exista y este activo.
                    if (usuario == null || !usuario.Activo)
                    {
                        lblMensaje.Text =
                            "Correo o contraseña incorrectos.";
                        return;
                    }

                    // Calcular hash de la contraseña ingresada.
                    string hashIngresado = CalcularHash(clave);

                    // Comparar con el hash almacenado.
                    string hashAlmacenado =
                        (usuario.ContrasenaHash ?? "").Trim();

                    if (!string.Equals(
                        hashIngresado,
                        hashAlmacenado,
                        StringComparison.OrdinalIgnoreCase))
                    {
                        lblMensaje.Text =
                            "Correo o contraseña incorrectos.";
                        return;
                    }

                    // Validar el rol.
                    if (usuario.Rol != "Administrador" &&
                        usuario.Rol != "Usuario" &&
                        usuario.Rol != "Tecnico")
                    {
                        lblMensaje.Text =
                            "El rol de esta cuenta no es valido.";
                        return;
                    }

                    // Crear nueva sesion.
                    Session.Clear();

                    Session["IdUsuario"] = usuario.IdUsuario;
                    Session["Usuario"] = usuario.Nombre;
                    Session["Correo"] = usuario.Correo;
                    Session["Rol"] = usuario.Rol;

                    // Redireccionar segun el rol.
                    switch (usuario.Rol)
                    {
                        case "Administrador":

                            Response.Redirect(
                                "Administrador/PanelAdministrador.aspx",
                                false);

                            Context.ApplicationInstance.CompleteRequest();
                            return;

                        case "Usuario":

                            Response.Redirect(
                                "Cliente/InicioCliente.aspx",
                                false);

                            Context.ApplicationInstance.CompleteRequest();
                            return;

                        case "Tecnico":

                            Response.Redirect(
                                "Tecnico/PanelTecnico.aspx",
                                false);

                            Context.ApplicationInstance.CompleteRequest();
                            return;
                    }
                }
            }
            catch (Exception)
            {
                lblMensaje.Text =
                    "No fue posible conectar con la base de datos. " +
                    "Intenta nuevamente o contacta al administrador.";
            }
        }
    }
}
