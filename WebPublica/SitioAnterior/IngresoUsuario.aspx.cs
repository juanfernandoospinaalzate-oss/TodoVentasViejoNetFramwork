

namespace WebPublica
{
    using System;

    public partial class IngresoUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { 
            
        }

        public void BtnRegistrar_Click(object sender, EventArgs e)
        {
            Fachada.WebPublica.Cliente Cliente = new Fachada.WebPublica.Cliente();

            EntidadesWeb.Cliente cliente = new EntidadesWeb.Cliente()
            {
                Nombre = this.TxtNombre.Text,
                Apellido = this.TxtApellido.Text,
                Telefono1 = TxtTelefono1.Text,
                Telefono2 = TxtTelefono2.Text,
                Email = TxtEmail.Text,
                Contrasena = this.TxtContrasena.Text,
                ConfirmarContrasena = this.TxtConfirmarContrasena.Text,
                DocCliente = int.Parse(this.TxtIdCliente.Text)
            };
            EntidadesWeb.Direccion direccion = new EntidadesWeb.Direccion();

            direccion.NombreDestinatario = this.TxtNomDestinatario.Text;
            direccion.DireccionEnvio = this.TxtDireccion.Text;
            direccion.Telefono = this.TxtTelefono.Text;
            direccion.Pais.IdPais = WucPaisDepartamentoCiudad.Pais.IdPais;
            direccion.Departamento.IdDepartamento = WucPaisDepartamentoCiudad.Departamento.IdDepartamento;
            direccion.Ciudad.IdCiudad = WucPaisDepartamentoCiudad.Ciudad.IdCiudad;

            EntidadesWeb.ResultadoTransaccion resultadoTransaccion = Cliente.Insertar(cliente, direccion);
        }
    }
}