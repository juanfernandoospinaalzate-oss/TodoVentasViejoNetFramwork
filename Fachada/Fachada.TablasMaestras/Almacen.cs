namespace Fachada.TablasMaestras
{
    public class Almacen : Contratos.IAlmacen
    {
        public Entidades.ResultadoTransaccion Insertar(Entidades.Almacen almacen)
        {
            ServicioAlmacen.AlmacenClient Almacen = new ServicioAlmacen.AlmacenClient();
            return Almacen.Insertar(almacen);
        }

        public Entidades.ResultadoTransaccion Actualizar(Entidades.Almacen almacen)
        {
            ServicioAlmacen.AlmacenClient Almacen = new ServicioAlmacen.AlmacenClient();
            return Almacen.Actualizar(almacen);
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Almacen> Listar()
        {
            ServicioAlmacen.AlmacenClient Almacen = new ServicioAlmacen.AlmacenClient();
            return Almacen.Listar();
        }

        public Entidades.ResultadoTransaccion Eliminar(int idAlmacen)
        {
            ServicioAlmacen.AlmacenClient Almacen = new ServicioAlmacen.AlmacenClient();
            return Almacen.Eliminar(idAlmacen);
        }
    }
}
