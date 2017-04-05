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
using System.Globalization;
using Respuesta;
using RestSharp;
using Herramienta;


namespace ExcelAddIn1
{
    public partial class MenuSemanal : Form
    {
        public MenuSemanal()
        {
            InitializeComponent();
        }

        private void Dtpikerinicio_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void MenuSemanal_Load(object sender, EventArgs e)
        {


            dvgLunes.AutoGenerateColumns = false;
            dvgMartes.AutoGenerateColumns = false;
            dvgMiercoles.AutoGenerateColumns = false;
            dvgJueves.AutoGenerateColumns = false;
            dvgViernes.AutoGenerateColumns = false;
            dvgSabado.AutoGenerateColumns = false;
            dvgDomingo.AutoGenerateColumns = false;
        }

        private void FechaJueves_Click(object sender, EventArgs e)
        {

        }

        private void dvgLunes_AllowUserToAddRowsChanged(object sender, EventArgs e)
        {
            
        }


        //public void LlenarTipo(IRestResponse json,  tipoReceta)
        //{
        //    BeginInvoke((MethodInvoker)(() =>
        //    {
        //        var bindingSource1 = new BindingSource
        //        {
        //            DataSource = Opcion.JsonaListaGenerica<CbGenerico>(json)
        //        };
        //        tipoReceta.DataSource = bindingSource1;
        //        tipoReceta.DisplayMember = "nombre";
        //        tipoReceta.ValueMember = "id";
        //        tipoReceta.Tag = json;
        //    }));
        //}
    }
}
