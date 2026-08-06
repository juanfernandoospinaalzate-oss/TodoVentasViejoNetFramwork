//-----------------------------------------------------------------------
// <copyright file="Albaran.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace AccesoDatos.WebPublica
{
    using EntidadesWeb;

    public class Albaran : ContratosWeb.IAlbaran
    {
        public ResultadoTransaccion Actualizar(EntidadesWeb.Albaran albaran)
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();

            EntidadesWeb.ResultadoTransaccion resultado = new EntidadesWeb.ResultadoTransaccion();            
            EntidadesWeb.ResultadoTransaccion resultadoTransaccion = new EntidadesWeb.ResultadoTransaccion();

            System.Data.SqlClient.SqlParameter paramIdVenta = null;
            System.Data.SqlClient.SqlParameter paramIdPreferencia = null;
            System.Data.SqlClient.SqlParameter paramEstadoVenta = null;

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "AlbaranUpdateIdPreferencia";

                paramIdVenta = new System.Data.SqlClient.SqlParameter("@IdAlbaran", System.Data.SqlDbType.Int);
                paramIdVenta.Value = albaran.IdAlbaran;
                cmd.Parameters.Add(paramIdVenta);

                paramIdPreferencia = new System.Data.SqlClient.SqlParameter("@IdPreferencia", System.Data.SqlDbType.NVarChar, 50);
                paramIdPreferencia.Value = albaran.IdPreferencia;
                cmd.Parameters.Add(paramIdPreferencia);

                paramEstadoVenta = new System.Data.SqlClient.SqlParameter("@EstadoVenta", System.Data.SqlDbType.NVarChar, 50);
                paramEstadoVenta.Value = albaran.EstadoDeLaVenta;
                cmd.Parameters.Add(paramEstadoVenta);


                cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                cmd.Connection.Open();
                int i = cmd.ExecuteNonQuery();
                resultado.RegistrosAfectados = i;
                resultadoTransaccion.Mensaje = MensajesWeb.LinqToXml.LeerMensaje("0009");

            }
            catch (System.Data.SqlClient.SqlException)
            {
                resultadoTransaccion.Mensaje = MensajesWeb.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new EntidadesWeb.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
            }
            catch (EntidadesWeb.Excepciones.ExceptionErrorTransaccion)
            {
                resultadoTransaccion.Mensaje = MensajesWeb.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new EntidadesWeb.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                return resultadoTransaccion;
            }
            finally
            {
                if (cmd.Connection.State == System.Data.ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }

                cmd.Dispose();
            }
            return resultadoTransaccion;
        }
    }
}
