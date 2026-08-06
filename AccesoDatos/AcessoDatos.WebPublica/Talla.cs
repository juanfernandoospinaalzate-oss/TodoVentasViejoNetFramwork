//-----------------------------------------------------------------------
// <copyright file="Talla.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace AccesoDatos.WebPublica
{
    using System.Collections.Generic;

    public class Talla : ContratosWeb.ITalla
    {
        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Talla> ListaTallas()
        {
            List<EntidadesWeb.Talla> talla = new List<EntidadesWeb.Talla>();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataReader datareader = null;
            System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Talla> listaReadOnlyTalla = null;
            EntidadesWeb.ResultadoTransaccion resultado = new EntidadesWeb.ResultadoTransaccion();

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "TallaSelect";
                cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                cmd.Connection.Open();
                datareader = cmd.ExecuteReader();

                while (datareader.Read())
                {
                    EntidadesWeb.Talla tallas = new EntidadesWeb.Talla();

                    tallas.IdTalla = datareader.GetInt32(0);
                    tallas.Nombre = datareader.GetString(1);
                    listaReadOnlyTalla = new System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Talla>(talla);
                    talla.Add(tallas);
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Logging.ErrorGeneral.Guardar(ex);
            }
            finally
            {
                if (cmd.Connection.State == System.Data.ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }

                if (datareader != null)
                {
                    datareader.Dispose();
                }

                if (cmd != null)
                {
                    cmd.Dispose();
                }
            }

            return listaReadOnlyTalla;
        }
    }
}
