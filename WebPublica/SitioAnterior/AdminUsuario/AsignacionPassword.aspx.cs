

namespace WebPublica.SitioAnterior.AdminUsuario
{
    using System;

    public partial class AsignacionPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Fachada.WebPublica.Cliente objCliente = new Fachada.WebPublica.Cliente();
            EntidadesWeb.Cliente cliente = new EntidadesWeb.Cliente();
            PanelMensaje.Visible = false;

            cliente = objCliente.SeleccionarClientePorEmail(Session["Email"].ToString());            
            EntidadesWeb.ResultadoTransaccion resultadoTransaccion = objCliente.RecuperarPassword(cliente.IdCliente, TxtPasswordNuevo.Text, TxtPasswordNuevoVerificacion.Text);

            if (resultadoTransaccion.RegistrosAfectados == 1)
            {
                PanelMensaje.Visible = true;
                LblResultadoOperacion.Text = "Su contraseña se ha actualizado correctamente";                
            }
        }
    }
}