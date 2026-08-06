//-----------------------------------------------------------------------
// <copyright file="Departamento.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace Entidades
{
    public class Departamento
    {
        public Departamento()
        {
            this.Pais = new Pais();
        }

        public int IdDepartamento { get; set; }

        public Entidades.Pais Pais { get; set; }

        public string Nombre { get; set; }

    }
}
