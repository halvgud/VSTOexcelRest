using System;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using Respuesta;
using RestSharp;
using Herramienta;


namespace ExcelAddIn1
{
    public partial class MenuSemanal : Form
    {
        public MenuSemanal()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");

            InitializeComponent();
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


        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
 
        }


        private void MenuSemanal_Load(object sender, EventArgs e)
        {
            dvgLunes.AutoResizeColumns();
            dvgMartes.AutoResizeColumns();
            dvgMiercoles.AutoResizeColumns();
            dvgJueves.AutoResizeColumns();
            dvgViernes.AutoResizeColumns();
            dvgSabado.AutoResizeColumns();
            dvgDomingo.AutoResizeColumns();

            dvgLunes.AutoGenerateColumns = false;
            dvgMartes.AutoGenerateColumns = false;
            dvgMiercoles.AutoGenerateColumns = false;
            dvgJueves.AutoGenerateColumns = false;
            dvgViernes.AutoGenerateColumns = false;
            dvgSabado.AutoGenerateColumns = false;
            dvgDomingo.AutoGenerateColumns = false;
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
    }
}
