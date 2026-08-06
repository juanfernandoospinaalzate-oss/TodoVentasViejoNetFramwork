//-----------------------------------------------------------------------
// <copyright file="Venta.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace AccesoDatos.WebPublica
{
    using System.Collections.Generic;

    public class Venta : ContratosWeb.IVenta
    {
        public EntidadesWeb.Venta ConsultarParaVenta(int IdUsuario, System.Data.SqlClient.SqlConnection conexion, System.Data.SqlClient.SqlTransaction transaccion)
        {
            System.Data.SqlClient.SqlParameter paramIdUsuario = null;
            System.Data.SqlClient.SqlDataReader datareader = null;
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            EntidadesWeb.ResultadoTransaccion resultadoTransaccion = new EntidadesWeb.ResultadoTransaccion();
            EntidadesWeb.Venta Venta = new EntidadesWeb.Venta();

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "VentaConsultarParaVentaSelect";
                paramIdUsuario = new System.Data.SqlClient.SqlParameter("@IdUsuario", System.Data.SqlDbType.Int);
                paramIdUsuario.Value = IdUsuario;
                cmd.Parameters.Add(paramIdUsuario);

                
                cmd.Connection = conexion;
                conexion.Open();
                cmd.Transaction = transaccion;
                datareader = cmd.ExecuteReader();

                while (datareader.Read())
                {
                    Venta.IdVenta = datareader.GetInt32(0);                    
                    Venta.NroFactura = datareader.GetInt32(1);
                    Venta.IdCliente = datareader.GetInt32(2);
                    Venta.DocCliente = datareader.GetInt32(3);
                    Venta.NombreCliente = datareader.GetString(4);
                    Venta.ApellidoCliente = datareader.GetString(5);
                    Venta.TelefonoClienteUno = datareader.GetString(6);
                    Venta.TelefonoClienteDos = datareader.GetString(7);
                    Venta.EmailCliente = datareader.GetString(8);
                    Venta.ContrasenaCliente = datareader.GetString(9);
                    Venta.NombreDestinatario = datareader.GetString(10);
                    Venta.DireccionEnvioDestinatario = datareader.GetString(11);
                    Venta.TelefonoDestinatario = datareader.GetString(12);
                    Venta.NombrePaisDestinatario = datareader.GetString(13);
                    Venta.NombreDepartamentoDestinatario = datareader.GetString(14);
                    Venta.NombreCiudadDestinatario = datareader.GetString(15);
                    Venta.Fecha = datareader.GetDateTime(16);
                    Venta.CodigoReferenciaPayU = datareader.GetInt32(17);
                    Venta.MedioDEPago = datareader.GetString(18);
                    Venta.TotalVenta = double.Parse(datareader.GetString(19));
                    Venta.TotalCosto = double.Parse(datareader.GetString(20));
                    Venta.NroGuia = datareader.GetString(21);
                    Venta.CostoFlete = datareader.GetInt32(22);
                    Venta.Anulado = bool.Parse(datareader.GetString(23));              
                }                

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

            return Venta;
        }

        public EntidadesWeb.ResultadoTransaccion Insertar(EntidadesWeb.Venta venta, System.Data.SqlClient.SqlConnection conexion, System.Data.SqlClient.SqlTransaction transaccion)
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();            
            EntidadesWeb.ResultadoTransaccion resultadoTransaccion = new EntidadesWeb.ResultadoTransaccion();

            System.Data.SqlClient.SqlParameter paramNroFactura = null;
            System.Data.SqlClient.SqlParameter paramIdCliente = null;
            System.Data.SqlClient.SqlParameter paramDocCliente = null;
            System.Data.SqlClient.SqlParameter paramNombreCliente = null;
            System.Data.SqlClient.SqlParameter paramApellidoCliente = null;
            System.Data.SqlClient.SqlParameter paramTelefonoClienteUno = null;
            System.Data.SqlClient.SqlParameter paramTelefonoClienteDos = null;
            System.Data.SqlClient.SqlParameter paramEmailCliente = null;
            System.Data.SqlClient.SqlParameter paramContrasenaCliente = null;
            System.Data.SqlClient.SqlParameter paramNombreDestinatario = null;
            System.Data.SqlClient.SqlParameter paramDireccionEnvioDestinatario = null;
            System.Data.SqlClient.SqlParameter paramTelefonoDestinatario = null;
            System.Data.SqlClient.SqlParameter paramNombrePaisDestinatario = null;
            System.Data.SqlClient.SqlParameter paramNombreDepartamentoDestinatario = null;
            System.Data.SqlClient.SqlParameter paramNombreCiudadDestinatario = null;
            System.Data.SqlClient.SqlParameter paramFecha = null;
            System.Data.SqlClient.SqlParameter paramCodigoReferenciaPayU = null;
            System.Data.SqlClient.SqlParameter paramMedioDePago = null;
            System.Data.SqlClient.SqlParameter paramTotalVenta = null;
            System.Data.SqlClient.SqlParameter paramTotalCosto = null;
            System.Data.SqlClient.SqlParameter paramNroGuia = null;
            System.Data.SqlClient.SqlParameter paramCostoFlete = null;
            System.Data.SqlClient.SqlParameter paramAnulado = null;

            System.Data.SqlClient.SqlParameter paramOutIdVenta = null;
                         
            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "VentaInsert";

                paramNroFactura = new System.Data.SqlClient.SqlParameter("@NroFactura", System.Data.SqlDbType.Int);
                paramNroFactura.Value = venta.NroFactura;
                cmd.Parameters.Add(paramNroFactura);

                paramIdCliente = new System.Data.SqlClient.SqlParameter("@IdCliente", System.Data.SqlDbType.Int);
                paramIdCliente.Value = venta.IdCliente;
                cmd.Parameters.Add(paramIdCliente);

                paramDocCliente = new System.Data.SqlClient.SqlParameter("@DocCliente", System.Data.SqlDbType.Int);
                paramDocCliente.Value = venta.DocCliente;
                cmd.Parameters.Add(paramDocCliente);

                paramNombreCliente = new System.Data.SqlClient.SqlParameter("@NombreCliente", System.Data.SqlDbType.NVarChar, 30);
                paramNombreCliente.Value = venta.NombreCliente;
                cmd.Parameters.Add(paramNombreCliente);

                paramApellidoCliente = new System.Data.SqlClient.SqlParameter("@ApellidoCliente", System.Data.SqlDbType.NVarChar, 30);
                paramApellidoCliente.Value = venta.ApellidoCliente;
                cmd.Parameters.Add(paramApellidoCliente);

                paramTelefonoClienteUno = new System.Data.SqlClient.SqlParameter("@TelefonoClienteUno", System.Data.SqlDbType.NVarChar, 20);
                paramTelefonoClienteUno.Value = venta.TelefonoClienteUno;
                cmd.Parameters.Add(paramTelefonoClienteUno);

                paramTelefonoClienteDos = new System.Data.SqlClient.SqlParameter("@TelefonoClienteDos", System.Data.SqlDbType.NVarChar, 20);
                paramTelefonoClienteDos.Value = venta.TelefonoClienteDos;
                cmd.Parameters.Add(paramTelefonoClienteDos);

                paramEmailCliente = new System.Data.SqlClient.SqlParameter("@EmailCliente", System.Data.SqlDbType.NVarChar, 50);
                paramEmailCliente.Value = venta.EmailCliente;
                cmd.Parameters.Add(paramEmailCliente);

                paramContrasenaCliente = new System.Data.SqlClient.SqlParameter("@ContrasenaCliente", System.Data.SqlDbType.NVarChar, 50);
                paramContrasenaCliente.Value = venta.ContrasenaCliente;
                cmd.Parameters.Add(paramContrasenaCliente);

                paramNombreDestinatario = new System.Data.SqlClient.SqlParameter("@NombreDestinatario", System.Data.SqlDbType.NVarChar, 30);
                paramNombreDestinatario.Value = venta.NombreDestinatario;
                cmd.Parameters.Add(paramNombreDestinatario);

                paramDireccionEnvioDestinatario = new System.Data.SqlClient.SqlParameter("@DireccionEnvioDestinatario", System.Data.SqlDbType.NVarChar, 80);
                paramDireccionEnvioDestinatario.Value = venta.DireccionEnvioDestinatario;
                cmd.Parameters.Add(paramDireccionEnvioDestinatario);

                paramTelefonoDestinatario = new System.Data.SqlClient.SqlParameter("@TelefonoDestinatario", System.Data.SqlDbType.NVarChar, 20);
                paramTelefonoDestinatario.Value = venta.TelefonoDestinatario;
                cmd.Parameters.Add(paramTelefonoDestinatario);

                paramNombrePaisDestinatario = new System.Data.SqlClient.SqlParameter("@NombrePaisDestinatario", System.Data.SqlDbType.NVarChar, 42);
                paramNombrePaisDestinatario.Value = venta.NombrePaisDestinatario;
                cmd.Parameters.Add(paramNombrePaisDestinatario);

                paramNombreDepartamentoDestinatario = new System.Data.SqlClient.SqlParameter("@NombreDepartamentoDestinatario", System.Data.SqlDbType.NVarChar, 42);
                paramNombreDepartamentoDestinatario.Value = venta.NombreDepartamentoDestinatario;
                cmd.Parameters.Add(paramNombreDepartamentoDestinatario);

                paramNombreCiudadDestinatario = new System.Data.SqlClient.SqlParameter("@NombreCiudadDestinatario", System.Data.SqlDbType.NVarChar, 42);
                paramNombreCiudadDestinatario.Value = venta.NombreCiudadDestinatario;
                cmd.Parameters.Add(paramNombreCiudadDestinatario);

                paramFecha = new System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.Date);
                paramFecha.Value = venta.Fecha;
                cmd.Parameters.Add(paramFecha);

                paramCodigoReferenciaPayU = new System.Data.SqlClient.SqlParameter("@CodigoReferenciaPayU", System.Data.SqlDbType.Int);
                paramCodigoReferenciaPayU.Value = venta.CodigoReferenciaPayU;
                cmd.Parameters.Add(paramCodigoReferenciaPayU);

                paramMedioDePago = new System.Data.SqlClient.SqlParameter("@MedioDePago", System.Data.SqlDbType.NVarChar, 60);
                paramMedioDePago.Value = venta.MedioDEPago;
                cmd.Parameters.Add(paramMedioDePago);

                paramTotalVenta = new System.Data.SqlClient.SqlParameter("@TotalVenta", System.Data.SqlDbType.Float);
                paramTotalVenta.Value = venta.TotalVenta;
                cmd.Parameters.Add(paramTotalVenta);

                paramTotalCosto = new System.Data.SqlClient.SqlParameter("@TotalCosto", System.Data.SqlDbType.Float);
                paramTotalCosto.Value = venta.TotalCosto;
                cmd.Parameters.Add(paramTotalCosto);

                paramNroGuia = new System.Data.SqlClient.SqlParameter("@NroGuia", System.Data.SqlDbType.NVarChar, 20);
                paramNroGuia.Value = venta.NroGuia;
                cmd.Parameters.Add(paramNroGuia);

                paramCostoFlete = new System.Data.SqlClient.SqlParameter("@CostoFlete", System.Data.SqlDbType.NVarChar, 20);
                paramCostoFlete.Value = venta.CostoFlete;
                cmd.Parameters.Add(paramCostoFlete);

                paramAnulado = new System.Data.SqlClient.SqlParameter("@Anulado", System.Data.SqlDbType.Bit);
                paramAnulado.Value = venta.Anulado;
                cmd.Parameters.Add(paramAnulado);

                paramOutIdVenta = new System.Data.SqlClient.SqlParameter("@OutIdVenta", System.Data.SqlDbType.Int);
                paramOutIdVenta.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(paramOutIdVenta);

                cmd.Connection = conexion;
                cmd.Transaction = transaccion;

                int i = cmd.ExecuteNonQuery();
                resultadoTransaccion.RegistrosAfectados = i;
                resultadoTransaccion.ValorAuxiliar = paramOutIdVenta.Value;
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

                if (cmd != null)
                {
                    cmd.Dispose();
                }
            }

            return resultadoTransaccion;
        }

        public EntidadesWeb.ResultadoTransaccion InsertarDetalleVenta(EntidadesWeb.DetalleVenta detalleVenta, System.Data.SqlClient.SqlConnection conexion, System.Data.SqlClient.SqlTransaction transaccion)
        {
            System.Data.SqlClient.SqlParameter paramIdVenta = null;
            System.Data.SqlClient.SqlParameter paramIdCliente = null;
            System.Data.SqlClient.SqlParameter paramNombreMarca = null;
            System.Data.SqlClient.SqlParameter paramTitulo = null;
            // System.Data.SqlClient.SqlParameter paramCodigoEAN = null;
            System.Data.SqlClient.SqlParameter paramNombreUnidadVolumen = null;
            System.Data.SqlClient.SqlParameter paramVlrVolumenLargo = null;
            System.Data.SqlClient.SqlParameter paramVlrVolumenAncho = null;
            System.Data.SqlClient.SqlParameter paramVlrVolumenProfundidad = null;
            System.Data.SqlClient.SqlParameter paramVlrContenidoVolumetrico = null;
            System.Data.SqlClient.SqlParameter paramNombreUnidadMasa = null;
            System.Data.SqlClient.SqlParameter paramVlrUnidadMasa = null;
            System.Data.SqlClient.SqlParameter paramNombreUnidadLongitud = null;
            System.Data.SqlClient.SqlParameter paramVlrUnidadLongitud = null;
            System.Data.SqlClient.SqlParameter paramNombreTalla = null;
            System.Data.SqlClient.SqlParameter paramNombreColor = null;
            System.Data.SqlClient.SqlParameter paramNombreSabor = null;
            System.Data.SqlClient.SqlParameter paramPrecioVenta = null;
            System.Data.SqlClient.SqlParameter paramCantidad = null;
            System.Data.SqlClient.SqlParameter paramCostoDelProducto = null;
            System.Data.SqlClient.SqlParameter paramSubTotalVenta = null;

            System.Data.SqlClient.SqlParameter paramSubtotalCosto = null;
            System.Data.SqlClient.SqlParameter paramNombreCategoria = null;
            System.Data.SqlClient.SqlParameter paramCaminoSubCategorias = null;
            System.Data.SqlClient.SqlParameter paramIdPresentacionArticulo = null;

            EntidadesWeb.ResultadoTransaccion resultado = new EntidadesWeb.ResultadoTransaccion();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();  
            EntidadesWeb.ResultadoTransaccion resultadoTransaccion = new EntidadesWeb.ResultadoTransaccion();

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "DetalleVentaInsert";

                paramIdVenta = new System.Data.SqlClient.SqlParameter("@IdVenta", System.Data.SqlDbType.Int);
                paramIdVenta.Value = detalleVenta.IdVenta;
                cmd.Parameters.Add(paramIdVenta);

                paramIdCliente = new System.Data.SqlClient.SqlParameter("@IdCliente", System.Data.SqlDbType.Int);
                paramIdCliente.Value = detalleVenta.IdCliente;
                cmd.Parameters.Add(paramIdCliente);

                paramNombreMarca = new System.Data.SqlClient.SqlParameter("@NombreMarca", System.Data.SqlDbType.NVarChar, 20);
                paramNombreMarca.Value = detalleVenta.NombreMarca;
                cmd.Parameters.Add(paramNombreMarca);

                paramTitulo = new System.Data.SqlClient.SqlParameter("@Titulo", System.Data.SqlDbType.NVarChar, 50);
                paramTitulo.Value = detalleVenta.Titulo;
                cmd.Parameters.Add(paramTitulo);

                paramNombreUnidadVolumen = new System.Data.SqlClient.SqlParameter("@NombreUnidadVolumen", System.Data.SqlDbType.NVarChar, 18);
                paramNombreUnidadVolumen.Value = detalleVenta.NombreUnidadVolumen;
                cmd.Parameters.Add(paramNombreUnidadVolumen);

                paramVlrVolumenLargo = new System.Data.SqlClient.SqlParameter("@VlrVolumenLargo", System.Data.SqlDbType.Int);
                paramVlrVolumenLargo.Value = detalleVenta.VlrVolumenLargo;
                cmd.Parameters.Add(paramVlrVolumenLargo);

                paramVlrVolumenAncho = new System.Data.SqlClient.SqlParameter("@VlrVolumenAncho", System.Data.SqlDbType.Int);
                paramVlrVolumenAncho.Value = detalleVenta.VlrVolumenAncho;
                cmd.Parameters.Add(paramVlrVolumenAncho);

                paramVlrVolumenProfundidad = new System.Data.SqlClient.SqlParameter("@VlrVolumenProfundidad", System.Data.SqlDbType.Int);
                paramVlrVolumenProfundidad.Value = detalleVenta.VlrVolumenProfundidad;
                cmd.Parameters.Add(paramVlrVolumenProfundidad);


                paramVlrContenidoVolumetrico = new System.Data.SqlClient.SqlParameter("@VlrContenidoVolumetrico", System.Data.SqlDbType.Int);
                paramVlrContenidoVolumetrico.Value = detalleVenta.VlrContenidoVolumetrico;
                cmd.Parameters.Add(paramVlrContenidoVolumetrico);

                paramNombreUnidadMasa = new System.Data.SqlClient.SqlParameter("@NombreUnidadMasa", System.Data.SqlDbType.NVarChar, 20);
                paramNombreUnidadMasa.Value = detalleVenta.NombreUnidadMasa;
                cmd.Parameters.Add(paramNombreUnidadMasa);


                paramVlrUnidadMasa = new System.Data.SqlClient.SqlParameter("@VlrUnidadMasa", System.Data.SqlDbType.Int);
                paramVlrUnidadMasa.Value = detalleVenta.VlrUnidadMasa;
                cmd.Parameters.Add(paramVlrUnidadMasa);


                paramNombreUnidadLongitud = new System.Data.SqlClient.SqlParameter("@NombreUnidadLongitud", System.Data.SqlDbType.NVarChar, 20);
                paramNombreUnidadLongitud.Value = detalleVenta.NombreUnidadLongitud;
                cmd.Parameters.Add(paramNombreUnidadLongitud);


                paramVlrUnidadLongitud = new System.Data.SqlClient.SqlParameter("@VlrUnidadLongitud", System.Data.SqlDbType.Int);
                paramVlrUnidadLongitud.Value = detalleVenta.VlrUnidadLongitud;
                cmd.Parameters.Add(paramVlrUnidadLongitud);


                paramNombreTalla = new System.Data.SqlClient.SqlParameter("@NombreTalla", System.Data.SqlDbType.NVarChar, 20);
                paramNombreTalla.Value = detalleVenta.NombreTalla;
                cmd.Parameters.Add(paramNombreTalla);


                paramNombreColor = new System.Data.SqlClient.SqlParameter("@NombreColor", System.Data.SqlDbType.NVarChar, 25);
                paramNombreColor.Value = detalleVenta.NombreColor;
                cmd.Parameters.Add(paramNombreColor);

                paramNombreSabor = new System.Data.SqlClient.SqlParameter("@NombreSabor", System.Data.SqlDbType.NVarChar, 20);
                paramNombreSabor.Value = detalleVenta.NombreSabor;
                cmd.Parameters.Add(paramNombreSabor);

                paramPrecioVenta = new System.Data.SqlClient.SqlParameter("@PrecioVenta", System.Data.SqlDbType.Float);
                paramPrecioVenta.Value = detalleVenta.PrecioVenta;
                cmd.Parameters.Add(paramPrecioVenta);

                paramCantidad = new System.Data.SqlClient.SqlParameter("@Cantidad", System.Data.SqlDbType.Int);
                paramCantidad.Value = detalleVenta.Cantidad;
                cmd.Parameters.Add(paramCantidad);

                paramCostoDelProducto = new System.Data.SqlClient.SqlParameter("@CostoDelProducto", System.Data.SqlDbType.Float);
                paramCostoDelProducto.Value = detalleVenta.CostoDelProducto;
                cmd.Parameters.Add(paramCostoDelProducto);

                paramSubTotalVenta = new System.Data.SqlClient.SqlParameter("@SubTotalVenta", System.Data.SqlDbType.Float);
                paramSubTotalVenta.Value = detalleVenta.SubtotalCosto;
                cmd.Parameters.Add(paramSubTotalVenta); 

                paramSubtotalCosto = new System.Data.SqlClient.SqlParameter("@SubtotalCosto", System.Data.SqlDbType.Float);
                paramSubtotalCosto.Value = detalleVenta.SubtotalCosto;
                cmd.Parameters.Add(paramSubtotalCosto);

                paramNombreCategoria = new System.Data.SqlClient.SqlParameter("@NombreCategoria", System.Data.SqlDbType.NVarChar, 60);
                paramNombreCategoria.Value = detalleVenta.NombreCategoria;
                cmd.Parameters.Add(paramNombreCategoria);

                paramCaminoSubCategorias = new System.Data.SqlClient.SqlParameter("@CaminoSubCategorias", System.Data.SqlDbType.NVarChar, 250);
                paramCaminoSubCategorias.Value = detalleVenta.CaminoSubCategorias;
                cmd.Parameters.Add(paramCaminoSubCategorias);

                paramIdPresentacionArticulo = new System.Data.SqlClient.SqlParameter("@IdPresentacionArticulo", System.Data.SqlDbType.Int);
                paramIdPresentacionArticulo.Value = detalleVenta.IdPresentacionArticulo;
                cmd.Parameters.Add(paramIdPresentacionArticulo);

                cmd.Connection = conexion;
                cmd.Transaction = transaccion;

                int i = cmd.ExecuteNonQuery();
                resultadoTransaccion.RegistrosAfectados = i;
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

                if (cmd != null)
                {
                    cmd.Dispose();
                }
            }

            return resultadoTransaccion;
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.DetalleVenta> ConsultarParaDetalleVenta(int IdUsuario, System.Data.SqlClient.SqlConnection conexion, System.Data.SqlClient.SqlTransaction transaccion)
        {
            List<EntidadesWeb.DetalleVenta> DetalleVentas = new List<EntidadesWeb.DetalleVenta>();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataReader datareader = null;
            System.Data.SqlClient.SqlParameter paramIdUsuario = null;
            System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.DetalleVenta> listaReadOnlyDetalleVenta = null;

            try
            {
                paramIdUsuario = new System.Data.SqlClient.SqlParameter("@IdUsuario", System.Data.SqlDbType.Int);
                paramIdUsuario.Value = IdUsuario;
                cmd.Parameters.Add(paramIdUsuario);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "DetalleVentaConsultarParaDetalleVentaSelect";
                cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                cmd.Connection.Open();
                datareader = cmd.ExecuteReader();

                while (datareader.Read())
                {
                    EntidadesWeb.DetalleVenta DetalleVenta = new EntidadesWeb.DetalleVenta();

                        DetalleVenta.IdDetalleVenta = datareader.GetInt32(0);
                        DetalleVenta.IdVenta = datareader.GetInt32(1);
                        DetalleVenta.IdCliente = datareader.GetInt32(2);
                        DetalleVenta.NombreMarca = datareader.GetString(3);
                        DetalleVenta.Titulo = datareader.GetString(4);
                        DetalleVenta.CodigoEan = datareader.GetString(5);
                        DetalleVenta.NombreUnidadVolumen = datareader.GetString(6);
                        DetalleVenta.VlrVolumenLargo = datareader.GetInt32(7);
                        DetalleVenta.VlrVolumenAncho = datareader.GetInt32(8);
                        DetalleVenta.VlrVolumenProfundidad = datareader.GetInt32(9);
                        DetalleVenta.VlrContenidoVolumetrico = datareader.GetInt32(10);
                        DetalleVenta.NombreUnidadMasa = datareader.GetString(11);
                        DetalleVenta.VlrUnidadMasa = datareader.GetInt32(12);
                        DetalleVenta.NombreUnidadLongitud = datareader.GetString(13);
                        DetalleVenta.VlrUnidadLongitud = datareader.GetInt32(14);
                        DetalleVenta.NombreTalla = datareader.GetString(15);
                        DetalleVenta.NombreColor = datareader.GetString(16);
                        DetalleVenta.NombreSabor = datareader.GetString(17);
                        DetalleVenta.PrecioVenta = datareader.GetDouble(18);
                        DetalleVenta.Cantidad = datareader.GetInt32(19);
                        DetalleVenta.CostoDelProducto = double.Parse(datareader.GetString(20));
                        DetalleVenta.SubTotalVenta = double.Parse(datareader.GetString(21));
                        DetalleVenta.SubtotalCosto = double.Parse(datareader.GetString(22));
                        DetalleVenta.NombreCategoria = datareader.GetString(23);
                        DetalleVenta.CaminoSubCategorias = datareader.GetString(24);
                        DetalleVenta.IdPresentacionArticulo = datareader.GetInt32(25);

                        DetalleVentas.Add(DetalleVenta);
                }

                listaReadOnlyDetalleVenta = new System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.DetalleVenta>(DetalleVentas);
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

            return listaReadOnlyDetalleVenta;

        }

        public EntidadesWeb.ResultadoTransaccion Eliminar(int IdUsuario)
        {
            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlParameter paramIdUsuario = null;
            EntidadesWeb.ResultadoTransaccion resultadoTransaccion = new EntidadesWeb.ResultadoTransaccion();

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "VentaEliminarPorIdUsuarioDelCarrito";

                paramIdUsuario = new System.Data.SqlClient.SqlParameter("@IdUsuario", System.Data.SqlDbType.Int);
                paramIdUsuario.Value = IdUsuario;
                cmd.Parameters.Add(paramIdUsuario);

                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();
                int i = cmd.ExecuteNonQuery();
                resultadoTransaccion.RegistrosAfectados = i;
                resultadoTransaccion.Mensaje = MensajesWeb.LinqToXml.LeerMensaje("0006");
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

                if (cmd != null)
                {
                    cmd.Dispose();
                }
            }

            return resultadoTransaccion;
        }

        public EntidadesWeb.Venta ConsultarParaVentaModoInvitado(System.Data.SqlClient.SqlConnection conexion, System.Data.SqlClient.SqlTransaction transaccion)
        {
            System.Data.SqlClient.SqlDataReader datareader = null;
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            EntidadesWeb.ResultadoTransaccion resultadoTransaccion = new EntidadesWeb.ResultadoTransaccion();
            EntidadesWeb.Venta Venta = new EntidadesWeb.Venta();

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "VentaConsultarModoInvitadoSelect";

                cmd.Connection = conexion;
                // conexion.Open();
                cmd.Transaction = transaccion;
                datareader = cmd.ExecuteReader();

                while (datareader.Read())
                {
                    Venta.IdVenta = datareader.GetInt32(0);
                    Venta.NroFactura = datareader.GetInt32(1);
                    Venta.IdCliente = datareader.GetInt32(2);
                    Venta.DocCliente = datareader.GetInt32(3);
                    Venta.NombreCliente = datareader.GetString(4);
                    Venta.ApellidoCliente = datareader.GetString(5);
                    Venta.TelefonoClienteUno = datareader.GetString(6);
                    Venta.TelefonoClienteDos = datareader.GetString(7);
                    Venta.EmailCliente = datareader.GetString(8);
                    Venta.ContrasenaCliente = datareader.GetString(9);
                    Venta.NombreDestinatario = datareader.GetString(10);
                    Venta.DireccionEnvioDestinatario = datareader.GetString(11);
                    Venta.TelefonoDestinatario = datareader.GetString(12);
                    Venta.NombrePaisDestinatario = datareader.GetString(13);
                    Venta.NombreDepartamentoDestinatario = datareader.GetString(14);
                    Venta.NombreCiudadDestinatario = datareader.GetString(15);
                    Venta.Fecha = datareader.GetDateTime(16);
                    Venta.CodigoReferenciaPayU = datareader.GetInt32(17);
                    Venta.MedioDEPago = datareader.GetString(18);
                    Venta.TotalVenta = double.Parse(datareader.GetString(19));
                    Venta.TotalCosto = double.Parse(datareader.GetString(20));
                    Venta.NroGuia = datareader.GetString(21);
                    Venta.CostoFlete = datareader.GetInt32(22);
                    Venta.Anulado = bool.Parse(datareader.GetString(23));
                }

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

            return Venta;
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.DetalleVenta> ConsultarParaDetalleVentaModoInvitado(System.Data.SqlClient.SqlConnection conexion, System.Data.SqlClient.SqlTransaction transaccion)
        {
            List<EntidadesWeb.DetalleVenta> DetalleVentas = new List<EntidadesWeb.DetalleVenta>();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataReader datareader = null;
            System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.DetalleVenta> listaReadOnlyDetalleVenta = null;

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "DetalleVentaConsultarModoInvitadoSelect";
                cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                cmd.Connection.Open();
                datareader = cmd.ExecuteReader();

                while (datareader.Read())
                {
                    EntidadesWeb.DetalleVenta DetalleVenta = new EntidadesWeb.DetalleVenta();

                    DetalleVenta.IdDetalleVenta = datareader.GetInt32(0);
                    DetalleVenta.IdVenta = datareader.GetInt32(1);
                    DetalleVenta.IdCliente = datareader.GetInt32(2);
                    DetalleVenta.NombreMarca = datareader.GetString(3);
                    DetalleVenta.Titulo = datareader.GetString(4);
                    // DetalleVenta.CodigoEAN = datareader.GetString(5);
                    DetalleVenta.NombreUnidadVolumen = datareader.GetString(5);
                    DetalleVenta.VlrVolumenLargo = datareader.GetInt32(6);
                    DetalleVenta.VlrVolumenAncho = datareader.GetInt32(7);
                    DetalleVenta.VlrVolumenProfundidad = datareader.GetInt32(8);
                    DetalleVenta.VlrContenidoVolumetrico = datareader.GetInt32(9);
                    DetalleVenta.NombreUnidadMasa = datareader.GetString(10);
                    DetalleVenta.VlrUnidadMasa = datareader.GetInt32(11);
                    DetalleVenta.NombreUnidadLongitud = datareader.GetString(12);                    
                    DetalleVenta.VlrUnidadLongitud = datareader.GetInt32(13);
                    DetalleVenta.NombreTalla = datareader.GetString(14);
                    DetalleVenta.NombreColor = datareader.GetString(15);
                    DetalleVenta.NombreSabor = datareader.GetString(16);
                    DetalleVenta.PrecioVenta = datareader.GetDouble(17);
                    DetalleVenta.Cantidad = datareader.GetInt32(18);
                    DetalleVenta.CostoDelProducto = double.Parse(datareader.GetString(19));
                    DetalleVenta.SubTotalVenta = double.Parse(datareader.GetString(20));
                    DetalleVenta.SubtotalCosto = double.Parse(datareader.GetString(21));
                    DetalleVenta.NombreCategoria = datareader.GetString(22);
                    DetalleVenta.CaminoSubCategorias = datareader.GetString(23);
                    DetalleVenta.IdPresentacionArticulo = datareader.GetInt32(24);

                    DetalleVentas.Add(DetalleVenta);
                }

                listaReadOnlyDetalleVenta = new System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.DetalleVenta>(DetalleVentas);
                // Logging.Accion.Guardar("Lectura de la tabla Detalle Venta");
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

            return listaReadOnlyDetalleVenta;
        }
    }
}
