//-----------------------------------------------------------------------
// <copyright file="Departamento.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace AccesoDatos.TablasMaestras
{
    using System.Collections.Generic;

    public class Departamento : Contratos.IDepartamento
    {
        public Entidades.ResultadoTransaccion Insertar(Entidades.Departamento departamento)
        {
            if (departamento == null)
            {
                Entidades.Mensaje mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(mensaje.Texto));
                throw new Entidades.Excepciones.ExceptionErrorTransaccion(mensaje.Texto);
            }

            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlParameter paramNombre = null;
            System.Data.SqlClient.SqlParameter paramIdPais = null;
            Entidades.ResultadoTransaccion resultado = new Entidades.ResultadoTransaccion();
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "DepartamentoInsert";

                paramNombre = new System.Data.SqlClient.SqlParameter("@Nombre", System.Data.SqlDbType.NVarChar, 42);
                paramNombre.Value = departamento.Nombre;
                cmd.Parameters.Add(paramNombre);

                paramIdPais = new System.Data.SqlClient.SqlParameter("@IdPais", System.Data.SqlDbType.Int);
                paramIdPais.Value = departamento.Pais.IdPais;
                cmd.Parameters.Add(paramIdPais);

                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();
                int i = cmd.ExecuteNonQuery();
                resultado.RegistrosAfectados = i;
                resultado.Mensaje = Mensajes.LinqToXml.LeerMensaje("0009");
            }
            catch (System.Data.SqlClient.SqlException)
            {
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
            }
            catch (Entidades.Excepciones.ExceptionErrorTransaccion)
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                return resultadoTransaccion;
            }
            finally
            {
                if (cmd.Connection.State == System.Data.ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }

                cmd.Dispose();
            }

            return resultado;
        }


        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Departamento> Listar(int idPais)
        {
            List<Entidades.Departamento> ListDepartamento = new List<Entidades.Departamento>();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataReader datareader = null;
            System.Data.SqlClient.SqlParameter paramIdPais = null;
            System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Departamento> listaReadOnlyDepartamento = null;

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "DepartamentoSelect";

                paramIdPais = new System.Data.SqlClient.SqlParameter("@IdPais", System.Data.SqlDbType.Int);
                paramIdPais.Value = idPais;
                cmd.Parameters.Add(paramIdPais);


                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();
                datareader = cmd.ExecuteReader();

                while (datareader.Read())
                {
                    Entidades.Departamento departamento = new Entidades.Departamento();
                    departamento.IdDepartamento = datareader.GetInt32(0);
                    departamento.Pais.IdPais = datareader.GetInt32(1);
                    departamento.Nombre = datareader.GetString(2);

                    ListDepartamento.Add(departamento);
                }

                listaReadOnlyDepartamento = new System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Departamento>(ListDepartamento);
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

            return listaReadOnlyDepartamento;
        }


        public Entidades.ResultadoTransaccion Actualizar(Entidades.Departamento departamento)
        {
            if (departamento == null)
            {
                Entidades.Mensaje mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(mensaje.Texto));
                throw new Entidades.Excepciones.ExceptionErrorTransaccion(mensaje.Texto);
            }

            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlParameter paramIdDepartamento = null;
            System.Data.SqlClient.SqlParameter paramNombre = null;
            Entidades.ResultadoTransaccion resultado = new Entidades.ResultadoTransaccion();
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "DepartamentoUpdate";

                paramIdDepartamento = new System.Data.SqlClient.SqlParameter("@IdDepartamento", System.Data.SqlDbType.Int);
                paramIdDepartamento.Value = departamento.IdDepartamento;
                cmd.Parameters.Add(paramIdDepartamento);

                paramNombre = new System.Data.SqlClient.SqlParameter("@Nombre", System.Data.SqlDbType.NVarChar, 42);
                paramNombre.Value = departamento.Nombre;
                cmd.Parameters.Add(paramNombre);

                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();
                int i = cmd.ExecuteNonQuery();
                resultado.RegistrosAfectados = i;
                resultado.Mensaje = Mensajes.LinqToXml.LeerMensaje("0007");
            }
            catch (System.Data.SqlClient.SqlException)
            {
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
            }
            catch (Entidades.Excepciones.ExceptionErrorTransaccion)
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                return resultadoTransaccion;
            }
            finally
            {
                if (cmd.Connection.State == System.Data.ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }

                cmd.Dispose();
            }

            return resultado;
        }


        public Entidades.ResultadoTransaccion Eliminar(int idDepartamento)
        {
            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlParameter paramIdDepartamento = null;
            Entidades.ResultadoTransaccion resultado = new Entidades.ResultadoTransaccion();
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "DepartamentoDelete";

                paramIdDepartamento = new System.Data.SqlClient.SqlParameter("@IdDepartamento", System.Data.SqlDbType.Int);
                paramIdDepartamento.Value = idDepartamento;
                cmd.Parameters.Add(paramIdDepartamento);

                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();
                int i = cmd.ExecuteNonQuery();
                resultado.RegistrosAfectados = i;
                resultado.Mensaje = Mensajes.LinqToXml.LeerMensaje("0006");
            }
            catch (System.Data.SqlClient.SqlException)
            {
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
            }
            catch (Entidades.Excepciones.ExceptionErrorTransaccion)
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                return resultadoTransaccion;
            }
            finally
            {
                if (cmd.Connection.State == System.Data.ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }

                cmd.Dispose();
            }

            return resultado;
        }
    }
}
