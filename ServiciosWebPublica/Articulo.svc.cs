

namespace ServiciosWebPublica
{
    using System.Collections.ObjectModel;
    using EntidadesWeb;

    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Articulo" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Articulo.svc o Articulo.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Articulo : ContratosWeb.IArticulo
    {
        public EntidadesWeb.Articulo ConsultarArticuloPorIdArtículo(int idArticulo)
        {
            Validacion.WebPublica.Articulo Articulo = new Validacion.WebPublica.Articulo();
            return Articulo.ConsultarArticuloPorIdArtículo(idArticulo);
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Articulo> Listar()
        {
            Validacion.WebPublica.Articulo Articulo = null;
            System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Articulo> ListaArtículos = null;

            try
            {
                Articulo = new Validacion.WebPublica.Articulo();
                ListaArtículos = Articulo.Listar();
            }
            catch (EntidadesWeb.Excepciones.ExceptionErrorTransaccion ex)
            {
                Logging.ErrorGeneral.Guardar(ex);
            }

            return ListaArtículos;
        }

        public ReadOnlyCollection<EntidadesWeb.Articulo> ListarPendientesActualizacion()
        {
            Validacion.WebPublica.Articulo Articulo = new Validacion.WebPublica.Articulo();
            return Articulo.ListarPendientesActualizacion();
        }

        public ReadOnlyCollection<double> ListarPorIdsCategorias(System.Collections.ObjectModel.ReadOnlyCollection<double> IdsCategorias)
        {
            Validacion.WebPublica.Articulo Articulo = new Validacion.WebPublica.Articulo();
            return Articulo.ListarPorIdsCategorias(IdsCategorias);
        }

        public ResultadoTransaccion QuitarMarcaActualizarArticulo(int idArticulo)
        {
            Validacion.WebPublica.Articulo Articulo = new Validacion.WebPublica.Articulo();
            return Articulo.QuitarMarcaActualizarArticulo(idArticulo);
        }
    }
}
