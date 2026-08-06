// -----------------------------------------------------------------------
// <copyright file="Cliente.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace ReglasDENegocio.TablasMaestras
{
    using Entidades;

    /// <summary>
    /// Manejo de datos del usuario en el sitio web
    /// </summary>
    public class Cliente : Contratos.ICliente
    {
        /// <summary>
        /// Actualiza los datos del cliente en la base de datos
        /// </summary>
        /// <param name="cliente">Datos de cliente</param>
        /// <returns>Resultado con mensaje y número de registros afectados</returns>
        public ResultadoTransaccion Actualizar(Entidades.Cliente cliente)
        {
            AccesoDatos.TablasMaestras.Cliente accesoDatosCliente = new AccesoDatos.TablasMaestras.Cliente();
            return accesoDatosCliente.Actualizar(cliente);
        }

        /// <summary>
        /// Recupera los datos del cliente correspondiente
        /// </summary>
        /// <param name="idCliente">Identificación del cliente usuario en la base de datos</param>
        /// <returns>datos del cliente encontrados</returns>
        public Entidades.Cliente BuscarClientePorDocCliente(int idCliente)
        {
            AccesoDatos.TablasMaestras.Cliente accesoDatosCliente = new AccesoDatos.TablasMaestras.Cliente();
            return accesoDatosCliente.BuscarClientePorDocCliente(idCliente);
        }

        /// <summary>
        /// Ingresa un cliente nuevo en la base de datos
        /// </summary>
        /// <param name="cliente">Datos nuevos de cliente</param>
        /// <returns>Resultado con mensaje y número de registros afectados</returns>
        public ResultadoTransaccion Insertar(Entidades.Cliente cliente)
        {
            AccesoDatos.TablasMaestras.Cliente accesoDatosCliente = new AccesoDatos.TablasMaestras.Cliente();
            cliente.Contrasena = Criptografia.Criptografia.Encriptar(cliente.Contrasena);

            // Si el Documento del cliente ya existe en la Base de Datos, no se hace inserción
            Entidades.Cliente resultadoBusquedaCliente = accesoDatosCliente.SeleccionarClientePorDocCliente(cliente.DocCliente);
            if (resultadoBusquedaCliente.IdCliente != 0)
            {
                // Devolver resultado de transacción no exitosa.
                Entidades.ResultadoTransaccion resultado = new Entidades.ResultadoTransaccion();
                resultado.Mensaje = Mensajes.LinqToXml.LeerMensaje("0060");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultado.Mensaje.Texto));
                resultado.RegistrosAfectados = 0;
                return resultado;
            }

            // Si el Email del cliente ya existe en la Base de Datos, no se hace inserción
            resultadoBusquedaCliente = null;
            resultadoBusquedaCliente = accesoDatosCliente.SeleccionarClientePorEmail(cliente.Email);
            if (resultadoBusquedaCliente.IdCliente != 0)
            {
                // Devolver resultado de transacción no exitosa.
                Entidades.ResultadoTransaccion resultado = new Entidades.ResultadoTransaccion();
                resultado.Mensaje = Mensajes.LinqToXml.LeerMensaje("0061");
                resultado.RegistrosAfectados = 0;
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultado.Mensaje.Texto));
                return resultado;
            }

            return accesoDatosCliente.Insertar(cliente);
        }

        /// <summary>
        /// Obtiene todos los clientes
        /// </summary>
        /// <returns>Lista completa de clientes</returns>
        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Cliente> Listar()
        {
            AccesoDatos.TablasMaestras.Cliente accesoDatosCliente = new AccesoDatos.TablasMaestras.Cliente();
            return accesoDatosCliente.Listar();
        }

        /// <summary>
        /// Consulta los datos de un cliente utilizando su identificación legal en la base de datos
        /// </summary>
        /// <param name="docCliente">Identificación legal del cliente</param>
        /// <returns>Datos del cliente</returns>
        public Entidades.Cliente SeleccionarClientePorDocCliente(int docCliente)
        {
            AccesoDatos.TablasMaestras.Cliente accesoDatosCliente = new AccesoDatos.TablasMaestras.Cliente();
            return accesoDatosCliente.SeleccionarClientePorDocCliente(docCliente);
        }

        /// <summary>
        /// Consulta los datos de un cliente utilizando su email en la base de datos
        /// </summary>
        /// <param name="email">Dirección de correo electrónico</param>
        /// <returns>Datos del usuario</returns>
        public Entidades.Cliente SeleccionarClientePorEmail(string email)
        {
            AccesoDatos.TablasMaestras.Cliente accesoDatosCliente = new AccesoDatos.TablasMaestras.Cliente();
            return accesoDatosCliente.SeleccionarClientePorEmail(email);
        }
    }
}
