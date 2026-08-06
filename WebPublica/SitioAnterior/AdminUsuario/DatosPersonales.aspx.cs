

namespace WebPublica.AdminUsuario
{
    using System;

    public partial class DatosPersonales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Fachada.WebPublica.Cliente Cliente = new Fachada.WebPublica.Cliente();
            EntidadesWeb.Cliente cliente = Cliente.SeleccionarClientePorIdCliente(int.Parse(Session["Cliente"].ToString()));

            EntidadesWeb.EtiquetaControles etiqueta = null;
            etiqueta = new EntidadesWeb.EtiquetaControles();

            etiqueta = MensajesWeb.LinqToXml.LeerEtiquetaControles("0180");
            this.TxtDocCliente.Text = etiqueta.Texto;

            etiqueta = MensajesWeb.LinqToXml.LeerEtiquetaControles("0181");
            this.TxtNombre.Text = etiqueta.Texto;

            etiqueta = MensajesWeb.LinqToXml.LeerEtiquetaControles("0182");
            this.TxtApellido.Text = etiqueta.Texto;

            etiqueta = MensajesWeb.LinqToXml.LeerEtiquetaControles("0183");
            this.TxtTelefono1.Text = etiqueta.Texto;

            etiqueta = MensajesWeb.LinqToXml.LeerEtiquetaControles("0184");
            this.TxtTelefono2.Text = etiqueta.Texto;

            etiqueta = MensajesWeb.LinqToXml.LeerEtiquetaControles("0185");
            this.TxtEmail.Text = etiqueta.Texto;

 
            LblUser.Text = Session["Cliente"].ToString();
            TxtDocCliente.Text = Convert.ToString(cliente.DocCliente);
            TxtNombre.Text = cliente.Nombre;
            TxtApellido.Text = cliente.Apellido;
            TxtTelefono1.Text = cliente.Telefono1;
            TxtTelefono2.Text = cliente.Telefono2;
            TxtEmail.Text = cliente.Email;

            TxtDocCliente.Enabled = false;
            TxtNombre.Enabled = false;
            TxtApellido.Enabled = false;
            TxtTelefono1.Enabled = false;
            TxtTelefono2.Enabled = false;
            TxtEmail.Enabled = false;

            BtnGuardar.Enabled = false;
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            Fachada.WebPublica.Cliente Cliente = new Fachada.WebPublica.Cliente();

            EntidadesWeb.Cliente cliente = new EntidadesWeb.Cliente();
            cliente.Nombre = this.TxtNombre.Text;
            cliente.Apellido = this.TxtApellido.Text;
            cliente.Telefono1 = this.TxtTelefono1.Text;
            cliente.Telefono2 = this.TxtTelefono2.Text;
            cliente.Email = this.TxtEmail.Text;

            EntidadesWeb.ResultadoTransaccion resultadoTransaccion = Cliente.Actualizar(cliente);
        }

        protected void BtnEditar_Click(object sender, EventArgs e)
        {
            BtnEditar.Enabled = false;
            BtnGuardar.Enabled = true;

            TxtNombre.Enabled = true;
            TxtApellido.Enabled = true;
            TxtTelefono1.Enabled = true;
            TxtTelefono2.Enabled = true;
            TxtEmail.Enabled = true;            
        }
    }
}