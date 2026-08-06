//-----------------------------------------------------------------------
// <copyright file="ConfiguracionCatalogoPorCategorias.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace Entidades
{
    public class ConfiguracionCatalogoPorCategorias
    {
        private Entidades.Categoria categoria = new Entidades.Categoria();

        public Entidades.Categoria Categoria
        {
            get
            {
                return this.categoria;
            }

            set
            {
                this.categoria = value;
            }
        }

        public int NroColumnas { get; set; }

    }
}
