//-----------------------------------------------------------------------
// <copyright file="PresentacionArticuloPorAlmacen.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace AccesoDatos.TablasMaestras
{
    using System.Collections.Generic;

    public class PresentacionArticuloPorAlmacen : Contratos.IPresentacionArticuloPorAlmacen
    {
        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.PresentacionArticuloPorAlmacen> Listar()
        {
            List<Entidades.PresentacionArticuloPorAlmacen> ListaPresentacionArticuloPorAlmacen = new List<Entidades.PresentacionArticuloPorAlmacen>();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataReader datareader = null;
            System.Collections.ObjectModel.ReadOnlyCollection<Entidades.PresentacionArticuloPorAlmacen> listaReadOnlyPresentacionArticuloPorAlmacen = null;

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "ArticulosPorAlmacenSelect";
                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();
                datareader = cmd.ExecuteReader();

                while (datareader.Read())
                {
                    Entidades.PresentacionArticuloPorAlmacen EntidadAlmacen = new Entidades.PresentacionArticuloPorAlmacen();

                    EntidadAlmacen.IdPresentacionArticuloPorAlmacen = datareader.GetInt32(0);
                    EntidadAlmacen.IdAlmacen = datareader.GetInt32(1);
                    EntidadAlmacen.NombreCompleto = datareader.GetString(2);
                    ListaPresentacionArticuloPorAlmacen.Add(EntidadAlmacen);
                }

                listaReadOnlyPresentacionArticuloPorAlmacen = new System.Collections.ObjectModel.ReadOnlyCollection<Entidades.PresentacionArticuloPorAlmacen>(ListaPresentacionArticuloPorAlmacen);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Logging.ErrorGeneral.Guardar(ex);
            }
            finally
            {
                if (cmd.Connection.State == System.Data.ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }

                cmd.Dispose();

                if (datareader != null)
                {
                    datareader.Dispose();
                }
            }

            return listaReadOnlyPresentacionArticuloPorAlmacen;
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.PresentacionArticuloPorAlmacen> ListarPresentacionArticulo()
        {
            List<Entidades.PresentacionArticuloPorAlmacen> ListaPresentacionArticulo = new List<Entidades.PresentacionArticuloPorAlmacen>();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataReader datareader = null;
            System.Collections.ObjectModel.ReadOnlyCollection<Entidades.PresentacionArticuloPorAlmacen> listaReadOnlyPresentacionArticuloPorAlmacen = null;

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "ListarPresentacionArticulo";
                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();
                datareader = cmd.ExecuteReader();

                while (datareader.Read())
                {
                    Entidades.PresentacionArticuloPorAlmacen EntidadPresentacionArticulo = new Entidades.PresentacionArticuloPorAlmacen()
                    {
                        NombrePresentacionArticulo = datareader.GetString(0),
                        DescripcionBreve = datareader.GetString(1)
                    };
                    ListaPresentacionArticulo.Add(EntidadPresentacionArticulo);
                }

                listaReadOnlyPresentacionArticuloPorAlmacen = new System.Collections.ObjectModel.ReadOnlyCollection<Entidades.PresentacionArticuloPorAlmacen>(ListaPresentacionArticulo);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Logging.ErrorGeneral.Guardar(ex);
            }
            finally
            {
                if (cmd.Connection.State == System.Data.ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }

                cmd.Dispose();

                if (datareader != null)
                {
                    datareader.Dispose();
                }
            }

            return listaReadOnlyPresentacionArticuloPorAlmacen;
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.PresentacionArticuloPorAlmacen> ListarPresentacionArticuloPorAlmacen(int idAlmacen)
        {
            List<Entidades.PresentacionArticuloPorAlmacen> ListaPresentacionArticuloPorAlmacen = new List<Entidades.PresentacionArticuloPorAlmacen>();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataReader datareader = null;
            System.Data.SqlClient.SqlParameter paramIdAlmacen = null;
            System.Collections.ObjectModel.ReadOnlyCollection<Entidades.PresentacionArticuloPorAlmacen> listaReadOnlyPresentacionArticuloPorAlmacen = null;

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "ListarPresentacionArticuloPorAlmacen";

                paramIdAlmacen = new System.Data.SqlClient.SqlParameter("@IdAlmacen", System.Data.SqlDbType.Int);
                paramIdAlmacen.Value = idAlmacen;
                cmd.Parameters.Add(paramIdAlmacen);

                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();
                datareader = cmd.ExecuteReader();

                while (datareader.Read())
                {
                    Entidades.PresentacionArticuloPorAlmacen EntidadPresentacionArticuloPorAlmacen = new Entidades.PresentacionArticuloPorAlmacen();

                    EntidadPresentacionArticuloPorAlmacen.Existencia = datareader.GetInt32(0);
                    EntidadPresentacionArticuloPorAlmacen.MaxExistencias = datareader.GetInt32(1);
                    EntidadPresentacionArticuloPorAlmacen.MinExistencias = datareader.GetInt32(2);
                    EntidadPresentacionArticuloPorAlmacen.CostoUnitario = datareader.GetDecimal(3);
                    EntidadPresentacionArticuloPorAlmacen.PrecioVenta = datareader.GetDecimal(4);
                    EntidadPresentacionArticuloPorAlmacen.NombrePresentacionArticulo = datareader.GetString(5);
                    EntidadPresentacionArticuloPorAlmacen.IdPresentacionArticuloPorAlmacen = datareader.GetInt32(6);
                    EntidadPresentacionArticuloPorAlmacen.IdAlmacen = datareader.GetInt32(7);


                    ListaPresentacionArticuloPorAlmacen.Add(EntidadPresentacionArticuloPorAlmacen);
                }

                listaReadOnlyPresentacionArticuloPorAlmacen = new System.Collections.ObjectModel.ReadOnlyCollection<Entidades.PresentacionArticuloPorAlmacen>(ListaPresentacionArticuloPorAlmacen);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Logging.ErrorGeneral.Guardar(ex);
            }
            finally
            {
                if (cmd.Connection.State == System.Data.ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }

                cmd.Dispose();

                if (datareader != null)
                {
                    datareader.Dispose();
                }
            }

            return listaReadOnlyPresentacionArticuloPorAlmacen;
        }

        public Entidades.ResultadoTransaccion Actualizar(Entidades.PresentacionArticuloPorAlmacen presentacionArticuloPorAlmacen, Entidades.PresentacionArticuloPorAlmacen presentacionArticuloPorAlmacenDestino, int unidadesTransferidas)
        {
            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlParameter paramIdPresentacion = null;
            System.Data.SqlClient.SqlParameter paramIdAlmacen = null;
            System.Data.SqlClient.SqlParameter paramExistencia = null;
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "PresentacionArticuloPorAlmacenUpdate";

                paramIdPresentacion = new System.Data.SqlClient.SqlParameter("@IdPresentacionArticulo", System.Data.SqlDbType.Int);
                paramIdPresentacion.Value = presentacionArticuloPorAlmacen.IdPresentacionArticuloPorAlmacen;
                cmd.Parameters.Add(paramIdPresentacion);

                paramIdAlmacen = new System.Data.SqlClient.SqlParameter("@IdAlmacen", System.Data.SqlDbType.Int);
                paramIdAlmacen.Value = presentacionArticuloPorAlmacen.IdAlmacen;
                cmd.Parameters.Add(paramIdAlmacen);

                paramExistencia = new System.Data.SqlClient.SqlParameter("@Existencia", System.Data.SqlDbType.Int);
                paramExistencia.Value = presentacionArticuloPorAlmacen.Existencia;
                cmd.Parameters.Add(paramExistencia);


                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();
                int i = cmd.ExecuteNonQuery();

                if (i == 1)
                {
                    paramIdPresentacion.Value = presentacionArticuloPorAlmacenDestino.IdPresentacionArticuloPorAlmacen;
                    paramIdAlmacen.Value = presentacionArticuloPorAlmacenDestino.IdAlmacen;
                    paramExistencia.Value = presentacionArticuloPorAlmacenDestino.Existencia;

                    i = cmd.ExecuteNonQuery();
                }

                resultadoTransaccion.RegistrosAfectados = i;
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0007");
            }
            catch (System.Data.SqlClient.SqlException)
            {
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
            }
            catch (Entidades.Excepciones.ExceptionErrorTransaccion)
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
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

        public Entidades.ResultadoTransaccion Eliminar(int idPresentacionArticuloPorAlmacen)
        {
            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlParameter paramIdPresentacionArticuloPorAlmacen = null;
            Entidades.ResultadoTransaccion resultado = new Entidades.ResultadoTransaccion();
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "PresentacionArticuloPorAlmacenDelete";

                paramIdPresentacionArticuloPorAlmacen = new System.Data.SqlClient.SqlParameter("@IdPresentacionArticuloPorAlmacen", System.Data.SqlDbType.Int);
                paramIdPresentacionArticuloPorAlmacen.Value = idPresentacionArticuloPorAlmacen;
                cmd.Parameters.Add(paramIdPresentacionArticuloPorAlmacen);

                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();
                int i = cmd.ExecuteNonQuery();
                resultado.RegistrosAfectados = i;
                resultado.Mensaje = Mensajes.LinqToXml.LeerMensaje("0006");
            }
            catch (System.Data.SqlClient.SqlException)
            {
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
            }
            catch (Entidades.Excepciones.ExceptionErrorTransaccion)
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
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

            return resultado;
        }

        public Entidades.ResultadoTransaccion Insertar(Entidades.PresentacionArticuloPorAlmacen presentacionArticuloPorAlmacen, Entidades.PresentacionArticuloPorAlmacen presentacionArticuloPorAlmacenDestino, int unidadesTransferidas)
        {
            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlParameter paramIdPresentacionArticuloPorAlmacen = null;
            System.Data.SqlClient.SqlParameter paramIdAlmacen = null;
            System.Data.SqlClient.SqlParameter paramExistencia = null;
            System.Data.SqlClient.SqlParameter paramMaxExistencias = null;
            System.Data.SqlClient.SqlParameter paramMinExistencias = null;
            System.Data.SqlClient.SqlParameter paramCostoUnitario = null;
            System.Data.SqlClient.SqlParameter paramPrecioVenta = null;
            System.Data.SqlClient.SqlParameter paramIva = null;
            
            
            Entidades.ResultadoTransaccion resultado = new Entidades.ResultadoTransaccion();
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "PresentacionArticuloPorAlmacenInsert";

                paramIdPresentacionArticuloPorAlmacen = new System.Data.SqlClient.SqlParameter("@IdPresentacionArticulo", System.Data.SqlDbType.Int);
                paramIdPresentacionArticuloPorAlmacen.Value = presentacionArticuloPorAlmacen.IdPresentacionArticuloPorAlmacen;
                cmd.Parameters.Add(paramIdPresentacionArticuloPorAlmacen);

                paramIdAlmacen = new System.Data.SqlClient.SqlParameter("@IdAlmacen", System.Data.SqlDbType.Int);
                paramIdAlmacen.Value = presentacionArticuloPorAlmacenDestino.IdAlmacen;
                cmd.Parameters.Add(paramIdAlmacen);

                paramExistencia = new System.Data.SqlClient.SqlParameter("@Existencia", System.Data.SqlDbType.Int);
                paramExistencia.Value = presentacionArticuloPorAlmacenDestino.Existencia;
                cmd.Parameters.Add(paramExistencia);

                paramMaxExistencias = new System.Data.SqlClient.SqlParameter("@MaxExistencias", System.Data.SqlDbType.Int);
                paramMaxExistencias.Value = presentacionArticuloPorAlmacenDestino.MaxExistencias;
                cmd.Parameters.Add(paramMaxExistencias);

                paramMinExistencias = new System.Data.SqlClient.SqlParameter("@MinExistencias", System.Data.SqlDbType.Int);
                paramMinExistencias.Value = presentacionArticuloPorAlmacenDestino.MinExistencias;
                cmd.Parameters.Add(paramMinExistencias);

                paramCostoUnitario = new System.Data.SqlClient.SqlParameter("@CostoUnitario", System.Data.SqlDbType.Decimal);
                paramCostoUnitario.Value = presentacionArticuloPorAlmacenDestino.CostoUnitario;
                cmd.Parameters.Add(paramCostoUnitario);

                paramPrecioVenta = new System.Data.SqlClient.SqlParameter("@PrecioVenta", System.Data.SqlDbType.Decimal);
                paramPrecioVenta.Value = presentacionArticuloPorAlmacenDestino.PrecioVenta;
                cmd.Parameters.Add(paramPrecioVenta);

                paramIva = new System.Data.SqlClient.SqlParameter("@Iva", System.Data.SqlDbType.Decimal);
                paramIva.Value = 0.16;
                cmd.Parameters.Add(paramIva);

                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();
                int i = cmd.ExecuteNonQuery();

                if (i == 1)
                {
                    
                    cmd.CommandText = "PresentacionArticuloPorAlmacenUpdate";
                    cmd.Parameters.Clear();

                    paramIdPresentacionArticuloPorAlmacen = new System.Data.SqlClient.SqlParameter("@IdPresentacionArticulo", System.Data.SqlDbType.Int);
                    paramIdPresentacionArticuloPorAlmacen.Value = presentacionArticuloPorAlmacen.IdPresentacionArticuloPorAlmacen;
                    cmd.Parameters.Add(paramIdPresentacionArticuloPorAlmacen);

                    paramIdAlmacen = new System.Data.SqlClient.SqlParameter("@IdAlmacen", System.Data.SqlDbType.Int);
                    paramIdAlmacen.Value = presentacionArticuloPorAlmacen.IdAlmacen;
                    cmd.Parameters.Add(paramIdAlmacen);

                    paramExistencia = new System.Data.SqlClient.SqlParameter("@Existencia", System.Data.SqlDbType.Int);
                    paramExistencia.Value = presentacionArticuloPorAlmacen.Existencia;
                    cmd.Parameters.Add(paramExistencia);

                    // paramIdPresentacionArticuloPorAlmacen.Value = presentacionArticuloPorAlmacenDestino.IdPresentacionArticuloPorAlmacen;
                    // paramIdAlmacen.Value = presentacionArticuloPorAlmacenDestino.IdAlmacen;
                    // paramExistencia.Value = presentacionArticuloPorAlmacenDestino.Existencia;

                    i = cmd.ExecuteNonQuery();
                }

                resultado.RegistrosAfectados = i;
                resultado.Mensaje = Mensajes.LinqToXml.LeerMensaje("0009");
            }
            catch (System.Data.SqlClient.SqlException)
            {
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
            }
            catch (Entidades.Excepciones.ExceptionErrorTransaccion)
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
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

            return resultado;
        }

        public Entidades.ResultadoTransaccion ActualizarII(Entidades.PresentacionArticuloPorAlmacen presentacionArticuloPorAlmacen, Entidades.PresentacionArticuloPorAlmacen presentacionArticuloPorAlmacenDestino, int unidadesTransferidas)
        {
            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlParameter paramIdPresentacion = null;
            System.Data.SqlClient.SqlParameter paramIdAlmacen = null;
            System.Data.SqlClient.SqlParameter paramExistencia = null;
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "PresentacionArticuloPorAlmacenUpdate";

                paramIdPresentacion = new System.Data.SqlClient.SqlParameter("@IdPresentacionArticulo", System.Data.SqlDbType.Int);
                paramIdPresentacion.Value = presentacionArticuloPorAlmacen.IdPresentacionArticuloPorAlmacen;
                cmd.Parameters.Add(paramIdPresentacion);

                paramIdAlmacen = new System.Data.SqlClient.SqlParameter("@IdAlmacen", System.Data.SqlDbType.Int);
                paramIdAlmacen.Value = presentacionArticuloPorAlmacen.IdAlmacen;
                cmd.Parameters.Add(paramIdAlmacen);

                paramExistencia = new System.Data.SqlClient.SqlParameter("@Existencia", System.Data.SqlDbType.Int);
                paramExistencia.Value = presentacionArticuloPorAlmacen.Existencia;
                cmd.Parameters.Add(paramExistencia);


                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();
                int i = cmd.ExecuteNonQuery();

                if (i == 1)
                {
                    paramIdPresentacion.Value = presentacionArticuloPorAlmacenDestino.IdPresentacionArticuloPorAlmacen;
                    paramIdAlmacen.Value = presentacionArticuloPorAlmacenDestino.IdAlmacen;
                    paramExistencia.Value = presentacionArticuloPorAlmacenDestino.Existencia;

                    i = cmd.ExecuteNonQuery();
                }

                resultadoTransaccion.RegistrosAfectados = i;
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0007");
            }
            catch (System.Data.SqlClient.SqlException)
            {
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
            }
            catch (Entidades.Excepciones.ExceptionErrorTransaccion)
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
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

        public Entidades.ResultadoTransaccion InsertarII(Entidades.PresentacionArticuloPorAlmacen presentacionArticuloPorAlmacen, Entidades.PresentacionArticuloPorAlmacen presentacionArticuloPorAlmacenDestino, int unidadesTransferidas)
        {
            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlParameter paramIdPresentacionArticuloPorAlmacen = null;
            System.Data.SqlClient.SqlParameter paramIdAlmacen = null;
            System.Data.SqlClient.SqlParameter paramExistencia = null;
            System.Data.SqlClient.SqlParameter paramMaxExistencias = null;
            System.Data.SqlClient.SqlParameter paramMinExistencias = null;
            System.Data.SqlClient.SqlParameter paramCostoUnitario = null;
            System.Data.SqlClient.SqlParameter paramPrecioVenta = null;
            System.Data.SqlClient.SqlParameter paramIva = null;


            Entidades.ResultadoTransaccion resultado = new Entidades.ResultadoTransaccion();
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "PresentacionArticuloPorAlmacenInsert";

                paramIdPresentacionArticuloPorAlmacen = new System.Data.SqlClient.SqlParameter("@IdPresentacionArticulo", System.Data.SqlDbType.Int);
                paramIdPresentacionArticuloPorAlmacen.Value = presentacionArticuloPorAlmacen.IdPresentacionArticuloPorAlmacen;
                cmd.Parameters.Add(paramIdPresentacionArticuloPorAlmacen);

                paramIdAlmacen = new System.Data.SqlClient.SqlParameter("@IdAlmacen", System.Data.SqlDbType.Int);
                paramIdAlmacen.Value = presentacionArticuloPorAlmacenDestino.IdAlmacen;
                cmd.Parameters.Add(paramIdAlmacen);

                paramExistencia = new System.Data.SqlClient.SqlParameter("@Existencia", System.Data.SqlDbType.Int);
                paramExistencia.Value = presentacionArticuloPorAlmacenDestino.Existencia;
                cmd.Parameters.Add(paramExistencia);

                paramMaxExistencias = new System.Data.SqlClient.SqlParameter("@MaxExistencias", System.Data.SqlDbType.Int);
                paramMaxExistencias.Value = presentacionArticuloPorAlmacenDestino.MaxExistencias;
                cmd.Parameters.Add(paramMaxExistencias);

                paramMinExistencias = new System.Data.SqlClient.SqlParameter("@MinExistencias", System.Data.SqlDbType.Int);
                paramMinExistencias.Value = presentacionArticuloPorAlmacenDestino.MinExistencias;
                cmd.Parameters.Add(paramMinExistencias);

                paramCostoUnitario = new System.Data.SqlClient.SqlParameter("@CostoUnitario", System.Data.SqlDbType.Decimal);
                paramCostoUnitario.Value = presentacionArticuloPorAlmacenDestino.CostoUnitario;
                cmd.Parameters.Add(paramCostoUnitario);

                paramPrecioVenta = new System.Data.SqlClient.SqlParameter("@PrecioVenta", System.Data.SqlDbType.Decimal);
                paramPrecioVenta.Value = presentacionArticuloPorAlmacenDestino.PrecioVenta;
                cmd.Parameters.Add(paramPrecioVenta);

                paramIva = new System.Data.SqlClient.SqlParameter("@Iva", System.Data.SqlDbType.Decimal);
                paramIva.Value = 0.16;
                cmd.Parameters.Add(paramIva);

                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();
                int i = cmd.ExecuteNonQuery();

                if (i == 1)
                {

                    cmd.CommandText = "PresentacionArticuloPorAlmacenUpdate";
                    cmd.Parameters.Clear();

                    paramIdPresentacionArticuloPorAlmacen = new System.Data.SqlClient.SqlParameter("@IdPresentacionArticulo", System.Data.SqlDbType.Int);
                    paramIdPresentacionArticuloPorAlmacen.Value = presentacionArticuloPorAlmacen.IdPresentacionArticuloPorAlmacen;
                    cmd.Parameters.Add(paramIdPresentacionArticuloPorAlmacen);

                    paramIdAlmacen = new System.Data.SqlClient.SqlParameter("@IdAlmacen", System.Data.SqlDbType.Int);
                    paramIdAlmacen.Value = presentacionArticuloPorAlmacen.IdAlmacen;
                    cmd.Parameters.Add(paramIdAlmacen);

                    paramExistencia = new System.Data.SqlClient.SqlParameter("@Existencia", System.Data.SqlDbType.Int);
                    paramExistencia.Value = presentacionArticuloPorAlmacen.Existencia;
                    cmd.Parameters.Add(paramExistencia);

                    i = cmd.ExecuteNonQuery();
                }

                // resultado.RegistrosAfectados = i;
                resultado.Mensaje = Mensajes.LinqToXml.LeerMensaje("0009");
            }
            catch (System.Data.SqlClient.SqlException)
            {
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
            }
            catch (Entidades.Excepciones.ExceptionErrorTransaccion)
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
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

            return resultado;
        }
    }
}
