// -----------------------------------------------------------------------
// <copyright file="Talla.svc.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace ServiciosWeb.TablasMaestras
{
    using System;

    /// <summary>
    /// Formulario para la administración de tallas en la base de datos por operaciones CRUD
    /// </summary>
    public class Talla : Contratos.ITallas
    {
        /// <summary>
        /// Inserta una talla nueva en la base de datos
        /// </summary>
        /// <param name="talla">Objeto con los datos que se desean insertar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        public Entidades.ResultadoTransaccion Insertar(Entidades.Talla talla)
        {
            Validacion.TablasMaestras.Talla tallas = new Validacion.TablasMaestras.Talla();
            return tallas.Insertar(talla);            
        }

        /// <summary>
        /// Actualiza los datos de una talla en la base de datos.
        /// </summary>
        /// <param name="talla">Objeto con los datos que se desean actualizar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        public Entidades.ResultadoTransaccion Actualizar(Entidades.Talla talla)
        {
            Validacion.TablasMaestras.Talla tallas = new Validacion.TablasMaestras.Talla();
            return tallas.Actualizar(talla);
        }

        /// <summary>
        /// Elimina el registro de una talla existente en la base de datos.
        /// </summary>
        /// <param name="idtalla">identificador acceder al registro que se va a eliminar</param>
        /// <returns>1 si la operación fué exitosa, 0 sino fué exitosa</returns>
        public Entidades.ResultadoTransaccion Eliminar(int idtalla)
        {
            Validacion.TablasMaestras.Talla tallas = new Validacion.TablasMaestras.Talla();
            return tallas.Eliminar(idtalla);
        }

        /// <summary>
        /// Obtiene la lista de tallas de la base de datos.
        /// </summary>
        /// <returns>Lista de entidades de tipo Entidades.Talla</returns>
        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Talla> Listar()
        {
            Validacion.TablasMaestras.Talla tallas = new Validacion.TablasMaestras.Talla();
            return tallas.Listar();
        }

        /// <summary>
        /// Verifica que no se pueda ingresar una talla duplicada
        /// </summary>
        /// <param name="talla">Objeto con los datos que se desean verificar</param>
        /// <returns>indica si hay o no un registro relacionado</returns>
        public bool TallaVerificarDuplicidad(Entidades.Talla talla)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Verifica Si la talla no está relacionada(asociada) a un artículo.
        /// </summary>
        /// <param name="idTalla">identificador de Talla</param>
        /// <returns>indica si hay o no un registro relacionado</returns>
        public bool TallaVerificarRelacionArticulo(int idTalla)
        {
            throw new NotImplementedException();
        }
    }
}
