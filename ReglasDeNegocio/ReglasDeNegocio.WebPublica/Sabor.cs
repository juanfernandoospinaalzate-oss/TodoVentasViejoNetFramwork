//-----------------------------------------------------------------------
// <copyright file="Sabor.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace ReglasDENegocio.WebPublica
{
    public class Sabor : ContratosWeb.ISabor
    {
        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Sabor> ListaSabores()
        {
            AccesoDatos.WebPublica.Sabor Sabor = new AccesoDatos.WebPublica.Sabor();
            return Sabor.ListaSabores();
        }
    }
}
