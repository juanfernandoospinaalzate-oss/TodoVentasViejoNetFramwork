// -----------------------------------------------------------------------
// <copyright file="Enumeracion.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace EntidadesWeb.Enumeraciones
{
    public enum FuncionPayU
    {
        Ping = 0,

        ListarBancosDisponibles = 1,

        ListarMediosDEPagosActivos = 2,

        SubmitTransactionEfecty = 3,

        SubmitTransactionBaloto = 4,

        ListarFranquiciasDisponibles = 5,

        ConsultarOrdenPorIdentificador = 6,

        ConsultarOrdenPorReferencia = 7,

        ConsultarOrdenPorTransaccion = 8,

        SubmitTarjetaCredito = 9,

        SubmitBancos = 10

    }

    public enum MedioPago
    { 
        Efecty = 0,
        Baloto = 1,
        TarjetaCredito = 2,
        Bancos = 3,
        PayPal = 4,
        MercadoPago = 5
    }

    public enum Filtro
    {
        Volumen = 0,
        Masa = 1,
        Longitud = 2,
        Talla = 3,
        Color = 4,
        Sabor = 5,
        UnidadPresentacion = 6
    } 

    public enum BannerPrincipalVideoDataSource
    {
        vimeo = 0,
        youtube = 1 
    }

    /// <summary>
    /// Dummy para cumplir con reglas stylecop
    /// </summary>
    public enum Enumeracion
    {
        /// <summary>
        /// Dummy para cumplir con reglas stylecop
        /// </summary>
        Dummy = 0,

        /// <summary>
        /// Dummy para cumplir con reglas stylecop
        /// </summary>
        Dummy2 = 1
    }
}
