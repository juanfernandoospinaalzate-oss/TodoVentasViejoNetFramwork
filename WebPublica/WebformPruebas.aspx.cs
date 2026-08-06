//-----------------------------------------------------------------------
// <copyright file="WebFormPruebas.aspx.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace WebPublica
{
    using System;
    using System.Web;

    public partial class WebformPruebas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ActualizarArticulosDesdeBaseDatos_a_SitioWeb_Click(object sender, EventArgs e)
        {
            Global claseGlobal = HttpContext.Current.ApplicationInstance as Global;
            claseGlobal.ActualizarArticulosDesdeBaseDatos_a_SitioWeb();
        }

        protected void ActualizarPresentacionesArticuloDesdeBaseDatos_a_SitioWeb_Click(object sender, EventArgs e)
        {
            Global claseGlobal = HttpContext.Current.ApplicationInstance as Global;
            claseGlobal.ActualizarPresentacionesArticuloDesdeBaseDatos_a_SitioWeb();
        }

        protected void RemoverPublicacionesSitioWeb_Click(object sender, EventArgs e)
        {
            Global claseGlobal = HttpContext.Current.ApplicationInstance as Global;
            claseGlobal.RemoverPublicacionesSitioWeb();
        }
    }
}