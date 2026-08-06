namespace ContratosWeb
{
    using System.ServiceModel;

    /// <summary>
    /// Manejo de datos del usuario en el sitio web
    /// </summary>
    [ServiceContract]
    public interface IClientes
    {
        /// <summary>
        /// Inserta un nuevo usuario para el sitio web
        /// </summary>
        /// <param name="cliente">Datos del nuevo usuario</param>
        /// <param name="direccion">Dirección usada para entregas</param>
        /// <returns>Resultado de la transacción con mensaje y número de registros afectados</returns>
        [OperationContract]
        EntidadesWeb.ResultadoTransaccion Insertar(EntidadesWeb.Cliente cliente, EntidadesWeb.Direccion direccion);

        /// <summary>
        /// Consulta los datos de un cliente utilizando su id en la base de datos
        /// </summary>
        /// <param name="idCliente">Identificación del cliente en la base de datos</param>
        /// <returns>Datos del uusuario</returns>
        [OperationContract]
        EntidadesWeb.Cliente SeleccionarClientePorIdCliente(int idCliente);

        /// <summary>
        /// Actualiza los datos del usuario en el sitio web
        /// </summary>
        /// <param name="cliente">Datos del usuario para actualizar en la base de datos</param>
        /// <returns>Resultado con mensaje y cantidad de registros afectados</returns>
        [OperationContract]
        EntidadesWeb.ResultadoTransaccion Actualizar(EntidadesWeb.Cliente cliente);

        /// <summary>
        /// Consulta los datos de un cliente utilizando su email en la base de datos
        /// </summary>
        /// <param name="email">Dirección de correo electrónico</param>
        /// <returns>Datos del uusuario</returns>
        [OperationContract]
        EntidadesWeb.Cliente SeleccionarClientePorEmail(string email);

        /// <summary>
        /// Actualiza la clave de acceso del usuario en la base de datos
        /// </summary>
        /// <param name="idCliente">Identificación del usuario en la base de datos</param>
        /// <param name="passwordNuevo">Nuevo password del usuario en el sitio web</param>
        /// <param name="passwordNuevoVerificacion">Confirmación del nuevo password del usuario en el sitio web</param>
        /// <param name="passwordActual">Password actual del usuario en el sitio web</param>
        /// <returns>Resultado con mensaje y cantidad de registros afectados</returns>
        [OperationContract]
        EntidadesWeb.ResultadoTransaccion CambioPassword(int idCliente, string passwordNuevo, string passwordNuevoVerificacion, string passwordActual);

        /// <summary>
        /// Consulta los datos de un cliente utilizando su identificación legal en la base de datos
        /// </summary>
        /// <param name="docCliente">identificación legal del usuario</param>
        /// <returns>Datos del cliente</returns>
        [OperationContract]
        EntidadesWeb.Cliente SeleccionarClientePorDocCliente(int docCliente);

        /// <summary>
        /// Reemplaza el password del usuario correspondiente en la base de datos
        /// </summary>
        /// <param name="idCliente">Identificación del usuario</param>
        /// <param name="passwordNuevo">Nuevo password del usuario en el sitio web</param>
        /// <param name="passwordNuevoVerificacion">Confirmación del nuevo password del usuario en el sitio web</param>
        /// <returns>Resultado con mensaje y número de registros afectados</returns>
        [OperationContract]
        EntidadesWeb.ResultadoTransaccion RecuperarPassword(int idCliente, string passwordNuevo, string passwordNuevoVerificacion);


    }
}
