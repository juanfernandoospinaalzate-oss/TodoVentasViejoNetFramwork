
namespace WebPublica.PasarelasDePago.RedirectUrlsPayPal
{
    using PayPal.Api;
    using System;
    using PasarelasPago;


    public partial class PaymentSuccessful : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LoadComplete += this.PaymentSuccessful_LoadComplete;            
        }

        private void PaymentSuccessful_LoadComplete(object sender, EventArgs e)
        {
            string paymentId = Request.Params["paymentId"];
            string payerId = Request.Params["PayerID"];
            Payment objPayment = this.EjecutarPago(paymentId, payerId);
        }

        private Payment EjecutarPago(string paymentId, string payerId)
        {            
            var executePayment = PayPalConfiguration.ExecutePayment(paymentId, payerId);
            return executePayment;
        }

        protected void BtnRedirectCarrito_Click(object sender, EventArgs e)
        {
            Response.Redirect(this.Session["UrlBase"].ToString() + "Carrito.aspx", false);
        }
    }
}