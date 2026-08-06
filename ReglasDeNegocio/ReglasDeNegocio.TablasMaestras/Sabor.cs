// -----------------------------------------------------------------------
// <copyright file="Sabor.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// ----------------------------------------------------------------------
namespace ReglasDENegocio.TablasMaestras
{
    /// <summary>
    /// Formulario para la administración de sabores en la base de datos por operaciones CRUD
    /// </summary>
    public class Sabor : Contratos.ISabor
    {
        /// <summary>
        /// Inserta un sabor nuevo en la base de datos
        /// </summary>
        /// <param name="sabor">Objeto con los datos que se desean insertar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        public Entidades.ResultadoTransaccion Insertar(Entidades.Sabor sabor)
        {
            AccesoDatos.TablasMaestras.Sabor Sabor = new AccesoDatos.TablasMaestras.Sabor();
            if (Sabor.Equals(sabor))
            {
                Entidades.ResultadoTransaccion resultado = new Entidades.ResultadoTransaccion();
                resultado.RegistrosAfectados = 0;
                Entidades.Mensaje mensaje = Mensajes.LinqToXml.LeerMensaje("0011");
                resultado.Mensaje = mensaje;
                return resultado;
            }

            return Sabor.Insertar(sabor);
        }

        /// <summary>
        /// Obtiene la lista de sabores de la base de datos.
        /// </summary>
        /// <returns>Lista de entidades de tipo Entidades.Sabor</returns>
        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Sabor> Listar()
        {
            AccesoDatos.TablasMaestras.Sabor Sabor = new AccesoDatos.TablasMaestras.Sabor();
            return Sabor.Listar();
        }

        /// <summary>
        /// Elimina el registro de un sabor existente en la base de datos.
        /// </summary>
        /// <param name="idsabor">identificador acceder al registro que se va a eliminar</param>
        /// <returns>1 si la operación fué exitosa, 0 sino fué exitosa</returns>
        public Entidades.ResultadoTransaccion Eliminar(int idsabor)
        {
            AccesoDatos.TablasMaestras.Sabor Sabor = new AccesoDatos.TablasMaestras.Sabor();
            if (Sabor.Equals(idsabor))
            {
                Entidades.ResultadoTransaccion resultado = new Entidades.ResultadoTransaccion();
                resultado.RegistrosAfectados = 0;
                Entidades.Mensaje mensaje = Mensajes.LinqToXml.LeerMensaje("0002");
                resultado.Mensaje = mensaje;
                return resultado;
            }

            return Sabor.Eliminar(idsabor);
        }

        /// <summary>
        /// Actualiza los datos de un sabor de la base de datos.
        /// </summary>
        /// <param name="sabor">Objeto con los datos que se desean actualizar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        public Entidades.ResultadoTransaccion Actualizar(Entidades.Sabor sabor)
        {
            AccesoDatos.TablasMaestras.Sabor Sabor = new AccesoDatos.TablasMaestras.Sabor();
            if (Sabor.Equals(sabor))
            {
                Entidades.ResultadoTransaccion resultadoTallaVerificarDuplicidad = new Entidades.ResultadoTransaccion();
                resultadoTallaVerificarDuplicidad.RegistrosAfectados = 0;
                Entidades.Mensaje mensaje = Mensajes.LinqToXml.LeerMensaje("0015");
                resultadoTallaVerificarDuplicidad.Mensaje = mensaje;
                return resultadoTallaVerificarDuplicidad;
            }

            return Sabor.Actualizar(sabor);
        }
    }
}
