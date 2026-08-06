//-----------------------------------------------------------------------
// <copyright file="Direccion.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace AccesoDatos.TablasMaestras
{
    using System.Collections.Generic;

    /// <summary>
    /// Administra las direcciones del cliente
    /// </summary>
    public class Direccion : Contratos.IDireccion
    {
        /// <summary>
        /// Obtiene todas las direcciones asociadas a un cliente
        /// </summary>
        /// <param name="idCliente">Identificación del cliente en la base de datos</param>
        /// <returns>listado de direcciones asociadas al cliente encontrado</returns>
        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Direccion> ConsultarDireccionPorId(int idCliente)
        {
            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlParameter paramIdDireccion = null;
            System.Data.SqlClient.SqlDataReader datareader = null;
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();
            System.Collections.Generic.List<Entidades.Direccion> listaDirecciones = new List<Entidades.Direccion>(); 

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "DireccionSelectIdUsuario";
                paramIdDireccion = new System.Data.SqlClient.SqlParameter("@IdUsuario", System.Data.SqlDbType.Int);
                paramIdDireccion.Value = idCliente;
                cmd.Parameters.Add(paramIdDireccion);

                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();
                datareader = cmd.ExecuteReader();

                if (datareader.Read())
                {
                    Entidades.Direccion direccion = new Entidades.Direccion();
                    direccion.IdDireccion = datareader.GetInt32(0);
                    direccion.NombreDestinatario = datareader.GetString(1);
                    direccion.DireccionEnvio = datareader.GetString(2);
                    direccion.Telefono = datareader.GetString(3);
                    direccion.Pais.IdPais = datareader.GetInt32(4);
                    direccion.Departamento.IdDepartamento = datareader.GetInt32(5);
                    direccion.Ciudad.IdCiudad = datareader.GetInt32(6);
                    direccion.IdCliente = datareader.GetInt32(7);
                    direccion.Pais.Nombre = datareader.GetString(8);
                    direccion.Departamento.Nombre = datareader.GetString(9);
                    direccion.Ciudad.Nombre = datareader.GetString(10);
                    listaDirecciones.Add(direccion);
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Logging.ErrorGeneral.Guardar(ex);
            }
            catch (Entidades.Excepciones.ExceptionErrorTransaccion ex)
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(ex);
            }
            finally
            {
                if (cmd.Connection.State == System.Data.ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }

                cmd.Dispose();
            }

            return new System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Direccion>(listaDirecciones);
        }
    }
}
