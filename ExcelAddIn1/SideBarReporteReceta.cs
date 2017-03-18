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
    }
}
