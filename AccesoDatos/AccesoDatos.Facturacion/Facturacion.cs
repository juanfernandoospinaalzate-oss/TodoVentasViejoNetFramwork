//-----------------------------------------------------------------------
// <copyright file="Facturacion.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace AccesoDatos.Facturacion
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using Entidades;

    public class Facturacion : Contratos.IFacturacion
    {
        public Entidades.PresentacionArticulo ConsultarPresentacionPorCodigoEAN(string CodigoEAN)
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataReader datareader = null;
            System.Data.SqlClient.SqlParameter paramCodigoEAN = null;
            Entidades.PresentacionArticulo presentacionArticulo = new Entidades.PresentacionArticulo();

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "PresentacionArticuloSelectPorCodigoEAN";

                paramCodigoEAN = new System.Data.SqlClient.SqlParameter("@CodigoEAN", System.Data.SqlDbType.NVarChar, 18);
                paramCodigoEAN.Value = CodigoEAN;
                cmd.Parameters.Add(paramCodigoEAN);

                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();
                datareader = cmd.ExecuteReader();

                while (datareader.Read())
                {
                    presentacionArticulo.IdPresentacionArticulo = datareader.GetInt32(0);
                    presentacionArticulo.Articulo.IdArticulo = datareader.GetInt32(1);
                    presentacionArticulo.CodigoEAN = datareader.GetString(2);
                    presentacionArticulo.Nombre = datareader.GetString(3);
                    presentacionArticulo.DescripcionBreve = datareader.GetString(4);
                    presentacionArticulo.Color.IdColor = datareader.GetInt32(5);
                    presentacionArticulo.Talla.IdTalla = datareader.GetInt32(6);
                    presentacionArticulo.Fecha = datareader.GetDateTime(13);

                    string RutaImagen = System.Configuration.ConfigurationManager.AppSettings["RutaImagenesArticulo"] + "\\" + presentacionArticulo.Fecha.ToString("yyyy-MM-dd") + "\\";
                    if (datareader.GetBoolean(7) == true)
                    {
                        presentacionArticulo.Imagen1 = System.IO.File.ReadAllBytes(RutaImagen + presentacionArticulo.IdPresentacionArticulo + "A.jpg");
                    }
                    else
                    {
                        presentacionArticulo.Imagen1 = null;
                    }

                    presentacionArticulo.VlrUnidadMasa = datareader.GetDouble(14);
                    presentacionArticulo.VlrUnidadVolumenAncho = datareader.GetDouble(15);
                    presentacionArticulo.VlrUnidadVolumenLargo = datareader.GetDouble(16);
                    presentacionArticulo.VlrUnidadVolumenProfundidad = datareader.GetDouble(17);
                    presentacionArticulo.VlrContenidoVolumetrico = datareader.GetDouble(18);
                    presentacionArticulo.VlrUnidadLongitud = datareader.GetDouble(19);
                    presentacionArticulo.UnidadMasa.IdUnidadMasa = datareader.GetInt32(20);
                    presentacionArticulo.UnidadVolumen.IdUnidadVolumen = datareader.GetInt32(21);
                    presentacionArticulo.UnidadLongitud.IdUnidadLongitud = datareader.GetInt32(22);
                    presentacionArticulo.EnLinea = datareader.GetBoolean(23);
                    presentacionArticulo.Activo = datareader.GetBoolean(24);
                    presentacionArticulo.Precio = datareader.GetDouble(25);
                    presentacionArticulo.Existencias = datareader.GetInt32(26);
                    presentacionArticulo.Sabor.IdSabor = datareader.GetInt32(27);
                    presentacionArticulo.CostoArticulo = datareader.GetDouble(28);
                }
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

            return presentacionArticulo;
        }

        public int GenerarFactura(List<PresentacionArticulo> listaPresentacionArticulo, Cliente cliente, MetodoDePago metodoDePago, EstadoVenta estadoDeLaVenta)
        {
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
            System.Data.SqlClient.SqlParameter paraCantidad = new System.Data.SqlClient.SqlParameter("@Cantidad", System.Data.SqlDbType.Int);
            System.Data.SqlClient.SqlParameter paramCostoDelProducto = new System.Data.SqlClient.SqlParameter("@CostoDelProducto", System.Data.SqlDbType.Float);
            System.Data.SqlClient.SqlParameter paramSubTotalVenta = new System.Data.SqlClient.SqlParameter("@SubTotalVenta", System.Data.SqlDbType.Float);
            System.Data.SqlClient.SqlParameter paramSubtotalCosto = new System.Data.SqlClient.SqlParameter("@SubtotalCosto", System.Data.SqlDbType.Float);
            System.Data.SqlClient.SqlParameter paramNombreCategoria = new System.Data.SqlClient.SqlParameter("@NombreCategoria", System.Data.SqlDbType.NVarChar, 60);
            System.Data.SqlClient.SqlParameter paramCaminoSubCategorias = new System.Data.SqlClient.SqlParameter("@CaminoSubCategorias", System.Data.SqlDbType.NVarChar, 250);
            System.Data.SqlClient.SqlParameter paramIdPresentacionArticulo = new System.Data.SqlClient.SqlParameter("@IdPresentacionArticulo", System.Data.SqlDbType.Int);
            System.Data.SqlClient.SqlParameter paramNombreUnidadPresentacion = new System.Data.SqlClient.SqlParameter("@NombreUnidadPresentacion", System.Data.SqlDbType.NVarChar, 40);
            System.Data.SqlClient.SqlParameter paramVlrUnidadPresentacion = new System.Data.SqlClient.SqlParameter("@VlrUnidadPresentacion", System.Data.SqlDbType.Float);

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();

                // Iniciar transacción
                cmd.Transaction = cmd.Connection.BeginTransaction("TransaccionGenerarFactura");

                // aumentar y recuperar un nuevo número de factura
                // Procedimiento almacenado [ContadoresGenerarNumeroFactura]
                cmd.CommandText = "ContadoresGenerarNumeroFactura";
                SqlDataReader datareader = cmd.ExecuteReader();
                if (datareader.Read())
                {
                    paramNroFactura.Value = datareader.GetInt32(0);
                    datareader.Close();
                }

                // Guardar Cabeza de factura
                // Procedimiento almacenado [VentaInsert]
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
                        paraCantidad.Value = listaPresentacionArticulo[i].Existencias;
                        paramCostoDelProducto.Value = listaPresentacionArticulo[i].CostoArticulo;
                        paramSubTotalVenta.Value = listaPresentacionArticulo[i].Existencias * listaPresentacionArticulo[i].Precio;
                        paramSubtotalCosto.Value = listaPresentacionArticulo[i].Existencias * listaPresentacionArticulo[i].CostoArticulo;
                        paramNombreCategoria.Value = listaPresentacionArticulo[i].Articulo.Categoria.Nombre;
                        paramCaminoSubCategorias.Value = string.Empty;
                        paramIdPresentacionArticulo.Value = listaPresentacionArticulo[i].IdPresentacionArticulo;
                        paramNombreUnidadPresentacion.Value = listaPresentacionArticulo[i].UnidadPresentacion.Nombre;
                        paramVlrUnidadPresentacion.Value = listaPresentacionArticulo[i].VlrUnidadPresentacion;

                        // Parametros de Detalle Factura
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
                        cmd.Parameters.Add(paraCantidad);
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
                        cmd.Parameters.AddWithValue("@Cantidad", paraCantidad.Value);
                        cmd.Parameters.AddWithValue("@IdPresentacionArticulo", paramIdPresentacionArticulo.Value);
                        cmd.ExecuteNonQuery();
                    }
                }

                // Terminar transacción
                cmd.Transaction.Commit();
                cmd.Connection.Close();
            }
            catch (SqlException ex)
            {
                cmd.Transaction.Rollback();
                Logging.ErrorGeneral.Guardar(ex);
                return 0;
            }
            catch (Exception ex)
            {
                cmd.Transaction.Rollback();
                Logging.ErrorGeneral.Guardar(ex);
                return 0;
            }
            finally
            {
                if (cmd.Connection.State == System.Data.ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }
                cmd.Dispose();
            }

            return int.Parse(paramNroFactura.Value.ToString());
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

        public int ConsultarExistenciasPresentacionArticulo(long IdPresentacionArticulo)
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataReader datareader = null;
            System.Data.SqlClient.SqlParameter paramIdPresentacionArticulo;
            Entidades.PresentacionArticulo presentacionArticulo = new Entidades.PresentacionArticulo();

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "PresentacionArticuloSelectExistencias";

                paramIdPresentacionArticulo = new System.Data.SqlClient.SqlParameter("@IdPresentacionArticulo", System.Data.SqlDbType.Int);
                paramIdPresentacionArticulo.Value = IdPresentacionArticulo;
                cmd.Parameters.Add(paramIdPresentacionArticulo);

                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();
                datareader = cmd.ExecuteReader();

                if (datareader.Read())
                {
                    return datareader.GetInt32(0);
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Logging.ErrorGeneral.Guardar(ex);
            }
            catch (Exception ex)
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

            return 0;
        }
    }
}