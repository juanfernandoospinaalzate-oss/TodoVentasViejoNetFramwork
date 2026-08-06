// -----------------------------------------------------------------------
// <copyright file="Color.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace ReglasDENegocio.TablasMaestras
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
            // true si el nombre ya está registrado, indicándolo mediante un mensaje
            AccesoDatos.TablasMaestras.Color colores = new AccesoDatos.TablasMaestras.Color();
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();
            resultadoTransaccion.RegistrosAfectados = 0;

            // el sistema verifica que el color no sea nulo
            if (color == null)
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                return resultadoTransaccion;
            }

            // el sistema verifica que el campo (nombre) no se encuentre vacío.
            if (string.IsNullOrEmpty(color.Nombre.Trim()))
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0010");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                return resultadoTransaccion;
            }

            if (colores.ColorVerificaUnicidadNombre(color.Nombre))
            {
                Entidades.ResultadoTransaccion resultadoColorVerificaUnicidadNombre = new Entidades.ResultadoTransaccion();
                resultadoColorVerificaUnicidadNombre.RegistrosAfectados = 0;
                Entidades.Mensaje mensaje = Mensajes.LinqToXml.LeerMensaje("0011");
                resultadoColorVerificaUnicidadNombre.Mensaje = mensaje;
                return resultadoColorVerificaUnicidadNombre;
            }

            // false si el código no está registrado
            return colores.Insertar(color);
        }

        /// <summary>
        /// Elimina el registro de un color existente en la base de datos.
        /// </summary>
        /// <param name="idColor">Identificación del color en la base de datos</param>
        /// <returns>1 si la operación fué exitosa, 0 sino fué exitosa</returns>
        public Entidades.ResultadoTransaccion Eliminar(int idColor)
        {
            // Validar el que no sea un código de color predeterminado del sistema.
            if (idColor < 68)
            {
                // si es un código predeterminado no se hace la eliminación
                Entidades.Mensaje mensaje = Mensajes.LinqToXml.LeerMensaje("0003");
                return new Entidades.ResultadoTransaccion() { Mensaje = mensaje, RegistrosAfectados = 0 };
            }
            
            // Validar que el registro no esté siento utilizado en una tabla relacionada (Tabla de artículos)
            AccesoDatos.TablasMaestras.Color colores = new AccesoDatos.TablasMaestras.Color();
            if (colores.ColorVerificarRelacionArticulo(idColor) == true)
            {
                // Si es un registro relacionado no se hace la eliminación
                Entidades.Mensaje mensaje = Mensajes.LinqToXml.LeerMensaje("0002");
                return new Entidades.ResultadoTransaccion() { Mensaje = mensaje, RegistrosAfectados = 0 };
            }

            return colores.Eliminar(idColor);
        }

        /// <summary>
        /// Obtiene la lista de colores almacenada en la base de datos
        /// </summary>
        /// <returns>Lista de entidades de tipo Entidades.Color</returns>
        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Color> Listar()
        {
            AccesoDatos.TablasMaestras.Color colores = new AccesoDatos.TablasMaestras.Color();
            return colores.Listar();
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
        /// indica si el nombre del color ya se encuentra registrado en la tabla de colores
        /// </summary>
        /// <param name="nombreColor">Nombre del color de 20 caracteres como máximo</param>
        /// <returns>true si el nombre ya está registrado o false si el nombre no está registrado</returns>
        public bool ColorVerificaUnicidadNombre(string nombreColor)
        {
            AccesoDatos.TablasMaestras.Color colores = new AccesoDatos.TablasMaestras.Color();
            return colores.ColorVerificaUnicidadNombre(nombreColor);
        }

        /// <summary>
        /// Actualiza los datos de un color existente en la base de datos.
        /// </summary>
        /// <param name="color">Objeto con los datos que se desean actualizar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        public Entidades.ResultadoTransaccion Actualizar(Entidades.Color color)
        {
            // Indica si el código hexadecimal ya está registrado de la tabla de colores
            AccesoDatos.TablasMaestras.Color colores = new AccesoDatos.TablasMaestras.Color();             
            if (colores.ColorVerificaUnicidadCodigo(color))
            {
                // true si el código ya está registrado
                Entidades.ResultadoTransaccion resultadoColorVerificaUnicidadCodigo = new Entidades.ResultadoTransaccion();
                resultadoColorVerificaUnicidadCodigo.RegistrosAfectados = 0;
                Entidades.Mensaje mensaje = Mensajes.LinqToXml.LeerMensaje("0011");
                resultadoColorVerificaUnicidadCodigo.Mensaje = mensaje;
                return resultadoColorVerificaUnicidadCodigo;
            }

            return colores.Actualizar(color);    
        }

        /// <summary>
        /// Indica si el código hexadecimal ya existe en un registro de la tabla de colores
        /// </summary>
        /// <param name="color">código RGB en formato Hexadecimal de 6 caracteres</param>
        /// <returns>true si el código ya está registrado o false si el código no está registrado</returns>
        public bool ColorVerificaUnicidadCodigo(Entidades.Color color)
        {
            AccesoDatos.TablasMaestras.Color colores = new AccesoDatos.TablasMaestras.Color();
            return colores.ColorVerificaUnicidadCodigo(color);
        }
    }
}
