

namespace ServiciosWeb.TablasMaestras
{
    using System.Collections.ObjectModel;
    using Entidades;

    public class MedioDePago : Contratos.IMedioDePago
    {
        public ResultadoTransaccion Actualizar(MetodoDePago metodoDePago)
        {
            Validacion.TablasMaestras.MedioDePago medioPago = new Validacion.TablasMaestras.MedioDePago();
            return medioPago.Actualizar(metodoDePago);
        }

        public ResultadoTransaccion Eliminar(int IdMedioPago)
        {
            Validacion.TablasMaestras.MedioDePago medioPago = new Validacion.TablasMaestras.MedioDePago();
            return medioPago.Eliminar(IdMedioPago);
        }

        public ResultadoTransaccion Insertar(MetodoDePago metodoDePago)
        {
            Validacion.TablasMaestras.MedioDePago medioPago = new Validacion.TablasMaestras.MedioDePago();
            return medioPago.Insertar(metodoDePago);
        }

        public ReadOnlyCollection<MetodoDePago> Listar()
        {
            Validacion.TablasMaestras.MedioDePago medioPago = new Validacion.TablasMaestras.MedioDePago();
            return medioPago.Listar();
        }
    }
}
