

namespace ServiciosWeb.Busqueda
{
    using System;
    using System.Collections.ObjectModel;
    using Entidades;
    using Entidades.Enumeraciones;

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Busqueda" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Busqueda.svc or Busqueda.svc.cs at the Solution Explorer and start debugging.
    public class Busqueda : Contratos.IBusqueda
    {
        public ResultadoTransaccion Aprobar()
        {
            throw new NotImplementedException();
        }

        public ReadOnlyCollection<Entidades.Articulo> Buscar(string texto, System.Collections.ObjectModel.ReadOnlyCollection<double> idArticulos)
        {
            ServicioBusquedaWeb.BusquedaClient ServicioBusquedaWeb = null;
            Validacion.Busquedas.Busqueda Busqueda = null;

            try
            {
                ServicioBusquedaWeb = new ServiciosWeb.ServicioBusquedaWeb.BusquedaClient();
                Busqueda = new Validacion.Busquedas.Busqueda();

                // Obtener los Ids de los artículos correspondientes a la busquda (Función llamada a ServiciosWebPublica)
                ReadOnlyCollection<double> IdArticulos = ServicioBusquedaWeb.Buscar(texto);
                
                // Al ya tener los Ids de los artículos no es necesario continuar manejando el texto de la busqueda
                return Busqueda.Buscar(string.Empty, IdArticulos);
            }
            catch (Entidades.Excepciones.ExceptionErrorTransaccion ex)
            {
                Logging.ErrorGeneral.Guardar(ex);
            }

            return null;
        }

        public ReadOnlyCollection<Articulo> BuscarPorEstado(string texto, ReadOnlyCollection<double> idArticulos, Estado estado)
        {
            ServicioBusquedaWeb.BusquedaClient ServicioBusquedaWeb = null;
            Validacion.Busquedas.Busqueda Busqueda = null;

            try
            {
                ServicioBusquedaWeb = new ServiciosWeb.ServicioBusquedaWeb.BusquedaClient();
                Busqueda = new Validacion.Busquedas.Busqueda();

                // Obtener los Ids de los artículos correspondientes a la busquda (Función llamada a ServiciosWebPublica)
                ReadOnlyCollection<double> IdArticulos = ServicioBusquedaWeb.Buscar(texto);

                // Al ya tener los Ids de los artículos no es necesario continuar manejando el texto de la busqueda
                return Busqueda.BuscarPorEstado(null, IdArticulos, estado);
            }
            catch (Exception ex)
            {
                Logging.ErrorGeneral.Guardar(ex);
            }

            return null;
        }

        public ResultadoTransaccion Eliminar()
        {
            throw new NotImplementedException();
        }

        public ReadOnlyCollection<Entidades.Busqueda> Listar(bool Eliminado, bool Aprobado)
        {
            throw new NotImplementedException();
        }
    }
}
