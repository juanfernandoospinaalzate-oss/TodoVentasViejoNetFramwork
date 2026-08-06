

namespace Fachada.TablasMaestras
{
    using System.Collections.ObjectModel;
    using Entidades;

    public class TarifasDomicilio : Contratos.ITarifasDomicilio
    {
        public ResultadoTransaccion Actualizar(Entidades.TarifasDomicilio tarifasDomicilio)
        {
            ServicioTarifasDomicilio.TarifasDomicilioClient TarifasDomicilio = new ServicioTarifasDomicilio.TarifasDomicilioClient();
            return TarifasDomicilio.Actualizar(tarifasDomicilio);
        }

        public ResultadoTransaccion Eliminar(int idtarifasDomicilio)
        {
            ServicioTarifasDomicilio.TarifasDomicilioClient TarifasDomicilio = new ServicioTarifasDomicilio.TarifasDomicilioClient();
            return TarifasDomicilio.Eliminar(idtarifasDomicilio);
        }

        public ResultadoTransaccion Insertar(Entidades.TarifasDomicilio tarifasDomicilio)
        {
            ServicioTarifasDomicilio.TarifasDomicilioClient TarifasDomicilio = new ServicioTarifasDomicilio.TarifasDomicilioClient();
            return TarifasDomicilio.Insertar(tarifasDomicilio);
        }

        public ReadOnlyCollection<Entidades.TarifasDomicilio> Listar()
        {
            ServicioTarifasDomicilio.TarifasDomicilioClient TarifasDomicilio = new ServicioTarifasDomicilio.TarifasDomicilioClient();
            return TarifasDomicilio.Listar();
        }
    }
}
