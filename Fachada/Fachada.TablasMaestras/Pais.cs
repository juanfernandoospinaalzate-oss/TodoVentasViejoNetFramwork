

namespace Fachada.TablasMaestras
{
    using System;

    public class Pais : Contratos.IPais
    {
        public Entidades.ResultadoTransaccion Insertar(Entidades.Pais pais)
        {
            ServicioPais.PaisClient Pais = new ServicioPais.PaisClient();
            return Pais.Insertar(pais);
        }


        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Pais> Listar()
        {
            ServicioPais.PaisClient Pais = new ServicioPais.PaisClient();
            return Pais.Listar();
        }


        public Entidades.ResultadoTransaccion Eliminar(int idpais)
        {
            ServicioPais.PaisClient Pais = new ServicioPais.PaisClient();
            return Pais.Eliminar(idpais);
        }


        public bool PaisVerificarRelacionDpto(int idpais)
        {
            throw new NotImplementedException();
        }
    }
}
