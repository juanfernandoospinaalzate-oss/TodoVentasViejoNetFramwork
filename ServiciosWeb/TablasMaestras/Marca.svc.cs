// -----------------------------------------------------------------------
// <copyright file="Marca.svc.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace ServiciosWeb.TablasMaestras
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
            Validacion.TablasMaestras.Marca marcas = new Validacion.TablasMaestras.Marca();
            return marcas.Insertar(marca);
        }

        /// <summary>
        /// Actualiza los datos de un marca en la base de datos.
        /// </summary>
        /// <param name="marca">Objeto con los datos que se desean actualizar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        public Entidades.ResultadoTransaccion Actualizar(Entidades.Marca marca)
        {
            Validacion.TablasMaestras.Marca marcas = new Validacion.TablasMaestras.Marca();
            return marcas.Actualizar(marca);
        }

        /// <summary>
        /// Elimina el registro de un marca existente en la base de datos.
        /// </summary>
        /// <param name="idmarca">identificador acceder al registro que se va a eliminar</param>
        /// <returns>1 si la operación fué exitosa, 0 sino fué exitosa</returns>
        public Entidades.ResultadoTransaccion Eliminar(int idmarca)
        {
            Validacion.TablasMaestras.Marca marcas = new Validacion.TablasMaestras.Marca();
            return marcas.Eliminar(idmarca);
        }

        /// <summary>
        /// Obtiene la lista de marca de la base de datos.
        /// </summary>
        /// <returns>Lista de entidades de tipo Entidades.Marca</returns>
        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Marca> Listar()
        {
            Validacion.TablasMaestras.Marca marcas = new Validacion.TablasMaestras.Marca();
            return marcas.Listar();
        }

        /// <summary>
        /// Obtiene la lista de marca de la base de datos ordenada por el id de marca.
        /// </summary>
        /// <returns>Lista de entidades de tipo Entidades.Marca</returns>
        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Marca> ListarOrdenadoPorIdMarca()
        {
            Validacion.TablasMaestras.Marca marcas = new Validacion.TablasMaestras.Marca();
            return marcas.ListarOrdenadoPorIdMarca();
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Marca> ListarPorNombre(string marca)
        {
            Validacion.TablasMaestras.Marca marcas = new Validacion.TablasMaestras.Marca();
            return marcas.ListarPorNombre(marca);
        }

        public ReadOnlyCollection<Entidades.Marca> ListarPorId(int idMarca)
        {
            Validacion.TablasMaestras.Marca marcas = new Validacion.TablasMaestras.Marca();
            return marcas.ListarPorId(idMarca);
        }

        public bool VerificarRelacionArticulo(int idMarca)
        {
            Validacion.TablasMaestras.Marca marcas = new Validacion.TablasMaestras.Marca();
            return marcas.VerificarRelacionArticulo(idMarca);
        }
    }
}

