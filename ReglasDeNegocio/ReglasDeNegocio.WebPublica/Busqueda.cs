// -----------------------------------------------------------------------
// <copyright file="Busqueda.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace ReglasDENegocio.WebPublica
{
    public class Busqueda : ContratosWeb.IBusqueda
    {
        public System.Collections.ObjectModel.ReadOnlyCollection<string> Listar(string texto)
        {
            AccesoDatos.WebPublica.Busqueda Busqueda = new AccesoDatos.WebPublica.Busqueda();
            return Busqueda.Listar(texto);
        }


        public void Insertar(string texto)
        {
            AccesoDatos.WebPublica.Busqueda Busqueda = new AccesoDatos.WebPublica.Busqueda();
            Busqueda.Insertar(texto);
        }


        public System.Collections.ObjectModel.ReadOnlyCollection<double> Buscar(string texto)
        {
            texto = this.GenerarConsultaSQL(texto);

            AccesoDatos.WebPublica.Busqueda Busqueda = new AccesoDatos.WebPublica.Busqueda();
            return Busqueda.Buscar(texto);
        }

        public string GenerarConsultaSQL(string textoBusqueda)
        {
            string[] PalabrasBusqueda = null;
            PalabrasBusqueda = textoBusqueda.Split(' ');
            string TextoBusquedaArticulo = string.Empty;

            // Búsqueda 1 (Tabla Artículo, búsqueda literal de la frase)
            // Traer como resultado todos los artículos que contangan toda la literalemnte, en el mismo campo
            // todas en Titulo o todas en Descripción o todas en PalabrasRelacionArticulo
            TextoBusquedaArticulo = "(SELECT IdArticulo FROM Articulo WHERE Titulo COLLATE Latin1_General_CI_AI LIKE '%" + textoBusqueda + "%')";
            TextoBusquedaArticulo = TextoBusquedaArticulo + "UNION ALL (SELECT IdArticulo FROM Articulo WHERE PalabrasRelacionArticulo COLLATE Latin1_General_CI_AI LIKE '%" + textoBusqueda + "%')";
            TextoBusquedaArticulo = TextoBusquedaArticulo + "UNION ALL (SELECT IdArticulo FROM Articulo WHERE Descripcion COLLATE Latin1_General_CI_AI LIKE '%" + textoBusqueda + "%')";

            // Búsqueda 2 (Tabla Artículo)
            // Traer como resultado todos los artículos que contengan todas las palabras buscadas en cualquiera los campos (Titulo, Descripcion y PalabrasRelacionArticulo) o repartidas entre dichoscampos
            TextoBusquedaArticulo = TextoBusquedaArticulo + " UNION ALL (SELECT IdArticulo FROM Articulo WHERE ";

            for (int i = 0; i < PalabrasBusqueda.Length; i++)
            {
                TextoBusquedaArticulo = TextoBusquedaArticulo + "(CONTAINS(Titulo,'" + PalabrasBusqueda[i] + "') OR CONTAINS(PalabrasRelacionArticulo,'" + PalabrasBusqueda[i] + "') OR CONTAINS(Descripcion,'" + PalabrasBusqueda[i] + "'))";

                if (i < PalabrasBusqueda.Length - 1)
                {
                    TextoBusquedaArticulo = TextoBusquedaArticulo + " AND ";
                }
            }

            // Búsqueda 3 (Tabla Artículo)
            // Traer como resultado todos los artículos que contenga cualquiera de las palabras buscadas, en cualquier combinación, sin importar si es la misma palabra en todos los campos
            TextoBusquedaArticulo = TextoBusquedaArticulo + ") UNION ALL (SELECT IdArticulo FROM Articulo WHERE ";

            for (int i = 0; i < 3; i++)
            {
                switch (i)
                {
                    case 0:
                        TextoBusquedaArticulo = TextoBusquedaArticulo + "CONTAINS(Titulo,'";
                        break;
                    case 1:
                        TextoBusquedaArticulo = TextoBusquedaArticulo + "CONTAINS(PalabrasRelacionArticulo,'";
                        break;
                    case 2:
                        TextoBusquedaArticulo = TextoBusquedaArticulo + "CONTAINS(Descripcion,'";
                        break;
                    default:
                        break;
                }

                for (int j = 0; j < PalabrasBusqueda.Length; j++)
                {
                    TextoBusquedaArticulo = TextoBusquedaArticulo + PalabrasBusqueda[j];

                    if (j < PalabrasBusqueda.Length - 1)
                    {
                        TextoBusquedaArticulo = TextoBusquedaArticulo + " OR ";
                    }
                }

                TextoBusquedaArticulo = TextoBusquedaArticulo + "')";

                if (i < 2)
                {
                    TextoBusquedaArticulo = TextoBusquedaArticulo + " AND ";
                }
            }

            // Búsqueda 4 (Tabla Artículo)
            // Traer como resultado todos los artículos que contenga cualquiera de las palabras buscadas, en cualquier combinación, sin importar si es una sola palabra en uno solo de los campos
            TextoBusquedaArticulo = TextoBusquedaArticulo + ") UNION ALL (SELECT IdArticulo FROM Articulo WHERE ";

            for (int i = 0; i < 3; i++)
            {
                switch (i)
                {
                    case 0:
                        TextoBusquedaArticulo = TextoBusquedaArticulo + "CONTAINS(Titulo,'";
                        break;
                    case 1:
                        TextoBusquedaArticulo = TextoBusquedaArticulo + "CONTAINS(PalabrasRelacionArticulo,'";
                        break;
                    case 2:
                        TextoBusquedaArticulo = TextoBusquedaArticulo + "CONTAINS(Descripcion,'";
                        break;
                    default:
                        break;
                }

                for (int j = 0; j < PalabrasBusqueda.Length; j++)
                {
                    TextoBusquedaArticulo = TextoBusquedaArticulo + PalabrasBusqueda[j];

                    if (j < PalabrasBusqueda.Length - 1)
                    {
                        TextoBusquedaArticulo = TextoBusquedaArticulo + " OR ";
                    }
                }

                TextoBusquedaArticulo = TextoBusquedaArticulo + "')";

                if (i < 2)
                {
                    TextoBusquedaArticulo = TextoBusquedaArticulo + " OR ";
                }
            }

            TextoBusquedaArticulo = TextoBusquedaArticulo + ")";

            // Busqueda 5 (Tabla Categoria)
            // Traer como resultado todos los artículos que contengan todas las palabras buscadas en cualquiera los campos (Categoria.Nombre, Categoria.Descripcion y Categoria.PalabrasClaves) o repartidas entre dichos campos
            TextoBusquedaArticulo = TextoBusquedaArticulo + " UNION ALL (SELECT Articulo.IdArticulo FROM Articulo INNER JOIN Categoria ON Categoria.IdCategoria = Articulo.IdCategoria WHERE ";

            for (int i = 0; i < PalabrasBusqueda.Length; i++)
            {
                TextoBusquedaArticulo = TextoBusquedaArticulo + "(CONTAINS(Categoria.Nombre,'" + PalabrasBusqueda[i] + "') OR CONTAINS(Categoria.PalabrasClaves,'" + PalabrasBusqueda[i] + "') OR CONTAINS(Categoria.Descripcion,'" + PalabrasBusqueda[i] + "'))";

                if (i < PalabrasBusqueda.Length - 1)
                {
                    TextoBusquedaArticulo = TextoBusquedaArticulo + " AND ";
                }
            }

            // Búsqueda 6 (Tabla Categoria)
            // Traer como resultado todos los artículos que contenga cualquiera de las palabras buscadas, en cualquier combinación, sin importar si es la misma palabra en todos los campos
            TextoBusquedaArticulo = TextoBusquedaArticulo + ") UNION ALL (SELECT Articulo.IdArticulo FROM Articulo INNER JOIN Categoria ON Categoria.IdCategoria = Articulo.IdCategoria WHERE ";

            for (int i = 0; i < 3; i++)
            {
                switch (i)
                {
                    case 0:
                        TextoBusquedaArticulo = TextoBusquedaArticulo + "CONTAINS(Categoria.Nombre,'";
                        break;
                    case 1:
                        TextoBusquedaArticulo = TextoBusquedaArticulo + "CONTAINS(Categoria.PalabrasClaves,'";
                        break;
                    case 2:
                        TextoBusquedaArticulo = TextoBusquedaArticulo + "CONTAINS(Categoria.Descripcion,'";
                        break;
                    default:
                        break;
                }

                for (int j = 0; j < PalabrasBusqueda.Length; j++)
                {
                    TextoBusquedaArticulo = TextoBusquedaArticulo + PalabrasBusqueda[j];

                    if (j < PalabrasBusqueda.Length - 1)
                    {
                        TextoBusquedaArticulo = TextoBusquedaArticulo + " OR ";
                    }
                }

                TextoBusquedaArticulo = TextoBusquedaArticulo + "')";

                if (i < 2)
                {
                    TextoBusquedaArticulo = TextoBusquedaArticulo + " AND ";
                }
            }

            TextoBusquedaArticulo = TextoBusquedaArticulo + ")";

            // Busqueda 7 
            // por código de barras
            // TextoBusquedaArticulo = TextoBusquedaArticulo + " UNION ALL (SELECT Articulo.IdArticulo FROM Articulo INNER JOIN PresentacionArticulo ON PresentacionArticulo.IdArticulo = Articulo.IdArticulo" +
            //    " WHERE CONTAINS(PresentacionArticulo.CodigoEAN,'" + textoBusqueda + "'))";

            // Busqueda 8
            // Traer como resultado todos los artículos que pertenezcan a las categorías asociadas a los resultados.

            return TextoBusquedaArticulo;
        }
    }
}
