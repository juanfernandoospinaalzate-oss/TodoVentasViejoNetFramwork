// -----------------------------------------------------------------------
// <copyright file="UnidadPresentacion.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// ---------------------------------------------------------------------
namespace Fachada.TablasMaestras
{
    public class UnidadPresentacion : Contratos.IUnidadPresentacion
    {
        public Entidades.ResultadoTransaccion Insertar(Entidades.UnidadPresentacion unidadPresentacion)
        {
            ServicioUnidadPresentacion.UnidadPresentacionClient unidadesPresentacion = new ServicioUnidadPresentacion.UnidadPresentacionClient();
            return unidadesPresentacion.Insertar(unidadPresentacion);
        }

        public Entidades.ResultadoTransaccion Actualizar(Entidades.UnidadPresentacion unidadPresentacion)
        {
            ServicioUnidadPresentacion.UnidadPresentacionClient unidadesPresentacion = new ServicioUnidadPresentacion.UnidadPresentacionClient();
            return unidadesPresentacion.Actualizar(unidadPresentacion);
        }

        public Entidades.ResultadoTransaccion Eliminar(int IdUnidadPresentacion)
        {
            ServicioUnidadPresentacion.UnidadPresentacionClient unidadesPresentacion = new ServicioUnidadPresentacion.UnidadPresentacionClient();
            return unidadesPresentacion.Eliminar(IdUnidadPresentacion);
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.UnidadPresentacion> Listar()
        {
            ServicioUnidadPresentacion.UnidadPresentacionClient unidadPresentacion = new ServicioUnidadPresentacion.UnidadPresentacionClient();
            return unidadPresentacion.Listar();
        }
    }
}
