//-----------------------------------------------------------------------
// <copyright file="CargaDescargaInventario.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace AccesoDatos.Inventario
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CargaDescargaInventario : Contratos.ICargaDescargaInventario
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="idPresentacionArticulo"></param>
        public CargaDescargaInventario(int idPresentacionArticulo)
        {
            
        }

        public Entidades.ResultadoTransaccion Cargar(string codigoBarras, int cantidad, Entidades.Kardex kardex, bool ActivarPresentacionArticulo)
        {
            Entidades.ResultadoTransaccion ResultadoTransaccion = null;
            Entidades.ResultadoTransaccion ResultadoTransaccionKardex = null;
            System.Data.SqlClient.SqlConnection Conexion = null;
            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlCommand cmdKardex = null;
            System.Data.SqlClient.SqlParameter paramCantidad = null;
            System.Data.SqlClient.SqlParameter paramIdPresentacionArticulo = null;
            System.Data.SqlClient.SqlParameter paramActivo = null;
            System.Data.SqlClient.SqlParameter paramIdPresentacionArticuloKardex = null;
            System.Data.SqlClient.SqlParameter paramFecha = null;
            System.Data.SqlClient.SqlParameter paramNombre = null;
            System.Data.SqlClient.SqlParameter paramCantidadEntrada = null;
            System.Data.SqlClient.SqlParameter paramCantidadSalida = null;
            System.Data.SqlClient.SqlParameter paramPrecioUnitario = null;
            System.Data.SqlClient.SqlParameter paramCostoUnitario = null;
            System.Data.SqlClient.SqlParameter paramTotalExistencias = null;
            System.Data.SqlClient.SqlParameter paramPrecioTotal = null;
            System.Data.SqlClient.SqlParameter paramCostoTotal = null;
            System.Data.SqlClient.SqlParameter paramDetalle = null;

            try
            {
                Conexion = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd = new System.Data.SqlClient.SqlCommand("PresentacionArticuloUpdateStock", Conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmdKardex = new System.Data.SqlClient.SqlCommand("KardexInsert", Conexion);
                cmdKardex.CommandType = System.Data.CommandType.StoredProcedure;

                // Paramatros para actualizar stock
                paramCantidad = new System.Data.SqlClient.SqlParameter("@Cantidad", System.Data.SqlDbType.Int);
                paramIdPresentacionArticulo = new System.Data.SqlClient.SqlParameter("@IdPresentacionArticulo", System.Data.SqlDbType.Int);
                paramActivo = new System.Data.SqlClient.SqlParameter("@Activo", System.Data.SqlDbType.Bit);
                cmd.Parameters.Add(paramCantidad);
                cmd.Parameters.Add(paramIdPresentacionArticulo);
                cmd.Parameters.Add(paramActivo);
                paramCantidad.Value = cantidad; // Para actualizar cargando cantidad, se debe llegar el valor negativo desde regla de negocios)
                paramIdPresentacionArticulo.Value = kardex.IdPresentacionArticulo;
                paramActivo.Value = ActivarPresentacionArticulo;

                // Parametros para el kardex
                paramIdPresentacionArticuloKardex = new System.Data.SqlClient.SqlParameter("@IdPresentacionArticulo", System.Data.SqlDbType.Int);
                cmdKardex.Parameters.Add(paramIdPresentacionArticuloKardex);
                paramFecha = new System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime);
                cmdKardex.Parameters.Add(paramFecha);
                paramNombre = new System.Data.SqlClient.SqlParameter("@Nombre", System.Data.SqlDbType.NVarChar, 100);
                cmdKardex.Parameters.Add(paramNombre);
                paramCantidadEntrada = new System.Data.SqlClient.SqlParameter("@CantidadEntrada", System.Data.SqlDbType.Int);
                cmdKardex.Parameters.Add(paramCantidadEntrada);
                paramCantidadSalida = new System.Data.SqlClient.SqlParameter("@CantidadSalida", System.Data.SqlDbType.Int);
                cmdKardex.Parameters.Add(paramCantidadSalida);
                paramPrecioUnitario = new System.Data.SqlClient.SqlParameter("@PrecioUnitario", System.Data.SqlDbType.Float);
                cmdKardex.Parameters.Add(paramPrecioUnitario);
                paramCostoUnitario = new System.Data.SqlClient.SqlParameter("@CostoUnitario", System.Data.SqlDbType.Float);
                cmdKardex.Parameters.Add(paramCostoUnitario);
                paramTotalExistencias = new System.Data.SqlClient.SqlParameter("@TotalExistencias", System.Data.SqlDbType.Int);
                cmdKardex.Parameters.Add(paramTotalExistencias);
                paramPrecioTotal = new System.Data.SqlClient.SqlParameter("@PrecioTotal", System.Data.SqlDbType.Float);
                cmdKardex.Parameters.Add(paramPrecioTotal);
                paramCostoTotal = new System.Data.SqlClient.SqlParameter("@CostoTotal", System.Data.SqlDbType.Float);
                cmdKardex.Parameters.Add(paramCostoTotal);
                paramDetalle = new System.Data.SqlClient.SqlParameter("@Detalle", System.Data.SqlDbType.NVarChar, 100);
                cmdKardex.Parameters.Add(paramDetalle);

                ResultadoTransaccion = new Entidades.ResultadoTransaccion();
                ResultadoTransaccionKardex = new Entidades.ResultadoTransaccion();
                
                paramIdPresentacionArticuloKardex.Value = kardex.IdPresentacionArticulo;
                paramFecha.Value = kardex.Fecha;
                paramNombre.Value = kardex.Nombre;
                paramCantidadEntrada.Value = kardex.CantidadEntrada;
                paramCantidadSalida.Value = kardex.CantidadSalida;
                paramPrecioUnitario.Value = kardex.PrecioUnitario;
                paramCostoUnitario.Value = kardex.CostoUnitario;
                paramTotalExistencias.Value = kardex.TotalExistencias;
                paramPrecioTotal.Value = kardex.PrecioTotal;
                paramCostoTotal.Value = kardex.CostoTotal;
                paramDetalle.Value = kardex.Detalle;

                cmd.Connection.Open();
                cmd.Transaction = cmd.Connection.BeginTransaction();
                cmdKardex.Transaction = cmd.Transaction;

                ResultadoTransaccion.RegistrosAfectados = cmd.ExecuteNonQuery();
                ResultadoTransaccionKardex.RegistrosAfectados = cmdKardex.ExecuteNonQuery();
                ResultadoTransaccion.RegistrosAfectados = ResultadoTransaccion.RegistrosAfectados + ResultadoTransaccionKardex.RegistrosAfectados;

                #if Pruebas
                cmd.Transaction.Rollback();
                #else
                if (ResultadoTransaccion.RegistrosAfectados == 2)
                {
                    cmd.Transaction.Commit();
                }
                else
                {
                    cmd.Transaction.Rollback();
                    ResultadoTransaccion.RegistrosAfectados = 0;
                }
                #endif

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                cmd.Transaction.Rollback();
                ResultadoTransaccion.RegistrosAfectados = 0;
                ResultadoTransaccion.Mensaje.Texto = ex.Message;
                Logging.ErrorGeneral.Guardar(ex);
            }
            catch (Entidades.Excepciones.ExceptionErrorTransaccion ex)
            {
                cmd.Transaction.Rollback();
                ResultadoTransaccion.RegistrosAfectados = 0;
                ResultadoTransaccion.Mensaje.Texto = ex.Message;
                Logging.ErrorGeneral.Guardar(ex);
            }
            catch (Exception ex)
            {
                cmd.Transaction.Rollback();
                ResultadoTransaccion.RegistrosAfectados = 0;
                ResultadoTransaccion.Mensaje.Texto = ex.Message;
                Logging.ErrorGeneral.Guardar(ex);
            }
            finally
            {
                if (cmd.Connection.State == System.Data.ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }

                if (cmdKardex.Connection.State == System.Data.ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }

                cmd.Dispose();
            }

            return ResultadoTransaccion;
        }

        public Entidades.ResultadoTransaccion Descargar(string codigoBarras, int cantidad, Entidades.Kardex kardex)
        {
            // Para descargar se reutiliza la función de descargar pero usando cantidad negativa
            return this.Cargar(codigoBarras, cantidad, kardex, false);
        }
    }
}
