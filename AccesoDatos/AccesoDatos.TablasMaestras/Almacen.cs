//-----------------------------------------------------------------------
// <copyright file="Almacen.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace AccesoDatos.TablasMaestras
{
    using System.Collections.Generic;

    public class Almacen : Contratos.IAlmacen
    {
        public Entidades.ResultadoTransaccion Insertar(Entidades.Almacen almacen)
        {
            if (almacen == null)
            {
                Entidades.Mensaje mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(mensaje.Texto));
                throw new Entidades.Excepciones.ExceptionErrorTransaccion(mensaje.Texto);
            }

            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlParameter paramNombreCompleto = null;
            System.Data.SqlClient.SqlParameter paramDescripcion = null;
            System.Data.SqlClient.SqlParameter paramDireccion = null;
            System.Data.SqlClient.SqlParameter paramCiudad = null;
            System.Data.SqlClient.SqlParameter paramTelefono1 = null;
            System.Data.SqlClient.SqlParameter paramTelefono2 = null;
            System.Data.SqlClient.SqlParameter paramFax = null;
            System.Data.SqlClient.SqlParameter paramEmail = null;
            System.Data.SqlClient.SqlParameter paramNit = null;
            System.Data.SqlClient.SqlParameter paramSitioWeb = null;

            Entidades.ResultadoTransaccion resultado = new Entidades.ResultadoTransaccion();
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "AlmacenInsert";

                paramNombreCompleto = new System.Data.SqlClient.SqlParameter("@NombreCompleto", System.Data.SqlDbType.NVarChar, 60);
                paramNombreCompleto.Value = almacen.NombreCompleto;
                cmd.Parameters.Add(paramNombreCompleto);

                paramDescripcion = new System.Data.SqlClient.SqlParameter("@Descripcion", System.Data.SqlDbType.NVarChar, 250);
                paramDescripcion.Value = almacen.Descripcion;
                cmd.Parameters.Add(paramDescripcion);

                paramDireccion = new System.Data.SqlClient.SqlParameter("@Direccion", System.Data.SqlDbType.NVarChar, 250);
                paramDireccion.Value = almacen.Direccion;
                cmd.Parameters.Add(paramDireccion);

                paramCiudad = new System.Data.SqlClient.SqlParameter("@IdCiudad", System.Data.SqlDbType.Int);
                paramCiudad.Value = almacen.Ciudad.IdCiudad;
                cmd.Parameters.Add(paramCiudad);

                paramTelefono1 = new System.Data.SqlClient.SqlParameter("@Telefono1", System.Data.SqlDbType.NVarChar, 50);
                paramTelefono1.Value = almacen.Telefono1;
                cmd.Parameters.Add(paramTelefono1);

                paramTelefono2 = new System.Data.SqlClient.SqlParameter("@Telefono2", System.Data.SqlDbType.NVarChar, 50);
                paramTelefono2.Value = almacen.Telefono2;
                cmd.Parameters.Add(paramTelefono2);

                paramFax = new System.Data.SqlClient.SqlParameter("@Fax", System.Data.SqlDbType.NVarChar, 25);
                paramFax.Value = almacen.Fax;
                cmd.Parameters.Add(paramFax);

                paramEmail = new System.Data.SqlClient.SqlParameter("@Email", System.Data.SqlDbType.NVarChar, 50);
                paramEmail.Value = almacen.Email;
                cmd.Parameters.Add(paramEmail);

                paramNit = new System.Data.SqlClient.SqlParameter("@Nit", System.Data.SqlDbType.Int);
                paramNit.Value = almacen.Nit;
                cmd.Parameters.Add(paramNit);

                paramSitioWeb = new System.Data.SqlClient.SqlParameter("@SitioWeb", System.Data.SqlDbType.NVarChar, 50);
                paramSitioWeb.Value = almacen.SitioWeb;
                cmd.Parameters.Add(paramSitioWeb);

                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();
                int i = cmd.ExecuteNonQuery();
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
                if (cmd != null)
                {
                    cmd.Dispose();
                }
            }

            return resultado;
        }

        public Entidades.ResultadoTransaccion Actualizar(Entidades.Almacen almacen)
        {
            if (almacen == null)
            {
                Entidades.Mensaje mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(mensaje.Texto));
                throw new Entidades.Excepciones.ExceptionErrorTransaccion(mensaje.Texto);
            }

            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlParameter paramIdAlmacen = null;
            System.Data.SqlClient.SqlParameter paramNombreCompleto = null;
            System.Data.SqlClient.SqlParameter paramDescripcion = null;
            System.Data.SqlClient.SqlParameter paramDireccion = null;
            System.Data.SqlClient.SqlParameter paramCiudad = null;
            System.Data.SqlClient.SqlParameter paramTelefono1 = null;
            System.Data.SqlClient.SqlParameter paramTelefono2 = null;
            System.Data.SqlClient.SqlParameter paramFax = null;
            System.Data.SqlClient.SqlParameter paramEmail = null;
            System.Data.SqlClient.SqlParameter paramNit = null;
            System.Data.SqlClient.SqlParameter paramSitioWeb = null;
            Entidades.ResultadoTransaccion resultado = new Entidades.ResultadoTransaccion();
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "AlmacenUpdate";

                paramIdAlmacen = new System.Data.SqlClient.SqlParameter("@IdAlmacen", System.Data.SqlDbType.Int);
                paramIdAlmacen.Value = almacen.IdAlmacen;
                cmd.Parameters.Add(paramIdAlmacen);

                paramNombreCompleto = new System.Data.SqlClient.SqlParameter("@NombreCompleto", System.Data.SqlDbType.NVarChar, 60);
                paramNombreCompleto.Value = almacen.NombreCompleto;
                cmd.Parameters.Add(paramNombreCompleto);

                paramDescripcion = new System.Data.SqlClient.SqlParameter("@Descripcion", System.Data.SqlDbType.NVarChar, 250);
                paramDescripcion.Value = almacen.Descripcion;
                cmd.Parameters.Add(paramDescripcion);

                paramDireccion = new System.Data.SqlClient.SqlParameter("@Direccion", System.Data.SqlDbType.NVarChar, 250);
                paramDireccion.Value = almacen.Direccion;
                cmd.Parameters.Add(paramDireccion);

                paramCiudad = new System.Data.SqlClient.SqlParameter("@IdCiudad", System.Data.SqlDbType.Int);
                paramCiudad.Value = almacen.Ciudad.IdCiudad;
                cmd.Parameters.Add(paramCiudad);

                paramTelefono1 = new System.Data.SqlClient.SqlParameter("@Telefono1", System.Data.SqlDbType.NVarChar, 50);
                paramTelefono1.Value = almacen.Telefono1;
                cmd.Parameters.Add(paramTelefono1);

                paramTelefono2 = new System.Data.SqlClient.SqlParameter("@Telefono2", System.Data.SqlDbType.NVarChar, 50);
                paramTelefono2.Value = almacen.Telefono2;
                cmd.Parameters.Add(paramTelefono2);

                paramFax = new System.Data.SqlClient.SqlParameter("@Fax", System.Data.SqlDbType.NVarChar, 25);
                paramFax.Value = almacen.Fax;
                cmd.Parameters.Add(paramFax);

                paramEmail = new System.Data.SqlClient.SqlParameter("@Email", System.Data.SqlDbType.NVarChar, 50);
                paramEmail.Value = almacen.Email;
                cmd.Parameters.Add(paramEmail);

                paramNit = new System.Data.SqlClient.SqlParameter("@Nit", System.Data.SqlDbType.Int);
                paramNit.Value = almacen.Nit;
                cmd.Parameters.Add(paramNit);

                paramSitioWeb = new System.Data.SqlClient.SqlParameter("@SitioWeb", System.Data.SqlDbType.NVarChar, 50);
                paramSitioWeb.Value = almacen.SitioWeb;
                cmd.Parameters.Add(paramSitioWeb);

                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();
                int i = cmd.ExecuteNonQuery();
                resultado.RegistrosAfectados = i;
                resultado.Mensaje = Mensajes.LinqToXml.LeerMensaje("0007");
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
                if (cmd != null)
                {
                    cmd.Dispose();
                }
            }

            return resultado;
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Almacen> Listar()
        {
            List<Entidades.Almacen> ListAlmacenes = new List<Entidades.Almacen>();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataReader datareader = null;
            System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Almacen> listaReadOnlyAlmacen = null;

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "AlmacenSelect";
                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();
                datareader = cmd.ExecuteReader();

                while (datareader.Read())
                {
                    Entidades.Almacen EntidadAlmacen = new Entidades.Almacen();

                    EntidadAlmacen.IdAlmacen = datareader.GetInt32(0);
                    EntidadAlmacen.NombreCompleto = datareader.GetString(1);
                    EntidadAlmacen.Descripcion = datareader.GetString(2);
                    EntidadAlmacen.Direccion = datareader.GetString(3);
                    EntidadAlmacen.Ciudad.IdCiudad = datareader.GetInt32(4);
                    EntidadAlmacen.Telefono1 = datareader.GetString(5);
                    EntidadAlmacen.Telefono2 = datareader.GetString(6);
                    EntidadAlmacen.Fax = datareader.GetString(7);
                    EntidadAlmacen.Email = datareader.GetString(8);
                    EntidadAlmacen.Nit = datareader.GetInt32(9);
                    EntidadAlmacen.SitioWeb = datareader.GetString(10);

                    ListAlmacenes.Add(EntidadAlmacen);
                }

                listaReadOnlyAlmacen = new System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Almacen>(ListAlmacenes);
                // Logging.Accion.Guardar("Lectura de la tabla Almacen");
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Logging.ErrorGeneral.Guardar(ex);
            }
            finally
            {
                if (datareader != null)
                {
                    datareader.Dispose();
                }

                cmd.Dispose();
            }

            return listaReadOnlyAlmacen;
        }

        public Entidades.ResultadoTransaccion Eliminar(int idAlmacen)
        {
            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlParameter paramIdAlmacen = null;
            Entidades.ResultadoTransaccion resultado = new Entidades.ResultadoTransaccion();
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "AlmacenDelete";

                paramIdAlmacen = new System.Data.SqlClient.SqlParameter("@IdAlmacen", System.Data.SqlDbType.Int);
                paramIdAlmacen.Value = idAlmacen;
                cmd.Parameters.Add(paramIdAlmacen);

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
                if (cmd != null)
                {
                    cmd.Dispose();
                }
            }

            return resultado;
        }
    }
}
