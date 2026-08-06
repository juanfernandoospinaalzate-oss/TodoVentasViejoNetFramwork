//-----------------------------------------------------------------------
// <copyright file="Abonos.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace AccesoDatos.TablasMaestras
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class Abonos : Contratos.IAbonos
    {
        public ReadOnlyCollection<Entidades.Abonos> Listar(string criterioBusqueda)
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlParameter paramCriterioBusqueda = null;
            System.Data.SqlClient.SqlDataReader datareader = null;
            List<Entidades.Abonos> LstAbonos = new List<Entidades.Abonos>();
            System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Abonos> ListaReadOnlyAbonos = null;

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "AbonosPorCriterioSelect";
                paramCriterioBusqueda = new System.Data.SqlClient.SqlParameter("@CriterioBusqueda", System.Data.SqlDbType.VarChar);

                paramCriterioBusqueda.Value = criterioBusqueda;
                cmd.Parameters.Add(paramCriterioBusqueda);

                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();
                datareader = cmd.ExecuteReader();

                while (datareader.Read())
                {
                    Entidades.Abonos abonos = new Entidades.Abonos();

                    abonos.IdAbono = datareader.GetInt32(0);
                    abonos.IdAlbaran = datareader.GetInt32(1);
                    abonos.ValorAbono = datareader.GetDouble(2);
                    abonos.Fecha = datareader.GetDateTime(3);
                    abonos.MedioDePago = datareader.GetString(4);
                    abonos.NroFactura = datareader.GetInt32(5);
                    abonos.NombreCompletoCliente = datareader.GetString(6);
                    
                    LstAbonos.Add(abonos);
                }

                ListaReadOnlyAbonos = new System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Abonos>(LstAbonos);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Logging.ErrorGeneral.Guardar(ex);
            }
            catch (Entidades.Excepciones.ExceptionErrorTransaccion)
            {
                Entidades.Mensaje mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(mensaje.Texto));
                throw new Entidades.Excepciones.ExceptionErrorTransaccion(mensaje.Texto);
            }
            finally
            {
                if (cmd.Connection.State == System.Data.ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }

                cmd.Dispose();
            }
            return ListaReadOnlyAbonos;
        }
    }
}
