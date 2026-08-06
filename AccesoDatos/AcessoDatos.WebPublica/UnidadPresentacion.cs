//-----------------------------------------------------------------------
// <copyright file="UnidadPresentacion.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace AccesoDatos.WebPublica
{
    using System.Collections.Generic;

    public class UnidadPresentacion : ContratosWeb.IUnidadPresentacion
    {

        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.UnidadPresentacion> Listar()
        {
            List<EntidadesWeb.UnidadPresentacion> ListaUnidadPresentacion = new List<EntidadesWeb.UnidadPresentacion>();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataReader datareader = null;
            System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.UnidadPresentacion> listaReadOnlyUnidadPresentacion = null;

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "UnidadPresentacionSelect";
                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();
                datareader = cmd.ExecuteReader();

                while (datareader.Read())
                {
                    EntidadesWeb.UnidadPresentacion unidadPResentacion = new EntidadesWeb.UnidadPresentacion()
                    {
                        IdUnidadPresentacion = datareader.GetInt32(0),
                        Nombre = datareader.GetString(1)
                    };
                    ListaUnidadPresentacion.Add(unidadPResentacion);
                }

                listaReadOnlyUnidadPresentacion = new System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.UnidadPresentacion>(ListaUnidadPresentacion);
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

            return listaReadOnlyUnidadPresentacion;
        }
    }
}
