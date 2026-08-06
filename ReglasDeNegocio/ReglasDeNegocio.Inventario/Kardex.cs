// -----------------------------------------------------------------------
// <copyright file="KArdex.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace ReglasDENegocio.Inventario
{
    using System.Collections.ObjectModel;
    using Entidades;

    public class Kardex : Contratos.IKardex
    {
        public bool VerificarRelacionPresentacionArticulo(int idPresentacionArticulo)
        {
            AccesoDatos.Inventario.Kardex Kardex = new AccesoDatos.Inventario.Kardex();
            return Kardex.VerificarRelacionPresentacionArticulo(idPresentacionArticulo);
        }

        public ResultadoTransaccion Insertar(Entidades.Kardex registro)
        {
            AccesoDatos.Inventario.Kardex Kardex = new AccesoDatos.Inventario.Kardex();
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

            return Kardex.Insertar(registro);
        }

        public ReadOnlyCollection<Entidades.Kardex> ListarPorIdPresentacionArticulo(int idPresentacionArticulo)
        {
            AccesoDatos.Inventario.Kardex Kardex = new AccesoDatos.Inventario.Kardex();
            return Kardex.ListarPorIdPresentacionArticulo(idPresentacionArticulo);
        }
    }
}
