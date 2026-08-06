// -----------------------------------------------------------------------
// <copyright file="UnidadMasa.svc.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// ----------------------------------------------------------------------

namespace ServiciosWeb.TablasMaestras
{
    using System;

    /// <summary>
    /// Formulario para la administración de unidades de masa en la base de datos por operaciones CRUD
    /// </summary>
    public class UnidadMasa : Contratos.IUnidadMasa
    {
        /// <summary>
        /// Ingresa una unidad de masa nueva en la base de datos
        /// </summary>
        /// <param name="unidadMasa">Objeto con los datos que se desean insertar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        public Entidades.ResultadoTransaccion Insertar(Entidades.UnidadMasa unidadMasa)
        {
            Validacion.TablasMaestras.UnidadMasa unidadesMasa = new Validacion.TablasMaestras.UnidadMasa();
            return unidadesMasa.Insertar(unidadMasa);
        }

        /// <summary>
        /// Actualiza una unidad de masa nueva existente en la base de datos
        /// </summary>
        /// <param name="unidadMasa">Objeto con los datos que se desean actualizar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        public Entidades.ResultadoTransaccion Actualizar(Entidades.UnidadMasa unidadMasa)
        {
            Validacion.TablasMaestras.UnidadMasa unidadesMasa = new Validacion.TablasMaestras.UnidadMasa();
            return unidadesMasa.Actualizar(unidadMasa);
        }

        /// <summary>
        /// Elimina el registro de una unidad de masa existente en la base de datos.
        /// </summary>
        /// <param name="idmasa">identificador acceder al registro que se va a eliminar</param>
        /// <returns>1 si la operación fué exitosa, 0 sino fué exitosa</returns>
        public Entidades.ResultadoTransaccion Eliminar(int idmasa)
        {
            Validacion.TablasMaestras.UnidadMasa unidadesMasa = new Validacion.TablasMaestras.UnidadMasa();
            return unidadesMasa.Eliminar(idmasa);
        }

        /// <summary>
        /// Obtiene la lista de unidades de masa almacenada en la base de datos 
        /// </summary>
        /// <returns>Lista de entidades de tipo Entidades.UnidadMasa</returns>
        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.UnidadMasa> Listar()
        {
            Validacion.TablasMaestras.UnidadMasa unidadesMasa = new Validacion.TablasMaestras.UnidadMasa();
            return unidadesMasa.Listar();
        }

        /// <summary>
        /// Verifica si la unidad de masa ya existe en la base de datos.
        /// </summary>
        /// <param name="unidadMasa">Objeto con los datos que se desean verificar</param>
        /// <returns>indica si hay o no un registro relacionado.</returns>
        public bool UnidadMasaVerificarDuplicidad(Entidades.UnidadMasa unidadMasa)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Verifica Si el artículo a eliminar no está relacionado(asociado)a una Unidad de Masa.
        /// </summary>
        /// <param name="idmasa">variable con el dato a verificar </param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        public bool UnidadMasaVerificarRelacionArticulo(int idmasa)
        {
            throw new NotImplementedException();
        }
    }
}
