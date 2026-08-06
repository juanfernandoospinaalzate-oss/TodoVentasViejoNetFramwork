//-----------------------------------------------------------------------
// <copyright file="Albaran.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace Validacion.WebPublica
{
    using EntidadesWeb;

    public class Albaran : ContratosWeb.IAlbaran
    {
        public ResultadoTransaccion Actualizar(EntidadesWeb.Albaran albaran)
        {
            ReglasDENegocio.WebPublica.Albaran Albaran = new ReglasDENegocio.WebPublica.Albaran();
            return Albaran.Actualizar(albaran);
        }
    }
}
