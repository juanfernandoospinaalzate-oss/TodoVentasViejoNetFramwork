//-----------------------------------------------------------------------
// <copyright file="PAisDepartamentoCiudad.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace ReglasDENegocio.WebPublica
{
    public class PaisDepartamentoCiudad : ContratosWeb.IPaisDepartamentoCiudad
    {
        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Pais> ListarPais()
        {
            AccesoDatos.WebPublica.PaisDepartamentoCiudad PaisDepartamentoCiudad = new AccesoDatos.WebPublica.PaisDepartamentoCiudad();
            return PaisDepartamentoCiudad.ListarPais();
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Departamento> ListarDepartamento(int idPais)
        {
            AccesoDatos.WebPublica.PaisDepartamentoCiudad PaisDepartamentoCiudad = new AccesoDatos.WebPublica.PaisDepartamentoCiudad();
            return PaisDepartamentoCiudad.ListarDepartamento(idPais);
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Ciudad> ListarCiudad(int IdDpto)
        {
            AccesoDatos.WebPublica.PaisDepartamentoCiudad PaisDepartamentoCiudad = new AccesoDatos.WebPublica.PaisDepartamentoCiudad();
            return PaisDepartamentoCiudad.ListarCiudad(IdDpto);
        }
    }
}
