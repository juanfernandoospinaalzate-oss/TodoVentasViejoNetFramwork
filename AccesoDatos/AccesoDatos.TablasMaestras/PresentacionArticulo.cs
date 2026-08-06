// -----------------------------------------------------------------------
// <copyright file="PresentacionArticulo.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// ----------------------------------------------------------------------
namespace AccesoDatos.TablasMaestras
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Entidades;
    using Entidades.Enumeraciones;

    /// <summary>
    /// Formulario para la administración de presentación artículo en la base de datos por operaciones CRUD
    /// </summary>
    public class PresentacionArticulo : Contratos.IPresentacionArticulo
    {
        /// <summary>
        /// Inserta registros del formulario Presentación Artículo en la base de datos.
        /// </summary>
        /// <param name="presentacion">Objeto con los datos que se desean insertar</param>
        /// <param name="kardex">Objeto con los datos que se desean insertar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        [CLSCompliant(false)]
        public Entidades.ResultadoTransaccion Insertar(Entidades.PresentacionArticulo presentacion, Entidades.Kardex kardex)
        {
            if (presentacion == null)
            {
                Entidades.Mensaje mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(mensaje.Texto));
                throw new Entidades.Excepciones.ExceptionErrorTransaccion(mensaje.Texto);
            }

            System.Data.SqlClient.SqlParameter paramIdArticulo = null;
            System.Data.SqlClient.SqlParameter paramCodigoEAN = null;
            System.Data.SqlClient.SqlParameter paramNombre = null;
            System.Data.SqlClient.SqlParameter paramDescripcionBreve = null;
            System.Data.SqlClient.SqlParameter paramIdColor = null;
            System.Data.SqlClient.SqlParameter paramIdTalla = null;
            System.Data.SqlClient.SqlParameter paramImagen1 = null;
            System.Data.SqlClient.SqlParameter paramImagen2 = null;
            System.Data.SqlClient.SqlParameter paramImagen3 = null;
            System.Data.SqlClient.SqlParameter paramImagen4 = null;
            System.Data.SqlClient.SqlParameter paramImagen5 = null;
            System.Data.SqlClient.SqlParameter paramImagen6 = null;
            System.Data.SqlClient.SqlParameter paramVlrUnidadMasa = null;
            System.Data.SqlClient.SqlParameter paramVlrUnidadVolumenLargo = null;
            System.Data.SqlClient.SqlParameter paramVlrUnidadVolumenAncho = null;
            System.Data.SqlClient.SqlParameter paramVlrUnidadVolumenProfundidad = null;
            System.Data.SqlClient.SqlParameter paramVlrContenidoVolumetrico = null;
            System.Data.SqlClient.SqlParameter paramVlrUnidadLongitud = null;
            System.Data.SqlClient.SqlParameter paramIdUnidadMasa = null;
            System.Data.SqlClient.SqlParameter paramIdUnidadVolumen = null;
            System.Data.SqlClient.SqlParameter paramIdUnidadLongitud = null;
            System.Data.SqlClient.SqlParameter paramEnLinea = null;
            System.Data.SqlClient.SqlParameter paramActivo = null;
            System.Data.SqlClient.SqlParameter paramPrecio = null;
            System.Data.SqlClient.SqlParameter paramExistencias = null;
            System.Data.SqlClient.SqlParameter paramIdSabor = null;
            System.Data.SqlClient.SqlParameter paramCostoArticulo = null;
            System.Data.SqlClient.SqlParameter paramPreOrden = null;
            System.Data.SqlClient.SqlParameter paramIdUnidadPresentacion = null;
            System.Data.SqlClient.SqlParameter paramVlrUnidadPresentacion = null;
            System.Data.SqlClient.SqlParameter paramOutFecha = null;
            System.Data.SqlClient.SqlParameter paramOutIdPresentacionArticulo = null;
            System.Data.SqlClient.SqlParameter paramFechaProximoVencimiento = null;
            System.Data.SqlClient.SqlParameter paramUsarFechaProximoVencimiento = null;
            System.Data.SqlClient.SqlParameter paramUsarDescuento = null;
            System.Data.SqlClient.SqlParameter paramUsarPorcentajeDescuento = null;
            System.Data.SqlClient.SqlParameter paramValorPorcentajeDescuento = null;
            System.Data.SqlClient.SqlParameter paramUsarValorFijoDescuento = null;
            System.Data.SqlClient.SqlParameter paramValorFijoDescuento = null;
            System.Data.SqlClient.SqlParameter paramFechaInicioDescuento = null;
            System.Data.SqlClient.SqlParameter paramFechaFinalDescuento = null;

            System.Data.SqlClient.SqlParameter paramIdPresentacionArticulo = null;
            System.Data.SqlClient.SqlParameter paramFecha = null;
            System.Data.SqlClient.SqlParameter paramNombreKardex = null;
            System.Data.SqlClient.SqlParameter paramCantidadEntrada = null;
            System.Data.SqlClient.SqlParameter paramCantidadSalida = null;
            System.Data.SqlClient.SqlParameter paramPrecioUnitario = null;
            System.Data.SqlClient.SqlParameter paramCostoUnitario = null;
            System.Data.SqlClient.SqlParameter paramTotalExistencias = null;
            System.Data.SqlClient.SqlParameter paramPrecioTotal = null;
            System.Data.SqlClient.SqlParameter paramCostoTotal = null;
            System.Data.SqlClient.SqlParameter paramDetalle = null;

            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlCommand cmdKardex = null;
            Entidades.ResultadoTransaccion resultadoTransaccion = null;
            Entidades.ResultadoTransaccion resultadoTransaccionKardex = null;

            try
            {
                resultadoTransaccion = new Entidades.ResultadoTransaccion();
                resultadoTransaccionKardex = new Entidades.ResultadoTransaccion();

                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "PresentacionArticuloInsert";

                cmdKardex = new System.Data.SqlClient.SqlCommand();
                cmdKardex.CommandType = System.Data.CommandType.StoredProcedure;
                cmdKardex.CommandText = "KardexInsert";

                paramIdArticulo = new System.Data.SqlClient.SqlParameter("@IdArticulo", System.Data.SqlDbType.Int);
                paramIdArticulo.Value = presentacion.Articulo.IdArticulo;
                cmd.Parameters.Add(paramIdArticulo);

                paramCodigoEAN = new System.Data.SqlClient.SqlParameter("@CodigoEAN", System.Data.SqlDbType.NVarChar, 30);
                paramCodigoEAN.Value = presentacion.CodigoEAN;
                cmd.Parameters.Add(paramCodigoEAN);

                paramNombre = new System.Data.SqlClient.SqlParameter("@Nombre", System.Data.SqlDbType.NVarChar, 100);
                paramNombre.Value = presentacion.Nombre;
                cmd.Parameters.Add(paramNombre);

                paramDescripcionBreve = new System.Data.SqlClient.SqlParameter("@DescripcionBreve", System.Data.SqlDbType.NVarChar, 250);
                paramDescripcionBreve.Value = presentacion.DescripcionBreve;
                cmd.Parameters.Add(paramDescripcionBreve);

                paramIdColor = new System.Data.SqlClient.SqlParameter("@IdColor", System.Data.SqlDbType.Int);
                paramIdColor.Value = presentacion.Color.IdColor;
                cmd.Parameters.Add(paramIdColor);

                paramIdTalla = new System.Data.SqlClient.SqlParameter("@IdTalla", System.Data.SqlDbType.Int);
                paramIdTalla.Value = presentacion.Talla.IdTalla;
                cmd.Parameters.Add(paramIdTalla);

                paramImagen1 = new System.Data.SqlClient.SqlParameter("@Imagen1", System.Data.SqlDbType.Bit);

                if (presentacion.Imagen1 != null)
                {
                    paramImagen1.Value = true;
                }
                else
                {
                    paramImagen1.Value = false;
                }

                cmd.Parameters.Add(paramImagen1); 


                paramImagen2 = new System.Data.SqlClient.SqlParameter("@Imagen2", System.Data.SqlDbType.Bit);

                if (presentacion.Imagen2 != null)
                {
                    paramImagen2.Value = true;
                }
                else
                {
                    paramImagen2.Value = false;
                }
                
                cmd.Parameters.Add(paramImagen2);


                paramImagen3 = new System.Data.SqlClient.SqlParameter("@Imagen3", System.Data.SqlDbType.Bit);

                if (presentacion.Imagen3 != null)
                {
                    paramImagen3.Value = true;
                }
                else
                {
                    paramImagen3.Value = false;
                }

                cmd.Parameters.Add(paramImagen3);

                paramImagen4 = new System.Data.SqlClient.SqlParameter("@Imagen4", System.Data.SqlDbType.Bit);

                if (presentacion.Imagen4 != null)
                {
                    paramImagen4.Value = true;
                }
                else
                {
                    paramImagen4.Value = false;
                }

                cmd.Parameters.Add(paramImagen4);


                paramImagen5 = new System.Data.SqlClient.SqlParameter("@Imagen5", System.Data.SqlDbType.Bit);

                if (presentacion.Imagen5 != null)
                {
                    paramImagen5.Value = true;
                }
                else
                {
                    paramImagen5.Value = false;
                }

                cmd.Parameters.Add(paramImagen5);

                paramImagen6 = new System.Data.SqlClient.SqlParameter("@Imagen6", System.Data.SqlDbType.Bit);

                if (presentacion.Imagen6 != null)
                {
                    paramImagen6.Value = true;
                }
                else
                {
                    paramImagen6.Value = false;
                }

                cmd.Parameters.Add(paramImagen6);

                paramVlrUnidadMasa = new System.Data.SqlClient.SqlParameter("@VlrUnidadMasa", System.Data.SqlDbType.Float);
                paramVlrUnidadMasa.Value = presentacion.VlrUnidadMasa;
                cmd.Parameters.Add(paramVlrUnidadMasa);

                paramVlrUnidadVolumenLargo = new System.Data.SqlClient.SqlParameter("@VlrUnidadVolumenLargo", System.Data.SqlDbType.Float);
                paramVlrUnidadVolumenLargo.Value = presentacion.VlrUnidadVolumenLargo;
                cmd.Parameters.Add(paramVlrUnidadVolumenLargo);

                paramVlrUnidadVolumenAncho = new System.Data.SqlClient.SqlParameter("@VlrUnidadVolumenAncho", System.Data.SqlDbType.Float);
                paramVlrUnidadVolumenAncho.Value = presentacion.VlrUnidadVolumenAncho;
                cmd.Parameters.Add(paramVlrUnidadVolumenAncho);

                paramVlrUnidadVolumenProfundidad = new System.Data.SqlClient.SqlParameter("@VlrUnidadVolumenProfundidad", System.Data.SqlDbType.Float);
                paramVlrUnidadVolumenProfundidad.Value = presentacion.VlrUnidadVolumenProfundidad;
                cmd.Parameters.Add(paramVlrUnidadVolumenProfundidad);

                paramVlrContenidoVolumetrico = new System.Data.SqlClient.SqlParameter("@VlrContenidoVolumetrico", System.Data.SqlDbType.Float);
                paramVlrContenidoVolumetrico.Value = presentacion.VlrContenidoVolumetrico;
                cmd.Parameters.Add(paramVlrContenidoVolumetrico);

                paramVlrUnidadLongitud = new System.Data.SqlClient.SqlParameter("@VlrUnidadLongitud", System.Data.SqlDbType.Float);
                paramVlrUnidadLongitud.Value = presentacion.VlrUnidadLongitud;
                cmd.Parameters.Add(paramVlrUnidadLongitud);

                paramIdUnidadMasa = new System.Data.SqlClient.SqlParameter("@IdUnidadMasa", System.Data.SqlDbType.Int);
                paramIdUnidadMasa.Value = presentacion.UnidadMasa.IdUnidadMasa;
                cmd.Parameters.Add(paramIdUnidadMasa);

                paramIdUnidadLongitud = new System.Data.SqlClient.SqlParameter("@IdUnidadLongitud", System.Data.SqlDbType.Int);
                paramIdUnidadLongitud.Value = presentacion.UnidadLongitud.IdUnidadLongitud;
                cmd.Parameters.Add(paramIdUnidadLongitud);

                paramIdUnidadVolumen = new System.Data.SqlClient.SqlParameter("@IdUnidadVolumen", System.Data.SqlDbType.Int);
                paramIdUnidadVolumen.Value = presentacion.UnidadVolumen.IdUnidadVolumen;
                cmd.Parameters.Add(paramIdUnidadVolumen);

                paramEnLinea = new System.Data.SqlClient.SqlParameter("@EnLinea", System.Data.SqlDbType.Bit);
                paramEnLinea.Value = presentacion.EnLinea;
                cmd.Parameters.Add(paramEnLinea);

                paramActivo = new System.Data.SqlClient.SqlParameter("@Activo", System.Data.SqlDbType.Bit);
                paramActivo.Value = presentacion.Activo;
                cmd.Parameters.Add(paramActivo);

                paramPrecio = new System.Data.SqlClient.SqlParameter("@Precio", System.Data.SqlDbType.Int);
                paramPrecio.Value = presentacion.Precio;
                cmd.Parameters.Add(paramPrecio);

                paramExistencias = new System.Data.SqlClient.SqlParameter("@Existencias", System.Data.SqlDbType.Int);
                paramExistencias.Value = presentacion.Existencias;
                cmd.Parameters.Add(paramExistencias);

                paramIdSabor = new System.Data.SqlClient.SqlParameter("@IdSabor", System.Data.SqlDbType.Int);
                paramIdSabor.Value = presentacion.Sabor.IdSabor;
                cmd.Parameters.Add(paramIdSabor);

                paramCostoArticulo = new System.Data.SqlClient.SqlParameter("@CostoArticulo", System.Data.SqlDbType.Int);
                paramCostoArticulo.Value = presentacion.CostoArticulo;
                cmd.Parameters.Add(paramCostoArticulo);

                paramPreOrden = new System.Data.SqlClient.SqlParameter("@PreOrden", System.Data.SqlDbType.Int);
                paramPreOrden.Value = presentacion.PreOrden;
                cmd.Parameters.Add(paramPreOrden);

                paramIdUnidadPresentacion = new System.Data.SqlClient.SqlParameter("@IdUnidadPresentacion", System.Data.SqlDbType.Int);
                paramIdUnidadPresentacion.Value = presentacion.UnidadPresentacion.IdUnidadPresentacion;
                cmd.Parameters.Add(paramIdUnidadPresentacion);

                paramVlrUnidadPresentacion = new System.Data.SqlClient.SqlParameter("@VlrUnidadPresentacion", System.Data.SqlDbType.Float);
                paramVlrUnidadPresentacion.Value = presentacion.VlrUnidadPresentacion;
                cmd.Parameters.Add(paramVlrUnidadPresentacion);

                paramOutFecha = new System.Data.SqlClient.SqlParameter("@OutFecha", System.Data.SqlDbType.Date);
                paramOutFecha.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(paramOutFecha);

                paramOutIdPresentacionArticulo = new System.Data.SqlClient.SqlParameter("@OutIdPresentacionArticulo", System.Data.SqlDbType.Int);
                paramOutIdPresentacionArticulo.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(paramOutIdPresentacionArticulo);

                paramFechaProximoVencimiento = new System.Data.SqlClient.SqlParameter("@FechaProximoVencimiento", System.Data.SqlDbType.Date);
                paramFechaProximoVencimiento.Value = presentacion.FechaProximoVencimiento;
                cmd.Parameters.Add(paramFechaProximoVencimiento);

                paramUsarFechaProximoVencimiento = new System.Data.SqlClient.SqlParameter("@UsarFechaProximoVencimiento", System.Data.SqlDbType.Bit);
                paramUsarFechaProximoVencimiento.Value = presentacion.UsarFechaProximoVencimiento;
                cmd.Parameters.Add(paramUsarFechaProximoVencimiento);

                paramUsarDescuento = new System.Data.SqlClient.SqlParameter("@UsarDescuento", System.Data.SqlDbType.Bit);
                paramUsarDescuento.Value = paramUsarDescuento.Value = presentacion.UsarDescuento;
                cmd.Parameters.Add(paramUsarDescuento);

                paramUsarPorcentajeDescuento = new System.Data.SqlClient.SqlParameter("@UsarPorcentajeDescuento", System.Data.SqlDbType.Bit);
                paramUsarPorcentajeDescuento.Value = presentacion.UsarPorcentajeDescuento;
                cmd.Parameters.Add(paramUsarPorcentajeDescuento);

                paramValorPorcentajeDescuento = new System.Data.SqlClient.SqlParameter("@ValorPorcentajeDescuento", System.Data.SqlDbType.Float);
                paramValorPorcentajeDescuento.Value = presentacion.ValorPorcentajeDescuento;
                cmd.Parameters.Add(paramValorPorcentajeDescuento);

                paramUsarValorFijoDescuento = new System.Data.SqlClient.SqlParameter("@UsarValorFijoDescuento", System.Data.SqlDbType.Bit);
                paramUsarValorFijoDescuento.Value = presentacion.UsarValorFijoDescuento;
                cmd.Parameters.Add(paramUsarValorFijoDescuento);

                paramValorFijoDescuento = new System.Data.SqlClient.SqlParameter("@ValorFijoDescuento", System.Data.SqlDbType.Float);
                paramValorFijoDescuento.Value = presentacion.ValorFijoDescuento;
                cmd.Parameters.Add(paramValorFijoDescuento);

                paramFechaInicioDescuento = new System.Data.SqlClient.SqlParameter("@FechaInicioDescuento", System.Data.SqlDbType.Date);
                paramFechaInicioDescuento.Value = presentacion.FechaInicioDescuento;
                cmd.Parameters.Add(paramFechaInicioDescuento);

                paramFechaFinalDescuento = new System.Data.SqlClient.SqlParameter("@FechaFinalDescuento", System.Data.SqlDbType.Date);
                paramFechaFinalDescuento.Value = presentacion.FechaFinalDescuento;
                cmd.Parameters.Add(paramFechaFinalDescuento);

                // Los datos de este parámetro se llenan luego de obtner el autonumérico al insertar en la tabla de presentación de artículo
                paramIdPresentacionArticulo = new System.Data.SqlClient.SqlParameter("@IdPresentacionArticulo", System.Data.SqlDbType.Int);

                paramFecha = new System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime);
                paramFecha.Value = kardex.Fecha;
                cmdKardex.Parameters.Add(paramFecha);

                paramNombreKardex = new System.Data.SqlClient.SqlParameter("@Nombre", System.Data.SqlDbType.NVarChar, 100);
                paramNombreKardex.Value = kardex.Nombre;
                cmdKardex.Parameters.Add(paramNombreKardex);

                paramCantidadEntrada = new System.Data.SqlClient.SqlParameter("@CantidadEntrada", System.Data.SqlDbType.Int);
                paramCantidadEntrada.Value = kardex.CantidadEntrada;
                cmdKardex.Parameters.Add(paramCantidadEntrada);

                paramCantidadSalida = new System.Data.SqlClient.SqlParameter("@CantidadSalida", System.Data.SqlDbType.Int);
                paramCantidadSalida.Value = kardex.CantidadSalida;
                cmdKardex.Parameters.Add(paramCantidadSalida);

                paramPrecioUnitario = new System.Data.SqlClient.SqlParameter("@PrecioUnitario", System.Data.SqlDbType.Float);
                paramPrecioUnitario.Value = kardex.PrecioUnitario;
                cmdKardex.Parameters.Add(paramPrecioUnitario);

                paramCostoUnitario = new System.Data.SqlClient.SqlParameter("@CostoUnitario", System.Data.SqlDbType.Float);
                paramCostoUnitario.Value = kardex.CostoUnitario;
                cmdKardex.Parameters.Add(paramCostoUnitario);

                paramTotalExistencias = new System.Data.SqlClient.SqlParameter("@TotalExistencias", System.Data.SqlDbType.Int);
                paramTotalExistencias.Value = kardex.TotalExistencias;
                cmdKardex.Parameters.Add(paramTotalExistencias);

                paramPrecioTotal = new System.Data.SqlClient.SqlParameter("@PrecioTotal", System.Data.SqlDbType.Float);
                paramPrecioTotal.Value = kardex.PrecioTotal;
                cmdKardex.Parameters.Add(paramPrecioTotal);

                paramCostoTotal = new System.Data.SqlClient.SqlParameter("@CostoTotal", System.Data.SqlDbType.Float);
                paramCostoTotal.Value = kardex.CostoTotal;
                cmdKardex.Parameters.Add(paramCostoTotal);

                paramDetalle = new System.Data.SqlClient.SqlParameter("@Detalle", System.Data.SqlDbType.NVarChar, 100);
                paramDetalle.Value = kardex.Detalle;
                cmdKardex.Parameters.Add(paramDetalle);

                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmdKardex.Connection = cmd.Connection;
                cmd.Connection.Open();
                cmd.Transaction = cmd.Connection.BeginTransaction();
                cmdKardex.Transaction = cmd.Transaction;

                resultadoTransaccion.RegistrosAfectados = cmd.ExecuteNonQuery();
                kardex.IdPresentacionArticulo = int.Parse(paramOutIdPresentacionArticulo.Value.ToString());
                paramIdPresentacionArticulo.Value = kardex.IdPresentacionArticulo;
                cmdKardex.Parameters.Add(paramIdPresentacionArticulo);
                resultadoTransaccionKardex.RegistrosAfectados = cmdKardex.ExecuteNonQuery();
                resultadoTransaccion.RegistrosAfectados = resultadoTransaccion.RegistrosAfectados + resultadoTransaccionKardex.RegistrosAfectados;

                #if Pruebas
                    cmd.Transaction.Rollback();
                #else
                    if (resultadoTransaccion.RegistrosAfectados == 2)
                    {
                        cmd.Transaction.Commit();
                    }
                    else
                    {
                        cmd.Transaction.Rollback();
                        resultadoTransaccion.RegistrosAfectados = 0;
                    }
                #endif

                DateTime FechaOut = DateTime.Parse(paramOutFecha.Value.ToString());

                // Solo ejecutar fuera de Pruebas
                #if !Pruebas
                    this.SubirImagen(presentacion.Imagen1, paramOutIdPresentacionArticulo.Value.ToString(), 'A', FechaOut);
                    this.SubirImagen(presentacion.Imagen2, paramOutIdPresentacionArticulo.Value.ToString(), 'B', FechaOut);
                    this.SubirImagen(presentacion.Imagen3, paramOutIdPresentacionArticulo.Value.ToString(), 'C', FechaOut);
                    this.SubirImagen(presentacion.Imagen4, paramOutIdPresentacionArticulo.Value.ToString(), 'D', FechaOut);
                    this.SubirImagen(presentacion.Imagen5, paramOutIdPresentacionArticulo.Value.ToString(), 'E', FechaOut);
                    this.SubirImagen(presentacion.Imagen6, paramOutIdPresentacionArticulo.Value.ToString(), 'F', FechaOut);
                #endif

                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0009");
                resultadoTransaccion.ValorAuxiliar = paramOutIdPresentacionArticulo.Value;
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                resultadoTransaccion.Mensaje.Texto = ex.Message;
                Logging.ErrorGeneral.Guardar(ex);
                cmd.Transaction.Rollback();
                return resultadoTransaccion;
            }
            catch (Entidades.Excepciones.ExceptionErrorTransaccion ex)
            {
                resultadoTransaccion.Mensaje.Texto = ex.Message;
                Logging.ErrorGeneral.Guardar(ex);
                cmd.Transaction.Rollback();
                return resultadoTransaccion;
            }
            catch (Exception ex)
            {
                resultadoTransaccion.Mensaje.Texto = ex.Message;
                Logging.ErrorGeneral.Guardar(ex);
                cmd.Transaction.Rollback();
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

        /// <summary>
        /// Carga la imágen por un servicio web al sitio web.
        /// </summary>
        /// <param name="imagen"></param>
        /// <param name="nombreImagen"></param>
        /// <param name="letraImagen"></param>
        /// <param name="fechaOut"></param>
        /// <returns></returns>
        public bool SubirImagen(byte[] imagen, string nombreImagen, char letraImagen, DateTime fechaOut)
        {
            if (imagen == null)
            {
                return false;
            }

            System.IO.MemoryStream ms = new System.IO.MemoryStream(imagen);
            string rutaCarpeta = System.Configuration.ConfigurationManager.AppSettings["RutaImagenesArticulo"] + "\\" + fechaOut.ToString("yyyy-MM-dd");
            string rutaImagen = string.Empty;
            rutaImagen = rutaCarpeta + rutaImagen + "\\" + nombreImagen + letraImagen + ".jpg";

            if (System.IO.Directory.Exists(rutaCarpeta) == false)
            {
                System.IO.Directory.CreateDirectory(rutaCarpeta);
            }

            System.IO.FileStream fs = new System.IO.FileStream(rutaImagen, System.IO.FileMode.Create);
            ms.WriteTo(fs);
            ms.Close();
            fs.Close();
            return true;
        }

        /// <summary>
        /// Actualiza registros del formulario Presentación Artículo en la base de datos.
        /// </summary>
        /// <param name="presentacion">Objeto con los datos que se desean modificar</param>
        /// <param name="kardex">Objeto con los datos que se desean modificar</param>
        /// <returns></returns>
        public Entidades.ResultadoTransaccion Actualizar(Entidades.PresentacionArticulo presentacion, Entidades.Kardex kardex)
        {
            if (presentacion == null)
            {
                Entidades.Mensaje mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(mensaje.Texto));
                throw new Entidades.Excepciones.ExceptionErrorTransaccion(mensaje.Texto);
            }

            System.Data.SqlClient.SqlParameter paramIdArticulo = null;
            System.Data.SqlClient.SqlParameter paramNombre = null;
            System.Data.SqlClient.SqlParameter paramCodigoEAN = null;
            System.Data.SqlClient.SqlParameter paramDescripcionAnexada = null;
            System.Data.SqlClient.SqlParameter paramIdColor = null;
            System.Data.SqlClient.SqlParameter paramIdTalla = null;
            System.Data.SqlClient.SqlParameter paramImagen1 = null;
            System.Data.SqlClient.SqlParameter paramImagen2 = null;
            System.Data.SqlClient.SqlParameter paramImagen3 = null;
            System.Data.SqlClient.SqlParameter paramImagen4 = null;
            System.Data.SqlClient.SqlParameter paramImagen5 = null;
            System.Data.SqlClient.SqlParameter paramImagen6 = null;
            System.Data.SqlClient.SqlParameter paramVlrUnidadMasa = null;
            System.Data.SqlClient.SqlParameter paramVlrUnidadVolumenLargo = null;
            System.Data.SqlClient.SqlParameter paramVlrUnidadVolumenAncho = null;
            System.Data.SqlClient.SqlParameter paramVlrUnidadVolumenProfundidad = null;
            System.Data.SqlClient.SqlParameter paramVlrContenidoVolumetrico = null;
            System.Data.SqlClient.SqlParameter paramVlrUnidadLongitud = null;
            System.Data.SqlClient.SqlParameter paramIdUnidadMasa = null;
            System.Data.SqlClient.SqlParameter paramIdUnidadVolumen = null;
            System.Data.SqlClient.SqlParameter paramIdUnidadLongitud = null;
            System.Data.SqlClient.SqlParameter paramEnLinea = null;
            System.Data.SqlClient.SqlParameter paramActivo = null;
            System.Data.SqlClient.SqlParameter paramPrecio = null;
            System.Data.SqlClient.SqlParameter paramExistencias = null;
            System.Data.SqlClient.SqlParameter paramIdSabor = null;
            System.Data.SqlClient.SqlParameter paramCostoArticulo = null;
            System.Data.SqlClient.SqlParameter paramIdPresentacionArticulo = null;
            System.Data.SqlClient.SqlParameter paramPreOrden = null;
            System.Data.SqlClient.SqlParameter paramIdUnidadPresentacion  = null;
            System.Data.SqlClient.SqlParameter paramVlrUnidadPresentacion = null;
            System.Data.SqlClient.SqlParameter paramFechaProximoVencimiento = null;
            System.Data.SqlClient.SqlParameter paramUsarFechaProximoVencimiento = null;
            System.Data.SqlClient.SqlParameter paramUsarDescuento = null;
            System.Data.SqlClient.SqlParameter paramUsarPorcentajeDescuento = null;
            System.Data.SqlClient.SqlParameter paramValorPorcentajeDescuento = null;
            System.Data.SqlClient.SqlParameter paramUsarValorFijoDescuento = null;
            System.Data.SqlClient.SqlParameter paramValorFijoDescuento = null;
            System.Data.SqlClient.SqlParameter paramFechaInicioDescuento = null;
            System.Data.SqlClient.SqlParameter paramFechaFinalDescuento = null;

            System.Data.SqlClient.SqlParameter paramIdPresentacionArticuloKardex = null;
            System.Data.SqlClient.SqlParameter paramFecha = null;
            System.Data.SqlClient.SqlParameter paramNombreKardex = null;
            System.Data.SqlClient.SqlParameter paramCantidadEntrada = null;
            System.Data.SqlClient.SqlParameter paramCantidadSalida = null;
            System.Data.SqlClient.SqlParameter paramPrecioUnitario = null;
            System.Data.SqlClient.SqlParameter paramCostoUnitario = null;
            System.Data.SqlClient.SqlParameter paramTotalExistencias = null;
            System.Data.SqlClient.SqlParameter paramPrecioTotal = null;
            System.Data.SqlClient.SqlParameter paramCostoTotal = null;
            System.Data.SqlClient.SqlParameter paramDetalle = null;

            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlCommand cmdKardex = null;
            Entidades.ResultadoTransaccion resultadoTransaccion = null;
            Entidades.ResultadoTransaccion resultadoTransaccionKardex = null;

            try
            {
                resultadoTransaccion = new Entidades.ResultadoTransaccion();
                resultadoTransaccionKardex = new Entidades.ResultadoTransaccion();

                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "PresentacionArticuloUpdate";

                cmdKardex = new System.Data.SqlClient.SqlCommand();
                cmdKardex.CommandType = System.Data.CommandType.StoredProcedure;
                cmdKardex.CommandText = "KardexInsert";

                paramIdPresentacionArticulo = new System.Data.SqlClient.SqlParameter("@IdPresentacionArticulo", System.Data.SqlDbType.Int);
                paramIdPresentacionArticulo.Value = presentacion.IdPresentacionArticulo;
                cmd.Parameters.Add(paramIdPresentacionArticulo);

                paramIdArticulo = new System.Data.SqlClient.SqlParameter("@IdArticulo", System.Data.SqlDbType.Int);
                paramIdArticulo.Value = presentacion.Articulo.IdArticulo;
                cmd.Parameters.Add(paramIdArticulo);

                paramCodigoEAN = new System.Data.SqlClient.SqlParameter("@CodigoEAN", System.Data.SqlDbType.NVarChar, 30);
                paramCodigoEAN.Value = presentacion.CodigoEAN;
                cmd.Parameters.Add(paramCodigoEAN);

                paramNombre = new System.Data.SqlClient.SqlParameter("@Nombre", System.Data.SqlDbType.NVarChar, 100);
                paramNombre.Value = presentacion.Nombre;
                cmd.Parameters.Add(paramNombre);

                paramDescripcionAnexada = new System.Data.SqlClient.SqlParameter("@DescripcionBreve", System.Data.SqlDbType.NVarChar, 250);
                paramDescripcionAnexada.Value = presentacion.DescripcionBreve;
                cmd.Parameters.Add(paramDescripcionAnexada);

                paramIdColor = new System.Data.SqlClient.SqlParameter("@IdColor", System.Data.SqlDbType.Int);
                paramIdColor.Value = presentacion.Color.IdColor;
                cmd.Parameters.Add(paramIdColor);

                paramIdTalla = new System.Data.SqlClient.SqlParameter("@IdTalla", System.Data.SqlDbType.Int);
                paramIdTalla.Value = presentacion.Talla.IdTalla;
                cmd.Parameters.Add(paramIdTalla);

                paramImagen1 = new System.Data.SqlClient.SqlParameter("@Imagen1", System.Data.SqlDbType.Bit);

                if (presentacion.Imagen1 != null)
                {

                    paramImagen1.Value = true;

                }
                else
                {
                    paramImagen1.Value = false;
                }

                cmd.Parameters.Add(paramImagen1);


                paramImagen2 = new System.Data.SqlClient.SqlParameter("@Imagen2", System.Data.SqlDbType.Bit);

                if (presentacion.Imagen2 != null)
                {
                    paramImagen2.Value = true;
                }
                else
                {
                    paramImagen2.Value = false;
                }

                cmd.Parameters.Add(paramImagen2);


                paramImagen3 = new System.Data.SqlClient.SqlParameter("@Imagen3", System.Data.SqlDbType.Bit);

                if (presentacion.Imagen3 != null)
                {
                    paramImagen3.Value = true;
                }
                else
                {
                    paramImagen3.Value = false;
                }

                cmd.Parameters.Add(paramImagen3);


                paramImagen4 = new System.Data.SqlClient.SqlParameter("@Imagen4", System.Data.SqlDbType.Bit);

                if (presentacion.Imagen4 != null)
                {
                    paramImagen4.Value = true;
                }
                else
                {
                    paramImagen4.Value = false;
                }

                cmd.Parameters.Add(paramImagen4);


                paramImagen5 = new System.Data.SqlClient.SqlParameter("@Imagen5", System.Data.SqlDbType.Bit);

                if (presentacion.Imagen5 != null)
                {
                    paramImagen5.Value = true;
                }
                else
                {
                    paramImagen5.Value = false;
                }

                cmd.Parameters.Add(paramImagen5);


                paramImagen6 = new System.Data.SqlClient.SqlParameter("@Imagen6", System.Data.SqlDbType.Bit);

                if (presentacion.Imagen6 != null)
                {
                    paramImagen6.Value = true;
                }
                else
                {
                    paramImagen6.Value = false;
                }

                cmd.Parameters.Add(paramImagen6);

                paramVlrUnidadMasa = new System.Data.SqlClient.SqlParameter("@VlrUnidadMasa", System.Data.SqlDbType.Float);
                paramVlrUnidadMasa.Value = presentacion.VlrUnidadMasa;
                cmd.Parameters.Add(paramVlrUnidadMasa);

                paramVlrUnidadVolumenLargo = new System.Data.SqlClient.SqlParameter("@VlrUnidadVolumenLargo", System.Data.SqlDbType.Float);
                paramVlrUnidadVolumenLargo.Value = presentacion.VlrUnidadVolumenLargo;
                cmd.Parameters.Add(paramVlrUnidadVolumenLargo);

                paramVlrUnidadVolumenAncho = new System.Data.SqlClient.SqlParameter("@VlrUnidadVolumenAncho", System.Data.SqlDbType.Float);
                paramVlrUnidadVolumenAncho.Value = presentacion.VlrUnidadVolumenAncho;
                cmd.Parameters.Add(paramVlrUnidadVolumenAncho);

                paramVlrUnidadVolumenProfundidad = new System.Data.SqlClient.SqlParameter("@VlrUnidadVolumenProfundidad", System.Data.SqlDbType.Float);
                paramVlrUnidadVolumenProfundidad.Value = presentacion.VlrUnidadVolumenProfundidad;
                cmd.Parameters.Add(paramVlrUnidadVolumenProfundidad);

                paramVlrContenidoVolumetrico = new System.Data.SqlClient.SqlParameter("@VlrContenidoVolumetrico", System.Data.SqlDbType.Float);
                paramVlrContenidoVolumetrico.Value = presentacion.VlrContenidoVolumetrico;
                cmd.Parameters.Add(paramVlrContenidoVolumetrico);

                paramVlrUnidadLongitud = new System.Data.SqlClient.SqlParameter("@VlrUnidadLongitud", System.Data.SqlDbType.Float);
                paramVlrUnidadLongitud.Value = presentacion.VlrUnidadLongitud;
                cmd.Parameters.Add(paramVlrUnidadLongitud);

                paramIdUnidadMasa = new System.Data.SqlClient.SqlParameter("@IdUnidadMasa", System.Data.SqlDbType.Int);
                paramIdUnidadMasa.Value = presentacion.UnidadMasa.IdUnidadMasa;
                cmd.Parameters.Add(paramIdUnidadMasa);

                paramIdUnidadLongitud = new System.Data.SqlClient.SqlParameter("@IdUnidadLongitud", System.Data.SqlDbType.Int);
                paramIdUnidadLongitud.Value = presentacion.UnidadLongitud.IdUnidadLongitud;
                cmd.Parameters.Add(paramIdUnidadLongitud);

                paramIdUnidadVolumen = new System.Data.SqlClient.SqlParameter("@IdUnidadVolumen", System.Data.SqlDbType.Int);
                paramIdUnidadVolumen.Value = presentacion.UnidadVolumen.IdUnidadVolumen;
                cmd.Parameters.Add(paramIdUnidadVolumen);

                paramEnLinea = new System.Data.SqlClient.SqlParameter("@EnLinea", System.Data.SqlDbType.Bit);
                paramEnLinea.Value = presentacion.EnLinea;
                cmd.Parameters.Add(paramEnLinea);

                paramActivo = new System.Data.SqlClient.SqlParameter("@Activo", System.Data.SqlDbType.Bit);
                paramActivo.Value = presentacion.Activo;
                cmd.Parameters.Add(paramActivo);

                paramPrecio = new System.Data.SqlClient.SqlParameter("@Precio", System.Data.SqlDbType.Float);
                paramPrecio.Value = presentacion.Precio;
                cmd.Parameters.Add(paramPrecio);

                paramExistencias = new System.Data.SqlClient.SqlParameter("@Existencias", System.Data.SqlDbType.Int);
                paramExistencias.Value = presentacion.Existencias;
                cmd.Parameters.Add(paramExistencias);

                paramIdSabor = new System.Data.SqlClient.SqlParameter("@IdSabor", System.Data.SqlDbType.Int);
                paramIdSabor.Value = presentacion.Sabor.IdSabor;
                cmd.Parameters.Add(paramIdSabor);

                paramCostoArticulo = new System.Data.SqlClient.SqlParameter("@CostoArticulo", System.Data.SqlDbType.Float);
                paramCostoArticulo.Value = presentacion.CostoArticulo;
                cmd.Parameters.Add(paramCostoArticulo);

                paramPreOrden = new System.Data.SqlClient.SqlParameter("@PreOrden", System.Data.SqlDbType.Bit);
                paramPreOrden.Value = presentacion.PreOrden;
                cmd.Parameters.Add(paramPreOrden);

                paramIdUnidadPresentacion = new System.Data.SqlClient.SqlParameter("@IdUnidadPresentacion", System.Data.SqlDbType.Int);
                paramIdUnidadPresentacion.Value = presentacion.UnidadPresentacion.IdUnidadPresentacion;
                cmd.Parameters.Add(paramIdUnidadPresentacion);

                paramVlrUnidadPresentacion = new System.Data.SqlClient.SqlParameter("@VlrUnidadPresentacion", System.Data.SqlDbType.Float);
                paramVlrUnidadPresentacion.Value = presentacion.VlrUnidadPresentacion;
                cmd.Parameters.Add(paramVlrUnidadPresentacion);

                paramFechaProximoVencimiento = new System.Data.SqlClient.SqlParameter("@FechaProximoVencimiento", System.Data.SqlDbType.Date);
                paramFechaProximoVencimiento.Value = presentacion.FechaProximoVencimiento;
                cmd.Parameters.Add(paramFechaProximoVencimiento);

                paramUsarFechaProximoVencimiento = new System.Data.SqlClient.SqlParameter("@UsarFechaProximoVencimiento", System.Data.SqlDbType.Bit);
                paramUsarFechaProximoVencimiento.Value = presentacion.UsarFechaProximoVencimiento;
                cmd.Parameters.Add(paramUsarFechaProximoVencimiento);

                paramUsarDescuento = new System.Data.SqlClient.SqlParameter("@UsarDescuento", System.Data.SqlDbType.Bit);
                paramUsarDescuento.Value = paramUsarDescuento.Value = presentacion.UsarDescuento;
                cmd.Parameters.Add(paramUsarDescuento);

                paramUsarPorcentajeDescuento = new System.Data.SqlClient.SqlParameter("@UsarPorcentajeDescuento", System.Data.SqlDbType.Bit);
                paramUsarPorcentajeDescuento.Value = presentacion.UsarPorcentajeDescuento;
                cmd.Parameters.Add(paramUsarPorcentajeDescuento);

                paramValorPorcentajeDescuento = new System.Data.SqlClient.SqlParameter("@ValorPorcentajeDescuento", System.Data.SqlDbType.Float);
                paramValorPorcentajeDescuento.Value = presentacion.ValorPorcentajeDescuento;
                cmd.Parameters.Add(paramValorPorcentajeDescuento);

                paramUsarValorFijoDescuento = new System.Data.SqlClient.SqlParameter("@UsarValorFijoDescuento", System.Data.SqlDbType.Bit);
                paramUsarValorFijoDescuento.Value = presentacion.UsarValorFijoDescuento;
                cmd.Parameters.Add(paramUsarValorFijoDescuento);

                paramValorFijoDescuento = new System.Data.SqlClient.SqlParameter("@ValorFijoDescuento", System.Data.SqlDbType.Float);
                paramValorFijoDescuento.Value = presentacion.ValorFijoDescuento;
                cmd.Parameters.Add(paramValorFijoDescuento);

                paramFechaInicioDescuento = new System.Data.SqlClient.SqlParameter("@FechaInicioDescuento", System.Data.SqlDbType.Date);
                paramFechaInicioDescuento.Value = presentacion.FechaInicioDescuento;
                cmd.Parameters.Add(paramFechaInicioDescuento);

                paramFechaFinalDescuento = new System.Data.SqlClient.SqlParameter("@FechaFinalDescuento", System.Data.SqlDbType.Date);
                paramFechaFinalDescuento.Value = presentacion.FechaFinalDescuento;
                cmd.Parameters.Add(paramFechaFinalDescuento);

                paramIdPresentacionArticuloKardex = new System.Data.SqlClient.SqlParameter("@IdPresentacionArticulo", System.Data.SqlDbType.Int);
                paramIdPresentacionArticuloKardex.Value = kardex.IdPresentacionArticulo;
                cmdKardex.Parameters.Add(paramIdPresentacionArticuloKardex);

                paramFecha = new System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime);
                paramFecha.Value = kardex.Fecha;
                cmdKardex.Parameters.Add(paramFecha);

                paramNombreKardex = new System.Data.SqlClient.SqlParameter("@Nombre", System.Data.SqlDbType.NVarChar, 100);
                paramNombreKardex.Value = kardex.Nombre;
                cmdKardex.Parameters.Add(paramNombreKardex);

                paramCantidadEntrada = new System.Data.SqlClient.SqlParameter("@CantidadEntrada", System.Data.SqlDbType.Int);
                paramCantidadEntrada.Value = kardex.CantidadEntrada;
                cmdKardex.Parameters.Add(paramCantidadEntrada);

                paramCantidadSalida = new System.Data.SqlClient.SqlParameter("@CantidadSalida", System.Data.SqlDbType.Int);
                paramCantidadSalida.Value = kardex.CantidadSalida;
                cmdKardex.Parameters.Add(paramCantidadSalida);

                paramPrecioUnitario = new System.Data.SqlClient.SqlParameter("@PrecioUnitario", System.Data.SqlDbType.Float);
                paramPrecioUnitario.Value = kardex.PrecioUnitario;
                cmdKardex.Parameters.Add(paramPrecioUnitario);

                paramCostoUnitario = new System.Data.SqlClient.SqlParameter("@CostoUnitario", System.Data.SqlDbType.Float);
                paramCostoUnitario.Value = kardex.CostoUnitario;
                cmdKardex.Parameters.Add(paramCostoUnitario);

                paramTotalExistencias = new System.Data.SqlClient.SqlParameter("@TotalExistencias", System.Data.SqlDbType.Int);
                paramTotalExistencias.Value = kardex.TotalExistencias;
                cmdKardex.Parameters.Add(paramTotalExistencias);

                paramPrecioTotal = new System.Data.SqlClient.SqlParameter("@PrecioTotal", System.Data.SqlDbType.Float);
                paramPrecioTotal.Value = kardex.PrecioTotal;
                cmdKardex.Parameters.Add(paramPrecioTotal);

                paramCostoTotal = new System.Data.SqlClient.SqlParameter("@CostoTotal", System.Data.SqlDbType.Float);
                paramCostoTotal.Value = kardex.CostoTotal;
                cmdKardex.Parameters.Add(paramCostoTotal);

                paramDetalle = new System.Data.SqlClient.SqlParameter("@Detalle", System.Data.SqlDbType.NVarChar, 100);
                paramDetalle.Value = kardex.Detalle;
                cmdKardex.Parameters.Add(paramDetalle);

                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmdKardex.Connection = cmd.Connection;
                cmd.Connection.Open();
                cmd.Transaction = cmd.Connection.BeginTransaction();
                cmdKardex.Transaction = cmd.Transaction;

                resultadoTransaccion.RegistrosAfectados = cmd.ExecuteNonQuery();
                resultadoTransaccionKardex.RegistrosAfectados = cmdKardex.ExecuteNonQuery();
                resultadoTransaccion.RegistrosAfectados = resultadoTransaccion.RegistrosAfectados + resultadoTransaccionKardex.RegistrosAfectados;

                #if Pruebas
                    cmd.Transaction.Rollback();
                #else
                    if (resultadoTransaccion.RegistrosAfectados == 2)
                    {
                        cmd.Transaction.Commit();
                    }
                    else
                    {
                        cmd.Transaction.Rollback();
                        resultadoTransaccion.RegistrosAfectados = 0;
                    }
                #endif

                #if !Pruebas
                    this.SubirImagen(presentacion.Imagen1, paramIdPresentacionArticulo.Value.ToString(), 'A', presentacion.Fecha);
                    this.SubirImagen(presentacion.Imagen2, paramIdPresentacionArticulo.Value.ToString(), 'B', presentacion.Fecha);
                    this.SubirImagen(presentacion.Imagen3, paramIdPresentacionArticulo.Value.ToString(), 'C', presentacion.Fecha);
                    this.SubirImagen(presentacion.Imagen4, paramIdPresentacionArticulo.Value.ToString(), 'D', presentacion.Fecha);
                    this.SubirImagen(presentacion.Imagen5, paramIdPresentacionArticulo.Value.ToString(), 'E', presentacion.Fecha);
                    this.SubirImagen(presentacion.Imagen6, paramIdPresentacionArticulo.Value.ToString(), 'F', presentacion.Fecha);
                #endif

                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0009");
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                cmd.Transaction.Rollback();
                Logging.ErrorGeneral.Guardar(ex);
                return resultadoTransaccion;
            }
            catch (Entidades.Excepciones.ExceptionErrorTransaccion)
            {
                cmd.Transaction.Rollback();
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

        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.PresentacionArticulo> Listar(int idArticulo)
        {
            List<Entidades.PresentacionArticulo> presentacion = null;
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataReader datareader = null;
            System.Collections.ObjectModel.ReadOnlyCollection<Entidades.PresentacionArticulo> listaReadOnlyPresentacionArticulos = null;
            Entidades.ResultadoTransaccion resultado = null;
            System.Data.SqlClient.SqlParameter paramIdArticulo = null;
            
            try
            {
                presentacion = new List<Entidades.PresentacionArticulo>();
                resultado = new Entidades.ResultadoTransaccion();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "PresentacionArticuloSelectPorIdArticulo";

                paramIdArticulo = new System.Data.SqlClient.SqlParameter("@IdArticulo", System.Data.SqlDbType.Int);
                paramIdArticulo.Value = idArticulo;
                cmd.Parameters.Add(paramIdArticulo);

                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();
                datareader = cmd.ExecuteReader();

                while (datareader.Read())
                {
                    Entidades.PresentacionArticulo presentacionArticulo = new Entidades.PresentacionArticulo();

                    presentacionArticulo.IdPresentacionArticulo = datareader.GetInt32(0);
                    presentacionArticulo.Articulo.IdArticulo = datareader.GetInt32(1);
                    presentacionArticulo.CodigoEAN = datareader.GetString(2);
                    presentacionArticulo.Nombre = datareader.GetString(3);
                    presentacionArticulo.DescripcionBreve = datareader.GetString(4);
                    presentacionArticulo.Color.IdColor = datareader.GetInt32(5);
                    presentacionArticulo.Color.Codigo = datareader.GetString(6);
                    presentacionArticulo.Color.Nombre = datareader.GetString(7);
                    presentacionArticulo.Talla.IdTalla = datareader.GetInt32(8);

                    // La fecha se lee antes de cargar las imágenes para no generar bug
                    presentacionArticulo.Fecha = datareader.GetDateTime(15);

                    string RutaImagen = System.Configuration.ConfigurationManager.AppSettings["RutaImagenesArticulo"] + "\\" + presentacionArticulo.Fecha.ToString("yyyy-MM-dd") + "\\";
                    if (datareader.GetBoolean(9) == true)
                    {
                        presentacionArticulo.Imagen1 = System.IO.File.ReadAllBytes(RutaImagen + presentacionArticulo.IdPresentacionArticulo + "A.jpg");
                    }
                    else
                    {
                        presentacionArticulo.Imagen1 = null;
                    }

                    if (datareader.GetBoolean(10) == true)
                    {
                        presentacionArticulo.Imagen2 = System.IO.File.ReadAllBytes(RutaImagen + presentacionArticulo.IdPresentacionArticulo + "B.jpg");
                    }
                    else
                    {
                        presentacionArticulo.Imagen2 = null;
                    }

                    if (datareader.GetBoolean(11) == true)
                    {
                        presentacionArticulo.Imagen3 = System.IO.File.ReadAllBytes(RutaImagen + presentacionArticulo.IdPresentacionArticulo + "C.jpg");
                    }
                    else
                    {
                        presentacionArticulo.Imagen3 = null;
                    }

                    if (datareader.GetBoolean(12) == true)
                    {
                        presentacionArticulo.Imagen4 = System.IO.File.ReadAllBytes(RutaImagen + presentacionArticulo.IdPresentacionArticulo + "D.jpg");
                    }
                    else
                    {
                        presentacionArticulo.Imagen4 = null;
                    }

                    if (datareader.GetBoolean(13) == true)
                    {
                        presentacionArticulo.Imagen5 = System.IO.File.ReadAllBytes(RutaImagen + presentacionArticulo.IdPresentacionArticulo + "E.jpg");
                    }
                    else
                    {
                        presentacionArticulo.Imagen5 = null;
                    }

                    if (datareader.GetBoolean(14) == true)
                    {
                        presentacionArticulo.Imagen6 = System.IO.File.ReadAllBytes(RutaImagen + presentacionArticulo.IdPresentacionArticulo + "F.jpg");
                    }
                    else
                    {
                        presentacionArticulo.Imagen6 = null;
                    }

                    presentacionArticulo.VlrUnidadMasa = datareader.GetDouble(16);
                    presentacionArticulo.VlrUnidadVolumenAncho = datareader.GetDouble(17);
                    presentacionArticulo.VlrUnidadVolumenLargo = datareader.GetDouble(18);
                    presentacionArticulo.VlrUnidadVolumenProfundidad = datareader.GetDouble(19);
                    presentacionArticulo.VlrContenidoVolumetrico = datareader.GetDouble(20);
                    presentacionArticulo.VlrUnidadLongitud = datareader.GetDouble(21);
                    presentacionArticulo.UnidadMasa.IdUnidadMasa = datareader.GetInt32(22);
                    presentacionArticulo.UnidadVolumen.IdUnidadVolumen = datareader.GetInt32(23);
                    presentacionArticulo.UnidadLongitud.IdUnidadLongitud = datareader.GetInt32(24);
                    presentacionArticulo.EnLinea = datareader.GetBoolean(25);
                    presentacionArticulo.Activo = datareader.GetBoolean(26);
                    presentacionArticulo.Precio = datareader.GetDouble(27);
                    presentacionArticulo.Existencias = datareader.GetInt32(28);
                    presentacionArticulo.Sabor.IdSabor = datareader.GetInt32(29);
                    presentacionArticulo.CostoArticulo = datareader.GetDouble(30);
                    presentacionArticulo.PreOrden = datareader.GetBoolean(31);
                    presentacionArticulo.UnidadPresentacion.IdUnidadPresentacion = datareader.GetInt32(32);
                    presentacionArticulo.VlrUnidadPresentacion = datareader.GetDouble(33);
                    presentacionArticulo.FechaProximoVencimiento = datareader.GetDateTime(34);
                    presentacionArticulo.UsarFechaProximoVencimiento = datareader.GetBoolean(35);
                    presentacionArticulo.UsarDescuento = datareader.GetBoolean(36);
                    presentacionArticulo.UsarPorcentajeDescuento = datareader.GetBoolean(37);
                    presentacionArticulo.ValorPorcentajeDescuento = datareader.GetDouble(38);
                    presentacionArticulo.UsarValorFijoDescuento = datareader.GetBoolean(39);
                    presentacionArticulo.ValorFijoDescuento = datareader.GetDouble(40);
                    presentacionArticulo.FechaInicioDescuento = datareader.GetDateTime(41);
                    presentacionArticulo.FechaFinalDescuento = datareader.GetDateTime(42);

                    presentacion.Add(presentacionArticulo);

                    #if Pruebas
                        break;
                    #endif
                }

                listaReadOnlyPresentacionArticulos = new System.Collections.ObjectModel.ReadOnlyCollection<Entidades.PresentacionArticulo>(presentacion);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Logging.ErrorGeneral.Guardar(ex);
            }
            catch (Entidades.Excepciones.ExceptionErrorTransaccion ex)
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

            return listaReadOnlyPresentacionArticulos;
        }

        /// <summary>
        /// Elimina el registro de la presentación de Artículo, incluyendo las imágenes
        /// </summary>
        /// <param name="idPresentacionArticulo"></param>
        /// <returns> Cantidad de registros afectados y mensaje informativo</returns>
        public Entidades.ResultadoTransaccion Eliminar(int idPresentacionArticulo)
        {
            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlParameter paramIdArticulo = null;
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "PresentacionArticuloDelete";

                paramIdArticulo = new System.Data.SqlClient.SqlParameter("@IdPresentacionArticulo", System.Data.SqlDbType.Int);
                paramIdArticulo.Value = idPresentacionArticulo;
                cmd.Parameters.Add(paramIdArticulo);

                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();
                resultadoTransaccion.RegistrosAfectados = cmd.ExecuteNonQuery();

                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0006");
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Logging.ErrorGeneral.Guardar(ex);
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

        public Entidades.ResultadoTransaccion ActivarInactivarPorArticulo(int idArticulo, Entidades.Enumeraciones.Estado estado)
        {
            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlParameter paramIdArticulo = null;
            System.Data.SqlClient.SqlParameter paramEstado = null;
            Entidades.ResultadoTransaccion resultado = new Entidades.ResultadoTransaccion();
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "PresentacionArticuloUpdateEstado";

                paramIdArticulo = new System.Data.SqlClient.SqlParameter("@idArticulo", System.Data.SqlDbType.Int);
                paramIdArticulo.Value = idArticulo;
                cmd.Parameters.Add(paramIdArticulo);

                paramEstado = new System.Data.SqlClient.SqlParameter("@Estado", System.Data.SqlDbType.Bit);
                if (estado == Estado.Habilitado)
                {
                    paramEstado.Value = 1;
                }
                else
                {
                    paramEstado.Value = 0;
                }
                
                cmd.Parameters.Add(paramEstado);

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

        /// <summary>
        /// Verifica si hay ventas relacionadas
        /// </summary>
        /// <param name="idPresentacionArticulo"></param>
        /// <returns>True: Si hay Ventas relacionadas, False: No hay Ventas relacionadas</returns>
        public bool VerificarVentaArticulo(int idPresentacionArticulo)
        {
            if (idPresentacionArticulo == 0)
            {
                Entidades.Mensaje mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(mensaje.Texto));
                throw new Entidades.Excepciones.ExceptionErrorTransaccion(mensaje.Texto);
            }

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlParameter paramIdPresentacionArticulo = null;
            System.Data.SqlClient.SqlParameter paramOutConteoVentas = null;
            int ConteoVentas = int.MinValue;

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "DetalleVentaVerificarVentaArticulo";

                // Paramtro de entrada
                paramIdPresentacionArticulo = new System.Data.SqlClient.SqlParameter("@IdPresentacionArticulo", System.Data.SqlDbType.Int);
                paramIdPresentacionArticulo.Value = idPresentacionArticulo;
                cmd.Parameters.Add(paramIdPresentacionArticulo);

                // Parametro de salida
                paramOutConteoVentas = new System.Data.SqlClient.SqlParameter("@TotalVentas", System.Data.SqlDbType.Int);
                paramOutConteoVentas.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(paramOutConteoVentas);

                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();

                ConteoVentas = int.Parse(paramOutConteoVentas.Value.ToString());
                if (ConteoVentas < 0)
                {
                    // Si tiene ventas asociadas
                    return true;
                }
                else
                {
                    // No tiene ventas asociadas
                    return false;
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Logging.ErrorGeneral.Guardar(ex);
            }
            catch (Entidades.Excepciones.ExceptionErrorTransaccion)
            {
                Entidades.Mensaje mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(mensaje.Texto));
                throw new Entidades.Excepciones.ExceptionErrorTransaccion(mensaje.Texto);
            }
            finally
            {
                if (cmd.Connection.State == System.Data.ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }

                cmd.Dispose();
            }

            return false; 
        }

        public bool VerificarRelacionCarrito(int idPresentacionArticulo)
        {
            throw new NotImplementedException();
        }

        public ReadOnlyCollection<Entidades.PresentacionArticulo> ListarTodo()
        {
            List<Entidades.PresentacionArticulo> presentacion = new List<Entidades.PresentacionArticulo>();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataReader datareader = null;
            System.Collections.ObjectModel.ReadOnlyCollection<Entidades.PresentacionArticulo> listaReadOnlyPresentacionArticulos = null;
            Entidades.ResultadoTransaccion resultado = new Entidades.ResultadoTransaccion();

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "PresentacionArticuloSelect";

                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();
                datareader = cmd.ExecuteReader();

                while (datareader.Read())
                {
                    Entidades.PresentacionArticulo presentacionArticulo = new Entidades.PresentacionArticulo();

                    presentacionArticulo.IdPresentacionArticulo = datareader.GetInt32(0);
                    presentacionArticulo.Articulo.IdArticulo = datareader.GetInt32(1);
                    presentacionArticulo.CodigoEAN = datareader.GetString(2);
                    presentacionArticulo.Nombre = datareader.GetString(3);
                    presentacionArticulo.DescripcionBreve = datareader.GetString(4);
                    presentacionArticulo.Color.IdColor = datareader.GetInt32(5);
                    presentacionArticulo.Color.Codigo = datareader.GetString(6);
                    presentacionArticulo.Color.Nombre = datareader.GetString(7);
                    presentacionArticulo.Talla.IdTalla = datareader.GetInt32(8);

                    // La fecha se lee antes de cargar las imágenes para no generar bug
                    presentacionArticulo.Fecha = datareader.GetDateTime(15);

                    string RutaImagenes = System.Configuration.ConfigurationManager.AppSettings["RutaImagenesArticulo"] + "\\" + presentacionArticulo.Fecha.ToString("yyyy-MM-dd") + "\\";
                    string RutaArchivo = string.Empty;

                    RutaArchivo = RutaImagenes + presentacionArticulo.IdPresentacionArticulo + "A.jpg";
                    if (datareader.GetBoolean(9) == true && System.IO.File.Exists(RutaArchivo) == true)
                    {
                        presentacionArticulo.Imagen1 = System.IO.File.ReadAllBytes(RutaArchivo);
                    }
                    else
                    {
                        presentacionArticulo.Imagen1 = null;
                    }

                    RutaArchivo = RutaImagenes + presentacionArticulo.IdPresentacionArticulo + "B.jpg";
                    if (datareader.GetBoolean(10) == true && System.IO.File.Exists(RutaArchivo) == true)
                    {
                        presentacionArticulo.Imagen2 = System.IO.File.ReadAllBytes(RutaArchivo);
                    }
                    else
                    {
                        presentacionArticulo.Imagen2 = null;
                    }

                    RutaArchivo = RutaImagenes + presentacionArticulo.IdPresentacionArticulo + "C.jpg";
                    if (datareader.GetBoolean(11) == true && System.IO.File.Exists(RutaArchivo) == true)
                    {
                        presentacionArticulo.Imagen3 = System.IO.File.ReadAllBytes(RutaArchivo);
                    }
                    else
                    {
                        presentacionArticulo.Imagen3 = null;
                    }

                    RutaArchivo = RutaImagenes + presentacionArticulo.IdPresentacionArticulo + "D.jpg";
                    if (datareader.GetBoolean(12) == true && System.IO.File.Exists(RutaArchivo) == true)
                    {
                        presentacionArticulo.Imagen4 = System.IO.File.ReadAllBytes(RutaArchivo);
                    }
                    else
                    {
                        presentacionArticulo.Imagen4 = null;
                    }

                    RutaArchivo = RutaImagenes + presentacionArticulo.IdPresentacionArticulo + "E.jpg";
                    if (datareader.GetBoolean(13) == true && System.IO.File.Exists(RutaArchivo) == true)
                    {
                        presentacionArticulo.Imagen5 = System.IO.File.ReadAllBytes(RutaArchivo);
                    }
                    else
                    {
                        presentacionArticulo.Imagen5 = null;
                    }

                    RutaArchivo = RutaImagenes + presentacionArticulo.IdPresentacionArticulo + "F.jpg";
                    if (datareader.GetBoolean(14) == true && System.IO.File.Exists(RutaArchivo) == true)
                    {
                        presentacionArticulo.Imagen6 = System.IO.File.ReadAllBytes(RutaArchivo);
                    }
                    else
                    {
                        presentacionArticulo.Imagen6 = null;
                    }

                    presentacionArticulo.VlrUnidadMasa = datareader.GetDouble(16);
                    presentacionArticulo.VlrUnidadVolumenAncho = datareader.GetDouble(17);
                    presentacionArticulo.VlrUnidadVolumenLargo = datareader.GetDouble(18);
                    presentacionArticulo.VlrUnidadVolumenProfundidad = datareader.GetDouble(19);
                    presentacionArticulo.VlrContenidoVolumetrico = datareader.GetDouble(20);
                    presentacionArticulo.VlrUnidadLongitud = datareader.GetDouble(21);
                    presentacionArticulo.UnidadMasa.IdUnidadMasa = datareader.GetInt32(22);
                    presentacionArticulo.UnidadVolumen.IdUnidadVolumen = datareader.GetInt32(23);
                    presentacionArticulo.UnidadLongitud.IdUnidadLongitud = datareader.GetInt32(24);
                    presentacionArticulo.EnLinea = datareader.GetBoolean(25);
                    presentacionArticulo.Activo = datareader.GetBoolean(26);
                    presentacionArticulo.Precio = datareader.GetDouble(27);
                    presentacionArticulo.Existencias = datareader.GetInt32(28);
                    presentacionArticulo.Sabor.IdSabor = datareader.GetInt32(29);
                    presentacionArticulo.CostoArticulo = datareader.GetDouble(30);
                    presentacionArticulo.PreOrden = datareader.GetBoolean(31);
                    presentacionArticulo.UnidadPresentacion.IdUnidadPresentacion = datareader.GetInt32(32);
                    presentacionArticulo.VlrUnidadPresentacion = datareader.GetDouble(33);
                    presentacionArticulo.UnidadPresentacion.Nombre = datareader.GetString(34);
                    presentacionArticulo.FechaProximoVencimiento = datareader.GetDateTime(35);

                    presentacion.Add(presentacionArticulo);

                    #if Pruebas
                        break;
                    #endif
                }

                listaReadOnlyPresentacionArticulos = new System.Collections.ObjectModel.ReadOnlyCollection<Entidades.PresentacionArticulo>(presentacion);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Logging.ErrorGeneral.Guardar(ex);
            }
            catch (Entidades.Excepciones.ExceptionErrorTransaccion ex)
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

            return listaReadOnlyPresentacionArticulos;
        }

        public ReadOnlyCollection<Entidades.PresentacionArticulo> ListarPendientesActualizacion()
        {
            List<Entidades.PresentacionArticulo> presentacion = new List<Entidades.PresentacionArticulo>();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataReader datareader = null;
            System.Collections.ObjectModel.ReadOnlyCollection<Entidades.PresentacionArticulo> listaReadOnlyPresentacionArticulos = null;
            Entidades.ResultadoTransaccion resultado = new Entidades.ResultadoTransaccion();

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "PresentacionArticuloSelectPendientesActualizacion";
                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();
                datareader = cmd.ExecuteReader();

                while (datareader.Read())
                {
                    Entidades.PresentacionArticulo presentacionArticulo = new Entidades.PresentacionArticulo();

                    presentacionArticulo.IdPresentacionArticulo = datareader.GetInt32(0);
                    presentacionArticulo.Articulo.IdArticulo = datareader.GetInt32(1);
                    presentacionArticulo.CodigoEAN = datareader.GetString(2);
                    presentacionArticulo.Nombre = datareader.GetString(3);
                    presentacionArticulo.DescripcionBreve = datareader.GetString(4);
                    presentacionArticulo.Color.IdColor = datareader.GetInt32(5);
                    presentacionArticulo.Color.Codigo = datareader.GetString(6);
                    presentacionArticulo.Color.Nombre = datareader.GetString(7);
                    presentacionArticulo.Talla.IdTalla = datareader.GetInt32(8);

                    // La fecha se lee antes de cargar las imágenes para no generar bug
                    presentacionArticulo.Fecha = datareader.GetDateTime(15);

                    string RutaImagen = System.Configuration.ConfigurationManager.AppSettings["RutaImagenesArticulo"] + "\\" + presentacionArticulo.Fecha.ToString("yyyy-MM-dd") + "\\";
                    if (datareader.GetBoolean(9) == true)
                    {
                        presentacionArticulo.Imagen1 = System.IO.File.ReadAllBytes(RutaImagen + presentacionArticulo.IdPresentacionArticulo + "A.jpg");
                    }
                    else
                    {
                        presentacionArticulo.Imagen1 = null;
                    }

                    if (datareader.GetBoolean(10) == true)
                    {
                        presentacionArticulo.Imagen2 = System.IO.File.ReadAllBytes(RutaImagen + presentacionArticulo.IdPresentacionArticulo + "B.jpg");
                    }
                    else
                    {
                        presentacionArticulo.Imagen2 = null;
                    }

                    if (datareader.GetBoolean(11) == true)
                    {
                        presentacionArticulo.Imagen3 = System.IO.File.ReadAllBytes(RutaImagen + presentacionArticulo.IdPresentacionArticulo + "C.jpg");
                    }
                    else
                    {
                        presentacionArticulo.Imagen3 = null;
                    }

                    if (datareader.GetBoolean(12) == true)
                    {
                        presentacionArticulo.Imagen4 = System.IO.File.ReadAllBytes(RutaImagen + presentacionArticulo.IdPresentacionArticulo + "D.jpg");
                    }
                    else
                    {
                        presentacionArticulo.Imagen4 = null;
                    }

                    if (datareader.GetBoolean(13) == true)
                    {
                        presentacionArticulo.Imagen5 = System.IO.File.ReadAllBytes(RutaImagen + presentacionArticulo.IdPresentacionArticulo + "E.jpg");
                    }
                    else
                    {
                        presentacionArticulo.Imagen5 = null;
                    }

                    if (datareader.GetBoolean(14) == true)
                    {
                        presentacionArticulo.Imagen6 = System.IO.File.ReadAllBytes(RutaImagen + presentacionArticulo.IdPresentacionArticulo + "F.jpg");
                    }
                    else
                    {
                        presentacionArticulo.Imagen6 = null;
                    }

                    presentacionArticulo.VlrUnidadMasa = datareader.GetDouble(16);
                    presentacionArticulo.VlrUnidadVolumenAncho = datareader.GetDouble(17);
                    presentacionArticulo.VlrUnidadVolumenLargo = datareader.GetDouble(18);
                    presentacionArticulo.VlrUnidadVolumenProfundidad = datareader.GetDouble(19);
                    presentacionArticulo.VlrContenidoVolumetrico = datareader.GetDouble(20);
                    presentacionArticulo.VlrUnidadLongitud = datareader.GetDouble(21);
                    presentacionArticulo.UnidadMasa.IdUnidadMasa = datareader.GetInt32(22);
                    presentacionArticulo.UnidadVolumen.IdUnidadVolumen = datareader.GetInt32(23);
                    presentacionArticulo.UnidadLongitud.IdUnidadLongitud = datareader.GetInt32(24);
                    presentacionArticulo.EnLinea = datareader.GetBoolean(25);
                    presentacionArticulo.Activo = datareader.GetBoolean(26);
                    presentacionArticulo.Precio = datareader.GetDouble(27);
                    presentacionArticulo.Existencias = datareader.GetInt32(28);
                    presentacionArticulo.Sabor.IdSabor = datareader.GetInt32(29);
                    presentacionArticulo.CostoArticulo = datareader.GetDouble(30);
                    presentacionArticulo.PreOrden = datareader.GetBoolean(31);
                    presentacionArticulo.UnidadPresentacion.IdUnidadPresentacion = datareader.GetInt32(32);
                    presentacionArticulo.VlrUnidadPresentacion = datareader.GetDouble(33);
                    presentacionArticulo.FechaProximoVencimiento = datareader.GetDateTime(34);
                    presentacion.Add(presentacionArticulo);

                    #if Pruebas
                        break;
                    #endif
                }

                listaReadOnlyPresentacionArticulos = new System.Collections.ObjectModel.ReadOnlyCollection<Entidades.PresentacionArticulo>(presentacion);

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

            return listaReadOnlyPresentacionArticulos;
        }

        public ReadOnlyCollection<Entidades.PresentacionArticulo> ListarActivos()
        {
            List<Entidades.PresentacionArticulo> presentacion = new List<Entidades.PresentacionArticulo>();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataReader datareader = null;
            System.Collections.ObjectModel.ReadOnlyCollection<Entidades.PresentacionArticulo> listaReadOnlyPresentacionArticulos = null;
            Entidades.ResultadoTransaccion resultado = new Entidades.ResultadoTransaccion();

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "PresentacionArticuloSelectActivos";

                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();
                datareader = cmd.ExecuteReader();

                while (datareader.Read())
                {
                    Entidades.PresentacionArticulo presentacionArticulo = new Entidades.PresentacionArticulo();

                    presentacionArticulo.IdPresentacionArticulo = datareader.GetInt32(0);
                    presentacionArticulo.Articulo.IdArticulo = datareader.GetInt32(1);
                    presentacionArticulo.CodigoEAN = datareader.GetString(2);
                    presentacionArticulo.Nombre = datareader.GetString(3);
                    presentacionArticulo.DescripcionBreve = datareader.GetString(4);
                    presentacionArticulo.Color.IdColor = datareader.GetInt32(5);
                    presentacionArticulo.Color.Codigo = datareader.GetString(6);
                    presentacionArticulo.Color.Nombre = datareader.GetString(7);
                    presentacionArticulo.Talla.IdTalla = datareader.GetInt32(8);

                    // La fecha se lee antes de cargar las imágenes para no generar bug
                    presentacionArticulo.Fecha = datareader.GetDateTime(15);

                    string RutaImagen = System.Configuration.ConfigurationManager.AppSettings["RutaImagenesArticulo"] + "\\" + presentacionArticulo.Fecha.ToString("yyyy-MM-dd") + "\\";
                    if (datareader.GetBoolean(9) == true)
                    {
                        presentacionArticulo.Imagen1 = System.IO.File.ReadAllBytes(RutaImagen + presentacionArticulo.IdPresentacionArticulo + "A.jpg");
                    }
                    else
                    {
                        presentacionArticulo.Imagen1 = null;
                    }

                    if (datareader.GetBoolean(10) == true)
                    {
                        presentacionArticulo.Imagen2 = System.IO.File.ReadAllBytes(RutaImagen + presentacionArticulo.IdPresentacionArticulo + "B.jpg");
                    }
                    else
                    {
                        presentacionArticulo.Imagen2 = null;
                    }

                    if (datareader.GetBoolean(11) == true)
                    {
                        presentacionArticulo.Imagen3 = System.IO.File.ReadAllBytes(RutaImagen + presentacionArticulo.IdPresentacionArticulo + "C.jpg");
                    }
                    else
                    {
                        presentacionArticulo.Imagen3 = null;
                    }

                    if (datareader.GetBoolean(12) == true)
                    {
                        presentacionArticulo.Imagen4 = System.IO.File.ReadAllBytes(RutaImagen + presentacionArticulo.IdPresentacionArticulo + "D.jpg");
                    }
                    else
                    {
                        presentacionArticulo.Imagen4 = null;
                    }

                    if (datareader.GetBoolean(13) == true)
                    {
                        presentacionArticulo.Imagen5 = System.IO.File.ReadAllBytes(RutaImagen + presentacionArticulo.IdPresentacionArticulo + "E.jpg");
                    }
                    else
                    {
                        presentacionArticulo.Imagen5 = null;
                    }

                    if (datareader.GetBoolean(14) == true)
                    {
                        presentacionArticulo.Imagen6 = System.IO.File.ReadAllBytes(RutaImagen + presentacionArticulo.IdPresentacionArticulo + "F.jpg");
                    }
                    else
                    {
                        presentacionArticulo.Imagen6 = null;
                    }

                    presentacionArticulo.VlrUnidadMasa = datareader.GetDouble(16);
                    presentacionArticulo.VlrUnidadVolumenAncho = datareader.GetDouble(17);
                    presentacionArticulo.VlrUnidadVolumenLargo = datareader.GetDouble(18);
                    presentacionArticulo.VlrUnidadVolumenProfundidad = datareader.GetDouble(19);
                    presentacionArticulo.VlrContenidoVolumetrico = datareader.GetDouble(20);
                    presentacionArticulo.VlrUnidadLongitud = datareader.GetDouble(21);
                    presentacionArticulo.UnidadMasa.IdUnidadMasa = datareader.GetInt32(22);
                    presentacionArticulo.UnidadVolumen.IdUnidadVolumen = datareader.GetInt32(23);
                    presentacionArticulo.UnidadLongitud.IdUnidadLongitud = datareader.GetInt32(24);
                    presentacionArticulo.EnLinea = datareader.GetBoolean(25);
                    presentacionArticulo.Activo = datareader.GetBoolean(26);
                    presentacionArticulo.Precio = datareader.GetDouble(27);
                    presentacionArticulo.Existencias = datareader.GetInt32(28);
                    presentacionArticulo.Sabor.IdSabor = datareader.GetInt32(29);
                    presentacionArticulo.CostoArticulo = datareader.GetDouble(30);
                    presentacionArticulo.PreOrden = datareader.GetBoolean(31);
                    presentacionArticulo.UnidadPresentacion.IdUnidadPresentacion = datareader.GetInt32(32);
                    presentacionArticulo.VlrUnidadPresentacion = datareader.GetDouble(33);
                    presentacionArticulo.FechaProximoVencimiento = datareader.GetDateTime(34);

                    listaReadOnlyPresentacionArticulos = new System.Collections.ObjectModel.ReadOnlyCollection<Entidades.PresentacionArticulo>(presentacion);
                    // Logging.Accion.Guardar("Lectura de la tabla presentacion articulo");

                    presentacion.Add(presentacionArticulo);

                    #if Pruebas
                        break;
                    #endif
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Logging.ErrorGeneral.Guardar(ex);
            }
            catch (Entidades.Excepciones.ExceptionErrorTransaccion ex)
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

            return listaReadOnlyPresentacionArticulos;
        }

        public ResultadoTransaccion ActivarInactivarEnLineaPorArticulo(int idArticulo, Estado estado)
        {
            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlParameter paramIdArticulo = null;
            System.Data.SqlClient.SqlParameter paramEstado = null;
            Entidades.ResultadoTransaccion resultado = new Entidades.ResultadoTransaccion();
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "PresentacionArticuloUpdateEnLinea";

                paramIdArticulo = new System.Data.SqlClient.SqlParameter("@idArticulo", System.Data.SqlDbType.Int);
                paramIdArticulo.Value = idArticulo;
                cmd.Parameters.Add(paramIdArticulo);

                paramEstado = new System.Data.SqlClient.SqlParameter("@EnLinea", System.Data.SqlDbType.Bit);
                if (estado == Estado.Habilitado)
                {
                    paramEstado.Value = 1;
                }
                else
                {
                    paramEstado.Value = 0;
                }
                
                cmd.Parameters.Add(paramEstado);

                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();
                int i = cmd.ExecuteNonQuery();
                resultado.RegistrosAfectados = i;
                resultado.Mensaje = Mensajes.LinqToXml.LeerMensaje("0006");
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Logging.ErrorGeneral.Guardar(ex);
            }
            catch (Entidades.Excepciones.ExceptionErrorTransaccion ex)
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(ex);
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

        public ResultadoTransaccion ActivarInactivarPreordenPorArticulo(int idArticulo, Estado estado)
        {
            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlParameter paramIdArticulo = null;
            System.Data.SqlClient.SqlParameter paramEstado = null;
            Entidades.ResultadoTransaccion resultado = new Entidades.ResultadoTransaccion();
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "PresentacionArticuloUpdatePreOrden";

                paramIdArticulo = new System.Data.SqlClient.SqlParameter("@idArticulo", System.Data.SqlDbType.Int);
                paramIdArticulo.Value = idArticulo;
                cmd.Parameters.Add(paramIdArticulo);

                paramEstado = new System.Data.SqlClient.SqlParameter("@PreOrden", System.Data.SqlDbType.Bit);
                if (estado == Estado.Habilitado)
                {
                    paramEstado.Value = 1;
                }
                else
                {
                    paramEstado.Value = 0;
                }
                cmd.Parameters.Add(paramEstado);

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

        public Entidades.PresentacionArticulo ConsultarPorId(int idPresentacionArticulo)
        {
            Entidades.PresentacionArticulo presentacionArticulo = null;
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataReader datareader = null;
            System.Data.SqlClient.SqlParameter ParametroIdPresentacionArticulo = null;

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "PresentacionArticuloSelectPorIdPresentacionArticulo";
                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                ParametroIdPresentacionArticulo = new System.Data.SqlClient.SqlParameter("@IdPresentacionArticulo", System.Data.SqlDbType.Int);
                ParametroIdPresentacionArticulo.Value = idPresentacionArticulo;
                cmd.Parameters.Add(ParametroIdPresentacionArticulo);
                cmd.Connection.Open();
                datareader = cmd.ExecuteReader();

                if (datareader.Read())
                {
                    presentacionArticulo = new Entidades.PresentacionArticulo();

                    presentacionArticulo.IdPresentacionArticulo = datareader.GetInt32(0);
                    presentacionArticulo.Articulo.IdArticulo = datareader.GetInt32(1);
                    presentacionArticulo.CodigoEAN = datareader.GetString(2);
                    presentacionArticulo.Nombre = datareader.GetString(3);
                    presentacionArticulo.DescripcionBreve = datareader.GetString(4);
                    presentacionArticulo.Color.IdColor = datareader.GetInt32(5);
                    presentacionArticulo.Talla.IdTalla = datareader.GetInt32(6);
                    presentacionArticulo.Fecha = datareader.GetDateTime(13);

                    string RutaImagenes = System.Configuration.ConfigurationManager.AppSettings["RutaImagenesArticulo"] + "\\" + presentacionArticulo.Fecha.ToString("yyyy-MM-dd") + "\\";
                    string RutaArchivo = string.Empty;

                    RutaArchivo = RutaImagenes + presentacionArticulo.IdPresentacionArticulo + "A.jpg";
                    if (datareader.GetBoolean(7) == true && System.IO.File.Exists(RutaArchivo) == true)
                    {
                        presentacionArticulo.Imagen1 = System.IO.File.ReadAllBytes(RutaArchivo);
                    }
                    else
                    {
                        presentacionArticulo.Imagen1 = null;
                    }

                    RutaArchivo = RutaImagenes + presentacionArticulo.IdPresentacionArticulo + "B.jpg";
                    if (datareader.GetBoolean(8) == true && System.IO.File.Exists(RutaArchivo) == true)
                    {
                        presentacionArticulo.Imagen2 = System.IO.File.ReadAllBytes(RutaArchivo);
                    }
                    else
                    {
                        presentacionArticulo.Imagen2 = null;
                    }

                    RutaArchivo = RutaImagenes + presentacionArticulo.IdPresentacionArticulo + "C.jpg";
                    if (datareader.GetBoolean(9) == true && System.IO.File.Exists(RutaArchivo) == true)
                    {
                        presentacionArticulo.Imagen3 = System.IO.File.ReadAllBytes(RutaArchivo);
                    }
                    else
                    {
                        presentacionArticulo.Imagen3 = null;
                    }

                    RutaArchivo = RutaImagenes + presentacionArticulo.IdPresentacionArticulo + "D.jpg";
                    if (datareader.GetBoolean(10) == true && System.IO.File.Exists(RutaArchivo) == true)
                    {
                        presentacionArticulo.Imagen4 = System.IO.File.ReadAllBytes(RutaArchivo);
                    }
                    else
                    {
                        presentacionArticulo.Imagen4 = null;
                    }

                    RutaArchivo = RutaImagenes + presentacionArticulo.IdPresentacionArticulo + "E.jpg";
                    if (datareader.GetBoolean(11) == true && System.IO.File.Exists(RutaArchivo) == true)
                    {
                        presentacionArticulo.Imagen5 = System.IO.File.ReadAllBytes(RutaArchivo);
                    }
                    else
                    {
                        presentacionArticulo.Imagen5 = null;
                    }

                    RutaArchivo = RutaImagenes + presentacionArticulo.IdPresentacionArticulo + "F.jpg";
                    if (datareader.GetBoolean(12) == true && System.IO.File.Exists(RutaArchivo) == true)
                    {
                        presentacionArticulo.Imagen6 = System.IO.File.ReadAllBytes(RutaArchivo);
                    }
                    else
                    {
                        presentacionArticulo.Imagen6 = null;
                    }

                    presentacionArticulo.VlrUnidadMasa = datareader.GetDouble(14);
                    presentacionArticulo.VlrUnidadVolumenAncho = datareader.GetDouble(15);
                    presentacionArticulo.VlrUnidadVolumenLargo = datareader.GetDouble(16);
                    presentacionArticulo.VlrUnidadVolumenProfundidad = datareader.GetDouble(17);
                    presentacionArticulo.VlrUnidadLongitud = datareader.GetDouble(18);
                    presentacionArticulo.UnidadMasa.IdUnidadMasa = datareader.GetInt32(19);
                    presentacionArticulo.UnidadVolumen.IdUnidadVolumen = datareader.GetInt32(20);
                    presentacionArticulo.UnidadLongitud.IdUnidadLongitud = datareader.GetInt32(21);
                    presentacionArticulo.EnLinea = datareader.GetBoolean(22);
                    presentacionArticulo.Activo = datareader.GetBoolean(23);
                    presentacionArticulo.Precio = datareader.GetDouble(24);
                    presentacionArticulo.Articulo.Titulo = datareader.GetString(25);
                    presentacionArticulo.UnidadMasa.Nombre = datareader.GetString(26);
                    presentacionArticulo.Sabor.Nombre = datareader.GetString(27);
                    presentacionArticulo.Talla.Nombre = datareader.GetString(28);
                    presentacionArticulo.Color.Nombre = datareader.GetString(29);
                    presentacionArticulo.UnidadLongitud.Nombre = datareader.GetString(30);
                    presentacionArticulo.UnidadVolumen.Nombre = datareader.GetString(31);
                    presentacionArticulo.VlrContenidoVolumetrico = datareader.GetDouble(32);
                    presentacionArticulo.Existencias = datareader.GetInt32(33);
                    presentacionArticulo.Sabor.IdSabor = datareader.GetInt32(34);
                    presentacionArticulo.Articulo.Categoria.IdCategoria = datareader.GetInt32(35);
                    presentacionArticulo.Articulo.Categoria.IdCategoriaPadre = datareader.GetInt32(36);
                    presentacionArticulo.Articulo.Categoria.Nombre = datareader.GetString(37);
                    presentacionArticulo.UnidadPresentacion.IdUnidadPresentacion = datareader.GetInt32(38);
                    presentacionArticulo.UnidadPresentacion.Nombre = datareader.GetString(39);
                    presentacionArticulo.VlrUnidadPresentacion = datareader.GetDouble(40);
                    presentacionArticulo.PreOrden = datareader.GetBoolean(41);
                    presentacionArticulo.Articulo.Marca.IdMarca = datareader.GetInt32(42);
                    presentacionArticulo.Articulo.Marca.Nombre = datareader.GetString(43);
                    presentacionArticulo.FechaProximoVencimiento = datareader.GetDateTime(44);
                }
                return presentacionArticulo;
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

                if (datareader != null)
                {
                    datareader.Dispose();
                }

                if (cmd != null)
                {
                    cmd.Dispose();
                }
            }

            return null;
        }

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

                if (datareader.Read())
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
