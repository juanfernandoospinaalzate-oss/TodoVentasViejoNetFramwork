// -----------------------------------------------------------------------
// <copyright file="Carrito.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace Validacion.WebPublica
{
    using ContratosWeb;
    using System.Collections.Generic;

    /// <summary>
    /// Administra los datos del carrito de compras
    /// </summary>
    public class Carrito : ContratosWeb.ICarrito
    {
        /// <summary>
        /// Elimina un item del carrito
        /// </summary>
        /// <param name="idItemCarrito">Identificación única del registro</param>
        /// <returns>Resultado con mensaje y cantidad de registros afectados</returns>
        public EntidadesWeb.ResultadoTransaccion Eliminar(int idItemCarrito)
        {
            ReglasDENegocio.WebPublica.Carrito Carrito = new ReglasDENegocio.WebPublica.Carrito();
            return Carrito.Eliminar(idItemCarrito);
        }

        /// <summary>
        /// Actualiza la cantidad de un registro en el carrito
        /// </summary>
        /// <param name="carrito">Datos del carrito, solo se necesita la nueva cantidad y el identificador del registro</param>
        /// <returns>Resultado con mensaje y cantida de registros afectados</returns>
        public EntidadesWeb.ResultadoTransaccion Actualizar(EntidadesWeb.ItemCarrito carrito)
        {
            ReglasDENegocio.WebPublica.Carrito Carrito = new ReglasDENegocio.WebPublica.Carrito();
            return Carrito.Actualizar(carrito);
        }

        /// <summary>
        /// Recupera todos los items de carrito asociados a la identificación del usuario
        /// </summary>
        /// <param name="idUsuario">Identificación del usuario en la base de datos</param>
        /// <returns>Lisca con los registros recuperados</returns>
        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.ItemCarrito> Listar(int idUsuario)
        {
            ReglasDENegocio.WebPublica.Carrito Carrito = new ReglasDENegocio.WebPublica.Carrito();
            return Carrito.Listar(idUsuario);
        }

        /// <summary>
        /// Ingresa un registro nuevo al carrito
        /// </summary>
        /// <param name="carrito">Datos a registrar, idenficiación del usuario, identificación de la presentación del artículo y cantidad</param>
        /// <returns>Resultado con mensaje y cantidad de registros afectados</returns>
        public EntidadesWeb.ResultadoTransaccion Insertar(EntidadesWeb.ItemCarrito carrito)
        {
            ReglasDENegocio.WebPublica.Carrito Carrito = new ReglasDENegocio.WebPublica.Carrito();
            return Carrito.Insertar(carrito);
        }

        /// <summary>
        /// Recupera el registro del carrito asociado a los parámetros para recuperar la cantidad guardad en el carrito
        /// </summary>
        /// <param name="IdPresentacionArticulo">Identificación de la presentación de artículo</param>
        /// <param name="IdUsuario">Identificación del usuario en la base de datos</param>
        /// <returns>Item de carrito con su Id, la cantidad y nombre</returns>
        public EntidadesWeb.ItemCarrito ConsultarPorIdPresentacionArticulo(int IdPresentacionArticulo, int IdUsuario)
        {
            ReglasDENegocio.WebPublica.Carrito Carrito = new ReglasDENegocio.WebPublica.Carrito();
            return Carrito.ConsultarPorIdPresentacionArticulo(IdPresentacionArticulo, IdUsuario);
        }

        public double TotalPorIdUsuario(int IdUsuario)
        {
            ReglasDENegocio.WebPublica.Carrito Carrito = new ReglasDENegocio.WebPublica.Carrito();
            return Carrito.TotalPorIdUsuario(IdUsuario);
        }

        public string GenerarPreferenciaPago(List<EntidadesWeb.ItemCarrito> ListadoCarrito, EntidadesWeb.Cliente objCliente, EntidadesWeb.Direccion objDireccion, EntidadesWeb.Enumeraciones.MedioPago formaDePago, double tasaDeCambioDolar, string urlBase)
        {
            ReglasDENegocio.WebPublica.Carrito Carrito = new ReglasDENegocio.WebPublica.Carrito();
            return Carrito.GenerarPreferenciaPago(ListadoCarrito, objCliente, objDireccion, formaDePago, tasaDeCambioDolar, urlBase);
        }

    }
}
