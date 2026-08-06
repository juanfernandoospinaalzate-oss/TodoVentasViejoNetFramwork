//-----------------------------------------------------------------------
// <copyright file="TarifasDomicilio.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace ReglasDENegocio.TablasMaestras
{
    using System.Collections.ObjectModel;
    using Entidades;

    public class TarifasDomicilio : Contratos.ITarifasDomicilio
    {
        public ResultadoTransaccion Actualizar(Entidades.TarifasDomicilio tarifasDomicilio)
        {
            AccesoDatos.TablasMaestras.TarifasDomicilio TarifasDomicilio = new AccesoDatos.TablasMaestras.TarifasDomicilio();
            return TarifasDomicilio.Actualizar(tarifasDomicilio);
        }

        public ResultadoTransaccion Eliminar(int idtarifasDomicilio)
        {
            AccesoDatos.TablasMaestras.TarifasDomicilio TarifasDomicilio = new AccesoDatos.TablasMaestras.TarifasDomicilio();
            return TarifasDomicilio.Eliminar(idtarifasDomicilio);
        }

        public ResultadoTransaccion Insertar(Entidades.TarifasDomicilio tarifasDomicilio)
        {
            AccesoDatos.TablasMaestras.TarifasDomicilio TarifasDomicilio = new AccesoDatos.TablasMaestras.TarifasDomicilio();
            return TarifasDomicilio.Insertar(tarifasDomicilio);
        }

        public ReadOnlyCollection<Entidades.TarifasDomicilio> Listar()
        {
            AccesoDatos.TablasMaestras.TarifasDomicilio TarifasDomicilio = new AccesoDatos.TablasMaestras.TarifasDomicilio();
            return TarifasDomicilio.Listar();
        }
    }
}
