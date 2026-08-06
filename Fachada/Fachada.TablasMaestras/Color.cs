// -----------------------------------------------------------------------
// <copyright file="Color.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace Fachada.TablasMaestras
{
    using System;

    /// <summary>
    /// Formulario para la administración de colores en la base de datos por operaciones CRUD
    /// </summary>
    public class Color : Contratos.IColores
    {
        /// <summary>
        /// Inserta un color nuevo en la base de datos.
        /// </summary>
        /// <param name="color">Objeto con los datos que se desean insertar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        public Entidades.ResultadoTransaccion Insertar(Entidades.Color color)
        {
            ServicioColor.ColoresClient servicioColor = null;

            try
            {
                servicioColor = new ServicioColor.ColoresClient();
                servicioColor.Close();
            }
            catch (Exception)
            {
                throw new Entidades.Excepciones.ExceptionErrorTransaccion("0016");
            }

            return servicioColor.Insertar(color);
        }

        /// <summary>
        /// Actualiza los datos de un color existente en la base de datos.
        /// </summary>
        /// <param name="color">Objeto con los datos que se desean actualizar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        public Entidades.ResultadoTransaccion Actualizar(Entidades.Color color)
        {
            ServicioColor.ColoresClient servicioColor = null;

            try
            {
                servicioColor = new ServicioColor.ColoresClient();
                servicioColor.Close();
            }
            catch (Exception)
            {
                throw new Entidades.Excepciones.ExceptionErrorTransaccion("0016");
            }

            return servicioColor.Actualizar(color);
        }

        /// <summary>
        /// Elimina el registro de un color existente en la base de datos.
        /// </summary>
        /// <param name="idColor">Identificación del color en la base de datos</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        public Entidades.ResultadoTransaccion Eliminar(int idColor)
        {
            ServicioColor.ColoresClient servicioColor = null;

            try
            {
                servicioColor = new ServicioColor.ColoresClient();
                servicioColor.Close();
            }
            catch (Exception)
            {
                throw new Entidades.Excepciones.ExceptionErrorTransaccion("0016");
            }

            return servicioColor.Eliminar(idColor);
        }

        /// <summary>
        /// Obtiene la lista de colores almacenada en la base de datos
        /// </summary>
        /// <returns>Lista de entidades de tipo Entidades.Color</returns>
        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Color> Listar()
        {
            ServicioColor.ColoresClient color = null;
            System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Color> listaReadOnlycolores = null;
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

            try
            {
                color = new ServicioColor.ColoresClient();
                listaReadOnlycolores = color.Listar();
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
                if (color != null)
                {
                    ((IDisposable)color).Dispose();
                }
            }

            return listaReadOnlycolores;
        }

        /// <summary>
        /// Obtiene los datos de un color buscando por us ID único de tabla.
        /// </summary>
        /// <param name="idColor">Identificación de color en la base de datos.</param>
        /// <returns>Objeto de tipo color buscado, en caso de no encontrarlo retorna un valor null</returns>
        public Entidades.Color ConsultarPorId(int idColor)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Indica si el color tiene un registro relacionado en la base de datos.
        /// </summary>
        /// <param name="idColor">Identificador del color.</param>
        /// <returns>indica si hay o no un registro relacionado.</returns>
        public bool ColorVerificarRelacionArticulo(int idColor)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Indica si el código hexadecimal ya existe en un registro de la tabla de colores
        /// </summary>
        /// <param name="color">código RGB en formato Hexadecimal de 6 caracteres</param>
        /// <returns>true si el código ya está registrado o false si el código no está registrado</returns>
        public bool ColorVerificaUnicidadCodigo(Entidades.Color color)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// indica si el nombre del color ya se encuentra registrado en la tabla de colores
        /// </summary>
        /// <param name="nombreColor">Nombre del color de 20 caracteres como máximo</param>
        /// <returns>true si el nombre ya está registrado o false si el nombre no está registrado</returns>
        public bool ColorVerificaUnicidadNombre(string nombreColor)
        {
            throw new NotImplementedException();
        }
    }
}
