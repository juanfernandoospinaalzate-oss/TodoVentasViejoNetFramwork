//-----------------------------------------------------------------------
// <copyright file="Categoria.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace AccesoDatos.WebPublica
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class Categoria : ContratosWeb.ICategoria
    {
        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Categoria> Listar()
        {
            List<EntidadesWeb.Categoria> categorias = new List<EntidadesWeb.Categoria>();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataReader datareader = null;
            System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Categoria> listaReadOnlycategorias = null;

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "CategoriaSelect";
                cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                cmd.Connection.Open();
                datareader = cmd.ExecuteReader();
                while (datareader.Read())
                {
                    EntidadesWeb.Categoria categoria = new EntidadesWeb.Categoria()
                    {
                        IdCategoria = datareader.GetInt32(0),
                        IdCategoriaPadre = datareader.GetInt32(1),
                        Nombre = datareader.GetString(2),
                        Descripcion = datareader.GetString(3),
                        PalabraClave = datareader.GetString(4)
                    };
                    categorias.Add(categoria);
                }

                listaReadOnlycategorias = new System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Categoria>(categorias);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Logging.ErrorGeneral.Guardar(ex);
            }
            catch (EntidadesWeb.Excepciones.ExceptionErrorTransaccion)
            {
                EntidadesWeb.Mensaje mensaje = MensajesWeb.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new EntidadesWeb.Excepciones.ExceptionErrorTransaccion(mensaje.Texto));
                throw new EntidadesWeb.Excepciones.ExceptionErrorTransaccion(mensaje.Texto);
            }
            catch (Exception ex)
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

            return listaReadOnlycategorias;
        }

        public ReadOnlyCollection<EntidadesWeb.Categoria> ListarCategoriasUsadas()
        {
            List<EntidadesWeb.Categoria> categorias = new List<EntidadesWeb.Categoria>();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataReader datareader = null;
            System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Categoria> listaReadOnlycategorias = null;

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "CategoriaSelectUsadas";
                cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                cmd.Connection.Open();
                datareader = cmd.ExecuteReader();
                while (datareader.Read())
                {
                    EntidadesWeb.Categoria categoria = new EntidadesWeb.Categoria()
                    {
                        IdCategoria = datareader.GetInt32(0),
                        IdCategoriaPadre = datareader.GetInt32(1),
                        Nombre = datareader.GetString(2),
                        Descripcion = datareader.GetString(3),
                        PalabraClave = datareader.GetString(4)
                    };
                    categorias.Add(categoria);

                    #if Pruebas
                        break;
                    #endif
                }

                listaReadOnlycategorias = new System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Categoria>(categorias);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Logging.ErrorGeneral.Guardar(ex);
            }
            catch (EntidadesWeb.Excepciones.ExceptionErrorTransaccion)
            {
                EntidadesWeb.Mensaje mensaje = MensajesWeb.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new EntidadesWeb.Excepciones.ExceptionErrorTransaccion(mensaje.Texto));
                throw new EntidadesWeb.Excepciones.ExceptionErrorTransaccion(mensaje.Texto);
            }
            catch (Exception ex)
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

            return listaReadOnlycategorias;
        }
    }
}
