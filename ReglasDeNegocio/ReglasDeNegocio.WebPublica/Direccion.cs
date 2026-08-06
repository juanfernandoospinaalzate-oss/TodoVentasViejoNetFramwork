//-----------------------------------------------------------------------
// <copyright file="Direccion.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace ReglasDENegocio.WebPublica
{
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
            AccesoDatos.WebPublica.Direccion objdireccion = new AccesoDatos.WebPublica.Direccion();
            return objdireccion.Insertar(direccion);
        }

        /// <summary>
        /// Obtiene todas las direcciones asociadas al usuario
        /// </summary>
        /// <param name="idUsuario">Identificación del usuario en la base de datos</param>
        /// <returns>listado de direcciones asociadas al usuario encontrado</returns>
        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.DireccionParaGrid> ListarPorIdUsuario(int idUsuario)
        {
            AccesoDatos.WebPublica.Direccion direccion = new AccesoDatos.WebPublica.Direccion();
            return direccion.ListarPorIdUsuario(idUsuario);
        }

        /// <summary>
        /// Actualiza la dirección del usuario
        /// </summary>
        /// <param name="direccion">Contiene los datos que se van a ingresar</param>
        /// <returns>resultado con cantidad de registros afectados y mensaje</returns>
        public EntidadesWeb.ResultadoTransaccion Actualizar(EntidadesWeb.DireccionParaGrid direccion)
        {
            AccesoDatos.WebPublica.Direccion objdireccion = new AccesoDatos.WebPublica.Direccion();
            return objdireccion.Actualizar(direccion);
        }

        /// <summary>
        /// Elimina la dirección de un usuario
        /// </summary>
        /// <param name="idDireccion">Identificación de la dirección en la base de datos</param>
        /// <returns>resultado con cantidad de registros afectados y mensaje</returns>
        public EntidadesWeb.ResultadoTransaccion Eliminar(int idDireccion)
        {
            AccesoDatos.WebPublica.Direccion direccion = new AccesoDatos.WebPublica.Direccion();
            return direccion.Eliminar(idDireccion);
        }

        /// <summary>
        /// Consulta los datos de una dirección en concreto
        /// </summary>
        /// <param name="idDireccion">Identificación única de la dirección en la base de datos</param>
        /// <returns>Objeto con los datos de dirección solicitados</returns>
        public EntidadesWeb.Direccion ConsultarDireccionPorId(int idDireccion)
        {
            AccesoDatos.WebPublica.Direccion direccion = new AccesoDatos.WebPublica.Direccion();
            return direccion.ConsultarDireccionPorId(idDireccion);
        }
    }
}
