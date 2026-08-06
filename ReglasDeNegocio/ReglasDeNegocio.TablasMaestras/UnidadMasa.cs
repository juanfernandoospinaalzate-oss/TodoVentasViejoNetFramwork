// -----------------------------------------------------------------------
// <copyright file="UnidadMasa.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// ---------------------------------------------------------------------

namespace ReglasDENegocio.TablasMaestras
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
            AccesoDatos.TablasMaestras.UnidadMasa unidadesMasa = new AccesoDatos.TablasMaestras.UnidadMasa();

            // Investigar si el texto ingresado es un texto duplicado para la tabla, en caso positivo no se inserta y se devuelve mensaje el de error
            if (unidadesMasa.UnidadMasaVerificarDuplicidad(unidadMasa))
            {
                Entidades.ResultadoTransaccion resultadoUnidadMasaVerificarDuplicidad = new Entidades.ResultadoTransaccion();
                resultadoUnidadMasaVerificarDuplicidad.RegistrosAfectados = 0;
                Entidades.Mensaje mensaje = Mensajes.LinqToXml.LeerMensaje("0011");
                resultadoUnidadMasaVerificarDuplicidad.Mensaje = mensaje;
                return resultadoUnidadMasaVerificarDuplicidad;
            }

            return unidadesMasa.Insertar(unidadMasa);
        }

        /// <summary>
        /// Actualiza una unidad de masa nueva existente en la base de datos
        /// </summary>
        /// <param name="unidadMasa">Objeto con los datos que se desean actualizar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        public Entidades.ResultadoTransaccion Actualizar(Entidades.UnidadMasa unidadMasa)
        {
            AccesoDatos.TablasMaestras.UnidadMasa unidadesMasa = new AccesoDatos.TablasMaestras.UnidadMasa();
            if (unidadesMasa.UnidadMasaVerificarDuplicidad(unidadMasa))
            {
                Entidades.ResultadoTransaccion resultadoUnidadMasaVerificarDuplicidad = new Entidades.ResultadoTransaccion();
                resultadoUnidadMasaVerificarDuplicidad.RegistrosAfectados = 0;
                Entidades.Mensaje mensaje = Mensajes.LinqToXml.LeerMensaje("0015");
                resultadoUnidadMasaVerificarDuplicidad.Mensaje = mensaje;
                return resultadoUnidadMasaVerificarDuplicidad;
            }

            return unidadesMasa.Actualizar(unidadMasa);
        }

        /// <summary>
        /// Elimina el registro de una unidad de masa existente en la base de datos.
        /// </summary>
        /// <param name="idmasa">identificador acceder al registro que se va a eliminar</param>
        /// <returns>1 si la operación fué exitosa, 0 sino fué exitosa</returns>
        public Entidades.ResultadoTransaccion Eliminar(int idmasa)
        {            
            AccesoDatos.TablasMaestras.UnidadMasa unidadesMasa = new AccesoDatos.TablasMaestras.UnidadMasa();

            // Verificar si hay presentaciones de artículo asociadas a la unidad de masa que se intenta eliminar, en caso de ser positivo, no se elimina y se retorna mensaje de error.
            if (unidadesMasa.UnidadMasaVerificarRelacionArticulo(idmasa))
            {
                Entidades.ResultadoTransaccion resultadoUnidadMasaVerificarRelacionArticulo = new Entidades.ResultadoTransaccion();
                resultadoUnidadMasaVerificarRelacionArticulo.RegistrosAfectados = 0;
                Entidades.Mensaje mensaje = Mensajes.LinqToXml.LeerMensaje("0002");
                resultadoUnidadMasaVerificarRelacionArticulo.Mensaje = mensaje;
                return resultadoUnidadMasaVerificarRelacionArticulo;
            }

            return unidadesMasa.Eliminar(idmasa);
        }

        /// <summary>
        /// Obtiene la lista de unidades de masa almacenada en la base de datos 
        /// </summary>
        /// <returns>Lista de entidades de tipo Entidades.UnidadMasa</returns>
        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.UnidadMasa> Listar()
        {
            AccesoDatos.TablasMaestras.UnidadMasa unidadesMasa = new AccesoDatos.TablasMaestras.UnidadMasa();
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
