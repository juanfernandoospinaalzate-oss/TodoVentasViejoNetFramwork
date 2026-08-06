//-----------------------------------------------------------------------
// <copyright file="RequestPayU.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace EntidadesWeb
{
    public class RequestPayU
    {
        public string IsTest { get; set; }
        public string Language { get; set; }
        public string Command { get; set; }

        public EntidadesWeb.MerchantPayU Merchant { get; set; }

        public EntidadesWeb.DetailsPayU Details { get; set; }
    }
}
