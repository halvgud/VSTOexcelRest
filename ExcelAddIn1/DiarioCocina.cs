using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Herramienta;
using Herramienta.Config;


namespace ExcelAddIn1
{
    public partial class DiarioCocina : Form
    {
        public DiarioCocina()
        {
            InitializeComponent();
        }

        public List<Cocina.ReporteDiarioCocina.FechasReporte> _ListfechasList; 
        private void DiarioCocina_Load(object sender, EventArgs e)
        {

            var fechainicior =DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
            var fechafinalr = DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd");
            var fechas= new Cocina.ReporteDiarioCocina.FechasReporte
                   {
                       FechaInicioR = fechainicior,
                       FechaFinalR = fechafinalr
                   };

            Opcion.EjecucionAsync(x =>
            {
                Data.Reporte.RepoDiarioD(x, fechas); 
                 
            }, jsonResult =>

            {
                BeginInvoke((MethodInvoker)(() =>
                {
                    switch (jsonResult.StatusCode)
                    {
                        case HttpStatusCode.OK:
                           
                            dgvrepodiario.DataSource = Opcion.JsonaListaGenerica<Respuesta.Reporte.RespuestaCocina.Repo_Diario>(jsonResult);

                            break;
                        default:
                            MessageBox.Show(@"Comunicar al area de Sistemas");
                            break;
                    }
                }));
            });
        }
    }
}
