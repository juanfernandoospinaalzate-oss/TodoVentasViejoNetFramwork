//-----------------------------------------------------------------------
// <copyright file="Direccion.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace Fachada.WebPublica
{
    using System;

    /// <summary>
    /// Administra las direcciones del usuario
    /// </summary>
    public class Direccion : ContratosWeb.IDireccion
    {
        /// <summary>
        /// Inserta una dirección nuevo en la base de datos.
        /// </summary>
        /// <param name="direccion">Objeto con los datos que se desean insertar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        public EntidadesWeb.ResultadoTransaccion Insertar(EntidadesWeb.Direccion direccion)
        {
            ServicioDireccion.DireccionClient objdireccion = new ServicioDireccion.DireccionClient();
            return objdireccion.Insertar(direccion);
        }

        /// <summary>
        /// Obtiene todas las direcciones asociadas al usuario
        /// </summary>
        /// <param name="idUsuario">Identificación del usuario en la base de datos</param>
        /// <returns>listado de direcciones asociadas al usuario encontrado</returns>
        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.DireccionParaGrid> ListarPorIdUsuario(int idUsuario)
        {
            ServicioDireccion.DireccionClient direccion = new ServicioDireccion.DireccionClient();
            return direccion.ListarPorIdUsuario(idUsuario);
        }

        /// <summary>
        /// Actualiza la dirección del usuario
        /// </summary>
        /// <param name="direccion">Contiene los datos que se van a ingresar</param>
        /// <returns>resultado con cantidad de registros afectados y mensaje</returns>
        public EntidadesWeb.ResultadoTransaccion Actualizar(EntidadesWeb.DireccionParaGrid direccion)
        {
            ServicioDireccion.DireccionClient objdireccion = new ServicioDireccion.DireccionClient();
            return objdireccion.Actualizar(direccion);
        }

        /// <summary>
        /// Elimina la dirección de un usuario
        /// </summary>
        /// <param name="idDireccion">Identificación de la dirección en la base de datos</param>
        /// <returns>resultado con cantidad de registros afectados y mensaje</returns>
        public EntidadesWeb.ResultadoTransaccion Eliminar(int idDireccion)
        {
            ServicioDireccion.DireccionClient direccion = new ServicioDireccion.DireccionClient();
            return direccion.Eliminar(idDireccion);
        }

        /// <summary>
        /// Consulta los datos de una dirección en concreto
        /// </summary>
        /// <param name="idDireccion">Identificación única de la dirección en la base de datos</param>
        /// <returns>Objeto con los datos de dirección solicitados</returns>
        public EntidadesWeb.Direccion ConsultarDireccionPorId(int idDireccion)
        {
            ServicioDireccion.DireccionClient direccion = new ServicioDireccion.DireccionClient();
            return direccion.ConsultarDireccionPorId(idDireccion);
        }
    }
}
