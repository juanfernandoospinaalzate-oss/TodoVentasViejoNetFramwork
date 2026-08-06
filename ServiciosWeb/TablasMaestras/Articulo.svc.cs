// -----------------------------------------------------------------------
// <copyright file="Articulo.svc.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// --------------------------------------------------------------------
namespace ServiciosWeb.TablasMaestras
{
    /// <summary>
    /// Formulario para la administración de artículos en la base de datos por operaciones CRUD
    /// </summary>
    public class Articulo : Contratos.IArticulos
    {
        /// <summary>
        /// Inserta un Artículo nuevo en la base de datos.
        /// </summary>
        /// <param name="articulo">Objeto con los datos que se desean insertar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        public Entidades.ResultadoTransaccion Insertar(Entidades.Articulo articulo)
        {
            Validacion.TablasMaestras.Articulo articulos = new Validacion.TablasMaestras.Articulo();
            return articulos.Insertar(articulo);
        }

        /// <summary>
        /// Actualiza los datos de un artículo en la base de datos.
        /// </summary>
        /// <param name="articulo">Objeto con los datos que se desean actualizar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        public Entidades.ResultadoTransaccion Actualizar(Entidades.Articulo articulo)
        {
            Validacion.TablasMaestras.Articulo articulos = new Validacion.TablasMaestras.Articulo();
            return articulos.Actualizar(articulo);
        }

        /// <summary>
        /// Elimina el registro de un artículo existente en la base de datos.
        /// </summary>
        /// <param name="idarticulo">identificador acceder al registro que se va a eliminar</param>
        /// <returns>1 si la operación fué exitosa, 0 sino fué exitosa</returns>
        public Entidades.ResultadoTransaccion Eliminar(int idarticulo)
        {
            Validacion.TablasMaestras.Articulo articulos = new Validacion.TablasMaestras.Articulo();
            return articulos.Eliminar(idarticulo);
        }

        /// <summary>
        /// Obtiene la lista de artículos de la base de datos.
        /// </summary>
        /// <returns>Lista de entidades de tipo Entidades.Artículo</returns>
        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Articulo> Listar()
        {
            Validacion.TablasMaestras.Articulo articulos = new Validacion.TablasMaestras.Articulo();
            return articulos.Listar();
        }

        /// <summary>
        /// Obtiene la lista por estado de artículos de la base de datos.
        /// </summary>
        /// <returns>Lista de entidades de tipo Entidades.Artículo</returns>
        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Articulo> ListarPorEstado(Entidades.Enumeraciones.EstadoInventario estado)
        {
            Validacion.TablasMaestras.Articulo articulos = new Validacion.TablasMaestras.Articulo();
            return articulos.ListarPorEstado(estado);
        }
    }
}