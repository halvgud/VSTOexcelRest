using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data;
using Herramienta;
using Herramienta.Config;

namespace ExcelAddIn1
{
    public partial class SideBarReportes : UserControl
    {

        private readonly List<Reportes> _reportess;
        public SideBarReportes()
        {
            InitializeComponent();
            _reportess = new List<Reportes>();
        }

        public class Reportes
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
        }

        private void Reportes_Load(object sender, EventArgs e)
        {
            //_reportess.Add(new Reportes { Nombre="Reporte Inventario",Id=1});
            _reportess.Add(new Reportes { Nombre = "Reporte General", Id = 1 });
            //_reportess.Add(new Reportes { Nombre="Reporte Destino", Id=3});
            _reportess.Add(new Reportes { Nombre = "Reporte Platillos ", Id = 2 });
            cbreportes.Items.Add(_reportess.ToList());

            cbreportes.DataSource = _reportess.ToArray();
            cbreportes.DisplayMember = "Nombre";
            cbreportes.ValueMember = "Id";
            //cbreportes.DataSource = Reportess;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if ((cbreportes.SelectedIndex+1)==1) {

            //    ThisAddIn.ReporteReceta.Visible = true;
            //    ThisAddIn.ReportessCustomTaskPane.Visible = false;
                
        
            //}
            var diafinal = Convert.ToDateTime(dtpfinal.Value.ToString("yyyy/MM/dd HH:mm:ss"));
            var diainicio = Convert.ToDateTime(dtpinicio.Value.ToString("yyyy/MM/dd 00:00:00"));
        
                var addIn = Globals.ThisAddIn;

                //Opcion.EjecucionAsync(Data.Reporte.RepCongeladosFechados, y =>
                //{
                //    addIn.ReporteCongelados(y);
        
                //});

            Opcion.EjecucionAsync(x =>
            {
                var datosimportar = new Respuesta.Reporte.RespuestaCocina.Reportess
                {
                    FechaFinal = Convert.ToDateTime(diafinal),
                    FechaInicio = Convert.ToDateTime(diainicio)

                };

                Data.Reporte.RepCongeladosFechados(x, datosimportar);
            }, y =>
            {
                if (y != null)
                {

                BeginInvoke((MethodInvoker)(() =>
                {

                    addIn.ReporteCongelados(y);
                }));
                }
                else
                {
                    
                    addIn.ReporteCongelados(y);
                }
            });      
         }

        private void cbreportes_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if ((cbreportes.SelectedIndex + 1) == 1)
            //{
            //    //chhistoria.Visible = true;
            //    dtpfinal.Visible = false;
            //    dtpinicio.Visible = false;
            //    lbde.Visible = false;
            //    lbhasta.Visible = false;
            //}
            //if ((cbreportes.SelectedIndex+1)==2)
            //{
            //    //chhistoria.Visible = true;
            //    dtpfinal.Visible = false;
            //    dtpinicio.Visible = false;
            //    lbde.Visible = false;
            //    lbhasta.Visible = false;
            //}

        }


    }
}
