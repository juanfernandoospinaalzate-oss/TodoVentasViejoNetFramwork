//-----------------------------------------------------------------------
// <copyright file="IMetodoDePago.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace Contratos
{
    using System.ServiceModel;

    [ServiceContract]
    interface IMetodoDePago
    {

        [OperationContract]
        Entidades.ResultadoTransaccion Insertar(Entidades.MetodoDePago metodoPago);

        /// <summary>
        /// Obtiene una lista con todos los países disponibles
        /// </summary>
        /// <returns>Lista con todos los países disponibles</returns>
        [OperationContract]
        System.Collections.ObjectModel.ReadOnlyCollection<Entidades.MetodoDePago> Listar();

        /// <summary>
        /// Eliminar un país nuevo en la base de datos.
        /// </summary>
        /// <param name="idtalla">identificador de los datos que se desean eliminar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        [OperationContract]
        Entidades.ResultadoTransaccion Eliminar(int idMetodoPago);




    }
}
