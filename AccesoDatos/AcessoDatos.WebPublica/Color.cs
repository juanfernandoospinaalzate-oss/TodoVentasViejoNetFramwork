//-----------------------------------------------------------------------
// <copyright file="Color.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace AccesoDatos.WebPublica
{
    using System.Collections.Generic;

    public class Color : ContratosWeb.IColor
    {
        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Color> ListaColores()
        {
            List<EntidadesWeb.Color> color = new List<EntidadesWeb.Color>();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataReader datareader = null;
            System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Color> listaReadOnlyColor = null;
            EntidadesWeb.ResultadoTransaccion resultado = new EntidadesWeb.ResultadoTransaccion();

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "ColorSelect";
                cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                cmd.Connection.Open();
                datareader = cmd.ExecuteReader();

                while (datareader.Read())
                {
                    EntidadesWeb.Color colores = new EntidadesWeb.Color();

                    colores.IdColor = datareader.GetInt32(0);
                    colores.Codigo = datareader.GetString(1);
                    colores.Nombre = datareader.GetString(2);

                    color.Add(colores);
                }

                listaReadOnlyColor = new System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Color>(color);
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

            return listaReadOnlyColor;
        }
    }
}
