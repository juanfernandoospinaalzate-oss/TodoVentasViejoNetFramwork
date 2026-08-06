//-----------------------------------------------------------------------
// <copyright file="Cliente.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace Entidades
{
    /// <summary>
    /// Usuario del sitio web y/o cliente de compra presencial
    /// </summary>
    public class Cliente
    {
        /// <summary>
        /// Lista de direcciones asociadas al usuario. Se accede a este campo usando la propiedad direcciones
        /// </summary>
        private System.Collections.Generic.List<Entidades.Direccion> direcciones = new System.Collections.Generic.List<Entidades.Direccion>();

        /// <summary>
        /// Identificación del usuario en la base de datos
        /// </summary>
        public int IdCliente { get; set; }

        /// <summary>
        /// Documento de identificación legal del usuario
        /// </summary>
        public int DocCliente { get; set; }

        /// <summary>
        /// Nombres del usuario
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Apellidos del usuario
        /// </summary>
        public string Apellido { get; set; }

        /// <summary>
        /// Número de teléfono del usuario, preferiblemente celular
        /// </summary>
        public string Telefono1 { get; set; }

        /// <summary>
        /// Número de teléfono secundario del usuario
        /// </summary>
        public string Telefono2 { get; set; }

        /// <summary>
        /// Correo electrónico del usuario
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Lista con direcciones de entrega para el usuario
        /// </summary>
        public System.Collections.Generic.List<Entidades.Direccion> Direcciones
        {
            get
            {
                return this.direcciones;
            }

            set
            {
                this.direcciones = value;
            }
        }

        /// <summary>
        /// Password del usuario en el sitio web
        /// </summary>
        public string Contrasena { get; set; }
    }
}