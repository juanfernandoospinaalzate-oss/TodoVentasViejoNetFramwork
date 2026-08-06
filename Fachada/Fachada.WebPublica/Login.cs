//-----------------------------------------------------------------------
// <copyright file="Login.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace Fachada.WebPublica
{
    using System;
    using System.Collections.ObjectModel;
    using EntidadesWeb;

    public class Login : ContratosWeb.ILogin
    {
        /// <summary>
        /// Ingreso de un cliente al sistema.
        /// </summary>
        /// <param name="login">Objeto con los datos que se desean insertar</param>
        /// <returns>Resultado de la transacción con todos los detalles</returns>
        public EntidadesWeb.ResultadoTransaccion Ingresar(EntidadesWeb.Login login)
        {
            ServicioLogin.LoginClient Login = new ServicioLogin.LoginClient();
            return Login.Ingresar(login);
        }

        /// <summary>
        /// Inserta una presentación de artículo en el carrito, sin hacer suma cuando el item ya existe para ese usuario
        /// </summary>
        /// <param name="carrito">Item de carrito a insertar. Tiene que contener el Id del usuario</param>
        /// <returns>Resultado transacción con la cantidad de registros afectados</returns>
        public ResultadoTransaccion InsertarItemCarrito(System.Collections.Generic.List<EntidadesWeb.ItemCarrito> carrito)
        {
            ServicioLogin.LoginClient Login = new ServicioLogin.LoginClient();
            return Login.InsertarItemCarrito(carrito.ToArray());
        }

        public ReadOnlyCollection<ItemCarrito> ListarItemCarritoPorIdUsuario(int IdUsuario)
        {
            throw new NotImplementedException();
        }
    }
}
