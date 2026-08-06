//-----------------------------------------------------------------------
// <copyright file="ItemCarrito.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace EntidadesWeb
{
    using System;

    public class ItemCarrito
    {
        public int IdItemCarrito { get; set; }

        public int IdUsuario { get; set; }

        public int IdPrestacionArticulo { get; set; }

        public int Cantidad { get; set; }

        public string Nombre { get; set; }

        public double Precio { get; set; }

        public string UrlImagen { get; set; }

        public DateTime Fecha { get; set; }

        public double SubTotal
        {
            get
            {
                return this.Cantidad * this.Precio;
            }
        }
    }
}
