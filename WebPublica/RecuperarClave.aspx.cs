// -----------------------------------------------------------------------
// <copyright file="RecuperarClave.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace WebPublica
{
    using Nexmo.Api;
    using System;
    using System.Web.UI;

    public partial class RecuperarClave : System.Web.UI.Page
    {
        const int CANTIDAD_DIGITOS_CELULAR = 10;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.SetCaptchaText();
            }

            this.TxtEmail.Focus();
            (this.Master.FindControl("ModalPopupExtender1") as AjaxControlToolkit.ModalPopupExtender).Enabled = false; // Deshabilitar popup mailchimp
        }

        protected void LkBtnEnviarSMS_Click(object sender, EventArgs e)
        {
            Fachada.WebPublica.Cliente objCliente = new Fachada.WebPublica.Cliente();
            EntidadesWeb.Cliente cliente = new EntidadesWeb.Cliente();

            cliente = objCliente.SeleccionarClientePorEmail(TxtEmail.Text);

            if (cliente.Email != null)
            {
                string numeroTelefonico = cliente.Telefono1.Replace(" ", string.Empty);

                try
                {

                    if (this.Session["Captcha"].ToString() != txtCaptcha.Text.Trim())
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "errorAlert();", true);
                    }
                    else
                    {
                        string codeVerify = string.Empty;
                        if (numeroTelefonico.Length == CANTIDAD_DIGITOS_CELULAR)
                        {
                            codeVerify = this.ObtenerCodigoVerificacion(numeroTelefonico);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "errorNroCelularAlert();", true);
                        }
                        if (!string.IsNullOrEmpty(codeVerify))
                        {
                            this.Session["CodeVerify"] = codeVerify;
                            this.Session["Email"] = TxtEmail.Text;
                            this.Response.Redirect(Session["UrlBase"].ToString() + "ConfimarCodigoVerificacion.aspx", false);
                        }
                    }
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion("Se ha producido un error al generar el código de verificación"));
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "errorEmailAlert();", true);
            }


        }

        private string ObtenerCodigoVerificacion(string numeroTelefonico)
        {
            string codigoVerificacionGenerado = GenerateRandom();
            var client = new Client(creds: new Nexmo.Api.Request.Credentials
            {
                // CREDENCIALES DE PRODUCCION
                ApiKey = "6796d888",
                ApiSecret = "LGc7j7nRq2D1iRFJ"

                // CREDENCIALES DE PRUEBAS
                // ApiKey = "ca12412d",
                // ApiSecret = "O2Krcyz4gsr7x5DY"
            });
            var results = client.SMS.Send(request: new SMS.SMSRequest
            {
                from = "Nexmo",
                to = "1" + numeroTelefonico,
                text = "Codigo de verificacion de TodoVentasColombia es: " + codigoVerificacionGenerado
            });
            return codigoVerificacionGenerado;
        }

        private static string GenerateRandom()
        {
            Random randomGenerate = new Random();
            long numberGenerate = randomGenerate.Next(000001, 999999);
            string sPassword = numberGenerate.ToString();
            return sPassword.Substring(sPassword.Length - 6, 6);
        }

        private void SetCaptchaText()
        {
            Random oRandom = new Random();
            int iNumber = oRandom.Next(100000, 999999);
            this.Session["Captcha"] = iNumber.ToString();
        }

        protected void LkbtnRefresh_Click(object sender, EventArgs e)
        {
            this.SetCaptchaText();
        }
    }
}