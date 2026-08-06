// -----------------------------------------------------------------------
// <copyright file="UnidadLongitud.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// ---------------------------------------------------------------------

namespace Validacion.TablasMaestras
{
    using System;

    /// <summary>
    /// Formulario para la administración de unidades de longitud en la base de datos por operaciones CRUD
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
            ReglasDENegocio.TablasMaestras.UnidadLongitud unidadesLongitud = new ReglasDENegocio.TablasMaestras.UnidadLongitud();
            return unidadesLongitud.Insertar(unidadLongitud);
        }

        /// <summary>
        /// Elimina el registro de una unidad de longitud existente en la base de datos.
        /// </summary>
        /// <param name="idlongitud">identificador acceder al registro que se va a eliminar</param>
        /// <returns>1 si la operación fué exitosa, 0 sino fué exitosa</returns>
        public Entidades.ResultadoTransaccion Eliminar(int idlongitud)
        {
            ReglasDENegocio.TablasMaestras.UnidadLongitud unidadesLongitud = new ReglasDENegocio.TablasMaestras.UnidadLongitud();
            return unidadesLongitud.Eliminar(idlongitud);
        }

        /// <summary>
        /// Actualiza los datos de una unidad de longitud en la base de datos.
        /// </summary>
        /// <param name="unidadLongitud">Objeto con los datos que se desean actualizar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        public Entidades.ResultadoTransaccion Actualizar(Entidades.UnidadLongitud unidadLongitud)
        {
            ReglasDENegocio.TablasMaestras.UnidadLongitud unidadesLongitud = new ReglasDENegocio.TablasMaestras.UnidadLongitud();
            return unidadesLongitud.Actualizar(unidadLongitud);
        }

        /// <summary>
        /// Obtiene la lista de unidades de longitud de la base de datos.
        /// </summary>
        /// <returns>Lista de entidades de tipo Entidades.UnidadLongitud</returns>
        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.UnidadLongitud> Listar()
        {
            ReglasDENegocio.TablasMaestras.UnidadLongitud unidadesLongitud = new ReglasDENegocio.TablasMaestras.UnidadLongitud();
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
