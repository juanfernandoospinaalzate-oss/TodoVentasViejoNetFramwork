//-----------------------------------------------------------------------
// <copyright file="OrdenesCompra.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace Entidades
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class OrdenesCompra
    {
        [Display(Name = "NOMBRE CLIENTE", AutoGenerateFilter = false)]
        public string NombreCliente { get; set; }

        public string ApellidoCliente { get; set; }

        public int DocumentoIdentificacion { get; set; }

        public string TelefonoClienteUno { get; set; }

        public DateTime Fecha { get; set; }

        public string EmailCliente { get; set; }

        public double TotalVenta { get; set; }
        
        public int IdAlbaran { get; set; }
       
    }
}