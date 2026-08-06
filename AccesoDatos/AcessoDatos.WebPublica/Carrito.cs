//-----------------------------------------------------------------------
// <copyright file="Carrito.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace AccesoDatos.WebPublica
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ContratosWeb;
    using EntidadesWeb;
    
    /// <summary>
    /// Administra los datos del carrito de compras
    /// </summary>
    public class Carrito : ICarrito
    {
        /// <summary>
        /// Elimina un item del carrito
        /// </summary>
        /// <param name="idItemCarrito">Identificación única del registro</param>
        /// <returns>Resultado con mensaje y cantidad de registros afectados</returns>
        public EntidadesWeb.ResultadoTransaccion Eliminar(int idItemCarrito)
        {
            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlParameter paramIdItemCarrito = null;
            EntidadesWeb.ResultadoTransaccion resultado = new EntidadesWeb.ResultadoTransaccion();
            EntidadesWeb.ResultadoTransaccion resultadoTransaccion = new EntidadesWeb.ResultadoTransaccion();

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "CarritoDelete";

                paramIdItemCarrito = new System.Data.SqlClient.SqlParameter("@IdItemCarrito", System.Data.SqlDbType.Int);
                paramIdItemCarrito.Value = idItemCarrito;
                cmd.Parameters.Add(paramIdItemCarrito);

                cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                cmd.Connection.Open();
                cmd.Transaction = cmd.Connection.BeginTransaction();
                int i = cmd.ExecuteNonQuery();

                #if Pruebas
                    cmd.Transaction.Rollback();
                #else
                    cmd.Transaction.Commit();
                #endif

                resultado.RegistrosAfectados = i;
                resultado.Mensaje = MensajesWeb.LinqToXml.LeerMensaje("0006");
            }
            catch (System.Data.SqlClient.SqlException)
            {
                Logging.ErrorGeneral.Guardar(new EntidadesWeb.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
            }
            catch (EntidadesWeb.Excepciones.ExceptionErrorTransaccion)
            {
                resultadoTransaccion.Mensaje = MensajesWeb.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new EntidadesWeb.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                return resultadoTransaccion;
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

            return resultado;
        }

        /// <summary>
        /// Actualiza la cantidad de un registro en el carrito
        /// </summary>
        /// <param name="carrito">Datos del carrito, solo se necesita la nueva cantidad y el identificador del registro</param>
        /// <returns>Resultado con mensaje y cantidad de registros afectados</returns>
        public EntidadesWeb.ResultadoTransaccion Actualizar(EntidadesWeb.ItemCarrito carrito)
        {
            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlParameter paramIdItemCarrito = null;
            System.Data.SqlClient.SqlParameter paramCantidad = null;

            EntidadesWeb.ResultadoTransaccion resultado = new EntidadesWeb.ResultadoTransaccion();
            EntidadesWeb.ResultadoTransaccion resultadoTransaccion = new EntidadesWeb.ResultadoTransaccion();
            
            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "CarritoUpdate";

                paramIdItemCarrito = new System.Data.SqlClient.SqlParameter("@IdItemCarrito", System.Data.SqlDbType.NVarChar, 20);
                paramIdItemCarrito.Value = carrito.IdItemCarrito;
                cmd.Parameters.Add(paramIdItemCarrito);

                paramCantidad = new System.Data.SqlClient.SqlParameter("@Cantidad", System.Data.SqlDbType.Int);
                paramCantidad.Value = carrito.Cantidad;
                cmd.Parameters.Add(paramCantidad);

                cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                cmd.Connection.Open();
                cmd.Transaction = cmd.Connection.BeginTransaction();
                int i = cmd.ExecuteNonQuery();

                #if Pruebas
                    cmd.Transaction.Rollback();
                #else
                    cmd.Transaction.Commit();
                #endif

                resultado.RegistrosAfectados = i;
                resultado.Mensaje = MensajesWeb.LinqToXml.LeerMensaje("0007");
            }
            catch (System.Data.SqlClient.SqlException)
            {
                Logging.ErrorGeneral.Guardar(new EntidadesWeb.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
            }
            catch (EntidadesWeb.Excepciones.ExceptionErrorTransaccion)
            {
                resultadoTransaccion.Mensaje = MensajesWeb.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new EntidadesWeb.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                return resultadoTransaccion;
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

            return resultado;
        }

        /// <summary>
        /// Recupera todos los items de carrito asociados a la identificación del usuario
        /// </summary>
        /// <param name="idUsuario">Identificación del usuario en la base de datos</param>
        /// <returns>Lista con los registros recuperados</returns>
        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.ItemCarrito> Listar(int idUsuario)
        {
            List<EntidadesWeb.ItemCarrito> listaCarrito = new List<EntidadesWeb.ItemCarrito>();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlParameter paramIdUsuario = null;
            System.Data.SqlClient.SqlDataReader datareader = null;
            System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.ItemCarrito> listaReadOnlyCarrito = null;

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "CarritoSelect";

                paramIdUsuario = new System.Data.SqlClient.SqlParameter("@IdUsuario", System.Data.SqlDbType.Int);
                paramIdUsuario.Value = idUsuario;
                cmd.Parameters.Add(paramIdUsuario);

                cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                cmd.Connection.Open();
                datareader = cmd.ExecuteReader();

                while (datareader.Read())
                {
                    EntidadesWeb.ItemCarrito carrito = new EntidadesWeb.ItemCarrito();

                    carrito.IdItemCarrito = datareader.GetInt32(0);
                    carrito.IdUsuario = datareader.GetInt32(1);
                    carrito.IdPrestacionArticulo = datareader.GetInt32(2);
                    carrito.Cantidad = datareader.GetInt32(3);
                    carrito.Nombre = datareader.GetString(4);
                    carrito.Precio = datareader.GetDouble(5);

                    listaCarrito.Add(carrito);
                }

                listaReadOnlyCarrito = new System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.ItemCarrito>(listaCarrito);
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

            return listaReadOnlyCarrito;
        }

        /// <summary>
        /// Ingresa un registro nuevo al carrito
        /// </summary>
        /// <param name="carrito">Datos a registrar, idenficación del usuario, identificación de la presentación del artículo y cantidad</param>
        /// <returns>Resultado con mensaje y cantidad de registros afectados</returns>
        public EntidadesWeb.ResultadoTransaccion Insertar(EntidadesWeb.ItemCarrito carrito)
        {
            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlParameter paramIdUsuario = null;
            System.Data.SqlClient.SqlParameter paramIdPresentacionArticulo = null;
            System.Data.SqlClient.SqlParameter paramCantidad = null;
            EntidadesWeb.ResultadoTransaccion resultado = null;
            EntidadesWeb.ResultadoTransaccion resultadoTransaccion = null;

            try
            {
                resultado = new EntidadesWeb.ResultadoTransaccion();
                resultadoTransaccion = new EntidadesWeb.ResultadoTransaccion();
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "CarritoInsert";

                paramIdUsuario = new System.Data.SqlClient.SqlParameter("@IdUsuario", System.Data.SqlDbType.Int);
                paramIdUsuario.Value = carrito.IdUsuario;
                cmd.Parameters.Add(paramIdUsuario);

                paramIdPresentacionArticulo = new System.Data.SqlClient.SqlParameter("@IdPresentacionArticulo", System.Data.SqlDbType.Int);
                paramIdPresentacionArticulo.Value = carrito.IdPrestacionArticulo;
                cmd.Parameters.Add(paramIdPresentacionArticulo);

                paramCantidad = new System.Data.SqlClient.SqlParameter("@Cantidad", System.Data.SqlDbType.Int);
                paramCantidad.Value = carrito.Cantidad;
                cmd.Parameters.Add(paramCantidad);

                cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                cmd.Connection.Open();
                cmd.Transaction = cmd.Connection.BeginTransaction();
                int i = cmd.ExecuteNonQuery();

                #if Pruebas
                    cmd.Transaction.Rollback();
                #else
                    cmd.Transaction.Commit();
                #endif

                resultado.RegistrosAfectados = i;
                resultado.Mensaje = MensajesWeb.LinqToXml.LeerMensaje("0009");
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                resultado.Mensaje.Texto = ex.Message;
                Logging.ErrorGeneral.Guardar(ex);
            }
            catch (EntidadesWeb.Excepciones.ExceptionErrorTransaccion ex)
            {
                resultado.Mensaje.Texto = ex.Message;
                Logging.ErrorGeneral.Guardar(ex);
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

            return resultado;
        }

        /// <summary>
        /// Recupera el registro del carrito asociado a los parámetros con la cantidad en el carrito
        /// </summary>
        /// <param name="IdPresentacionArticulo">Identificación de la presentación de artículo</param>
        /// <param name="IdUsuario">Identificación del usuario en la base de datos</param>
        /// <returns>Item de carrito con su Id, la cantidad y nombre</returns>
        public EntidadesWeb.ItemCarrito ConsultarPorIdPresentacionArticulo(int IdPresentacionArticulo, int IdUsuario)
        {
            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlDataReader datareader = null;
            System.Data.SqlClient.SqlParameter paramIdPresentacionArticulo = null;
            System.Data.SqlClient.SqlParameter paramIdUsuario = null;
            EntidadesWeb.ResultadoTransaccion resultadoTransaccion = null;
            EntidadesWeb.ItemCarrito itemCarrito = null;

            try
            {
                resultadoTransaccion = new EntidadesWeb.ResultadoTransaccion();
                itemCarrito = new EntidadesWeb.ItemCarrito();

                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "CarritoConsultarPorIdPresentacionArticulo";

                paramIdPresentacionArticulo = new System.Data.SqlClient.SqlParameter("@IdPresentacionArticulo", System.Data.SqlDbType.Int);
                paramIdPresentacionArticulo.Value = IdPresentacionArticulo;
                cmd.Parameters.Add(paramIdPresentacionArticulo);

                paramIdUsuario = new System.Data.SqlClient.SqlParameter("@IdUsuario", System.Data.SqlDbType.Int);
                paramIdUsuario.Value = IdUsuario;
                cmd.Parameters.Add(paramIdUsuario);

                cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                cmd.Connection.Open();
                datareader = cmd.ExecuteReader();

                if (datareader.Read())
                {
                    itemCarrito.IdItemCarrito = datareader.GetInt32(0);
                    itemCarrito.IdUsuario = datareader.GetInt32(1);
                    itemCarrito.IdPrestacionArticulo = datareader.GetInt32(2);
                    itemCarrito.Cantidad = datareader.GetInt32(3); // cargar la cantidad existente en el carrito
                    itemCarrito.Nombre = datareader.GetString(4);
                }
                else
                {
                    itemCarrito = null;
                }
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

                if (datareader != null)
                {
                    datareader.Dispose();
                }

                if (cmd != null)
                {
                    cmd.Dispose();
                }
            }

            return itemCarrito;
        }

        /// <summary>
        /// Obtiene la suma de todos los artículos del carrito para el usuario
        /// </summary>
        /// <param name="IdUsuario"></param>
        /// <returns></returns>
        public double TotalPorIdUsuario(int IdUsuario)
        {
            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlParameter paramIdUsuario = null;

            EntidadesWeb.ResultadoTransaccion resultado = new EntidadesWeb.ResultadoTransaccion();
            resultado.ValorAuxiliar = 0;
            EntidadesWeb.ResultadoTransaccion resultadoTransaccion = new EntidadesWeb.ResultadoTransaccion();
            EntidadesWeb.ItemCarrito itemCarrito = new EntidadesWeb.ItemCarrito();
            try
            {
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "CarritoTotalPorIdUsuario";

                paramIdUsuario = new System.Data.SqlClient.SqlParameter("@IdUsuario", System.Data.SqlDbType.Int);
                paramIdUsuario.Value = IdUsuario;
                cmd.Parameters.Add(paramIdUsuario);

                cmd.Connection = AccesoDatos.WebPublica.Conexion.NuevaConexion();
                cmd.Connection.Open();
                resultado.ValorAuxiliar = cmd.ExecuteScalar().ToString();
                resultado.Mensaje = MensajesWeb.LinqToXml.LeerMensaje("0009");
            }
            catch (System.Data.SqlClient.SqlException)
            {
                Logging.ErrorGeneral.Guardar(new EntidadesWeb.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
            }
            catch (EntidadesWeb.Excepciones.ExceptionErrorTransaccion)
            {
                resultadoTransaccion.Mensaje = MensajesWeb.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new EntidadesWeb.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
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

            if (resultado.ValorAuxiliar.ToString() == string.Empty)
            {
                return 0;
            }
            else
            {
                return double.Parse(resultado.ValorAuxiliar.ToString());
            }
        }

        public string GenerarPreferenciaPago(List<ItemCarrito> ListadoCarrito, EntidadesWeb.Cliente objCliente, EntidadesWeb.Direccion objDireccion, EntidadesWeb.Enumeraciones.MedioPago formaDePago, double tasaDeCambioDolar, string urlBase)
        {
            int numeroAlbaran = int.MinValue;

            numeroAlbaran = this.GuardarListadoCarrito(ListadoCarrito, objCliente, objDireccion); 

            string RespuestaPreferencia = string.Empty;
            if (formaDePago == EntidadesWeb.Enumeraciones.MedioPago.PayPal)
            {
                RespuestaPreferencia = this.ConstruirJsonPayPal(ListadoCarrito, numeroAlbaran, tasaDeCambioDolar);
                PayPal.Api.APIContext apiContext = PasarelasPago.PayPalConfiguration.GetAPIContext();
                var createdPayment = PasarelasPago.PayPalConfiguration.CreatePayment(apiContext, string.Empty, ListadoCarrito, tasaDeCambioDolar, urlBase);
                RespuestaPreferencia = createdPayment.links[1].href;
            }

            if (formaDePago == EntidadesWeb.Enumeraciones.MedioPago.MercadoPago) 
            {
                Newtonsoft.Json.Linq.JObject datosPreferencia = null;
                datosPreferencia = this.ConstruirJsonMercadoPago(ListadoCarrito, numeroAlbaran, objCliente, objDireccion);
                RespuestaPreferencia = this.CrearPreferenciaMercadoPago(datosPreferencia);
                return RespuestaPreferencia;
            }

            return RespuestaPreferencia;
        }

        private int GuardarListadoCarrito(List<ItemCarrito> listadoCarrito, EntidadesWeb.Cliente objCliente, EntidadesWeb.Direccion objDireccion)
        {
            EntidadesWeb.ResultadoTransaccion resultado = new ResultadoTransaccion();
            int numeroAlbaran = this.InsertarAlbaran(listadoCarrito, objCliente, objDireccion);
            return numeroAlbaran;
        }

        private Newtonsoft.Json.Linq.JObject ConstruirJsonMercadoPago(List<EntidadesWeb.ItemCarrito> listaCarrito, int numeroAlbaran, EntidadesWeb.Cliente objCliente, EntidadesWeb.Direccion objDireccion)
        {
            // listaCarrito.Insert(0, )
            string JsonItems = "{ \n";
            JsonItems += "\"items\": [ \n";

            // ESTA ESTRUCTURA SE ESTABLECE POR DEFECTO PARA MOSTRAR EL ENCABEZADO DE MERCADOPAGO EL NRO. DE ALBARARAN QUE SERVIRA PARA IDENTIFICAR EL PEDIDO.
            JsonItems += "{ \n";
            JsonItems += "\"title\":" + "\"" + "Numero de remision:" + numeroAlbaran + " " +
                objCliente.Nombre + " " +
                objCliente.Apellido + ", " +
                objCliente.Telefono1 + ", " +
                objCliente.Telefono2 + ", " +
                objDireccion.NombreDestinatario + ", " +
                objDireccion.DireccionEnvio + ", " +
                objDireccion.Departamento.Nombre + ", " +
                objDireccion.Ciudad.Nombre + "\"" + 
                ",\n";
            JsonItems += "\"unit_price\":" + 0 + ".0,\n";
            JsonItems += "\"currency_id\":" + "\"COP\"" + ",\n";
            JsonItems += "\"quantity\":" + 1 + "\n";
            JsonItems += "}, \n";

            // Recorrer Carrito para enviar datos a MercadoPago.
            for (int i = 0; i < listaCarrito.Count; i++)
            {
                if (i != listaCarrito.Count - 1)
                {
                    JsonItems += "{ \n";
                    JsonItems += "\"title\":" + "\"" + listaCarrito[i].Nombre + "\"" + ",\n";
                    JsonItems += "\"unit_price\":" + listaCarrito[i].Precio + ".0,\n";
                    JsonItems += "\"currency_id\":" + "\"COP\"" + ",\n";
                    JsonItems += "\"quantity\":" + listaCarrito[i].Cantidad + "\n";
                    JsonItems += "}, \n";
                }
                else
                {
                    if (i == listaCarrito.Count - 1)
                    {
                        JsonItems += "{ \n";
                        JsonItems += "\"title\":" + "\"" + listaCarrito[i].Nombre + "\"" + ",\n";
                        JsonItems += "\"unit_price\":" + listaCarrito[i].Precio + ".0,\n";
                        JsonItems += "\"currency_id\":" + "\"COP\"" + ",\n";
                        JsonItems += "\"quantity\":" + listaCarrito[i].Cantidad + "\n";
                        JsonItems += "} \n";
                        JsonItems += "], \n";
                        string Aux = "https://www.*.com/PasarelasDePago/Notificaciones/NotificacionesMercadoPago.ashx";
                        JsonItems += "\"back_urls\": {\n";
                        JsonItems += "\"success\": \"" + Aux + "\",\n";
                        JsonItems += "\"failure\": \"" + Aux + "\",\n";
                        JsonItems += "\"pending\": \"" + Aux + "\"\n";
                        JsonItems += "},\n";

                        // DATOS DE COMPRADOR (PÉRDIDA DE TIEMPO SI SE QUIEREN VER EN EL MOVIMIENTO DE MERCADOPAGO, NO SE MUESTRAN ESTOS DATOS EN LA VENTA)
                        //string nombre = "";
                        //string telefono = "";
                        //string email = "X@X.XX";
                        //string direccion = "calle tal nro tal";
                        //JsonItems += "\"payer\": {\n";
                        //JsonItems += "\"Name\": \"" + nombre + "\",\n";
                        //JsonItems += "\"email\": \"" + email + "\",\n";
                        //JsonItems += "\"phone\": {\n";
                        //JsonItems += "\"number\": \"" + telefono + "\"\n";
                        //JsonItems += "},\n";
                        //JsonItems += "\"address\": {\n";
                        //JsonItems += "\"street_name\": \"" + direccion + "\"\n";
                        //JsonItems += "}\n"; 
                        //JsonItems += "},\n";

                        JsonItems += "\"AutoReturn\": \"approved\"\n";
                    }
                }
            }
            JsonItems += "}";

            Newtonsoft.Json.Linq.JObject preferenciaJason = Newtonsoft.Json.Linq.JObject.Parse(JsonItems);

            return preferenciaJason;
        }

        private string ConstruirJsonPayPal(List<ItemCarrito> listaReadOnlyCarrito, int numeroAlbaran, double tasaDeCambioDolar)
        {
            double total = 0;

            foreach (ItemCarrito item in listaReadOnlyCarrito)
            {
                total += item.SubTotal;
            }

            string JsonItems = "<script src ='https://www.paypalobjects.com/api/checkout.js'></script> \n";
            JsonItems += "<script> \n";
            // JsonItems += "function funcionJS() { \n";
            JsonItems += "paypal.Button.render({ \n";
            // JsonItems += "env: 'sandbox', // Or 'sandbox' \n";
            JsonItems += "env: 'production', // Or 'sandbox' \n";
            JsonItems += "client: \n";
            JsonItems += "{ \n";
            // JsonItems += "sandbox: '', \n";
            JsonItems += "production: '' \n";
            JsonItems += "}, \n";
            JsonItems += "commit: true, \n";
            JsonItems += "payment: function(data, actions) { \n";
            JsonItems += "return actions.payment.create({ \n";
            JsonItems += "payment: \n";
            JsonItems += "{ \n";
            JsonItems += "transactions: [ \n";
            JsonItems += "{ \n";
            JsonItems += "amount: \n";
            JsonItems += "{ \n";

            double TotalEnDolares = PasarelasPago.PayPalConfiguration.ConvertirPesosADolares(total, tasaDeCambioDolar);
            double ValorEnvio = 0;
            double TotalPagar = TotalEnDolares + ValorEnvio;
            string TotalPagarEnDolares = this.CambiarFormato(TotalPagar.ToString());
            string SubTotalEnDolares = this.CambiarFormato(TotalEnDolares.ToString());

            JsonItems += "total:'" + "1.00" + "',\n";
            JsonItems += "currency: 'USD',  \n";
            JsonItems += "details:   \n";
            JsonItems += "{   \n";
            JsonItems += "subtotal:'" + "1.00" + "'" + ", \n";
            JsonItems += "shipping:'0.00'" + " \n";
            JsonItems += "}" + "\n";
            JsonItems += "}," + "\n";
            JsonItems += "item_list: \n";
            JsonItems += "{ \n";
            JsonItems += "items: [ \n";


            // Recorrer Carrito para enviar datos a PayPal.
            for (int i = 0; i < listaReadOnlyCarrito.Count; i++)
            {
                double Co = listaReadOnlyCarrito[i].Precio;
                double PrecioEnDolares = PasarelasPago.PayPalConfiguration.ConvertirPesosADolares(Co, tasaDeCambioDolar);
                string precio = this.CambiarFormato(PrecioEnDolares.ToString());

                if (i != listaReadOnlyCarrito.Count)
                {
                    JsonItems += "{  \n";
                    JsonItems += "name:'" + listaReadOnlyCarrito[i].Nombre + "'" + ", \n";
                    JsonItems += "description:'" + listaReadOnlyCarrito[i].Nombre + "',\n";
                    JsonItems += "price:'" + "1.00" + "',\n";
                    JsonItems += "currency: 'USD',\n";
                    // JsonItems += "sku: '2',\n";
                    JsonItems += "quantity:'" + 1 + "'\n";
                    JsonItems += "},  \n";
                }
            }
            JsonItems += "]   \n";
            JsonItems += "},  \n";
            JsonItems += "}   \n";
            JsonItems += "]   \n";
            JsonItems += "}   \n";
            JsonItems += "});    \n";
            JsonItems += "},    \n";
            JsonItems += "onAuthorize: function(data, actions) { \n";
            JsonItems += "return actions.payment.execute().then(function() { \n";
            JsonItems += "window.alert('Payment Complete!');       \n";
            JsonItems += "});      \n";
            JsonItems += "}      \n";
            JsonItems += "}, '#paypal-button-container');     \n";
            // JsonItems += "}  \n";
            JsonItems += "</script>";

            return JsonItems;
        }

        private string CambiarFormato(string valor)
        {
            string resultado = valor.Replace(",", ".");
            return resultado.ToString();
        }

        private string CrearPreferenciaMercadoPago(Newtonsoft.Json.Linq.JObject datosPreferencia)
        {
            object strUrl = null;

            try
            {
                if (MercadoPago.SDK.ClientId == null)
                {
                    MercadoPago.SDK.ClientId = System.Configuration.ConfigurationManager.AppSettings["MercadopagoClientId"];
                    MercadoPago.SDK.ClientSecret = System.Configuration.ConfigurationManager.AppSettings["MercadopagoClientSecret"]; 
                }

                Newtonsoft.Json.Linq.JToken Token = MercadoPago.SDK.Post("/checkout/preferences", datosPreferencia);
                strUrl = Token["init_point"].ToString();
                // strUrl = Token["sandbox_init_point"].ToString(); // Init Point para pruebas
            }
            catch (Exception ex)
            {
                Logging.ErrorGeneral.Guardar(ex);
            }

            return strUrl.ToString();
        }

        private int InsertarAlbaran(List<ItemCarrito> listadoCarrito, EntidadesWeb.Cliente cliente, EntidadesWeb.Direccion objDireccion)
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();

            // Parametros Guardar Cabeza de Factura Procedimiento Almacenado [VentaWebInsert]
            System.Data.SqlClient.SqlParameter paramNroFactura = new System.Data.SqlClient.SqlParameter("@NroFactura", System.Data.SqlDbType.Int);
            System.Data.SqlClient.SqlParameter paramIdCliente = new System.Data.SqlClient.SqlParameter("@IdCliente", System.Data.SqlDbType.Int);
            System.Data.SqlClient.SqlParameter paramDocCliente = new System.Data.SqlClient.SqlParameter("@DocCliente", System.Data.SqlDbType.Int);
            System.Data.SqlClient.SqlParameter paramNombreCliente = new System.Data.SqlClient.SqlParameter("@NombreCliente", System.Data.SqlDbType.NVarChar, 30);
            System.Data.SqlClient.SqlParameter paramApellidoCliente = new System.Data.SqlClient.SqlParameter("@ApellidoCliente", System.Data.SqlDbType.NVarChar, 30);
            System.Data.SqlClient.SqlParameter paramTelefonoClienteUno = new System.Data.SqlClient.SqlParameter("@TelefonoClienteUno", System.Data.SqlDbType.NVarChar, 20);
            System.Data.SqlClient.SqlParameter paramTelefonoClienteDos = new System.Data.SqlClient.SqlParameter("@TelefonoClienteDos", System.Data.SqlDbType.NVarChar, 20);
            System.Data.SqlClient.SqlParameter paramEmailCliente = new System.Data.SqlClient.SqlParameter("@EmailCliente", System.Data.SqlDbType.NVarChar, 50);
            System.Data.SqlClient.SqlParameter paramNombreDestinatario = new System.Data.SqlClient.SqlParameter("@NombreDestinatario", System.Data.SqlDbType.NVarChar, 30);
            System.Data.SqlClient.SqlParameter paramDireccionEnvioDestinatario = new System.Data.SqlClient.SqlParameter("@DireccionEnvioDestinatario", System.Data.SqlDbType.NVarChar, 80);
            System.Data.SqlClient.SqlParameter paramTelefonoDestinatario = new System.Data.SqlClient.SqlParameter("@TelefonoDestinatario", System.Data.SqlDbType.NVarChar, 20);
            System.Data.SqlClient.SqlParameter paramNombrePaisDestinatario = new System.Data.SqlClient.SqlParameter("@NombrePaisDestinatario", System.Data.SqlDbType.NVarChar, 42);
            System.Data.SqlClient.SqlParameter paramNombreDepartamentoDestinatario = new System.Data.SqlClient.SqlParameter("@NombreDepartamentoDestinatario", System.Data.SqlDbType.NVarChar, 42);
            System.Data.SqlClient.SqlParameter paramNombreCiudadDestinatario = new System.Data.SqlClient.SqlParameter("@NombreCiudadDestinatario", System.Data.SqlDbType.NVarChar, 42);
            System.Data.SqlClient.SqlParameter paramFecha = new System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.Date);
            System.Data.SqlClient.SqlParameter paramCodigoReferenciaPayU = new System.Data.SqlClient.SqlParameter("@CodigoReferenciaPayU", System.Data.SqlDbType.Int);
            System.Data.SqlClient.SqlParameter paramMedioDePago = new System.Data.SqlClient.SqlParameter("@MedioDePago", System.Data.SqlDbType.NVarChar, 60);
            System.Data.SqlClient.SqlParameter paramTotalVenta = new System.Data.SqlClient.SqlParameter("@TotalVenta", System.Data.SqlDbType.Float);
            System.Data.SqlClient.SqlParameter paramTotalCosto = new System.Data.SqlClient.SqlParameter("@TotalCosto", System.Data.SqlDbType.Float);
            System.Data.SqlClient.SqlParameter paramNroGuia = new System.Data.SqlClient.SqlParameter("@NroGuia", System.Data.SqlDbType.NVarChar, 20);
            System.Data.SqlClient.SqlParameter paramCostoFlete = new System.Data.SqlClient.SqlParameter("@CostoFlete", System.Data.SqlDbType.Int);
            System.Data.SqlClient.SqlParameter paramAnulado = new System.Data.SqlClient.SqlParameter("@Anulado", System.Data.SqlDbType.Bit);
            System.Data.SqlClient.SqlParameter paramEstadoVenta = new System.Data.SqlClient.SqlParameter("@EstadoVenta", System.Data.SqlDbType.NVarChar, 50);
            System.Data.SqlClient.SqlParameter paramOutIdVentaWeb = new System.Data.SqlClient.SqlParameter("@OutIdVentaWeb", System.Data.SqlDbType.Int);
            paramOutIdVentaWeb.Direction = System.Data.ParameterDirection.Output;

            // Parametros guardar detalle de Factura, Procedimiento Almacenado [DetalleVentaWebInsert]
            System.Data.SqlClient.SqlParameter paramIdVentaWeb = new System.Data.SqlClient.SqlParameter("@IdVentaWeb", System.Data.SqlDbType.Int);
            paramIdCliente = new System.Data.SqlClient.SqlParameter("@IdCliente", System.Data.SqlDbType.Int);
            System.Data.SqlClient.SqlParameter paramNombreMarca = new System.Data.SqlClient.SqlParameter("@NombreMarca", System.Data.SqlDbType.NVarChar, 20);
            System.Data.SqlClient.SqlParameter paramTitulo = new System.Data.SqlClient.SqlParameter("@Titulo", System.Data.SqlDbType.NVarChar, 50);
            System.Data.SqlClient.SqlParameter paramNombreUnidadVolumen = new System.Data.SqlClient.SqlParameter("@NombreUnidadVolumen", System.Data.SqlDbType.NVarChar, 40);
            System.Data.SqlClient.SqlParameter paramVlrVolumenLargo = new System.Data.SqlClient.SqlParameter("@VlrVolumenLargo", System.Data.SqlDbType.Float);
            System.Data.SqlClient.SqlParameter paramVlrVolumenAncho = new System.Data.SqlClient.SqlParameter("@VlrVolumenAncho", System.Data.SqlDbType.Float);
            System.Data.SqlClient.SqlParameter paramVlrVolumenProfundidad = new System.Data.SqlClient.SqlParameter("@VlrVolumenProfundidad", System.Data.SqlDbType.Float);
            System.Data.SqlClient.SqlParameter paramVlrContenidoVolumetrico = new System.Data.SqlClient.SqlParameter("@VlrContenidoVolumetrico", System.Data.SqlDbType.Float);
            System.Data.SqlClient.SqlParameter paramNombreUnidadMasa = new System.Data.SqlClient.SqlParameter("@NombreUnidadMasa", System.Data.SqlDbType.NVarChar, 20);
            System.Data.SqlClient.SqlParameter paramVlrUnidadMasa = new System.Data.SqlClient.SqlParameter("@VlrUnidadMasa", System.Data.SqlDbType.Float);
            System.Data.SqlClient.SqlParameter paramNombreUnidadLongitud = new System.Data.SqlClient.SqlParameter("@NombreUnidadLongitud", System.Data.SqlDbType.NVarChar, 20);
            System.Data.SqlClient.SqlParameter paramVlrUnidadLongitud = new System.Data.SqlClient.SqlParameter("@VlrUnidadLongitud", System.Data.SqlDbType.Float);
            System.Data.SqlClient.SqlParameter paramNombreTalla = new System.Data.SqlClient.SqlParameter("@NombreTalla", System.Data.SqlDbType.NVarChar, 20);
            System.Data.SqlClient.SqlParameter paramNombreColor = new System.Data.SqlClient.SqlParameter("@NombreColor", System.Data.SqlDbType.NVarChar, 25);
            System.Data.SqlClient.SqlParameter paramNombreSabor = new System.Data.SqlClient.SqlParameter("@NombreSabor", System.Data.SqlDbType.NVarChar, 20);
            System.Data.SqlClient.SqlParameter paramPrecioVenta = new System.Data.SqlClient.SqlParameter("@PrecioVenta", System.Data.SqlDbType.Float);
            System.Data.SqlClient.SqlParameter paraCantidad = new System.Data.SqlClient.SqlParameter("@Cantidad", System.Data.SqlDbType.Int);
            System.Data.SqlClient.SqlParameter paramCostoDelProducto = new System.Data.SqlClient.SqlParameter("@CostoDelProducto", System.Data.SqlDbType.Float);
            System.Data.SqlClient.SqlParameter paramSubTotalVenta = new System.Data.SqlClient.SqlParameter("@SubTotalVenta", System.Data.SqlDbType.Float);
            System.Data.SqlClient.SqlParameter paramSubtotalCosto = new System.Data.SqlClient.SqlParameter("@SubtotalCosto", System.Data.SqlDbType.Float);
            System.Data.SqlClient.SqlParameter paramNombreCategoria = new System.Data.SqlClient.SqlParameter("@NombreCategoria", System.Data.SqlDbType.NVarChar, 60);
            System.Data.SqlClient.SqlParameter paramCaminoSubCategorias = new System.Data.SqlClient.SqlParameter("@CaminoSubCategorias", System.Data.SqlDbType.NVarChar, 250);
            System.Data.SqlClient.SqlParameter paramIdPresentacionArticulo = new System.Data.SqlClient.SqlParameter("@IdPresentacionArticulo", System.Data.SqlDbType.Int);
            System.Data.SqlClient.SqlParameter paramNombreUnidadPresentacion = new System.Data.SqlClient.SqlParameter("@NombreUnidadPresentacion", System.Data.SqlDbType.NVarChar, 40);
            System.Data.SqlClient.SqlParameter paramVlrUnidadPresentacion = new System.Data.SqlClient.SqlParameter("@VlrUnidadPresentacion", System.Data.SqlDbType.Float);

            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionTodoVentas"].ConnectionString);
                cmd.Connection.Open();

                // Iniciar transacción
                cmd.Transaction = cmd.Connection.BeginTransaction("TransaccionGenerarFactura");

                // Iniciar transacción
                // Guardar Cabeza de Alvaran (Remisión)
                paramNroFactura.Value = int.MinValue;
                int Cero = 0;
                if (cliente == null)
                {
                    // La venta se asocia al Cliente anónimo
                    paramIdCliente.Value = 1;
                    paramDocCliente.Value = Cero;
                    paramNombreCliente.Value = string.Empty;
                    paramApellidoCliente.Value = string.Empty;
                    paramTelefonoClienteUno.Value = string.Empty;
                    paramTelefonoClienteDos.Value = string.Empty;
                    paramEmailCliente.Value = string.Empty;
                    paramNombreDestinatario.Value = string.Empty;
                    paramDireccionEnvioDestinatario.Value = string.Empty;
                    paramTelefonoDestinatario.Value = string.Empty;
                    paramNombrePaisDestinatario.Value = string.Empty;
                    paramNombreDepartamentoDestinatario.Value = string.Empty;
                    paramNombreCiudadDestinatario.Value = string.Empty;
                }
                else
                {
                    paramIdCliente.Value = cliente.IdCliente;
                    paramDocCliente.Value = cliente.DocCliente;
                    paramNombreCliente.Value = cliente.Nombre;
                    paramApellidoCliente.Value = cliente.Apellido;
                    paramTelefonoClienteUno.Value = cliente.Telefono1;
                    paramTelefonoClienteDos.Value = cliente.Telefono2;
                    paramEmailCliente.Value = cliente.Email;
                    paramNombreDestinatario.Value = objDireccion.NombreDestinatario;
                    paramDireccionEnvioDestinatario.Value = objDireccion.DireccionEnvio;
                    paramTelefonoDestinatario.Value = objDireccion.Telefono;
                    paramNombrePaisDestinatario.Value = objDireccion.Pais.Nombre;
                    paramNombreDepartamentoDestinatario.Value = objDireccion.Departamento.Nombre;
                    paramNombreCiudadDestinatario.Value = objDireccion.Ciudad.Nombre;
                }

                paramFecha.Value = System.DateTime.Now;
                paramCodigoReferenciaPayU.Value = int.MinValue;
                paramMedioDePago.Value = string.Empty;
                paramTotalVenta.Value = Cero;
                paramTotalCosto.Value = Cero;
                paramNroGuia.Value = Cero;
                paramCostoFlete.Value = Cero;
                paramAnulado.Value = Cero;
                paramEstadoVenta.Value = string.Empty;

                cmd.Parameters.Clear();
                cmd.Parameters.Add(paramNroFactura);
                cmd.Parameters.Add(paramIdCliente);
                cmd.Parameters.Add(paramDocCliente);
                cmd.Parameters.Add(paramNombreCliente);
                cmd.Parameters.Add(paramApellidoCliente);
                cmd.Parameters.Add(paramTelefonoClienteUno);
                cmd.Parameters.Add(paramTelefonoClienteDos);
                cmd.Parameters.Add(paramEmailCliente);
                cmd.Parameters.Add(paramNombreDestinatario);
                cmd.Parameters.Add(paramDireccionEnvioDestinatario);
                cmd.Parameters.Add(paramTelefonoDestinatario);
                cmd.Parameters.Add(paramNombrePaisDestinatario);
                cmd.Parameters.Add(paramNombreDepartamentoDestinatario);
                cmd.Parameters.Add(paramNombreCiudadDestinatario);
                cmd.Parameters.Add(paramFecha);
                cmd.Parameters.Add(paramCodigoReferenciaPayU);
                cmd.Parameters.Add(paramMedioDePago);
                cmd.Parameters.Add(paramTotalVenta);
                cmd.Parameters.Add(paramTotalCosto);
                cmd.Parameters.Add(paramNroGuia);
                cmd.Parameters.Add(paramCostoFlete);
                cmd.Parameters.Add(paramAnulado);
                cmd.Parameters.Add(paramEstadoVenta);
                cmd.Parameters.Add(paramOutIdVentaWeb);

                cmd.CommandText = "VentaWebInsert";
                cmd.ExecuteNonQuery();

                for (int i = 0; i < listadoCarrito.Count; i++)
                {
                    // Guardar detalle
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(paramIdVentaWeb);
                    cmd.Parameters.Add(paramIdCliente);
                    cmd.Parameters.Add(paramNombreMarca);
                    cmd.Parameters.Add(paramTitulo);
                    cmd.Parameters.Add(paramNombreUnidadVolumen);
                    cmd.Parameters.Add(paramVlrVolumenLargo);
                    cmd.Parameters.Add(paramVlrVolumenAncho);
                    cmd.Parameters.Add(paramVlrVolumenProfundidad);
                    cmd.Parameters.Add(paramVlrContenidoVolumetrico);
                    cmd.Parameters.Add(paramNombreUnidadMasa);
                    cmd.Parameters.Add(paramVlrUnidadMasa);
                    cmd.Parameters.Add(paramNombreUnidadLongitud);
                    cmd.Parameters.Add(paramVlrUnidadLongitud);
                    cmd.Parameters.Add(paramNombreTalla);
                    cmd.Parameters.Add(paramNombreColor);
                    cmd.Parameters.Add(paramNombreSabor);
                    cmd.Parameters.Add(paramPrecioVenta);
                    cmd.Parameters.Add(paraCantidad);
                    cmd.Parameters.Add(paramCostoDelProducto);
                    cmd.Parameters.Add(paramSubTotalVenta);
                    cmd.Parameters.Add(paramSubtotalCosto);
                    cmd.Parameters.Add(paramNombreCategoria);
                    cmd.Parameters.Add(paramCaminoSubCategorias);
                    cmd.Parameters.Add(paramIdPresentacionArticulo);
                    cmd.Parameters.Add(paramNombreUnidadPresentacion);
                    cmd.Parameters.Add(paramVlrUnidadPresentacion);

                    cmd.CommandText = "DetalleVentaWebInsert";
                    paramIdVentaWeb.Value = paramOutIdVentaWeb.Value;

                    if (cliente == null)
                    {
                        paramIdCliente.Value = 1;
                    }
                    else
                    {
                        paramIdCliente.Value = cliente.IdCliente;
                    }

                    int IdPresentacionArticulo = listadoCarrito.ElementAt(i).IdPrestacionArticulo;
                    AccesoDatos.WebPublica.PresentacionArticulo ObjPresentacionArticulo = new AccesoDatos.WebPublica.PresentacionArticulo();
                    EntidadesWeb.PresentacionArticulo PresentacionArticulo = ObjPresentacionArticulo.ConsultarPorIdPresentacionArticulo(IdPresentacionArticulo);

                    paramNombreMarca.Value = PresentacionArticulo.Articulo.Marca.Nombre;
                    paramTitulo.Value = listadoCarrito[i].Nombre;
                    paramNombreUnidadVolumen.Value = PresentacionArticulo.UnidadVolumen.Nombre;
                    paramVlrVolumenLargo.Value = PresentacionArticulo.VlrUnidadVolumenLargo;
                    paramVlrVolumenAncho.Value = PresentacionArticulo.VlrUnidadVolumenAncho;
                    paramVlrVolumenProfundidad.Value = PresentacionArticulo.VlrUnidadVolumenProfundidad;
                    paramVlrContenidoVolumetrico.Value = PresentacionArticulo.VlrContenidoVolumetrico;
                    paramNombreUnidadMasa.Value = PresentacionArticulo.UnidadMasa.Nombre;
                    paramVlrUnidadMasa.Value = PresentacionArticulo.VlrUnidadMasa;
                    paramNombreUnidadLongitud.Value = PresentacionArticulo.UnidadLongitud.Nombre;
                    paramVlrUnidadLongitud.Value = PresentacionArticulo.VlrUnidadLongitud;
                    paramNombreTalla.Value = PresentacionArticulo.Talla.Nombre;
                    paramNombreColor.Value = PresentacionArticulo.Color.Nombre;
                    paramNombreSabor.Value = PresentacionArticulo.Sabor.Nombre;
                    paramPrecioVenta.Value = listadoCarrito[i].Precio;
                    paraCantidad.Value = listadoCarrito[i].Cantidad;
                    paramCostoDelProducto.Value = listadoCarrito[i].Precio;
                    paramSubTotalVenta.Value = listadoCarrito[i].Cantidad * listadoCarrito[i].Precio;
                    paramSubtotalCosto.Value = PresentacionArticulo.Existencias * PresentacionArticulo.Precio;
                    paramNombreCategoria.Value = PresentacionArticulo.Articulo.Categoria.Nombre;
                    paramCaminoSubCategorias.Value = string.Empty;
                    paramIdPresentacionArticulo.Value = listadoCarrito[i].IdPrestacionArticulo;
                    paramNombreUnidadPresentacion.Value = PresentacionArticulo.UnidadPresentacion.Nombre;
                    paramVlrUnidadPresentacion.Value = PresentacionArticulo.VlrUnidadPresentacion;
                    cmd.ExecuteNonQuery();
                }

                // Terminar transacción
                cmd.Transaction.Commit();
                cmd.Connection.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                cmd.Transaction.Rollback();
                Logging.ErrorGeneral.Guardar(ex);
            }
            catch (System.Exception ex)
            {
                cmd.Transaction.Rollback();
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

            return int.Parse(paramOutIdVentaWeb.Value.ToString());
        }
    }
}