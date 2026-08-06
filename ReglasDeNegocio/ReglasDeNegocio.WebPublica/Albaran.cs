//-----------------------------------------------------------------------
// <copyright file="Albaran.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace ReglasDENegocio.WebPublica
{
    using EntidadesWeb;

    public class Albaran : ContratosWeb.IAlbaran
    {
        public ResultadoTransaccion Actualizar(EntidadesWeb.Albaran albaran)
        {
            AccesoDatos.WebPublica.Albaran Albaran = new AccesoDatos.WebPublica.Albaran();
            return Albaran.Actualizar(albaran);
        }
    }
}
