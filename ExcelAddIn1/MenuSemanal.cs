using System;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using Respuesta;
using RestSharp;
using Herramienta;
using System.Collections.Generic;
using System.Linq;




namespace ExcelAddIn1
{
    public partial class MenuSemanal : Form
    {
        private List<Receta> _listaRecetas;
        public MenuSemanal()
        {

            InitializeComponent();
            _listaRecetas = new List<Receta>();



            Opcion.EjecucionAsync(Data.Receta.Tipo.Lista, x =>
            {
                LlenarTipo(x, TipoLunes);
                LlenarTipo(x, TipoMartes);
                LlenarTipo(x, TipoMiercoles);
                LlenarTipo(x, TipoJueves);
                LlenarTipo(x, TipoViernes);
                LlenarTipo(x, TipoSabado);
                LlenarTipo(x, TipoDomingo);
            });
           
        }

        private void PopulateManualCombo()
        {
            comboBox1.Items.Add("All");
            comboBox1.Items.Add("Lunes");
            comboBox1.Items.Add("Martes");
            comboBox1.Items.Add("Miercoles");
            comboBox1.Items.Add("Jueves");
            comboBox1.Items.Add("Viernes");
            comboBox1.Items.Add("Sabado");
            comboBox1.Items.Add("Domingo");
        }


        public void LlenarTipo(IRestResponse json, DataGridViewComboBoxColumn tipoColumn)
        {
      
            BeginInvoke((MethodInvoker)(() =>
            {
                var bindingSource1 = new BindingSource
                {
                    DataSource = Opcion.JsonaListaGenerica<CbGenerico>(json)
                };
                tipoColumn.DataSource = bindingSource1;
                tipoColumn.DisplayMember = "nombre";
                tipoColumn.ValueMember = "id";
                tipoColumn.Tag = json;
            }));
        }

        private void MenuSemanal_Load(object sender, EventArgs e)
        {
            PopulateManualCombo();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.CheckBoxItems[0].Checked == false)
            {

                comboBox1.CheckBoxItems[1].Checked = false;
                comboBox1.CheckBoxItems[2].Checked = false;
                comboBox1.CheckBoxItems[3].Checked = false;
                comboBox1.CheckBoxItems[4].Checked = false;
                comboBox1.CheckBoxItems[5].Checked = false;
                comboBox1.CheckBoxItems[6].Checked = false;
                comboBox1.CheckBoxItems[7].Checked = false;
                comboBox1.Items.Remove(comboBox1.SelectedItem);
            }
            else
                {
                comboBox1.CheckBoxItems[1].Checked = true;
                comboBox1.CheckBoxItems[2].Checked = true;
                comboBox1.CheckBoxItems[3].Checked = true;
                comboBox1.CheckBoxItems[4].Checked = true;
                comboBox1.CheckBoxItems[5].Checked = true;
                comboBox1.CheckBoxItems[6].Checked = true;
                comboBox1.CheckBoxItems[7].Checked = true;
            }
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox1.CheckBoxItems[0].Checked == false)
            {
                comboBox1.CheckBoxItems[1].Checked = false;
                comboBox1.CheckBoxItems[2].Checked = false;
                comboBox1.CheckBoxItems[3].Checked = false;
                comboBox1.CheckBoxItems[4].Checked = false;
                comboBox1.CheckBoxItems[5].Checked = false;
                comboBox1.CheckBoxItems[6].Checked = false;
                comboBox1.CheckBoxItems[7].Checked = false;
                comboBox1.Items.Remove(comboBox1.SelectedItem);
                comboBox1.Items.Clear();
            }
        }

        private void DtpFecha_ValueChanged(object sender, EventArgs e)
        {
            DateTime date = new DateTime(Convert.ToInt16(DtpFecha.Value.ToString("yyyy")), Convert.ToInt16(DtpFecha.Value.ToString("MM")), Convert.ToInt16(DtpFecha.Value.ToString("dd")));
            string l = "Monday";
            string m = "Tuesday";
            string M = "Wednesday";
            string j = "Thursday";
            string v = "Friday";
            string s = "Saturday";
            string d = "Sunday";

            //lunes
            if (l == date.DayOfWeek.ToString())
            {
                FechaLunes.Text = Convert.ToString(DtpFecha.Value.ToShortDateString());
            }
            //martes
            if (m == date.DayOfWeek.ToString())
            {
                FechaMartes.Text = Convert.ToString(DtpFecha.Value.ToShortDateString());
            }
            //miercoles
            if (M == date.DayOfWeek.ToString())
            {
                FechaMiercoles.Text = Convert.ToString(DtpFecha.Value.ToShortDateString());
            }
            //jueves
            if (j == date.DayOfWeek.ToString())
            {
                FechaJueves.Text = Convert.ToString(DtpFecha.Value.ToShortDateString());
            }
            //viernes
            if (v == date.DayOfWeek.ToString())
            {
                FechaViernes.Text = Convert.ToString(DtpFecha.Value.ToShortDateString());
            }
            //sabado
            if (s == date.DayOfWeek.ToString())
            {
                FechaSabado.Text = Convert.ToString(DtpFecha.Value.ToShortDateString());
                //domingo
                if (d == date.DayOfWeek.ToString())
                {
                    FechaDomingo.Text = Convert.ToString(DtpFecha.Value.ToShortDateString());
                }
            }

        }
    }

}
