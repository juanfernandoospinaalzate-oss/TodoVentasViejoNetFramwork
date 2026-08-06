// -----------------------------------------------------------------------
// <copyright file="Index.aspx.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace WebPublica
{
    using System;
    using System.Linq;

    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static string[] GetCompletionList(string prefixText, int count, string contextKey)
        {
            string[] result = new string[3];
            result[0] = prefixText + "a";
            result[1] = prefixText + "aa";
            result[2] = prefixText + "aaa";

            Fachada.WebPublica.Busqueda Busqueda = new Fachada.WebPublica.Busqueda();
            System.Collections.ObjectModel.ReadOnlyCollection<string> resultado = Busqueda.Listar(prefixText);

            return resultado.ToArray();
        }
    }
} 