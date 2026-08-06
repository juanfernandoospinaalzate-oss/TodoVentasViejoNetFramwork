// -----------------------------------------------------------------------
// <copyright file="ICategorias.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace Contratos
{
    using System.ServiceModel;

    /// <summary>
    /// interface con los contratos de operación para el servicio web Categorías.svc
    /// </summary>
    [ServiceContract]
    public interface ICategorias
    {
        /// <summary>
        /// Inserta una categoría nueva en la base de datos.
        /// </summary>
        /// <param name="categoria">Objeto con los datos que se desean insertar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns> 
        [OperationContract]
        Entidades.ResultadoTransaccion Insertar(Entidades.Categoria categoria);

        /// <summary>
        /// Actualiza los datos de una categoría existente en la base de datos.
        /// </summary>
        /// <param name="categoria">Objeto con los datos que se desean actualizar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        [OperationContract]
        Entidades.ResultadoTransaccion Actualizar(Entidades.Categoria categoria);

        /// <summary>
        /// Elimina el registro de un color existente en la base de datos.
        /// </summary>
        /// <param name="idCategoria">Identificación de la categoría en la base de datos</param>
        /// <returns>1 si la operación fué exitosa, 0 sino fué exitosa</returns>
        [OperationContract]
        Entidades.ResultadoTransaccion Eliminar(int idCategoria);

        /// <summary>
        /// Obtiene la lista de Categorías almacenada en la base de datos
        /// </summary>
        /// <returns>Lista de entidades de tipo Entidades.Categoría</returns>
        [OperationContract]
        System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Categoria> Listar();

        /// <summary>
        /// Obtiene la lista de categoría almacenada en la base de datos según el id de la categoría
        /// </summary>
        /// <param name="idCategoria">Identificación de la categoría en la base de datos</param>
        /// <returns>Lista de entidades de tipo Entidades.Categoría</returns>
        [OperationContract]
        System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Categoria> ListarPorIdCategoria(int idCategoria);

        /// <summary>
        /// Verifica si la categoría tiene por lo menos un artículo relacionado
        /// </summary>
        /// <param name="idCategoria">Identificación de la categoría en la base de datos</param>
        /// <returns>true si la categoría tiene por lo menos un artículo relacionado, o false si no tiene ningún artículo relacionado</returns>
        [OperationContract]
        bool CategoriaVerificarRelacionArticulo(int idCategoria);
        
        /// <summary>
        /// verifica si la categoría a eliminar no contiene subcategorías
        /// </summary>
        /// <param name="idCategoria">Identificación de la categoría en la base de datos</param>
        /// <returns>true si la categoría tiene por lo menos una subcategoría, o false si no tiene ninguna subcategoría relacionada</returns>
        [OperationContract]
        bool CategoriaVerificarSubCategoria(int idCategoria);

        /// <summary>
        /// verificar si el nombre de la categoría ya existe con (otro Id) para no realizar la inserción de los datos.
        /// </summary>
        /// <param name="categoria">Identificación de la categoría en la base de datos</param>
        /// <returns>true si la categoría ya existe con (otro Id), o false si no existe la categoría</returns>
        [OperationContract]
        bool CategoriaVerificarDuplicidad(Entidades.Categoria categoria);
    }
}
