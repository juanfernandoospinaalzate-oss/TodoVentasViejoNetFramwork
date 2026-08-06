//-----------------------------------------------------------------------
// <copyright file="Departamento.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace EntidadesWeb
{
    public class Departamento
    {
        public Departamento()
        {
            this.Pais = new Pais();
        }

        public int IdDepartamento { get; set; }

        public string Nombre { get; set; }

        public EntidadesWeb.Pais Pais { get; set; }
    }
}
