

namespace Fachada.TablasMaestras
{
    using System.Collections.ObjectModel;
    using Entidades;

    public class MedioDePago : Contratos.IMedioDePago
    {
        public ResultadoTransaccion Actualizar(MetodoDePago metodoDePago)
        {
            ServicioMedioDePago.MedioDePagoClient medioPago = new ServicioMedioDePago.MedioDePagoClient();
            return medioPago.Actualizar(metodoDePago);
        }

        public ResultadoTransaccion Eliminar(int IdMedioPago)
        {
            ServicioMedioDePago.MedioDePagoClient medioPago = new ServicioMedioDePago.MedioDePagoClient();
            return medioPago.Eliminar(IdMedioPago);
        }

        public ResultadoTransaccion Insertar(MetodoDePago metodoDePago)
        {
            ServicioMedioDePago.MedioDePagoClient medioPago = new ServicioMedioDePago.MedioDePagoClient();
            return medioPago.Insertar(metodoDePago);
        }

        public ReadOnlyCollection<MetodoDePago> Listar()
        {
            ServicioMedioDePago.MedioDePagoClient medioPago = new ServicioMedioDePago.MedioDePagoClient();
            return medioPago.Listar();
        }
    }
}