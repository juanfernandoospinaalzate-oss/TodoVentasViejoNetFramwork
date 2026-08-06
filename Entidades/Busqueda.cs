// -----------------------------------------------------------------------
// <copyright file="Busqueda.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace Entidades
{
    public class Busqueda
    {
        public int IdBusqueda { get; set; }

        public string Texto { get; set; }

        public long ContadorBusquedas { get; set; }

        public bool Eliminado { get; set; }

        public bool Aprobado { get; set; }

    }
}
