//-----------------------------------------------------------------------
// <copyright file="UnidadMasa.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace AccesoDatos.WebPublica
{
    using System.Collections.Generic;

    public class UnidadMasa : ContratosWeb.IUnidadMasa
    {
        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.UnidadMasa> ListaUnidadMasa()
        {
            List<EntidadesWeb.UnidadMasa> unidadMasa = new List<EntidadesWeb.UnidadMasa>();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataReader datareader = null;
            System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.UnidadMasa> listaReadOnlyUnidadMasa = null;
            EntidadesWeb.ResultadoTransaccion resultado = new EntidadesWeb.ResultadoTransaccion();

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "UnidadMasaSelect";
                cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                cmd.Connection.Open();
                datareader = cmd.ExecuteReader();

                while (datareader.Read())
                {
                    EntidadesWeb.UnidadMasa UndMasa = new EntidadesWeb.UnidadMasa();

                    UndMasa.IdUnidadMasa = datareader.GetInt32(0);
                    UndMasa.Nombre = datareader.GetString(1);

                    listaReadOnlyUnidadMasa = new System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.UnidadMasa>(unidadMasa);
                    unidadMasa.Add(UndMasa);
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

            return listaReadOnlyUnidadMasa;
        }
    }
}
