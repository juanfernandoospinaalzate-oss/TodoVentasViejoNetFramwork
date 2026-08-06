// -----------------------------------------------------------------------
// <copyright file="UcTrCategorias.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// ----------------------------------------------------------------------

namespace Controles.WinForms
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// Administra la categoría
    /// </summary>
    public partial class UctrCategorias : UserControl
    {
        public string Nombre = string.Empty;
        public string Descripcion = string.Empty;
        public string PalabrasClave = string.Empty;

        /// <summary>
        /// Constructor del formulario.
        /// </summary>
        public UctrCategorias()
        {
            this.InitializeComponent();
            LblLoading.Visible = true;
        }

        public TreeView TreeViewCategorías
        {
            get
            {
                return this.treeView1;
            }
            set
            {
                this.treeView1 = value;
            }
        }

        /// <summary>
        /// llamado al método AgregaNodo
        /// </summary>
        private delegate void AgregarNodo();

        /// <summary>
        /// Constructor del formulario.
        /// </summary>
        public TreeView TreeViewCategorias
        {
            get
            {
                return this.treeView1;
            }

            set
            {
                if (value != null)
                {
                    this.treeView1 = value;
                }
            }
        }

        /// <summary>
        /// inicia el treeview categoría
        /// </summary>
        /// <param name="sender">Objeto que provocó el llamado</param>
        /// <param name="e">Argumentos del evento</param>
        public void TRCategoriasLoad(object sender, EventArgs e)
        {
            (this.Parent as Form).Activated += this.TRCategoriasActivated;
            treeView1.DrawMode = TreeViewDrawMode.Normal;
            treeView1.HideSelection = false;
            treeView1.DrawNode += new DrawTreeNodeEventHandler(this.TreeViewCategoriasseleccionarNodo);
        }

        /// <summary>
        /// activa el treeview categorías
        /// </summary>
        /// <param name="sender">Objeto que provocó el llamado</param>
        /// <param name="e">Argumentos del evento</param>
        public void TRCategoriasActivated(object sender, EventArgs e)
        {
            (this.Parent as Form).Enabled = false;
            System.Threading.Thread hilo = new System.Threading.Thread(this.CargarCategorias);
            hilo.Start();

            Entidades.EtiquetaControles etiqueta = null;
            etiqueta = new Entidades.EtiquetaControles();

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0006");
            this.LblLoading.Text = etiqueta.Texto;
        }

        /// <summary>
        /// carga los nodos correspondientes a categorías
        /// </summary>
        public void CargarCategorias()
        {
            System.Threading.Thread.Sleep(500);
            this.Invoke(new AgregarNodo(this.AgregarNodos));
        }

        /// <summary>
        /// Agrega nodos del módulo categorías
        /// </summary>
        public void AgregarNodos()
        {
            // Cargar la lista de categorias
            Fachada.TablasMaestras.Categoria categoria = null;
            categoria = new Fachada.TablasMaestras.Categoria();
            treeView1.Nodes.Clear();
            TreeNode nivel1 = null;
            TreeNode nivel2 = null;
            TreeNode nivel3 = null;
            TreeNode nivel4 = null;

            System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Categoria> listaCategorias = null;
            listaCategorias = categoria.Listar();
            foreach (Entidades.Categoria categoriaNivel1 in listaCategorias)
            {
                if (categoriaNivel1.IdCategoriaPadre == 0)
                {
                    nivel1 = new TreeNode(categoriaNivel1.Nombre);
                    nivel1.Tag = categoriaNivel1;

                    System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Categoria> listaNivel2 = this.ListarPorIdCategoria(categoriaNivel1.IdCategoria, listaCategorias);
                    foreach (Entidades.Categoria categoriaNivel2 in listaNivel2)
                    {
                        nivel2 = new TreeNode(categoriaNivel2.Nombre);
                        nivel2.Tag = categoriaNivel2;
                        nivel1.Nodes.Add(nivel2);

                        System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Categoria> listaNivel3 = this.ListarPorIdCategoria(categoriaNivel2.IdCategoria, listaCategorias);
                        foreach (Entidades.Categoria categoriaNivel3 in listaNivel3)
                        {
                            nivel3 = new TreeNode(categoriaNivel3.Nombre);
                            nivel3.Tag = categoriaNivel3;
                            nivel2.Nodes.Add(nivel3);

                            System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Categoria> listaNivel4 = this.ListarPorIdCategoria(categoriaNivel3.IdCategoria, listaCategorias);
                            foreach (Entidades.Categoria categoriaNivel4 in listaNivel4)
                            {
                                nivel4 = new TreeNode(categoriaNivel4.Nombre);
                                nivel4.Tag = categoriaNivel4;
                                nivel3.Nodes.Add(nivel4);
                            }
                        }
                    }

                treeView1.Nodes.Add(nivel1);
                }
            }

            (this.Parent as Form).Enabled = true;
            LblLoading.Visible = false;
        }

        /// <summary>
        /// permite mostrar el nodo seleccionado en el treeview
        /// </summary>
        /// <param name="texto">parámetro de entrada para realizar la búsqueda</param>
        public void BuscarNodo(int idCategoria)
        {
            foreach (TreeNode nodoNivel1 in treeView1.Nodes)
            {
                Entidades.Categoria CategoriaNivel1 = nodoNivel1.Tag as Entidades.Categoria;
                if (CategoriaNivel1.IdCategoria == idCategoria)
                {
                    treeView1.SelectedNode = nodoNivel1;
                    treeView1.Select();
                    break;
                }

                foreach (TreeNode nodoNivel2 in nodoNivel1.Nodes)
                {
                    Entidades.Categoria CategoriaNivel2 = nodoNivel2.Tag as Entidades.Categoria;
                    if (CategoriaNivel2.IdCategoria == idCategoria)
                    {
                        treeView1.SelectedNode = nodoNivel2;
                        treeView1.Select();
                        break;
                    }

                    foreach (TreeNode nodoNivel3 in nodoNivel2.Nodes)
                    {
                        Entidades.Categoria CategogiaNivel3 = nodoNivel3.Tag as Entidades.Categoria;
                        if (CategogiaNivel3.IdCategoria == idCategoria)
                        {
                            treeView1.SelectedNode = nodoNivel3;
                            treeView1.Select();
                            break;
                        }

                        foreach (TreeNode nodoNivel4 in nodoNivel3.Nodes)
                        {
                            Entidades.Categoria CategoriaNivel4 = nodoNivel4.Tag as Entidades.Categoria;
                            if (CategoriaNivel4.IdCategoria == idCategoria)
                            {
                                treeView1.SelectedNode = nodoNivel4;
                                treeView1.Select();
                                break;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// resalta el nodo seleccionado en el treeview
        /// </summary>
        /// <param name="sender">Objeto que provocó el llamado</param>
        /// <param name="seleccionar">marca o resalta la categoría seleccionada</param>
        public void TreeViewCategoriasseleccionarNodo(object sender, DrawTreeNodeEventArgs seleccionar)
        {
            if (seleccionar == null)
            {
                Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();
                resultadoTransaccion.RegistrosAfectados = 0;
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0010");
            }
            else
            {
                if (seleccionar.State == (TreeNodeStates.Selected | TreeNodeStates.Focused))
                {
                    seleccionar.Graphics.FillRectangle(Brushes.Blue, seleccionar.Bounds);
                }
            }
        }

        /// <summary>
        /// Busca en memoria ya disponible las subcategorias de una categoría pasadas por argumento
        /// </summary>
        /// <param name="idCategoria">Identificación de la categoría</param>
        /// <param name="listaCategorias">Lista de todas las categorías disponibles a la base de datos.</param>
        /// <returns>Retorna la lista de subcategorías de la categoría correspondiente a idCategoria</returns>
        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Categoria> ListarPorIdCategoria(int idCategoria, System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Categoria> listaCategorias)
        {
            List<Entidades.Categoria> listaCategoriasAuxiliar = new List<Entidades.Categoria>();

            foreach (Entidades.Categoria categoria in listaCategorias)
            {
                if (categoria.IdCategoriaPadre == idCategoria)
                {
                    listaCategoriasAuxiliar.Add(categoria);
                }
            }

            return new System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Categoria>(listaCategoriasAuxiliar);
        }

        public void HabilitarInhabilitar(Entidades.Enumeraciones.Estado EstadoControlTransparente)
        {

            if (EstadoControlTransparente == Entidades.Enumeraciones.Estado.Inhabilitado)
            {
                this.controlTransparente1.Size = new Size(393, 162);
            }
            else
            {
                this.controlTransparente1.Size = new Size(-393, 0);
            }
        }

    }
}
