using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Herramienta;
using Herramienta.Config;
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

        private void btGenerarReceta_Click(object sender, EventArgs e)
        {
            var addIn = Globals.ThisAddIn;
            //var respuestaReporteGeneral = new Reporte.General
            //{
            //    CatId = "%",
            //    DepId = "%",
            //    FechaFin = dtFechaFin.Value,
            //    FechaIni = dtFechaIni.Value,
            //    ProId = "0",
            //    ProId2 = arregloList,
            //    OrderBy = "ORDER BY a.margen1 DESC",
            //    IdTipo = "%"
            //};
            //Data.Reporte.FechaIni = dtFechaIni.Value;
            //Data.Reporte.FechaFin = dtFechaFin.Value;
            //Data.Reporte.Categoria = "%";
            //Data.Reporte.Departamento = "%";
            Opcion.EjecucionAsync(Data.ReporteCocina.VersionExtendida, y =>
            {
                BeginInvoke((MethodInvoker)(() =>
                {
                    addIn.ReporteCocina(y);
                }));
            });
     
        }

        private void cbConceptoReceta_SelectedIndexChanged(object sender, EventArgs e)
        {

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
            Opcion.EjecucionAsync(Data.ParametroConcepto.Lista, x =>
            {
                CargarComboBox(x, cbConceptoReceta);

            });
            Opcion.EjecucionAsync(Data.ParametroReceta.Lista, x =>
            {
                CargarComboBox(x, cbOrdenarReceta);

            });
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SideBarReporteReceta_MouseClick(object sender, MouseEventArgs e)
        {

        }
    }
}
