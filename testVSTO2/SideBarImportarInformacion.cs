 using System;
using System.Windows.Forms;
using RestSharp;
using Herramienta;
using Herramienta.Config;

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
            if (cbDepartamento.SelectedValue.ToString() == "") return;
            Local.Departamento.IdDepartamento = cbDepartamento.SelectedValue.ToString();
            Opcion.EjecucionAsync(Data.Categoria.Lista, x =>
            {
                CargarComboBox(x, cbCategoria, true);
                ValidarComboBox(cbCategoria, chCategoria);
            });
        
        }
        private void ImportarInformacion_Load(object sender, EventArgs e)
        {
            Opcion.EjecucionAsync(Data.Departamento.Lista, x => CargarComboBox(x,cbDepartamento,true));
            Opcion.EjecucionAsync(Data.Proveedor.Lista, x => CargarComboBox(x,cbProveedor,false));
            Opcion.EjecucionAsync(Data.Articulo.Tipo.Seleccionar,x=>CargarComboBox(x,cbTipoProducto,false));
            Opcion.EjecucionAsync(Data.Reporte.Lista,x=>CargarComboBox(x,cbOrderBy,true));
            Opcion.EjecucionAsync(Data.Sucursal.Lista,x=>CargarComboBox(x,cbSucursal,false));
            cbImprimir.Checked = Data.Permiso.ListaPermisos.Find(x => x.IdControl == "cbImprimir.Checked")?.Valor == "1";
            cbImprimir.Enabled = Data.Permiso.ListaPermisos.Find(x => x.IdControl == "cbImprimir.Enabled")?.Valor == "1";
            dtFechaIni.Value = dtFechaFin.Value.AddDays(-30);
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
                cb.DisplayMember = "Nombre"; /**Le cambiaron el a Id y a Nombre en lugar de id descripcion*/
                cb.ValueMember = "Id";
                cb.Enabled = habilitar;
            }));
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
        ///todo: validar que haya checkbox checked, tomar el ProId y agruparlo para enviarlo en el json
        /// 
        private void btAceptar_Click(object sender, EventArgs e)
        {
            var cancelar = false;
            var mse = new MensajeDeEspera(() =>
            {
                var continuarCancelacion = MessageBox.Show(@"¿Desea detener la operación?",
                @"Alerta",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);
                if (continuarCancelacion != DialogResult.Yes)
                    return false;
                cancelar = true;
                HabilitarSideBar(true);
                return true;
            });
            mse.Show(); 
            HabilitarSideBar(false);
            
            var addIn = Globals.ThisAddIn;
            var respuestaReporteGeneral = new Respuesta.Reporte.General
            {
                CatId = chCategoria.Checked?(cbCategoria.SelectedValue.ToString() == "%25"?"%":cbCategoria.SelectedValue.ToString()):"%",
                DepId = chDepartamento.Checked? (cbDepartamento.SelectedValue.ToString() == "%25" ? "%" : cbDepartamento.SelectedValue.ToString()) : "%",
                FechaFin = dtFechaFin.Value,
                FechaIni = dtFechaIni.Value,
                ProId =  chProveedor.Checked?(cbProveedor.SelectedValue.ToString()):"%",
                OrderBy = cbOrderBy.SelectedValue.ToString(),
                IdTipo = chTipoProducto.Checked?(cbTipoProducto.SelectedValue.ToString()):"%"
            };
            Data.Reporte.FechaIni = dtFechaIni.Value;
            Data.Reporte.FechaFin = dtFechaFin.Value;
            Data.Reporte.Categoria = cbCategoria.Text;
            Data.Reporte.Departamento = cbDepartamento.Text;
            Opcion.EjecucionAsync(x =>
            {   
                if (cbImprimir.Checked)
                    Data.Reporte.Imprimir(x, respuestaReporteGeneral);
                else
                    Data.Reporte.General(x, respuestaReporteGeneral);
            }, y =>
            {
                BeginInvoke((MethodInvoker)(() =>
                {
                    if (y != null&&!cancelar)
                        if (cbImprimir.Checked)
                            addIn.ReporteImprimir(y, () => CerrarCuadroDeEspera(mse));
                        else
                            addIn.ReporteGeneral(y, () => CerrarCuadroDeEspera(mse));
                    else
                    {
                        CerrarCuadroDeEspera(mse);
                        BeginInvoke((MethodInvoker) (() =>
                        {
                            MessageBox.Show(@"No se encontró registros con los parámetros utilizados");
                        }));
                    }    
                }));
            });
        }
        private void CerrarCuadroDeEspera(MensajeDeEspera mse)
        {
            BeginInvoke((MethodInvoker)(() =>
            {
                mse.Close();
                HabilitarSideBar(true);
            }));
        }

        private void ValidarComboBox(ComboBox cb, CheckBox ch)
        {
            BeginInvoke((MethodInvoker)(() =>
            {
                cb.Enabled = ch.Checked;
            }));
        }
        private void chCategoria_CheckedChanged(object sender, EventArgs e)
        {
            ValidarComboBox(cbCategoria, chCategoria);}

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
