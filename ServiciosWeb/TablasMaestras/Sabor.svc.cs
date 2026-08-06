// -----------------------------------------------------------------------
// <copyright file="Sabor.svc.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace ServiciosWeb.TablasMaestras
{
    /// <summary>
    /// Formulario para la administración de sabores en la base de datos por operaciones CRUD
    /// </summary>
    public class Sabor : Contratos.ISabor
    {
        /// <summary>
        /// Inserta un sabor nuevo en la base de datos.
        /// </summary>
        /// <param name="sabor">Objeto con los datos que se desean insertar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        public Entidades.ResultadoTransaccion Insertar(Entidades.Sabor sabor)
        {
            Validacion.TablasMaestras.Sabor Sabor = new Validacion.TablasMaestras.Sabor();
            return Sabor.Insertar(sabor);
        }

        /// <summary>
        /// Obtiene la lista de sabores almacenada en la base de datos
        /// </summary>
        /// <returns>Lista de entidades de tipo Entidades.Sabor</returns>
        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Sabor> Listar()
        {
            Validacion.TablasMaestras.Sabor Sabor = new Validacion.TablasMaestras.Sabor();
            return Sabor.Listar();
        }

        /// <summary>
        /// Elimina el registro de un sabor existente en la base de datos.
        /// </summary>
        /// <param name="idsabor">Identificación del color en la base de datos</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        public Entidades.ResultadoTransaccion Eliminar(int idsabor)
        {
            Validacion.TablasMaestras.Sabor Sabor = new Validacion.TablasMaestras.Sabor();
            return Sabor.Eliminar(idsabor);
        }

        /// <summary>
        /// Actualiza los datos de un Sabor existente en la base de datos.
        /// </summary>
        /// <param name="sabor">Objeto con los datos que se desean actualizar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        public Entidades.ResultadoTransaccion Actualizar(Entidades.Sabor sabor)
        {
            Validacion.TablasMaestras.Sabor Sabor = new Validacion.TablasMaestras.Sabor();
            return Sabor.Actualizar(sabor);
        }
    }
}
