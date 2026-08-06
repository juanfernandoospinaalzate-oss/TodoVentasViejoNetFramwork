namespace ServiciosWeb.TablasMaestras
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "PresentacionArticuloPorAlmacen" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione PresentacionArticuloPorAlmacen.svc o PresentacionArticuloPorAlmacen.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class PresentacionArticuloPorAlmacen : Contratos.IPresentacionArticuloPorAlmacen
    {
        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.PresentacionArticuloPorAlmacen> Listar()
        {
            Validacion.TablasMaestras.PresentacionArticuloPorAlmacen PresentacionArticuloPorAlmacen = new Validacion.TablasMaestras.PresentacionArticuloPorAlmacen();
            return PresentacionArticuloPorAlmacen.Listar();
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.PresentacionArticuloPorAlmacen> ListarPresentacionArticulo()
        {
            Validacion.TablasMaestras.PresentacionArticuloPorAlmacen PresentacionArticuloPorAlmacen = new Validacion.TablasMaestras.PresentacionArticuloPorAlmacen();
            return PresentacionArticuloPorAlmacen.ListarPresentacionArticulo();
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.PresentacionArticuloPorAlmacen> ListarPresentacionArticuloPorAlmacen(int idAlmacen)
        {
            Validacion.TablasMaestras.PresentacionArticuloPorAlmacen PresentacionArticuloPorAlmacen = new Validacion.TablasMaestras.PresentacionArticuloPorAlmacen();
            return PresentacionArticuloPorAlmacen.ListarPresentacionArticuloPorAlmacen(idAlmacen);
        }

        public Entidades.ResultadoTransaccion Actualizar(Entidades.PresentacionArticuloPorAlmacen presentacionArticuloPorAlmacen, Entidades.PresentacionArticuloPorAlmacen presentacionArticuloPorAlmacenDestino, int unidadesTransferidas)
        {
            Validacion.TablasMaestras.PresentacionArticuloPorAlmacen PresentacionArticuloPorAlmacen = new Validacion.TablasMaestras.PresentacionArticuloPorAlmacen();
            return PresentacionArticuloPorAlmacen.Actualizar(presentacionArticuloPorAlmacen, presentacionArticuloPorAlmacenDestino, unidadesTransferidas);
        }

        public Entidades.ResultadoTransaccion Eliminar(int idPresentacionArticuloPorAlmacen)
        {
            Validacion.TablasMaestras.PresentacionArticuloPorAlmacen PresentacionArticuloPorAlmacen = new Validacion.TablasMaestras.PresentacionArticuloPorAlmacen();
            return PresentacionArticuloPorAlmacen.Eliminar(idPresentacionArticuloPorAlmacen);
        }

        public Entidades.ResultadoTransaccion Insertar(Entidades.PresentacionArticuloPorAlmacen presentacionArticuloPorAlmacen, Entidades.PresentacionArticuloPorAlmacen presentacionArticuloPorAlmacenDestino, int unidadesTransferidas)
        {
            Validacion.TablasMaestras.PresentacionArticuloPorAlmacen PresentacionArticuloPorAlmacen = new Validacion.TablasMaestras.PresentacionArticuloPorAlmacen();
            return PresentacionArticuloPorAlmacen.Insertar(presentacionArticuloPorAlmacen, presentacionArticuloPorAlmacenDestino, unidadesTransferidas);
        }
        
        public Entidades.ResultadoTransaccion ActualizarII(Entidades.PresentacionArticuloPorAlmacen presentacionArticuloPorAlmacen, Entidades.PresentacionArticuloPorAlmacen presentacionArticuloPorAlmacenDestino, int unidadesTransferidas)
        {
            Validacion.TablasMaestras.PresentacionArticuloPorAlmacen PresentacionArticuloPorAlmacen = new Validacion.TablasMaestras.PresentacionArticuloPorAlmacen();
            return PresentacionArticuloPorAlmacen.ActualizarII(presentacionArticuloPorAlmacen, presentacionArticuloPorAlmacenDestino, unidadesTransferidas);
        }

        public Entidades.ResultadoTransaccion InsertarII(Entidades.PresentacionArticuloPorAlmacen presentacionArticuloPorAlmacen, Entidades.PresentacionArticuloPorAlmacen presentacionArticuloPorAlmacenDestino, int unidadesTransferidas)
        {
            Validacion.TablasMaestras.PresentacionArticuloPorAlmacen PresentacionArticuloPorAlmacen = new Validacion.TablasMaestras.PresentacionArticuloPorAlmacen();
            return PresentacionArticuloPorAlmacen.InsertarII(presentacionArticuloPorAlmacen, presentacionArticuloPorAlmacenDestino, unidadesTransferidas);
        }
    }
}
