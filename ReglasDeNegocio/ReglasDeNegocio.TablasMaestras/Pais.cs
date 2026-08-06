//-----------------------------------------------------------------------
// <copyright file="Pais.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace ReglasDENegocio.TablasMaestras
{
    using System;

    public class Pais : Contratos.IPais
    {
        public Entidades.ResultadoTransaccion Insertar(Entidades.Pais pais)
        {
            AccesoDatos.TablasMaestras.Pais Pais = new AccesoDatos.TablasMaestras.Pais();
            return Pais.Insertar(pais);
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Pais> Listar()
        {
            AccesoDatos.TablasMaestras.Pais Pais = new AccesoDatos.TablasMaestras.Pais();
            return Pais.Listar();
        }


        public Entidades.ResultadoTransaccion Eliminar(int idpais)
        {
            AccesoDatos.TablasMaestras.Pais Pais = new AccesoDatos.TablasMaestras.Pais();

            if (Pais.PaisVerificarRelacionDpto(idpais))
            {
                Entidades.ResultadoTransaccion resultadoVerificarRelacion = new Entidades.ResultadoTransaccion();
                resultadoVerificarRelacion.RegistrosAfectados = 0;
                Entidades.Mensaje mensaje = Mensajes.LinqToXml.LeerMensaje("0002");
                resultadoVerificarRelacion.Mensaje = mensaje;
                return resultadoVerificarRelacion;
            }
            return Pais.Eliminar(idpais);
        }


        public bool PaisVerificarRelacionDpto(int idpais)
        {
            throw new NotImplementedException();
        }
    }
}
