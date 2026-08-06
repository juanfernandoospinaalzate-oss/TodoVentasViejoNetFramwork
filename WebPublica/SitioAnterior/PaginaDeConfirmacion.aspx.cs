//-----------------------------------------------------------------------
// <copyright file="PaginaDeConfirmacion.aspx.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace WebPublica
{
    using System;

    public partial class PaginaDeConfirmacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EntidadesWeb.EtiquetaControles etiqueta = null;
            etiqueta = new EntidadesWeb.EtiquetaControles();

            if (Request.Params[0].ToString() == "0")
            {
                etiqueta = MensajesWeb.LinqToXml.LeerEtiquetaControles("0203");
                this.LblMensajeDeConfirmacion.Text = etiqueta.Texto;
            }

            if (Request.Params[0].ToString() == "1")
            {
                etiqueta = MensajesWeb.LinqToXml.LeerEtiquetaControles("0202");
                this.LblMensajeDeConfirmacion.Text = etiqueta.Texto;
            }
        }
    }
}