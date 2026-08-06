// -----------------------------------------------------------------------
// <copyright file="Color.svc.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace ServiciosWeb.TablasMaestras
{
    using System;

    /// <summary>
    /// Formulario para la administración de colores en la base de datos por operaciones CRUD
    /// </summary>
    public class Color : Contratos.IColores
    {
        /// <summary>
        /// Inserta un color nuevo en la base de datos.
        /// </summary>
        /// <param name="color">Objeto con los datos que se desean insertar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        public Entidades.ResultadoTransaccion Insertar(Entidades.Color color)
        {
            Validacion.TablasMaestras.Color colores = new Validacion.TablasMaestras.Color();
            return colores.Insertar(color);
        }

        /// <summary>
        /// Actualiza los datos de un color existente en la base de datos.
        /// </summary>
        /// <param name="color">Objeto con los datos que se desean actualizar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        public Entidades.ResultadoTransaccion Actualizar(Entidades.Color color)
        {
            Validacion.TablasMaestras.Color colores = new Validacion.TablasMaestras.Color();
            return colores.Actualizar(color);
        }

        /// <summary>
        /// Elimina el registro de un color existente en la base de datos.
        /// </summary>
        /// <param name="idColor">Identificación del color en la base de datos</param>
        /// <returns>1 si la operación fué exitosa, 0 sino fué exitosa</returns>
        public Entidades.ResultadoTransaccion Eliminar(int idColor)
        {
            Validacion.TablasMaestras.Color color = new Validacion.TablasMaestras.Color();
            return color.Eliminar(idColor);
        }

        /// <summary>
        /// Obtiene una lista con todos los colores disponibles
        /// </summary>
        /// <returns>Lista con todos los colores disponibles</returns>
        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Color> Listar()
        {
            Validacion.TablasMaestras.Color color = new Validacion.TablasMaestras.Color();
            return color.Listar();
        }

        /// <summary>
        /// Obtiene los datos de un color buscando por us ID único de tabla.
        /// </summary>
        /// <param name="idColor">Identificación de color en la base de datos.</param>
        /// <returns>Objeto de tipo color buscado, en caso de no encontrarlo retorna un valor null</returns>
        public Entidades.Color ConsultarPorId(int idColor)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Indica si el color tiene un registro relacionado en la base de datos.
        /// </summary>
        /// <param name="idColor">Identificador del color.</param>
        /// <returns>indica si hay o no un registro relacionado.</returns>
        public bool ColorVerificarRelacionArticulo(int idColor)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Indica si el código hexadecimal ya existe en un registro de la tabla de colores
        /// </summary>
        /// <param name="color">código RGB en formato Hexadecimal de 6 caracteres</param>
        /// <returns>true si el código ya está registrado o false si el código no está registrado</returns>
        public bool ColorVerificaUnicidadCodigo(Entidades.Color color)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// indica si el nombre del color ya se encuentra registrado en la tabla de colores
        /// </summary>
        /// <param name="nombreColor">Nombre del color de 20 caracteres como máximo</param>
        /// <returns>true si el nombre ya está registrado o false si el nombre no está registrado</returns>
        public bool ColorVerificaUnicidadNombre(string nombreColor)
        {
            throw new NotImplementedException();
        }
    }
}
