// -----------------------------------------------------------------------
// <copyright file="Departamento.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace ReglasDENegocio.TablasMaestras
{
    public class Departamento : Contratos.IDepartamento
    {
        public Entidades.ResultadoTransaccion Insertar(Entidades.Departamento departamento)
        {
            AccesoDatos.TablasMaestras.Departamento Departamento = new AccesoDatos.TablasMaestras.Departamento();
            return Departamento.Insertar(departamento);
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Departamento> Listar(int idPais)
        {
            AccesoDatos.TablasMaestras.Departamento Departamento = new AccesoDatos.TablasMaestras.Departamento();
            return Departamento.Listar(idPais);
        }

        public Entidades.ResultadoTransaccion Actualizar(Entidades.Departamento departamento)
        {
            AccesoDatos.TablasMaestras.Departamento Departamento = new AccesoDatos.TablasMaestras.Departamento();
            return Departamento.Actualizar(departamento);
        }

        public Entidades.ResultadoTransaccion Eliminar(int idDepartamento)
        {
            AccesoDatos.TablasMaestras.Departamento Departamento = new AccesoDatos.TablasMaestras.Departamento();
            return Departamento.Eliminar(idDepartamento);
        }
    }
}
