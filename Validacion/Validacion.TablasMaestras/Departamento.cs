namespace Validacion.TablasMaestras
{
    public class Departamento : Contratos.IDepartamento
    {
        public Entidades.ResultadoTransaccion Insertar(Entidades.Departamento departamento)
        {
            ReglasDENegocio.TablasMaestras.Departamento Departamento = new ReglasDENegocio.TablasMaestras.Departamento();
            return Departamento.Insertar(departamento);
        }


        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Departamento> Listar(int idPais)
        {
            ReglasDENegocio.TablasMaestras.Departamento Departamento = new ReglasDENegocio.TablasMaestras.Departamento();
            return Departamento.Listar(idPais);
        }


        public Entidades.ResultadoTransaccion Actualizar(Entidades.Departamento departamento)
        {
            ReglasDENegocio.TablasMaestras.Departamento Departamento = new ReglasDENegocio.TablasMaestras.Departamento();
            return Departamento.Actualizar(departamento);
        }


        public Entidades.ResultadoTransaccion Eliminar(int idDepartamento)
        {
            ReglasDENegocio.TablasMaestras.Departamento Departamento = new ReglasDENegocio.TablasMaestras.Departamento();
            return Departamento.Eliminar(idDepartamento);
        }
    }
}
