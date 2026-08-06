namespace Fachada.TablasMaestras
{
    public class EstadoDELAVenta : Contratos.IEstadoVenta
    {
        public Entidades.ResultadoTransaccion Insertar(Entidades.EstadoVenta estadoDeLaVenta)
        {
            ServicioEstadoDeLaVenta.EstadoVentaClient EstadoDeLaVenta = new ServicioEstadoDeLaVenta.EstadoVentaClient();
            return EstadoDeLaVenta.Insertar(estadoDeLaVenta);
        }

        public Entidades.ResultadoTransaccion Actualizar(Entidades.EstadoVenta estadoDeLaVenta)
        {
            ServicioEstadoDeLaVenta.EstadoVentaClient EstadoDeLaVenta = new ServicioEstadoDeLaVenta.EstadoVentaClient();
            return EstadoDeLaVenta.Actualizar(estadoDeLaVenta);
        }


        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.EstadoVenta> Listar()
        {
            ServicioEstadoDeLaVenta.EstadoVentaClient EstadoDeLaVenta = new ServicioEstadoDeLaVenta.EstadoVentaClient();
            return EstadoDeLaVenta.Listar();
        }

        public Entidades.ResultadoTransaccion Eliminar(int idEstadoVenta)
        {
            ServicioEstadoDeLaVenta.EstadoVentaClient EstadoDeLaVenta = new ServicioEstadoDeLaVenta.EstadoVentaClient();
            return EstadoDeLaVenta.Eliminar(idEstadoVenta);
        }
    }
}
