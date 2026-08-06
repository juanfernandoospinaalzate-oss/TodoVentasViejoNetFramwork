

namespace Validacion.TablasMaestras
{
    using System.Collections.ObjectModel;
    using Entidades;

    public class MedioDePago : Contratos.IMedioDePago
    {
        public ResultadoTransaccion Actualizar(MetodoDePago metodoDePago)
        {
            ReglasDENegocio.TablasMaestras.MedioDePago medioPago = new ReglasDENegocio.TablasMaestras.MedioDePago();
            return medioPago.Actualizar(metodoDePago);
        }

        public ResultadoTransaccion Eliminar(int IdMedioPago)
        {
            ReglasDENegocio.TablasMaestras.MedioDePago medioPago = new ReglasDENegocio.TablasMaestras.MedioDePago();
            return medioPago.Eliminar(IdMedioPago);
        }

        public ResultadoTransaccion Insertar(MetodoDePago metodoDePago)
        {
            ReglasDENegocio.TablasMaestras.MedioDePago medioPago = new ReglasDENegocio.TablasMaestras.MedioDePago();
            return medioPago.Insertar(metodoDePago);
        }

        public ReadOnlyCollection<MetodoDePago> Listar()
        {
            ReglasDENegocio.TablasMaestras.MedioDePago medioPago = new ReglasDENegocio.TablasMaestras.MedioDePago();
            return medioPago.Listar();
        }
    }
}
