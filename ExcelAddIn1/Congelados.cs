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

namespace ExcelAddIn1
{
    public partial class Congelados : Form
    {
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

            //Local.Receta.clave = txtbuscarcongelado.Text == string.Empty ? "%" : txtbuscarcongelado.Text;  /* asigna la clave a la variable estatica*/
            //Opcion.EjecucionAsync(Data.Receta.Lista, jsonResult => /* se ejecuta Data.Receta.Lista, el resultado se guarda en jsonResult*/
            //{
            //    BeginInvoke((MethodInvoker)(() =>  /*se manda llamar al hilo de la UI*/
            //    {
            //        switch (jsonResult.StatusCode) /*se determina cual fue el resultado*/
            //        {
            //            case HttpStatusCode.OK: /*si el resultado es oK*/
            //                var brd = /*se crea el constructor que recibe por parametro una Lista del tipo "Receta" */
            //                 new BusquedaRecetaDetalle(Opcion.JsonaListaGenerica<Receta>(jsonResult), /*Que es la parte de Opcion.jsonaListaGenerica<Receta>*/
            //                     resultado => /*tiene un callback el constructor, se le declara como resultado=>*/
            //                     {
            //                         BeginInvoke((MethodInvoker)(() => /*se manda llamar de nuevo a la interfaz*/
            //                         {
            //                             dgvcongelados.DataSource = resultado.Ingredientes /*para actualizar el datagridview*/
            //                             .Select(x => new Articulo.Basica  /*de la tabla se seleccionan ciertos valores */
            //                             {pero directamente
            //                                 ArtId = x.ArtId,
            //                                 Clave = x.Clave,
            //                                 Descripcion = x.Descripcion,
            //                                 PrecioCompra = x.PrecioCompra,
            //                                 Cantidad = x.Cantidad
            //                             }).ToList();
            //                             tbPrecioBE.Text = resultado.Precio.ToString(CultureInfo.InvariantCulture); /*se asignan los valores a los textbox,*/
            //                             tbDescripcionBE.Text = resultado.Descripcion;
            //                             tbPesoLitroBE.Text = resultado.PesoLitro.ToString(CultureInfo.InvariantCulture);
            //                             tbMargenConPrecioBE.Text = resultado.Margen.ToString(CultureInfo.InvariantCulture);
            //                             chDiarioBE.Checked = (resultado.Diario == 1);
            //                             tbCodigoBE.Enabled = true; tbCostoElaboracionBE.Text =
            //                                  resultado.CostoElaboracion.ToString(CultureInfo.InvariantCulture);
            //                             btBuscarBE.Enabled = true;
            //                         }));
            //                     }, false);
            //                brd.Show(); /*se muestra*/
            //                break;
            //            default:
            //                MessageBox.Show(this, @"No se encontraron recetas con los parametros de busqueda ingresados");
            //                Console.WriteLine(jsonResult.Content);
            //                break;
            //        }

            //    }));
            //});

        }


        private bool ValidarVacia()
        {
            return txtbuscarcongelado.Text.Trim().Length > 0;
        }

        private void txtbuscarcongelado_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btbuscareditar_Click(object sender, EventArgs e)
        {


            //          public BuscarArticulo(List<Articulo> listaArticulo, Action<List<Articulo>> callback)
            //{
            //    _listaArticulo = listaArticulo;
            //    _callback = callback;
            //    InitializeComponent();
            //    dgvListaArticulos.DataSource = _listaArticulo.Select(x => new { x.clave, x.descripcion, x.precioCompra }).ToArray();
            //    dgvListaArticulos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //}
            // BUSCAR ARTICULO
            //_listaArticulo = listaArticulo;
            //_callback = callback;
            //InitializeComponent();
            //dgvListaArticulos.DataSource = _listaArticulo.Select(x => new { x.clave, x.descripcion, x.precioCompra }).ToArray();
            //dgvListaArticulos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            /**
             aqui en lugar de lo que tienes abajo vas a poner esto*/

            Cocina.buscarcongelados.descripcion = txtbuscarcongeladoeditar.Text == string.Empty ? "%" : txtbuscarcongeladoeditar.Text;
          
                Opcion.EjecucionAsync(Data.ReporteCocina.Buscarcongelados, jsonResult => 
                {
                    BeginInvoke((MethodInvoker)(() => 
                    {
                        var brd = new BuscarArticulo(Opcion.JsonaListaGenerica<Articulo>(jsonResult), listaArticulo =>
                          {
                              BeginInvoke((MethodInvoker)(() =>
                             {
                                 dgvcongeladobuscaryeditar.DataSource = Receta.Congelados2.ToList();
                                 //_listaArticuloBasica1 = parametros.Ingredientes.DataSource as List<Articulo.Basica>;
                                 //_listaArticuloBasica2 = (listaArticulo.Select(x => x.CopiadoSencillo()).ToList());
                                 //if (_listaArticuloBasica1 != null)
                                 //{
                                 //    _listaArticuloBasica2.AddRange(_listaArticuloBasica1);
                                 //}
                                 //parametros.Ingredientes.DataSource = _listaArticuloBasica2
                                 //        .GroupBy(p => p.ArtId)
                                 //        .Select(g => new Articulo.Basica
                                 //        {
                                 //            ArtId = g.Key,
                                 //            Clave = g.First().Clave,
                                 //            Descripcion = g.First().Descripcion,
                                 //            PrecioCompra = g.First().PrecioCompra,
                                 //            Cantidad = g.Sum(i => i.Cantidad)
                                 //        }).ToList();
                                 //for (var x = 0; x == 3; x++)
                                 //{
                                 //    parametros.Ingredientes.Columns[x].ReadOnly = true;
                                 //    parametros.Ingredientes.Columns[x].DefaultCellStyle.BackColor = Color.LightGray;
                                 //}
                                 //parametros.Ingredientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                                 //parametros.ClaveReceta.Text = "";
                                 //parametros.ClaveReceta.Focus();
                                 //actualizarInputs(parametros);
                             }));
                          });
                        brd.Show();
                    }));
                });
            /*luego lo simplificamos...
                 
                 */

            //Cocina.buscarcongelados.descripcion = txtbuscarcongeladoeditar.Text == string.Empty ? "%" : txtbuscarcongeladoeditar.Text;  /* asigna la clave a la variable estatica*/
            //Opcion.EjecucionAsync(Data.ReporteCocina.Buscarcongelados, jsonResult => /* se ejecuta Data.Receta.Lista, el resultado se guarda en jsonResult*/
            //{
            //    BeginInvoke((MethodInvoker)(() =>  
            //    {
            //        switch (jsonResult.StatusCode) 
            //        {
            //            case HttpStatusCode.OK: 
            //                var brd = /*aqui que ondas */
            //                 new BuscarArticulo(Opcion.JsonaListaGenerica<Receta.Congelados>(jsonResult), /*esta parte no le entiendo*/
            //                     resultado =>
            //                     {
            //                         BeginInvoke((MethodInvoker)(() => /*se manda llamar de nuevo a la interfaz*/
            //                         {
            //                             dgvcongelados.DataSource = resultado.ListaCongelados /*ni estas*/
            //                              .ToList();
            //                             //tbPrecioBE.Text = resultado.Precio.ToString(CultureInfo.InvariantCulture); /*se asignan los valores a los textbox,*/
            //                             //tbDescripcionBE.Text = resultado.Descripcion;
            //                             //tbPesoLitroBE.Text = resultado.PesoLitro.ToString(CultureInfo.InvariantCulture);
            //                             //tbMargenConPrecioBE.Text = resultado.Margen.ToString(CultureInfo.InvariantCulture);
            //                             //chDiarioBE.Checked = (resultado.Diario == 1);
            //                             //tbCodigoBE.Enabled = true; tbCostoElaboracionBE.Text =
            //                             //     resultado.CostoElaboracion.ToString(CultureInfo.InvariantCulture);
            //                             //btBuscarBE.Enabled = true;
            //                         }));
            //                     }, true);
            //                brd.Show(); /*se muestra*/
            //                break;
            //            default:
            //                MessageBox.Show(this, @"No se encontraron recetas con los parametros de busqueda ingresados");
            //                Console.WriteLine(jsonResult.Content);
            //                break;
            //        }

            //    }));
            //});
        }
    }
}
