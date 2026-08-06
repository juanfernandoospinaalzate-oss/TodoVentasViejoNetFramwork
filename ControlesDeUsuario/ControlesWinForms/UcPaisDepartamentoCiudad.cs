

namespace Controles.WinForms
{
    using System;
    using System.Windows.Forms;

    public partial class UcPaisDepartamentoCiudad : UserControl
    {
        public UcPaisDepartamentoCiudad()
        {
            this.InitializeComponent();
        }

        public ComboBox Cbpais
        {
            get
            {
                return this.CbPais;
            }

            set
            {
                this.CbPais = value;
            }
        }

        public ComboBox Cbdepartamento
        {
            get
            {
                return this.CbDepartamento;
            }

            set
            {
                this.CbDepartamento = value;
            }
        }

        public ComboBox Cbciudad
        {
            get
            {
                return this.CbCiudad;
            }

            set
            {
                this.CbCiudad = value;
            }
        }

        private void UcPaisDepartamentoCiudad_Load(object sender, EventArgs e)
        {
            Fachada.TablasMaestras.Pais Pais = new Fachada.TablasMaestras.Pais();
            Fachada.TablasMaestras.Departamento Departamento = new Fachada.TablasMaestras.Departamento();
            Fachada.TablasMaestras.Ciudad Ciudad = new Fachada.TablasMaestras.Ciudad();

            if (this.DesignMode == true)
            {
                return;
            }

            // si no hay paises cargados entonces se cargan
            if (CbPais.Items.Count == 0)
            {
                // Cargar la lista de paises
                this.CbPais.DataSource = Pais.Listar();
                this.CbPais.ValueMember = "IdPais";
                this.CbPais.DisplayMember = "Nombre";
                this.CbPais.SelectedValue = 52; // Sleccionar país predeterminado (Colombia)

                // Cargar lista de Departamentos del país seleccionado predeterminadamente
                this.CbDepartamento.ValueMember = "IdDepartamento";
                this.CbDepartamento.DisplayMember = "Nombre";
                int idPais = int.Parse(CbPais.SelectedValue.ToString());
                if (idPais != 0)
                {
                    this.CbDepartamento.DataSource = Departamento.Listar(idPais);
                }

                // Cargar la lista de ciudades del primer departamento de la lista de departamentos cargados
                this.CbCiudad.ValueMember = "IdCiudad";
                this.CbCiudad.DisplayMember = "Nombre";
                int IdDpto = int.Parse(CbDepartamento.SelectedValue.ToString());
                if (IdDpto != 0)
                {
                    this.CbCiudad.DataSource = Ciudad.Listar(IdDpto);
                }
            }
        }

        private void CbPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fachada.TablasMaestras.Departamento Departamento = new Fachada.TablasMaestras.Departamento();
            Fachada.TablasMaestras.Ciudad Ciudad = new Fachada.TablasMaestras.Ciudad();

            int idPais = int.Parse((this.Cbpais.SelectedItem as Entidades.Pais).IdPais.ToString());

            this.CbDepartamento.DataSource = null;
            this.Cbdepartamento.DataSource = Departamento.Listar(idPais);
            this.Cbdepartamento.DisplayMember = "Nombre";
            this.Cbdepartamento.ValueMember = "IdDepartamento";
        }

        private void CbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fachada.TablasMaestras.Ciudad Ciudad = new Fachada.TablasMaestras.Ciudad();

            int idDpto = int.Parse((this.CbDepartamento.SelectedItem as Entidades.Departamento).IdDepartamento.ToString());

            this.CbCiudad.DataSource = null;
            this.CbCiudad.DataSource = Ciudad.Listar(idDpto);
            this.CbCiudad.DisplayMember = "Nombre";
            this.CbCiudad.ValueMember = "IdCiudad";
        }
    }
}
