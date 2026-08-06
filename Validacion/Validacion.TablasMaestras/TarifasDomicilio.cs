

namespace Validacion.TablasMaestras
{
    using System.Collections.ObjectModel;
    using Entidades;

    public class TarifasDomicilio : Contratos.ITarifasDomicilio
    {
        public ResultadoTransaccion Actualizar(Entidades.TarifasDomicilio tarifasDomicilio)
        {
            ReglasDENegocio.TablasMaestras.TarifasDomicilio TarifasDomicilio = new ReglasDENegocio.TablasMaestras.TarifasDomicilio();
            return TarifasDomicilio.Actualizar(tarifasDomicilio);
        }

        public ResultadoTransaccion Eliminar(int idtarifasDomicilio)
        {
            ReglasDENegocio.TablasMaestras.TarifasDomicilio TarifasDomicilio = new ReglasDENegocio.TablasMaestras.TarifasDomicilio();
            return TarifasDomicilio.Eliminar(idtarifasDomicilio);
        }

        public ResultadoTransaccion Insertar(Entidades.TarifasDomicilio tarifasDomicilio)
        {
            ReglasDENegocio.TablasMaestras.TarifasDomicilio TarifasDomicilio = new ReglasDENegocio.TablasMaestras.TarifasDomicilio();
            return TarifasDomicilio.Insertar(tarifasDomicilio);
        }

        public ReadOnlyCollection<Entidades.TarifasDomicilio> Listar()
        {
            ReglasDENegocio.TablasMaestras.TarifasDomicilio TarifasDomicilio = new ReglasDENegocio.TablasMaestras.TarifasDomicilio();
            return TarifasDomicilio.Listar();
        }
    }
}
