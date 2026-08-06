//-----------------------------------------------------------------------
// <copyright file="PaypalConfiguration.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace PasarelasPago
{
    using EntidadesWeb;
    // using PayPal.Api;
    using System;
    using System.Collections.Generic;

    public static class PayPalConfiguration
    {
        public readonly static string ClientId;
        public readonly static string ClientSecret;

        /// <summary>
        /// MÉTODOS PARA CONFIGURACIÓN PAGO
        /// </summary>
        static PayPalConfiguration()
        {
            var config = GetConfig();
            ClientId = config["clientId"];
            ClientSecret = config["clientSecret"];
        }

        public static Dictionary<string, string> GetConfig()
        {
            // ConfigManager.Instance.GetProperties(); // it doesn't work on ASPNET 5
            return new Dictionary<string, string>() {
                { "clientId", "" },
                { "clientSecret", "" },
                { "mode", "live" }
            };
        }

        private static string GetAccessToken()
        {
            // ###AccessToken
            // Retrieve the access token from OAuthTokenCredential by passing in
            // ClientID and ClientSecret
            // It is not mandatory to generate Access Token on a per call basis.
            // Typically the access token can be generated once and reused within the expiry window                 
            string accessToken = new PayPal.Api.OAuthTokenCredential(ClientId, ClientSecret, GetConfig()).GetAccessToken();
            return accessToken;
        }

        public static PayPal.Api.APIContext GetAPIContext(string accessToken = "")
        {
            // Pass in a `APIContext` object to authenticate 
            // the call and to send a unique request id 
            // (that ensures idempotency). The SDK generates
            // a request id if you do not pass one explicitly. 
            var apiContext = new PayPal.Api.APIContext(string.IsNullOrEmpty(accessToken) ?
                GetAccessToken() : accessToken);
            apiContext.Config = GetConfig();

            return apiContext;
        }


        /// <summary>
        /// MÉTODOS PARA CREACIÓN Y EJECUTAR PAGO
        /// </summary>
        public static PayPal.Api.Payment CreatePayment(PayPal.Api.APIContext apiContext, string intent, List<ItemCarrito> ListadoCarrito, double tasaDeCambioDolar, string urlBase)
        {
            string str_intent = "sale";
            // Payment Resource
            var payment = new PayPal.Api.Payment()
            {
                intent = str_intent,    // `sale` or `authorize`
                payer = new PayPal.Api.Payer() { payment_method = "paypal" },
                transactions = GetTransactionsList(ListadoCarrito, tasaDeCambioDolar),
                redirect_urls = GetReturnUrls(urlBase, str_intent)
            };

            // Create a payment using a valid APIContext
            var createdPayment = payment.Create(apiContext);

            return createdPayment;
        }

        private static List<PayPal.Api.Transaction> GetTransactionsList(List<ItemCarrito> ListadoCarrito, double tasaDeCambioDolar)
        {
            double dcmSubTotal = 0;

            // A transaction defines the contract of a payment
            // what is the payment for and who is fulfilling it. 
            var transactionList = new List<PayPal.Api.Transaction>();

            PayPal.Api.Transaction tx = new PayPal.Api.Transaction();
            

            tx.item_list = new PayPal.Api.ItemList();
            tx.item_list.items = new List<PayPal.Api.Item>();

            for (int i = 0; i < ListadoCarrito.Count; i++)
            {
                double Co = ListadoCarrito[i].Precio;
                double PrecioEnDolares = ConvertirPesosADolares(Co, tasaDeCambioDolar);
                string precio = CambiarFormato(PrecioEnDolares.ToString());

                int cantidadPorArticulo = ListadoCarrito[i].Cantidad;
                dcmSubTotal += PrecioEnDolares * cantidadPorArticulo;


                PayPal.Api.Item Elemento = new PayPal.Api.Item()
                {
                    name = ListadoCarrito[i].Nombre,
                    currency = "USD",
                    price = precio,
                    quantity = ListadoCarrito[i].Cantidad.ToString(),
                    sku = "sku"
                };

                tx.item_list.items.Add(Elemento);

            }
            transactionList.Add(tx);
            string Sub_Total = CambiarFormato(dcmSubTotal.ToString());
            tx.invoice_number = GetRandomInvoiceNumber();
            tx.amount = new PayPal.Api.Amount()
            {
                currency = "USD",
                total = Sub_Total,       // Total must be equal to sum of shipping, tax and subtotal.
                details = new PayPal.Api.Details() // Details: Let's you specify details of a payment amount.
                {
                    tax = "0.0",
                    shipping = "0.0",
                    subtotal = Sub_Total
                }
            };



            return transactionList;
        }

        private static PayPal.Api.RedirectUrls GetReturnUrls(string baseUrl, string intent)
        {
            // var returnUrl = intent == "sale" ? "/Home/PaymentSuccessful" : "/Home/AuthorizeSuccessful";
            var returnUrl = "/PasarelasDePago/RedirectUrlsPayPal/PaymentSuccessful.aspx";
            // Redirect URLS
            // These URLs will determine how the user is redirected from PayPal 
            // once they have either approved or canceled the payment.
            return new PayPal.Api.RedirectUrls()
            {
                cancel_url = baseUrl + "/PasarelasDePago/RedirectUrlsPayPal/PaymentCancelled.aspx",
                return_url = baseUrl + returnUrl
            };
        }

        public static PayPal.Api.Payment ExecutePayment(string paymentId, string payerId)
        {
            // ### Api Context
            // Pass in a `APIContext` object to authenticate 
            // the call and to send a unique request id 
            // (that ensures idempotency). The SDK generates
            // a request id if you do not pass one explicitly. 
            var apiContext = PayPalConfiguration.GetAPIContext();

            var paymentExecution = new PayPal.Api.PaymentExecution() { payer_id = payerId };
            var payment = new PayPal.Api.Payment() { id = paymentId };

            // Execute the payment.
            var executedPayment = payment.Execute(apiContext, paymentExecution);

            return executedPayment;
        }

        public static double ConvertirPesosADolares(double precio, double tasaDeCambioDolar)
        {
            double resultado = double.MinValue;
            resultado = precio / tasaDeCambioDolar;
            return Math.Round(resultado, 2);
        }

        private static string CambiarFormato(string valor)
        {
            string resultado = valor.Replace(",", ".");
            return resultado.ToString();
        }

        public static string GetRandomInvoiceNumber()
        {
            return new Random().Next(999999).ToString();
        }

    }
}
