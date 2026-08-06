// -----------------------------------------------------------------------
// <copyright file="Busqueda.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace AccesoDatos.WebPublica
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Busqueda : ContratosWeb.IBusqueda
    {
        public System.Collections.ObjectModel.ReadOnlyCollection<string> Listar(string texto)
        {
            List<string> ListaBusqueda = new List<string>();
            System.Collections.ObjectModel.ReadOnlyCollection<string> listaReadOnlyBusquedas = null;
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlParameter paramTexto = null;
            System.Data.SqlClient.SqlDataReader datareader = null;
            
            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "BusquedasListarWeb";

                cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();

                paramTexto = new System.Data.SqlClient.SqlParameter("@Texto", System.Data.SqlDbType.NVarChar, 250);
                paramTexto.Value = texto;
                cmd.Parameters.Add(paramTexto);

                cmd.Connection.Open();
                datareader = cmd.ExecuteReader();

                while (datareader.Read())
                {
                    ListaBusqueda.Add(datareader.GetString(1));
                }

                listaReadOnlyBusquedas = new System.Collections.ObjectModel.ReadOnlyCollection<string>(ListaBusqueda);
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

            return listaReadOnlyBusquedas;
        }


        public void Insertar(string texto)
        {
            if (texto == string.Empty)
            {
                return;
            }

            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlParameter paramTexto = null;
            EntidadesWeb.ResultadoTransaccion resultadoTransaccion = new EntidadesWeb.ResultadoTransaccion();

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "BusquedasInsertar";

                paramTexto = new System.Data.SqlClient.SqlParameter("@Texto", System.Data.SqlDbType.NVarChar, 250);
                paramTexto.Value = texto;
                cmd.Parameters.Add(paramTexto);

                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();
                int i = cmd.ExecuteNonQuery();
                resultadoTransaccion.RegistrosAfectados = i;
                // Logging.Accion.Guardar("Ingreso de Búsqueda o Incremento de conteo del texto buscado");
            }
            catch (System.Data.SqlClient.SqlException excepcion)
            {
                Logging.ErrorGeneral.Guardar(excepcion);
            }
            catch (EntidadesWeb.Excepciones.ExceptionErrorTransaccion excepcionTransaccion)
            {
                Logging.ErrorGeneral.Guardar(excepcionTransaccion);
            }
            finally
            {
                if (cmd.Connection.State == System.Data.ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }

                if (cmd != null)
                {
                    cmd.Dispose();
                }
            }
        }


        public System.Collections.ObjectModel.ReadOnlyCollection<double> Buscar(string texto)
        {
            List<double> ListaIdsArticulos = new List<double>();
            System.Collections.ObjectModel.ReadOnlyCollection<double> listaReadOnlyBusquedas = null;
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataReader datareader = null;

            try
            {
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = texto;
                cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                cmd.Connection.Open();
                datareader = cmd.ExecuteReader();

                while (datareader.Read())
                {
                    object ValorObject = datareader.GetValue(0);
                    double ValorDouble = Convert.ToDouble(ValorObject);
                    ListaIdsArticulos.Add(ValorDouble);
                }

                // Eliminar duplicados
                ListaIdsArticulos = ListaIdsArticulos.Distinct().ToList();
                listaReadOnlyBusquedas = new System.Collections.ObjectModel.ReadOnlyCollection<double>(ListaIdsArticulos);
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

            return listaReadOnlyBusquedas;
        }

        public string GenerarConsultaSQL(string textoBusqueda)
        {
            throw new NotImplementedException();
        }
    }
}
