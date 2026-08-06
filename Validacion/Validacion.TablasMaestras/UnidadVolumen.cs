// -----------------------------------------------------------------------
// <copyright file="UnidadVolumen.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// ---------------------------------------------------------------------

namespace Validacion.TablasMaestras
{
    using System;

    /// <summary>
    /// Formulario para la administración de unidades de volúmen en la base de datos por operaciones CRUD
    /// </summary>
    public class UnidadVolumen : Contratos.IUnidadVolumen
    {
        /// <summary>
        /// Ingresa una unidad de volúmen nueva en la base de datos
        /// </summary>
        /// <param name="unidadVolumen">Objeto con los datos que se desean insertar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        public Entidades.ResultadoTransaccion Insertar(Entidades.UnidadVolumen unidadVolumen)
        {
            ReglasDENegocio.TablasMaestras.UnidadVolumen unidadesVolumen = new ReglasDENegocio.TablasMaestras.UnidadVolumen();
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

            if (string.IsNullOrEmpty(unidadVolumen.Nombre))
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                return resultadoTransaccion;
            }

            return unidadesVolumen.Insertar(unidadVolumen);
        }

        /// <summary>
        /// Elimina una unidad de volúmen de la base de datos.
        /// </summary>
        /// <param name="idvolumen">identificador de la tabla unidad de volúmen</param>
        /// <returns>1 si la operación fué exitosa, 0 sino fué exitosa</returns>
        public Entidades.ResultadoTransaccion Eliminar(int idvolumen)
        {
            ReglasDENegocio.TablasMaestras.UnidadVolumen unidadesVolumen = new ReglasDENegocio.TablasMaestras.UnidadVolumen();
            return unidadesVolumen.Eliminar(idvolumen);
        }

        /// <summary>
        /// Obtiene la lista de unidades de volúmen almacenada en la base de datos
        /// </summary>
        /// <returns>Lista de entidades de tipo Entidades.UnidadMasa</returns>
        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.UnidadVolumen> Listar()
        {
            ReglasDENegocio.TablasMaestras.UnidadVolumen unidadesVolumen = new ReglasDENegocio.TablasMaestras.UnidadVolumen();
            return unidadesVolumen.Listar();
        }

        /// <summary>
        /// Verifica que la unidad de volúmen no está ingresada en la base de datos
        /// </summary>
        /// <param name="unidadVolumen">Objeto con los datos que se desean verificar</param>
        /// <returns>true si unidad de volúmen ya está registrado o false si la unidad de volúmen no está registrado</returns>
        public bool UnidadVolumenVerificarDuplicidad(Entidades.UnidadVolumen unidadVolumen)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Verifica que la unidad de volúmen NO esté relacionada(asociada) con un artículo
        /// </summary>
        /// <param name="idvolumen">Identificador de unidad de volúmen</param>
        /// <returns>indica si hay o no un registro relacionado.</returns>
        public bool UnidadVolumenVerificarRelacionArticulo(int idvolumen)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Actualiza una unidad de volúmen en la base de datos.
        /// </summary>
        /// <param name="unidadVolumen">Objeto con los datos que se desean actualizar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        public Entidades.ResultadoTransaccion Actualizar(Entidades.UnidadVolumen unidadVolumen)
        {
            ReglasDENegocio.TablasMaestras.UnidadVolumen unidadesVolumen = new ReglasDENegocio.TablasMaestras.UnidadVolumen();
            return unidadesVolumen.Actualizar(unidadVolumen);
        }
    }
}
