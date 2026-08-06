//-----------------------------------------------------------------------
// <copyright file="Login.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace ReglasDENegocio.WebPublica
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
            EntidadesWeb.ResultadoTransaccion ResultadoAutenticacion = null;
            AccesoDatos.WebPublica.Login Login = new AccesoDatos.WebPublica.Login();
            login.Contrasena = Criptografia.Criptografia.Encriptar(login.Contrasena);

            ResultadoAutenticacion = Login.Ingresar(login);

            // cuando la autenticación no es exitosa, producimos un retraso en al respuesta para reducir ataques de fuerza bruta
            if (int.Parse(ResultadoAutenticacion.ValorAuxiliar.ToString()) == 0)
            {
                System.Threading.Thread.Sleep(4000);
            }

            return ResultadoAutenticacion;
        }

        /// <summary>
        /// Inserta una presentación de artículo en el carrito, sin hacer suma cuando el item ya existe para ese usuario
        /// </summary>
        /// <param name="carrito">Item de carrito a insertar. Tiene que contener el Id del usuario</param>
        /// <returns>Resultado transacción con la cantidad de registros afectados</returns>
        public ResultadoTransaccion InsertarItemCarrito(System.Collections.Generic.List<EntidadesWeb.ItemCarrito> carrito)
        {
            AccesoDatos.WebPublica.Login Login = new AccesoDatos.WebPublica.Login();
            return Login.InsertarItemCarrito(carrito);
        }

        public ReadOnlyCollection<ItemCarrito> ListarItemCarritoPorIdUsuario(int IdUsuario)
        {
            throw new NotImplementedException();
        }
    }
}
