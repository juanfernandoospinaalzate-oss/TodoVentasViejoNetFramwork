//-----------------------------------------------------------------------
// <copyright file="Cliente.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace EntidadesWeb
{
    /// <summary>
    /// Usuario del sitio web y/o cliente de compra presencial
    /// </summary>
    public class Cliente
    {
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
        /// Password del usuario en el sitio web
        /// </summary>
        public string Contrasena { get; set; }

        /// <summary>
        /// Password del usuario
        /// </summary>
        public string ConfirmarContrasena { get; set; }
    }
}
