using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using Respuesta;
using RestSharp;
using Herramienta;
using Herramienta.Config;
using System.Net;
using System.Windows.Forms;

namespace ExcelAddIn1
{
    public partial class AgregarReceta :Form
    {
        private List<Articulo.Basica> _listaArticuloBasica1;
        private List<Articulo.Basica> _listaArticuloBasica2;
        public class Inputs
        {

            public DataGridView Ingredientes;
            public TextBox ClaveReceta;
            public MaskedTextBox PesoLitro;
            public TextBox Descripcion;
            public MaskedTextBox CostoEstimado;
            public MaskedTextBox CostoElaboracion;
            public Action<MaskedTextBox> ActualizarMargen;
            public MaskedTextBox MargenSugerido;
            public MaskedTextBox MargenConPrecio;
            public MaskedTextBox PrecioSugerido;
            public MaskedTextBox Precio;
            public CheckBox Diario;
            public RichTextBox ModoElaboracion;
        }
        public AgregarReceta()
        {
            InitializeComponent();
            Opcion.EjecucionAsync(Data.Receta.Tipo.Lista, x =>
            {
                CargarComboBox(x, cbTipoReceta);
                CargarComboBox(x, cbTipoBE);
            });
        }
        private void tbClaveReceta_TextChanged(object sender, EventArgs e)
        {  btGuardar.Enabled = ValidarCampos();
            tsmGuardar.Enabled = ValidarCampos();
        }
        private void tbDescripcion_TextChanged(object sender, EventArgs e)
        {
            btGuardar.Enabled = ValidarCampos();
        }
        private void AgregarReceta_Load(object sender, EventArgs e)
        {
            ActiveControl = tbCodigo;
            tbCodigo.Focus();
        }
        private void rtbModoElaboracion_TextChanged(object sender, EventArgs e)
        {
            btGuardar.Enabled = ValidarCampos();
        }
        private void btBuscar_Click(object sender, EventArgs e)
        {
            BuscarReceta(ActualizarInputs, new Inputs
            {
                ClaveReceta = tbCodigo,
                ActualizarMargen = ActualizarMargen,
                CostoElaboracion = tbCostoElaboracion,
                CostoEstimado = tbCostoEstimado,
                Ingredientes = dgvIngredientes,
                MargenSugerido = tbMargenSugerido,
                PrecioSugerido = tbPrecioSugerido
            });
        }
        private void tbCostoElaboracion_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Opcion.ValidarCaracter(e);
        }
        private void tbCostoElaboracion_TextChanged(object sender, EventArgs e)
        {
            if (!Opcion.ValidarDouble(tbCostoElaboracion)) return;
            ActualizarInputs(new Inputs
            {
                ActualizarMargen = ActualizarMargen,
                CostoElaboracion = tbCostoElaboracion,
                CostoEstimado = tbCostoEstimado,
                Ingredientes = dgvIngredientes,
                MargenSugerido = tbMargenSugerido,
                PrecioSugerido = tbPrecioSugerido
            });
            btGuardar.Enabled = ValidarCampos();
            tsmGuardar.Enabled = ValidarCampos();
        }
        private void tbMargenConPrecio_TextChanged(object sender, EventArgs e)
        {
            if (!Opcion.ValidarDouble(tbMargenConPrecio)) return;
            ActualizarPrecio(new Inputs
            {
                Precio = tbPrecio,
                Ingredientes = dgvIngredientes,
                MargenConPrecio = tbMargenConPrecio,
                CostoElaboracion = tbCostoElaboracion
            });
            btGuardar.Enabled = ValidarCampos();
            tsmGuardar.Enabled = ValidarCampos();

        }
        private void tbMargenConPrecioBE_TextChanged(object sender, EventArgs e)
        {
            if (!Opcion.ValidarDouble(tbMargenConPrecioBE)) return;
            ActualizarPrecio(new Inputs
            {
                Precio = tbPrecioBE,
                Ingredientes = dgvIngredientesBusqueda,
                MargenConPrecio = tbMargenConPrecioBE,
                CostoElaboracion = tbCostoElaboracionBE
            });
        }

        private void btBorrarSeleccion_Click(object sender, EventArgs e)
        {
            Opcion.BorrarSeleccion(dgvIngredientes);
        }
        private void tbPrecio_TextChanged(object sender, EventArgs e)
        {
            if (!Opcion.ValidarDouble(tbPrecio)) return;
            ActualizarMargen(new Inputs
            {
                MargenConPrecio = tbMargenConPrecio,
                Ingredientes = dgvIngredientes,
                CostoElaboracion = tbCostoElaboracion,
                Precio = tbPrecio
            });
            btGuardar.Enabled = ValidarCampos();
            tsmGuardar.Enabled = ValidarCampos();
        }
        private void tbPrecioBE_TextChanged(object sender, EventArgs e)
        {
            if (!Opcion.ValidarDouble(tbPrecioBE)) return;
            ActualizarMargen(new Inputs
            {
                MargenConPrecio = tbMargenConPrecioBE,
                Ingredientes = dgvIngredientesBusqueda,
                CostoElaboracion = tbCostoElaboracionBE,
                Precio = tbPrecioBE
            });
        }


        private bool ValidarCampos()
        {
            return (tbClaveReceta.Text != string.Empty && tbDescripcion.Text != string.Empty
                    && tbPrecio.Text != string.Empty && tbMargenConPrecio.Text != string.Empty &&
                                 tbPesoLitro.Text != string.Empty && tbCostoEstimado.Text != string.Empty 
                                 && rtbModoElaboracion.Text != string.Empty);
        }
        
        private static void ActualizarInputs(Inputs inputs)
        {
            double sum = 0;
            for (var i = 0; i < inputs.Ingredientes.Rows.Count; ++i)
            {
                var costo1 = Convert.ToDouble(inputs.Ingredientes.Rows[i].Cells[3].Value);
                var cantidad1 = Convert.ToDouble(inputs.Ingredientes.Rows[i].Cells[4].Value);
                sum += (costo1*cantidad1);
            }
            inputs.CostoEstimado.Text = sum.ToString(CultureInfo.InvariantCulture);
            inputs.ActualizarMargen(inputs.MargenSugerido);                                                                            
            var costo = (sum) +
                        (inputs.CostoElaboracion.Text != string.Empty
                            ? Convert.ToDouble(inputs.CostoElaboracion.Text)
                            : 0);
            var margen = 1 - (Convert.ToDouble(inputs.MargenSugerido.Text)/100);
            inputs.PrecioSugerido.Text = (Math.Round((costo/margen), 2)).ToString(CultureInfo.InvariantCulture);    
        }
        private void ActualizarMargen(MaskedTextBox margenSugerido)
        {
            if (cbTipoReceta.Items.Count <= 0) return;
            var lista = Opcion.JsonaListaGenerica<CbGenerico>((IRestResponse)cbTipoReceta.Tag);
            margenSugerido.Text = lista[cbTipoReceta.SelectedIndex].Margen;
        }

        public void CargarComboBox(IRestResponse json,ComboBox tipoReceta)
        {
            BeginInvoke((MethodInvoker)(() =>
            {
                var bindingSource1 = new BindingSource
                {
                    DataSource = Opcion.JsonaListaGenerica<CbGenerico>(json)
                };
                tipoReceta.DataSource = bindingSource1;
                tipoReceta.DisplayMember = "nombre";
                tipoReceta.ValueMember = "id";
                tipoReceta.Tag = json;
            }));
        }

        private void BuscarReceta(Action<Inputs> actualizarInputs,Inputs parametros)
        {
            Local.Articulo.IdArticulo = parametros.ClaveReceta.Text.Trim();
            Opcion.EjecucionAsync(x =>
            {
                Data.Articulo.Lista(x, this);
            }, jsonResult => 
            {
                BeginInvoke((MethodInvoker)(() => 
                {
                    var brd = new BuscarArticulo(Opcion.JsonaListaGenerica<Articulo>(jsonResult), listaArticulo =>
                      {
                          BeginInvoke((MethodInvoker)(() =>
                         {
                             _listaArticuloBasica1 = parametros.Ingredientes.DataSource as List<Articulo.Basica>;
                             _listaArticuloBasica2 = (listaArticulo.Select(x => x.CopiadoSencillo()).ToList());
                             if (_listaArticuloBasica1 != null)
                             {
                                 _listaArticuloBasica2.AddRange(_listaArticuloBasica1);
                             }
                             parametros.Ingredientes.DataSource = _listaArticuloBasica2
                                     .GroupBy(p => p.ArtId)
                                     .Select(g => new Articulo.Basica
                                     {
                                         ArtId = g.Key,
                                         Clave = g.First().Clave,
                                         Descripcion = g.First().Descripcion,
                                         PrecioCompra = g.First().PrecioCompra,
                                         Cantidad = g.Sum(i => i.Cantidad)
                                     }).ToList();
                             for (var x = 0; x == 3; x++)
                             {
                                 parametros.Ingredientes.Columns[x].ReadOnly = true;
                                 parametros.Ingredientes.Columns[x].DefaultCellStyle.BackColor = Color.LightGray;
                             }
                             parametros.Ingredientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                             parametros.ClaveReceta.Text = "";
                             parametros.ClaveReceta.Focus();
                             actualizarInputs(parametros);
                         }));
                      });
                    brd.Show();
                }));
            });
        }

        /// <summary>
        /// Funcion que actualiza el Precio en base al margen
        /// </summary>
        /// <param name="inputs">Actualmente solo utiliza Precio,Ingredientes,MargenConPrecio,CostoElaboracion</param>
        private void ActualizarPrecio(Inputs inputs)
        {
            if (inputs.Precio.Focused) return;
            double sum = 0;
            for (var i = 0; i < inputs.Ingredientes.Rows.Count; ++i)
            {
                var costo = Convert.ToDouble(inputs.Ingredientes.Rows[i].Cells[3].Value);
                var cantidad = Convert.ToDouble(inputs.Ingredientes.Rows[i].Cells[4].Value);
                sum += (costo*cantidad);
            }
            if (tbMargenConPrecio.Text != string.Empty)
            {
                inputs.Precio.Text = (Math.Round(((sum) +
                                                    (inputs.CostoElaboracion.Text != string.Empty
                                                        ? Convert.ToDouble(inputs.CostoElaboracion.Text)
                                                        : 0))
                                                        /
                                                    (1 - (Convert.ToDouble(inputs.MargenConPrecio.Text)/100)), 2))
                    .ToString(CultureInfo.InvariantCulture);
            }
            ValidarBusquedaVacia();
        }

        private void ActualizarMargen(Inputs inputs)
        {
                if (inputs.MargenConPrecio.Focused) return;
                double sum = 0;
                for (var i = 0; i < inputs.Ingredientes.Rows.Count; ++i)
                {
                    var costo1 = Convert.ToDouble(inputs.Ingredientes.Rows[i].Cells[3].Value);
                    var cantidad1 = Convert.ToDouble(inputs.Ingredientes.Rows[i].Cells[4].Value);
                    sum += (costo1*cantidad1);
                }
                var costo = sum +(inputs.CostoElaboracion.Text != string.Empty
                                ? Convert.ToDouble(inputs.CostoElaboracion.Text)
                                : 0);
                if (inputs.Precio.Text == string.Empty) return;
                var precio = Convert.ToDouble(inputs.Precio.Text);
                inputs.MargenConPrecio.Text =
                    Math.Round(((1 - (costo/precio))*100), 2).ToString(CultureInfo.InvariantCulture);
            ValidarBusquedaVacia();
        }
        private void btBorrarLista_Click(object sender, EventArgs e)
        {
            Opcion.BorrarDataGridView(dgvIngredientes);
            ValidarBusquedaVacia();
        }

       private bool ValidarClave(TextBox claveReceta, IRestResponse jsonResult)
        {
            if (jsonResult.StatusCode == HttpStatusCode.OK)
            {
                BeginInvoke((MethodInvoker)(() =>
                {
                    MessageBox.Show(this, @"La Clave ingresada ya existe");
                    claveReceta.Text = "";
                    claveReceta.Focus();
                    btGuardar.Enabled = true;
                }));
                return false;
            }
            return true;
        }
        private void Guardar(Inputs inputs)
        {
     
        
            btGuardar.Enabled =false;
            Local.Receta.clave = (inputs.ClaveReceta.Text);
            if (ValidarCampos())
            {
                Opcion.EjecucionAsync(Data.Receta.Lista, jsonResult =>
                {
                    if (!ValidarClave(inputs.ClaveReceta, jsonResult)) return;
                    var mde = new MensajeDeEspera();
                    BeginInvoke((MethodInvoker)(() =>
                    {

         
                        mde.Show();
                        var receta = new Receta{
                            Clave = inputs.ClaveReceta.Text,
                            CostoCreacion = double.Parse(inputs.CostoEstimado.Text),
                            CostoElaboracion = double.Parse(inputs.CostoElaboracion.Text),
                            Descripcion = inputs.Descripcion.Text,
                            FechaModificacion = DateTime.Now,
                            Margen = double.Parse(inputs.MargenConPrecio.Text),
                            PesoLitro = Convert.ToDouble(inputs.PesoLitro.Text),
                            Precio = double.Parse(inputs.Precio.Text),
                            RecId = 0,
                            Diario = Convert.ToInt32(inputs.Diario.Checked),
                            ModoElaboracion = inputs.ModoElaboracion.Text
                            
                      };
                        if (MessageBox.Show(@"Desea agregar la imagen de la Receta", @"Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {

                            //aqui pones el beginInvoke porque estas en otro hilo
                            openFileDialog1.Filter = @"Image Files (*.png *.jpg *.bmp) | *.png; *.jpg; *.bmp | All Files(*.*) | *.* ";
                            openFileDialog1.Title = @"Buscar Imagen";
                            openFileDialog1.FileName = "";
                            openFileDialog1.ShowDialog();
                            long a = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
                            // string v = openFileDialog1.FileName;//=inputs.ClaveReceta.Text+a.ToString();
                            // MessageBox.Show(v);
                            //  openFileDialog1 open =new openFileDialog1();
                            //   open.Filter= "|*.jpg|*.bmp|*.png";
                            //SaveFileDialog guardarDialog = new SaveFileDialog();
                            //guardarDialog.Filter = "|*.jpg|*.bmp|*.png";
                            //guardarDialog.FileName = inputs.ClaveReceta.Text + Convert.ToDouble(DateTime.Now);

                            Opcion.Copycmdserver(openFileDialog1.FileName, @"\\mercattoserver\Recetario\img\" + inputs.ClaveReceta.Text + a.ToString() + ".jpg");
                            var ruta = new Receta.Imagen_and_Process
                            {
                                
                                instruccion = inputs.ModoElaboracion.Text,
                                ruta = @"\\mercattoserver\Recetario\img\" + inputs.ClaveReceta.Text + a.ToString() + ".jpg"
                            };
                        }


                        Data.Receta.CReceta = receta;
                        Opcion.EjecucionAsync(Data.Receta.Insertar, resultado =>
                        {
                        
                     
                            Guardado(resultado,inputs);
                        }, x =>
                        {
                            Limpiar(inputs, mde);
                        });
                       
                        
                    }));
                });}}

        private static void Guardado(Action<IRestResponse> x, Inputs inputs)
        {
            var listRecetaDetalle = new List<Receta.Detalle>();
            for (var i = 0; i < inputs.Ingredientes.Rows.Count; i++)
            {
                var cantidad = double.Parse(inputs.Ingredientes.Rows[i].Cells[4].Value.ToString());
                var precioCompra = Convert.ToDouble(inputs.Ingredientes.Rows[i].Cells[3].Value);
                var precioTotal = precioCompra * cantidad;
                listRecetaDetalle.Add(new Receta.Detalle
                {
                    RecId = Data.Receta.CReceta.RecId,
                    ArtId = Convert.ToInt32(inputs.Ingredientes.Rows[i].Cells[0].Value),
                    Cantidad = double.Parse(inputs.Ingredientes.Rows[i].Cells[4].Value.ToString()),
                    Clave = inputs.Ingredientes.Rows[i].Cells[1].Value.ToString(),
                    Descripcion = inputs.Ingredientes.Rows[i].Cells[2].Value.ToString(),
                    IdUnidad = 1,
                    PrecioCompra = Convert.ToDouble(inputs.Ingredientes.Rows[i].Cells[3].Value),
                    PrecioTotal = precioTotal
                });
            }
            Data.Receta.Detalle.CRecetaDetalle = listRecetaDetalle;
            Data.Receta.Detalle.Insertar(x);
             



        }
        private void Limpiar(Inputs inputs, MensajeDeEspera mde)
        {
            BeginInvoke((MethodInvoker)(() =>
            {
                mde?.Close();
                MessageBox.Show(this, @"Se a guardado con éxito  Clave :" + inputs.ClaveReceta.Text);
                inputs.ClaveReceta.Text = "";
                inputs.Precio.Text = "";
                inputs.PesoLitro.Text = "";
                inputs.Descripcion.Text = "";
                inputs.MargenConPrecio.Text = "";
                inputs.Ingredientes.DataSource = null;
                inputs.Ingredientes.Update();
                inputs.ModoElaboracion.Text = "";
                mde?.Close();
            }));
        }
         private void btGuardar_Click(object sender, EventArgs e) 
        {
            if (tabControl1.SelectedTab == tabControl1.TabPages[0])
                Guardar(new Inputs
                {
                    ClaveReceta = tbClaveReceta,
                    CostoElaboracion = tbCostoElaboracion,
                    CostoEstimado = tbCostoEstimado,
                    Descripcion = tbDescripcion,
                    Diario = chDiario,
                    Ingredientes = dgvIngredientes,
                    MargenConPrecio = tbMargenConPrecio,
                    MargenSugerido = tbMargenSugerido,
                    PesoLitro = tbPesoLitro,
                    Precio = tbPrecio,
                    ModoElaboracion = rtbModoElaboracion

                });
            else 
            {
                Guardar(new Inputs
                {
                    ClaveReceta = tbClaveReceta,
                    CostoElaboracion = tbCostoElaboracionBE,
                    CostoEstimado = tbCostoEstimadoBE,
                    Descripcion = tbDescripcionBE,
                    Diario = chDiarioBE,
                    Ingredientes = dgvIngredientesBusqueda,
                    MargenConPrecio = tbMargenConPrecioBE,
                    MargenSugerido = tbMargenSugeridoBE,
                    PesoLitro = tbPesoLitro,
                    Precio = tbPrecio,
                    ModoElaboracion = rtbModoElaboracionBE
                });

            }
        }
      
        /****************************************************************************/
        private void btBuscarClave_Click(object sender, EventArgs e)
        {
            Local.Receta.clave = tbBuscarReceta.Text == string.Empty ? "%" : tbBuscarReceta.Text;
Opcion.EjecucionAsync(Data.Receta.Lista, jsonResult =>
            {
                BeginInvoke((MethodInvoker)(() =>
                {
                    switch (jsonResult.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            var brd =
                             new BusquedaRecetaDetalle(Opcion.JsonaListaGenerica<Receta>(jsonResult),
                                 resultado =>
                                 {
                                     BeginInvoke((MethodInvoker)(() =>
                                     {
                                         dgvIngredientesBusqueda.DataSource = resultado.Ingredientes
                                         .Select(x => new Articulo.Basica
                                         {
                                             ArtId = x.ArtId,
                                             Clave = x.Clave,
                                             Descripcion = x.Descripcion,
                                             PrecioCompra = x.PrecioCompra,
                                             Cantidad = x.Cantidad
                                         }).ToList();
                                         tbPrecioBE.Text = resultado.Precio.ToString(CultureInfo.InvariantCulture);
                                         tbDescripcionBE.Text = resultado.Descripcion;
                                         tbPesoLitroBE.Text = resultado.PesoLitro.ToString(CultureInfo.InvariantCulture);
                                         tbMargenConPrecioBE.Text = resultado.Margen.ToString(CultureInfo.InvariantCulture);
                                         chDiarioBE.Checked = (resultado.Diario == 1);
                                         tbCodigoBE.Enabled = true; tbCostoElaboracionBE.Text =
                                              resultado.CostoElaboracion.ToString(CultureInfo.InvariantCulture);
                                         btBuscarBE.Enabled = true;
                                     }));
                                 }, false);
                            brd.Show();
                            break;
                        default:
                            MessageBox.Show(this, @"No se encontraron recetas con los parametros de busqueda ingresados");
                            Console.WriteLine(jsonResult.Content);
                            break;
                    }

                }));
            });
        }
        private void btBuscarBE_Click(object sender, EventArgs e)
        {
            BuscarReceta(ActualizarInputs, new Inputs
            {
                ClaveReceta = tbCodigoBE,
                ActualizarMargen = ActualizarMargen,
                CostoElaboracion = tbCostoElaboracionBE,
                CostoEstimado = tbCostoEstimadoBE,
                Ingredientes = dgvIngredientesBusqueda,
                MargenSugerido = tbMargenSugeridoBE,
                PrecioSugerido = tbPrecioSugeridoBE
            });
        }

        private void tbPesoLitro_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Opcion.ValidarCaracter(e);
        }
        private void tbMargenConPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Opcion.ValidarCaracter(e);
        }
        private void tbPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Opcion.ValidarCaracter(e);
        }
        private void tbPesoLitro_TextChanged(object sender, EventArgs e)
        {
           Opcion.ValidarDouble(tbPesoLitro);
        }

        private void tbCodigo_TextChanged(object sender, EventArgs e)
        {
            btBuscar.Enabled = ValidarBusquedaVacia();
            
        }

        private bool ValidarBusquedaVacia()
        {
            return tbCodigo.Text.Trim().Length > 0;
        }
        private void tbCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 13 &&ValidarBusquedaVacia())
            {
                btBuscar_Click(sender,new EventArgs());
            }
        }

        private void btValidar_Click(object sender, EventArgs e)
        {
            Local.Receta.clave = (tbClaveReceta.Text);
            Opcion.EjecucionAsync(Data.Receta.Lista, jsonResult =>
            {
                // ReSharper disable once RedundantJumpStatement
                if (!ValidarClave(tbClaveReceta, jsonResult)) return;
            });
        }

        private void btBorrarSelecBE_Click(object sender, EventArgs e)
        {
            Opcion.BorrarSeleccion(dgvIngredientesBusqueda);
            MessageBox.Show(this, @"Registro eliminado con exito");

        }

        private void btBorrarListaBE_Click(object sender, EventArgs e)
        {
            Opcion.BorrarDataGridView(dgvIngredientesBusqueda);
            ValidarBusquedaVacia1();
            MessageBox.Show(this, @"Lista eliminada con exito");
        }
        private bool ValidarBusquedaVacia1()
        {
            return tbCodigoBE.Text.Trim().Length > 0;
        }
        private void tbCodigoBE_TextChanged(object sender, EventArgs e)
{
            btBuscarBE.Enabled = ValidarBusquedaVacia1();
        }
        private void tbCodigoBE_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 13 && ValidarBusquedaVacia1())
            {
                btBuscarBE_Click(sender, new EventArgs());
            }
        }

        private void cbTipoReceta_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cbTipoReceta.SelectedIndex == -1 || dgvIngredientes.Rows.Count <= 0) return;
            ActualizarMargen(tbMargenSugerido);
            ActualizarInputs(new Inputs
            {
                ActualizarMargen = ActualizarMargen,
                CostoElaboracion = tbCostoElaboracion,
                CostoEstimado = tbCostoEstimado,
                Ingredientes = dgvIngredientes,
                MargenSugerido = tbMargenSugerido,
                PrecioSugerido = tbPrecioSugerido
            });
        }

        private void tbBuscarReceta_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && ValidarBusquedaVacia1())
            {
                btBuscarClave_Click(sender, new EventArgs());
            }
        }

    }
}