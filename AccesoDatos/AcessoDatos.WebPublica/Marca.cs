//-----------------------------------------------------------------------
// <copyright file="Marca.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace AccesoDatos.WebPublica
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class Marca : ContratosWeb.IMarca
    {
        public ReadOnlyCollection<EntidadesWeb.Marca> Listar()
        {
            List<EntidadesWeb.Marca> marcas = new List<EntidadesWeb.Marca>();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataReader datareader = null;
            System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Marca> listaReadOnlymarca = null;

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "MarcaSelectOrdenadoPorId";
                cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                cmd.Connection.Open();
                datareader = cmd.ExecuteReader();

                while (datareader.Read())
                {
                    EntidadesWeb.Marca marca = new EntidadesWeb.Marca()
                    {
                        IdMarca = datareader.GetInt32(0),
                        Nombre = datareader.GetString(1)
                    };
                    marcas.Add(marca);
                }

                listaReadOnlymarca = new System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Marca>(marcas);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Logging.ErrorGeneral.Guardar(ex);
            }
            finally
            {
                if (datareader != null)
                {
                    datareader.Dispose();
                }

                if (cmd.Connection.State == System.Data.ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }

                cmd.Dispose();
            }

            return listaReadOnlymarca;
        }
    }
}
