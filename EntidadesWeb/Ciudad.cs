//-----------------------------------------------------------------------
// <copyright file="Ciudad.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace EntidadesWeb
{
    public class Ciudad
    {
        public Ciudad()
        {
            this.Departamento = new Departamento();
        }

        public int IdCiudad { get; set; }

        public EntidadesWeb.Departamento Departamento { get; set; }

        public string Nombre { get; set; }

    }
}
