// -----------------------------------------------------------------------
// <copyright file="PresentacionArticulo.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// ----------------------------------------------------------------------
namespace Fachada.TablasMaestras
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
            ServicioPresentacionArticulo.PresentacionArticuloClient presentaciones = new ServicioPresentacionArticulo.PresentacionArticuloClient();
            return presentaciones.Insertar(presentacion, kardex);
        }

        public bool SubirImagen(byte[] imagen, string nombreImagen, char letraImagen, DateTime fechaOut)
        {
            ServicioPresentacionArticulo.PresentacionArticuloClient Presentacion = new ServicioPresentacionArticulo.PresentacionArticuloClient();
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
            ServicioPresentacionArticulo.PresentacionArticuloClient Presentacion = new ServicioPresentacionArticulo.PresentacionArticuloClient();
            return Presentacion.Actualizar(presentacion, kardex);
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.PresentacionArticulo> Listar(int IdArticulo)
        {
            ServicioPresentacionArticulo.PresentacionArticuloClient Presentacion = new ServicioPresentacionArticulo.PresentacionArticuloClient();
            return Presentacion.Listar(IdArticulo);
        }

        public Entidades.ResultadoTransaccion Eliminar(int idPresentacionArticulo)
        {
            ServicioPresentacionArticulo.PresentacionArticuloClient Presentacion = new ServicioPresentacionArticulo.PresentacionArticuloClient();
            return Presentacion.Eliminar(idPresentacionArticulo);
        }

        public Entidades.ResultadoTransaccion ActivarInactivarPorArticulo(int idPresentacion, Entidades.Enumeraciones.Estado estado)
        {
            ServicioPresentacionArticulo.PresentacionArticuloClient Presentacion = new ServicioPresentacionArticulo.PresentacionArticuloClient();
            return null;
        }

        public bool VerificarVentaArticulo(int idPresentacionArticulo)
        {
            ServicioPresentacionArticulo.PresentacionArticuloClient Presentacion = new ServicioPresentacionArticulo.PresentacionArticuloClient();
            return Presentacion.VerificarVentaArticulo(idPresentacionArticulo);
        }

        public bool VerificarRelacionCarrito(int idPresentacionArticulo)
        {
            throw new NotImplementedException();
        }

        public ReadOnlyCollection<Entidades.PresentacionArticulo> ListarTodo()
        {
            ServicioPresentacionArticulo.PresentacionArticuloClient Presentacion = new ServicioPresentacionArticulo.PresentacionArticuloClient();
            return Presentacion.ListarTodo();
        }

        public ReadOnlyCollection<Entidades.PresentacionArticulo> ListarPendientesActualizacion()
        {
            ServicioPresentacionArticulo.PresentacionArticuloClient Presentacion = new ServicioPresentacionArticulo.PresentacionArticuloClient();
            return Presentacion.ListarPendientesActualizacion();
        }

        public ReadOnlyCollection<Entidades.PresentacionArticulo> ListarActivos()
        {
            ServicioPresentacionArticulo.PresentacionArticuloClient Presentacion = new ServicioPresentacionArticulo.PresentacionArticuloClient();
            return Presentacion.ListarActivos();
        }

        public ResultadoTransaccion ActivarInactivarEnLineaPorArticulo(int idArticulo, Estado estado)
        {
            ServicioPresentacionArticulo.PresentacionArticuloClient Presentacion = new ServicioPresentacionArticulo.PresentacionArticuloClient();
            return Presentacion.ActivarInactivarEnLineaPorArticulo(idArticulo, estado);
        }

        public ResultadoTransaccion ActivarInactivarPreordenPorArticulo(int idArticulo, Estado estado)
        {
            ServicioPresentacionArticulo.PresentacionArticuloClient Presentacion = new ServicioPresentacionArticulo.PresentacionArticuloClient();
            return Presentacion.ActivarInactivarPreordenPorArticulo(idArticulo, estado);
        }

        public Entidades.PresentacionArticulo ConsultarPorId(int idPresentacionArticulo)
        {
            ServicioPresentacionArticulo.PresentacionArticuloClient Presentacion = new ServicioPresentacionArticulo.PresentacionArticuloClient();
            return Presentacion.ConsultarPorId(idPresentacionArticulo);
        }

        public Entidades.PresentacionArticulo ConsultarPresentacionPorCodigoEAN(string CodigoEAN)
        {
            ServicioPresentacionArticulo.PresentacionArticuloClient Presentacion = new ServicioPresentacionArticulo.PresentacionArticuloClient();
            return Presentacion.ConsultarPresentacionPorCodigoEAN(CodigoEAN);
        }

        public int ConsultarExistenciasPresentacionArticulo(long IdPresentacionArticulo)
        {
            ServicioPresentacionArticulo.PresentacionArticuloClient Presentacion = new ServicioPresentacionArticulo.PresentacionArticuloClient();
            return Presentacion.ConsultarExistenciasPresentacionArticulo(IdPresentacionArticulo);
        }
    }
}
