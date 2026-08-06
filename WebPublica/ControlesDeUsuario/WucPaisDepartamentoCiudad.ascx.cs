

namespace WebPublica.ControlesDeUsuario
{
    using System;
    using System.Web.UI.WebControls;

    public partial class WucPaisDepartamentoCiudad : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {                 
            Fachada.WebPublica.PaisDepartamentoCiudad PaisDepartamentoCiudad = new Fachada.WebPublica.PaisDepartamentoCiudad();

            if (DdlPais.Items.Count == 0)
            {
                this.DdlPais.DataValueField = "IdPais";
                this.DdlPais.DataTextField = "Nombre";
                this.DdlPais.DataSource = PaisDepartamentoCiudad.ListarPais();
                this.DdlPais.DataBind();
                this.DdlPais.Items.FindByValue("52").Selected = true;

                this.DdlDepartamento.DataValueField = "IdDepartamento";
                this.DdlDepartamento.DataTextField = "Nombre";
                int idPais = int.Parse(DdlPais.SelectedValue.ToString());
                if (idPais != 0)
                {
                    this.DdlDepartamento.DataSource = PaisDepartamentoCiudad.ListarDepartamento(idPais);
                }
                this.DdlDepartamento.DataBind();

                this.DdlCiudad.DataValueField = "IdCiudad";
                this.DdlCiudad.DataTextField = "Nombre";
                int IdDpto = int.Parse(DdlDepartamento.SelectedValue.ToString());
                if (IdDpto != 0)
                {
                    this.DdlCiudad.DataSource = PaisDepartamentoCiudad.ListarCiudad(IdDpto);
                }
                this.DdlCiudad.DataBind();
            }
        }

        public void DdlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fachada.WebPublica.PaisDepartamentoCiudad PaisDepartamentoCiudad = new Fachada.WebPublica.PaisDepartamentoCiudad();

            int IdDpto = int.Parse(DdlDepartamento.SelectedValue.ToString());
            if (IdDpto != 0)
            {
                this.DdlCiudad.DataSource = PaisDepartamentoCiudad.ListarCiudad(IdDpto);
            }
            this.DdlCiudad.DataBind();
        }

        public void DdlPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fachada.WebPublica.PaisDepartamentoCiudad PaisDepartamentoCiudad = new Fachada.WebPublica.PaisDepartamentoCiudad();

            int idPais = int.Parse(DdlPais.SelectedValue.ToString());
            if (idPais != 0)
            {
                this.DdlDepartamento.DataSource = PaisDepartamentoCiudad.ListarDepartamento(idPais);
            }
            this.DdlDepartamento.DataBind();
        }

        public EntidadesWeb.Pais Pais
        {
            get
            {
                EntidadesWeb.Pais pais = new EntidadesWeb.Pais();
                pais.IdPais = int.Parse(DdlCiudad.SelectedValue.ToString());
                pais.Nombre = DdlPais.SelectedItem.Text;

                return pais;
            }

        }

        public EntidadesWeb.Departamento Departamento
        {
            get
            {
                EntidadesWeb.Departamento departamento = new EntidadesWeb.Departamento();
                departamento.IdDepartamento = int.Parse(DdlCiudad.SelectedValue.ToString());
                departamento.Nombre = DdlDepartamento.SelectedItem.Text;

                return departamento;
            }
        }

        public EntidadesWeb.Ciudad Ciudad
        {
            get
            {
                EntidadesWeb.Ciudad ciudad = new EntidadesWeb.Ciudad();
                ciudad.IdCiudad = int.Parse(DdlCiudad.SelectedValue.ToString());
                ciudad.Nombre = DdlCiudad.SelectedItem.Text;

                return ciudad;
            }
        }

        public DropDownList Ddl_Pais
        {
            get
            {
                return this.DdlPais;
            }
            set
            {
                this.DdlPais = value;
            }
        }

        public DropDownList Ddl_Departamento
        {
            get
            {
                return this.DdlDepartamento;
            }
            set
            {
                this.DdlDepartamento = value;
            }
        }

        public DropDownList Ddl_Ciudad
        {
            get
            {
                return this.DdlCiudad;
            }
            set
            {
                this.DdlCiudad = value;
            }
        }
    }
}