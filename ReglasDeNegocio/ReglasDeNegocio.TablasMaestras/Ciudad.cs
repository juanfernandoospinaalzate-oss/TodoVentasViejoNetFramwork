// -----------------------------------------------------------------------
// <copyright file="Ciudad.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace ReglasDENegocio.TablasMaestras
{
    public class Ciudad : Contratos.ICiudad
    {
        public Entidades.ResultadoTransaccion Insertar(Entidades.Ciudad ciudad)
        {
            AccesoDatos.TablasMaestras.Ciudad Ciudad = new AccesoDatos.TablasMaestras.Ciudad();
            return Ciudad.Insertar(ciudad);
        }


        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Ciudad> Listar(int idDpto)
        {
            AccesoDatos.TablasMaestras.Ciudad Ciudad = new AccesoDatos.TablasMaestras.Ciudad();
            return Ciudad.Listar(idDpto);
        }


        public Entidades.ResultadoTransaccion Eliminar(int idCiudad)
        {
            AccesoDatos.TablasMaestras.Ciudad Ciudad = new AccesoDatos.TablasMaestras.Ciudad();
            return Ciudad.Eliminar(idCiudad);
        }


        public Entidades.ResultadoTransaccion Actualizar(Entidades.Ciudad ciudad)
        {
            AccesoDatos.TablasMaestras.Ciudad Ciudad = new AccesoDatos.TablasMaestras.Ciudad();
            return Ciudad.Actualizar(ciudad);
        }
    }
}
