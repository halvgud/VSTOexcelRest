using System;
using System.Windows.Forms;
using RestSharp;

namespace testVSTO2
{
    public partial class SideBarImportarInformacion : UserControl
    {
        public SideBarImportarInformacion()
        {
            InitializeComponent();
        }
        public void EjecucionAsync(Action<Action<IRestResponse>> accionInicial)
        {
            accionInicial(x =>
            {
                //  MessageBox.Show(x);
            });
        }

        private void cbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDepartamento.SelectedValue.ToString() != "")
            {
                Prop.Config.Local.Departamento.IdDepartamento = cbDepartamento.SelectedValue.ToString();
                Prop.Opcion.EjecucionAsync(Data.Categoria.Lista, x =>
                {
                    BeginInvoke((MethodInvoker)(() =>
                    {
                        var bindingSource1 = new BindingSource
                        {
                            DataSource = Prop.Opcion.JsonaListaGenerica<Respuesta.CbGenerico>(x)
                        };

                        cbCategoria.DataSource = bindingSource1;
                        cbCategoria.DisplayMember = "nombre";
                        cbCategoria.ValueMember = "id";
                    }));
                });
            }
        }
        private void ImportarInformacion_Load(object sender, EventArgs e)
        {
            Prop.Opcion.EjecucionAsync(Data.Departamento.Lista, CargarComboBox);
        }
        public void CargarComboBox(IRestResponse json)
        {
            BeginInvoke((MethodInvoker)(() =>
            {
                var bindingSource1 = new BindingSource
                {
                    DataSource = Prop.Opcion.JsonaListaGenerica<Respuesta.CbGenerico>(json)
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
            btAceptar.Enabled = cbCategoria.SelectedValue.ToString() != "" && cbDepartamento.SelectedValue.ToString() != "";
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {

        }
    }
}
