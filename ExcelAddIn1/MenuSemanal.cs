using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestSharp.Extensions;

namespace ExcelAddIn1
{
    public partial class MenuSemanal : Form
    {
        public MenuSemanal()
        {
            InitializeComponent();
            
        }

        private void Btrecetasemanal_Click(object sender, EventArgs e)
        {

        }

        private void Dtpikerinicio_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void Dtpikerfinal_ValueChanged(object sender, EventArgs e)
        {
           
            DateTime inicio = Dtpikerinicio.Value;
            DateTime final = Dtpikerfinal.Value;
            
            int numerodias = ((final - inicio).Days);
            DateTime dd = DateTime.Now;
            string fecha = dd.ToString("yyyy-M-d");
            lbDiaSemana.Items.Add(fecha);
            lbDiaSemana.Items.Add(Dtpikerfinal.Value.Day).ToString("dddd");



      
            //for (int i = 0; i <= numerodias; i++)
            //{

            //}

            //int prueba = (final - inicio);
            ////Convert.ToString() ;
            ////lbDiaSemana.Items.Add(numerodias);
            //Convert.ToString(numerodias);
            //lbDiaSemana.Items.Add(Dtpikerinicio.Value).ToString("dddd");



            //DateTime dateValue = new DateTime(2017,4 , 3);
            //lbDiaSemana.Items.Add(dateValue.ToString("dddd"));
            //lbDiaSemana.Items.Add(numerodias);

            //string[] dias = fecha.Split('-');
            //int calis = fecha[1];
            //lbDiaSemana.Items.Add(calis).ToString();
        }

        private void lbDiaSemana_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
