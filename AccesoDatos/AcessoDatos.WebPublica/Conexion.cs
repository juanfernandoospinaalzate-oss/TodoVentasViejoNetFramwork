//-----------------------------------------------------------------------
// <copyright file="Conexion.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace AccesoDatos.WebPublica
{
    public static class Conexion
    {
        public static System.Data.SqlClient.SqlConnection NuevaConexion()
        {
                return new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
        }
    }
}
