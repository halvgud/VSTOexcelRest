using System;
using System.Windows.Forms;
using RestSharp;
using testVSTO2.Prop;

namespace testVSTO2
{
    public partial class SideBarImportarInformacion : UserControl
    {
        public SideBarImportarInformacion()
        {
            InitializeComponent();
        }

        private void cbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDepartamento.SelectedValue.ToString() != "")
            {
                Prop.Config.Local.Departamento.IdDepartamento = cbDepartamento.SelectedValue.ToString();
                Prop.Opcion.EjecucionAsync(Data.Categoria.Lista,x=> CargarComboBox(x, cbCategoria, true));
            }
        }
        private void ImportarInformacion_Load(object sender, EventArgs e)
        {
            Prop.Opcion.EjecucionAsync(Data.Departamento.Lista, x => CargarComboBox(x,cbDepartamento,true));
            Prop.Opcion.EjecucionAsync(Data.Proveedor.Lista, x => CargarComboBox(x,cbProveedor,false));
        }
        public void CargarComboBox(IRestResponse json,ComboBox cb,bool habilitar)
        {
            BeginInvoke((MethodInvoker)(() =>
            {
                var bindingSource1 = new BindingSource
                {
                    DataSource = Prop.Opcion.JsonaListaGenerica<Respuesta.CbGenerico>(json)
                };
                cb.DataSource = bindingSource1;
                cb.DisplayMember = "nombre";
                cb.ValueMember = "id";
                cb.Enabled = habilitar;
            }
            ));
        }

        private void cbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            btAceptar.Enabled = cbCategoria.SelectedValue.ToString() != "" && cbDepartamento.SelectedValue.ToString() != "";
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            var addIn = Globals.ThisAddIn;
            Opcion.EjecucionAsync(x =>
            {
                Data.Reporte.General(x, new Respuesta.Reporte.General
                {
                    cat_id = Convert.ToInt32(cbCategoria.SelectedValue),
                    dep_id = Convert.ToInt32(cbDepartamento.SelectedValue),
                    fechaFin = dtFechaFin.Value,
                    fechaIni = dtFechaIni.Value
                });
            }, addIn.ReporteGeneral);
        }
        private static void ValidarComboBox(ComboBox cb, CheckBox ch)
        {
            cb.Enabled = ch.Checked;
        }
        private void chCategoria_CheckedChanged(object sender, EventArgs e)
        {
            ValidarComboBox(cbCategoria, chCategoria);
        }

        private void chDepartamento_CheckedChanged(object sender, EventArgs e)
        {
            ValidarComboBox(cbDepartamento, chDepartamento);
        }

        private void chProveedor_CheckedChanged(object sender, EventArgs e)
        {
            ValidarComboBox(cbProveedor, chProveedor);
        }

        private void chTipoProducto_CheckedChanged(object sender, EventArgs e)
        {
            ValidarComboBox(cbTipoProducto, chTipoProducto);
        }
    }
}
