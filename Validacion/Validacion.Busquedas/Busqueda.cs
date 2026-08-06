

namespace Validacion.Busquedas
{
    using System;
    using System.Collections.ObjectModel;
    using Entidades;
    using Entidades.Enumeraciones;

    public class Busqueda : Contratos.IBusqueda
    {
        public Entidades.ResultadoTransaccion Aprobar()
        {
            throw new NotImplementedException();
        }

        public ReadOnlyCollection<Entidades.Articulo> Buscar(string texto, System.Collections.ObjectModel.ReadOnlyCollection<double> idArticulos)
        {
            ReglaDENegocio.Busquedas.Busqueda Busqueda = null;

            try
            {
                // El texto de búsqueda ya fue limpiado y validado desde el servicio web que realiza la busqueda de Ids
                // no es necesario hacer nuevamente el proceso, desde este punto el texto ya debe llegar vació y solo seguir on la lista de Ids de los artículos
                Busqueda = new ReglaDENegocio.Busquedas.Busqueda();
                return Busqueda.Buscar(string.Empty, idArticulos);
            }
            catch (Entidades.Excepciones.ExceptionErrorTransaccion ex)
            {
                Logging.ErrorGeneral.Guardar(ex);
            }

            return null;
        }

        public ReadOnlyCollection<Articulo> BuscarPorEstado(string texto, ReadOnlyCollection<double> idArticulos, Estado estado)
        {
            ReglaDENegocio.Busquedas.Busqueda Busqueda = null;

            try
            {
                // El texto de búsqueda ya fue limpiado y validado desde el servicio web que realiza la busqueda de Ids
                // no es necesario hacer nuevamente el proceso, desde este punto el texto ya debe llegar vació y solo seguir on la lista de Ids de los artículos
                Busqueda = new ReglaDENegocio.Busquedas.Busqueda();
                return Busqueda.BuscarPorEstado(string.Empty, idArticulos, estado);
            }
            catch (Exception ex)
            {
                Logging.ErrorGeneral.Guardar(ex);
            }

            return null;
        }

        public Entidades.ResultadoTransaccion Eliminar()
        {
            throw new NotImplementedException();
        }

        public ReadOnlyCollection<Entidades.Busqueda> Listar(bool Eliminado, bool Aprobado)
        {
            throw new NotImplementedException();
        }
    }
}
