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

          
            //if ( comboBox1.CheckBoxItems[0].Checked == true)
            //{

            //    comboBox1.CheckBoxItems[1].Checked = true;
            //    comboBox1.CheckBoxItems[2].Checked = true;
            //    comboBox1.CheckBoxItems[3].Checked = true;
            //    comboBox1.CheckBoxItems[4].Checked = true;
            //    comboBox1.CheckBoxItems[5].Checked = true;
            //    comboBox1.CheckBoxItems[6].Checked = true;
            //    comboBox1.CheckBoxItems[7].Checked = true;
            //}
            //else
            //{
            //    comboBox1.CheckBoxItems[1].Checked = false;
            //    comboBox1.CheckBoxItems[2].Checked = false;
            //    comboBox1.CheckBoxItems[3].Checked = false;
            //    comboBox1.CheckBoxItems[4].Checked = false;
            //    comboBox1.CheckBoxItems[5].Checked = false;
            //    comboBox1.CheckBoxItems[6].Checked = false;
            //    comboBox1.CheckBoxItems[7].Checked = false;

            //}

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

<<<<<<< HEAD
        private void Dtpikerinicio_ValueChanged(object sender, EventArgs e)
        {
            DateTime date = new DateTime(Convert.ToInt16(Dtpikerinicio.Value.ToString("yyyy")), Convert.ToInt16(Dtpikerinicio.Value.ToString("MM")), Convert.ToInt16(Dtpikerinicio.Value.ToString("dd")));
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
                FechaLunes.Text =Convert.ToString(Dtpikerinicio.Value.ToShortDateString());
            }
            //martes
            if (m == date.DayOfWeek.ToString())
            {
                FechaMartes.Text = Convert.ToString(Dtpikerinicio.Value.ToShortDateString());
            }
            //miercoles
            if (M == date.DayOfWeek.ToString())
            {
                FechaMiercoles.Text = Convert.ToString(Dtpikerinicio.Value.ToShortDateString());
            }
            //jueves
            if (j == date.DayOfWeek.ToString())
            {
                FechaJueves.Text = Convert.ToString(Dtpikerinicio.Value.ToShortDateString());
            }
            //viernes
            if (v == date.DayOfWeek.ToString())
            {
                FechaViernes.Text = Convert.ToString(Dtpikerinicio.Value.ToShortDateString());
            }
            //sabado
            if (s == date.DayOfWeek.ToString())
            {
                FechaSabado.Text = Convert.ToString(Dtpikerinicio.Value.ToShortDateString());
                //domingo
            if (d == date.DayOfWeek.ToString())
            {
                FechaDomingo.Text = Convert.ToString(Dtpikerinicio.Value.ToShortDateString());
            }
            }
            
        }
=======

>>>>>>> origin/master

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
        

<<<<<<< HEAD


        }
=======
        private void Dtpikerinicio_ValueChanged(object sender, EventArgs e)
        {
            MessageBox.Show("algo anda mal");
        }

        private void dtpsegundon_ValueChanged(object sender, EventArgs e)
        {
            MessageBox.Show("aver si sale");
        }

        //private void BuscarMenuSemanal(Action<Inputs> actualizarInputs, Inputs parametros)
        //{
        //    Local.Articulo.IdArticulo = parametros.ClaveReceta.Text.Trim();
        //    Opcion.EjecucionAsync(x =>
        //    {
        //        Data.Articulo.Lista(x, this);
        //    }, jsonResult =>
        //    {
        //        BeginInvoke((MethodInvoker)(() =>
        //        {
        //            var brd = new BuscarArticulo(Opcion.JsonaListaGenerica<Articulo>(jsonResult), listaArticulo =>
        //            {
        //                BeginInvoke((MethodInvoker)(() =>
        //                {
        //                    _listaArticuloBasica1 = parametros.Ingredientes.DataSource as List<Articulo.Basica>;
        //                    _listaArticuloBasica2 = (listaArticulo.Select(x => x.CopiadoSencillo()).ToList());
        //                    if (_listaArticuloBasica1 != null)
        //                    {
        //                        _listaArticuloBasica2.AddRange(_listaArticuloBasica1);
        //                    }
        //                    parametros.Ingredientes.DataSource = _listaArticuloBasica2
        //                            .GroupBy(p => p.ArtId)
        //                            .Select(g => new Articulo.Basica
        //                            {
        //                                ArtId = g.Key,
        //                                Clave = g.First().Clave,
        //                                Descripcion = g.First().Descripcion,
        //                                PrecioCompra = g.First().PrecioCompra,
        //                                Cantidad = g.Sum(i => i.Cantidad)
        //                            }).ToList();
        //                    for (var x = 0; x == 3; x++)
        //                    {
        //                        parametros.Ingredientes.Columns[x].ReadOnly = true;
        //                        parametros.Ingredientes.Columns[x].DefaultCellStyle.BackColor = Color.LightGray;
        //                    }
        //                    parametros.Ingredientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        //                    parametros.ClaveReceta.Text = "";
        //                    parametros.ClaveReceta.Focus();
        //                    actualizarInputs(parametros);
        //                }));
        //            });
        //            brd.Show();
        //        }));
        //    });
        //}
>>>>>>> origin/master
    }

}
