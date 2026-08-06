

namespace ServiciosWebPublica
{
    using System.Collections.ObjectModel;
    using EntidadesWeb;

    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "PresentacionArticulo" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione PresentacionArticulo.svc o PresentacionArticulo.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class PresentacionArticulo : ContratosWeb.IPresentacionArticulo
    {
        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.PresentacionArticulo> Listar()
        {
            Validacion.WebPublica.PresentacionArticulo Presentacion = new Validacion.WebPublica.PresentacionArticulo();
            return Presentacion.Listar();
        }

        public ReadOnlyCollection<EntidadesWeb.PresentacionArticulo> ListarPendientesActualizacion()
        {
            Validacion.WebPublica.PresentacionArticulo Presentacion = new Validacion.WebPublica.PresentacionArticulo();
            return Presentacion.ListarPendientesActualizacion();
        }

        public ReadOnlyCollection<EntidadesWeb.PresentacionArticulo> ListarPorIdArticulo(int idArticulo)
        {
            Validacion.WebPublica.PresentacionArticulo Presentacion = new Validacion.WebPublica.PresentacionArticulo();
            return Presentacion.ListarPorIdArticulo(idArticulo);
        }

        public EntidadesWeb.PresentacionArticulo ConsultarPorIdPresentacionArticulo(int idPresentacionArticulo)
        {
            Validacion.WebPublica.PresentacionArticulo Presentacion = new Validacion.WebPublica.PresentacionArticulo();
            return Presentacion.ConsultarPorIdPresentacionArticulo(idPresentacionArticulo);
        }

        public ResultadoTransaccion QuitarMarcaActualizarPresentacionArticulo(int idPresentacionArticulo)
        {
            Validacion.WebPublica.PresentacionArticulo Presentacion = new Validacion.WebPublica.PresentacionArticulo();
            return Presentacion.QuitarMarcaActualizarPresentacionArticulo(idPresentacionArticulo);
        }
    }
}
