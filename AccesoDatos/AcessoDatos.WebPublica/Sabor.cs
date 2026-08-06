//-----------------------------------------------------------------------
// <copyright file="Sabor.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace AccesoDatos.WebPublica
{
    using System.Collections.Generic;

    public class Sabor : ContratosWeb.ISabor
    {
        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Sabor> ListaSabores()
        {
            List<EntidadesWeb.Sabor> ListaSabores = new List<EntidadesWeb.Sabor>();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataReader datareader = null;
            System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Sabor> listaReadOnlySabor = null;
            EntidadesWeb.ResultadoTransaccion resultado = new EntidadesWeb.ResultadoTransaccion();

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SaborSelect";
                cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                cmd.Connection.Open();
                datareader = cmd.ExecuteReader();

                while (datareader.Read())
                {
                    EntidadesWeb.Sabor sabores = new EntidadesWeb.Sabor();

                    sabores.IdSabor = datareader.GetInt32(0);
                    sabores.Nombre = datareader.GetString(1);

                    listaReadOnlySabor = new System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Sabor>(ListaSabores);
                    ListaSabores.Add(sabores);
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

            return listaReadOnlySabor;
        }
    }
}
