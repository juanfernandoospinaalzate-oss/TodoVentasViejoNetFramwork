//-----------------------------------------------------------------------
// <copyright file="PresentacionArticulo.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace ReglasDENegocio.WebPublica
{
    using System.Collections.ObjectModel;
    using EntidadesWeb;

    public class PresentacionArticulo : ContratosWeb.IPresentacionArticulo
    {
        public System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.PresentacionArticulo> Listar()
        {
            AccesoDatos.WebPublica.PresentacionArticulo Presentacion = new AccesoDatos.WebPublica.PresentacionArticulo();
            return Presentacion.Listar();
        }

        public ReadOnlyCollection<EntidadesWeb.PresentacionArticulo> ListarPendientesActualizacion()
        {
            AccesoDatos.WebPublica.PresentacionArticulo Presentacion = new AccesoDatos.WebPublica.PresentacionArticulo();
            return Presentacion.ListarPendientesActualizacion();
        }

        public ReadOnlyCollection<EntidadesWeb.PresentacionArticulo> ListarPorIdArticulo(int idArticulo)
        {
            AccesoDatos.WebPublica.PresentacionArticulo Presentacion = new AccesoDatos.WebPublica.PresentacionArticulo();
            return Presentacion.ListarPorIdArticulo(idArticulo);
        }

        public EntidadesWeb.PresentacionArticulo ConsultarPorIdPresentacionArticulo(int idPresentacionArticulo)
        {
            AccesoDatos.WebPublica.PresentacionArticulo Presentacion = new AccesoDatos.WebPublica.PresentacionArticulo();
            return Presentacion.ConsultarPorIdPresentacionArticulo(idPresentacionArticulo);
        }

        public ResultadoTransaccion QuitarMarcaActualizarPresentacionArticulo(int idPresentacionArticulo)
        {
            AccesoDatos.WebPublica.PresentacionArticulo Presentacion = new AccesoDatos.WebPublica.PresentacionArticulo();
            return Presentacion.QuitarMarcaActualizarPresentacionArticulo(idPresentacionArticulo);
        }
    }
}
