//-----------------------------------------------------------------------
// <copyright file="ConfiguracionPieDePagina.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace AccesoDatos.WebPublica
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class ConfiguracionPieDePagina : ContratosWeb.IConfiguracionPieDePagina
    {
        public ReadOnlyCollection<EntidadesWeb.ConfiguracionPieDePagina> Listar()
        {
            List<EntidadesWeb.ConfiguracionPieDePagina> ListaConfiguracionPieDePagina = new List<EntidadesWeb.ConfiguracionPieDePagina>();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataReader datareader = null;
            System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.ConfiguracionPieDePagina> listaReadOnlyConfiguracionPieDePagina = null;

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "ConfiguracionPieDePaginaSelect";
                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();
                datareader = cmd.ExecuteReader();

                while (datareader.Read())
                {
                    EntidadesWeb.ConfiguracionPieDePagina PieDePagina = new EntidadesWeb.ConfiguracionPieDePagina()
                    {
                        Id = datareader.GetInt32(0),
                        AtencionSkype = datareader.GetString(1),
                        LineaTelefonica = datareader.GetString(2),
                        LineaCelular = datareader.GetString(3),
                        CorreoElectronico = datareader.GetString(4),
                        Devoluciones = datareader.GetString(5),
                        ComoPagar = datareader.GetString(6),
                        Envios = datareader.GetString(7)
                    };
                    ListaConfiguracionPieDePagina.Add(PieDePagina);
                }

                listaReadOnlyConfiguracionPieDePagina = new System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.ConfiguracionPieDePagina>(ListaConfiguracionPieDePagina);
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

                cmd.Dispose();

                if (datareader != null)
                {
                    datareader.Dispose();
                }
            }
            return listaReadOnlyConfiguracionPieDePagina;
        }
    }
}
