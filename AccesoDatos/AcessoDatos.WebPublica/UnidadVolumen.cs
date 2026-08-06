//-----------------------------------------------------------------------
// <copyright file="UnidadVolumen.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace AccesoDatos.WebPublica
{
    using System.Collections.Generic;

    public class UnidadVolumen : ContratosWeb.IUnidadVolumen
    {
        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.UnidadVolumen> ListaUnidadVolumen()
        {
            List<EntidadesWeb.UnidadVolumen> unidadVolumen = new List<EntidadesWeb.UnidadVolumen>();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataReader datareader = null;
            System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.UnidadVolumen> listaReadOnlyUnidadVolumen = null;
            EntidadesWeb.ResultadoTransaccion resultado = new EntidadesWeb.ResultadoTransaccion();

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "UnidadVolumenSelect";
                cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                cmd.Connection.Open();
                datareader = cmd.ExecuteReader();

                while (datareader.Read())
                {
                    EntidadesWeb.UnidadVolumen UndVolumen = new EntidadesWeb.UnidadVolumen();

                    UndVolumen.IdUnidadVolumen = datareader.GetInt32(0);
                    UndVolumen.Nombre = datareader.GetString(1);
                    listaReadOnlyUnidadVolumen = new System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.UnidadVolumen>(unidadVolumen);
                    unidadVolumen.Add(UndVolumen);
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

            return listaReadOnlyUnidadVolumen;
        }
    }
}
