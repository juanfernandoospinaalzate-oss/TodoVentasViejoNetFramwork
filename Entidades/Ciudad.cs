//-----------------------------------------------------------------------
// <copyright file="ciudad.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace Entidades
{
    public class Ciudad
    {
        public Ciudad()
        {
            this.Departamento = new Departamento();
        }

        public int IdCiudad { get; set; }

        public Entidades.Departamento Departamento { get; set; }

        public string Nombre { get; set; }

    }
}
