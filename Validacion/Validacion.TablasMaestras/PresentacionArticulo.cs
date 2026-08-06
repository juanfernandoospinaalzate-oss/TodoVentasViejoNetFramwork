// -----------------------------------------------------------------------
// <copyright file="PresentacionArticulo.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// ----------------------------------------------------------------------

namespace Validacion.TablasMaestras
{
    using System;
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
        public Entidades.ResultadoTransaccion Insertar(Entidades.PresentacionArticulo presentacion, Entidades.Kardex kardex)
        {
            ReglasDENegocio.TablasMaestras.PresentacionArticulo presentaciones = new ReglasDENegocio.TablasMaestras.PresentacionArticulo();
            Entidades.ResultadoTransaccion respuestaTransaccion = new Entidades.ResultadoTransaccion();

            if (presentacion == null)
            {
                respuestaTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(respuestaTransaccion.Mensaje.Texto));
                return respuestaTransaccion;
            }

            // El sistema verifica que se especifique un IdArtículo (Parte 1)
            if (string.IsNullOrEmpty(presentacion.Articulo.IdArticulo.ToString()))
            {
                respuestaTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0036");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(respuestaTransaccion.Mensaje.Texto));
                return respuestaTransaccion;
            }

            // El sistema verifica que se especifique un IdArtículo (Parte 2)
            int garantiaMeses = int.MinValue;
            if (int.TryParse(presentacion.Articulo.IdArticulo.ToString(), out garantiaMeses) == false)
            {
                respuestaTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0036");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(respuestaTransaccion.Mensaje.Texto));
                return respuestaTransaccion;
            }

            if (string.IsNullOrEmpty(presentacion.Nombre.Trim()))
            {
                respuestaTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0038");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(respuestaTransaccion.Mensaje.Texto));
                return respuestaTransaccion;
            }

            if (string.IsNullOrEmpty(presentacion.Nombre.Trim()))
            {
                respuestaTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0038");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(respuestaTransaccion.Mensaje.Texto));
                return respuestaTransaccion;
            }

            if (string.IsNullOrEmpty(presentacion.CodigoEAN.Trim()))
            {
                respuestaTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0037");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(respuestaTransaccion.Mensaje.Texto));
                return respuestaTransaccion;
            }

            // CantidadSalida tiene que ser cero al crear una presentación de artículo
            if (kardex.CantidadSalida != 0)
            {
                respuestaTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0084");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(respuestaTransaccion.Mensaje.Texto));
                return respuestaTransaccion;
            }

            // La cantidad de entrada tiene que ser mayor o igual a cero al crear una presentación de artículo
            if (kardex.CantidadEntrada < 0)
            {
                respuestaTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0085");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(respuestaTransaccion.Mensaje.Texto));
                return respuestaTransaccion;
            }

            // Controlar las entradas si se va a usar descuento
            if (presentacion.UsarDescuento == true)
            {
                // Cuando el descuento está activo...
                
                // Ambas formas de descuento no pueden estar Activas a la vez
                if (presentacion.UsarPorcentajeDescuento == true && presentacion.UsarValorFijoDescuento == true)
                {
                    respuestaTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0086");
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(respuestaTransaccion.Mensaje.Texto));
                    return respuestaTransaccion;
                }

                // Ambas formas de descuento no puede estar Inactivas a la vez
                if (presentacion.UsarPorcentajeDescuento == false && presentacion.UsarValorFijoDescuento == false)
                {
                    respuestaTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0087");
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(respuestaTransaccion.Mensaje.Texto));
                    return respuestaTransaccion;
                }

                // Si se usa porcentaje de descuento
                if (presentacion.UsarPorcentajeDescuento == true)
                {
                    // El porcentaje configurado está bien, pero el valor fijo tiene que ser cero
                    if (presentacion.ValorPorcentajeDescuento > 0 && presentacion.ValorFijoDescuento != 0)
                    {
                        respuestaTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0088");
                        Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(respuestaTransaccion.Mensaje.Texto));
                        return respuestaTransaccion;
                    }

                    // Si el porcentaje configurado es negativo o es cero
                    if (presentacion.ValorPorcentajeDescuento <= 0)
                    {
                        respuestaTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0089");
                        Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(respuestaTransaccion.Mensaje.Texto));
                        return respuestaTransaccion;
                    }

                }

                // Si se usa Valor fijo de descuento
                if (presentacion.UsarValorFijoDescuento == true)
                {
                    // El valor fijo está bien pero el porcentaje tiene que ser cero
                    if (presentacion.ValorFijoDescuento > 0 && presentacion.ValorPorcentajeDescuento != 0)
                    {
                        respuestaTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0090");
                        Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(respuestaTransaccion.Mensaje.Texto));
                        return respuestaTransaccion;
                    }

                    // Si el valor fijo de descuento está mal configurado
                    if (presentacion.ValorFijoDescuento <= 0)
                    {
                        respuestaTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0091");
                        Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(respuestaTransaccion.Mensaje.Texto));
                        return respuestaTransaccion;
                    }
                }

                // La fecha de inicio de descuento debe ser menor a la fecha final de descuento
                if (presentacion.FechaInicioDescuento >= presentacion.FechaFinalDescuento)
                {
                    respuestaTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0092");
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(respuestaTransaccion.Mensaje.Texto));
                    return respuestaTransaccion;
                }
            }

            // Ninguna de las fechas, inicio o final de descuento pueden estar configuradas lejos en el pasado
            if (presentacion.FechaInicioDescuento < new DateTime(2022, 10, 13) || presentacion.FechaFinalDescuento < new DateTime(2022, 10, 13))
            {
                respuestaTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0093");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(respuestaTransaccion.Mensaje.Texto));
                return respuestaTransaccion;
            }

            if (presentacion.CodigoEAN.Length > 18)
            {
                respuestaTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0096");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(respuestaTransaccion.Mensaje.Texto));
                return respuestaTransaccion;
            }

            if (presentacion.Nombre.Length > 100)
            {
                respuestaTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0097");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(respuestaTransaccion.Mensaje.Texto));
                return respuestaTransaccion;
            }

            return presentaciones.Insertar(presentacion, kardex);
        }


        public bool SubirImagen(byte[] imagen, string nombreImagen, char letraImagen, DateTime fechaOut)
        {
            ReglasDENegocio.TablasMaestras.PresentacionArticulo Presentacion = new ReglasDENegocio.TablasMaestras.PresentacionArticulo();
            return Presentacion.SubirImagen(imagen, nombreImagen, letraImagen, fechaOut);
        }

        /// <summary>
        /// Actualiza registros del formulario Presentación Artículo en la base de datos.
        /// </summary>
        /// <param name="presentacion">Objeto con los datos que se desean modificar</param>
        /// <param name="kardex">Objeto con los datos que se desean modificar</param>
        /// <returns></returns>
        public Entidades.ResultadoTransaccion Actualizar(Entidades.PresentacionArticulo presentacion, Entidades.Kardex kardex)
        {
            ReglasDENegocio.TablasMaestras.PresentacionArticulo Presentacion = new ReglasDENegocio.TablasMaestras.PresentacionArticulo();
            Entidades.ResultadoTransaccion respuestaTransaccion = new Entidades.ResultadoTransaccion();

            if (presentacion == null)
            {
                respuestaTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(respuestaTransaccion.Mensaje.Texto));
                return respuestaTransaccion;
            }

            // El sistema verifica que se especifique un IdArtículo (Parte 1)
            if (string.IsNullOrEmpty(presentacion.Articulo.IdArticulo.ToString()))
            {
                respuestaTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0036");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(respuestaTransaccion.Mensaje.Texto));
                return respuestaTransaccion;
            }

            // El sistema verifica que se especifique un IdArtículo (Parte 2)
            int garantiaMeses = int.MinValue;
            if (int.TryParse(presentacion.Articulo.IdArticulo.ToString(), out garantiaMeses) == false)
            {
                respuestaTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0036");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(respuestaTransaccion.Mensaje.Texto));
                return respuestaTransaccion;
            }

            if (string.IsNullOrEmpty(presentacion.Nombre.Trim()))
            {
                respuestaTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0038");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(respuestaTransaccion.Mensaje.Texto));
                return respuestaTransaccion;
            }

            if (string.IsNullOrEmpty(presentacion.Nombre.Trim()))
            {
                respuestaTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0038");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(respuestaTransaccion.Mensaje.Texto));
                return respuestaTransaccion;
            }

            if (string.IsNullOrEmpty(presentacion.CodigoEAN.Trim()))
            {
                respuestaTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0037");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(respuestaTransaccion.Mensaje.Texto));
                return respuestaTransaccion;
            }

            // CantidadSalida tiene que ser positiva o cero al actualizar una presentación de artículo
            if (kardex.CantidadSalida < 0)
            {
                respuestaTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0094");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(respuestaTransaccion.Mensaje.Texto));
                return respuestaTransaccion;
            }

            // La cantidad de entrada tiene que ser positiva o cero al actualizar una presentación de artículo
            if (kardex.CantidadEntrada < 0)
            {
                respuestaTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0095");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(respuestaTransaccion.Mensaje.Texto));
                return respuestaTransaccion;
            }

            // Controlar las entradas si se va a usar descuento
            if (presentacion.UsarDescuento == true)
            {
                // Cuando el descuento está activo...

                // Ambas formas de descuento no pueden estar Activas a la vez
                if (presentacion.UsarPorcentajeDescuento == true && presentacion.UsarValorFijoDescuento == true)
                {
                    respuestaTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0086");
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(respuestaTransaccion.Mensaje.Texto));
                    return respuestaTransaccion;
                }

                // Ambas formas de descuento no puede estar Inactivas a la vez
                if (presentacion.UsarPorcentajeDescuento == false && presentacion.UsarValorFijoDescuento == false)
                {
                    respuestaTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0087");
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(respuestaTransaccion.Mensaje.Texto));
                    return respuestaTransaccion;
                }

                // Si se usa porcentaje de descuento
                if (presentacion.UsarPorcentajeDescuento == true)
                {
                    // El porcentaje configurado está bien, pero el valor fijo tiene que ser cero
                    if (presentacion.ValorPorcentajeDescuento > 0 && presentacion.ValorFijoDescuento != 0)
                    {
                        respuestaTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0088");
                        Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(respuestaTransaccion.Mensaje.Texto));
                        return respuestaTransaccion;
                    }

                    // Si el porcentaje configurado es negativo o es cero
                    if (presentacion.ValorPorcentajeDescuento <= 0)
                    {
                        respuestaTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0089");
                        Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(respuestaTransaccion.Mensaje.Texto));
                        return respuestaTransaccion;
                    }

                }

                // Si se usa Valor fijo de descuento
                if (presentacion.UsarValorFijoDescuento == true)
                {
                    // El valor fijo está bien pero el porcentaje tiene que ser cero
                    if (presentacion.ValorFijoDescuento > 0 && presentacion.ValorPorcentajeDescuento != 0)
                    {
                        respuestaTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0090");
                        Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(respuestaTransaccion.Mensaje.Texto));
                        return respuestaTransaccion;
                    }

                    // Si el valor fijo de descuento está mal configurado
                    if (presentacion.ValorFijoDescuento <= 0)
                    {
                        respuestaTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0091");
                        Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(respuestaTransaccion.Mensaje.Texto));
                        return respuestaTransaccion;
                    }
                }

                // La fecha de inicio de descuento debe ser menor a la fecha final de descuento
                if (presentacion.FechaInicioDescuento >= presentacion.FechaFinalDescuento)
                {
                    respuestaTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0092");
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(respuestaTransaccion.Mensaje.Texto));
                    return respuestaTransaccion;
                }
            }

            // Ninguna de las fechas, inicio o final de descuento pueden estar configuradas lejos en el pasado
            if (presentacion.FechaInicioDescuento < new DateTime(2022, 10, 13) || presentacion.FechaFinalDescuento < new DateTime(2022, 10, 13))
            {
                respuestaTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0093");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(respuestaTransaccion.Mensaje.Texto));
                return respuestaTransaccion;
            }

            if (presentacion.CodigoEAN.Length > 18)
            {
                respuestaTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0096");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(respuestaTransaccion.Mensaje.Texto));
                return respuestaTransaccion;
            }

            if (presentacion.Nombre.Length > 100)
            {
                respuestaTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0097");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(respuestaTransaccion.Mensaje.Texto));
                return respuestaTransaccion;
            }

            return Presentacion.Actualizar(presentacion, kardex);
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.PresentacionArticulo> Listar(int idArticulo)
        {
            ReglasDENegocio.TablasMaestras.PresentacionArticulo Presentacion = new ReglasDENegocio.TablasMaestras.PresentacionArticulo();
            return Presentacion.Listar(idArticulo);
        }


        public Entidades.ResultadoTransaccion Eliminar(int idPresentacionArticulo)
        {
            ReglasDENegocio.TablasMaestras.PresentacionArticulo Presentacion = new ReglasDENegocio.TablasMaestras.PresentacionArticulo();
            return Presentacion.Eliminar(idPresentacionArticulo);
        }

        public Entidades.ResultadoTransaccion ActivarInactivarPorArticulo(int idArticulo, Entidades.Enumeraciones.Estado estado)
        {
            ReglasDENegocio.TablasMaestras.PresentacionArticulo Presentacion = new ReglasDENegocio.TablasMaestras.PresentacionArticulo();
            return Presentacion.ActivarInactivarPorArticulo(idArticulo, estado);
        }

        public bool VerificarVentaArticulo(int idPresentacionArticulo)
        {
            ReglasDENegocio.TablasMaestras.PresentacionArticulo Presentacion = new ReglasDENegocio.TablasMaestras.PresentacionArticulo();
            return Presentacion.VerificarVentaArticulo(idPresentacionArticulo);
        }

        public bool VerificarRelacionCarrito(int idPresentacionArticulo)
        {
            throw new NotImplementedException();
        }

        public ReadOnlyCollection<Entidades.PresentacionArticulo> ListarTodo()
        {
            ReglasDENegocio.TablasMaestras.PresentacionArticulo Presentacion = new ReglasDENegocio.TablasMaestras.PresentacionArticulo();
            return Presentacion.ListarTodo();
        }

        public ReadOnlyCollection<Entidades.PresentacionArticulo> ListarPendientesActualizacion()
        {
            ReglasDENegocio.TablasMaestras.PresentacionArticulo Presentacion = new ReglasDENegocio.TablasMaestras.PresentacionArticulo();
            return Presentacion.ListarPendientesActualizacion();
        }

        public ReadOnlyCollection<Entidades.PresentacionArticulo> ListarActivos()
        {
            ReglasDENegocio.TablasMaestras.PresentacionArticulo Presentacion = new ReglasDENegocio.TablasMaestras.PresentacionArticulo();
            return Presentacion.ListarActivos();
        }

        public ResultadoTransaccion ActivarInactivarEnLineaPorArticulo(int idArticulo, Estado estado)
        {
            ReglasDENegocio.TablasMaestras.PresentacionArticulo Presentacion = new ReglasDENegocio.TablasMaestras.PresentacionArticulo();
            return Presentacion.ActivarInactivarEnLineaPorArticulo(idArticulo, estado);
        }

        public ResultadoTransaccion ActivarInactivarPreordenPorArticulo(int idArticulo, Estado estado)
        {
            ReglasDENegocio.TablasMaestras.PresentacionArticulo Presentacion = new ReglasDENegocio.TablasMaestras.PresentacionArticulo();
            return Presentacion.ActivarInactivarPreordenPorArticulo(idArticulo, estado);
        }

        public Entidades.PresentacionArticulo ConsultarPorId(int idPresentacionArticulo)
        {
            ReglasDENegocio.TablasMaestras.PresentacionArticulo Presentacion = new ReglasDENegocio.TablasMaestras.PresentacionArticulo();
            return Presentacion.ConsultarPorId(idPresentacionArticulo);
        }

        public Entidades.PresentacionArticulo ConsultarPresentacionPorCodigoEAN(string CodigoEAN)
        {
            ReglasDENegocio.TablasMaestras.PresentacionArticulo Presentacion = new ReglasDENegocio.TablasMaestras.PresentacionArticulo();
            return Presentacion.ConsultarPresentacionPorCodigoEAN(CodigoEAN);
        }

        public int ConsultarExistenciasPresentacionArticulo(long IdPresentacionArticulo)
        {
            ReglasDENegocio.TablasMaestras.PresentacionArticulo Presentacion = new ReglasDENegocio.TablasMaestras.PresentacionArticulo();
            return Presentacion.ConsultarExistenciasPresentacionArticulo(IdPresentacionArticulo);
        }
    }
}
