//-----------------------------------------------------------------------
// <copyright file="Almacen.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace Entidades
{
    public class Almacen
    {
        public Almacen()
        {
            this.Ciudad = new Ciudad();
        }

        public int IdAlmacen { get; set; }
        public string NombreCompleto { get; set; }
        public string Descripcion { get; set; }
        public string Direccion { get; set; }
        public Entidades.Ciudad Ciudad { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public int Nit { get; set; }
        public string SitioWeb { get; set; }
    }
}
