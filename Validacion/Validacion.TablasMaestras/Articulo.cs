// -----------------------------------------------------------------------
// <copyright file="Articulo.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// ---------------------------------------------------------------------
namespace Validacion.TablasMaestras
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
            ReglasDENegocio.TablasMaestras.Articulo articulos = new ReglasDENegocio.TablasMaestras.Articulo();
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();
            resultadoTransaccion.RegistrosAfectados = 0;

            // el sistema verifica que el articulo no sea nulo
            if (articulo == null)
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                return resultadoTransaccion;
            }

            // Buscar la marca que se intenta ingresar al artículo en la tabla de marcas
            ReglasDENegocio.TablasMaestras.Marca marca = new ReglasDENegocio.TablasMaestras.Marca();
            System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Marca> ListaMarcas = marca.Listar();
            bool resultadoBusquedaMarca = false;
            foreach (Entidades.Marca item in ListaMarcas)
            {
                if (item.IdMarca == articulo.Marca.IdMarca)
                {
                    resultadoBusquedaMarca = true;
                }
            }

            // si la marca que se intenta insertar no está en la tabla de marcas.
            if (resultadoBusquedaMarca == false)
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0026");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                return resultadoTransaccion;
            }

            // el sistema verifica que el campo (título) no se encuentre vacío.
            if (string.IsNullOrEmpty(articulo.Titulo.Trim()))
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0024");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                return resultadoTransaccion;
            }


            // el sistema verifica que el campo (descripción) no se encuentre vacío.
            if (string.IsNullOrEmpty(articulo.Descripcion.Trim()))
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0025");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                return resultadoTransaccion;
            }

            // el sistema verifica que el campo (descripción) no se encuentre vacío.
            if (string.IsNullOrEmpty(articulo.PalabrasRelacionArticulo.Trim()))
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0027");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                return resultadoTransaccion;
            }

            // El sistema verifica que se especifique una cantidad de meses de garantía o por lo menos una garantía de cero meses (Parte 1)
            if (string.IsNullOrEmpty(articulo.GarantiaMeses.ToString()))
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0028");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                return resultadoTransaccion;
            }

            // El sistema verifica que se especifique una cantidad de meses de garantía o por lo menos una garantía de cero meses (PArte 2)
            int garantiaMeses = int.MinValue;
            if (int.TryParse(articulo.GarantiaMeses.ToString(), out garantiaMeses) == false)
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0028");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                return resultadoTransaccion;
            }

            if (articulo.VideoYoutube != string.Empty)
            {
                Uri resultadoURL = null;
                bool urlValida = false;
                // verficar que sea una URI válida
                urlValida = Uri.TryCreate(articulo.VideoYoutube, UriKind.Absolute, out resultadoURL);

                if (resultadoURL == null)
                {
                    // si la url está mala
                    resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0029");
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                    return resultadoTransaccion;
                 }
                else
                {
                    // Si la url es válida, verificar que sea una url con esquema http
                    if (resultadoURL.Scheme != Uri.UriSchemeHttp)
                    {
                        resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0030");
                        Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                        return resultadoTransaccion;
                    }
                }
            }

            // el sistema verifica que el campo (metadescripción) no se encuentre vacío.
            if (string.IsNullOrEmpty(articulo.MetaDescripcion))
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0031");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                return resultadoTransaccion;
            }

            // el sistema verifica que el campo (metakeywords) no se encuentre vacío.
            if (string.IsNullOrEmpty(articulo.MetaKeyWords))
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0032");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                return resultadoTransaccion;
            }

            // Se cuentan los filtros activos porque no se permiten más de 3
            int contadorFiltrosActivos = int.MinValue;
            contadorFiltrosActivos = 0;
            if (articulo.UnidadVolumen == true)
            {
                contadorFiltrosActivos++;
            }

            if (articulo.UnidadMasa == true)
            {
                contadorFiltrosActivos++;
            }

            if (articulo.UnidadLongitud == true)
            {
                contadorFiltrosActivos++;
            }

            if (articulo.Talla == true)
            {
                contadorFiltrosActivos++;
            }

            if (articulo.Color == true)
            {
                contadorFiltrosActivos++;
            }

            if (articulo.Sabor == true)
            {
                contadorFiltrosActivos++;
            }

            // Si los filtros activos son más de 3 disparamos el error
            if (contadorFiltrosActivos > 3)
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0033");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                return resultadoTransaccion;
            }

            if (articulo.Categoria == null)
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0034");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                return resultadoTransaccion;
            }

            return articulos.Insertar(articulo);
        }

        /// <summary>
        /// Actualiza los datos de un artículo en la base de datos.
        /// </summary>
        /// <param name="articulo">Objeto con los datos que se desean actualizar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        public Entidades.ResultadoTransaccion Actualizar(Entidades.Articulo articulo)
        {
            ReglasDENegocio.TablasMaestras.Articulo articulos = new ReglasDENegocio.TablasMaestras.Articulo();
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();
            resultadoTransaccion.RegistrosAfectados = 0;

            //// el sistema verifica que el articulo no sea nulo
            if (articulo == null)
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                return resultadoTransaccion;
            }

            // Buscar la marca que se intenta ingresar al artículo en la tabla de marcas
            ReglasDENegocio.TablasMaestras.Marca marca = new ReglasDENegocio.TablasMaestras.Marca();
            System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Marca> ListaMarcas = marca.Listar();
            bool resultadoBusquedaMarca = false;
            foreach (Entidades.Marca item in ListaMarcas)
            {
                if (item.IdMarca == articulo.Marca.IdMarca)
                {
                    resultadoBusquedaMarca = true;
                }
            }

            // si la marca que se intenta insertar no está en la tabla de marcas.
            if (resultadoBusquedaMarca == false)
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0026");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                return resultadoTransaccion;
            }

            // el sistema verifica que el campo (título) no se encuentre vacío.
            if (string.IsNullOrEmpty(articulo.Titulo.Trim()))
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0024");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                return resultadoTransaccion;
            }


            // el sistema verifica que el campo (descripción) no se encuentre vacío.
            if (string.IsNullOrEmpty(articulo.Descripcion.Trim()))
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0025");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                return resultadoTransaccion;
            }

            // el sistema verifica que el campo (descripción) no se encuentre vacío.
            if (string.IsNullOrEmpty(articulo.PalabrasRelacionArticulo.Trim()))
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0027");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                return resultadoTransaccion;
            }

            // El sistema verifica que se especifique una cantidad de meses de garantía o por lo menos una garantía de cero meses (Parte 1)
            if (string.IsNullOrEmpty(articulo.GarantiaMeses.ToString()))
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0028");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                return resultadoTransaccion;
            }

            // El sistema verifica que se especifique una cantidad de meses de garantía o por lo menos una garantía de cero meses (PArte 2)
            int garantiaMeses = int.MinValue;
            if (int.TryParse(articulo.GarantiaMeses.ToString(), out garantiaMeses) == false)
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0028");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                return resultadoTransaccion;
            }

            if (articulo.VideoYoutube != string.Empty)
            {
                Uri resultadoURL = null;
                bool urlValida = false;
                // verficar que sea una URI válida
                urlValida = Uri.TryCreate(articulo.VideoYoutube, UriKind.Absolute, out resultadoURL);

                if (resultadoURL == null)
                {
                    // si la url está mala
                    resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0029");
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                    return resultadoTransaccion;
                }
                else
                {
                    // Si la url es válida, verificar que sea una url con esquema http
                    if (resultadoURL.Scheme != Uri.UriSchemeHttp)
                    {
                        resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0030");
                        Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                        return resultadoTransaccion;
                    }
                }
            }

            // el sistema verifica que el campo (metadescripción) no se encuentre vacío.
            if (string.IsNullOrEmpty(articulo.MetaDescripcion))
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0031");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                return resultadoTransaccion;
            }

            // el sistema verifica que el campo (metakeywords) no se encuentre vacío.
            if (string.IsNullOrEmpty(articulo.MetaKeyWords))
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0032");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                return resultadoTransaccion;
            }

            // Se cuentan los filtros activos porque no se permiten más de 3
            int contadorFiltrosActivos = int.MinValue;
            contadorFiltrosActivos = 0;
            if (articulo.UnidadVolumen == true)
            {
                contadorFiltrosActivos++;
            }

            if (articulo.UnidadMasa == true)
            {
                contadorFiltrosActivos++;
            }

            if (articulo.UnidadLongitud == true)
            {
                contadorFiltrosActivos++;
            }

            if (articulo.Talla == true)
            {
                contadorFiltrosActivos++;
            }

            if (articulo.Color == true)
            {
                contadorFiltrosActivos++;
            }

            if (articulo.Sabor == true)
            {
                contadorFiltrosActivos++;
            }

            // Si los filtros activos son más de 3 disparamos el error
            if (contadorFiltrosActivos > 3)
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0033");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                return resultadoTransaccion;
            }

            if (articulo.Categoria == null)
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0034");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                return resultadoTransaccion;
            }

            return articulos.Actualizar(articulo);
        }

        /// <summary>
        /// Elimina el registro de un artículo existente en la base de datos.
        /// </summary>
        /// <param name="idarticulo">identificador acceder al registro que se va a eliminar</param>
        /// <returns>1 si la operación fué exitosa, 0 sino fué exitosa</returns>
        public Entidades.ResultadoTransaccion Eliminar(int idarticulo)
        {
            ReglasDENegocio.TablasMaestras.Articulo articulos = new ReglasDENegocio.TablasMaestras.Articulo();
            return articulos.Eliminar(idarticulo);
        }

        /// <summary>
        /// Obtiene la lista de artículos de la base de datos.
        /// </summary>
        /// <returns>Lista de entidades de tipo Entidades.Artículo</returns>
        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Articulo> Listar()
        {
            ReglasDENegocio.TablasMaestras.Articulo articulos = new ReglasDENegocio.TablasMaestras.Articulo();
            return articulos.Listar();
        }

        /// <summary>
        /// verifica que sean seleccionados uno o dos filtros de búsqueda como máximo
        /// </summary>
        /// <param name="articulo">Objeto con los datos que se desean validar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        public bool ValidacionCasillasBusqueda(Entidades.Articulo articulo)
        {
            ReglasDENegocio.TablasMaestras.Articulo articulos = new ReglasDENegocio.TablasMaestras.Articulo();
            return articulos.ValidacionCasillasBusqueda(articulo);
        }

        /// <summary>
        /// Obtiene la lista por estado de artículos de la base de datos.
        /// </summary>
        /// <returns>Lista de entidades de tipo Entidades.Artículo</returns>
        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Articulo> ListarPorEstado(Entidades.Enumeraciones.EstadoInventario estado)
        {
            ReglasDENegocio.TablasMaestras.Articulo articulos = new ReglasDENegocio.TablasMaestras.Articulo();
            return articulos.ListarPorEstado(estado);

        }
    }
}
