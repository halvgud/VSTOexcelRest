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
using System.Net;



namespace ExcelAddIn1
{
    public partial class MenuSemanal : Form
    {
        //private readonly List<Respuesta.Receta.MenuSemana> _listaMenuSemanas;
        //private readonly Action<List<Respuesta.Receta.MenuSemana>> _callback;
        //private List<Receta> _listaRecetas;

        public class Inputs
        {
            public CheckBoxComboBox DiasSemana;

        }
  
        private List<Receta.Semana> _semanas; 
        public MenuSemanal(/*List<Respuesta.Receta.MenuSemana> listaMenuSemanas, Action<List<Respuesta.Receta.MenuSemana>> callback*/)
        {
            //_listaMenuSemanas = listaMenuSemanas;
            //_callback = callback;
            InitializeComponent();
            //dgvLunes.DataSource = _listaMenuSemanas.ToArray();
            //dgvLunes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dgvMartes.DataSource = _listaMenuSemanas.ToArray();
            //dgvMartes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dgvMiercoles.DataSource = _listaMenuSemanas.ToArray();
            //dgvMiercoles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dgvJueves.DataSource = _listaMenuSemanas.ToArray();
            //dgvJueves.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dgvViernes.DataSource = _listaMenuSemanas.ToArray();
            //dgvViernes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dgvSabado.DataSource = _listaMenuSemanas.ToArray();
            //dgvSabado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dgvDomingo.DataSource = _listaMenuSemanas.ToArray();
            //dgvDomingo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _semanas = new List<Receta.Semana>();
         

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

        //public void VerSemana()
        //{
        //    Cocina.DiasSemana.DiaLunes = (DtpFecha.Text);
        //    Opcion.EjecucionAsync(Data.Receta.Lista, jsonResult =>
        //    {
        //        BeginInvoke((MethodInvoker)(() =>
        //        {
        //            switch (jsonResult.StatusCode)
        //            {
        //                case HttpStatusCode.OK:
        //                    _listaRecetas = Opcion.JsonaListaGenerica<Receta>(jsonResult);
        //                    dgvLunes.DataSource = _listaRecetas.Select(x => new { x.Clave, x.Descripcion, x.Precio }).ToArray();
        //                    dgvLunes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        //                    for (var x = 0; x < 3; x++)
        //                    {
        //                        dgvLunes.Columns[x].ReadOnly = true;
        //                        dgvLunes.Columns[x].DefaultCellStyle.BackColor = Color.LightGray;
        //                    }
        //                    break;
        //                default:
        //                    MessageBox.Show(this, @"No se encontraron recetas con los parametros de busqueda ingresados");
        //                    break;
        //            }
        //        }));
        //    });
        //}
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
            var i = Weekday(DateTime.Now, DayOfWeek.Monday);
            //DtpFecha.Value = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + 1);     
        }
        private void DtpFecha_ValueChanged(object sender, EventArgs e)
        {
            //DateTime dt = DateTime.Now.StartOfWeek(DayOfWeek.Monday);
 
            var date = new DateTime(Convert.ToInt16(DtpFecha.Value.ToString("yyyy")), Convert.ToInt16(DtpFecha.Value.ToString("MM")), Convert.ToInt16(DtpFecha.Value.ToString("dd")));
            //string[] days = {"Monday", "Tuesday","Wednesday", "Thursday", "Friday", "Saturday", "Sunday"};
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
                DateTime dia2 = Convert.ToDateTime(DtpFecha.Value.ToShortDateString());
                dia2 = dia2.AddDays(1);
                DateTime dia3 = Convert.ToDateTime(DtpFecha.Value.ToShortDateString());
                dia3 = dia3.AddDays(2);
                DateTime dia4 = Convert.ToDateTime(DtpFecha.Value.ToShortDateString());
                dia4 = dia4.AddDays(3);
                DateTime dia5 = Convert.ToDateTime(DtpFecha.Value.ToShortDateString());
                dia5 = dia5.AddDays(4);
                DateTime dia6 = Convert.ToDateTime(DtpFecha.Value.ToShortDateString());
                dia6 = dia6.AddDays(5);
                DateTime dia7 = Convert.ToDateTime(DtpFecha.Value.ToShortDateString());
                dia7 = dia7.AddDays(6);
                FechaLunes.Text = Convert.ToString(DtpFecha.Value.ToShortDateString());
                FechaMartes.Text = Convert.ToString(dia2.ToShortDateString());
                FechaMiercoles.Text = Convert.ToString(dia3.ToShortDateString());
                FechaJueves.Text = Convert.ToString(dia4.ToShortDateString());
                FechaViernes.Text = Convert.ToString(dia5.ToShortDateString());
                FechaSabado.Text = Convert.ToString(dia6.ToShortDateString());
                //DtpFecha.Value = DtpFecha.Value.AddDays(int.Parse(FechaDomingo.Text)+6);
                FechaDomingo.Text = Convert.ToString(dia7.ToShortDateString());

            }
            //martes
            if (ma == date.DayOfWeek.ToString())
            {
                DateTime dia1 = Convert.ToDateTime(DtpFecha.Value.ToShortDateString());
                dia1 = dia1.AddDays(-1);
                DateTime dia3 = Convert.ToDateTime(DtpFecha.Value.ToShortDateString());
                dia3 = dia3.AddDays(1);
                DateTime dia4 = Convert.ToDateTime(DtpFecha.Value.ToShortDateString());
                dia4 = dia4.AddDays(2);
                DateTime dia5 = Convert.ToDateTime(DtpFecha.Value.ToShortDateString());
                dia5 = dia5.AddDays(3);
                DateTime dia6 = Convert.ToDateTime(DtpFecha.Value.ToShortDateString());
                dia6 = dia6.AddDays(4);
                DateTime dia7 = Convert.ToDateTime(DtpFecha.Value.ToShortDateString());
                dia7 = dia7.AddDays(5);
                FechaLunes.Text = Convert.ToString(dia1.ToShortDateString());
                FechaMartes.Text = Convert.ToString(DtpFecha.Value.ToShortDateString());
                FechaMiercoles.Text = Convert.ToString(dia3.ToShortDateString());
                FechaJueves.Text = Convert.ToString(dia4.ToShortDateString());
                FechaViernes.Text = Convert.ToString(dia5.ToShortDateString());
                FechaSabado.Text = Convert.ToString(dia6.ToShortDateString());
                FechaDomingo.Text = Convert.ToString(dia7.ToShortDateString());
            }
            //miercoles
            if (mi == date.DayOfWeek.ToString())
            {
                DateTime dia1 = Convert.ToDateTime(DtpFecha.Value.ToShortDateString());
                dia1 = dia1.AddDays(-2);
                DateTime dia2 = Convert.ToDateTime(DtpFecha.Value.ToShortDateString());
                dia2 = dia2.AddDays(-1);
                DateTime dia4 = Convert.ToDateTime(DtpFecha.Value.ToShortDateString());
                dia4 = dia4.AddDays(1);
                DateTime dia5 = Convert.ToDateTime(DtpFecha.Value.ToShortDateString());
                dia5 = dia5.AddDays(2);
                DateTime dia6 = Convert.ToDateTime(DtpFecha.Value.ToShortDateString());
                dia6 = dia6.AddDays(3);
                DateTime dia7 = Convert.ToDateTime(DtpFecha.Value.ToShortDateString());
                dia7 = dia7.AddDays(4);
                FechaLunes.Text = Convert.ToString(dia1.ToShortDateString());
                FechaMartes.Text = Convert.ToString(dia2.ToShortDateString());
                FechaMiercoles.Text = Convert.ToString(DtpFecha.Value.ToShortDateString());
                FechaJueves.Text = Convert.ToString(dia4.ToShortDateString());
                FechaViernes.Text = Convert.ToString(dia5.ToShortDateString());
                FechaSabado.Text = Convert.ToString(dia6.ToShortDateString());
                FechaDomingo.Text = Convert.ToString(dia7.ToShortDateString());
            }
            //jueves
            if (ju == date.DayOfWeek.ToString())
            {
                DateTime dia1 = Convert.ToDateTime(DtpFecha.Value.ToShortDateString());
                dia1 = dia1.AddDays(-3);
                DateTime dia2 = Convert.ToDateTime(DtpFecha.Value.ToShortDateString());
                dia2 = dia2.AddDays(-2);
                DateTime dia3 = Convert.ToDateTime(DtpFecha.Value.ToShortDateString());
                dia3 = dia3.AddDays(-1);
                DateTime dia5 = Convert.ToDateTime(DtpFecha.Value.ToShortDateString());
                dia5 = dia5.AddDays(1);
                DateTime dia6 = Convert.ToDateTime(DtpFecha.Value.ToShortDateString());
                dia6 = dia6.AddDays(2);
                DateTime dia7 = Convert.ToDateTime(DtpFecha.Value.ToShortDateString());
                dia7 = dia7.AddDays(3);
                FechaLunes.Text = Convert.ToString(dia1.ToShortDateString());
                FechaMartes.Text = Convert.ToString(dia2.ToShortDateString());
                FechaMiercoles.Text = Convert.ToString(dia3.ToShortDateString());
                FechaJueves.Text = Convert.ToString(DtpFecha.Value.ToShortDateString());
                FechaViernes.Text = Convert.ToString(dia5.ToShortDateString());
                FechaSabado.Text = Convert.ToString(dia6.ToShortDateString());
                FechaDomingo.Text = Convert.ToString(dia7.ToShortDateString());
            }
            //viernes
            if (vi == date.DayOfWeek.ToString())
            {
                DateTime dia1 = Convert.ToDateTime(DtpFecha.Value.ToShortDateString());
                dia1 = dia1.AddDays(-4);
                DateTime dia2 = Convert.ToDateTime(DtpFecha.Value.ToShortDateString());
                dia2 = dia2.AddDays(-3);
                DateTime dia3 = Convert.ToDateTime(DtpFecha.Value.ToShortDateString());
                dia3 = dia3.AddDays(-2);
                DateTime dia4 = Convert.ToDateTime(DtpFecha.Value.ToShortDateString());
                dia4 = dia4.AddDays(-1);
                DateTime dia6 = Convert.ToDateTime(DtpFecha.Value.ToShortDateString());
                dia6 = dia6.AddDays(1);
                DateTime dia7 = Convert.ToDateTime(DtpFecha.Value.ToShortDateString());
                dia7 = dia7.AddDays(2);
                FechaLunes.Text = Convert.ToString(dia1.ToShortDateString());
                FechaMartes.Text = Convert.ToString(dia2.ToShortDateString());
                FechaMiercoles.Text = Convert.ToString(dia3.ToShortDateString());
                FechaJueves.Text = Convert.ToString(dia4.ToShortDateString());
                FechaViernes.Text = Convert.ToString(DtpFecha.Value.ToShortDateString());
                FechaSabado.Text = Convert.ToString(dia6.ToShortDateString());
                FechaDomingo.Text = Convert.ToString(dia7.ToShortDateString());
            }
            //sabado
            if (sa == date.DayOfWeek.ToString())
            {
                DateTime dia1 = Convert.ToDateTime(DtpFecha.Value.ToShortDateString());
                dia1 = dia1.AddDays(-5);
                DateTime dia2 = Convert.ToDateTime(DtpFecha.Value.ToShortDateString());
                dia2 = dia2.AddDays(-4);
                DateTime dia3 = Convert.ToDateTime(DtpFecha.Value.ToShortDateString());
                dia3 = dia3.AddDays(-3);
                DateTime dia4 = Convert.ToDateTime(DtpFecha.Value.ToShortDateString());
                dia4= dia4.AddDays(-2);
                DateTime dia5 = Convert.ToDateTime(DtpFecha.Value.ToShortDateString());
                dia5 = dia5.AddDays(-1);
                DateTime dia7 = Convert.ToDateTime(DtpFecha.Value.ToShortDateString());
                dia7 = dia7.AddDays(1);
                FechaLunes.Text = Convert.ToString(dia1.ToShortDateString());
                FechaMartes.Text = Convert.ToString(dia2.ToShortDateString());
                FechaMiercoles.Text = Convert.ToString(dia3.ToShortDateString());
                FechaJueves.Text = Convert.ToString(dia4.ToShortDateString());
                FechaViernes.Text = Convert.ToString(dia5.ToShortDateString());
                FechaSabado.Text = Convert.ToString(DtpFecha.Value.ToShortDateString());
                FechaDomingo.Text = Convert.ToString(dia7.ToShortDateString());
            }
                //domingo
            if (dom == date.DayOfWeek.ToString())
            {
                DateTime dia1 = Convert.ToDateTime(DtpFecha.Value.ToShortDateString());
                dia1 = dia1.AddDays(-6);
                DateTime dia2 = Convert.ToDateTime(DtpFecha.Value.ToShortDateString());
                dia2 = dia2.AddDays(-5);
                DateTime dia3 = Convert.ToDateTime(DtpFecha.Value.ToShortDateString());
                dia3 = dia3.AddDays(-4);
                DateTime dia4 = Convert.ToDateTime(DtpFecha.Value.ToShortDateString());
                dia4 = dia4.AddDays(-3);
                DateTime dia5 = Convert.ToDateTime(DtpFecha.Value.ToShortDateString());
                dia5 = dia5.AddDays(-2);
                DateTime dia6 = Convert.ToDateTime(DtpFecha.Value.ToShortDateString());
                dia6 = dia6.AddDays(-1);
                FechaLunes.Text = Convert.ToString(dia1.ToShortDateString());
                FechaMartes.Text = Convert.ToString(dia2.ToShortDateString());
                FechaMiercoles.Text = Convert.ToString(dia3.ToShortDateString());
                FechaJueves.Text = Convert.ToString(dia4.ToShortDateString());
                FechaViernes.Text = Convert.ToString(dia5.ToShortDateString());
                FechaSabado.Text = Convert.ToString(dia6.ToShortDateString());
                FechaDomingo.Text = Convert.ToString(DtpFecha.Value.ToShortDateString());
                }
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

        private void LlamarDiasDeLaSemana(List<Receta.Semana> receta)
        {
            _semanas.AddRange(receta);
            _semanas = _semanas.Select(g => new Receta.Semana
            { 
                Lunes= g.Lunes,
                Martes = g.Martes,
                Miercoles = g.Miercoles,
                Jueves = g.Jueves,
                Viernes = g.Viernes,
                Sabado = g.Sabado,
                Domingo = g.Domingo
                 
            }).ToList();     
            }
        private static int Weekday(DateTime date, DayOfWeek startDay)
        {
            int diff;
            DayOfWeek dow = date.DayOfWeek;
            diff = dow - startDay;
            if (diff < 0)
            {
                diff += 7;
            }
            return diff;
        }

        //public static class DateTimeExtensions
        //{
        //    public static DateTime StartOfWeek( DateTime dt, DayOfWeek startOfWeek)
        //    {
        //        int diff = dt.DayOfWeek - startOfWeek;
        //        if (diff < 0)
        //        {
        //            diff += 7;
        //        }
        //        return dt.AddDays(-1 * diff).Date;
        //    }
        //}

        private void btAgregarSemana_Click(object sender, EventArgs e)
        {

            //Cocina.DiasSemana.Fecha = DtpFecha.Text == string.Empty ? "%" : DtpFecha.Text;  /* asigna la clave a la variable estatica*/
            //Opcion.EjecucionAsync(Data.ReporteCocina.Buscarcongelados, jsonResult => /* se ejecuta Data.Receta.Lista, el resultado se guarda en jsonResult*/
            //{
            //    BeginInvoke((MethodInvoker)(() =>
            //    {
            //        switch (jsonResult.StatusCode)
            //        {
            //            case HttpStatusCode.OK:
            //                var brd = /*aqui que ondas */
            //                 new MenuSemanal(Opcion.JsonaListaGenerica<Receta.MenuSemana>(jsonResult), /*esta parte no le entiendo*/
            //                     resultado =>
            //                     {
            //                         BeginInvoke((MethodInvoker)(() => /*se manda llamar de nuevo a la interfaz*/
            //                         {
            //                             dgvLunes.DataSource = resultado;
            //                             dgvMartes.DataSource = resultado;
            //                             dgvMiercoles.DataSource = resultado;
            //                             dgvJueves.DataSource = resultado;
            //                             dgvViernes.DataSource = resultado;
            //                             dgvSabado.DataSource = resultado;
            //                             dgvDomingo.DataSource = resultado
            //                            /*ni estas*/
            //                              .ToList();
            //                         }));
            //                     });
            //                brd.Show(); /*se muestra*/
            //                break;
            //            default:
            //                MessageBox.Show(this, @"No se encontraron recetas con los parametros de busqueda ingresados");
            //                Console.WriteLine(jsonResult.Content);
            //                break;
            //        }

            //    }));
            //});



            //Cocina.DiasSemana.DiaLunes = (DtpFecha.Text);
            //Opcion.EjecucionAsync(Data.Receta.Lista, jsonResult =>
            //{
            //    BeginInvoke((MethodInvoker)(() =>
            //    {
            //        switch (jsonResult.StatusCode)
            //        {
            //            case HttpStatusCode.OK:
            //                _listaRecetas = Opcion.JsonaListaGenerica<Receta>(jsonResult);
            //                dgvLunes.DataSource = _listaRecetas.Select(x => new { x.Clave, x.Descripcion, x.Precio }).ToArray();
            //                dgvLunes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //                for (var x = 0; x < 3; x++)
            //                {
            //                    dgvLunes.Columns[x].ReadOnly = true;
            //                    dgvLunes.Columns[x].DefaultCellStyle.BackColor = Color.LightGray;
            //                }
            //                break;
            //            default:
            //                MessageBox.Show(this, @"No se encontraron recetas con los parametros de busqueda ingresados");
            //                break;
            //        }
            //    }));
            //});

        }
    }
    }
