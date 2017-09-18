using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Herramienta;
using Respuesta;
using RestSharp;

namespace ExcelAddIn1
{
    public partial class SideBarReporteReceta : UserControl
    {
        public SideBarReporteReceta()
        {
            InitializeComponent();
          
        }


        public static DateTime FechaInicio { get; set; }
        public static DateTime FechaFinal { get; set; }
        public class Fechado
        {
            public string FechaInicio { get; set; }
            public string FechaFinal { get; set; }
        }

        //esos errores no me avian salido ahorita }
        public List<Respuesta.CbGenerico> ListproductoList;
        public List<Respuesta.CbGenerico> ListorderList; 

        private void btGenerarReceta_Click(object sender, EventArgs e)
        {
            //var datosimportar = new Respuesta.Orderbyandgroupby()
            //{
            //    Id = cbproducto.SelectedIndex,
            //    Order = cbOrdenarReceta.SelectedItem.ToString()
            //}
            // ;
            var msj = new MensajeDeEspera();
            msj.Show();            
            FechaInicio =Convert.ToDateTime(dtpFechaIni.Value.ToString("yyyy/MM/dd 00:00:00"));
            FechaFinal = Convert.ToDateTime(dtpFechaFin.Value.ToString("yyyy/MM/dd HH:mm:ss"));
            ThisAddIn.FechaDateTime=DateTime.Now;
            var addIn = Globals.ThisAddIn;
            if(cbTipoReceta.Checked)
            { 
                Opcion.EjecucionAsync(x =>
            {
                var datosimportar = new Respuesta.Reporte.RespuestaCocina.Reportess
                {
                    Id = Convert.ToInt16(cbproducto.SelectedValue.ToString()),
                    Orderby = cbOrdenarReceta.SelectedValue.ToString(),
                    FechaFinal = Convert.ToDateTime(FechaFinal.ToString()),
                    FechaInicio = Convert.ToDateTime(FechaInicio.ToString())

                };

                Data.ReporteCocina.VersionExtendida(x, datosimportar); 
            }, y =>
            {
                BeginInvoke((MethodInvoker)(() =>
                {
                    msj.Close();
                    addIn.ReporteCocina(y);
                }));

            });
            }
            if (cbPlatillo.Checked)
            {
                Opcion.EjecucionAsync(x =>
                {
                    var datosimportar = new Respuesta.Reporte.RespuestaCocina.Reportess
                    {
                        Clave = tbProducto.Text == string.Empty ? "%" :tbProducto.Text,
                        FechaFinal = Convert.ToDateTime(FechaFinal.ToString()),
                        FechaInicio = Convert.ToDateTime(FechaInicio.ToString())

                    };

                    Data.ReporteCocina.VersionExtendidaporPlatillo(x, datosimportar);
                }, y =>
                {
                    BeginInvoke((MethodInvoker)(() =>
                    {
                        msj.Close();
                        addIn.ReporteCocina(y);
                    }));

                });

            }
            cbTipoReceta.Checked = false;
            cbPlatillo.Checked = false;


        }
        public void CargarComboBox(IRestResponse json, ComboBox tipoReceta)
        {
            BeginInvoke((MethodInvoker)(() =>
            {
                var bindingSource1 = new BindingSource
                {
                    DataSource = Opcion.JsonaListaGenerica<CbGenerico>(json)
                };
                tipoReceta.DataSource = bindingSource1; 
                tipoReceta.DisplayMember = "Nombre";
                tipoReceta.ValueMember = "Id";
                tipoReceta.Tag = json;
            }));
        }
        private void SideBarReporteReceta_Load(object sender, EventArgs e)
        {
            tbProducto.Visible = false;
            cbproducto.Visible = false;
            lbOrdenar.Visible = false;
            cbOrdenarReceta.Visible = false;
            btGenerarReceta.Enabled = false;
            Opcion.EjecucionAsync(Data.ParametroProducto.Lista, x =>
            {
                CargarComboBox(x, cbproducto);
            });
            Opcion.EjecucionAsync(Data.ParametroReceta.Lista, x =>
            {
                CargarComboBox(x, cbOrdenarReceta);
            });   
        }
        private void cbOrdenarReceta_SelectedIndexChanged(object sender, EventArgs e)
        {
            btGenerarReceta.Enabled = true;
        }
        private void cbTipoReceta_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTipoReceta.Checked)
            {
                cbproducto.Visible = true;
                lbOrdenar.Visible = true;
                cbOrdenarReceta.Visible = true;
                btGenerarReceta.Enabled = true;
                cbPlatillo.Checked = false;
            }
            else
            {
                cbproducto.Visible = false;
                lbOrdenar.Visible = false;
                cbOrdenarReceta.Visible = false;
                btGenerarReceta.Enabled = false;
            }
        }
        private void cbPlatillo_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPlatillo.Checked)
            {
                tbProducto.Visible = true;
                btGenerarReceta.Enabled= true;
                cbTipoReceta.Checked = false;
            }
            else
            {
                tbProducto.Visible = false;
                btGenerarReceta.Enabled = false;
        
            }
            
        }

        private void tbProducto_TextChanged(object sender, EventArgs e)
        {
            btGenerarReceta.Enabled = true;
        }
    }
}
