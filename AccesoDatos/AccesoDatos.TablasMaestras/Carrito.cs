//-----------------------------------------------------------------------
// <copyright file="Carrito.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace AccesoDatos.TablasMaestras
{
    public class Carrito : Contratos.ICarrito
    {
        public Entidades.ResultadoTransaccion EliminarPorIdPresentacionArticulo(int IdpresentacionArticulo)
        {
            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlParameter paramIdPresentacion = null;
            Entidades.ResultadoTransaccion ResultadoTransaccion = new Entidades.ResultadoTransaccion();

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "CarritoEliminarPorIdPresentacionArticulo";

                paramIdPresentacion = new System.Data.SqlClient.SqlParameter("@IdPresentacionArticulo", System.Data.SqlDbType.Int);
                paramIdPresentacion.Value = IdpresentacionArticulo;
                cmd.Parameters.Add(paramIdPresentacion);

                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();
                ResultadoTransaccion.RegistrosAfectados = cmd.ExecuteNonQuery();
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

            return ResultadoTransaccion;
        }
    }
}
