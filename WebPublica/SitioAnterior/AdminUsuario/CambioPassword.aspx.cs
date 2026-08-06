

namespace WebPublica.AdminUsuario
{
    using System;

    public partial class CambioPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void BtnCambiarContrasena_Click(object sender, EventArgs e)
        {
            Fachada.WebPublica.Cliente Cliente = new Fachada.WebPublica.Cliente();
            EntidadesWeb.Cliente cliente = new EntidadesWeb.Cliente();

            int idCliente = int.Parse(Session["IdCliente"].ToString());
            string passwordNuevo = TxtPswdNueva.Text;
            string passwordNuevoVerificacion = TxtPswdConfirmar.Text;
            string passwordActual = TxtPswdActual.Text;
            cliente.Contrasena = TxtPswdNueva.Text;
            EntidadesWeb.ResultadoTransaccion resultadoTransaccion = Cliente.CambioPassword(idCliente, passwordNuevo, passwordNuevoVerificacion, passwordActual);
            
        }


    }
}