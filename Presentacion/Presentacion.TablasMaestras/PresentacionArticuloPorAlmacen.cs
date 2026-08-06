

namespace Presentacion.TablasMaestras
{
    using System;
    using System.Windows.Forms;

    public partial class PresentacionArticuloPorAlmacen : Form
    {
        public PresentacionArticuloPorAlmacen()
        {
            this.InitializeComponent();
        }

        private void PresentacionArticuloPorAlmacen_Load(object sender, EventArgs e)
        {
            Fachada.TablasMaestras.PresentacionArticuloPorAlmacen PresentacionArticuloPorAlmacen = new Fachada.TablasMaestras.PresentacionArticuloPorAlmacen();
            this.CmbAlmacen.DataSource = PresentacionArticuloPorAlmacen.Listar();
            this.CmbAlmacen.DisplayMember = "NombreCompleto";
            this.CmbAlmacen.ValueMember = "IdPresentacionArticuloPorAlmacen";


            this.CmbAlmacenII.DataSource = PresentacionArticuloPorAlmacen.Listar();
            this.CmbAlmacenII.DisplayMember = "NombreCompleto";
            this.CmbAlmacenII.ValueMember = "IdPresentacionArticuloPorAlmacen";


            this.DgvListarPresentacionArticulo.DataSource = PresentacionArticuloPorAlmacen.ListarPresentacionArticulo();
            
            int IdAlmacen = (this.CmbAlmacen.SelectedItem as Entidades.PresentacionArticuloPorAlmacen).IdPresentacionArticuloPorAlmacen;
            if (IdAlmacen != 0)
            {
                this.DgvListarPresentacionArticuloPorAlmacen.DataSource = PresentacionArticuloPorAlmacen.ListarPresentacionArticuloPorAlmacen(IdAlmacen);
            }


            int IdAlmacenII = (this.CmbAlmacenII.SelectedItem as Entidades.PresentacionArticuloPorAlmacen).IdPresentacionArticuloPorAlmacen;
            if (IdAlmacenII != 0)
            {
                this.DgvListarPresentacionArticuloPorAlmacenII.DataSource = PresentacionArticuloPorAlmacen.ListarPresentacionArticuloPorAlmacen(IdAlmacen);
            }



            this.DgvListarPresentacionArticuloPorAlmacen.Columns[0].Visible = false;
            this.DgvListarPresentacionArticuloPorAlmacen.Columns[1].Visible = false;
            this.DgvListarPresentacionArticuloPorAlmacen.Columns[3].Visible = false;
            this.DgvListarPresentacionArticuloPorAlmacen.Columns[4].Visible = false;
            this.DgvListarPresentacionArticuloPorAlmacen.Columns[7].Visible = false;

            this.DgvListarPresentacionArticuloPorAlmacenII.Columns[0].Visible = false;
            this.DgvListarPresentacionArticuloPorAlmacenII.Columns[1].Visible = false;
            this.DgvListarPresentacionArticuloPorAlmacenII.Columns[3].Visible = false;
            this.DgvListarPresentacionArticuloPorAlmacenII.Columns[4].Visible = false;
            this.DgvListarPresentacionArticuloPorAlmacenII.Columns[7].Visible = false;


            this.DgvListarPresentacionArticulo.Columns[0].Visible = false;
            this.DgvListarPresentacionArticulo.Columns[1].Visible = false;
            this.DgvListarPresentacionArticulo.Columns[2].Visible = false;
            this.DgvListarPresentacionArticulo.Columns[3].Visible = false;
            this.DgvListarPresentacionArticulo.Columns[4].Visible = false;
            this.DgvListarPresentacionArticulo.Columns[5].Visible = false;
            this.DgvListarPresentacionArticulo.Columns[6].Visible = false;
            this.DgvListarPresentacionArticulo.Columns[7].Visible = false;
            this.DgvListarPresentacionArticulo.Columns[8].Visible = false;

            this.DgvListarPresentacionArticulo.Columns[9].Width = 370;
            this.DgvListarPresentacionArticulo.Columns[10].Width = 600;


            this.DgvListarPresentacionArticuloPorAlmacen.Columns[8].Visible = false;
            this.DgvListarPresentacionArticuloPorAlmacen.Columns[10].Visible = false;


            this.DgvListarPresentacionArticuloPorAlmacenII.Columns[8].Visible = false;
            this.DgvListarPresentacionArticuloPorAlmacenII.Columns[10].Visible = false;

        }

        private void CmbAlmacen_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fachada.TablasMaestras.PresentacionArticuloPorAlmacen PresentacionArticuloPorAlmacen = new Fachada.TablasMaestras.PresentacionArticuloPorAlmacen();
            // int IdAlmacen = (CmbAlmacen.SelectedItem as Entidades.PresentacionArticuloPorAlmacen).IdPresentacionArticuloPorAlmacen;
            // this.DgvListarPresentacionArticuloPorAlmacen.DataSource = PresentacionArticuloPorAlmacen.ListarPresentacionArticuloPorAlmacen(IdAlmacen);

            int IdAlmacen = (this.CmbAlmacen.SelectedItem as Entidades.PresentacionArticuloPorAlmacen).IdPresentacionArticuloPorAlmacen;
            if (IdAlmacen != 0)
            {
                this.DgvListarPresentacionArticuloPorAlmacen.DataSource = PresentacionArticuloPorAlmacen.ListarPresentacionArticuloPorAlmacen(IdAlmacen);
            }
        }

        private void DgvListarPresentacionArticuloPorAlmacen_SelectionChanged(object sender, EventArgs e)
        {
            if (this.DgvListarPresentacionArticuloPorAlmacen.SelectedRows.Count > 0)
            {
                TxtCantidad.Text = this.DgvListarPresentacionArticuloPorAlmacen.SelectedRows[0].Cells[2].Value.ToString();
                
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            Fachada.TablasMaestras.PresentacionArticuloPorAlmacen PresentacionArticuloPorAlmacen = new Fachada.TablasMaestras.PresentacionArticuloPorAlmacen();
            int IdPresentacionArticulo = int.Parse(this.DgvListarPresentacionArticuloPorAlmacen.SelectedRows[0].Cells[0].Value.ToString());

            Entidades.PresentacionArticuloPorAlmacen EntidadPresentacionArticuloPorAlmacen = new Entidades.PresentacionArticuloPorAlmacen();
            Entidades.PresentacionArticuloPorAlmacen EntidadPresentacionArticuloPorAlmacenDestino = new Entidades.PresentacionArticuloPorAlmacen();
                EntidadPresentacionArticuloPorAlmacen.IdPresentacionArticuloPorAlmacen = IdPresentacionArticulo;
                int unidadesTransferidas = int.Parse(this.TxtCantidad.Text);

                Entidades.ResultadoTransaccion resultadoTransaccion = PresentacionArticuloPorAlmacen.Actualizar(EntidadPresentacionArticuloPorAlmacen, EntidadPresentacionArticuloPorAlmacenDestino, unidadesTransferidas);
                MessageBox.Show(resultadoTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                int IdAlmacen = (this.CmbAlmacen.SelectedItem as Entidades.PresentacionArticuloPorAlmacen).IdPresentacionArticuloPorAlmacen;
                this.DgvListarPresentacionArticuloPorAlmacen.DataSource = PresentacionArticuloPorAlmacen.ListarPresentacionArticuloPorAlmacen(IdAlmacen);
        }

        private void BtnEliminarPresentacionArticuloPorAlmacen_Click(object sender, EventArgs e)
        {
            Fachada.TablasMaestras.PresentacionArticuloPorAlmacen PresentacionArticuloPorAlmacen = new Fachada.TablasMaestras.PresentacionArticuloPorAlmacen();
            int IdPresentacionArticulo = int.Parse(DgvListarPresentacionArticuloPorAlmacen.SelectedRows[0].Cells[0].Value.ToString());

            Entidades.ResultadoTransaccion resultadoTransaccion = PresentacionArticuloPorAlmacen.Eliminar(IdPresentacionArticulo);
            MessageBox.Show(resultadoTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
            
            int IdAlmacen = (this.CmbAlmacen.SelectedItem as Entidades.PresentacionArticuloPorAlmacen).IdPresentacionArticuloPorAlmacen;
            this.DgvListarPresentacionArticuloPorAlmacen.DataSource = PresentacionArticuloPorAlmacen.ListarPresentacionArticuloPorAlmacen(IdAlmacen);

        }

        private void CmbAlmacenII_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fachada.TablasMaestras.PresentacionArticuloPorAlmacen PresentacionArticuloPorAlmacen = new Fachada.TablasMaestras.PresentacionArticuloPorAlmacen();

            int IdAlmacenII = (this.CmbAlmacenII.SelectedItem as Entidades.PresentacionArticuloPorAlmacen).IdPresentacionArticuloPorAlmacen;
            if (IdAlmacenII != 0)
            {
                this.DgvListarPresentacionArticuloPorAlmacenII.DataSource = PresentacionArticuloPorAlmacen.ListarPresentacionArticuloPorAlmacen(IdAlmacenII);
            }
        }

        private void BtnEliminarPresentacionArticuloPorAlmacenII_Click(object sender, EventArgs e)
        {
            Fachada.TablasMaestras.PresentacionArticuloPorAlmacen PresentacionArticuloPorAlmacen = new Fachada.TablasMaestras.PresentacionArticuloPorAlmacen();
            int IdPresentacionArticuloII = int.Parse(this.DgvListarPresentacionArticuloPorAlmacenII.SelectedRows[0].Cells[0].Value.ToString());

            Entidades.ResultadoTransaccion resultadoTransaccion = PresentacionArticuloPorAlmacen.Eliminar(IdPresentacionArticuloII);
            MessageBox.Show(resultadoTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);

            int IdAlmacen = (CmbAlmacen.SelectedItem as Entidades.PresentacionArticuloPorAlmacen).IdPresentacionArticuloPorAlmacen;
            this.DgvListarPresentacionArticuloPorAlmacen.DataSource = PresentacionArticuloPorAlmacen.ListarPresentacionArticuloPorAlmacen(IdAlmacen);

        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            Fachada.TablasMaestras.PresentacionArticuloPorAlmacen PresentacionArticuloPorAlmacen = new Fachada.TablasMaestras.PresentacionArticuloPorAlmacen();
            int IdPresentacionArticulo = int.Parse(this.DgvListarPresentacionArticuloPorAlmacen.SelectedRows[0].Cells[0].Value.ToString());
            int IdAlmacen = int.Parse(this.DgvListarPresentacionArticuloPorAlmacen.SelectedRows[0].Cells[1].Value.ToString());

            bool resultadoBusqueda = false;
            foreach (DataGridViewRow fila in this.DgvListarPresentacionArticuloPorAlmacenII.Rows)
            {
                int IdPresentacionArticuloII = int.Parse(fila.Cells[0].Value.ToString());
                int IdAlmacenII = int.Parse(fila.Cells[1].Value.ToString());


                if (IdPresentacionArticuloII == IdPresentacionArticulo && IdAlmacenII != IdAlmacen)
                {
                    resultadoBusqueda = true;
                    break;
                }
            }

            if (resultadoBusqueda == true)
            {
                // ACTUALIZAR
                Entidades.PresentacionArticuloPorAlmacen EntidadActualizar = new Entidades.PresentacionArticuloPorAlmacen();
                EntidadActualizar.IdAlmacen = int.Parse((this.CmbAlmacen.SelectedItem as Entidades.PresentacionArticuloPorAlmacen).IdAlmacen.ToString());
                EntidadActualizar.IdPresentacionArticuloPorAlmacen = int.Parse(this.DgvListarPresentacionArticuloPorAlmacen.SelectedRows[0].Cells[0].Value.ToString());
                EntidadActualizar.Existencia = int.Parse(this.DgvListarPresentacionArticuloPorAlmacen.SelectedRows[0].Cells[2].Value.ToString());
                int unidadesTransferidas = int.Parse(this.TxtTranferirCantidad.Text);
                // EntidadActualizar.CantidadDescontada = int.Parse(DgvListarPresentacionArticuloPorAlmacen.SelectedRows[0].Cells[12].Value.ToString());
                
                Entidades.PresentacionArticuloPorAlmacen EntidadActualizarDestino = new Entidades.PresentacionArticuloPorAlmacen();
                EntidadActualizarDestino.IdPresentacionArticuloPorAlmacen = int.Parse(this.DgvListarPresentacionArticuloPorAlmacenII.SelectedRows[0].Cells[0].Value.ToString());
                EntidadActualizarDestino.IdAlmacen = int.Parse((this.CmbAlmacenII.SelectedItem as Entidades.PresentacionArticuloPorAlmacen).IdAlmacen.ToString());
                EntidadActualizarDestino.Existencia = int.Parse(this.DgvListarPresentacionArticuloPorAlmacenII.SelectedRows[0].Cells[2].Value.ToString());
                // EntidadActualizarDestino.CantidadDescontada = int.Parse(DgvListarPresentacionArticuloPorAlmacenII.SelectedRows[0].Cells[12].Value.ToString());


                Entidades.ResultadoTransaccion resultadoActualizar = PresentacionArticuloPorAlmacen.Actualizar(EntidadActualizar, EntidadActualizarDestino, unidadesTransferidas);

                // Llamar al actualizar
            }
            else
            {
                // INSERTAR
                Entidades.PresentacionArticuloPorAlmacen EntidadInsertar = new Entidades.PresentacionArticuloPorAlmacen();

                EntidadInsertar.IdPresentacionArticuloPorAlmacen = int.Parse(this.DgvListarPresentacionArticuloPorAlmacen.SelectedRows[0].Cells[0].Value.ToString());
                EntidadInsertar.IdAlmacen = int.Parse((this.CmbAlmacen.SelectedItem as Entidades.PresentacionArticuloPorAlmacen).IdAlmacen.ToString());
                EntidadInsertar.Existencia = int.Parse(this.DgvListarPresentacionArticuloPorAlmacen.SelectedRows[0].Cells[2].Value.ToString());
                EntidadInsertar.MaxExistencias = int.Parse(this.DgvListarPresentacionArticuloPorAlmacen.SelectedRows[0].Cells[3].Value.ToString());
                EntidadInsertar.MinExistencias = int.Parse(this.DgvListarPresentacionArticuloPorAlmacen.SelectedRows[0].Cells[4].Value.ToString());
                EntidadInsertar.CostoUnitario = decimal.Parse(this.DgvListarPresentacionArticuloPorAlmacen.SelectedRows[0].Cells[5].Value.ToString());
                EntidadInsertar.PrecioVenta = decimal.Parse(this.DgvListarPresentacionArticuloPorAlmacen.SelectedRows[0].Cells[6].Value.ToString());
                int unidadesTransferidas = int.Parse(this.TxtTranferirCantidad.Text);                

                Entidades.PresentacionArticuloPorAlmacen EntidadInsertarDestino = new Entidades.PresentacionArticuloPorAlmacen();
                EntidadInsertarDestino.IdPresentacionArticuloPorAlmacen = int.Parse(this.DgvListarPresentacionArticuloPorAlmacen.SelectedRows[0].Cells[0].Value.ToString());
                EntidadInsertarDestino.IdAlmacen = int.Parse((this.CmbAlmacenII.SelectedItem as Entidades.PresentacionArticuloPorAlmacen).IdAlmacen.ToString());
                EntidadInsertarDestino.Existencia = int.Parse(this.DgvListarPresentacionArticuloPorAlmacenII.SelectedRows[0].Cells[2].Value.ToString());


                Entidades.ResultadoTransaccion resultadoInsercion = PresentacionArticuloPorAlmacen.Insertar(EntidadInsertar, EntidadInsertarDestino, unidadesTransferidas);

                if (resultadoInsercion.RegistrosAfectados == 1)
                {
                    this.DgvListarPresentacionArticuloPorAlmacenII.DataSource = PresentacionArticuloPorAlmacen.ListarPresentacionArticuloPorAlmacen(EntidadInsertar.IdAlmacen);
                                       
                }
                else
                {
                    // Mostrar mensaje indicando que la inseción no fué exitosa
                }               
            }
        }

        private void BtnRemover_Click(object sender, EventArgs e)
        {
            Fachada.TablasMaestras.PresentacionArticuloPorAlmacen PresentacionArticuloPorAlmacen = new Fachada.TablasMaestras.PresentacionArticuloPorAlmacen();
            int IdPresentacionArticuloII = int.Parse(this.DgvListarPresentacionArticuloPorAlmacenII.SelectedRows[0].Cells[0].Value.ToString());
            int IdAlmacenII = int.Parse(this.DgvListarPresentacionArticuloPorAlmacenII.SelectedRows[0].Cells[1].Value.ToString());

            bool resultadoBusqueda = false;
            foreach (DataGridViewRow fila in this.DgvListarPresentacionArticuloPorAlmacen.Rows)
            {
                int IdPresentacionArticulo = int.Parse(fila.Cells[0].Value.ToString());
                int IdAlmacen = int.Parse(fila.Cells[1].Value.ToString());

                if (IdPresentacionArticulo == IdPresentacionArticuloII && IdAlmacen != IdAlmacenII)
                {
                    resultadoBusqueda = true;
                    break;
                }
            }

            if (resultadoBusqueda == true)
            {
                // ACTUALIZAR
                Entidades.PresentacionArticuloPorAlmacen EntidadActualizarII = new Entidades.PresentacionArticuloPorAlmacen();
                EntidadActualizarII.IdAlmacen = int.Parse((this.CmbAlmacenII.SelectedItem as Entidades.PresentacionArticuloPorAlmacen).IdAlmacen.ToString());
                EntidadActualizarII.IdPresentacionArticuloPorAlmacen = int.Parse(this.DgvListarPresentacionArticuloPorAlmacenII.SelectedRows[0].Cells[0].Value.ToString());
                EntidadActualizarII.Existencia = int.Parse(this.DgvListarPresentacionArticuloPorAlmacenII.SelectedRows[0].Cells[2].Value.ToString());
                int unidadesTransferidas = int.Parse(this.TxtTranferirCantidad.Text);
                // EntidadActualizarII.CantidadDescontada = int.Parse(DgvListarPresentacionArticuloPorAlmacenII.SelectedRows[0].Cells[12].Value.ToString());

                Entidades.PresentacionArticuloPorAlmacen EntidadActualizarDestinoII = new Entidades.PresentacionArticuloPorAlmacen();
                EntidadActualizarDestinoII.IdPresentacionArticuloPorAlmacen = int.Parse(this.DgvListarPresentacionArticuloPorAlmacen.SelectedRows[0].Cells[0].Value.ToString());
                EntidadActualizarDestinoII.IdAlmacen = int.Parse((this.CmbAlmacen.SelectedItem as Entidades.PresentacionArticuloPorAlmacen).IdAlmacen.ToString());
                EntidadActualizarDestinoII.Existencia = int.Parse(this.DgvListarPresentacionArticuloPorAlmacen.SelectedRows[0].Cells[2].Value.ToString());
                unidadesTransferidas = int.Parse(this.TxtTranferirCantidad.Text);
                // EntidadActualizarDestinoII.CantidadDescontada = int.Parse(DgvListarPresentacionArticuloPorAlmacen.SelectedRows[0].Cells[12].Value.ToString());

                Entidades.ResultadoTransaccion resultadoActualizar = PresentacionArticuloPorAlmacen.ActualizarII(EntidadActualizarII, EntidadActualizarDestinoII, unidadesTransferidas);   
            }
            else
            {
                // INSERTAR
                Entidades.PresentacionArticuloPorAlmacen EntidadInsertarII = new Entidades.PresentacionArticuloPorAlmacen();

                EntidadInsertarII.IdPresentacionArticuloPorAlmacen = int.Parse(this.DgvListarPresentacionArticuloPorAlmacenII.SelectedRows[0].Cells[0].Value.ToString());
                EntidadInsertarII.IdAlmacen = int.Parse((this.CmbAlmacenII.SelectedItem as Entidades.PresentacionArticuloPorAlmacen).IdAlmacen.ToString());
                EntidadInsertarII.Existencia = int.Parse(this.DgvListarPresentacionArticuloPorAlmacenII.SelectedRows[0].Cells[2].Value.ToString());
                EntidadInsertarII.MaxExistencias = int.Parse(this.DgvListarPresentacionArticuloPorAlmacenII.SelectedRows[0].Cells[3].Value.ToString());
                EntidadInsertarII.MinExistencias = int.Parse(this.DgvListarPresentacionArticuloPorAlmacenII.SelectedRows[0].Cells[4].Value.ToString());
                EntidadInsertarII.CostoUnitario = decimal.Parse(this.DgvListarPresentacionArticuloPorAlmacenII.SelectedRows[0].Cells[5].Value.ToString());
                EntidadInsertarII.PrecioVenta = decimal.Parse(this.DgvListarPresentacionArticuloPorAlmacenII.SelectedRows[0].Cells[6].Value.ToString());
                int unidadesTransferidas = int.Parse(this.TxtTranferirCantidad.Text);

                Entidades.PresentacionArticuloPorAlmacen EntidadInsertarDestinoII = new Entidades.PresentacionArticuloPorAlmacen();
                EntidadInsertarDestinoII.IdPresentacionArticuloPorAlmacen = int.Parse(this.DgvListarPresentacionArticuloPorAlmacen.SelectedRows[0].Cells[0].Value.ToString());
                EntidadInsertarDestinoII.IdAlmacen = int.Parse((this.CmbAlmacen.SelectedItem as Entidades.PresentacionArticuloPorAlmacen).IdAlmacen.ToString());
                EntidadInsertarDestinoII.Existencia = int.Parse(this.DgvListarPresentacionArticuloPorAlmacen.SelectedRows[0].Cells[2].Value.ToString());


                Entidades.ResultadoTransaccion resultadoInsercion = PresentacionArticuloPorAlmacen.InsertarII(EntidadInsertarII, EntidadInsertarDestinoII, unidadesTransferidas);

                if (resultadoInsercion.RegistrosAfectados == 1)
                {
                    this.DgvListarPresentacionArticuloPorAlmacenII.DataSource = PresentacionArticuloPorAlmacen.ListarPresentacionArticuloPorAlmacen(EntidadInsertarII.IdAlmacen);

                }
                else
                {
                    // Mostrar mensaje indicando que la inseción no fué exitosa
                }
            }

        }
    }
}
