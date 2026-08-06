

namespace Validacion.TablasMaestras
{
    using System;

    public class Pais : Contratos.IPais
    {
        public Entidades.ResultadoTransaccion Insertar(Entidades.Pais pais)
        {
            ReglasDENegocio.TablasMaestras.Pais Pais = new ReglasDENegocio.TablasMaestras.Pais();
            return Pais.Insertar(pais);
        }


        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Pais> Listar()
        {
            ReglasDENegocio.TablasMaestras.Pais Pais = new ReglasDENegocio.TablasMaestras.Pais();
            return Pais.Listar();
        }


        public Entidades.ResultadoTransaccion Eliminar(int idpais)
        {
            ReglasDENegocio.TablasMaestras.Pais Pais = new ReglasDENegocio.TablasMaestras.Pais();
            return Pais.Eliminar(idpais);
        }


        public bool PaisVerificarRelacionDpto(int idpais)
        {
            throw new NotImplementedException();
        }
    }
}
