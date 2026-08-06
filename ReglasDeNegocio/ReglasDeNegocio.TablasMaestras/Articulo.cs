// -----------------------------------------------------------------------
// <copyright file="Articulo.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// ----------------------------------------------------------------------
namespace ReglasDENegocio.TablasMaestras
{
    using System;

    /// <summary>
    /// Formulario para la administración de artículos en la base de datos por operaciones CRUD
    /// </summary>
    public class Articulo : Contratos.IArticulos
    {
        /// <summary>
        /// Inserta un Artículo nuevo en la base de datos.
        /// </summary>
        /// <param name="articulo">Objeto con los datos que se desean insertar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        public Entidades.ResultadoTransaccion Insertar(Entidades.Articulo articulo)
        {
            Entidades.Mensaje mensaje = null;

            if (this.ValidacionCasillasBusqueda(articulo) == false)
            {
                // no se cumplen las directivas de tener 3 check como maximo.
                Entidades.ResultadoTransaccion resultado = new Entidades.ResultadoTransaccion();
                resultado.RegistrosAfectados = 0;
                mensaje = Mensajes.LinqToXml.LeerMensaje("0033"); 
                resultado.Mensaje = mensaje;
                return resultado;
            }

            AccesoDatos.TablasMaestras.Articulo Articulo = new AccesoDatos.TablasMaestras.Articulo();

            Utilidades.QuitaAcentos(articulo.Titulo);

            return Articulo.Insertar(articulo);
        }

        /// <summary>
        /// Actualiza los datos de un artículo en la base de datos.
        /// </summary>
        /// <param name="articulo">Objeto con los datos que se desean actualizar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        public Entidades.ResultadoTransaccion Actualizar(Entidades.Articulo articulo)
        {
            AccesoDatos.TablasMaestras.Articulo articulos = new AccesoDatos.TablasMaestras.Articulo();
            AccesoDatos.TablasMaestras.PresentacionArticulo PresentacionArticulo = new AccesoDatos.TablasMaestras.PresentacionArticulo();

            // Actualizar en cascada para las presentaciones los Campos Activo, EnLinea y PreOrdenar
            if (articulo.Activo == true)
            {
                PresentacionArticulo.ActivarInactivarPorArticulo(articulo.IdArticulo, Entidades.Enumeraciones.Estado.Habilitado);
            }
            else
            {
                PresentacionArticulo.ActivarInactivarPorArticulo(articulo.IdArticulo, Entidades.Enumeraciones.Estado.Inhabilitado);
            }

            if (articulo.ENLinea == true)
            {
                PresentacionArticulo.ActivarInactivarEnLineaPorArticulo(articulo.IdArticulo, Entidades.Enumeraciones.Estado.Habilitado);
            }
            else
            {
                PresentacionArticulo.ActivarInactivarEnLineaPorArticulo(articulo.IdArticulo, Entidades.Enumeraciones.Estado.Inhabilitado);
            }

            if (articulo.PreOrdenar == true)
            {
                PresentacionArticulo.ActivarInactivarPreordenPorArticulo(articulo.IdArticulo, Entidades.Enumeraciones.Estado.Habilitado);
            }
            else
            {
                PresentacionArticulo.ActivarInactivarPreordenPorArticulo(articulo.IdArticulo, Entidades.Enumeraciones.Estado.Inhabilitado);
            }

            Utilidades.QuitaAcentos(articulo.Titulo);

            return articulos.Actualizar(articulo);
        }

        /// <summary>
        /// Elimina el registro de un artículo existente en la base de datos.
        /// </summary>
        /// <param name="idarticulo">identificador acceder al registro que se va a eliminar</param>
        /// <returns>1 si la operación fué exitosa, 0 sino fué exitosa</returns>
        public Entidades.ResultadoTransaccion Eliminar(int idarticulo)
        {
            AccesoDatos.TablasMaestras.Articulo articulos = new AccesoDatos.TablasMaestras.Articulo();
            AccesoDatos.TablasMaestras.PresentacionArticulo presentacionArticulo = new AccesoDatos.TablasMaestras.PresentacionArticulo();
            System.Collections.ObjectModel.ReadOnlyCollection<Entidades.PresentacionArticulo> PresentacionesArticulo = presentacionArticulo.Listar(idarticulo);

            // Verificar que el artículo no tenga presentaciones de artículo en el sistema
            if (PresentacionesArticulo != null)
            {
                if (PresentacionesArticulo.Count > 0)
                {
                    Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();
                    resultadoTransaccion.RegistrosAfectados = 0;
                    resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0059");
                    Logging.ErrorGeneral.Guardar(new Exception(resultadoTransaccion.Mensaje.Texto));
                    return resultadoTransaccion;
                }
            }

            return articulos.Eliminar(idarticulo);
        }

        /// <summary>
        /// Obtiene la lista de artículos de la base de datos.
        /// </summary>
        /// <returns>Lista de entidades de tipo Entidades.Artículo</returns>
        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Articulo> Listar()
        {
            AccesoDatos.TablasMaestras.Articulo articulos = new AccesoDatos.TablasMaestras.Articulo();
            return articulos.Listar();
        }

        /// <summary>
        /// verifica que sean seleccionados tres filtros de búsqueda como máximo
        /// </summary>
        /// <param name="articulo">Objeto con los datos que se desean validar</param>
        /// <returns>Retorna falso cuando se seleccionaron más de tres filtros</returns>
        public bool ValidacionCasillasBusqueda(Entidades.Articulo articulo)
        {
            byte chkMarcado = 0;
            if (articulo == null)
            {
                Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();
                resultadoTransaccion.RegistrosAfectados = 0;
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
            }
            else
            {
                if (articulo.UnidadVolumen == true)
                {
                   chkMarcado++;
                }

                if (articulo.UnidadMasa == true)
                {
                    chkMarcado++;
                }

                if (articulo.UnidadLongitud == true)
                {
                    chkMarcado++;
                }

                if (articulo.Talla == true)
                {
                    chkMarcado++;
                }

                if (articulo.Color == true)
                {
                    chkMarcado++;
                }
                if (articulo.Sabor == true)
                {
                    chkMarcado++;
                }

            }
            
            if (chkMarcado > 3 )
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Obtiene la lista por estado de artículos de la base de datos.
        /// </summary>
        /// <returns>Lista de entidades de tipo Entidades.Artículo</returns>
        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Articulo> ListarPorEstado(Entidades.Enumeraciones.EstadoInventario estado)
        {
            AccesoDatos.TablasMaestras.Articulo articulos = new AccesoDatos.TablasMaestras.Articulo();
            return articulos.ListarPorEstado(estado);
        }


    }
}