

namespace WebPublica.ControlesDeUsuario
{
    using System;
    using System.Collections.Generic;

    public partial class WucBotonTotal : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("es-co");
            culture.NumberFormat.CurrencyDecimalDigits = 0; // para dar formato al precio
            double Total = 0.0;
            Fachada.WebPublica.Carrito ObjCarrito = new Fachada.WebPublica.Carrito();
            List<EntidadesWeb.ItemCarrito> ListaCarrito = null;

            int IdUsuario = 0;
            if (this.Session["TicketUsuario"] != null)
            {
                IdUsuario = int.Parse((this.Session["TicketUsuario"] as System.Web.Security.FormsAuthenticationTicket).UserData);
            }

            if (IdUsuario == 0)
            {
                ListaCarrito = this.Session["ListaCarritoModoInvitado"] as System.Collections.Generic.List<EntidadesWeb.ItemCarrito>;
            }
            else
            {
                ListaCarrito = new List<EntidadesWeb.ItemCarrito>(ObjCarrito.Listar(IdUsuario));
            }

            if (ListaCarrito != null)
            {
                foreach (EntidadesWeb.ItemCarrito item in ListaCarrito)
                {
                    Total += item.SubTotal;
                }
            }

            this.LinkButtonIrAlCarrito.Text = MensajesWeb.LinqToXml.LeerEtiquetaControles("0249").Texto + "<br/> " + Total.ToString("C", culture);
            this.LinkButtonIrAlCarrito.PostBackUrl = "/Carrito.aspx";
        }
    }
}