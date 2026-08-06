// -----------------------------------------------------------------------
// <copyright file="Busqueda.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace Fachada.WebPublica
{
    using System;

    public class Busqueda : ContratosWeb.IBusqueda
    {
        public System.Collections.ObjectModel.ReadOnlyCollection<string> Listar(string texto)
        {
            ServicioBusqueda.BusquedaClient Busqueda = new ServicioBusqueda.BusquedaClient();
            return Busqueda.Listar(texto);
        }


        public void Insertar(string texto)
        {
            ServicioBusqueda.BusquedaClient Busqueda = new ServicioBusqueda.BusquedaClient();
            Busqueda.Insertar(texto);
        }


        public System.Collections.ObjectModel.ReadOnlyCollection<double> Buscar(string texto)
        {
            ServicioBusqueda.BusquedaClient Busqueda = new ServicioBusqueda.BusquedaClient();
            return Busqueda.Buscar(texto);
        }

        public string GenerarConsultaSQL(string textoBusqueda)
        {
            throw new NotImplementedException();
        }
    }
}
