

namespace WebPublica.ControlesDeUsuario
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.UI.WebControls;

    public partial class WucBusqueda : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Request["CadenaBusqueda"] != null && this.TxtBuscador.Text == string.Empty)
            {
                this.TxtBuscador.Text = this.Request["CadenaBusqueda"];
            }
        }

        protected void LinkButtonBuscar_Click(object sender, EventArgs e)
        {
            string Page = string.Empty;
            string PageSize = string.Empty;

            this.TxtBuscador.Text = this.TxtBuscador.Text.Trim();

            if (this.Request["Page"] == null)
            {
                Page = "1";
            }
            else
            {
                Page = this.Request["Page"];
            }

            if (this.Request["PageSize"] == null)
            {
                PageSize = "10";
            }
            else
            {
                PageSize = this.Request["PageSize"];
            }

            // TextoBuscador = TxtBuscador.Text.Replace(" ", "+");

            // Reemplazar los caracteres reservados por un espacio en blanco
            List<char> caracteresReservados = "!*'();:@&=+$,/?%#[]{}\\<>".ToList();

            for (int i = 0; i < caracteresReservados.Count; i++)
            {
                this.TxtBuscador.Text = this.TxtBuscador.Text.Replace(caracteresReservados[i].ToString(), string.Empty);
            }

            // Remover los espacios en blanco al inicio y al final de la cadena
            this.TxtBuscador.Text = this.TxtBuscador.Text.Trim();

            // Remover los excesos de despacios en blanco
            this.TxtBuscador.Text = System.Text.RegularExpressions.Regex.Replace(this.TxtBuscador.Text, @"\s+", " ");

            this.Response.Redirect("/ResultadoCaja.aspx?Page=" + Page + "&PageSize=" + PageSize + "&CadenaBusqueda=" + this.TxtBuscador.Text, false);
        }

    }
}