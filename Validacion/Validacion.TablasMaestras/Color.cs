// -----------------------------------------------------------------------
// <copyright file="Color.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace Validacion.TablasMaestras
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
            ReglasDENegocio.TablasMaestras.Color colores = new ReglasDENegocio.TablasMaestras.Color();
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

            if (color == null)
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                return resultadoTransaccion;
            }

            // El sistema verifica que el campo(código de color) no se encuentre vacío.
            if (string.IsNullOrEmpty(color.Codigo.Trim()))
            {
                // informar que falta por diligenciar el código del color.
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0010");
                resultadoTransaccion.Mensaje.Texto = resultadoTransaccion.Mensaje.Texto.Replace("<LISTA_ELEMENTOS_VACIOS>", "Código del Color");
                resultadoTransaccion.RegistrosAfectados = 0;

                return resultadoTransaccion;
            }

            // El sistema verifica qeu el campo(nombre del color) no se encuentre vacío.
            if (string.IsNullOrEmpty(color.Nombre.Trim()))
            {
                // informar que falta por diligenciar el nombre del color.
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0010");
                resultadoTransaccion.Mensaje.Texto = resultadoTransaccion.Mensaje.Texto.Replace("<LISTA_ELEMENTOS_VACIOS>", "Nombre del Color");
                resultadoTransaccion.RegistrosAfectados = 0;

                return resultadoTransaccion;
            }

            // El sistema verifica que el código de color sea único
            bool colorExiste = colores.ColorVerificaUnicidadCodigo(color);
            if (colorExiste == true)
            {
                // informar que el código hexadecimal del color ya se encuentra en uso
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0011");
                resultadoTransaccion.Mensaje.Texto = resultadoTransaccion.Mensaje.Texto.Replace("<NOMBRE_ELEMENTO>", "Código del Color");
                resultadoTransaccion.RegistrosAfectados = 0;
                return resultadoTransaccion;
            }
            
            // El sisteme verifica que el código hexadecimal contenga exactamente 6 caracteres
            if (color.Codigo.Length != 6)
            {
                // El código no es exactamente 6 caracteres. Se informa del Error
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0012");
                resultadoTransaccion.RegistrosAfectados = 0;
                return resultadoTransaccion;
            }

            // El sistema verifica que el código hexadecimal se encuentre en formato hexadecimal.
            // Para verifciar con facilidad se buscarán caracteres no Hexadecimales
            bool noHexadecimal = false;
            noHexadecimal = System.Text.RegularExpressions.Regex.IsMatch(color.Codigo, "[G-Zg-z]+");

            // Si hay alguna coincidencia entonces el código evaluado no es hexadecimal
            if (noHexadecimal == true)
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0013");
                resultadoTransaccion.RegistrosAfectados = 0;
                return resultadoTransaccion;
            }
            
            // El sistema verifica que el nombre del color no pase de veinticinco caracteres.
            if (color.Nombre.Length > 25)
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("014");
                resultadoTransaccion.Mensaje.Texto = resultadoTransaccion.Mensaje.Texto.Replace("<NOMBRE_CAMPO>", "Nombre del Color");
                resultadoTransaccion.Mensaje.Texto = resultadoTransaccion.Mensaje.Texto.Replace("<CANTIDAD_CARACTERES>", "Nombre del Color");
                resultadoTransaccion.RegistrosAfectados = 0;
                return resultadoTransaccion;
            }
            
            // El sistema verifica que el nombre del color sea único.
            bool nombreColorExiste = colores.ColorVerificaUnicidadNombre(color.Nombre);
            if (nombreColorExiste)
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0011");
                resultadoTransaccion.Mensaje.Texto = resultadoTransaccion.Mensaje.Texto.Replace("<NOMBRE_ELEMENTO>", "Código del Color");
                resultadoTransaccion.RegistrosAfectados = 0;
                return resultadoTransaccion;
            }

            // Como pasaron todas las validaciones se ingresa el registro
            return colores.Insertar(color);
        }

        /// <summary>
        /// Actualiza los datos de un color existente en la base de datos.
        /// </summary>
        /// <param name="color">Objeto con los datos que se desean actualizar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        public Entidades.ResultadoTransaccion Actualizar(Entidades.Color color)
        {
            ReglasDENegocio.TablasMaestras.Color colores = new ReglasDENegocio.TablasMaestras.Color();
            return colores.Actualizar(color);
        }

        /// <summary>
        /// Elimina el registro de un color existente en la base de datos.
        /// </summary>
        /// <param name="idColor">Identificación del color en la base de datos</param>
        /// <returns>1 si la operación fué exitosa, 0 sino fué exitosa</returns>
        public Entidades.ResultadoTransaccion Eliminar(int idColor)
        {
            ReglasDENegocio.TablasMaestras.Color colores = new ReglasDENegocio.TablasMaestras.Color();
            return colores.Eliminar(idColor);
        }

        /// <summary>
        /// Obtiene la lista de colores almacenada en la base de datos
        /// </summary>
        /// <returns>Lista de entidades de tipo Entidades.Color</returns>
        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Color> Listar()
        {
            ReglasDENegocio.TablasMaestras.Color colores = new ReglasDENegocio.TablasMaestras.Color();
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
        /// Indica si el código hexadecimal ya existe en un registro de la tabla de colores
        /// </summary>
        /// <param name="color">código RGB en formato Hexadecimal de 6 caracteres</param>
        /// <returns>true si el código ya está registrado o false si el código no está registrado</returns>
        public bool ColorVerificaUnicidadCodigo(Entidades.Color color)
        {
            ReglasDENegocio.TablasMaestras.Color colores = new ReglasDENegocio.TablasMaestras.Color();
            return colores.ColorVerificaUnicidadCodigo(color);            
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
