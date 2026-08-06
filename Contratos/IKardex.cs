//-----------------------------------------------------------------------
// <copyright file="IKardex.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace Contratos
{
    using System.ServiceModel;

    [ServiceContract]
    public interface IKardex
    {
        /// <summary>
        /// Insert un registro nuevo en el kardex
        /// </summary>
        /// <param name="registro">Nuevo registro para insertar en el kardex</param>
        /// <returns></returns>
        [OperationContract]
        Entidades.ResultadoTransaccion Insertar(Entidades.Kardex registro);

        /// <summary>
        /// Lista todos los registros correspondientes
        /// </summary>
        /// <param name="idPresentacionArticulo">Identificación única de la presentación de artículo</param>
        /// <returns></returns>
        [OperationContract]
        System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Kardex> ListarPorIdPresentacionArticulo(int idPresentacionArticulo);

        /// <summary>
        /// Verifica si ya existen registros relacionados en la tabla de kardex para esta presentación de artículo
        /// </summary>
        /// <param name="idPresentacionArticulo">Identificador único de la presentación de artículo</param>
        /// <returns>Retorna true si ya hay registros para esta presentación, de lo contrario retorna false</returns>
        [OperationContract]
        bool VerificarRelacionPresentacionArticulo(int idPresentacionArticulo);
    }
}
