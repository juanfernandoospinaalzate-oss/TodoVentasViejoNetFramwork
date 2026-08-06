

namespace ServiciosWeb.TablasMaestras
{
    using System;

    public class Pais : Contratos.IPais
    {

        public Entidades.ResultadoTransaccion Insertar(Entidades.Pais pais)
        {
            Validacion.TablasMaestras.Pais Pais = new Validacion.TablasMaestras.Pais();
            return Pais.Insertar(pais);
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Pais> Listar()
        {
            Validacion.TablasMaestras.Pais Pais = new Validacion.TablasMaestras.Pais();
            return Pais.Listar();
        }


        public Entidades.ResultadoTransaccion Eliminar(int idpais)
        {
            Validacion.TablasMaestras.Pais Pais = new Validacion.TablasMaestras.Pais();
            return Pais.Eliminar(idpais);
        }


        public bool PaisVerificarRelacionDpto(int idpais)
        {
            throw new NotImplementedException();
        }
    }
}
