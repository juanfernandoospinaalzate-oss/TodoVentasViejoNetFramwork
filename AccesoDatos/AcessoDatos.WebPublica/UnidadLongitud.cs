//-----------------------------------------------------------------------
// <copyright file="UnidadLongitud.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace AccesoDatos.WebPublica
{
    using System.Collections.Generic;

    public class UnidadLongitud : ContratosWeb.IUnidadLongitud
    {
        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.UnidadLongitud> ListaUnidadLongitud()
        {
            List<EntidadesWeb.UnidadLongitud> unidadLongitud = new List<EntidadesWeb.UnidadLongitud>();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataReader datareader = null;
            System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.UnidadLongitud> listaReadOnlyUnidadLongitud = null;
            EntidadesWeb.ResultadoTransaccion resultado = new EntidadesWeb.ResultadoTransaccion();

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "UnidadLongitudSelect";
                cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                cmd.Connection.Open();
                datareader = cmd.ExecuteReader();

                while (datareader.Read())
                {
                    EntidadesWeb.UnidadLongitud UndLongitud = new EntidadesWeb.UnidadLongitud();

                    UndLongitud.IdUnidadLongitud = datareader.GetInt32(0);
                    UndLongitud.Nombre = datareader.GetString(1);

                    listaReadOnlyUnidadLongitud = new System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.UnidadLongitud>(unidadLongitud);
                    unidadLongitud.Add(UndLongitud);
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

            return listaReadOnlyUnidadLongitud;
        }
    }
}
