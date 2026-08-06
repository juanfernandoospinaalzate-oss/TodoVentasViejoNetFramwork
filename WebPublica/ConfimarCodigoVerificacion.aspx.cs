

namespace WebPublica
{
    using System;
    using System.Web.UI;

    public partial class ConfimarCodigoVerificacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LoadComplete += this.ConfimarCodigoVerificacion_LoadComplete;
            this.TxtCodigoVerificacion.Focus();
        }

        private void ConfimarCodigoVerificacion_LoadComplete(object sender, EventArgs e)
        {            
            string codigoVerificacionInterno = this.Session["CodeVerify"].ToString();
            string email = this.Session["Email"].ToString();
        
            if (codigoVerificacionInterno == TxtCodigoVerificacion.Text)
            {
                Response.Redirect(this.Session["UrlBase"].ToString() + "SitioAnterior/AdminUsuario/AsignacionPassword.aspx", false);
            }
            else
            {
                if (TxtCodigoVerificacion.Text != string.Empty)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "errorAlert();", true);
                }               
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

            if (TxtCodigoVerificacion.Text == string.Empty)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "infoAlert();", true); 
            }
            
        }
    }
}