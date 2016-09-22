using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using testVSTO2.Prop;
using testVSTO2.Respuesta;
using RestSharp;

namespace testVSTO2
{
    public partial class AgregarReceta : Form
    {
        public AgregarReceta()
        {
            InitializeComponent();
            //Opcion.EjecucionAsync();
            Opcion.EjecucionAsync(Data.Receta.Tipo.Lista,CargarComboBox);
        }

        private List<Articulo.Basica> _listaArticuloBasica1;
        private List<Articulo.Basica> _listaArticuloBasica2;
         
        public void CargarComboBox(IRestResponse json)
        {
            BeginInvoke((MethodInvoker)(() =>
            {
                var bindingSource1 = new BindingSource
                {
                    DataSource = Opcion.JsonaListaGenerica<CbGenerico>(json)
                };
                cbTipoReceta.DataSource = bindingSource1;
                cbTipoReceta.DisplayMember = "nombre";
                cbTipoReceta.ValueMember = "id";
                cbTipoReceta.Tag = json;
                
            }
            )
        );
        }
        private void btBuscar_Click(object sender, EventArgs e)
        {
            Config.Local.Articulo.IdArticulo = tbCodigo.Text;
            _listaArticuloBasica1 = new List<Articulo.Basica>();
            Opcion.EjecucionAsync(Data.Articulo.Lista, jsonResult => {
                BeginInvoke((MethodInvoker)(() => {
                    var brd =
                     new BuscarArticulo(Opcion.JsonaListaGenerica<Articulo>(jsonResult), listaArticulo => {
                         _listaArticuloBasica1 = dgvIngredientes.DataSource as List<Articulo.Basica>;
                         _listaArticuloBasica2 = (listaArticulo.Select(x => x.CopiadoSencillo()).ToList());
                         if (_listaArticuloBasica1 != null)
                         {
                             _listaArticuloBasica2.AddRange(_listaArticuloBasica1);
                         }
                         var listaAgrupada = _listaArticuloBasica2
                                       .GroupBy(p => p.art_id)
                                       .Select(g => new Articulo.Basica()
                                                                           {
                                                                               art_id = g.Key,
                                                                               clave = g.First().clave,
                                                                               descripcion = g.First().descripcion,
                                                                               precioCompra = g.First().precioCompra,
                                                                               cantidad = g.Sum(i => i.cantidad)
                                                                           })
                                                                            .ToList();
                         dgvIngredientes.DataSource = listaAgrupada;
                         tbCodigo.Text = "";
                         tbCodigo.Focus();
                         ActualizarInputs();
                     });
                    brd.Show();
                }));
            });
        }
        double _sum;
        private void ActualizarInputs()
        {
            _sum = 0;
            for (var i = 0; i < dgvIngredientes.Rows.Count; ++i)
            {
                var costo1 = Convert.ToDouble(dgvIngredientes.Rows[i].Cells[3].Value);
                var cantidad1 = Convert.ToDouble(dgvIngredientes.Rows[i].Cells[4].Value);
                _sum += (costo1 * cantidad1);
            }
            tbCostoEstimado.Text = _sum.ToString(CultureInfo.InvariantCulture);
            ActualizarMargen();
            var costo = (_sum) + (tbCostoElaboracion.Text != string.Empty ? Convert.ToDouble(tbCostoElaboracion.Text) : 0);
            double margen = 1-Convert.ToDouble(tbMargenSugerido.Text);
            tbPrecioSugerido.Text = (Math.Round((costo / margen), 2)).ToString(CultureInfo.InvariantCulture);

        }

        private void ActualizarMargen()
        {
            if (cbTipoReceta.Items.Count > 0)
            {
                var lista = Opcion.JsonaListaGenerica<CbGenerico>((IRestResponse)cbTipoReceta.Tag);
                tbMargenSugerido.Text = lista[cbTipoReceta.SelectedIndex].Margen;
            }
        }
        private void tbCostoElaboracion_TextChanged(object sender, EventArgs e)
        {
            ActualizarInputs();
        }

        private void tbMargenConPrecio_TextChanged(object sender, EventArgs e)
        {
            if (!tbPrecio.Focused)
            {
                _sum = 0;
                for (var i = 0; i < dgvIngredientes.Rows.Count; ++i)
                {
                    var costo = Convert.ToDouble(dgvIngredientes.Rows[i].Cells[3].Value);
                    var cantidad = Convert.ToDouble(dgvIngredientes.Rows[i].Cells[4].Value);
                    _sum += (costo * cantidad);
                }
                if (tbMargenConPrecio.Text != string.Empty)
                {
                    tbPrecio.Text = (Math.Round(
                     (
                      (_sum) + (tbCostoElaboracion.Text != string.Empty ? Convert.ToDouble(tbCostoElaboracion.Text) : 0)
                     ) /
                     (
                      1 - (Convert.ToDouble(tbMargenConPrecio.Text) / 100)
                     ), 2)).ToString(CultureInfo.InvariantCulture);
                }
            }
        }

        private void tbPrecio_TextChanged(object sender, EventArgs e)
        {
            if (!tbMargenConPrecio.Focused)
            {
                _sum = 0;
                for (var i = 0; i < dgvIngredientes.Rows.Count; ++i)
                {
                    var costo1 = Convert.ToDouble(dgvIngredientes.Rows[i].Cells[3].Value);
                    var cantidad1 = Convert.ToDouble(dgvIngredientes.Rows[i].Cells[4].Value);
                    _sum += (costo1 * cantidad1);
                }
                var costo = _sum + (tbCostoElaboracion.Text != string.Empty ? Convert.ToDouble(tbCostoElaboracion.Text) : 0);
                if (tbPrecio.Text != string.Empty)
                {
                    var precio = Convert.ToDouble(tbPrecio.Text);

                    tbMargenConPrecio.Text = Math.Round(((1 - (costo / precio)) * 100), 2).ToString(CultureInfo.InvariantCulture);
                }
            }
        }

        private void tbCostoElaboracion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) ||
             char.IsSymbol(e.KeyChar) ||
             char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void btBorrarSeleccion_Click(object sender, EventArgs e)
        {
            if(dgvIngredientes.CurrentCell.RowIndex!=-1 && dgvIngredientes.Rows.Count > 0)
            { 
                var result = dgvIngredientes.DataSource as List<Articulo.Basica>;
                if (result != null)
                {
                    result.RemoveAt(dgvIngredientes.CurrentCell.RowIndex);
                    dgvIngredientes.DataSource = null;
                    dgvIngredientes.Refresh();
                    dgvIngredientes.DataSource = result;
                }
            }
        }

        private void btBorrarLista_Click(object sender, EventArgs e)
        {
            dgvIngredientes.DataSource = null;
            dgvIngredientes.Refresh();  
        }

        private void btGuardar_Click(object sender, EventArgs e)
        {
            MensajeDeEspera mde = new MensajeDeEspera();
            mde.Show();
            Receta receta = new Receta
            {
                clave = tbClaveReceta.Text,
                costoCreacion = double.Parse(tbCostoEstimado.Text),
                descripcion = tbDescripcion.Text,
                fechaModificacion = DateTime.Today,
                margen = double.Parse(tbMargenConPrecio.Text),
                pesoLitro = Convert.ToDouble(tbPesoLitro.Text),
                precio = double.Parse(tbPrecio.Text),
                rec_id = 0
            };
            
            Data.Receta.CReceta = receta;
            Opcion.EjecucionAsync(Data.Receta.Insertar, x =>
            {
                var listRecetaDetalle = new List<Receta.Detalle>();
                for (var i = 0; i < dgvIngredientes.Rows.Count; i++)
                {
                    var artId = dgvIngredientes.Rows[i].Cells[0].Value.ToString();
                    var cantidad = double.Parse(dgvIngredientes.Rows[i].Cells[4].Value.ToString());
                    var clave = dgvIngredientes.Rows[i].Cells[1].Value.ToString();
                    var descripcion = dgvIngredientes.Rows[i].Cells[2].Value.ToString();
                    var precioCompra = Convert.ToDouble(dgvIngredientes.Rows[i].Cells[3].Value);
                    var precioTotal = precioCompra * cantidad;
                    var recetaDetalle = new Receta.Detalle
                    {
                        rec_id = Data.Receta.CReceta.rec_id,
                        art_id = artId,
                        cantidad = cantidad,
                        clave = clave,
                        descripcion = descripcion,
                        idUnidad = 1,
                        precioCompra = precioCompra,
                        precioTotal = precioTotal
                    };
                    listRecetaDetalle.Add(recetaDetalle);
                }
                Data.Receta.Detalle.CRecetaDetalle = listRecetaDetalle;
                Data.Receta.Detalle.Insertar(x);
            },resultadoDeAmbos=>
            {
                BeginInvoke((MethodInvoker) (() => {
                                                       mde.Close();
                }));
            });

        }

        private void cbTipoReceta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTipoReceta.SelectedIndex != -1 && dgvIngredientes.Rows.Count > 0)
            {
                ActualizarMargen();
                ActualizarInputs();
            }
                     
        }
    }
}