// -----------------------------------------------------------------------
// <copyright file="UnidadLongitud.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// ----------------------------------------------------------------------

namespace ReglasDENegocio.TablasMaestras
{
    using System;

    /// <summary>
    /// Administra las unidades de longitud
    /// </summary>
    public class UnidadLongitud : Contratos.IUnidadLongitud
    {
        /// <summary>
        /// Ingresa una unidad de longitud nueva en la base de datos
        /// </summary>
        /// <param name="unidadLongitud">Objeto con los datos que se desean insertar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        public Entidades.ResultadoTransaccion Insertar(Entidades.UnidadLongitud unidadLongitud)
        {
            AccesoDatos.TablasMaestras.UnidadLongitud unidadesLongitud = new AccesoDatos.TablasMaestras.UnidadLongitud();
            if (unidadesLongitud.UnidadLongitudVerificarDuplicidad(unidadLongitud))
            {
                Entidades.ResultadoTransaccion resultadoUnidadVolumenVerificarDuplicidad = new Entidades.ResultadoTransaccion();
                resultadoUnidadVolumenVerificarDuplicidad.RegistrosAfectados = 0;
                Entidades.Mensaje mensaje = Mensajes.LinqToXml.LeerMensaje("0011");
                resultadoUnidadVolumenVerificarDuplicidad.Mensaje = mensaje;
                return resultadoUnidadVolumenVerificarDuplicidad;
            }

            return unidadesLongitud.Insertar(unidadLongitud);
        }

        /// <summary>
        /// Elimina un registro de la tabla Unidad de Longitud
        /// </summary>
        /// <param name="idlongitud">identificador de la unidad de longitud</param>
        /// <returns>1 si la operación fué exitosa, 0 sino fué exitosa</returns>
        public Entidades.ResultadoTransaccion Eliminar(int idlongitud)
        {
            AccesoDatos.TablasMaestras.UnidadLongitud unidadesLongitud = new AccesoDatos.TablasMaestras.UnidadLongitud();
            if (unidadesLongitud.UnidadLongitudVerificarRelacionArticulo(idlongitud))
            {
                Entidades.ResultadoTransaccion resultadoUnidadVolumenVerificarRelacionArticulo = new Entidades.ResultadoTransaccion();
                resultadoUnidadVolumenVerificarRelacionArticulo.RegistrosAfectados = 0;
                Entidades.Mensaje mensaje = Mensajes.LinqToXml.LeerMensaje("0002");
                resultadoUnidadVolumenVerificarRelacionArticulo.Mensaje = mensaje;
                return resultadoUnidadVolumenVerificarRelacionArticulo;
            }

            return unidadesLongitud.Eliminar(idlongitud);
        }

        /// <summary>
        /// Actualiza un registro de la tabla Unidad Longitud en la base de datos.
        /// </summary>
        /// <param name="unidadLongitud">Objeto con los datos que se desean actualizar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        public Entidades.ResultadoTransaccion Actualizar(Entidades.UnidadLongitud unidadLongitud)
        {
            AccesoDatos.TablasMaestras.UnidadLongitud unidadesLongitud = new AccesoDatos.TablasMaestras.UnidadLongitud();
            if (unidadesLongitud.UnidadLongitudVerificarDuplicidad(unidadLongitud))
            {
                Entidades.ResultadoTransaccion resultadoUnidadVolumenVerificarRelacionArticulo = new Entidades.ResultadoTransaccion();
                resultadoUnidadVolumenVerificarRelacionArticulo.RegistrosAfectados = 0;
                Entidades.Mensaje mensaje = Mensajes.LinqToXml.LeerMensaje("0015");
                resultadoUnidadVolumenVerificarRelacionArticulo.Mensaje = mensaje;
                return resultadoUnidadVolumenVerificarRelacionArticulo;
            }

            return unidadesLongitud.Actualizar(unidadLongitud);
        }

        /// <summary>
        /// Lista los datos de la tabla Unidad Longitud de la base de datos.
        /// </summary>
        /// <returns>Lista de entidades de tipo Entidades.UnidadLongitud</returns>
        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.UnidadLongitud> Listar()
        {
            AccesoDatos.TablasMaestras.UnidadLongitud unidadesLongitud = new AccesoDatos.TablasMaestras.UnidadLongitud();
            return unidadesLongitud.Listar();
        }

        /// <summary>
        /// Verifica Si la Unidad de Longitud ya existe en la base de datos
        /// </summary>
        /// <param name="unidadLongitud">Objeto con los datos que se desean verificar</param>
        /// <returns>true si la unidad de longitud ya está registrado o false si la unidad de longitud no está registrado</returns>
        public bool UnidadLongitudVerificarDuplicidad(Entidades.UnidadLongitud unidadLongitud)
        {
            throw new NotImplementedException();
        }
    }
}
