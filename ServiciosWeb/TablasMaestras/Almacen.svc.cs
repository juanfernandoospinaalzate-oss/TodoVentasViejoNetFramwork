namespace ServiciosWeb.TablasMaestras
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Almacen" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Almacen.svc o Almacen.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Almacen : Contratos.IAlmacen
    {
        public Entidades.ResultadoTransaccion Insertar(Entidades.Almacen almacen)
        {
            Validacion.TablasMaestras.Almacen Almacen = new Validacion.TablasMaestras.Almacen();
            return Almacen.Insertar(almacen);
        }

        public Entidades.ResultadoTransaccion Actualizar(Entidades.Almacen almacen)
        {
            Validacion.TablasMaestras.Almacen Almacen = new Validacion.TablasMaestras.Almacen();
            return Almacen.Actualizar(almacen);
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Almacen> Listar()
        {
            Validacion.TablasMaestras.Almacen Almacen = new Validacion.TablasMaestras.Almacen();
            return Almacen.Listar();
        }

        public Entidades.ResultadoTransaccion Eliminar(int idAlmacen)
        {
            Validacion.TablasMaestras.Almacen Almacen = new Validacion.TablasMaestras.Almacen();
            return Almacen.Eliminar(idAlmacen);
        }
    }
}
