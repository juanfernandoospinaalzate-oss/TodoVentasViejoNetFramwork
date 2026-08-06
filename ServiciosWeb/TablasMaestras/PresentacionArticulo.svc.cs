// -----------------------------------------------------------------------
// <copyright file="PresentacionArticulo.svc.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// --------------------------------------------------------------------

namespace ServiciosWeb.TablasMaestras
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
            Validacion.TablasMaestras.PresentacionArticulo presentaciones = new Validacion.TablasMaestras.PresentacionArticulo();
            return presentaciones.Insertar(presentacion, kardex);
        }


        public bool SubirImagen(byte[] imagen, string nombreImagen, char letraImagen, DateTime fechaOut)
        {
            Validacion.TablasMaestras.PresentacionArticulo Presentacion = new Validacion.TablasMaestras.PresentacionArticulo();
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
            Validacion.TablasMaestras.PresentacionArticulo Presentacion = new Validacion.TablasMaestras.PresentacionArticulo();
            return Presentacion.Actualizar(presentacion, kardex);
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.PresentacionArticulo> Listar(int idArticulo)
        {
            Validacion.TablasMaestras.PresentacionArticulo Presentacion = new Validacion.TablasMaestras.PresentacionArticulo();
            return Presentacion.Listar(idArticulo);
        }


        public Entidades.ResultadoTransaccion Eliminar(int idPresentacionArticulo)
        {
            Validacion.TablasMaestras.PresentacionArticulo Presentacion = new Validacion.TablasMaestras.PresentacionArticulo();
            return Presentacion.Eliminar(idPresentacionArticulo);
        }

        public Entidades.ResultadoTransaccion ActivarInactivarPorArticulo(int idPresentacion, Entidades.Enumeraciones.Estado estado)
        {
            Validacion.TablasMaestras.PresentacionArticulo Presentacion = new Validacion.TablasMaestras.PresentacionArticulo();
            return Presentacion.ActivarInactivarPorArticulo(idPresentacion, estado);
        }

        public bool VerificarVentaArticulo(int idPresentacionArticulo)
        {
            Validacion.TablasMaestras.PresentacionArticulo Presentacion = new Validacion.TablasMaestras.PresentacionArticulo();
            return Presentacion.VerificarVentaArticulo(idPresentacionArticulo);
        }

        public bool VerificarRelacionCarrito(int idPresentacionArticulo)
        {
            throw new NotImplementedException();
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.PresentacionArticulo> ListarTodo()
        {
            Validacion.TablasMaestras.PresentacionArticulo Presentacion = new Validacion.TablasMaestras.PresentacionArticulo();
            return Presentacion.ListarTodo();
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.PresentacionArticulo> ListarPendientesActualizacion()
        {
            Validacion.TablasMaestras.PresentacionArticulo Presentacion = new Validacion.TablasMaestras.PresentacionArticulo();
            return Presentacion.ListarPendientesActualizacion();
        }

        public ReadOnlyCollection<Entidades.PresentacionArticulo> ListarActivos()
        {
            Validacion.TablasMaestras.PresentacionArticulo Presentacion = new Validacion.TablasMaestras.PresentacionArticulo();
            return Presentacion.ListarActivos();
        }

        public ResultadoTransaccion ActivarInactivarEnLineaPorArticulo(int idArticulo, Estado estado)
        {
            Validacion.TablasMaestras.PresentacionArticulo Presentacion = new Validacion.TablasMaestras.PresentacionArticulo();
            return Presentacion.ActivarInactivarEnLineaPorArticulo(idArticulo, estado);
        }

        public ResultadoTransaccion ActivarInactivarPreordenPorArticulo(int idArticulo, Estado estado)
        {
            Validacion.TablasMaestras.PresentacionArticulo Presentacion = new Validacion.TablasMaestras.PresentacionArticulo();
            return Presentacion.ActivarInactivarPreordenPorArticulo(idArticulo, estado);
        }

        public Entidades.PresentacionArticulo ConsultarPorId(int idPresentacionArticulo)
        {
            Validacion.TablasMaestras.PresentacionArticulo Presentacion = new Validacion.TablasMaestras.PresentacionArticulo();
            return Presentacion.ConsultarPorId(idPresentacionArticulo);
        }

        public Entidades.PresentacionArticulo ConsultarPresentacionPorCodigoEAN(string CodigoEAN)
        {
            Validacion.TablasMaestras.PresentacionArticulo Presentacion = new Validacion.TablasMaestras.PresentacionArticulo();
            return Presentacion.ConsultarPresentacionPorCodigoEAN(CodigoEAN);
        }

        public int ConsultarExistenciasPresentacionArticulo(long IdPresentacionArticulo)
        {
            Validacion.TablasMaestras.PresentacionArticulo Presentacion = new Validacion.TablasMaestras.PresentacionArticulo();
            return Presentacion.ConsultarExistenciasPresentacionArticulo(IdPresentacionArticulo);
        }
    }
}
