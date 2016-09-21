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
                Config.Local.Departamento.IdDepartamento = cbDepartamento.SelectedValue.ToString();
                Opcion.EjecucionAsync(Data.Categoria.Lista,x=> CargarComboBox(x, cbCategoria, true));
            }
        }
        private void ImportarInformacion_Load(object sender, EventArgs e)
        {
            Opcion.EjecucionAsync(Data.Departamento.Lista, x => CargarComboBox(x,cbDepartamento,true));
            Opcion.EjecucionAsync(Data.Proveedor.Lista, x => CargarComboBox(x,cbProveedor,false));
            Opcion.EjecucionAsync(Data.Articulo.Tipo.Seleccionar,x=>CargarComboBox(x,cbTipoProducto,false));
        }
        public void CargarComboBox(IRestResponse json,ComboBox cb,bool habilitar)
        {
            BeginInvoke((MethodInvoker)(() =>
            {
                var bindingSource1 = new BindingSource
                {
                    DataSource = Opcion.JsonaListaGenerica<Respuesta.CbGenerico>(json)
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

        private void HabilitarSideBar(bool bandera)
        {
            panel1.Enabled = bandera;
            btAceptar.Enabled = bandera;
            btAyuda.Enabled = bandera;
            tabControl1.Enabled = bandera;
            
        }
        private void btAceptar_Click(object sender, EventArgs e)
        {
            MensajeDeEspera mse=new MensajeDeEspera();
            HabilitarSideBar(false);
            mse.Show();
            var addIn = Globals.ThisAddIn;
            var rrg = new Respuesta.Reporte.General
            {
                cat_id = Convert.ToInt32(cbCategoria.SelectedValue),
                dep_id = Convert.ToInt32(cbDepartamento.SelectedValue),
                fechaFin = dtFechaFin.Value,
                fechaIni = dtFechaIni.Value
            };
            if (!cbImprimir.Checked)
            {

                Opcion.EjecucionAsync(x =>
                {
                    Data.Reporte.General(x, rrg);
                }, y =>
                {
                    addIn.ReporteGeneral(y);
                    BeginInvoke((MethodInvoker)(() =>
                    {
                        mse.Close();
                        HabilitarSideBar(true);
                    }));
                });
            }
            else
            {
                Opcion.EjecucionAsync(x =>
                {
                    Data.Reporte.Imprimir(x, rrg);
                }, y =>
                {
                    addIn.ReporteImprimir(y);
                    BeginInvoke((MethodInvoker) (() =>
                    {
                        mse.Close();
                        HabilitarSideBar(true);
                    }));
                });

            }
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
