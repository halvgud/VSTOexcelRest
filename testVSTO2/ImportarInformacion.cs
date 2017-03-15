using System;
using System.Windows.Forms;
using RestSharp;
using Herramienta;
using Herramienta.Config;

namespace testVSTO2
{
    public partial class ImportarInformacion : Form
    {
        public ImportarInformacion()
        {
            InitializeComponent();
        }

        private void ImportarInformacion_Load(object sender, EventArgs e)
        {
            Opcion.EjecucionAsync(Data.Departamento.Lista, CargarComboBox);
        }
        public void CargarComboBox(IRestResponse json)
        {
            BeginInvoke((MethodInvoker)(() =>
                {
                    var bindingSource1 = new BindingSource
                    {
                        DataSource = Opcion.JsonaListaGenerica<Respuesta.CbGenerico>(json)
                    };
                    cbDepartamento.DataSource = bindingSource1;
                    cbDepartamento.DisplayMember = "nombre";
                    cbDepartamento.ValueMember = "id";
                }
            )
        );
        }

        private void cbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDepartamento.SelectedValue.ToString() != "")
            {
                Local.Departamento.IdDepartamento = cbDepartamento.SelectedValue.ToString();
               Opcion.EjecucionAsync(Data.Categoria.Lista, x =>
                {
                    BeginInvoke((MethodInvoker)(() =>
                    {
                        var bindingSource1 = new BindingSource
                        {
                            DataSource = Opcion.JsonaListaGenerica<Respuesta.CbGenerico>(x)
                        };
                        
                        cbCategoria.DataSource = bindingSource1;
                        cbCategoria.DisplayMember = "nombre";
                        cbCategoria.ValueMember = "id";
                    }));
                });
            }
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {

        }

    }

}
