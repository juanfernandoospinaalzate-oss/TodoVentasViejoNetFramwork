//-----------------------------------------------------------------------
// <copyright file="Direccion.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace Entidades
{
    public class Direccion
    {
        public long IdDireccion { get; set; }

        public string NombreDestinatario { get; set; }

        public string DireccionEnvio { get; set; }

        public string Telefono { get; set; }

        private Entidades.Pais pais = new Entidades.Pais();
        public Entidades.Pais Pais
        {
            get
            {
                return this.pais;
            }
            set
            {
                this.pais = value;
            }
        }

        private Entidades.Departamento departamento = new Entidades.Departamento();
        public Entidades.Departamento Departamento
        {
            get
            {
                return this.departamento;
            }
            set
            {
                this.departamento = value;
            }
        }

        private Entidades.Ciudad ciudad = new Entidades.Ciudad();
        public Entidades.Ciudad Ciudad
        {
            get
            {
                return this.ciudad;
            }
            set
            {
                this.ciudad = value;
            }
        }

        public long IdCliente { get; set; }
    }

    public class DireccionParaGrid
    {
        public int IdDireccion { get; set; }

        public string NombreDestinatario { get; set; }

        public string DireccionEnvio { get; set; }

        public string Telefono { get; set; }

        public int IdPais { get; set; }

        public string NombrePais { get; set; }

        public int IdDepartamento { get; set; }

        public string NombreDepartamento { get; set; }

        public int IdCiudad { get; set; }

        public string NombreCiudad { get; set; }

        public int IdCliente { get; set; }

        public string ConcatenacionDireccionParaGrid
        {
            get 
            {
                return this.NombreDestinatario + " , " + this.DireccionEnvio + " , " + this.Telefono + " , " + this.NombrePais + " , " + this.NombreDepartamento + " , " + this.NombreCiudad;
            }
        }
    }
}
