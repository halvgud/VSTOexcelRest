using System;
using System.Windows.Forms;
using Respuesta;
using RestSharp;
using Herramienta;
using System.Collections.Generic;
using System.Linq;
using Herramienta.Config;
using PresentationControls;
using Receta = Respuesta.Receta;
using System.Drawing;
using System.Globalization;
using System.Net;
using System.Xml.Serialization;


namespace ExcelAddIn1
{
    public partial class MenuSemanal : Form
    {

        public class Inputs
        {
            public CheckBoxComboBox DiasSemana;
            public DataGridView DtvMenus;

        }
  
        private List<MenuSemanal> _listasemanas;
        public MenuSemanal()
        {
          
            InitializeComponent();
         
            _listasemanas = new List<MenuSemanal>();
         

            Opcion.EjecucionAsync(Data.Receta.Tipo.Lista, x =>
            {
                //CargarComboBox(x, TipoLunes);
                //CargarComboBox(x, TipoMartes);
                //CargarComboBox(x, TipoMiercoles);
                //CargarComboBox(x, TipoJueves);
                //CargarComboBox(x, TipoViernes);
                //CargarComboBox(x, TipoSabado);
                //CargarComboBox(x, TipoDomingo);

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

        public void CargarComboBox(IRestResponse json, DataGridViewComboBoxColumn tipoColumn)
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
            //var i = Weekday(DateTime.Now, DayOfWeek.Monday);
            //DtpFecha.Format = DateTimePickerFormat.Custom;
         //DtpFecha.Value = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + 1);     
        }
        public static DateTime FirstDayOfWeek(DateTime date)
        {
            DayOfWeek fdow = CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
            int offset = fdow - date.DayOfWeek;
            DateTime fdowDate = date.AddDays(offset);
            return fdowDate;
        }

        public static DateTime LastDayOfWeek(DateTime date)
        {
            DateTime ldowDate = FirstDayOfWeek(date).AddDays(6);
            return ldowDate;
        }
        private void DtpFecha_ValueChanged(object sender, EventArgs e)
        {
            string diainicio = FirstDayOfWeek(DtpFecha.Value).ToShortDateString();
            string diafinal = LastDayOfWeek(DtpFecha.Value).ToShortDateString();
            Opcion.EjecucionAsync(x =>
            {
                   var times = new Reporte.General
                {
                    FechaIni = Convert.ToDateTime(diainicio),
                    FechaFin = Convert.ToDateTime(diafinal)
                };
                Data.MenuSemanal.CargarDias(x, times);
            }, jsonResult =>
            {
                if (jsonResult != null) { 
                BeginInvoke((MethodInvoker)(() =>
                {
                    switch (jsonResult.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            dgvLunes.DataSource = Opcion.JsonaClaseGenerica2<Respuesta.MenuSemanal>(jsonResult).Lunes;
                            FechaLunes.Text = Opcion.JsonaClaseGenerica2<Respuesta.MenuDia>(jsonResult).FechaElaboracion.ToShortDateString();
                            dgvMartes.DataSource = Opcion.JsonaClaseGenerica2<Respuesta.MenuSemanal>(jsonResult).Martes;
                            dgvMiercoles.DataSource = Opcion.JsonaClaseGenerica2<Respuesta.MenuSemanal>(jsonResult).Miercoles;
                            dgvJueves.DataSource = Opcion.JsonaClaseGenerica2<Respuesta.MenuSemanal>(jsonResult).Jueves;
                            dgvViernes.DataSource = Opcion.JsonaClaseGenerica2<Respuesta.MenuSemanal>(jsonResult).Viernes;
                            dgvSabado.DataSource = Opcion.JsonaClaseGenerica2<Respuesta.MenuSemanal>(jsonResult).Sabado;
                            dgvDomingo.DataSource = Opcion.JsonaClaseGenerica2<Respuesta.MenuSemanal>(jsonResult).Domingo;
                            /* agarra la propiedad de FECHA para ponerle la fecha debajo del DIA */



                            for (var x = 0; x==7; x++)
                            {
                                dgvLunes.Columns[x].ReadOnly = true;
                                dgvLunes.Columns[x].DefaultCellStyle.BackColor = Color.LightGray;
                                dgvMartes.Columns[x].ReadOnly = true;
                                dgvMartes.Columns[x].DefaultCellStyle.BackColor = Color.LightGray;
                                dgvMiercoles.Columns[x].ReadOnly = true;
                                dgvMiercoles.Columns[x].DefaultCellStyle.BackColor = Color.LightGray;
                                dgvJueves.Columns[x].ReadOnly = true;
                                dgvJueves.Columns[x].DefaultCellStyle.BackColor = Color.LightGray;
                                dgvViernes.Columns[x].ReadOnly = true;
                                dgvViernes.Columns[x].DefaultCellStyle.BackColor = Color.LightGray;
                                dgvSabado.Columns[x].ReadOnly = true;
                                dgvSabado.Columns[x].DefaultCellStyle.BackColor = Color.LightGray;
                                dgvDomingo.Columns[x].ReadOnly = true;
                                dgvDomingo.Columns[x].DefaultCellStyle.BackColor = Color.LightGray;

                            }
                           
                            dgvLunes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                            dgvMartes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                            dgvMiercoles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                            dgvJueves.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                            dgvViernes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                            dgvSabado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                            dgvDomingo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                            //FechaLunes.Text = Opcion.JsonaClaseGenerica2<Respuesta.MenuDia>(jsonResult).FechaElaboracion.ToShortDateString();
                            //FechaMiercoles.Text = Opcion.JsonaClaseGenerica2<Respuesta.MenuDia>(jsonResult).FechaElaboracion.ToShortDateString();
                            ////FechaViernes.Text = Convert.ToDateTime(dgvViernes.Columns[3]).ToShortDateString();

                            break;
                        default:
                            MessageBox.Show(this, @"No se encontraron recetas con los parametros de busqueda ingresados");
                            break;
                    }
                }));
                }
            });

            ////    //lunes
            ////    if (lu == date.DayOfWeek.ToString())
            ////{
            ////    DateTime dia2 = Convert.ToDateTime(DtpFecha.Value.ToShortDateString());
            ////    dia2 = dia2.AddDays(1);
            ////    DateTime dia3 = Convert.ToDateTime(DtpFecha.Value.ToShortDateString());
            ////    dia3 = dia3.AddDays(2);
            ////    DateTime dia4 = Convert.ToDateTime(DtpFecha.Value.ToShortDateString());
            ////    dia4 = dia4.AddDays(3);
            ////    DateTime dia5 = Convert.ToDateTime(DtpFecha.Value.ToShortDateString());
            ////    dia5 = dia5.AddDays(4);
            ////    DateTime dia6 = Convert.ToDateTime(DtpFecha.Value.ToShortDateString());
            ////    dia6 = dia6.AddDays(5);
            ////    DateTime dia7 = Convert.ToDateTime(DtpFecha.Value.ToShortDateString());
            ////    dia7 = dia7.AddDays(6);
            ////    FechaLunes.Text = Convert.ToString(DtpFecha.Value.ToShortDateString());
            ////    FechaMartes.Text = Convert.ToString(dia2.ToShortDateString());
            ////    FechaMiercoles.Text = Convert.ToString(dia3.ToShortDateString());
            ////    FechaJueves.Text = Convert.ToString(dia4.ToShortDateString());
            ////    FechaViernes.Text = Convert.ToString(dia5.ToShortDateString());
            ////    FechaSabado.Text = Convert.ToString(dia6.ToShortDateString());
            ////    //DtpFecha.Value = DtpFecha.Value.AddDays(int.Parse(FechaDomingo.Text)+6);
            ////    FechaDomingo.Text = Convert.ToString(dia7.ToShortDateString());

            ////}

        }

       
        private void cbDias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDias.CheckBoxItems[0].Checked)
            {
                cbDias.CheckBoxItems[1].Checked = true;
                cbDias.CheckBoxItems[2].Checked = true;
                cbDias.CheckBoxItems[3].Checked = true;
                cbDias.CheckBoxItems[4].Checked = true;
                cbDias.CheckBoxItems[5].Checked = true;
                cbDias.CheckBoxItems[6].Checked = true;
                cbDias.CheckBoxItems[7].Checked = true;
            }
            else
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

        private void LlamarDiasDeLaSemana(List<MenuSemanal> receta)
        {
    

        }
        }
    }
