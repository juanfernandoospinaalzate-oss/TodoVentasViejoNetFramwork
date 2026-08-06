// -----------------------------------------------------------------------
// <copyright file="Almacen.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace ReglasDENegocio.TablasMaestras
{
    public class Almacen : Contratos.IAlmacen
    {
        public Entidades.ResultadoTransaccion Insertar(Entidades.Almacen almacen)
        {
            AccesoDatos.TablasMaestras.Almacen Almacen = new AccesoDatos.TablasMaestras.Almacen();
            return Almacen.Insertar(almacen);
        }

        public Entidades.ResultadoTransaccion Actualizar(Entidades.Almacen almacen)
        {
            AccesoDatos.TablasMaestras.Almacen Almacen = new AccesoDatos.TablasMaestras.Almacen();
            return Almacen.Actualizar(almacen);
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Almacen> Listar()
        {
            AccesoDatos.TablasMaestras.Almacen Almacen = new AccesoDatos.TablasMaestras.Almacen();
            return Almacen.Listar();
        }

        public Entidades.ResultadoTransaccion Eliminar(int idAlmacen)
        {
            AccesoDatos.TablasMaestras.Almacen Almacen = new AccesoDatos.TablasMaestras.Almacen();
            return Almacen.Eliminar(idAlmacen);
        }
    }
}
