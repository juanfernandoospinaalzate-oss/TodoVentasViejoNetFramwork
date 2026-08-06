//-----------------------------------------------------------------------
// <copyright file="Criptografia.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace Criptografia
{
    using System.Text;

    public static class Criptografia
    {
        public static string Encriptar(string Contrasena)
        {
            System.Security.Cryptography.SHA1 sha1 = System.Security.Cryptography.SHA1CryptoServiceProvider.Create();
            byte[] textOriginal = ASCIIEncoding.Default.GetBytes(Contrasena);
            byte[] hash = sha1.ComputeHash(textOriginal);
            StringBuilder cadena = new StringBuilder();
            foreach (byte i in hash)
            {
                cadena.AppendFormat("{0:x2}", i);
            }
            return cadena.ToString();
        }
    }
}
