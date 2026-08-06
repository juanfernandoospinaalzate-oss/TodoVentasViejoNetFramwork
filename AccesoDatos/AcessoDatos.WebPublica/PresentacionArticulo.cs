//-----------------------------------------------------------------------
// <copyright file="PresentacionArticulo.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace AccesoDatos.WebPublica
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using EntidadesWeb;

    public class PresentacionArticulo : ContratosWeb.IPresentacionArticulo
    {
        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.PresentacionArticulo> Listar()
        {
            List<EntidadesWeb.PresentacionArticulo> ListaPresentacionArticulo = new List<EntidadesWeb.PresentacionArticulo>();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataReader datareader = null;
            System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.PresentacionArticulo> listaReadOnlyPresentacionArticulos = null;
            EntidadesWeb.ResultadoTransaccion resultado = new EntidadesWeb.ResultadoTransaccion();

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "PresentacionArticuloSelectWeb";
                cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                cmd.Connection.Open();
                datareader = cmd.ExecuteReader();

                while (datareader.Read())
                {
                    EntidadesWeb.PresentacionArticulo presentacionArticulo = new EntidadesWeb.PresentacionArticulo();

                    presentacionArticulo.IdPresentacionArticulo = datareader.GetInt32(0);
                    presentacionArticulo.Articulo.IdArticulo = datareader.GetInt32(1);
                    presentacionArticulo.CodigoEAN = datareader.GetString(2);
                    presentacionArticulo.Nombre = datareader.GetString(3);
                    presentacionArticulo.DescripcionBreve = datareader.GetString(4);
                    presentacionArticulo.Color.IdColor = datareader.GetInt32(5);
                    presentacionArticulo.Talla.IdTalla = datareader.GetInt32(6);
                    presentacionArticulo.Fecha = datareader.GetDateTime(13);
                    presentacionArticulo.Imagen1 = datareader.GetBoolean(7);
                    presentacionArticulo.Imagen2 = datareader.GetBoolean(8);
                    presentacionArticulo.Imagen3 = datareader.GetBoolean(9);
                    presentacionArticulo.Imagen4 = datareader.GetBoolean(10);
                    presentacionArticulo.Imagen5 = datareader.GetBoolean(11);
                    presentacionArticulo.Imagen6 = datareader.GetBoolean(12);
                    presentacionArticulo.VlrUnidadMasa = datareader.GetDouble(14);
                    presentacionArticulo.VlrUnidadVolumenAncho = datareader.GetDouble(15);
                    presentacionArticulo.VlrUnidadVolumenLargo = datareader.GetDouble(16);
                    presentacionArticulo.VlrUnidadVolumenProfundidad = datareader.GetDouble(17);
                    presentacionArticulo.VlrUnidadLongitud = datareader.GetDouble(18);
                    presentacionArticulo.UnidadMasa.IdUnidadMasa = datareader.GetInt32(19);
                    presentacionArticulo.UnidadVolumen.IdUnidadVolumen = datareader.GetInt32(20);
                    presentacionArticulo.UnidadLongitud.IdUnidadLongitud = datareader.GetInt32(21);
                    presentacionArticulo.ENLinea = datareader.GetBoolean(22);
                    presentacionArticulo.Activo = datareader.GetBoolean(23);
                    presentacionArticulo.Precio = datareader.GetDouble(24);
                    presentacionArticulo.NombreArticulo = datareader.GetString(25);
                    presentacionArticulo.UnidadMasa.Nombre = datareader.GetString(26);
                    presentacionArticulo.Sabor.Nombre = datareader.GetString(27);
                    presentacionArticulo.Talla.Nombre = datareader.GetString(28);
                    presentacionArticulo.Color.Nombre = datareader.GetString(29);
                    presentacionArticulo.UnidadLongitud.Nombre = datareader.GetString(30);
                    presentacionArticulo.UnidadVolumen.Nombre = datareader.GetString(31);
                    presentacionArticulo.VlrContenidoVolumetrico = datareader.GetDouble(32);
                    presentacionArticulo.Existencias = datareader.GetInt32(33);
                    presentacionArticulo.Sabor.IdSabor = datareader.GetInt32(34);
                    presentacionArticulo.Categoria.IdCategoria = datareader.GetInt32(35);
                    presentacionArticulo.Categoria.IdCategoriaPadre = datareader.GetInt32(36);
                    presentacionArticulo.Categoria.Nombre = datareader.GetString(37);
                    presentacionArticulo.UnidadPresentacion.IdUnidadPresentacion = datareader.GetInt32(38);
                    presentacionArticulo.UnidadPresentacion.Nombre = datareader.GetString(39);
                    presentacionArticulo.VlrUnidadPresentacion = datareader.GetDouble(40);
                    presentacionArticulo.PreOrden = datareader.GetBoolean(41);
                    presentacionArticulo.FechaProximoVencimiento = datareader.GetDateTime(42);
                    presentacionArticulo.Articulo.Marca.IdMarca = datareader.GetInt32(43);
                    presentacionArticulo.Articulo.Marca.Nombre = datareader.GetString(44);
                    presentacionArticulo.UsarFechaProximoVencimiento = datareader.GetBoolean(45);
                    presentacionArticulo.UsarDescuento = datareader.GetBoolean(46);
                    presentacionArticulo.UsarPorcentajeDescuento = datareader.GetBoolean(47);
                    presentacionArticulo.ValorPorcentajeDescuento = datareader.GetDouble(48);
                    presentacionArticulo.UsarValorFijoDescuento = datareader.GetBoolean(49);
                    presentacionArticulo.ValorFijoDescuento = datareader.GetDouble(50);
                    presentacionArticulo.FechaInicioDescuento = datareader.GetDateTime(51);
                    presentacionArticulo.FechaFinalDescuento = datareader.GetDateTime(52);

                    ListaPresentacionArticulo.Add(presentacionArticulo);

                    // Asegura en la prueba de integración solo devolver un elemento (el primero encontrado)
                    #if Pruebas
                        break;
                    #endif
                }

                listaReadOnlyPresentacionArticulos = new System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.PresentacionArticulo>(ListaPresentacionArticulo);
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

            return listaReadOnlyPresentacionArticulos;
        }

        public ReadOnlyCollection<EntidadesWeb.PresentacionArticulo> ListarPendientesActualizacion()
        {
            List<EntidadesWeb.PresentacionArticulo> ListaPresentacionArticulo = null;
            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlDataReader datareader = null;
            System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.PresentacionArticulo> listaReadOnlyPresentacionArticulos = null;

            try
            {
                ListaPresentacionArticulo = new List<EntidadesWeb.PresentacionArticulo>();
                cmd = new System.Data.SqlClient.SqlCommand();
                EntidadesWeb.ResultadoTransaccion resultado = new EntidadesWeb.ResultadoTransaccion();

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "PresentacionArticuloSelectWebPendientesActualizacion";
                cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                cmd.Connection.Open();
                datareader = cmd.ExecuteReader();

                while (datareader.Read())
                {
                    EntidadesWeb.PresentacionArticulo presentacionArticulo = new EntidadesWeb.PresentacionArticulo();

                    presentacionArticulo.IdPresentacionArticulo = datareader.GetInt32(0);
                    presentacionArticulo.Articulo.IdArticulo = datareader.GetInt32(1);
                    presentacionArticulo.CodigoEAN = datareader.GetString(2);
                    presentacionArticulo.Nombre = datareader.GetString(3);
                    presentacionArticulo.DescripcionBreve = datareader.GetString(4);
                    presentacionArticulo.Color.IdColor = datareader.GetInt32(5);
                    presentacionArticulo.Talla.IdTalla = datareader.GetInt32(6);
                    presentacionArticulo.Fecha = datareader.GetDateTime(13);
                    presentacionArticulo.Imagen1 = datareader.GetBoolean(7);
                    presentacionArticulo.Imagen2 = datareader.GetBoolean(8);
                    presentacionArticulo.Imagen3 = datareader.GetBoolean(9);
                    presentacionArticulo.Imagen4 = datareader.GetBoolean(10);
                    presentacionArticulo.Imagen5 = datareader.GetBoolean(11);
                    presentacionArticulo.Imagen6 = datareader.GetBoolean(12);
                    presentacionArticulo.VlrUnidadMasa = datareader.GetDouble(14);
                    presentacionArticulo.VlrUnidadVolumenAncho = datareader.GetDouble(15);
                    presentacionArticulo.VlrUnidadVolumenLargo = datareader.GetDouble(16);
                    presentacionArticulo.VlrUnidadVolumenProfundidad = datareader.GetDouble(17);
                    presentacionArticulo.VlrUnidadLongitud = datareader.GetDouble(18);
                    presentacionArticulo.UnidadMasa.IdUnidadMasa = datareader.GetInt32(19);
                    presentacionArticulo.UnidadVolumen.IdUnidadVolumen = datareader.GetInt32(20);
                    presentacionArticulo.UnidadLongitud.IdUnidadLongitud = datareader.GetInt32(21);
                    presentacionArticulo.ENLinea = datareader.GetBoolean(22);
                    presentacionArticulo.Activo = datareader.GetBoolean(23);
                    presentacionArticulo.Precio = datareader.GetDouble(24);
                    presentacionArticulo.NombreArticulo = datareader.GetString(25);
                    presentacionArticulo.UnidadMasa.Nombre = datareader.GetString(26);
                    presentacionArticulo.Sabor.Nombre = datareader.GetString(27);
                    presentacionArticulo.Talla.Nombre = datareader.GetString(28);
                    presentacionArticulo.Color.Nombre = datareader.GetString(29);
                    presentacionArticulo.UnidadLongitud.Nombre = datareader.GetString(30);
                    presentacionArticulo.UnidadVolumen.Nombre = datareader.GetString(31);
                    presentacionArticulo.VlrContenidoVolumetrico = datareader.GetDouble(32);
                    presentacionArticulo.Existencias = datareader.GetInt32(33);
                    presentacionArticulo.Sabor.IdSabor = datareader.GetInt32(34);
                    presentacionArticulo.Categoria.IdCategoria = datareader.GetInt32(35);
                    presentacionArticulo.Categoria.IdCategoriaPadre = datareader.GetInt32(36);
                    presentacionArticulo.Categoria.Nombre = datareader.GetString(37);
                    presentacionArticulo.UnidadPresentacion.IdUnidadPresentacion = datareader.GetInt32(38);
                    presentacionArticulo.UnidadPresentacion.Nombre = datareader.GetString(39);
                    presentacionArticulo.VlrUnidadPresentacion = datareader.GetDouble(40);

                    presentacionArticulo.PreOrden = datareader.GetBoolean(41);
                    // presentacionArticulo.Marca.IdMarca = datareader.GetInt32(42);
                    // presentacionArticulo.Marca.Nombre = datareader.GetString(43);
                    presentacionArticulo.FechaProximoVencimiento = datareader.GetDateTime(44);
                    presentacionArticulo.UsarFechaProximoVencimiento = datareader.GetBoolean(45);
                    presentacionArticulo.UsarDescuento = datareader.GetBoolean(46);
                    presentacionArticulo.UsarPorcentajeDescuento = datareader.GetBoolean(47);
                    presentacionArticulo.ValorPorcentajeDescuento = datareader.GetDouble(48);
                    presentacionArticulo.UsarValorFijoDescuento = datareader.GetBoolean(49);
                    presentacionArticulo.ValorFijoDescuento = datareader.GetDouble(50);
                    presentacionArticulo.FechaInicioDescuento = datareader.GetDateTime(51);
                    presentacionArticulo.FechaFinalDescuento = datareader.GetDateTime(52);

                    ListaPresentacionArticulo.Add(presentacionArticulo);

                    // Asegura en la prueba de integración solo devolver un elemento (el primero encontrado)
                    #if Pruebas
                        break; 
                    #endif
                }

                listaReadOnlyPresentacionArticulos = new System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.PresentacionArticulo>(ListaPresentacionArticulo);
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

            return listaReadOnlyPresentacionArticulos;
        }

        public ReadOnlyCollection<EntidadesWeb.PresentacionArticulo> ListarPorIdArticulo(int idArticulo)
        {
            List<EntidadesWeb.PresentacionArticulo> ListaPresentacionesDelArticulo = new List<EntidadesWeb.PresentacionArticulo>();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataReader dr = null;
            System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.PresentacionArticulo> listaReadOnlyArticulosPorIdPresentacion = null;
            System.Data.SqlClient.SqlParameter paramIdPArticulo = null;

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[PresentacionArticuloSelectWebPorIdArticulo]";
                paramIdPArticulo = new System.Data.SqlClient.SqlParameter("@IdArticulo", System.Data.SqlDbType.Int);
                paramIdPArticulo.Value = idArticulo;
                cmd.Parameters.Add(paramIdPArticulo);

                cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                cmd.Connection.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    EntidadesWeb.PresentacionArticulo presentacionArticulo = new EntidadesWeb.PresentacionArticulo()
                    {
                        IdPresentacionArticulo = dr.GetInt32(0),
                        Articulo = new EntidadesWeb.Articulo() { IdArticulo = dr.GetInt32(1), Titulo = dr.GetString(25) },
                        CodigoEAN = dr.GetString(2),
                        Nombre = dr.GetString(3),
                        NombreArticulo = dr.GetString(25),
                        DescripcionBreve = dr.GetString(4),
                        Color = new EntidadesWeb.Color() { IdColor = dr.GetInt32(5), Nombre = dr.GetString(29) },
                        Talla = new EntidadesWeb.Talla() { IdTalla = dr.GetInt32(6), Nombre = dr.GetString(28) },
                        Imagen1 = dr.GetBoolean(7),
                        Imagen2 = dr.GetBoolean(8),
                        Imagen3 = dr.GetBoolean(9),
                        Imagen4 = dr.GetBoolean(10),
                        Imagen5 = dr.GetBoolean(11),
                        Imagen6 = dr.GetBoolean(12),
                        Fecha = dr.GetDateTime(13),
                        VlrUnidadMasa = dr.GetDouble(14),
                        VlrUnidadVolumenLargo = dr.GetDouble(15),
                        VlrUnidadVolumenAncho = dr.GetDouble(16),
                        VlrUnidadVolumenProfundidad = dr.GetDouble(17),
                        VlrUnidadLongitud = dr.GetDouble(18),
                        UnidadMasa = new EntidadesWeb.UnidadMasa() { IdUnidadMasa = dr.GetInt32(19), Nombre = dr.GetString(26) },
                        UnidadVolumen = new EntidadesWeb.UnidadVolumen() { IdUnidadVolumen = dr.GetInt32(20), Nombre = dr.GetString(31) },
                        UnidadLongitud = new EntidadesWeb.UnidadLongitud() { IdUnidadLongitud = dr.GetInt32(21), Nombre = dr.GetString(30) },
                        ENLinea = dr.GetBoolean(22),
                        Activo = dr.GetBoolean(23),
                        Precio = dr.GetDouble(24),
                        Sabor = new EntidadesWeb.Sabor() { IdSabor = dr.GetInt32(34), Nombre = dr.GetString(27) },
                        VlrContenidoVolumetrico = dr.GetDouble(32),
                        Existencias = dr.GetInt32(33),
                        Categoria = new EntidadesWeb.Categoria() { IdCategoria = dr.GetInt32(35), IdCategoriaPadre = dr.GetInt32(36), Nombre = dr.GetString(37) },
                        UnidadPresentacion = new EntidadesWeb.UnidadPresentacion() { IdUnidadPresentacion = dr.GetInt32(38), Nombre = dr.GetString(39) },
                        VlrUnidadPresentacion = dr.GetDouble(40),
                        PreOrden = dr.GetBoolean(41),
                    };

                    ListaPresentacionesDelArticulo.Add(presentacionArticulo);

                    #if Pruebas
                        break;
                    #endif
                }

                listaReadOnlyArticulosPorIdPresentacion = new System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.PresentacionArticulo>(ListaPresentacionesDelArticulo);
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

                if (dr != null)
                {
                    dr.Dispose();
                }

                if (cmd != null)
                {
                    cmd.Dispose();
                }
            }

            return listaReadOnlyArticulosPorIdPresentacion;
        }

        public EntidadesWeb.PresentacionArticulo ConsultarPorIdPresentacionArticulo(int idPresentacionArticulo)
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataReader datareader = null;
            System.Data.SqlClient.SqlParameter paramIdPresentacionArticulo = null;
            EntidadesWeb.PresentacionArticulo presentacionArticulo = null;

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "PresentacionArticuloSelectWebPorIdPresentacionArticulo";
                paramIdPresentacionArticulo = new System.Data.SqlClient.SqlParameter("@IdPresentacionArticulo", System.Data.SqlDbType.Int);
                paramIdPresentacionArticulo.Value = idPresentacionArticulo;
                cmd.Parameters.Add(paramIdPresentacionArticulo);

                cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                cmd.Connection.Open();
                datareader = cmd.ExecuteReader();

                if (datareader.Read())
                {
                    presentacionArticulo = new EntidadesWeb.PresentacionArticulo();

                    presentacionArticulo.IdPresentacionArticulo = datareader.GetInt32(0);
                    presentacionArticulo.Articulo.IdArticulo = datareader.GetInt32(1);
                    presentacionArticulo.CodigoEAN = datareader.GetString(2);
                    presentacionArticulo.Nombre = datareader.GetString(3);
                    presentacionArticulo.DescripcionBreve = datareader.GetString(4);
                    presentacionArticulo.Color.IdColor = datareader.GetInt32(5);
                    presentacionArticulo.Talla.IdTalla = datareader.GetInt32(6);
                    presentacionArticulo.Fecha = datareader.GetDateTime(13);
                    presentacionArticulo.Imagen1 = datareader.GetBoolean(7);
                    presentacionArticulo.Imagen2 = datareader.GetBoolean(8);
                    presentacionArticulo.Imagen3 = datareader.GetBoolean(9);
                    presentacionArticulo.Imagen4 = datareader.GetBoolean(10);
                    presentacionArticulo.Imagen5 = datareader.GetBoolean(11);
                    presentacionArticulo.Imagen6 = datareader.GetBoolean(12);
                    presentacionArticulo.VlrUnidadMasa = datareader.GetDouble(14);
                    presentacionArticulo.VlrUnidadVolumenAncho = datareader.GetDouble(15);
                    presentacionArticulo.VlrUnidadVolumenLargo = datareader.GetDouble(16);
                    presentacionArticulo.VlrUnidadVolumenProfundidad = datareader.GetDouble(17);
                    presentacionArticulo.VlrUnidadLongitud = datareader.GetDouble(18);
                    presentacionArticulo.UnidadMasa.IdUnidadMasa = datareader.GetInt32(19);
                    presentacionArticulo.UnidadVolumen.IdUnidadVolumen = datareader.GetInt32(20);
                    presentacionArticulo.UnidadLongitud.IdUnidadLongitud = datareader.GetInt32(21);
                    presentacionArticulo.ENLinea = datareader.GetBoolean(22);
                    presentacionArticulo.Activo = datareader.GetBoolean(23);
                    presentacionArticulo.Precio = datareader.GetDouble(24);
                    presentacionArticulo.NombreArticulo = datareader.GetString(25);
                    presentacionArticulo.UnidadMasa.Nombre = datareader.GetString(26);
                    presentacionArticulo.Sabor.Nombre = datareader.GetString(27);
                    presentacionArticulo.Talla.Nombre = datareader.GetString(28);
                    presentacionArticulo.Color.Nombre = datareader.GetString(29);
                    presentacionArticulo.UnidadLongitud.Nombre = datareader.GetString(30);
                    presentacionArticulo.UnidadVolumen.Nombre = datareader.GetString(31);
                    presentacionArticulo.VlrContenidoVolumetrico = datareader.GetDouble(32);
                    presentacionArticulo.Existencias = datareader.GetInt32(33);
                    presentacionArticulo.Sabor.IdSabor = datareader.GetInt32(34);
                    presentacionArticulo.Categoria.IdCategoria = datareader.GetInt32(35);
                    presentacionArticulo.Categoria.IdCategoriaPadre = datareader.GetInt32(36);
                    presentacionArticulo.Categoria.Nombre = datareader.GetString(37);
                    presentacionArticulo.UnidadPresentacion.IdUnidadPresentacion = datareader.GetInt32(38);
                    presentacionArticulo.UnidadPresentacion.Nombre = datareader.GetString(39);
                    presentacionArticulo.VlrUnidadPresentacion = datareader.GetDouble(40);
                    presentacionArticulo.PreOrden = datareader.GetBoolean(41);
                    presentacionArticulo.FechaProximoVencimiento = datareader.GetDateTime(42);
                    presentacionArticulo.Articulo.Marca.IdMarca = datareader.GetInt32(43);
                    presentacionArticulo.Articulo.Marca.Nombre = datareader.GetString(44);
                    presentacionArticulo.UsarFechaProximoVencimiento = datareader.GetBoolean(45);
                    presentacionArticulo.UsarDescuento = datareader.GetBoolean(46);
                    presentacionArticulo.UsarPorcentajeDescuento = datareader.GetBoolean(47);
                    presentacionArticulo.ValorPorcentajeDescuento = datareader.GetDouble(48);
                    presentacionArticulo.UsarValorFijoDescuento = datareader.GetBoolean(49);
                    presentacionArticulo.ValorFijoDescuento = datareader.GetDouble(50);
                    presentacionArticulo.FechaInicioDescuento = datareader.GetDateTime(51);
                    presentacionArticulo.FechaFinalDescuento = datareader.GetDateTime(52);
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

            return presentacionArticulo;
        }

        public ResultadoTransaccion QuitarMarcaActualizarPresentacionArticulo(int idPresentacionArticulo)
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlParameter paramIdPresentacionArticulo = new System.Data.SqlClient.SqlParameter("@IdPresentacionArticulo", System.Data.SqlDbType.Int);
            EntidadesWeb.ResultadoTransaccion resultadoTransaccion = new EntidadesWeb.ResultadoTransaccion();

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "PresentacionArticuloUpdateQuitarMarcaActualizar";

                paramIdPresentacionArticulo.Value = idPresentacionArticulo;
                cmd.Parameters.Add(paramIdPresentacionArticulo);
                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();
                resultadoTransaccion.RegistrosAfectados = cmd.ExecuteNonQuery();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Logging.ErrorGeneral.Guardar(ex);
            }
            catch (EntidadesWeb.Excepciones.ExceptionErrorTransaccion ex)
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
            }

            return resultadoTransaccion;
        }
    }
}
