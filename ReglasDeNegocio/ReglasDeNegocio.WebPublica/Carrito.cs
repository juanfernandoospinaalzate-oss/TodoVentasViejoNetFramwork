//-----------------------------------------------------------------------
// <copyright file="Carrito.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace ReglasDENegocio.WebPublica
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
            AccesoDatos.WebPublica.Carrito Carrito = new AccesoDatos.WebPublica.Carrito();
            return Carrito.Eliminar(idItemCarrito);
        }

        /// <summary>
        /// Actualiza la cantidad de un registro en el carrito
        /// </summary>
        /// <param name="carrito">Datos del carrito, solo se necesita la nueva cantidad y el identificador del registro</param>
        /// <returns>Resultado con mensaje y cantida de registros afectados</returns>
        public EntidadesWeb.ResultadoTransaccion Actualizar(EntidadesWeb.ItemCarrito carrito)
        {
            AccesoDatos.WebPublica.Carrito Carrito = new AccesoDatos.WebPublica.Carrito();
            return Carrito.Actualizar(carrito);
        }

        /// <summary>
        /// Recupera todos los items de carrito asociados a la identificación del usuario
        /// </summary>
        /// <param name="idUsuario">Identificación del usuario en la base de datos</param>
        /// <returns>Lisca con los registros recuperados</returns>
        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.ItemCarrito> Listar(int idUsuario)
        {
            AccesoDatos.WebPublica.Carrito Carrito = new AccesoDatos.WebPublica.Carrito();
            return Carrito.Listar(idUsuario);
        }

        /// <summary>
        /// Agrega la presentación de artículo al carrito en base de datos, sumando las unidades a insertar si el item ya se encuentra en base de datos para ese usuario
        /// </summary>
        /// <param name="itemCarrito">Objeto con los datos a ingresar</param>
        /// <returns>Resultado de transacción indicando la cantidad de registros afectados</returns>
        public EntidadesWeb.ResultadoTransaccion Insertar(EntidadesWeb.ItemCarrito itemCarrito)
        {
            AccesoDatos.WebPublica.Carrito Carrito = new AccesoDatos.WebPublica.Carrito();

            // La propiedad ValorAuxiliar de (Resultado) contiene la cantidad a comprar para el item que se desea ingresar
            // si el valor auxiliar es cero, quiere decir que ese item no existe en el carrito, si es diferente de cero se suman las cantidades
            // y se actualiza el registro
            EntidadesWeb.ItemCarrito ResultadoItemCarrito = Carrito.ConsultarPorIdPresentacionArticulo(itemCarrito.IdPrestacionArticulo, itemCarrito.IdUsuario);

            if (ResultadoItemCarrito != null)
            {
                ResultadoItemCarrito.Cantidad = itemCarrito.Cantidad + ResultadoItemCarrito.Cantidad;
                ResultadoItemCarrito.IdUsuario = itemCarrito.IdUsuario;
                return Carrito.Actualizar(ResultadoItemCarrito);
            }
            else
            {
                return Carrito.Insertar(itemCarrito); 
            }

        }

        /// <summary>
        /// Recupera el registro del carrito asociado a los parámetros para recuperar la cantidad guardad en el carrito
        /// </summary>
        /// <param name="IdPresentacionArticulo">Identificación de la presentación de artículo</param>
        /// <param name="IdUsuario">Identificación del usuario en la base de datos</param>
        /// <returns>Item de carrito con su Id, la cantidad y nombre</returns>
        public EntidadesWeb.ItemCarrito ConsultarPorIdPresentacionArticulo(int IdPresentacionArticulo, int IdUsuario)
        {
            AccesoDatos.WebPublica.Carrito Carrito = new AccesoDatos.WebPublica.Carrito();
            return Carrito.ConsultarPorIdPresentacionArticulo(IdPresentacionArticulo, IdUsuario);
        }

        public double TotalPorIdUsuario(int IdUsuario)
        {
            AccesoDatos.WebPublica.Carrito Carrito = new AccesoDatos.WebPublica.Carrito();
            return Carrito.TotalPorIdUsuario(IdUsuario);
        }

        public string GenerarPreferenciaPago(List<EntidadesWeb.ItemCarrito> ListadoCarrito, EntidadesWeb.Cliente objCliente, EntidadesWeb.Direccion objDireccion, EntidadesWeb.Enumeraciones.MedioPago formaDePago, double tasaDeCambioDolar, string urlBase)
        {
            AccesoDatos.WebPublica.Carrito Carrito = new AccesoDatos.WebPublica.Carrito();

            //ListadoCarrito[0].IdItemCarrito

            return Carrito.GenerarPreferenciaPago(ListadoCarrito, objCliente, objDireccion, formaDePago, tasaDeCambioDolar, urlBase);
        }
    }
}
