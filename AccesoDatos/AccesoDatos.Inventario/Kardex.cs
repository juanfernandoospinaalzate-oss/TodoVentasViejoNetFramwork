//-----------------------------------------------------------------------
// <copyright file="Kardex.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace AccesoDatos.Inventario
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Entidades;

    public class Kardex : Contratos.IKardex
    {
        /// <summary>
        /// Verifica si ya existen registros relacionados en la tabla de kardex para esta presentación de artículo
        /// </summary>
        /// <param name="idPresentacionArticulo">Identificador único de la presentación de artículo</param>
        /// <returns>Retorna true si ya hay registros para esta presentación, de lo contrario retorna false</returns>
        public bool VerificarRelacionPresentacionArticulo(int idPresentacionArticulo)
        {
            Entidades.ResultadoTransaccion ResultadoTransaccion = null;
            System.Data.SqlClient.SqlConnection Conexion = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.Connection = Conexion;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "KardexSelectPorIdPresentacionArticulo";
            System.Data.SqlClient.SqlDataReader dataReader = null;

            try
            {
                System.Data.SqlClient.SqlParameter paramIdPresentacionArticulo = new System.Data.SqlClient.SqlParameter("@IdPresentacionArticulo", System.Data.SqlDbType.Int);
                paramIdPresentacionArticulo.Value = idPresentacionArticulo;
                cmd.Parameters.Add(paramIdPresentacionArticulo);
                cmd.Connection.Open();
                dataReader = cmd.ExecuteReader();

                if (dataReader.Read() == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                ResultadoTransaccion.Mensaje.Texto = ex.Message;
                Logging.ErrorGeneral.Guardar(ex);
            }
            catch (Entidades.Excepciones.ExceptionErrorTransaccion ex)
            {
                ResultadoTransaccion.Mensaje.Texto = ex.Message;
                Logging.ErrorGeneral.Guardar(ex);
            }
            catch (Exception ex)
            {
                ResultadoTransaccion.Mensaje.Texto = ex.Message;
                Logging.ErrorGeneral.Guardar(ex);
            }
            finally
            {
                if (cmd.Connection.State == System.Data.ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }

                cmd.Dispose();
            }

            throw new NotImplementedException();
        }

        public Entidades.ResultadoTransaccion Insertar(Entidades.Kardex registro)
        {
            Entidades.ResultadoTransaccion ResultadoTransaccion = null;
            System.Data.SqlClient.SqlCommand cmd = null;

            try
            {
                ResultadoTransaccion = new Entidades.ResultadoTransaccion();
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "KardexInsert";
                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);

                System.Data.SqlClient.SqlParameter paramIdPresentacionArticulo = new System.Data.SqlClient.SqlParameter("@IdPresentacionArticulo", System.Data.SqlDbType.Int);
                paramIdPresentacionArticulo.Value = registro.IdPresentacionArticulo;
                cmd.Parameters.Add(paramIdPresentacionArticulo);

                System.Data.SqlClient.SqlParameter paramFecha = new System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime);
                paramFecha.Value = registro.Fecha;
                cmd.Parameters.Add(paramFecha);

                System.Data.SqlClient.SqlParameter paramNombre = new System.Data.SqlClient.SqlParameter("@Nombre", System.Data.SqlDbType.NVarChar, 100);
                paramNombre.Value = registro.Nombre;
                cmd.Parameters.Add(paramNombre);

                System.Data.SqlClient.SqlParameter paramCantidadEntrada = new System.Data.SqlClient.SqlParameter("@CantidadEntrada", System.Data.SqlDbType.Int);
                paramCantidadEntrada.Value = registro.CantidadEntrada;
                cmd.Parameters.Add(paramCantidadEntrada);

                System.Data.SqlClient.SqlParameter paramCantidadSalida = new System.Data.SqlClient.SqlParameter("@CantidadSalida", System.Data.SqlDbType.Int);
                paramCantidadSalida.Value = registro.CantidadSalida;
                cmd.Parameters.Add(paramCantidadSalida);

                System.Data.SqlClient.SqlParameter paramPrecioUnitario = new System.Data.SqlClient.SqlParameter("@PrecioUnitario", System.Data.SqlDbType.Float);
                paramPrecioUnitario.Value = registro.PrecioUnitario;
                cmd.Parameters.Add(paramPrecioUnitario);

                System.Data.SqlClient.SqlParameter paramCostoUnitario = new System.Data.SqlClient.SqlParameter("@CostoUnitario", System.Data.SqlDbType.Float);
                paramCostoUnitario.Value = registro.CostoUnitario;
                cmd.Parameters.Add(paramCostoUnitario);

                System.Data.SqlClient.SqlParameter paramTotalExistencias = new System.Data.SqlClient.SqlParameter("@TotalExistencias", System.Data.SqlDbType.Int);
                paramTotalExistencias.Value = registro.TotalExistencias;
                cmd.Parameters.Add(paramTotalExistencias);

                System.Data.SqlClient.SqlParameter paramPrecioTotal = new System.Data.SqlClient.SqlParameter("@PrecioTotal", System.Data.SqlDbType.Float);
                paramPrecioTotal.Value = registro.PrecioTotal;
                cmd.Parameters.Add(paramPrecioTotal);

                System.Data.SqlClient.SqlParameter paramCostoTotal = new System.Data.SqlClient.SqlParameter("@CostoTotal", System.Data.SqlDbType.Float);
                paramCostoTotal.Value = registro.CostoTotal;
                cmd.Parameters.Add(paramCostoTotal);

                System.Data.SqlClient.SqlParameter paramDetalle = new System.Data.SqlClient.SqlParameter("@Detalle", System.Data.SqlDbType.NVarChar, 100);
                paramDetalle.Value = registro.Detalle;
                cmd.Parameters.Add(paramDetalle);

                cmd.Connection.Open();
               
                #if Pruebas
                    // Prueba de Integración
                    cmd.Transaction = cmd.Connection.BeginTransaction();
                    ResultadoTransaccion.RegistrosAfectados = cmd.ExecuteNonQuery();
                    cmd.Transaction.Rollback();
                #else
                    ResultadoTransaccion.RegistrosAfectados = cmd.ExecuteNonQuery();
                #endif

                ResultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0077"); // Mensaje de registro Exitoso
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                ResultadoTransaccion.Mensaje.Texto = ex.Message;
                Logging.ErrorGeneral.Guardar(ex);
            }
            catch (Entidades.Excepciones.ExceptionErrorTransaccion ex)
            {
                ResultadoTransaccion.Mensaje.Texto = ex.Message;
                Logging.ErrorGeneral.Guardar(ex);
            }
            catch (Exception ex)
            {
                ResultadoTransaccion.Mensaje.Texto = ex.Message;
                Logging.ErrorGeneral.Guardar(ex);
            }
            finally
            {
                if (cmd.Connection.State == System.Data.ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }

                cmd.Dispose();
            }
            
            return ResultadoTransaccion;
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Kardex> ListarPorIdPresentacionArticulo(int idPresentacionArticulo)
        {
            Entidades.ResultadoTransaccion ResultadoTransaccion = null;
            
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "KardexSelectPorIdPresentacionArticulo";
            System.Data.SqlClient.SqlDataReader dataReader = null;
            System.Collections.Generic.List<Entidades.Kardex> ListaKardex = new List<Entidades.Kardex>();

            try
            {
                System.Data.SqlClient.SqlParameter paramIdPresentacionArticulo = new System.Data.SqlClient.SqlParameter("@IdPresentacionArticulo", System.Data.SqlDbType.Int);
                paramIdPresentacionArticulo.Value = idPresentacionArticulo;
                cmd.Parameters.Add(paramIdPresentacionArticulo);
                cmd.Connection.Open();
                dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Entidades.Kardex Kardex = new Entidades.Kardex()
                    {
                        IdPresentacionArticulo = dataReader.GetInt32(1),
                        Fecha = dataReader.GetDateTime(2),
                        Nombre = dataReader.GetString(3),
                        CantidadEntrada = dataReader.GetInt32(4),
                        CantidadSalida = dataReader.GetInt32(5),
                        PrecioUnitario = dataReader.GetDouble(6),
                        CostoUnitario = dataReader.GetDouble(7),
                        TotalExistencias = dataReader.GetInt32(8),
                        PrecioTotal = dataReader.GetDouble(9),
                        CostoTotal = dataReader.GetDouble(10),
                        Detalle = dataReader.GetString(11)
                    };

                    ListaKardex.Add(Kardex);

                    // Asegura en la prueba de integración solo devolver un elemento (el primero encontrado)
                    #if Pruebas
                        break; 
                    #endif

                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                ResultadoTransaccion.Mensaje.Texto = ex.Message;
                Logging.ErrorGeneral.Guardar(ex);
            }
            catch (Entidades.Excepciones.ExceptionErrorTransaccion ex)
            {
                ResultadoTransaccion.Mensaje.Texto = ex.Message;
                Logging.ErrorGeneral.Guardar(ex);
            }
            finally
            {
                if (cmd.Connection.State == System.Data.ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }

                cmd.Dispose();
            }

            return new ReadOnlyCollection<Entidades.Kardex>(ListaKardex);
        }
    }
}
