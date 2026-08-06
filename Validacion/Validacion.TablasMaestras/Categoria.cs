// -----------------------------------------------------------------------
// <copyright file="Categoria.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace Validacion.TablasMaestras
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
           ReglasDENegocio.TablasMaestras.Categoria categorias = new ReglasDENegocio.TablasMaestras.Categoria();
           Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();
           resultadoTransaccion.RegistrosAfectados = 0;

           // el sistema verifica que la categoría no sea nula
           if (categoria == null)
           {
               resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
               Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
               return resultadoTransaccion;
           }

           // El sistema verifica que el campo (Nombre) no se encuentre vacío.
           if (string.IsNullOrEmpty(categoria.Nombre.Trim()))
           {
               // Informar que falta por diligenciar el campo de Nombre de la categoria.               
               resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0020");
               Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
               return resultadoTransaccion;
           }

           // El sistema verifica que el campo (Descripcion) no se encuentre vacío.
           if (string.IsNullOrEmpty(categoria.Descripcion.Trim()))
           {
               // Informar que falta por diligenciar el campo de Nombre de la categoria.
               resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0021");
               Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
               return resultadoTransaccion;
           }

           // El sistema verifica que el campo (PalabraClave) no se encuentre vacío.
           if (string.IsNullOrEmpty(categoria.PalabrasClave.Trim()))
           {
               // Informar que falta por diligenciar el campo de PalabraClave de la categoria.
               resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0022");
               Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
               return resultadoTransaccion;
           }

           return categorias.Insertar(categoria);             
       }

       /// <summary>
       /// Elimina el registro de una categoría existente en la base de datos.
       /// </summary>
       /// <param name="idCategoria">Identificación de la categoría en la base de datos</param>
       /// <returns>1 si la operación fué exitosa, 0 sino fué exitosa</returns>
       public Entidades.ResultadoTransaccion Eliminar(int idCategoria)
       {
           ReglasDENegocio.TablasMaestras.Categoria categorias = new ReglasDENegocio.TablasMaestras.Categoria();
           return categorias.Eliminar(idCategoria);
       }

       /// <summary>
       /// Actualiza los datos de una categoría existente en la base de datos.
       /// </summary>
       /// <param name="categoria">Objeto con los datos que se desean actualizar</param>
       /// <returns>Resultado de la transacción con todos los detalles</returns>
       public Entidades.ResultadoTransaccion Actualizar(Entidades.Categoria categoria)
       {       
           ReglasDENegocio.TablasMaestras.Categoria categorias = new ReglasDENegocio.TablasMaestras.Categoria();
           return categorias.Actualizar(categoria);           
       }

       /// <summary>
       /// Obtiene la lista de categorías almacenada en la base de datos
       /// </summary>
       /// <returns>Lista de entidades de tipo Entidades.Categoría</returns>
       public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Categoria> Listar()
       {
          ReglasDENegocio.TablasMaestras.Categoria categorias = new ReglasDENegocio.TablasMaestras.Categoria();
           return categorias.Listar();
       }

       /// <summary>
       /// Obtiene los datos de una categoría buscando por su ID único de tabla.
       /// </summary>
       /// <param name="idCategoria">Identificación de categoría en la base de datos.</param>
       /// <returns>Objeto de tipo categoría buscada, en caso de no encontrarla retorna un valor null</returns>
       public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Categoria> ListarPorIdCategoria(int idCategoria)
       {
          ReglasDENegocio.TablasMaestras.Categoria categorias = new ReglasDENegocio.TablasMaestras.Categoria();
           return categorias.ListarPorIdCategoria(idCategoria);
       }

       /// <summary>
       /// Verifica si la categoría tiene por lo menos un artículo relacionado
       /// </summary>
       /// <param name="idCategoria">Identificación de la categoría en la base de datos</param>
       /// <returns>true si la categoría tiene por lo menos un artículo relacionado, o false si no tiene artículos relacionados</returns>
       public bool CategoriaVerificarRelacionArticulo(int idCategoria)
       {
           ReglasDENegocio.TablasMaestras.Categoria categorias = new ReglasDENegocio.TablasMaestras.Categoria();
           return categorias.CategoriaVerificarRelacionArticulo(idCategoria);
       }

       /// <summary>
       /// verifica si la categoría a eliminar no contiene subcategoría
       /// </summary>
       /// <param name="idCategoria">identificador de la tabla categoría</param>
       /// <returns>Verdadero si la categoría tiene por lo menos una subcategoría, o Falso si no tiene ninguna subcategoría relacionada</returns>
       public bool CategoriaVerificarSubCategoria(int idCategoria)
       {
           ReglasDENegocio.TablasMaestras.Categoria categorias = new ReglasDENegocio.TablasMaestras.Categoria();
           return categorias.CategoriaVerificarSubCategoria(idCategoria);
       }

       /// <summary>
       /// verifica si el nombre de la categoría ya existe con (otro Id) para no realizar la inserción ó actualización de los datos.
       /// </summary>
       /// <param name="categoria">Objeto con los datos para verificar duplicidad</param>
       /// <returns>indica si hay o no un registro relacionado</returns>
       public bool CategoriaVerificarDuplicidad(Entidades.Categoria categoria)
       {
           ReglasDENegocio.TablasMaestras.Categoria categorias = new ReglasDENegocio.TablasMaestras.Categoria();
           return categorias.CategoriaVerificarDuplicidad(categoria);
       }
    }
}
