// -----------------------------------------------------------------------
// <copyright file="PresentacionArticulo.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -------------------------------------------------------------------
namespace EntidadesWeb
{
    using System;

    /// <summary>
    /// Representa un Presentación Artículo de la base de datos
    /// </summary>
    public class PresentacionArticulo
    {
        private string nombre = string.Empty;
        private string nombreArticulo;
        private string nombreSinEspacios = string.Empty;
        private string nombreRecortado = string.Empty;
        private string descripcionBreve = string.Empty;
        private string descripcionBreveRecortada = string.Empty;

        public PresentacionArticulo()
        {
            this.Talla = new Talla();
            this.Color = new Color();
            this.Sabor = new Sabor();
            this.UnidadMasa = new UnidadMasa();
            this.UnidadVolumen = new UnidadVolumen();
            this.UnidadLongitud = new UnidadLongitud();
            this.Categoria = new Categoria();
            this.UnidadPresentacion = new UnidadPresentacion();
            this.Articulo = new EntidadesWeb.Articulo();
        }
        
        public int IdPresentacionArticulo { get; set; }
        
        public EntidadesWeb.Articulo Articulo { get; set; }

        public string CodigoEAN { get; set; }
        
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
                this.nombreSinEspacios = this.nombre.Replace(" ", "_").Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u").Replace("ñ", "n").Replace("'", string.Empty).Replace("&", "and").Replace("/", string.Empty).Replace("+", string.Empty).Replace("%", string.Empty);

                if (this.nombre.Length > 55)
                {
                    this.nombreRecortado = this.nombre.Substring(0, 55) + "...";
                }
                else
                {
                    this.nombreRecortado = this.nombre;
                }
            }
        }

        public string NombreSinEspacios 
        {
            get 
            {
                return this.nombreSinEspacios;
            }
        }
        
        public string NombreRecortado
        {
            get
            {
                return this.nombreRecortado;
            }
        }
        
        public string DescripcionBreve 
        {
            get
            {
                return this.descripcionBreve;
            }
            set
            {
                this.descripcionBreve = value;

                if (this.descripcionBreve.Length > 140)
                {
                    this.descripcionBreveRecortada = this.descripcionBreve.Substring(0, 140) + "...";
                }
                else
                {
                    this.descripcionBreveRecortada = this.descripcionBreve;
                }
            }
        }
        
        public string DescripcionBreveRecortada 
        {
            get 
            {
                return this.descripcionBreveRecortada;
            }
        }

        public EntidadesWeb.Color Color { get; set; }

        public EntidadesWeb.Talla Talla { get; set; }

        public bool Imagen1 { get; set; }

        public bool Imagen2 { get; set; }

        public bool Imagen3 { get; set; }

        public bool Imagen4 { get; set; }

        public bool Imagen5 { get; set; }

        public bool Imagen6 { get; set; }

        public DateTime Fecha { get; set; }

        public EntidadesWeb.UnidadMasa UnidadMasa { get; set; }

        public double VlrUnidadMasa { get; set; }

        public string ConcatenacionUnidadMasa
        {
            get
            {
                return this.VlrUnidadMasa.ToString() + " " + this.UnidadMasa.Nombre;
            }
        }

        public EntidadesWeb.UnidadVolumen UnidadVolumen { get; set; }

        public double VlrUnidadVolumenLargo { get; set; }

        public double VlrUnidadVolumenAncho { get; set; }

        public double VlrUnidadVolumenProfundidad { get; set; }

        public double VlrContenidoVolumetrico { get; set; }

        public string ConcatenacionContenidoVolumetrico
        {
            get 
            {
                return this.VlrContenidoVolumetrico.ToString() + " " + this.UnidadVolumen.Nombre;
            }
        }

        public EntidadesWeb.UnidadLongitud UnidadLongitud { get; set; }

        public double VlrUnidadLongitud { get; set; }

        public bool ENLinea { get; set; }

        public bool Activo { get; set; }

        public double Precio { get; set; }

        public EntidadesWeb.Sabor Sabor { get; set; }

        
        public string NombreArticulo
        {
            get
            {
                return this.nombreArticulo;
            }
            set
            {
                this.nombreArticulo = value;
                this.NombreArticuloSinEspacios = this.nombreArticulo.Replace(" ", "_").Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u").Replace("ñ", "n");
            }

        }

        public string NombreArticuloSinEspacios { get; set; }

        public EntidadesWeb.Categoria Categoria { get; set; }

        public int Existencias { get; set; }

        public EntidadesWeb.UnidadPresentacion UnidadPresentacion { get; set; }

        public double VlrUnidadPresentacion { get; set; }

        public bool PreOrden { get; set; }

        public DateTime FechaProximoVencimiento { get; set; }

        public bool UsarFechaProximoVencimiento { get; set; }

        public bool UsarDescuento { get; set; }

        public bool UsarPorcentajeDescuento { get; set; }

        public double ValorPorcentajeDescuento { get; set; }

        public bool UsarValorFijoDescuento { get; set; }

        public double ValorFijoDescuento { get; set; }

        public DateTime FechaInicioDescuento { get; set; }

        public DateTime FechaFinalDescuento { get; set; }
    }
}
