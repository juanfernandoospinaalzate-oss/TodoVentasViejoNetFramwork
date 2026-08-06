namespace ReglasDENegocio.TablasMaestras
{
    public class MediosDePagoPayU : Contratos.IMediosDEPagoPayU
    {
        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Franquicia> ListarTodasLasFranquicias()
        {
            AccesoDatos.TablasMaestras.MediosDePagoPayU PayU = new AccesoDatos.TablasMaestras.MediosDePagoPayU();
            return PayU.ListarTodasLasFranquicias();
        }


        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Franquicia> ListarTarjetasDeCreditoConfiguradas()
        {
            AccesoDatos.TablasMaestras.MediosDePagoPayU PayU = new AccesoDatos.TablasMaestras.MediosDePagoPayU();
            return PayU.ListarTarjetasDeCreditoConfiguradas();
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Franquicia> ListarMediosEnEfectivoConfigurados()
        {
            AccesoDatos.TablasMaestras.MediosDePagoPayU PayU = new AccesoDatos.TablasMaestras.MediosDePagoPayU();
            return PayU.ListarMediosEnEfectivoConfigurados();
        }

        public Entidades.ResultadoTransaccion InsertarTarjetaDeCredito(Entidades.Franquicia franquicia)
        {
            AccesoDatos.TablasMaestras.MediosDePagoPayU PayU = new AccesoDatos.TablasMaestras.MediosDePagoPayU();
            System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Franquicia> ListaFranquicias = PayU.ListarTarjetasDeCreditoConfiguradas();

            // Verificar que no entre una tarjeta de credito ya registrada en el sistema
            foreach (Entidades.Franquicia FranquiciaActual in ListaFranquicias)
            {
                if (FranquiciaActual.IdPayU == franquicia.IdPayU)
                {
                    Entidades.ResultadoTransaccion ResultadoTransaccion = new Entidades.ResultadoTransaccion();
                    ResultadoTransaccion.RegistrosAfectados = 0;
                    ResultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0011");
                }
            }

            return PayU.InsertarTarjetaDeCredito(franquicia);
        }

        public Entidades.ResultadoTransaccion InsertarMedioEnEfectivo(Entidades.Franquicia franquicia)
        {
            AccesoDatos.TablasMaestras.MediosDePagoPayU PayU = new AccesoDatos.TablasMaestras.MediosDePagoPayU();
            System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Franquicia> ListaFranquicias = PayU.ListarMediosEnEfectivoConfigurados();

            // Verificar que no entre una tarjeta de credito ya registrada en el sistema
            foreach (Entidades.Franquicia FranquiciaActual in ListaFranquicias)
            {
                if (FranquiciaActual.IdPayU == franquicia.IdPayU)
                {
                    Entidades.ResultadoTransaccion ResultadoTransaccion = new Entidades.ResultadoTransaccion();
                    ResultadoTransaccion.RegistrosAfectados = 0;
                    ResultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0011");
                }
            }

            return PayU.InsertarMedioEnEfectivo(franquicia);
        }

        public Entidades.ResultadoTransaccion EliminarTarjetaDeCredito(Entidades.Franquicia franquicia)
        {
            AccesoDatos.TablasMaestras.MediosDePagoPayU PayU = new AccesoDatos.TablasMaestras.MediosDePagoPayU();
            return PayU.EliminarTarjetaDeCredito(franquicia);
        }

        public Entidades.ResultadoTransaccion EliminarMedioEnEfectivo(Entidades.Franquicia franquicia)
        {
            AccesoDatos.TablasMaestras.MediosDePagoPayU PayU = new AccesoDatos.TablasMaestras.MediosDePagoPayU();
            return PayU.EliminarMedioEnEfectivo(franquicia);
        }
    }
}
