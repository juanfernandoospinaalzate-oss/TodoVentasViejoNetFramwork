// -----------------------------------------------------------------------
// <copyright file="Categoria.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace ReglasDENegocio.TablasMaestras
{
    /// <summary>
    /// Formulario para la administración de categorías en la base de datos por operaciones CRUD
    /// </summary>
    public class Categoria : Contratos.ICategorias
    {
        /// <summary>
        /// Inserta una categoría nueva en la base de datos.
        /// </summary>
        /// <param name="categoria">Objeto con los datos que se desean insertar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        public Entidades.ResultadoTransaccion Insertar(Entidades.Categoria categoria)
        {
            // No se puede ingresar el registro si hay un elemento que ya existe con ese mismo nombre, no puede ser duplicado
            AccesoDatos.TablasMaestras.Categoria accesoDatosCategoria = new AccesoDatos.TablasMaestras.Categoria();

            if (accesoDatosCategoria.CategoriaVerificarDuplicidad(categoria))
            {
                Entidades.ResultadoTransaccion resultadoVerificarInserccion = new Entidades.ResultadoTransaccion();
                resultadoVerificarInserccion.RegistrosAfectados = 0;
                Entidades.Mensaje mensaje = Mensajes.LinqToXml.LeerMensaje("0023");
                resultadoVerificarInserccion.Mensaje = mensaje;
                return resultadoVerificarInserccion;
            }

            // Si la categoría padre es "Sin Categoría", se debe ingresar con id de categoría padre en cero
            if (categoria.IdCategoriaPadre == 1)
            {
                categoria.IdCategoriaPadre = 0;
            }

            Utilidades.QuitaAcentos(categoria.Nombre);

            
            return accesoDatosCategoria.Insertar(categoria);
        }

        /// <summary>
        /// Actualiza los datos de una categoría existente en la base de datos.
        /// </summary>
        /// <param name="categoria">Objeto con los datos que se desean actualizar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        public Entidades.ResultadoTransaccion Actualizar(Entidades.Categoria categoria)
        {
            // Valida Sí la cateoría ya existe con (otro Id) muestra un mensaje indicando que no se puede realizar la inserción de los datos.
            AccesoDatos.TablasMaestras.Categoria categorias = new AccesoDatos.TablasMaestras.Categoria();
            if (categorias.CategoriaVerificarDuplicidad(categoria))
            {
                Entidades.ResultadoTransaccion resultadoVerificarActualizacion = new Entidades.ResultadoTransaccion();
                resultadoVerificarActualizacion.RegistrosAfectados = 0;
                Entidades.Mensaje mensaje = Mensajes.LinqToXml.LeerMensaje("0015");
                resultadoVerificarActualizacion.Mensaje = mensaje;
                return resultadoVerificarActualizacion;
            }

            Utilidades.QuitaAcentos(categoria.Nombre);
            return categorias.Actualizar(categoria);
        }

        /// <summary>
        /// Elimina el registro de una categoría existente en la base de datos.
        /// </summary>
        /// <param name="idCategoria">Identificación de la categoría en la base de datos</param>
        /// <returns>1 si la operación fué exitosa, 0 sino fué exitosa</returns>
        public Entidades.ResultadoTransaccion Eliminar(int idCategoria)
        {
            // No permite eliminar una categoría si ésta tiene un articulo asociado.
            AccesoDatos.TablasMaestras.Categoria categorias = new AccesoDatos.TablasMaestras.Categoria();
            if (categorias.CategoriaVerificarRelacionArticulo(idCategoria))
            {
                Entidades.ResultadoTransaccion resultadoVerificarRelacionArticulo = new Entidades.ResultadoTransaccion();
                resultadoVerificarRelacionArticulo.RegistrosAfectados = 0;
                Entidades.Mensaje mensaje = Mensajes.LinqToXml.LeerMensaje("0002");
                resultadoVerificarRelacionArticulo.Mensaje = mensaje;
                return resultadoVerificarRelacionArticulo;
            }

            // La categoria no se puede eliminar debido a que esta contiene subcategorias.
            if (categorias.CategoriaVerificarSubCategoria(idCategoria))
            {
                Entidades.ResultadoTransaccion resultadoVerificarSubCategoria = new Entidades.ResultadoTransaccion();
                resultadoVerificarSubCategoria.RegistrosAfectados = 0;
                Entidades.Mensaje mensaje = Mensajes.LinqToXml.LeerMensaje("0002");
                resultadoVerificarSubCategoria.Mensaje = mensaje;
                return resultadoVerificarSubCategoria;
            }

            return categorias.Eliminar(idCategoria);
        }

        /// <summary>
        /// Obtiene la lista de categorías almacenada en la base de datos
        /// </summary>
        /// <returns>Lista de entidades de tipo Entidades.Categoría</returns>
        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Categoria> Listar()
        {
            AccesoDatos.TablasMaestras.Categoria categorias = new AccesoDatos.TablasMaestras.Categoria();
            return categorias.Listar();
        }

        /// <summary>
        /// Obtiene los datos de una categoría buscando por su ID único de tabla.
        /// </summary>
        /// <param name="idCategoria">Identificación de categoría en la base de datos.</param>
        /// <returns>Objeto de tipo categoría buscada, en caso de no encontrarla retorna un valor null</returns>
        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Categoria> ListarPorIdCategoria(int idCategoria)
        {
            AccesoDatos.TablasMaestras.Categoria categorias = new AccesoDatos.TablasMaestras.Categoria();
            return categorias.ListarPorIdCategoria(idCategoria);
        }

        /// <summary>
        /// Verifica si la categoría tiene por lo menos un artículo relacionado
        /// </summary>
        /// <param name="idCategoria">Identificación de la categoría en la base de datos</param>
        /// <returns>true si la categoría tiene por lo menos un artículo relacionado, o false si no tiene artículos relacionados</returns>
        public bool CategoriaVerificarRelacionArticulo(int idCategoria)
        {
            AccesoDatos.TablasMaestras.Categoria categorias = new AccesoDatos.TablasMaestras.Categoria();
            return categorias.CategoriaVerificarRelacionArticulo(idCategoria);
        }

        /// <summary>
        /// verifica si la categoría a eliminar no contiene subcategoría
        /// </summary>
        /// <param name="idCategoria">identificador de la tabla categoría</param>
        /// <returns>Verdadero si la categoría tiene por lo menos una subcategoría, o Falso si no tiene ninguna subcategoría relacionada</returns>
        public bool CategoriaVerificarSubCategoria(int idCategoria)
        {
            AccesoDatos.TablasMaestras.Categoria categorias = new AccesoDatos.TablasMaestras.Categoria();
            return categorias.CategoriaVerificarSubCategoria(idCategoria);
        }

        /// <summary>
        /// verifica si el nombre de la categoría ya existe con (otro Id) para no realizar la inserción ó actualización de los datos.
        /// </summary>
        /// <param name="categoria">Objeto con los datos para verificar duplicidad</param>
        /// <returns>indica si hay o no un registro relacionado</returns>
        public bool CategoriaVerificarDuplicidad(Entidades.Categoria categoria)
        {
            AccesoDatos.TablasMaestras.Categoria categorias = new AccesoDatos.TablasMaestras.Categoria();
            return categorias.CategoriaVerificarDuplicidad(categoria);
        }
    }
}
