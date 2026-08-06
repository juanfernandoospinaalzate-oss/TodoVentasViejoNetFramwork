namespace Validacion.TablasMaestras
{
    public class Almacen : Contratos.IAlmacen
    {
        public Entidades.ResultadoTransaccion Insertar(Entidades.Almacen almacen)
        {
            ReglasDENegocio.TablasMaestras.Almacen Almacen = new ReglasDENegocio.TablasMaestras.Almacen();
            return Almacen.Insertar(almacen);
        }

        public Entidades.ResultadoTransaccion Actualizar(Entidades.Almacen almacen)
        {
            ReglasDENegocio.TablasMaestras.Almacen Almacen = new ReglasDENegocio.TablasMaestras.Almacen();
            return Almacen.Actualizar(almacen);
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Almacen> Listar()
        {
            ReglasDENegocio.TablasMaestras.Almacen Almacen = new ReglasDENegocio.TablasMaestras.Almacen();
            return Almacen.Listar();
        }

        public Entidades.ResultadoTransaccion Eliminar(int idAlmacen)
        {
            ReglasDENegocio.TablasMaestras.Almacen Almacen = new ReglasDENegocio.TablasMaestras.Almacen();
            return Almacen.Eliminar(idAlmacen);
        }
    }
}
