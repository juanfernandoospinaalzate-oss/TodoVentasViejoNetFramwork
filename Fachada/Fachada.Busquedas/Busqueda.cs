

namespace Fachada.Busquedas
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
            ServicioBusqueda.BusquedaClient ServicioBusqueda = null;

            try
            {
                ServicioBusqueda = new ServicioBusqueda.BusquedaClient();
                return ServicioBusqueda.Buscar(texto, idArticulos);
            }
            catch (Exception ex)
            {
                Logging.ErrorGeneral.Guardar(ex);
            }

            return null;
        }

        public ReadOnlyCollection<Articulo> BuscarPorEstado(string texto, ReadOnlyCollection<double> idArticulos, Estado estado)
        {
            ServicioBusqueda.BusquedaClient ServicioBusqueda = null;

            try
            {
                ServicioBusqueda = new ServicioBusqueda.BusquedaClient();
                return ServicioBusqueda.BuscarPorEstado(texto, null, estado);
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
