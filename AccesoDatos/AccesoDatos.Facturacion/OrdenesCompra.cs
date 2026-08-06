//-----------------------------------------------------------------------
// <copyright file="OrdenesCompra.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace AccesoDatos.Facturacion
{
    using System;
    using System.Collections.Generic;
    using Entidades;
    using System.Data.SqlClient;
    using System.Collections.ObjectModel;
    using Entidades.Enumeraciones;

    public class OrdenesCompra : Contratos.IOrdenesCompra
    {
        public Entidades.ResultadoTransaccion ConfirmarOrdenCompra(List<PresentacionArticulo> listaPresentacionArticulo, Cliente cliente, int IdAlbaran)
        {
            
            System.Data.SqlClient.SqlParameter paramIdAlbaran = null;
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            Entidades.ResultadoTransaccion resultado = new Entidades.ResultadoTransaccion();
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

            // Parametros Guardar Cabeza de Factura Procedimiento Almacenado [VentaInsert]
            System.Data.SqlClient.SqlParameter paramNroFactura = new System.Data.SqlClient.SqlParameter("@NroFactura", System.Data.SqlDbType.Int);
            System.Data.SqlClient.SqlParameter paramIdCliente = new System.Data.SqlClient.SqlParameter("@IdCliente", System.Data.SqlDbType.Int);
            System.Data.SqlClient.SqlParameter paramDocCliente = new System.Data.SqlClient.SqlParameter("@DocCliente", System.Data.SqlDbType.Int);
            System.Data.SqlClient.SqlParameter paramNombreCliente = new System.Data.SqlClient.SqlParameter("@NombreCliente", System.Data.SqlDbType.NVarChar, 30);
            System.Data.SqlClient.SqlParameter paramApellidoCliente = new System.Data.SqlClient.SqlParameter("@ApellidoCliente", System.Data.SqlDbType.NVarChar, 30);
            System.Data.SqlClient.SqlParameter paramTelefonoClienteUno = new System.Data.SqlClient.SqlParameter("@TelefonoClienteUno", System.Data.SqlDbType.NVarChar, 20);
            System.Data.SqlClient.SqlParameter paramTelefonoClienteDos = new System.Data.SqlClient.SqlParameter("@TelefonoClienteDos", System.Data.SqlDbType.NVarChar, 20);
            System.Data.SqlClient.SqlParameter paramEmailCliente = new System.Data.SqlClient.SqlParameter("@EmailCliente", System.Data.SqlDbType.NVarChar, 50);
            System.Data.SqlClient.SqlParameter paramContrasenaCliente = new System.Data.SqlClient.SqlParameter("@ContrasenaCliente", System.Data.SqlDbType.NVarChar, 50);
            System.Data.SqlClient.SqlParameter paramNombreDestinatario = new System.Data.SqlClient.SqlParameter("@NombreDestinatario", System.Data.SqlDbType.NVarChar, 30);
            System.Data.SqlClient.SqlParameter paramDireccionEnvioDestinatario = new System.Data.SqlClient.SqlParameter("@DireccionEnvioDestinatario", System.Data.SqlDbType.NVarChar, 80);
            System.Data.SqlClient.SqlParameter paramTelefonoDestinatario = new System.Data.SqlClient.SqlParameter("@TelefonoDestinatario", System.Data.SqlDbType.NVarChar, 20);
            System.Data.SqlClient.SqlParameter paramNombrePaisDestinatario = new System.Data.SqlClient.SqlParameter("@NombrePaisDestinatario", System.Data.SqlDbType.NVarChar, 42);
            System.Data.SqlClient.SqlParameter paramNombreDepartamentoDestinatario = new System.Data.SqlClient.SqlParameter("@NombreDepartamentoDestinatario", System.Data.SqlDbType.NVarChar, 42);
            System.Data.SqlClient.SqlParameter paramNombreCiudadDestinatario = new System.Data.SqlClient.SqlParameter("@NombreCiudadDestinatario", System.Data.SqlDbType.NVarChar, 42);
            System.Data.SqlClient.SqlParameter paramFecha = new System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.Date);
            System.Data.SqlClient.SqlParameter paramCodigoReferenciaPayU = new System.Data.SqlClient.SqlParameter("@CodigoReferenciaPayU", System.Data.SqlDbType.Int);
            System.Data.SqlClient.SqlParameter paramMedioDePago = new System.Data.SqlClient.SqlParameter("@MedioDePago", System.Data.SqlDbType.NVarChar, 60);
            System.Data.SqlClient.SqlParameter paramTotalVenta = new System.Data.SqlClient.SqlParameter("@TotalVenta", System.Data.SqlDbType.Float);
            System.Data.SqlClient.SqlParameter paramTotalCosto = new System.Data.SqlClient.SqlParameter("@TotalCosto", System.Data.SqlDbType.Float);
            System.Data.SqlClient.SqlParameter paramNroGuia = new System.Data.SqlClient.SqlParameter("@NroGuia", System.Data.SqlDbType.NVarChar, 20);
            System.Data.SqlClient.SqlParameter paramCostoFlete = new System.Data.SqlClient.SqlParameter("@CostoFlete", System.Data.SqlDbType.Int);
            System.Data.SqlClient.SqlParameter paramAnulado = new System.Data.SqlClient.SqlParameter("@Anulado", System.Data.SqlDbType.Bit);
            System.Data.SqlClient.SqlParameter paramEstadoVenta = new System.Data.SqlClient.SqlParameter("@EstadoVenta", System.Data.SqlDbType.NVarChar, 50);
            System.Data.SqlClient.SqlParameter paramOutIdVenta = new System.Data.SqlClient.SqlParameter("@OutIdVenta", System.Data.SqlDbType.Int);
            paramOutIdVenta.Direction = System.Data.ParameterDirection.Output;

            // Parametros guardar detalle de Factura, Procedimiento Almacenado [DetalleVentaInsert]
            System.Data.SqlClient.SqlParameter paramIdVenta = new System.Data.SqlClient.SqlParameter("@IdVenta", System.Data.SqlDbType.Int);
            paramIdCliente = new System.Data.SqlClient.SqlParameter("@IdCliente", System.Data.SqlDbType.Int);
            System.Data.SqlClient.SqlParameter paramNombreMarca = new System.Data.SqlClient.SqlParameter("@NombreMarca", System.Data.SqlDbType.NVarChar, 20);
            System.Data.SqlClient.SqlParameter paramTitulo = new System.Data.SqlClient.SqlParameter("@Titulo", System.Data.SqlDbType.NVarChar, 50);
            System.Data.SqlClient.SqlParameter paramCodigoEAN = new System.Data.SqlClient.SqlParameter("@CodigoEAN", System.Data.SqlDbType.NVarChar, 30);
            System.Data.SqlClient.SqlParameter paramNombreUnidadVolumen = new System.Data.SqlClient.SqlParameter("@NombreUnidadVolumen", System.Data.SqlDbType.NVarChar, 40);
            System.Data.SqlClient.SqlParameter paramVlrVolumenLargo = new System.Data.SqlClient.SqlParameter("@VlrVolumenLargo", System.Data.SqlDbType.Float);
            System.Data.SqlClient.SqlParameter paramVlrVolumenAncho = new System.Data.SqlClient.SqlParameter("@VlrVolumenAncho", System.Data.SqlDbType.Float);
            System.Data.SqlClient.SqlParameter paramVlrVolumenProfundidad = new System.Data.SqlClient.SqlParameter("@VlrVolumenProfundidad", System.Data.SqlDbType.Float);
            System.Data.SqlClient.SqlParameter paramVlrContenidoVolumetrico = new System.Data.SqlClient.SqlParameter("@VlrContenidoVolumetrico", System.Data.SqlDbType.Float);
            System.Data.SqlClient.SqlParameter paramNombreUnidadMasa = new System.Data.SqlClient.SqlParameter("@NombreUnidadMasa", System.Data.SqlDbType.NVarChar, 20);
            System.Data.SqlClient.SqlParameter paramVlrUnidadMasa = new System.Data.SqlClient.SqlParameter("@VlrUnidadMasa", System.Data.SqlDbType.Float);
            System.Data.SqlClient.SqlParameter paramNombreUnidadLongitud = new System.Data.SqlClient.SqlParameter("@NombreUnidadLongitud", System.Data.SqlDbType.NVarChar, 20);
            System.Data.SqlClient.SqlParameter paramVlrUnidadLongitud = new System.Data.SqlClient.SqlParameter("@VlrUnidadLongitud", System.Data.SqlDbType.Float);
            System.Data.SqlClient.SqlParameter paramNombreTalla = new System.Data.SqlClient.SqlParameter("@NombreTalla", System.Data.SqlDbType.NVarChar, 20);
            System.Data.SqlClient.SqlParameter paramNombreColor = new System.Data.SqlClient.SqlParameter("@NombreColor", System.Data.SqlDbType.NVarChar, 25);
            System.Data.SqlClient.SqlParameter paramNombreSabor = new System.Data.SqlClient.SqlParameter("@NombreSabor", System.Data.SqlDbType.NVarChar, 20);
            System.Data.SqlClient.SqlParameter paramPrecioVenta = new System.Data.SqlClient.SqlParameter("@PrecioVenta", System.Data.SqlDbType.Float);
            System.Data.SqlClient.SqlParameter paramCantidad = new System.Data.SqlClient.SqlParameter("@Cantidad", System.Data.SqlDbType.Int);
            System.Data.SqlClient.SqlParameter paramCostoDelProducto = new System.Data.SqlClient.SqlParameter("@CostoDelProducto", System.Data.SqlDbType.Float);
            System.Data.SqlClient.SqlParameter paramSubTotalVenta = new System.Data.SqlClient.SqlParameter("@SubTotalVenta", System.Data.SqlDbType.Float);
            System.Data.SqlClient.SqlParameter paramSubtotalCosto = new System.Data.SqlClient.SqlParameter("@SubtotalCosto", System.Data.SqlDbType.Float);
            System.Data.SqlClient.SqlParameter paramNombreCategoria = new System.Data.SqlClient.SqlParameter("@NombreCategoria", System.Data.SqlDbType.NVarChar, 60);
            System.Data.SqlClient.SqlParameter paramCaminoSubCategorias = new System.Data.SqlClient.SqlParameter("@CaminoSubCategorias", System.Data.SqlDbType.NVarChar, 250);
            System.Data.SqlClient.SqlParameter paramIdPresentacionArticulo = new System.Data.SqlClient.SqlParameter("@IdPresentacionArticulo", System.Data.SqlDbType.Int);
            System.Data.SqlClient.SqlParameter paramNombreUnidadPresentacion = new System.Data.SqlClient.SqlParameter("@NombreUnidadPresentacion", System.Data.SqlDbType.NVarChar, 40);
            System.Data.SqlClient.SqlParameter paramVlrUnidadPresentacion = new System.Data.SqlClient.SqlParameter("@VlrUnidadPresentacion", System.Data.SqlDbType.Float);

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();

                cmd.Transaction = cmd.Connection.BeginTransaction("TransaccionEliminarOrdenCompra");
                // AlbaranDelete
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "OrdenCompraDataAlbaranDelete";                            
                paramIdAlbaran = new System.Data.SqlClient.SqlParameter("@IdAlbaran", System.Data.SqlDbType.Int);
                paramIdAlbaran.Value = IdAlbaran;
                cmd.Parameters.Add(paramIdAlbaran);                
                resultado.RegistrosAfectados = cmd.ExecuteNonQuery();
                resultado.Mensaje = Mensajes.LinqToXml.LeerMensaje("0006");

                // DetalleAlbaranDelete
                cmd.Parameters.Clear();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "OrdenCompraDataDetalleAlbaranDelete";
                paramIdAlbaran = new System.Data.SqlClient.SqlParameter("@IdAlbaran", System.Data.SqlDbType.Int);
                paramIdAlbaran.Value = IdAlbaran;
                cmd.Parameters.Add(paramIdAlbaran);
                resultado.RegistrosAfectados = cmd.ExecuteNonQuery();
                resultado.Mensaje = Mensajes.LinqToXml.LeerMensaje("0006");


                // CONFIRMAR ORDEN COMPRA -> VENTA *****************************************************************************************************************************


                cmd.Parameters.Clear();
                cmd.CommandText = "ContadoresGenerarNumeroFactura";
                SqlDataReader datareader = cmd.ExecuteReader();
                if (datareader.Read())
                {
                    paramNroFactura.Value = datareader.GetInt32(0);
                    datareader.Close();
                }

                int Cero = 0;
                double TotalVenta = 0;
                if (cliente == null)
                {
                    // La venta se asocia al cliente anónimo
                    paramIdCliente.Value = 1;
                    paramDocCliente.Value = Cero;
                    paramNombreCliente.Value = string.Empty;
                    paramApellidoCliente.Value = string.Empty;
                    paramTelefonoClienteUno.Value = string.Empty;
                    paramTelefonoClienteDos.Value = string.Empty;
                    paramEmailCliente.Value = string.Empty;
                    paramContrasenaCliente.Value = string.Empty;
                    paramNombreDestinatario.Value = string.Empty;
                    paramDireccionEnvioDestinatario.Value = string.Empty;
                    paramTelefonoDestinatario.Value = string.Empty;
                    paramNombrePaisDestinatario.Value = string.Empty;
                    paramNombreDepartamentoDestinatario.Value = string.Empty;
                    paramNombreCiudadDestinatario.Value = string.Empty;
                }
                else
                {
                    paramIdCliente.Value = cliente.IdCliente;
                    paramDocCliente.Value = cliente.DocCliente;
                    paramNombreCliente.Value = cliente.Nombre;
                    paramApellidoCliente.Value = cliente.Apellido;
                    paramTelefonoClienteUno.Value = cliente.Telefono1;
                    paramTelefonoClienteDos.Value = cliente.Telefono2;
                    paramEmailCliente.Value = cliente.Email;
                    paramContrasenaCliente.Value = string.Empty;
                    paramNombreDestinatario.Value = cliente.Direcciones[0].NombreDestinatario;
                    paramDireccionEnvioDestinatario.Value = cliente.Direcciones[0].DireccionEnvio;
                    paramTelefonoDestinatario.Value = cliente.Direcciones[0].Telefono;
                    paramNombrePaisDestinatario.Value = cliente.Direcciones[0].Pais.Nombre;
                    paramNombreDepartamentoDestinatario.Value = cliente.Direcciones[0].Departamento.Nombre;
                    paramNombreCiudadDestinatario.Value = cliente.Direcciones[0].Ciudad.Nombre;
                }
                paramFecha.Value = System.DateTime.Now;
                paramCodigoReferenciaPayU.Value = int.MinValue;
                paramMedioDePago.Value = string.Empty; // metodoDePago.Nombre;
                for (int i = 0; i < listaPresentacionArticulo.Count; i++)
                {
                    if (listaPresentacionArticulo[i] != null)
                    {
                        TotalVenta += listaPresentacionArticulo[i].Existencias * listaPresentacionArticulo[i].Precio;
                    }
                }
                paramTotalVenta.Value = TotalVenta;
                paramTotalCosto.Value = Cero;
                paramNroGuia.Value = Cero;
                paramCostoFlete.Value = Cero;
                paramAnulado.Value = Cero;
                paramEstadoVenta.Value = string.Empty; // estadoDeLaVenta.EstadoNuevo;

                cmd.Parameters.Clear();

                // Parametros de Cabeza de Factura
                cmd.Parameters.Add(paramNroFactura);
                cmd.Parameters.Add(paramIdCliente);
                cmd.Parameters.Add(paramDocCliente);
                cmd.Parameters.Add(paramNombreCliente);
                cmd.Parameters.Add(paramApellidoCliente);
                cmd.Parameters.Add(paramTelefonoClienteUno);
                cmd.Parameters.Add(paramTelefonoClienteDos);
                cmd.Parameters.Add(paramEmailCliente);
                cmd.Parameters.Add(paramContrasenaCliente);
                cmd.Parameters.Add(paramNombreDestinatario);
                cmd.Parameters.Add(paramDireccionEnvioDestinatario);
                cmd.Parameters.Add(paramTelefonoDestinatario);
                cmd.Parameters.Add(paramNombrePaisDestinatario);
                cmd.Parameters.Add(paramNombreDepartamentoDestinatario);
                cmd.Parameters.Add(paramNombreCiudadDestinatario);
                cmd.Parameters.Add(paramFecha);
                cmd.Parameters.Add(paramCodigoReferenciaPayU);
                cmd.Parameters.Add(paramMedioDePago);
                cmd.Parameters.Add(paramTotalVenta);
                cmd.Parameters.Add(paramTotalCosto);
                cmd.Parameters.Add(paramNroGuia);
                cmd.Parameters.Add(paramCostoFlete);
                cmd.Parameters.Add(paramAnulado);
                cmd.Parameters.Add(paramOutIdVenta);
                cmd.Parameters.Add(paramEstadoVenta);

                cmd.CommandText = "VentaInsert";
                cmd.ExecuteNonQuery();

                // Guardar detalle de factura
                // procedimiento almacenado [DetalleVentaInsert]
                for (int i = 0; i < listaPresentacionArticulo.Count; i++)
                {
                    if (listaPresentacionArticulo[i] != null)
                    {
                        paramIdVenta.Value = paramOutIdVenta.Value;
                        this.ValidarCliente(cliente, paramIdCliente);
                        paramNombreMarca.Value = listaPresentacionArticulo[i].Articulo.Marca.Nombre;
                        paramTitulo.Value = listaPresentacionArticulo[i].Nombre;
                        paramNombreUnidadVolumen.Value = listaPresentacionArticulo[i].UnidadVolumen.Nombre;
                        paramVlrVolumenLargo.Value = listaPresentacionArticulo[i].VlrUnidadVolumenLargo;
                        paramVlrVolumenAncho.Value = listaPresentacionArticulo[i].VlrUnidadVolumenAncho;
                        paramVlrVolumenProfundidad.Value = listaPresentacionArticulo[i].VlrUnidadVolumenProfundidad;
                        paramVlrContenidoVolumetrico.Value = listaPresentacionArticulo[i].VlrContenidoVolumetrico;
                        paramNombreUnidadMasa.Value = listaPresentacionArticulo[i].UnidadMasa.Nombre;
                        paramVlrUnidadMasa.Value = listaPresentacionArticulo[i].VlrUnidadMasa;
                        paramNombreUnidadLongitud.Value = listaPresentacionArticulo[i].UnidadLongitud.Nombre;
                        paramVlrUnidadLongitud.Value = listaPresentacionArticulo[i].VlrUnidadLongitud;
                        paramNombreTalla.Value = listaPresentacionArticulo[i].Talla.Nombre;
                        paramNombreColor.Value = listaPresentacionArticulo[i].Color.Nombre;
                        paramNombreSabor.Value = listaPresentacionArticulo[i].Sabor.Nombre;
                        paramPrecioVenta.Value = listaPresentacionArticulo[i].Precio;
                        paramCantidad.Value = listaPresentacionArticulo[i].Existencias;
                        paramCostoDelProducto.Value = listaPresentacionArticulo[i].CostoArticulo;
                        paramSubTotalVenta.Value = listaPresentacionArticulo[i].Existencias * listaPresentacionArticulo[i].Precio;
                        paramSubtotalCosto.Value = listaPresentacionArticulo[i].Existencias * listaPresentacionArticulo[i].CostoArticulo;
                        paramNombreCategoria.Value = listaPresentacionArticulo[i].Articulo.Categoria.Nombre;
                        paramCaminoSubCategorias.Value = string.Empty;
                        paramIdPresentacionArticulo.Value = listaPresentacionArticulo[i].IdPresentacionArticulo;
                        paramNombreUnidadPresentacion.Value = listaPresentacionArticulo[i].UnidadPresentacion.Nombre;
                        paramVlrUnidadPresentacion.Value = listaPresentacionArticulo[i].VlrUnidadPresentacion;

                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(paramIdVenta);
                        cmd.Parameters.Add(paramIdCliente);
                        cmd.Parameters.Add(paramNombreMarca);
                        cmd.Parameters.Add(paramTitulo);
                        cmd.Parameters.Add(paramNombreUnidadVolumen);
                        cmd.Parameters.Add(paramVlrVolumenLargo);
                        cmd.Parameters.Add(paramVlrVolumenAncho);
                        cmd.Parameters.Add(paramVlrVolumenProfundidad);
                        cmd.Parameters.Add(paramVlrContenidoVolumetrico);
                        cmd.Parameters.Add(paramNombreUnidadMasa);
                        cmd.Parameters.Add(paramVlrUnidadMasa);
                        cmd.Parameters.Add(paramNombreUnidadLongitud);
                        cmd.Parameters.Add(paramVlrUnidadLongitud);
                        cmd.Parameters.Add(paramNombreTalla);
                        cmd.Parameters.Add(paramNombreColor);
                        cmd.Parameters.Add(paramNombreSabor);
                        cmd.Parameters.Add(paramPrecioVenta);
                        cmd.Parameters.Add(paramCantidad);
                        cmd.Parameters.Add(paramCostoDelProducto);
                        cmd.Parameters.Add(paramSubTotalVenta);
                        cmd.Parameters.Add(paramSubtotalCosto);
                        cmd.Parameters.Add(paramNombreCategoria);
                        cmd.Parameters.Add(paramCaminoSubCategorias);
                        cmd.Parameters.Add(paramIdPresentacionArticulo);
                        cmd.Parameters.Add(paramNombreUnidadPresentacion);
                        cmd.Parameters.Add(paramVlrUnidadPresentacion);

                        cmd.CommandText = "DetalleVentaInsert";
                        cmd.ExecuteNonQuery();

                        // Actualizar las cantidades de la prsentación del artículo
                        cmd.CommandText = "PresentacionArticuloUpdateStock";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@Cantidad", paramCantidad.Value);
                        cmd.Parameters.AddWithValue("@IdPresentacionArticulo", paramIdPresentacionArticulo.Value);
                        cmd.ExecuteNonQuery();
                    }
                }

                // Terminar transacción
                cmd.Transaction.Commit();
                cmd.Connection.Close();
                resultado.RegistrosAfectados = 0; 
            }
            catch (SqlException ex)
            {
                cmd.Transaction.Rollback();
                Logging.ErrorGeneral.Guardar(ex);
            }
            catch (Exception ex)
            {
                cmd.Transaction.Rollback();
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

            return resultado;
        }

        public Entidades.ResultadoTransaccion EliminarOrdenCompraLogico(int IdAlbaran)
        {
            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlParameter paramIdAlbaran = null;
            Entidades.ResultadoTransaccion resultado = new Entidades.ResultadoTransaccion();
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "OrdenCompraEliminadoLogicoDelete";

                paramIdAlbaran = new System.Data.SqlClient.SqlParameter("@IdAlbaran", System.Data.SqlDbType.Int);
                paramIdAlbaran.Value = IdAlbaran;
                cmd.Parameters.Add(paramIdAlbaran);

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

        public int GenerarOrdenCompra(List<PresentacionArticulo> listaPresentacionArticulo, Cliente cliente)
        {
            // Parametros Guardar Cabeza de Factura Procedimiento Almacenado [AlbaranInsert]
            System.Data.SqlClient.SqlParameter paramIdCliente = new System.Data.SqlClient.SqlParameter("@IdCliente", System.Data.SqlDbType.Int);
            System.Data.SqlClient.SqlParameter paramDocCliente = new System.Data.SqlClient.SqlParameter("@DocCliente", System.Data.SqlDbType.Int);
            System.Data.SqlClient.SqlParameter paramNroOrdenCompra = new System.Data.SqlClient.SqlParameter("@NroOrdenCompra", System.Data.SqlDbType.NVarChar, 50);
            System.Data.SqlClient.SqlParameter paramNombreCliente = new System.Data.SqlClient.SqlParameter("@NombreCliente", System.Data.SqlDbType.NVarChar, 30);
            System.Data.SqlClient.SqlParameter paramApellidoCliente = new System.Data.SqlClient.SqlParameter("@ApellidoCliente", System.Data.SqlDbType.NVarChar, 30);
            System.Data.SqlClient.SqlParameter paramTelefonoClienteUno = new System.Data.SqlClient.SqlParameter("@TelefonoClienteUno", System.Data.SqlDbType.NVarChar, 20);
            System.Data.SqlClient.SqlParameter paramTelefonoClienteDos = new System.Data.SqlClient.SqlParameter("@TelefonoClienteDos", System.Data.SqlDbType.NVarChar, 20);
            System.Data.SqlClient.SqlParameter paramEmailCliente = new System.Data.SqlClient.SqlParameter("@EmailCliente", System.Data.SqlDbType.NVarChar, 50);
            System.Data.SqlClient.SqlParameter paramContrasenaCliente = new System.Data.SqlClient.SqlParameter("@ContrasenaCliente", System.Data.SqlDbType.NVarChar, 50);
            System.Data.SqlClient.SqlParameter paramNombreDestinatario = new System.Data.SqlClient.SqlParameter("@NombreDestinatario", System.Data.SqlDbType.NVarChar, 30);
            System.Data.SqlClient.SqlParameter paramDireccionEnvioDestinatario = new System.Data.SqlClient.SqlParameter("@DireccionEnvioDestinatario", System.Data.SqlDbType.NVarChar, 80);
            System.Data.SqlClient.SqlParameter paramTelefonoDestinatario = new System.Data.SqlClient.SqlParameter("@TelefonoDestinatario", System.Data.SqlDbType.NVarChar, 20);
            System.Data.SqlClient.SqlParameter paramNombrePaisDestinatario = new System.Data.SqlClient.SqlParameter("@NombrePaisDestinatario", System.Data.SqlDbType.NVarChar, 42);
            System.Data.SqlClient.SqlParameter paramNombreDepartamentoDestinatario = new System.Data.SqlClient.SqlParameter("@NombreDepartamentoDestinatario", System.Data.SqlDbType.NVarChar, 42);
            System.Data.SqlClient.SqlParameter paramNombreCiudadDestinatario = new System.Data.SqlClient.SqlParameter("@NombreCiudadDestinatario", System.Data.SqlDbType.NVarChar, 42);
            System.Data.SqlClient.SqlParameter paramFecha = new System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.Date);
            System.Data.SqlClient.SqlParameter paramCodigoReferenciaPayU = new System.Data.SqlClient.SqlParameter("@CodigoReferenciaPayU", System.Data.SqlDbType.Int);
            System.Data.SqlClient.SqlParameter paramTotalVenta = new System.Data.SqlClient.SqlParameter("@TotalVenta", System.Data.SqlDbType.Float);
            System.Data.SqlClient.SqlParameter paramTotalCosto = new System.Data.SqlClient.SqlParameter("@TotalCosto", System.Data.SqlDbType.Float);
            System.Data.SqlClient.SqlParameter paramNroGuia = new System.Data.SqlClient.SqlParameter("@NroGuia", System.Data.SqlDbType.NVarChar, 20);
            System.Data.SqlClient.SqlParameter paramCostoFlete = new System.Data.SqlClient.SqlParameter("@CostoFlete", System.Data.SqlDbType.Int);
            System.Data.SqlClient.SqlParameter paramAnulado = new System.Data.SqlClient.SqlParameter("@Anulado", System.Data.SqlDbType.Bit);
            System.Data.SqlClient.SqlParameter paramOutIdAlbaran = new System.Data.SqlClient.SqlParameter("@OutIdAlbaran", System.Data.SqlDbType.Int);
            paramOutIdAlbaran.Direction = System.Data.ParameterDirection.Output;

            // Parametros guardar detalle de Factura, Procedimiento Almacenado [DetalleAlbaranInsert]
            System.Data.SqlClient.SqlParameter paramIdAlbaran = new System.Data.SqlClient.SqlParameter("@IdAlbaran", System.Data.SqlDbType.Int);
            paramIdCliente = new System.Data.SqlClient.SqlParameter("@IdCliente", System.Data.SqlDbType.Int);
            System.Data.SqlClient.SqlParameter paramNombreMarca = new System.Data.SqlClient.SqlParameter("@NombreMarca", System.Data.SqlDbType.NVarChar, 20);
            System.Data.SqlClient.SqlParameter paramTitulo = new System.Data.SqlClient.SqlParameter("@Titulo", System.Data.SqlDbType.NVarChar, 50);
            System.Data.SqlClient.SqlParameter paramCodigoEAN = new System.Data.SqlClient.SqlParameter("@CodigoEAN", System.Data.SqlDbType.NVarChar, 30);
            System.Data.SqlClient.SqlParameter paramNombreUnidadVolumen = new System.Data.SqlClient.SqlParameter("@NombreUnidadVolumen", System.Data.SqlDbType.NVarChar, 40);
            System.Data.SqlClient.SqlParameter paramVlrVolumenLargo = new System.Data.SqlClient.SqlParameter("@VlrVolumenLargo", System.Data.SqlDbType.Float);
            System.Data.SqlClient.SqlParameter paramVlrVolumenAncho = new System.Data.SqlClient.SqlParameter("@VlrVolumenAncho", System.Data.SqlDbType.Float);
            System.Data.SqlClient.SqlParameter paramVlrVolumenProfundidad = new System.Data.SqlClient.SqlParameter("@VlrVolumenProfundidad", System.Data.SqlDbType.Float);
            System.Data.SqlClient.SqlParameter paramVlrContenidoVolumetrico = new System.Data.SqlClient.SqlParameter("@VlrContenidoVolumetrico", System.Data.SqlDbType.Float);
            System.Data.SqlClient.SqlParameter paramNombreUnidadMasa = new System.Data.SqlClient.SqlParameter("@NombreUnidadMasa", System.Data.SqlDbType.NVarChar, 20);
            System.Data.SqlClient.SqlParameter paramVlrUnidadMasa = new System.Data.SqlClient.SqlParameter("@VlrUnidadMasa", System.Data.SqlDbType.Float);
            System.Data.SqlClient.SqlParameter paramNombreUnidadLongitud = new System.Data.SqlClient.SqlParameter("@NombreUnidadLongitud", System.Data.SqlDbType.NVarChar, 20);
            System.Data.SqlClient.SqlParameter paramVlrUnidadLongitud = new System.Data.SqlClient.SqlParameter("@VlrUnidadLongitud", System.Data.SqlDbType.Float);
            System.Data.SqlClient.SqlParameter paramNombreTalla = new System.Data.SqlClient.SqlParameter("@NombreTalla", System.Data.SqlDbType.NVarChar, 20);
            System.Data.SqlClient.SqlParameter paramNombreColor = new System.Data.SqlClient.SqlParameter("@NombreColor", System.Data.SqlDbType.NVarChar, 25);
            System.Data.SqlClient.SqlParameter paramNombreSabor = new System.Data.SqlClient.SqlParameter("@NombreSabor", System.Data.SqlDbType.NVarChar, 20);
            System.Data.SqlClient.SqlParameter paramPrecioVenta = new System.Data.SqlClient.SqlParameter("@PrecioVenta", System.Data.SqlDbType.Float);
            System.Data.SqlClient.SqlParameter paramCantidad = new System.Data.SqlClient.SqlParameter("@Cantidad", System.Data.SqlDbType.Int);
            System.Data.SqlClient.SqlParameter paramCostoDelProducto = new System.Data.SqlClient.SqlParameter("@CostoDelProducto", System.Data.SqlDbType.Float);
            System.Data.SqlClient.SqlParameter paramSubTotalVenta = new System.Data.SqlClient.SqlParameter("@SubTotalVenta", System.Data.SqlDbType.Float);
            System.Data.SqlClient.SqlParameter paramSubtotalCosto = new System.Data.SqlClient.SqlParameter("@SubtotalCosto", System.Data.SqlDbType.Float);
            System.Data.SqlClient.SqlParameter paramNombreCategoria = new System.Data.SqlClient.SqlParameter("@NombreCategoria", System.Data.SqlDbType.NVarChar, 60);
            System.Data.SqlClient.SqlParameter paramCaminoSubCategorias = new System.Data.SqlClient.SqlParameter("@CaminoSubCategorias", System.Data.SqlDbType.NVarChar, 250);
            System.Data.SqlClient.SqlParameter paramIdPresentacionArticulo = new System.Data.SqlClient.SqlParameter("@IdPresentacionArticulo", System.Data.SqlDbType.Int);
            System.Data.SqlClient.SqlParameter paramNombreUnidadPresentacion = new System.Data.SqlClient.SqlParameter("@NombreUnidadPresentacion", System.Data.SqlDbType.NVarChar, 40);
            System.Data.SqlClient.SqlParameter paramVlrUnidadPresentacion = new System.Data.SqlClient.SqlParameter("@VlrUnidadPresentacion", System.Data.SqlDbType.Float);

            Entidades.ResultadoTransaccion resultado = new Entidades.ResultadoTransaccion();

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();

                // Iniciar transacción
                cmd.Transaction = cmd.Connection.BeginTransaction("TransaccionGenerarOrdenCompra");

                // aumentar y recuperar un nuevo número de factura
                // Procedimiento almacenado [ContadoresGenerarNumeroFactura]
                cmd.CommandText = "ContadoresGenerarNumeroFactura";
                SqlDataReader datareader = cmd.ExecuteReader();
                if (datareader.Read())
                {
                    paramNroOrdenCompra.Value = datareader.GetInt32(0);
                    datareader.Close();
                }

                int Cero = 0;
                double TotalVenta = 0;
                if (cliente == null)
                {
                    // La venta se asocia al Cliente anónimo
                    paramIdCliente.Value = 1;
                    paramDocCliente.Value = Cero;
                    paramNombreCliente.Value = string.Empty;
                    paramApellidoCliente.Value = string.Empty;
                    paramTelefonoClienteUno.Value = string.Empty;
                    paramTelefonoClienteDos.Value = string.Empty;
                    paramEmailCliente.Value = string.Empty;
                    paramContrasenaCliente.Value = string.Empty;
                    paramNombreDestinatario.Value = string.Empty;
                    paramDireccionEnvioDestinatario.Value = string.Empty;
                    paramTelefonoDestinatario.Value = string.Empty;
                    paramNombrePaisDestinatario.Value = string.Empty;
                    paramNombreDepartamentoDestinatario.Value = string.Empty;
                    paramNombreCiudadDestinatario.Value = string.Empty;
                }
                else
                {
                    paramIdCliente.Value = cliente.IdCliente;
                    paramDocCliente.Value = cliente.DocCliente;
                    paramNombreCliente.Value = cliente.Nombre;
                    paramApellidoCliente.Value = cliente.Apellido;
                    paramTelefonoClienteUno.Value = cliente.Telefono1;
                    paramTelefonoClienteDos.Value = cliente.Telefono2;
                    paramEmailCliente.Value = cliente.Email;
                    paramContrasenaCliente.Value = string.Empty;
                    paramNombreDestinatario.Value = cliente.Direcciones[0].NombreDestinatario;
                    paramDireccionEnvioDestinatario.Value = cliente.Direcciones[0].DireccionEnvio;
                    paramTelefonoDestinatario.Value = cliente.Direcciones[0].Telefono;
                    paramNombrePaisDestinatario.Value = cliente.Direcciones[0].Pais.Nombre;
                    paramNombreDepartamentoDestinatario.Value = cliente.Direcciones[0].Departamento.Nombre;
                    paramNombreCiudadDestinatario.Value = cliente.Direcciones[0].Ciudad.Nombre;
                }
                paramFecha.Value = System.DateTime.Now;
                paramCodigoReferenciaPayU.Value = int.MinValue;

                for (int i = 0; i < listaPresentacionArticulo.Count; i++)
                {
                    if (listaPresentacionArticulo[i].CodigoEAN != null)
                    {
                        TotalVenta += listaPresentacionArticulo[i].Existencias * listaPresentacionArticulo[i].Precio;
                    }
                }
                paramTotalVenta.Value = TotalVenta;
                paramTotalCosto.Value = Cero;
                paramNroGuia.Value = Cero;
                paramCostoFlete.Value = Cero;
                paramAnulado.Value = Cero;

                cmd.Parameters.Clear();

                cmd.Parameters.Add(paramIdCliente);
                cmd.Parameters.Add(paramDocCliente);
                cmd.Parameters.Add(paramNroOrdenCompra);
                cmd.Parameters.Add(paramNombreCliente);
                cmd.Parameters.Add(paramApellidoCliente);
                cmd.Parameters.Add(paramTelefonoClienteUno);
                cmd.Parameters.Add(paramTelefonoClienteDos);
                cmd.Parameters.Add(paramEmailCliente);
                cmd.Parameters.Add(paramContrasenaCliente);
                cmd.Parameters.Add(paramNombreDestinatario);
                cmd.Parameters.Add(paramDireccionEnvioDestinatario);
                cmd.Parameters.Add(paramTelefonoDestinatario);
                cmd.Parameters.Add(paramNombrePaisDestinatario);
                cmd.Parameters.Add(paramNombreDepartamentoDestinatario);
                cmd.Parameters.Add(paramNombreCiudadDestinatario);
                cmd.Parameters.Add(paramFecha);
                cmd.Parameters.Add(paramCodigoReferenciaPayU);

                cmd.Parameters.Add(paramTotalVenta);
                cmd.Parameters.Add(paramTotalCosto);
                cmd.Parameters.Add(paramNroGuia);
                cmd.Parameters.Add(paramCostoFlete);
                cmd.Parameters.Add(paramAnulado);
                cmd.Parameters.Add(paramOutIdAlbaran);

                cmd.CommandText = "AlbaranInsert";
                cmd.ExecuteNonQuery();

                // Guardar detalle de factura
                // procedimiento almacenado [DetalleVentaInsert]
                for (int i = 0; i < listaPresentacionArticulo.Count; i++)
                {
                    if (listaPresentacionArticulo[i].CodigoEAN != null)
                    {
                        paramIdAlbaran.Value = paramOutIdAlbaran.Value;
                        this.ValidarCliente(cliente, paramIdCliente);
                        paramNombreMarca.Value = listaPresentacionArticulo[i].Articulo.Marca.Nombre;
                        paramTitulo.Value = listaPresentacionArticulo[i].Nombre;
                        paramNombreUnidadVolumen.Value = listaPresentacionArticulo[i].UnidadVolumen.Nombre;
                        paramVlrVolumenLargo.Value = listaPresentacionArticulo[i].VlrUnidadVolumenLargo;
                        paramVlrVolumenAncho.Value = listaPresentacionArticulo[i].VlrUnidadVolumenAncho;
                        paramVlrVolumenProfundidad.Value = listaPresentacionArticulo[i].VlrUnidadVolumenProfundidad;
                        paramVlrContenidoVolumetrico.Value = listaPresentacionArticulo[i].VlrContenidoVolumetrico;
                        paramNombreUnidadMasa.Value = listaPresentacionArticulo[i].UnidadMasa.Nombre;
                        paramVlrUnidadMasa.Value = listaPresentacionArticulo[i].VlrUnidadMasa;
                        paramNombreUnidadLongitud.Value = listaPresentacionArticulo[i].UnidadLongitud.Nombre;
                        paramVlrUnidadLongitud.Value = listaPresentacionArticulo[i].VlrUnidadLongitud;
                        paramNombreTalla.Value = listaPresentacionArticulo[i].Talla.Nombre;
                        paramNombreColor.Value = listaPresentacionArticulo[i].Color.Nombre;
                        paramNombreSabor.Value = listaPresentacionArticulo[i].Sabor.Nombre;
                        paramPrecioVenta.Value = listaPresentacionArticulo[i].Precio;
                        paramCantidad.Value = listaPresentacionArticulo[i].Existencias;
                        paramCostoDelProducto.Value = listaPresentacionArticulo[i].CostoArticulo;
                        paramSubTotalVenta.Value = listaPresentacionArticulo[i].Existencias * listaPresentacionArticulo[i].Precio;
                        paramSubtotalCosto.Value = listaPresentacionArticulo[i].Existencias * listaPresentacionArticulo[i].CostoArticulo;
                        paramNombreCategoria.Value = listaPresentacionArticulo[i].Articulo.Categoria.Nombre;
                        paramCaminoSubCategorias.Value = string.Empty;
                        paramIdPresentacionArticulo.Value = listaPresentacionArticulo[i].IdPresentacionArticulo;
                        paramNombreUnidadPresentacion.Value = listaPresentacionArticulo[i].UnidadPresentacion.Nombre;
                        paramVlrUnidadPresentacion.Value = listaPresentacionArticulo[i].VlrUnidadPresentacion;

                        cmd.Parameters.Clear();

                        cmd.Parameters.Add(paramIdAlbaran);
                        cmd.Parameters.Add(paramIdCliente);
                        cmd.Parameters.Add(paramNombreMarca);
                        cmd.Parameters.Add(paramTitulo);
                        cmd.Parameters.Add(paramNombreUnidadVolumen);
                        cmd.Parameters.Add(paramVlrVolumenLargo);
                        cmd.Parameters.Add(paramVlrVolumenAncho);
                        cmd.Parameters.Add(paramVlrVolumenProfundidad);
                        cmd.Parameters.Add(paramVlrContenidoVolumetrico);
                        cmd.Parameters.Add(paramNombreUnidadMasa);
                        cmd.Parameters.Add(paramVlrUnidadMasa);
                        cmd.Parameters.Add(paramNombreUnidadLongitud);
                        cmd.Parameters.Add(paramVlrUnidadLongitud);
                        cmd.Parameters.Add(paramNombreTalla);
                        cmd.Parameters.Add(paramNombreColor);
                        cmd.Parameters.Add(paramNombreSabor);
                        cmd.Parameters.Add(paramPrecioVenta);
                        cmd.Parameters.Add(paramCantidad);
                        cmd.Parameters.Add(paramCostoDelProducto);
                        cmd.Parameters.Add(paramSubTotalVenta);
                        cmd.Parameters.Add(paramSubtotalCosto);
                        cmd.Parameters.Add(paramNombreCategoria);
                        cmd.Parameters.Add(paramCaminoSubCategorias);
                        cmd.Parameters.Add(paramIdPresentacionArticulo);
                        cmd.Parameters.Add(paramNombreUnidadPresentacion);
                        cmd.Parameters.Add(paramVlrUnidadPresentacion);

                        cmd.CommandText = "DetalleAlbaranInsert";
                        cmd.ExecuteNonQuery();
                    }
                }

                resultado.Mensaje = Mensajes.LinqToXml.LeerMensaje("0009");

                // Terminar transacción
                cmd.Transaction.Commit();
                cmd.Connection.Close();
            }
            catch (SqlException ex)
            {
                cmd.Transaction.Rollback();
                Logging.ErrorGeneral.Guardar(ex);
            }
            catch (Exception ex)
            {
                cmd.Transaction.Rollback();
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

            return resultado.RegistrosAfectados;
        }


        public ReadOnlyCollection<Entidades.OrdenesCompra> ListarEncabezadoOrdenCompraPorIdentificador(OpcionConsultaOrdenCompra opcionBusqueda, string filtroBusqueda)
        {
            List<Entidades.OrdenesCompra> ListaOrdenesCompra = new List<Entidades.OrdenesCompra>();
            System.Data.SqlClient.SqlParameter paramOpcionBusqueda = null;
            System.Data.SqlClient.SqlParameter paramfiltroBusqueda = null;
            System.Data.SqlClient.SqlParameter paramOutIdAlbaran = null;
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataReader datareader = null;
            System.Collections.ObjectModel.ReadOnlyCollection<Entidades.OrdenesCompra> listaReadOnlyOrdenesCompra = null;

            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "OrdenCompraEncabezadoPorIdentificadorSelect";

                if (OpcionConsultaOrdenCompra.NumeroOrdenCompra == opcionBusqueda)
                {
                    paramOpcionBusqueda = new System.Data.SqlClient.SqlParameter("@opcionBusqueda", System.Data.SqlDbType.VarChar);
                    paramOpcionBusqueda.Value = 0;
                    cmd.Parameters.Add(paramOpcionBusqueda);
                }
                if (OpcionConsultaOrdenCompra.NumeroIdentificacion == opcionBusqueda)
                {
                    paramOpcionBusqueda = new System.Data.SqlClient.SqlParameter("@opcionBusqueda", System.Data.SqlDbType.VarChar);
                    paramOpcionBusqueda.Value = 1;
                    cmd.Parameters.Add(paramOpcionBusqueda);
                }
                if (OpcionConsultaOrdenCompra.NombreCliente == opcionBusqueda)
                {
                    paramOpcionBusqueda = new System.Data.SqlClient.SqlParameter("@opcionBusqueda", System.Data.SqlDbType.VarChar);
                    paramOpcionBusqueda.Value = 2;
                    cmd.Parameters.Add(paramOpcionBusqueda);
                }

                paramfiltroBusqueda = new System.Data.SqlClient.SqlParameter("@filtroBusqueda", System.Data.SqlDbType.VarChar);
                paramfiltroBusqueda.Value = filtroBusqueda;
                cmd.Parameters.Add(paramfiltroBusqueda);

                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();
                datareader = cmd.ExecuteReader();

                while (datareader.Read())
                {
                    Entidades.OrdenesCompra dtoOrdenesCompra = new Entidades.OrdenesCompra();

                    dtoOrdenesCompra.NombreCliente = datareader.GetString(0);
                    dtoOrdenesCompra.ApellidoCliente = datareader.GetString(1);
                    dtoOrdenesCompra.DocumentoIdentificacion = datareader.GetInt32(2);
                    dtoOrdenesCompra.TelefonoClienteUno = datareader.GetString(3);
                    dtoOrdenesCompra.Fecha = datareader.GetDateTime(4);
                    dtoOrdenesCompra.EmailCliente = datareader.GetString(5);
                    dtoOrdenesCompra.TotalVenta = datareader.GetDouble(6);
                    dtoOrdenesCompra.IdAlbaran = datareader.GetInt32(7);                 

                    ListaOrdenesCompra.Add(dtoOrdenesCompra);
                }

                listaReadOnlyOrdenesCompra = new System.Collections.ObjectModel.ReadOnlyCollection<Entidades.OrdenesCompra>(ListaOrdenesCompra);                
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
            if (resultadoTransaccion.ValorAuxiliar != null)
            {
                listaReadOnlyOrdenesCompra[0].IdAlbaran = int.Parse(paramOutIdAlbaran.Value.ToString()); 
            }
            return listaReadOnlyOrdenesCompra;
        }


        public ReadOnlyCollection<Entidades.OrdenesCompraDetalle> ListarOrdenesCompraDetallePorIdentificador(int IdAlbaran)
        {
            List<Entidades.OrdenesCompraDetalle> ListaOrdenesCompra = new List<Entidades.OrdenesCompraDetalle>();
            System.Data.SqlClient.SqlParameter paramIdentificador = null;
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataReader datareader = null;
            System.Collections.ObjectModel.ReadOnlyCollection<Entidades.OrdenesCompraDetalle> listaReadOnlyOrdenesCompra = null;

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "OrdenesCompraDetallePorIdentificadorSelect";

                paramIdentificador = new System.Data.SqlClient.SqlParameter("@IdAlbaran", System.Data.SqlDbType.Int);                
                paramIdentificador.Value = IdAlbaran;
                cmd.Parameters.Add(paramIdentificador);


                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();
                datareader = cmd.ExecuteReader();

                while (datareader.Read())
                {
                    Entidades.OrdenesCompraDetalle dtoOrdenesCompra = new Entidades.OrdenesCompraDetalle();

                    dtoOrdenesCompra.NombreMarca = datareader.GetString(0);
                    dtoOrdenesCompra.Titulo = datareader.GetString(1);
                    dtoOrdenesCompra.NombreUnidadVolumen = datareader.GetString(2);
                    dtoOrdenesCompra.NombreUnidadMasa = datareader.GetString(3);
                    dtoOrdenesCompra.NombreUnidadLongitud = datareader.GetString(4);
                    dtoOrdenesCompra.NombreTalla = datareader.GetString(5);
                    dtoOrdenesCompra.NombreColor = datareader.GetString(6);
                    dtoOrdenesCompra.NombreSabor = datareader.GetString(7);
                    dtoOrdenesCompra.SubTotalVenta = datareader.GetDouble(8);
                    dtoOrdenesCompra.PrecioVenta = datareader.GetDouble(9);
                    dtoOrdenesCompra.Cantidad = datareader.GetInt32(10);
                    dtoOrdenesCompra.CostoDelProducto = datareader.GetDouble(11);
                    dtoOrdenesCompra.SubtotalCosto = datareader.GetDouble(12);
                    dtoOrdenesCompra.NombreCategoria = datareader.GetString(13);
                    dtoOrdenesCompra.NombreUnidadPresentacion = datareader.GetString(14);
                    dtoOrdenesCompra.IdPresentacionArticulo = datareader.GetInt32(15);
                    

                    ListaOrdenesCompra.Add(dtoOrdenesCompra);
                }

                listaReadOnlyOrdenesCompra = new System.Collections.ObjectModel.ReadOnlyCollection<Entidades.OrdenesCompraDetalle>(ListaOrdenesCompra);
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
            return listaReadOnlyOrdenesCompra;
        }


        private SqlParameter ValidarCliente(Cliente cliente, SqlParameter paramIdCliente)
        {
            if (cliente == null)
            {
                paramIdCliente.Value = 1;
            }
            else
            {
                paramIdCliente.Value = cliente.IdCliente;
            }
            return paramIdCliente;
        }

    }
}
