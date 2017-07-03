using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            cbreportes.Items.Add(Reportess);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((cbreportes.SelectedIndex + 1) == 1){

            }
            if ((cbreportes.SelectedIndex+1)==2) {
                var cocina = new SideBarReporteReceta();
                cocina.Show();

            }
            if ((cbreportes.SelectedIndex + 1) == 3)
            {

            }
            var fechass = new SideBarReporteReceta.fechado
            {
                FechaFinal = dtpfinal.Value.ToShortDateString(),
                FechaInicio = dtpinicio.Value.ToShortDateString()
            };
        }
    }
}
