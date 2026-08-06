// -----------------------------------------------------------------------
// <copyright file="Marca.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace ReglasDENegocio.TablasMaestras
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
            AccesoDatos.TablasMaestras.Marca marcas = new AccesoDatos.TablasMaestras.Marca();
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();
            System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Marca> ListaMarcasConsultadas = null;

            ListaMarcasConsultadas = marcas.ListarPorNombre(marca.Nombre);

            // No permitir nombre de marca duplicada
            if (ListaMarcasConsultadas.Count > 0)
            {
                resultadoTransaccion.RegistrosAfectados = 0;
                Entidades.Mensaje mensaje = Mensajes.LinqToXml.LeerMensaje("0011");
                resultadoTransaccion.Mensaje.Texto = mensaje.Texto.Replace("<NOMBRE_ELEMENTO>", "Nombre");
                resultadoTransaccion.Mensaje = mensaje;
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
            AccesoDatos.TablasMaestras.Marca marcas = new AccesoDatos.TablasMaestras.Marca();
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();
            System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Marca> ListaMarcasConsultadas = null;

            ListaMarcasConsultadas = marcas.ListarPorNombre(marca.Nombre);

            // Ya se encuentra el nombre que se desea ingresar pero bajo otro ID, eso generaría registros duplicados
            // También controla cuando se utiliza un ID que no existe en la base de datos pero el nombre si fue encontrado
            if (ListaMarcasConsultadas.Count == 1 && ListaMarcasConsultadas[0].IdMarca != marca.IdMarca)
            {
                resultadoTransaccion.RegistrosAfectados = 0;
                Entidades.Mensaje mensaje = Mensajes.LinqToXml.LeerMensaje("0015");
                resultadoTransaccion.Mensaje = mensaje;
                return resultadoTransaccion;
            }

            // Ya hay duplicados en Bd para ese nombre
            if (ListaMarcasConsultadas.Count > 1)
            {
                resultadoTransaccion.RegistrosAfectados = 0;
                Entidades.Mensaje mensaje = Mensajes.LinqToXml.LeerMensaje("0015");
                resultadoTransaccion.Mensaje = mensaje;
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
            AccesoDatos.TablasMaestras.Marca marcas = new AccesoDatos.TablasMaestras.Marca();
            Entidades.ResultadoTransaccion ResultadoTransaccion = new ResultadoTransaccion();
            System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Marca> ListaMarcasConsultadas = null;

            // No eliminar si el Id no existe en Base de Datos
            ListaMarcasConsultadas = marcas.ListarPorId(idmarca);
            if (ListaMarcasConsultadas.Count == 0)
            {
                ResultadoTransaccion.RegistrosAfectados = 0;
                ResultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0008");
                return ResultadoTransaccion;
            }

            // No Eliminar si existe un Artículo asociado a la marca
            if (marcas.VerificarRelacionArticulo(idmarca) == true)
            {
                ResultadoTransaccion.RegistrosAfectados = 0;
                ResultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0002");
                return ResultadoTransaccion;
            }


            return marcas.Eliminar(idmarca);
        }

        /// <summary>
        /// Obtiene la lista de marca de la base de datos.
        /// </summary>
        /// <returns>Lista de entidades de tipo Entidades.Marca</returns>
        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Marca> Listar()
        {
            AccesoDatos.TablasMaestras.Marca marcas = new AccesoDatos.TablasMaestras.Marca();
            return marcas.Listar();
        }

        public ReadOnlyCollection<Entidades.Marca> ListarOrdenadoPorIdMarca()
        {
            AccesoDatos.TablasMaestras.Marca marcas = new AccesoDatos.TablasMaestras.Marca();
            return marcas.ListarOrdenadoPorIdMarca();
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Marca> ListarPorNombre(string marca)
        {
            AccesoDatos.TablasMaestras.Marca Marcas = new AccesoDatos.TablasMaestras.Marca();
            return Marcas.ListarPorNombre(marca);
        }

        public ReadOnlyCollection<Entidades.Marca> ListarPorId(int idMarca)
        {
            AccesoDatos.TablasMaestras.Marca Marcas = new AccesoDatos.TablasMaestras.Marca();
            return Marcas.ListarPorId(idMarca);
        }

        public bool VerificarRelacionArticulo(int idMarca)
        {
            AccesoDatos.TablasMaestras.Marca Marcas = new AccesoDatos.TablasMaestras.Marca();
            return Marcas.VerificarRelacionArticulo(idMarca);
        }
    }
}
