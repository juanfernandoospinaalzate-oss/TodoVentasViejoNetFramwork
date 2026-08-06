namespace Validacion.WebPublica
{
    public class PaisDepartamentoCiudad : ContratosWeb.IPaisDepartamentoCiudad
    {
        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Pais> ListarPais()
        {
            ReglasDENegocio.WebPublica.PaisDepartamentoCiudad PaisDepartamentoCiudad = new ReglasDENegocio.WebPublica.PaisDepartamentoCiudad();
            return PaisDepartamentoCiudad.ListarPais();
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Departamento> ListarDepartamento(int idPais)
        {
            ReglasDENegocio.WebPublica.PaisDepartamentoCiudad PaisDepartamentoCiudad = new ReglasDENegocio.WebPublica.PaisDepartamentoCiudad();
            return PaisDepartamentoCiudad.ListarDepartamento(idPais);
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Ciudad> ListarCiudad(int IdDpto)
        {
            ReglasDENegocio.WebPublica.PaisDepartamentoCiudad PaisDepartamentoCiudad = new ReglasDENegocio.WebPublica.PaisDepartamentoCiudad();
            return PaisDepartamentoCiudad.ListarCiudad(IdDpto);
        }
    }
}
