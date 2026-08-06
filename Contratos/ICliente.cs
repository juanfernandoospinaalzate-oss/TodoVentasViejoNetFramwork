// -----------------------------------------------------------------------
// <copyright file="ICliente.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace Contratos
{
    using System.ServiceModel;

    /// <summary>
    /// Manejo de datos del usuario en el sitio web
    /// </summary>
    [ServiceContract]
    public interface ICliente
    {
        /// <summary>
        /// Recupera los datos del cliente correspondiente
        /// </summary>
        /// <param name="idCliente">Identificación del cliente usuario en la base de datos</param>
        /// <returns>datos del cliente encontrados</returns>
        [OperationContract]
        Entidades.Cliente BuscarClientePorDocCliente(int idCliente);

        /// <summary>
        /// Obtiene todos los clientes
        /// </summary>
        /// <returns>Lista completa de clientes</returns>
        [OperationContract]
        System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Cliente> Listar();

        /// <summary>
        /// Ingresa un cliente nuevo en la base de datos
        /// </summary>
        /// <param name="cliente">Datos nuevos de cliente</param>
        /// <returns>Resultado con mensaje y número de registros afectados</returns>
        [OperationContract]
        Entidades.ResultadoTransaccion Insertar(Entidades.Cliente cliente);

        /// <summary>
        /// Actualiza los datos del cliente en la base de datos
        /// </summary>
        /// <param name="cliente">Datos de cliente</param>
        /// <returns>Resultado con mensaje y número de registros afectados</returns>
        [OperationContract]
        Entidades.ResultadoTransaccion Actualizar(Entidades.Cliente cliente);

        /// <summary>
        /// Consulta los datos de un cliente utilizando su identificación legal en la base de datos
        /// </summary>
        /// <param name="docCliente">Identificación legal del cliente</param>
        /// <returns>Datos del cliente</returns>
        [OperationContract]
        Entidades.Cliente SeleccionarClientePorDocCliente(int docCliente);

        /// <summary>
        /// Consulta los datos de un cliente utilizando su email en la base de datos
        /// </summary>
        /// <param name="email">Dirección de correo electrónico</param>
        /// <returns>Datos del usuario</returns>
        [OperationContract]
        Entidades.Cliente SeleccionarClientePorEmail(string email);
    }
}
