namespace Validacion.TablasMaestras
{
    public class Ciudad : Contratos.ICiudad
    {
        public Entidades.ResultadoTransaccion Insertar(Entidades.Ciudad ciudad)
        {
            ReglasDENegocio.TablasMaestras.Ciudad Ciudad = new ReglasDENegocio.TablasMaestras.Ciudad();
            return Ciudad.Insertar(ciudad);
        }


        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Ciudad> Listar(int idDpto)
        {
            ReglasDENegocio.TablasMaestras.Ciudad Ciudad = new ReglasDENegocio.TablasMaestras.Ciudad();
            return Ciudad.Listar(idDpto);
        }


        public Entidades.ResultadoTransaccion Eliminar(int idCiudad)
        {
            ReglasDENegocio.TablasMaestras.Ciudad Ciudad = new ReglasDENegocio.TablasMaestras.Ciudad();
            return Ciudad.Eliminar(idCiudad);
        }


        public Entidades.ResultadoTransaccion Actualizar(Entidades.Ciudad ciudad)
        {
            ReglasDENegocio.TablasMaestras.Ciudad Ciudad = new ReglasDENegocio.TablasMaestras.Ciudad();
            return Ciudad.Actualizar(ciudad);
        }
    }
}
