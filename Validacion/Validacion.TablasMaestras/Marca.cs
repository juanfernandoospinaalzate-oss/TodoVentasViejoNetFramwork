// -----------------------------------------------------------------------
// <copyright file="Marca.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace Validacion.TablasMaestras
{
    using System;
    using System.Collections.ObjectModel;
    using Entidades;

    /// <summary>
    /// Formulario para la administración de marcas en la base de datos por operaciones CRUD
    /// </summary>
    public class Marca : Contratos.IMarca
    {
        /// <summary>
        /// Inserta una marca nueva en la base de datos
        /// </summary>
        /// <param name="marca">Objeto con los datos que se desean insertar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        public Entidades.ResultadoTransaccion Insertar(Entidades.Marca marca)
        {
            ReglasDENegocio.TablasMaestras.Marca marcas = new ReglasDENegocio.TablasMaestras.Marca();
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

            // No recibir string vacío, nullo ni null
            if (string.IsNullOrWhiteSpace(marca.Nombre))
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                return resultadoTransaccion;
            }

            // No recibir más de 20 caracteres
            if (marca.Nombre.Length > 20)
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0014");
                resultadoTransaccion.Mensaje.Texto = resultadoTransaccion.Mensaje.Texto.Replace("<NOMBRE_CAMPO>", "Nombre");
                resultadoTransaccion.Mensaje.Texto = resultadoTransaccion.Mensaje.Texto.Replace("<CANTIDAD_CARACTERES>", "20");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                return resultadoTransaccion;
            }

            return marcas.Insertar(marca);
        }

        /// <summary>
        /// Actualiza los datos de un marca en la base de datos.
        /// </summary>
        /// <param name="marca">Objeto con los datos que se desean actualizar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        public Entidades.ResultadoTransaccion Actualizar(Entidades.Marca marca)
        {
            ReglasDENegocio.TablasMaestras.Marca marcas = new ReglasDENegocio.TablasMaestras.Marca();
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

            // No recibir string vacío, nullo ni null
            if (string.IsNullOrWhiteSpace(marca.Nombre))
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                return resultadoTransaccion;
            }

            // No recibir más de 20 caracteres
            if (marca.Nombre.Length > 20)
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0014");
                resultadoTransaccion.Mensaje.Texto = resultadoTransaccion.Mensaje.Texto.Replace("<NOMBRE_CAMPO>", "Nombre");
                resultadoTransaccion.Mensaje.Texto = resultadoTransaccion.Mensaje.Texto.Replace("<CANTIDAD_CARACTERES>", "20");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                return resultadoTransaccion;
            }

            return marcas.Actualizar(marca);
        }

        /// <summary>
        /// Elimina el registro de un marca existente en la base de datos.
        /// </summary>
        /// <param name="idmarca">identificador acceder al registro que se va a eliminar</param>
        /// <returns>1 si la operación fué exitosa, 0 sino fué exitosa</returns>
        public Entidades.ResultadoTransaccion Eliminar(int idmarca)
        {
            ReglasDENegocio.TablasMaestras.Marca marcas = new ReglasDENegocio.TablasMaestras.Marca();
            return marcas.Eliminar(idmarca);
        }

        /// <summary>
        /// Obtiene la lista de marca de la base de datos.
        /// </summary>
        /// <returns>Lista de entidades de tipo Entidades.Marca</returns>
        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Marca> Listar()
        {
            ReglasDENegocio.TablasMaestras.Marca marcas = new ReglasDENegocio.TablasMaestras.Marca();
            return marcas.Listar();
        }

        public ReadOnlyCollection<Entidades.Marca> ListarOrdenadoPorIdMarca()
        {
            ReglasDENegocio.TablasMaestras.Marca marcas = new ReglasDENegocio.TablasMaestras.Marca();
            return marcas.ListarOrdenadoPorIdMarca();
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Marca> ListarPorNombre(string marca)
        {
            ReglasDENegocio.TablasMaestras.Marca marcas = new ReglasDENegocio.TablasMaestras.Marca();

            // No recibir string vacío, nullo ni null
            if (string.IsNullOrWhiteSpace(marca))
            {
                string mensaje = Mensajes.LinqToXml.LeerMensaje("0016").Texto;
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(mensaje));
                return new ReadOnlyCollection<Entidades.Marca>(new System.Collections.Generic.List<Entidades.Marca>());
            }

            // No recibir más de 20 caracteres
            if (marca.Length > 20)
            {
                string mensaje = Mensajes.LinqToXml.LeerMensaje("0014").Texto;
                mensaje = mensaje.Replace("<NOMBRE_CAMPO>", "Nombre");
                mensaje = mensaje.Replace("<CANTIDAD_CARACTERES>", "20");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(mensaje));
                return new ReadOnlyCollection<Entidades.Marca>(new System.Collections.Generic.List<Entidades.Marca>());
            }

            return marcas.ListarPorNombre(marca);
        }

        public ReadOnlyCollection<Entidades.Marca> ListarPorId(int idMarca)
        {
            ReglasDENegocio.TablasMaestras.Marca marcas = new ReglasDENegocio.TablasMaestras.Marca();
            return marcas.ListarPorId(idMarca);
        }

        public bool VerificarRelacionArticulo(int idMarca)
        {
            ReglasDENegocio.TablasMaestras.Marca marcas = new ReglasDENegocio.TablasMaestras.Marca();
            return marcas.VerificarRelacionArticulo(idMarca);
        }
    }
}
