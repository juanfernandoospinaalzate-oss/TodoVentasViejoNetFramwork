// -----------------------------------------------------------------------
// <copyright file="EstadoDeLaVenta.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace ReglasDENegocio.TablasMaestras
{
    public class EstadoDeLaVenta : Contratos.IEstadoVenta
    {
        public Entidades.ResultadoTransaccion Insertar(Entidades.EstadoVenta estadoDeLaVenta)
        {
            AccesoDatos.TablasMaestras.EstadoDELAVenta EstadoDeLaVenta = new AccesoDatos.TablasMaestras.EstadoDELAVenta();
            return EstadoDeLaVenta.Insertar(estadoDeLaVenta);
        }

        public Entidades.ResultadoTransaccion Actualizar(Entidades.EstadoVenta estadoDeLaVenta)
        {
            AccesoDatos.TablasMaestras.EstadoDELAVenta EstadoDeLaVenta = new AccesoDatos.TablasMaestras.EstadoDELAVenta();
            return EstadoDeLaVenta.Actualizar(estadoDeLaVenta);
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.EstadoVenta> Listar()
        {
            AccesoDatos.TablasMaestras.EstadoDELAVenta EstadoDeLaVenta = new AccesoDatos.TablasMaestras.EstadoDELAVenta();
            return EstadoDeLaVenta.Listar();
        }

        public Entidades.ResultadoTransaccion Eliminar(int idEstadoVenta)
        {
            AccesoDatos.TablasMaestras.EstadoDELAVenta EstadoDeLaVenta = new AccesoDatos.TablasMaestras.EstadoDELAVenta();
            return EstadoDeLaVenta.Eliminar(idEstadoVenta);
        }
    }
}
