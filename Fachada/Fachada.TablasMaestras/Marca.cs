// -----------------------------------------------------------------------
// <copyright file="Marca.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace Fachada.TablasMaestras
{
    using System;
    using System.Collections.ObjectModel;
    using Entidades;

    /// <summary>
    /// Formulario para la administración de marcas en la base de datos por operaciones CRUD
    /// </summary>
    public class Marca : Contratos.IMarca
    {
        /// <summary>
        /// Inserta una marca nueva en la base de datos
        /// </summary>
        /// <param name="marca">Objeto con los datos que se desean insertar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        public Entidades.ResultadoTransaccion Insertar(Entidades.Marca marca)
        {
            ServicioMarca.MarcaClient marcas = null;
            Entidades.ResultadoTransaccion ResultadoTransaccion = null;
             
            try
            {
                marcas = new ServicioMarca.MarcaClient();
                ResultadoTransaccion = marcas.Insertar(marca);
                marcas.Close();
            }
            catch (Exception ex)
            {
                Logging.ErrorGeneral.Guardar(ex);
                ResultadoTransaccion.Mensaje.Texto = ex.Message;
            }
            finally
            {
                if (marcas != null)
                {
                    ((IDisposable)marcas).Dispose();
                }
            }

            return ResultadoTransaccion;
        }

        /// <summary>
        /// Actualiza los datos de un marca en la base de datos.
        /// </summary>
        /// <param name="marca">Objeto con los datos que se desean actualizar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        public Entidades.ResultadoTransaccion Actualizar(Entidades.Marca marca)
        {
            ServicioMarca.MarcaClient marcas = null;
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();
            try
            {
                marcas = new ServicioMarca.MarcaClient();
                resultadoTransaccion = marcas.Actualizar(marca);
            }
            catch (Entidades.Excepciones.ExceptionErrorTransaccion ex)
            {
                Logging.ErrorGeneral.Guardar(ex);
            }

            return resultadoTransaccion;
        }

        /// <summary>
        /// Elimina el registro de un marca existente en la base de datos.
        /// </summary>
        /// <param name="idmarca">identificador acceder al registro que se va a eliminar</param>
        /// <returns>1 si la operación fué exitosa, 0 sino fué exitosa</returns>
        public Entidades.ResultadoTransaccion Eliminar(int idmarca)
        {
            ServicioMarca.MarcaClient marcas = null;
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();
            try
            {
                marcas = new ServicioMarca.MarcaClient();
                resultadoTransaccion = marcas.Eliminar(idmarca);
                marcas.Close();
            }
            catch (Entidades.Excepciones.ExceptionErrorTransaccion ex)
            {
                Logging.ErrorGeneral.Guardar(ex);
            }

            return resultadoTransaccion;
        }

        /// <summary>
        /// Obtiene la lista de marca de la base de datos.
        /// </summary>
        /// <returns>Lista de entidades de tipo Entidades.Marca</returns>así no 
        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Marca> Listar()
        {
            ServicioMarca.MarcaClient marca = new ServicioMarca.MarcaClient();
            System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Marca> listaReadOnlymarcas = null;
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();
            try
            {

                listaReadOnlymarcas = marca.Listar();
            }
            catch (Entidades.Excepciones.ExceptionErrorTransaccion)
            {
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
            }
            finally
            {
                if (marca != null)
                {
                    ((IDisposable)marca).Dispose();
                }
            }

            return listaReadOnlymarcas;
        }

        public ReadOnlyCollection<Entidades.Marca> ListarOrdenadoPorIdMarca()
        {
            ServicioMarca.MarcaClient marca = null;
            System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Marca> listaReadOnlymarcas = null;


            try
            {
                marca = new ServicioMarca.MarcaClient();
                listaReadOnlymarcas = marca.ListarOrdenadoPorIdMarca();
            }
            catch (Exception ex)
            {
                Logging.ErrorGeneral.Guardar(ex);
            }
            finally
            {
                if (marca != null)
                {
                    ((IDisposable)marca).Dispose();
                }
            }

            return listaReadOnlymarcas;
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Marca> ListarPorNombre(string marca)
        {
            ServicioMarca.MarcaClient Marcas = null;
            System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Marca> ListaMarcas = null;

            try
            {
                Marcas = new ServicioMarca.MarcaClient();
                ListaMarcas = Marcas.ListarPorNombre(marca);
            }
            catch (Exception ex)
            {
                Logging.ErrorGeneral.Guardar(ex);
            }
            finally
            {

            }
            return ListaMarcas;
        }

        public ReadOnlyCollection<Entidades.Marca> ListarPorId(int idMarca)
        {
            ServicioMarca.MarcaClient Marcas = null;
            System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Marca> ListaMarcas = null;

            try
            {
                Marcas = new ServicioMarca.MarcaClient();
                ListaMarcas = Marcas.ListarPorId(idMarca);
            }
            catch (Exception ex)
            {
                Logging.ErrorGeneral.Guardar(ex);
            }
            finally
            {

            }
            return ListaMarcas;
        }

        public bool VerificarRelacionArticulo(int idMarca)
        {
            ServicioMarca.MarcaClient Marcas = null;
            bool Resultado  = false;

            try
            {
                Marcas = new ServicioMarca.MarcaClient();
                Resultado = Marcas.VerificarRelacionArticulo(idMarca);
            }
            catch (Exception ex)
            {
                Logging.ErrorGeneral.Guardar(ex);
            }
            finally
            {

            }
            return Resultado;
        }
    }
}
