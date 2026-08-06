//-----------------------------------------------------------------------
// <copyright file="Direccion.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace EntidadesWeb
{
    public class Direccion
    {
        public int IdDireccion { get; set; }

        public string NombreDestinatario { get; set; }

        public string DireccionEnvio { get; set; }

        public string Telefono { get; set; }

        private EntidadesWeb.Pais IdPais = new EntidadesWeb.Pais();
        public EntidadesWeb.Pais Pais
        {
            get
            {
                return this.IdPais;
            }
            set
            {
                this.IdPais = value;
            }
        }

        private EntidadesWeb.Departamento departamento = new EntidadesWeb.Departamento();
        public EntidadesWeb.Departamento Departamento
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

        private EntidadesWeb.Ciudad ciudad = new EntidadesWeb.Ciudad();
        public EntidadesWeb.Ciudad Ciudad
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

        public int IdCliente { get; set; }
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