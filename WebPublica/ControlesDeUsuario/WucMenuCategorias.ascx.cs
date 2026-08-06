

namespace WebPublica.ControlesDeUsuario
{
    using System;
    using System.Collections.Generic;
    using System.Web.UI.WebControls;

    public partial class WucMenuCategorias : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.CrearMenu();
        }

        private void CrearMenu()
        {
            System.Web.UI.WebControls.MenuItem MenuItemRaiz = null;
            System.Web.UI.WebControls.MenuItem MenuItemNivel1 = null;
            System.Web.UI.WebControls.MenuItem MenuItemNivel2 = null;
            System.Web.UI.WebControls.MenuItem MenuItemNivel3 = null;
            System.Web.UI.WebControls.MenuItem MenuItemNivel4 = null;
            List<EntidadesWeb.Categoria> listaCategorias = null;
            System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Categoria> listaNivel2 = null;
            System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Categoria> listaNivel3 = null;
            System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Categoria> listaNivel4 = null;
            List<EntidadesWeb.Categoria> listaCategoriasUsadas = null;

            if (this.Application["MenuItemRaiz"] != null)
            {
                this.MenuCategorias.Items.Add(this.Application["MenuItemRaiz"] as System.Web.UI.WebControls.MenuItem);
                return;
            }

            listaCategorias = this.Application["ListaCategorias"] as List<EntidadesWeb.Categoria>;
            listaCategoriasUsadas = this.Application["ListaCategoriasUsadas"] as List<EntidadesWeb.Categoria>;
            MenuItemRaiz = new MenuItem("CATEGORÍAS", "/Sin_Categoria-1.aspx");
            foreach (EntidadesWeb.Categoria categoriaNivel1 in listaCategorias)
            {
                if (categoriaNivel1.IdCategoriaPadre == 0)
                {
                    MenuItemNivel1 = new MenuItem(categoriaNivel1.Nombre, "/" + categoriaNivel1.SegmentoAmigableUrlCategoria + "-" + categoriaNivel1.IdCategoria + ".aspx");

                    if (listaCategoriasUsadas.Exists(cat => cat.IdCategoria == categoriaNivel1.IdCategoria))
                    {
                        MenuItemNivel1.Selected = true;
                    }

                    listaNivel2 = this.ListarPorIdCategoria(categoriaNivel1.IdCategoria, listaCategorias);
                    foreach (EntidadesWeb.Categoria categoriaNivel2 in listaNivel2)
                    {
                        MenuItemNivel2 = new System.Web.UI.WebControls.MenuItem(categoriaNivel2.Nombre, "/" + categoriaNivel2.SegmentoAmigableUrlCategoria + "-" + categoriaNivel2.IdCategoria + ".aspx");
                        MenuItemNivel1.ChildItems.Add(MenuItemNivel2);

                        if (listaCategoriasUsadas.Exists(cat => cat.IdCategoria == categoriaNivel2.IdCategoria))
                        {
                            MenuItemNivel2.Selected = true;
                            MenuItemNivel1.Selected = true;
                        }

                        listaNivel3 = this.ListarPorIdCategoria(categoriaNivel2.IdCategoria, listaCategorias);
                        foreach (EntidadesWeb.Categoria categoriaNivel3 in listaNivel3)
                        {
                            MenuItemNivel3 = new System.Web.UI.WebControls.MenuItem(categoriaNivel3.Nombre, "/" + categoriaNivel3.SegmentoAmigableUrlCategoria + "-" + categoriaNivel3.IdCategoria + ".aspx");
                            MenuItemNivel2.ChildItems.Add(MenuItemNivel3);

                            if (listaCategoriasUsadas.Exists(cat => cat.IdCategoria == categoriaNivel3.IdCategoria))
                            {
                                MenuItemNivel3.Selected = true;
                                MenuItemNivel2.Selected = true;
                                MenuItemNivel1.Selected = true;
                            }

                            listaNivel4 = this.ListarPorIdCategoria(categoriaNivel3.IdCategoria, listaCategorias);
                            foreach (EntidadesWeb.Categoria categoriaNivel4 in listaNivel4)
                            {
                                MenuItemNivel4 = new System.Web.UI.WebControls.MenuItem(categoriaNivel4.Nombre, "/" + categoriaNivel4.SegmentoAmigableUrlCategoria + "-" + categoriaNivel4.IdCategoria + ".aspx");
                                MenuItemNivel3.ChildItems.Add(MenuItemNivel4);

                                if (listaCategoriasUsadas.Exists(cat => cat.IdCategoria == categoriaNivel4.IdCategoria))
                                {
                                    MenuItemNivel4.Selected = true;
                                    MenuItemNivel3.Selected = true;
                                    MenuItemNivel2.Selected = true;
                                    MenuItemNivel1.Selected = true;
                                }
                            }
                        }
                    }
                    MenuItemRaiz.ChildItems.Add(MenuItemNivel1);
                }
            }
            this.EliminarItemsMenuVacios(ref MenuItemRaiz);
            this.Application["MenuItemRaiz"] = MenuItemRaiz;
            this.MenuCategorias.Items.Add(MenuItemRaiz); 
        }

        private System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Categoria> ListarPorIdCategoria(int idCategoria, List<EntidadesWeb.Categoria> listaCategorias)
        {
            List<EntidadesWeb.Categoria> ListaCategorias = new List<EntidadesWeb.Categoria>();

            foreach (EntidadesWeb.Categoria categoria in listaCategorias)
            {
                if (categoria.IdCategoriaPadre == idCategoria)
                {
                    ListaCategorias.Add(categoria);
                }
            }

            return new System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.Categoria>(ListaCategorias);
        }

        protected void MenuCategorias_MenuItemClick(object sender, MenuEventArgs e)
        {
            Response.Redirect(e.Item.Value, false);
        }

        private void EliminarItemsMenuVacios(ref System.Web.UI.WebControls.MenuItem menuItem)
        {
            // Eliminar items de primer nivel
            for (int i = 0; i < menuItem.ChildItems.Count; i++) 
            {
                if (menuItem.ChildItems[i].Selected == false)
                {
                    menuItem.ChildItems.RemoveAt(i);
                    if (menuItem.ChildItems.Count != 0)
                    {
                        i--;
                    }
                }
                else
                {
                    // Eliminar items de segundo nivel
                    for (int j = 0; j < menuItem.ChildItems[i].ChildItems.Count; j++) 
                    {
                        if (menuItem.ChildItems[i].ChildItems[j].Selected == false)
                        {
                            menuItem.ChildItems[i].ChildItems.RemoveAt(j);
                            if (menuItem.ChildItems[i].ChildItems.Count != 0)
                            {
                                j--;
                            }
                        }
                        else
                        {
                            // Eliminar items de tercer nivel
                            for (int k = 0; k < menuItem.ChildItems[i].ChildItems[j].ChildItems.Count; k++)
                            {
                                if (menuItem.ChildItems[i].ChildItems[j].ChildItems[k].Selected == false)
                                {
                                    menuItem.ChildItems[i].ChildItems[j].ChildItems.RemoveAt(k);
                                    if (menuItem.ChildItems[i].ChildItems[j].ChildItems.Count != 0)
                                    {
                                        k--;
                                    }
                                }
                                else
                                {
                                    // Eliminar items de cuarto nivel
                                    for (int l = 0; l < menuItem.ChildItems[i].ChildItems[j].ChildItems[k].ChildItems.Count; l++)
                                    {
                                        if (menuItem.ChildItems[i].ChildItems[j].ChildItems[k].ChildItems[l].Selected == false)
                                        {
                                            menuItem.ChildItems[i].ChildItems[j].ChildItems[k].ChildItems.RemoveAt(l);
                                            if (menuItem.ChildItems[i].ChildItems[j].ChildItems[k].ChildItems.Count != 0)
                                            {
                                                l--;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}