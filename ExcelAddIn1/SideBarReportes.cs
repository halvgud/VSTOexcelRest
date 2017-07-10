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

namespace ExcelAddIn1
{
    public partial class SideBarReportes : UserControl
    {

        private readonly List<reportes> Reportess;
        public SideBarReportes()
        {
            InitializeComponent();
            Reportess = new List<reportes>();
        }

        public class reportes
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
        }

        private void Reportes_Load(object sender, EventArgs e)
        {
            Reportess.Add(new reportes { Nombre="Reporte Inventario",Id=1});
            Reportess.Add(new reportes { Nombre = "Reporte Cocina", Id = 2 });
            Reportess.Add(new reportes { Nombre="Reporte Diario", Id=3});
           cbreportes.Items.Add(Reportess.ToList());

            cbreportes.DataSource = Reportess.ToArray();
            cbreportes.DisplayMember = "Nombre";
            cbreportes.ValueMember = "Id";
            //cbreportes.DataSource = Reportess;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((cbreportes.SelectedIndex + 1) == 1)
            {
                var ms = new MensajeDeEspera();
                ms.Show();
                var addIn = Globals.ThisAddIn;
                
                    Opcion.EjecucionAsync(Data.Reporte.RepCongelados, y =>
                    {
                        addIn.ReporteCongelados(y);
                        ms.Close();
                    });
                
                
                

            }
            if ((cbreportes.SelectedIndex+1)==2) {

                ThisAddIn.ReporteReceta.Visible = true;
                ThisAddIn.ReportessCustomTaskPane.Visible = false;
                SideBarReporteReceta.FechaFinal = Convert.ToDateTime(dtpfinal.Value.ToString("yyyy/MM/dd HH:mm:ss")) ;
                SideBarReporteReceta.FechaInicio =Convert.ToDateTime(dtpinicio.Value.ToString("yyyy/MM/dd 00:00:00"))  ;
        
            }
            if ((cbreportes.SelectedIndex + 1) == 3)
            {
              

            }

        }

        private void cbreportes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((cbreportes.SelectedIndex + 1) == 1)
            {
                //chhistoria.Visible = true;
                dtpfinal.Visible = false;
                dtpinicio.Visible = false;
                lbde.Visible = false;
                lbhasta.Visible = false;
            }
            if ((cbreportes.SelectedIndex+1)==2)
            {
                //chhistoria.Visible = false;
                dtpfinal.Visible = true;
                dtpinicio.Visible = true;
                lbde.Visible = true;
                lbhasta.Visible=true;
            }

        }


    }
}
