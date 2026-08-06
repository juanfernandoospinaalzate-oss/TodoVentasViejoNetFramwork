//-----------------------------------------------------------------------
// <copyright file="Direccion.svc.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace ServiciosWebPublica
{
    /// <summary>
    /// Administra las direcciones del usuario
    /// </summary>
    public class Direccion : ContratosWeb.IDireccion
    {
        /// <summary>
        /// Ingresa una nueva dirección asociada al usuario en la base de datos
        /// </summary>
        /// <param name="direccion">Contiene los datos que se van a ingresar</param>
        /// <returns>resultado con cantidad de registros afectados y mensaje</returns>
        public EntidadesWeb.ResultadoTransaccion Insertar(EntidadesWeb.Direccion direccion)
        {
            Validacion.WebPublica.Direccion objDireccion = new Validacion.WebPublica.Direccion();
            return objDireccion.Insertar(direccion);
        }

        /// <summary>
        /// Obtiene todas las direcciones asociadas al usuario
        /// </summary>
        /// <param name="idUsuario">Identificación del usuario en la base de datos</param>
        /// <returns>listado de direcciones asociadas al usuario encontrado</returns>
        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.DireccionParaGrid> ListarPorIdUsuario(int idUsuario)
        {
            Validacion.WebPublica.Direccion direccion = new Validacion.WebPublica.Direccion();
            return direccion.ListarPorIdUsuario(idUsuario);
        }

        /// <summary>
        /// Actualiza la dirección del usuario
        /// </summary>
        /// <param name="direccion">Contiene los datos que se van a ingresar</param>
        /// <returns>resultado con cantidad de registros afectados y mensaje</returns>
        public EntidadesWeb.ResultadoTransaccion Actualizar(EntidadesWeb.DireccionParaGrid direccion)
        {
            Validacion.WebPublica.Direccion objDireccion = new Validacion.WebPublica.Direccion();
            return objDireccion.Actualizar(direccion);
        }

        /// <summary>
        /// Elimina la dirección de un usuario
        /// </summary>
        /// <param name="idDireccion">Identificación de la dirección en la base de datos</param>
        /// <returns>resultado con cantidad de registros afectados y mensaje</returns>
        public EntidadesWeb.ResultadoTransaccion Eliminar(int idDireccion)
        {
            Validacion.WebPublica.Direccion objDireccion = new Validacion.WebPublica.Direccion();
            return objDireccion.Eliminar(idDireccion);
        }

        /// <summary>
        /// Consulta los datos de una dirección en concreto
        /// </summary>
        /// <param name="idDireccion">Identificación única de la dirección en la base de datos</param>
        /// <returns>Objeto con los datos de dirección solicitados</returns>
        public EntidadesWeb.Direccion ConsultarDireccionPorId(int idDireccion)
        {
            Validacion.WebPublica.Direccion objDireccion = new Validacion.WebPublica.Direccion();
            return objDireccion.ConsultarDireccionPorId(idDireccion);
        }
    }
}
