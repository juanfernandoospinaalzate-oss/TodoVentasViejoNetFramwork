//-----------------------------------------------------------------------
// <copyright file="MedioDePago.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace ReglasDENegocio.TablasMaestras
{
    using System.Collections.ObjectModel;
    using Entidades;

    public class MedioDePago : Contratos.IMedioDePago
    {
        public ResultadoTransaccion Actualizar(MetodoDePago metodoDePago)
        {
            AccesoDatos.TablasMaestras.MedioDePago medioPago = new AccesoDatos.TablasMaestras.MedioDePago();
            return medioPago.Actualizar(metodoDePago);
        }

        public ResultadoTransaccion Eliminar(int IdMedioPago)
        {
            AccesoDatos.TablasMaestras.MedioDePago medioPago = new AccesoDatos.TablasMaestras.MedioDePago();
            return medioPago.Eliminar(IdMedioPago);
        }

        public ResultadoTransaccion Insertar(MetodoDePago metodoDePago)
        {
            AccesoDatos.TablasMaestras.MedioDePago medioPago = new AccesoDatos.TablasMaestras.MedioDePago();
            return medioPago.Insertar(metodoDePago);
        }

        public ReadOnlyCollection<MetodoDePago> Listar()
        {
            AccesoDatos.TablasMaestras.MedioDePago medioPago = new AccesoDatos.TablasMaestras.MedioDePago();
            return medioPago.Listar();
        }
    }
}
