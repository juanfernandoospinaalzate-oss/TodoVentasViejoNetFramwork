// -----------------------------------------------------------------------
// <copyright file="PresentacionArticulo.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// ----------------------------------------------------------------------
namespace ReglasDENegocio.TablasMaestras
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
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
            AccesoDatos.TablasMaestras.PresentacionArticulo presentaciones = new AccesoDatos.TablasMaestras.PresentacionArticulo();
            System.Collections.Generic.List<byte[]> lista = new List<byte[]>();
            
            this.ReordernarImagenes(ref presentacion, ref lista);
            Utilidades.QuitaAcentos(presentacion.Nombre);

            this.ControlarFechas(ref presentacion);

            // Verificar si el códogo de barras existe en la base de datos
            if (this.ConsultarPresentacionPorCodigoEAN(presentacion.CodigoEAN).CodigoEAN == presentacion.CodigoEAN)
            {
                Mensaje mensaje = Mensajes.LinqToXml.LeerMensaje("0098");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(mensaje.Texto));
                return new ResultadoTransaccion() { RegistrosAfectados = 0, Mensaje = mensaje };
            }

            return presentaciones.Insertar(presentacion, kardex);
        }

        public bool SubirImagen(byte[] imagen, string nombreImagen, char letraImagen, DateTime fechaOut)
        {
            AccesoDatos.TablasMaestras.PresentacionArticulo Presentacion = new AccesoDatos.TablasMaestras.PresentacionArticulo();
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
            AccesoDatos.TablasMaestras.PresentacionArticulo AccesoDatosPresentacion = new AccesoDatos.TablasMaestras.PresentacionArticulo();
            Entidades.PresentacionArticulo PresentacionArticuloEnBD = null;
            System.Collections.Generic.List<byte[]> lista = new List<byte[]>();

            this.ReordernarImagenes(ref presentacion, ref lista);
            Utilidades.QuitaAcentos(presentacion.Nombre);
            this.ControlarFechas(ref presentacion);

            // Verificar si el códogo de barras existe en la base de datos en una presentación de artículo diferente.
            // La ientificación de la presentación de artículo encontrada no puede ser cero (presentación de artículo inexistente)
            PresentacionArticuloEnBD = AccesoDatosPresentacion.ConsultarPresentacionPorCodigoEAN(presentacion.CodigoEAN);
            if (PresentacionArticuloEnBD.IdPresentacionArticulo != presentacion.IdPresentacionArticulo && PresentacionArticuloEnBD.IdPresentacionArticulo != 0)
            {
                Mensaje mensaje = Mensajes.LinqToXml.LeerMensaje("0099");
                mensaje.Texto += ". " + PresentacionArticuloEnBD.Nombre;
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(mensaje.Texto));
                return new ResultadoTransaccion() { RegistrosAfectados = 0, Mensaje = mensaje };
            }

            return AccesoDatosPresentacion.Actualizar(presentacion, kardex);
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.PresentacionArticulo> Listar(int idArticulo)
        {
            AccesoDatos.TablasMaestras.PresentacionArticulo Presentacion = new AccesoDatos.TablasMaestras.PresentacionArticulo();
            return Presentacion.Listar(idArticulo);
        }

        public Entidades.ResultadoTransaccion Eliminar(int idPresentacionArticulo)
        {
            AccesoDatos.TablasMaestras.PresentacionArticulo Presentacion = new AccesoDatos.TablasMaestras.PresentacionArticulo();
            AccesoDatos.TablasMaestras.Carrito Carrito = new AccesoDatos.TablasMaestras.Carrito();
            Entidades.ResultadoTransaccion resultadoVerificarRelacionArticulo = null;
            AccesoDatos.Inventario.Kardex Kardex = null;

            // Verificar si hay ventas asociadas
            if (this.VerificarVentaArticulo(idPresentacionArticulo) == true)
            {
                // En caso de tener ventas relacionadas no se continua y se devuelve el mensaje para mostrar.
                resultadoVerificarRelacionArticulo = new Entidades.ResultadoTransaccion();
                resultadoVerificarRelacionArticulo.RegistrosAfectados = 0;
                Entidades.Mensaje mensaje = Mensajes.LinqToXml.LeerMensaje("0079");
                resultadoVerificarRelacionArticulo.Mensaje = mensaje;
                return resultadoVerificarRelacionArticulo;
            }

            // Comprobar si hay movimientos relacinoados en el kardex
            Kardex = new AccesoDatos.Inventario.Kardex();
            if (Kardex.VerificarRelacionPresentacionArticulo(idPresentacionArticulo) == true)
            {
                // Si tiene movimientos asociados
                // En caso de tener ventas relacionadas no se continua y se devuelve el mensaje para mostrar.
                resultadoVerificarRelacionArticulo = new Entidades.ResultadoTransaccion();
                resultadoVerificarRelacionArticulo.RegistrosAfectados = 0;
                Entidades.Mensaje mensaje = Mensajes.LinqToXml.LeerMensaje("0080");
                resultadoVerificarRelacionArticulo.Mensaje = mensaje;
                return resultadoVerificarRelacionArticulo;
            }

            // Eliminar elementos de carrito
            Carrito.EliminarPorIdPresentacionArticulo(idPresentacionArticulo);

            return Presentacion.Eliminar(idPresentacionArticulo);
        }

        public Entidades.ResultadoTransaccion ActivarInactivarPorArticulo(int idPresentacion, Entidades.Enumeraciones.Estado estado)
        {
            AccesoDatos.TablasMaestras.PresentacionArticulo Presentacion = new AccesoDatos.TablasMaestras.PresentacionArticulo();
            return Presentacion.ActivarInactivarPorArticulo(idPresentacion, estado);
        }

        public bool VerificarVentaArticulo(int idPresentacionArticulo)
        {
            AccesoDatos.TablasMaestras.PresentacionArticulo Presentacion = new AccesoDatos.TablasMaestras.PresentacionArticulo();
            return Presentacion.VerificarVentaArticulo(idPresentacionArticulo);
        }

        public bool VerificarRelacionCarrito(int idPresentacionArticulo)
        {
            throw new NotImplementedException();
        }

        public ReadOnlyCollection<Entidades.PresentacionArticulo> ListarTodo()
        {
            AccesoDatos.TablasMaestras.PresentacionArticulo Presentacion = new AccesoDatos.TablasMaestras.PresentacionArticulo();
            return Presentacion.ListarTodo();
        }

        public ReadOnlyCollection<Entidades.PresentacionArticulo> ListarPendientesActualizacion()
        {
            AccesoDatos.TablasMaestras.PresentacionArticulo Presentacion = new AccesoDatos.TablasMaestras.PresentacionArticulo();
            return Presentacion.ListarPendientesActualizacion();
        }

        public ReadOnlyCollection<Entidades.PresentacionArticulo> ListarActivos()
        {
            AccesoDatos.TablasMaestras.PresentacionArticulo Presentacion = new AccesoDatos.TablasMaestras.PresentacionArticulo();
            return Presentacion.ListarActivos();
        }

        public ResultadoTransaccion ActivarInactivarEnLineaPorArticulo(int idArticulo, Estado estado)
        {
            AccesoDatos.TablasMaestras.PresentacionArticulo Presentacion = new AccesoDatos.TablasMaestras.PresentacionArticulo();
            return Presentacion.ActivarInactivarEnLineaPorArticulo(idArticulo, estado);
        }

        public ResultadoTransaccion ActivarInactivarPreordenPorArticulo(int idArticulo, Estado estado)
        {
            AccesoDatos.TablasMaestras.PresentacionArticulo Presentacion = new AccesoDatos.TablasMaestras.PresentacionArticulo();
            return Presentacion.ActivarInactivarPreordenPorArticulo(idArticulo, estado);
        }

        public Entidades.PresentacionArticulo ConsultarPorId(int idPresentacionArticulo)
        {
            AccesoDatos.TablasMaestras.PresentacionArticulo Presentacion = new AccesoDatos.TablasMaestras.PresentacionArticulo();
            return Presentacion.ConsultarPorId(idPresentacionArticulo);
        }

        private void ReordernarImagenes(ref Entidades.PresentacionArticulo presentacion, ref System.Collections.Generic.List<byte[]> lista)
        {
            if (presentacion.Imagen1 != null)
            {
                lista.Add(presentacion.Imagen1);
            }

            if (presentacion.Imagen2 != null)
            {
                lista.Add(presentacion.Imagen2);
            }

            if (presentacion.Imagen3 != null)
            {
                lista.Add(presentacion.Imagen3);
            }

            if (presentacion.Imagen4 != null)
            {
                lista.Add(presentacion.Imagen4);
            }

            if (presentacion.Imagen5 != null)
            {
                lista.Add(presentacion.Imagen5);
            }

            if (presentacion.Imagen6 != null)
            {
                lista.Add(presentacion.Imagen6);
            }

            presentacion.Imagen1 = null;
            presentacion.Imagen2 = null;
            presentacion.Imagen3 = null;
            presentacion.Imagen4 = null;
            presentacion.Imagen5 = null;
            presentacion.Imagen6 = null;

            if (lista.Count() > 0)
            {
                presentacion.Imagen1 = lista[0];
            }

            if (lista.Count() > 1)
            {
                presentacion.Imagen2 = lista[1];
            }

            if (lista.Count() > 2)
            {
                presentacion.Imagen3 = lista[2];
            }

            if (lista.Count() > 3)
            {
                presentacion.Imagen4 = lista[3];
            }

            if (lista.Count() > 4)
            {
                presentacion.Imagen5 = lista[4];
            }

            if (lista.Count() > 5)
            {
                presentacion.Imagen6 = lista[5];
            }
        }

        private void ControlarFechas(ref Entidades.PresentacionArticulo presentacion)
        {
            DateTime FechaMinimaSeleccionable = new DateTime(2020, 01, 01);

            // Fecha Mínima de Vencimiento Seleccionable y Fecha Minima a Guardar 01/01/2020
            if (presentacion.FechaProximoVencimiento < FechaMinimaSeleccionable)
            {
                // Cambiar fecha mínima seleccoinable para evitar inconvenientes con el DateTimePicker de presentación
                presentacion.FechaProximoVencimiento = FechaMinimaSeleccionable;
            }

            // // Fecha Mínima de Inicio de Descuento Seleccionable y Fecha Minima a Guardar 01/01/2020
            if (presentacion.FechaInicioDescuento < FechaMinimaSeleccionable)
            {
                // Cambiar la fecha de inicio de descuento seleccionable para evitar inconvenientes con el DateTimePicker
                presentacion.FechaInicioDescuento = FechaMinimaSeleccionable;
            }

            // Si la fechas de inicio y final de descuento no tienen sentido, se igualan
            if (presentacion.FechaInicioDescuento > presentacion.FechaFinalDescuento)
            {
                presentacion.FechaInicioDescuento = presentacion.FechaFinalDescuento;
            }
        }

        public Entidades.PresentacionArticulo ConsultarPresentacionPorCodigoEAN(string CodigoEAN)
        {
            AccesoDatos.TablasMaestras.PresentacionArticulo Presentacion = new AccesoDatos.TablasMaestras.PresentacionArticulo();
            return Presentacion.ConsultarPresentacionPorCodigoEAN(CodigoEAN);
        }

        public int ConsultarExistenciasPresentacionArticulo(long IdPresentacionArticulo)
        {
            AccesoDatos.TablasMaestras.PresentacionArticulo Presentacion = new AccesoDatos.TablasMaestras.PresentacionArticulo();
            return Presentacion.ConsultarExistenciasPresentacionArticulo(IdPresentacionArticulo);
        }
    }
}
