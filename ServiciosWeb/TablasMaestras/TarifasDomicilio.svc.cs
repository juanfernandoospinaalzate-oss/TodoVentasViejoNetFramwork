

namespace ServiciosWeb.TablasMaestras
{
    using System.Collections.ObjectModel;
    using Entidades;

    public class TarifasDomicilio : Contratos.ITarifasDomicilio
    {
        public ResultadoTransaccion Actualizar(Entidades.TarifasDomicilio tarifasDomicilio)
        {
            Validacion.TablasMaestras.TarifasDomicilio TarifasDomicilio = new Validacion.TablasMaestras.TarifasDomicilio();
            return TarifasDomicilio.Actualizar(tarifasDomicilio);
        }

        public ResultadoTransaccion Eliminar(int idtarifasDomicilio)
        {
            Validacion.TablasMaestras.TarifasDomicilio TarifasDomicilio = new Validacion.TablasMaestras.TarifasDomicilio();
            return TarifasDomicilio.Eliminar(idtarifasDomicilio);
        }

        public ResultadoTransaccion Insertar(Entidades.TarifasDomicilio tarifasDomicilio)
        {
            Validacion.TablasMaestras.TarifasDomicilio TarifasDomicilio = new Validacion.TablasMaestras.TarifasDomicilio();
            return TarifasDomicilio.Insertar(tarifasDomicilio);
        }

        public ReadOnlyCollection<Entidades.TarifasDomicilio> Listar()
        {
            Validacion.TablasMaestras.TarifasDomicilio TarifasDomicilio = new Validacion.TablasMaestras.TarifasDomicilio();
            return TarifasDomicilio.Listar();
        }
    }
}
