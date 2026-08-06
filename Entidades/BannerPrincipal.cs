//-----------------------------------------------------------------------
// <copyright file="BAnnerPrincipal.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace Entidades
{
    public class BannerPrincipal
    {
        public string BigBanner1 { get; set; }
        public byte[] BigBanner1Binario { get; set; }
        public string BigBanner2 { get; set; }
        public byte[] BigBanner2Binario { get; set; }
        public string BigBanner3 { get; set; }
        public byte[] BigBanner3Binario { get; set; }
        public string BigBanner4 { get; set; }
        public byte[] BigBanner4Binario { get; set; }
        public string BigBanner5 { get; set; }
        public byte[] BigBanner5Binario { get; set; }
        public string SmallBanner1 { get; set; }
        public byte[] SmallBanner1Binario { get; set; }
        public string SmallBanner2 { get; set; }
        public byte[] SmallBanner2Binario { get; set; }
        public string SmallBanner3 { get; set; }
        public byte[] SmallBanner3Binario { get; set; }
        public string SmallBanner4 { get; set; }
        public byte[] SmallBanner4Binario { get; set; }
        public string SmallBanner5 { get; set; }
        public byte[] SmallBanner5Binario { get; set; }
        public Enumeraciones.BannerPrincipalVideoDataSource VideoDataSource { get; set; }
        public string VideoDataId { get; set; }
        public string VideoImagenMiniatura { get; set; }
        public byte[] VideoImagenMiniaturaBinario { get; set; }
        public string UrlPresentacionArticulo1 { get; set; }
        public string UrlPresentacionArticulo2 { get; set; }
        public string UrlPresentacionArticulo3 { get; set; }
        public string UrlPresentacionArticulo4 { get; set; }
        public string UrlPresentacionArticulo5 { get; set; }
        public string UrlPresentacionArticulo6 { get; set; }
        public string UrlPresentacionArticulo7 { get; set; }
        public string UrlPresentacionArticulo8 { get; set; }
        public string UrlPresentacionArticulo9 { get; set; }
        public string UrlPresentacionArticulo10 { get; set; }

        private int segundoAutoplayFotorama = 5;
        public int SegundoAutoplayFotorama
        {
            get
            {
                return this.segundoAutoplayFotorama;
            }

            set
            {
                if (value < 1 || value > 10)
                {
                    throw new System.ArgumentOutOfRangeException(nameof(this.SegundoAutoplayFotorama));
                }

                this.segundoAutoplayFotorama = value;
            }
        }
    }
}