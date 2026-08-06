// -----------------------------------------------------------------------
// <copyright file="Talla.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace Fachada.TablasMaestras
{
    using System;

    /// <summary>
    /// Formulario para la administración de tallas en la base de datos por operaciones CRUD
    /// </summary>
    public class Talla : Contratos.ITallas
    {
        /// <summary>
        /// Inserta una talla nueva en la base de datos
        /// </summary>
        /// <param name="talla">Objeto con los datos que se desean insertar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        public Entidades.ResultadoTransaccion Insertar(Entidades.Talla talla) 
        {
            ServicioTalla.TallasClient tallas = null;
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

            try
            {
                tallas = new ServicioTalla.TallasClient();
            }
            catch (System.Data.SqlClient.SqlException)
            {
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
            }
            catch (Entidades.Excepciones.ExceptionErrorTransaccion)
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
            }
            finally
            {
                if (tallas != null)
                {
                    ((IDisposable)tallas).Dispose();
                }
            }

            return tallas.Insertar(talla);            
        }

        /// <summary>
        /// Actualiza los datos de una talla en la base de datos.
        /// </summary>
        /// <param name="talla">Objeto con los datos que se desean actualizar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        public Entidades.ResultadoTransaccion Actualizar(Entidades.Talla talla)
        {
            ServicioTalla.TallasClient tallas = null;
            try
            {
                tallas = new ServicioTalla.TallasClient();
                tallas.Close();
            }
            catch (Exception)
            {
                throw new Entidades.Excepciones.ExceptionErrorTransaccion("0016");
            }

            return tallas.Actualizar(talla);
        }

        /// <summary>
        /// Elimina el registro de una talla existente en la base de datos.
        /// </summary>
        /// <param name="idtalla">identificador acceder al registro que se va a eliminar</param>
        /// <returns>1 si la operación fué exitosa, 0 sino fué exitosa</returns>
        public Entidades.ResultadoTransaccion Eliminar(int idtalla)
        {
            ServicioTalla.TallasClient tallas = null;
            try
            {
                tallas = new ServicioTalla.TallasClient();
                tallas.Close();
            }
            catch (Exception)
            {
                throw new Entidades.Excepciones.ExceptionErrorTransaccion("0016");
            }

            return tallas.Eliminar(idtalla);
        }

        /// <summary>
        /// Obtiene la lista de tallas de la base de datos.
        /// </summary>
        /// <returns>Lista de entidades de tipo Entidades.Talla</returns>
        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Talla> Listar()
        {
            ServicioTalla.TallasClient talla = null;
            System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Talla> listaReadOnlytallas = null;
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

            try
            {
                talla = new ServicioTalla.TallasClient();
                listaReadOnlytallas = talla.Listar();
            }
            catch (System.Data.SqlClient.SqlException)
            {
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
            }
            catch (Entidades.Excepciones.ExceptionErrorTransaccion)
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
            }
            finally
            {
                if (talla != null)
                {
                    ((IDisposable)talla).Dispose();
                }
            }

            return listaReadOnlytallas;
        }

        /// <summary>
        /// Verifica que no se pueda ingresar una talla duplicada
        /// </summary>
        /// <param name="talla">Objeto con los datos que se desean verificar</param>
        /// <returns>indica si hay o no un registro relacionado</returns>
        public bool TallaVerificarDuplicidad(Entidades.Talla talla)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Verifica Si la talla no está relacionada(asociada) a un artículo.
        /// </summary>
        /// <param name="idTalla">identificador de Talla</param>
        /// <returns>indica si hay o no un registro relacionado</returns>
        public bool TallaVerificarRelacionArticulo(int idTalla)
        {
            throw new NotImplementedException();
        }
    }
}
