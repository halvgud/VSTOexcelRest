using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Herramienta;
using Herramienta.Config;
using Respuesta;
using System.Windows.Forms;

namespace ExcelAddIn1
{
    public partial class Congelados : Form
    {
        public char KeyChar { get; set; }
        private List<Articulo.Basica> _listaArticuloBasica1;
        private List<Respuesta.CbGenerico> _listaplatillo; 
        public class Inputs
        {
            public TextBox Nombre;
            public DataGridView ListaCongelados;
        }



        private static Congelados _alreadyOpened;
        public Congelados(Func<string[]> arreglo)
        {
            if (_alreadyOpened != null && !_alreadyOpened.IsDisposed)
            {
                _alreadyOpened.Focus();            // Bring the old one to top
                Shown += (s, e) => Close();  // and destroy the new one.
                return;
            }
            _alreadyOpened = this;
            InitializeComponent();
            var allowedTypes = new AutoCompleteStringCollection();
            allowedTypes.AddRange(arreglo());
            txtbuscarcongelado.AutoCompleteCustomSource = allowedTypes;
            txtbuscarcongelado.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtbuscarcongelado.AutoCompleteSource = AutoCompleteSource.CustomSource;

            txtbuscarcongeladoeditar.AutoCompleteCustomSource = allowedTypes;
            txtbuscarcongeladoeditar.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtbuscarcongeladoeditar.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }
        public Congelados()
        {
            if (_alreadyOpened != null && !_alreadyOpened.IsDisposed)
            {
                _alreadyOpened.Focus();            // Bring the old one to top
                Shown += (s, e) => Close();  // and destroy the new one.

            }
        }

        private void txtbuscarcongelado_TextChanged(object sender, EventArgs e)
        {


        }
       

        private void txtbuscarcongelado_Enter(object sender, EventArgs e)
        {

            

        }


        private bool ValidarVacia()
        {
            return txtbuscarcongelado.Text.Trim().Length > 0;
        }

        private void txtbuscarcongelado_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarVacia();
      

            if (e.KeyChar == (char)Keys.Enter)
            {
              

            }

    }

        private void Congelados_Load(object sender, EventArgs e)
        {
            ActiveControl = txtbuscarcongelado;
            txtbuscarcongelado.Focus();
        }


        //private void BuscarCongelado(Action<Inputs> actualizarInputs, Inputs parametros)
        //{
        //    Cocina.Platillos.Listado = parametros.Nombre.Text.Trim();
        //    Opcion.EjecucionAsync(x =>
        //    {
        //        Data.Articulo.Lista(x, this);
        //    }, jsonResult =>
        //    {
        //                BeginInvoke((MethodInvoker) (() =>
        //                {
        //                    _listaArticuloBasica1 = parametros.ListaCongelados.DataSource as List<Articulo.Basica>;
        //                    if (_listaArticuloBasica1 != null)
        //                    {
        //                        _listaArticuloBasica1.AddRange(_listaArticuloBasica1);

        //                        parametros.ListaCongelados.DataSource = _listaArticuloBasica1
        //                            .GroupBy(p => p.ArtId)
        //                            .Select(g => new Articulo.Basica
        //                            {
        //                                ArtId = g.Key,
        //                                Clave = g.First().Clave,
        //                                Descripcion = g.First().Descripcion,
        //                                PrecioCompra = g.First().PrecioCompra,
        //                                Cantidad = g.Sum(i => i.Cantidad)
        //                            }).ToList();
        //                        for (var x = 0; x == 3; x++)
        //                        {
        //                            parametros.ListaCongelados.Columns[x].ReadOnly = true;
        //                            parametros.ListaCongelados.Columns[x].DefaultCellStyle.BackColor = Color.LightGray;
        //                        }
        //                        parametros.ListaCongelados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        //                        parametros.Nombre.Text = "";
        //                        parametros.Nombre.Focus();
        //                        actualizarInputs(parametros);
        //                    }
        //                }));
        //            });
        //    }

        private void btbuscareditar_Click(object sender, EventArgs e)
        {
            Cocina.buscarcongelados.descripcion = txtbuscarcongeladoeditar.Text == string.Empty ? "%" : txtbuscarcongeladoeditar.Text;  /* asigna la clave a la variable estatica*/
            Opcion.EjecucionAsync(Data.ReporteCocina.Buscarcongelados, jsonResult => /* se ejecuta Data.Receta.Lista, el resultado se guarda en jsonResult*/
            {
                BeginInvoke((MethodInvoker)(() =>
                {
                    switch (jsonResult.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            var brd = /*aqui que ondas */
                             new BuscarCongelados(Opcion.JsonaListaGenerica<Receta.Congelados>(jsonResult), /*esta parte no le entiendo*/
                                 resultado =>
                                 {
                                     BeginInvoke((MethodInvoker)(() => /*se manda llamar de nuevo a la interfaz*/
                                     {
                                         dgvcongeladobuscaryeditar.DataSource = resultado /*ni estas*/
                                          .ToList();
                                     }));
                                 });
                            brd.Show(); /*se muestra*/
                            break;
                        default:
                            MessageBox.Show(this, @"No se encontraron recetas con los parametros de busqueda ingresados");
                            Console.WriteLine(jsonResult.Content);
                            break;
                    }

                }));
            });
        }


        private void btguardareditar_Click(object sender, EventArgs e)
        {

        }

        private void btreportecongelado_Click(object sender, EventArgs e)
        {
            var addIn = Globals.ThisAddIn;

            Opcion.EjecucionAsync(Data.Reporte.RepCongelados, y =>
            {
                BeginInvoke((MethodInvoker)(() =>
                {
                    addIn.ReporteCongelados(y);
                }));
            });
        }

        private void txtbuscarcongelado_KeyDown(object sender, KeyEventArgs e)
        {
            //var d = Opcion.JsonaListaGenerica<CbGenerico>(json).Select(x => x.Nombre).ToArray();
            if (e.KeyCode == Keys.Enter)
            {
           
                //Cocina.buscarcongelados.descripcion = (txtbuscarcongelado.Text);
                //Opcion.EjecucionAsync(Data.Reporte.Listaplatillos, jsonResult =>
                //{
                //    if (!ValidarDescripcion(txtbuscarcongelado, jsonResult)) return;
                //});
                Agregar_Congelados frm = new Agregar_Congelados();
                frm.Show();
            }

        }

        //private bool ValidarDescripcion(TextBox claveReceta, IRestResponse jsonResult)
        //{
        //    if (jsonResult.StatusCode == HttpStatusCode.OK)
        //    {
        //        BeginInvoke((MethodInvoker)(() =>
        //        {
        //            MessageBox.Show(this, @"La Clave ingresada ya existe");
        //            //claveReceta.Text = "";
        //            //claveReceta.Focus();
        //            //btGuardar.Enabled = true;
        //        }));
        //        return false;
        //    }
        //    return true;
        //}
    }

    internal class Controls
    {
    }
}
