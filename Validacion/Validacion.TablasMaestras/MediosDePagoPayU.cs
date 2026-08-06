namespace Validacion.TablasMaestras
{
    public class MediosDePagoPayU : Contratos.IMediosDEPagoPayU
    {
        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Franquicia> ListarTodasLasFranquicias()
        {
            ReglasDENegocio.TablasMaestras.MediosDePagoPayU PayU = new ReglasDENegocio.TablasMaestras.MediosDePagoPayU();
            return PayU.ListarTodasLasFranquicias();
        }


        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Franquicia> ListarTarjetasDeCreditoConfiguradas()
        {
            ReglasDENegocio.TablasMaestras.MediosDePagoPayU PayU = new ReglasDENegocio.TablasMaestras.MediosDePagoPayU();
            return PayU.ListarTarjetasDeCreditoConfiguradas();
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Franquicia> ListarMediosEnEfectivoConfigurados()
        {
            ReglasDENegocio.TablasMaestras.MediosDePagoPayU PayU = new ReglasDENegocio.TablasMaestras.MediosDePagoPayU();
            return PayU.ListarMediosEnEfectivoConfigurados();
        }

        public Entidades.ResultadoTransaccion InsertarTarjetaDeCredito(Entidades.Franquicia franquicia)
        {
            ReglasDENegocio.TablasMaestras.MediosDePagoPayU PayU = new ReglasDENegocio.TablasMaestras.MediosDePagoPayU();
            return PayU.InsertarTarjetaDeCredito(franquicia);
        }

        public Entidades.ResultadoTransaccion InsertarMedioEnEfectivo(Entidades.Franquicia franquicia)
        {
            ReglasDENegocio.TablasMaestras.MediosDePagoPayU PayU = new ReglasDENegocio.TablasMaestras.MediosDePagoPayU();
            return PayU.InsertarMedioEnEfectivo(franquicia);
        }

        public Entidades.ResultadoTransaccion EliminarTarjetaDeCredito(Entidades.Franquicia franquicia)
        {
            ReglasDENegocio.TablasMaestras.MediosDePagoPayU PayU = new ReglasDENegocio.TablasMaestras.MediosDePagoPayU();
            return PayU.EliminarTarjetaDeCredito(franquicia);
        }

        public Entidades.ResultadoTransaccion EliminarMedioEnEfectivo(Entidades.Franquicia franquicia)
        {
            ReglasDENegocio.TablasMaestras.MediosDePagoPayU PayU = new ReglasDENegocio.TablasMaestras.MediosDePagoPayU();
            return PayU.EliminarMedioEnEfectivo(franquicia);
        }
    }
}
