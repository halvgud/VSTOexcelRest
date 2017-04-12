using System;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using Respuesta;
using RestSharp;
using Herramienta;
using System.Collections.Generic;
using System.Linq;
using PresentationControls;
using Receta = Respuesta.Receta;


namespace ExcelAddIn1
{
    public partial class MenuSemanal : Form
    {
        public class Inputs
        {
          
            
        }
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
            cbDias.Items.Add("All");
            cbDias.Items.Add("Lunes");
            cbDias.Items.Add("Martes");
            cbDias.Items.Add("Miercoles");
            cbDias.Items.Add("Jueves");
            cbDias.Items.Add("Viernes");
            cbDias.Items.Add("Sabado");
            cbDias.Items.Add("Domingo");
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

        
        private void DtpFecha_ValueChanged(object sender, EventArgs e)
        {
            var date = new DateTime(Convert.ToInt16(DtpFecha.Value.ToString("yyyy")), Convert.ToInt16(DtpFecha.Value.ToString("MM")), Convert.ToInt16(DtpFecha.Value.ToString("dd")));
            var lu = "Monday";
            var ma = "Tuesday";
            var mi = "Wednesday";
            var ju = "Thursday";
            var vi = "Friday";
            var sa = "Saturday";
            var dom = "Sunday";

            //lunes
            if (lu == date.DayOfWeek.ToString())
            {
                FechaLunes.Text = Convert.ToString(DtpFecha.Value.ToShortDateString());
            }
            //martes
            if (ma == date.DayOfWeek.ToString())
            {
                FechaMartes.Text = Convert.ToString(DtpFecha.Value.ToShortDateString());
            }
            //miercoles
            if (mi == date.DayOfWeek.ToString())
            {
                FechaMiercoles.Text = Convert.ToString(DtpFecha.Value.ToShortDateString());
            }
            //jueves
            if (ju == date.DayOfWeek.ToString())
            {
                FechaJueves.Text = Convert.ToString(DtpFecha.Value.ToShortDateString());
            }
            //viernes
            if (vi == date.DayOfWeek.ToString())
            {
                FechaViernes.Text = Convert.ToString(DtpFecha.Value.ToShortDateString());
            }
            //sabado
            if (sa == date.DayOfWeek.ToString())
            {
                FechaSabado.Text = Convert.ToString(DtpFecha.Value.ToShortDateString());
                //domingo
                if (dom == date.DayOfWeek.ToString())
                {
                    FechaDomingo.Text = Convert.ToString(DtpFecha.Value.ToShortDateString());
                }
            }

        }

        private void cbDias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDias.CheckBoxItems[0].Checked == true)
            {
                cbDias.CheckBoxItems[1].Checked = true;
                cbDias.CheckBoxItems[2].Checked = true;
                cbDias.CheckBoxItems[3].Checked = true;
                cbDias.CheckBoxItems[4].Checked = true;
                cbDias.CheckBoxItems[5].Checked = true;
                cbDias.CheckBoxItems[6].Checked = true;
                cbDias.CheckBoxItems[7].Checked = true;
            }
            if (cbDias.CheckBoxItems[0].Checked==false)
            {
                cbDias.CheckBoxItems[1].Checked = false;
                cbDias.CheckBoxItems[2].Checked = false;
                cbDias.CheckBoxItems[3].Checked = false;
                cbDias.CheckBoxItems[4].Checked = false;
                cbDias.CheckBoxItems[5].Checked = false;
                cbDias.CheckBoxItems[6].Checked = false;
                cbDias.CheckBoxItems[7].Checked = false;
            }
            return;  
        }

        //private void LlamarDiasDeLaSemana(List<Receta.Semana>  )
        //{
        //    DateTime date = new DateTime(Convert.ToInt16(DtpFecha.Value.ToString("yyyy")), Convert.ToInt16(DtpFecha.Value.ToString("MM")), Convert.ToInt16(DtpFecha.Value.ToString("dd")));
        //    List<Receta.Semana> dias = new List<Receta.Semana>(

        //        lunes
                
        //        );

        //    }

        }
    }
