//-----------------------------------------------------------------------
// <copyright file="Login.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace AccesoDatos.WebPublica
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using EntidadesWeb;

    public class Login : ContratosWeb.ILogin
    {
        /// <summary>
        /// Ingreso de un cliente al sistema.
        /// </summary>
        /// <param name="login">Objeto con los datos que se desean insertar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        public EntidadesWeb.ResultadoTransaccion Ingresar(EntidadesWeb.Login login)
        {
            if (login == null)
            {
                EntidadesWeb.Mensaje mensaje = MensajesWeb.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new EntidadesWeb.Excepciones.ExceptionErrorTransaccion(mensaje.Texto));
                throw new EntidadesWeb.Excepciones.ExceptionErrorTransaccion(mensaje.Texto);
            }

            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlParameter paramUsuario = null;
            System.Data.SqlClient.SqlParameter paramContrasena = null;
            EntidadesWeb.ResultadoTransaccion resultado = new EntidadesWeb.ResultadoTransaccion();
            EntidadesWeb.ResultadoTransaccion resultadoTransaccion = new EntidadesWeb.ResultadoTransaccion();

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "LoginSignIn";

                paramUsuario = new System.Data.SqlClient.SqlParameter("@Email", System.Data.SqlDbType.NVarChar, 50);
                paramUsuario.Value = login.Usuario;
                cmd.Parameters.Add(paramUsuario);

                paramContrasena = new System.Data.SqlClient.SqlParameter("@Contrasena", System.Data.SqlDbType.NVarChar, 50);
                paramContrasena.Value = login.Contrasena;
                cmd.Parameters.Add(paramContrasena);

                cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                cmd.Connection.Open();
                System.Data.SqlClient.SqlDataReader Reader = cmd.ExecuteReader();

                if (Reader.Read())
                {
                    resultado.ValorAuxiliar = 1;
                }
                else
                {
                    resultado.ValorAuxiliar = 0;
                }

                resultado.Mensaje = MensajesWeb.LinqToXml.LeerMensaje("0009");
            }
            catch (System.Data.SqlClient.SqlException)
            {
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

                if (cmd != null)
                {
                    cmd.Dispose();
                }
            }

            return resultado;
        }

        /// <summary>
        /// Inserta una presentación de artículo en el carrito, sin hacer suma cuando el item ya existe para ese usuario
        /// </summary>
        /// <param name="carrito">Item de carrito a insertar. Tiene que contener el Id del usuario</param>
        /// <returns>Resultado transacción con la cantidad de registros afectados</returns>
        public ResultadoTransaccion InsertarItemCarrito(System.Collections.Generic.List<EntidadesWeb.ItemCarrito> carrito)
        {
            EntidadesWeb.ResultadoTransaccion resultadoTransaccion = null;

            System.Data.SqlClient.SqlCommand cmdInsertItemCarrito = null;
            System.Data.SqlClient.SqlCommand cmdSelectItemCarrito = null;
            System.Data.SqlClient.SqlDataReader datareader = null;

            // Paámetros para cmdInsertItemCarrito
            System.Data.SqlClient.SqlParameter paramIdUsuarioInsertItemCarrito = null;
            System.Data.SqlClient.SqlParameter paramIdPresentacionArticuloInsertItemCarrito = null;
            System.Data.SqlClient.SqlParameter paramCantidadInsertItemCarrito = null;

            // Parámtros para cmdSelectItemCarrito
            System.Data.SqlClient.SqlParameter paramIdUsuarioCarritoSelectItemCarrito = null;
            System.Data.SqlClient.SqlParameter paramIdPresentacionArticuloCarritoSelectItemCarrito = null;

            try
            {
                resultadoTransaccion = new EntidadesWeb.ResultadoTransaccion();
                cmdInsertItemCarrito = new System.Data.SqlClient.SqlCommand();
                cmdInsertItemCarrito.CommandType = System.Data.CommandType.StoredProcedure;
                cmdInsertItemCarrito.CommandText = "LoginInsertItemCarrito";

                cmdSelectItemCarrito = new System.Data.SqlClient.SqlCommand();
                cmdSelectItemCarrito.CommandType = System.Data.CommandType.StoredProcedure;
                cmdSelectItemCarrito.CommandText = "LoginSelectImtemCarritoPorIdUsuarioIdPresentacionArticulo";

                // Configurar parámetros de cmdInsertItemCarrito
                paramIdUsuarioInsertItemCarrito = new System.Data.SqlClient.SqlParameter("@IdUsuario", System.Data.SqlDbType.Int);
                paramIdPresentacionArticuloInsertItemCarrito = new System.Data.SqlClient.SqlParameter("@IdPresentacionArticulo", System.Data.SqlDbType.Int);
                paramCantidadInsertItemCarrito = new System.Data.SqlClient.SqlParameter("@Cantidad", System.Data.SqlDbType.Int);
                cmdInsertItemCarrito.Parameters.Add(paramIdUsuarioInsertItemCarrito);
                cmdInsertItemCarrito.Parameters.Add(paramIdPresentacionArticuloInsertItemCarrito);
                cmdInsertItemCarrito.Parameters.Add(paramCantidadInsertItemCarrito);

                // Configurar parámetros de cmdSelectItemCarrito
                paramIdUsuarioCarritoSelectItemCarrito = new System.Data.SqlClient.SqlParameter("@IdUsuario", System.Data.SqlDbType.Int);
                paramIdPresentacionArticuloCarritoSelectItemCarrito = new System.Data.SqlClient.SqlParameter("@IdPresentacionArticulo", System.Data.SqlDbType.Int);
                cmdSelectItemCarrito.Parameters.Add(paramIdUsuarioCarritoSelectItemCarrito);
                cmdSelectItemCarrito.Parameters.Add(paramIdPresentacionArticuloCarritoSelectItemCarrito);

                cmdInsertItemCarrito.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                cmdSelectItemCarrito.Connection = cmdInsertItemCarrito.Connection;
                cmdInsertItemCarrito.Connection.Open();


                foreach (EntidadesWeb.ItemCarrito itemCarrito in carrito)
                {
                    // Buscar el item usando IdUsuario y el IdPresentacionArtículo
                    paramIdUsuarioCarritoSelectItemCarrito.Value = itemCarrito.IdUsuario;
                    paramIdPresentacionArticuloCarritoSelectItemCarrito.Value = itemCarrito.IdPrestacionArticulo;
                    datareader = cmdSelectItemCarrito.ExecuteReader();

                    // Si el item no existe en el carrito para el usuario, se añade al carrito.
                    if (datareader.Read() == false)
                    {
                        paramIdUsuarioInsertItemCarrito.Value = itemCarrito.IdUsuario;
                        paramIdPresentacionArticuloInsertItemCarrito.Value = itemCarrito.IdPrestacionArticulo;
                        paramCantidadInsertItemCarrito.Value = itemCarrito.Cantidad;

                        datareader.Close();
                        cmdInsertItemCarrito.ExecuteNonQuery();
                    }
                }

            }
            catch (System.Data.SqlClient.SqlException sqlEx)
            {
                Logging.ErrorGeneral.Guardar(sqlEx);
            }
            catch (EntidadesWeb.Excepciones.ExceptionErrorTransaccion)
            {
                resultadoTransaccion.Mensaje = MensajesWeb.LinqToXml.LeerMensaje(string.Empty);
                Logging.ErrorGeneral.Guardar(new EntidadesWeb.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                return resultadoTransaccion;
            }
            catch (Exception ex)
             {
                Logging.ErrorGeneral.Guardar(ex);
                return resultadoTransaccion;
            }
            finally
            {
                if (cmdInsertItemCarrito.Connection.State == System.Data.ConnectionState.Open)
                {
                    cmdInsertItemCarrito.Connection.Close();
                }

                if (cmdInsertItemCarrito != null)
                {
                    cmdInsertItemCarrito.Dispose();
                }

                if (datareader != null)
                {
                    datareader.Dispose();
                }
            }

            return resultadoTransaccion;
        }

        public ReadOnlyCollection<ItemCarrito> ListarItemCarritoPorIdUsuario(int IdUsuario)
        {
            List<EntidadesWeb.ItemCarrito> listaCarrito = new List<EntidadesWeb.ItemCarrito>();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlParameter paramIdUsuario = null;
            System.Data.SqlClient.SqlDataReader datareader = null;
            System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.ItemCarrito> listaReadOnlyCarrito = null;

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "LoginSelectImtemCarritoPorIdUsuarioIdPresentacionArticulo";

                paramIdUsuario = new System.Data.SqlClient.SqlParameter("@IdUsuario", System.Data.SqlDbType.Int);
                paramIdUsuario.Value = IdUsuario;
                cmd.Parameters.Add(paramIdUsuario);

                cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                cmd.Connection.Open();
                datareader = cmd.ExecuteReader();

                while (datareader.Read())
                {
                    EntidadesWeb.ItemCarrito carrito = new EntidadesWeb.ItemCarrito();

                    carrito.IdItemCarrito = datareader.GetInt32(0);
                    carrito.IdUsuario = datareader.GetInt32(1);
                    carrito.IdPrestacionArticulo = datareader.GetInt32(2);
                    carrito.Cantidad = datareader.GetInt32(3);
                    carrito.Nombre = datareader.GetString(4);
                    carrito.Precio = datareader.GetDouble(5);
                    listaCarrito.Add(carrito);
                }
                listaReadOnlyCarrito = new System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.ItemCarrito>(listaCarrito);
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

                if (datareader != null)
                {
                    datareader.Dispose();
                }

                if (cmd != null)
                {
                    cmd.Dispose();
                }
            }
            return listaReadOnlyCarrito;
        }
    }
}
