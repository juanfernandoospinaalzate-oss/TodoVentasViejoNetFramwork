//-----------------------------------------------------------------------
// <copyright file="PAisDepartamentoCiudad.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace AccesoDatos.WebPublica
{
    using System.Collections.Generic;

    public class PaisDepartamentoCiudad : ContratosWeb.IPaisDepartamentoCiudad
    {
        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Pais> ListarPais()
        {
            List<EntidadesWeb.Pais> Pais = new List<EntidadesWeb.Pais>();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataReader datareader = null;
            System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Pais> listaReadOnlyPais = null;

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "PaisSelect";
                cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                cmd.Connection.Open();
                datareader = cmd.ExecuteReader();

                while (datareader.Read())
                {
                    EntidadesWeb.Pais pais = new EntidadesWeb.Pais()
                    {
                        IdPais = datareader.GetInt32(0),
                        Nombre = datareader.GetString(1)
                    };
                    Pais.Add(pais);
                }

                listaReadOnlyPais = new System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Pais>(Pais);
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

            return listaReadOnlyPais;
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Departamento> ListarDepartamento(int idPais)
        {
            List<EntidadesWeb.Departamento> ListDepartamento = new List<EntidadesWeb.Departamento>();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataReader datareader = null;
            System.Data.SqlClient.SqlParameter paramIdPais = null;
            System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Departamento> listaReadOnlyDepartamento = null;

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "DepartamentoSelect";

                paramIdPais = new System.Data.SqlClient.SqlParameter("@IdPais", System.Data.SqlDbType.Int);
                paramIdPais.Value = idPais;
                cmd.Parameters.Add(paramIdPais);


                cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                cmd.Connection.Open();
                datareader = cmd.ExecuteReader();

                while (datareader.Read())
                {
                    EntidadesWeb.Departamento departamento = new EntidadesWeb.Departamento();
                    departamento.IdDepartamento = datareader.GetInt32(0);
                    departamento.Pais.IdPais = datareader.GetInt32(1);
                    departamento.Nombre = datareader.GetString(2);

                    ListDepartamento.Add(departamento);
                }

                listaReadOnlyDepartamento = new System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Departamento>(ListDepartamento);
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

            return listaReadOnlyDepartamento;
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Ciudad> ListarCiudad(int IdDpto)
        {
            List<EntidadesWeb.Ciudad> ListCiudad = new List<EntidadesWeb.Ciudad>();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataReader datareader = null;
            System.Data.SqlClient.SqlParameter paramIdDpto = null;
            System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Ciudad> listaReadOnlyCiudad = null;

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "CiudadSelect";

                paramIdDpto = new System.Data.SqlClient.SqlParameter("@IdDpto", System.Data.SqlDbType.Int);
                paramIdDpto.Value = IdDpto;
                cmd.Parameters.Add(paramIdDpto);

                cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                cmd.Connection.Open();
                datareader = cmd.ExecuteReader();

                while (datareader.Read())
                {
                    EntidadesWeb.Ciudad ciudad = new EntidadesWeb.Ciudad();
                    ciudad.IdCiudad = datareader.GetInt32(0);
                    ciudad.Departamento.IdDepartamento = datareader.GetInt32(1);
                    ciudad.Nombre = datareader.GetString(2);

                    ListCiudad.Add(ciudad);
                }

                listaReadOnlyCiudad = new System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Ciudad>(ListCiudad);
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

            return listaReadOnlyCiudad;
        }
    }
}
