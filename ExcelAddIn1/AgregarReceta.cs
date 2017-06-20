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
using System.Net.Mime;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ExcelAddIn1
{
    public partial class AgregarReceta :Form
    {
        private readonly List<unidades> _unidadesList;
        private List<Articulo.Basica> _listaArticuloBasica1;
        private List<Articulo.Basica> _listaArticuloBasica2;
        //private List<Receta> _listadetalleact;
        //private List<Receta.Detalle> _ingredientesList;
        public class Inputs
        {

            public DataGridView Ingredientes;
            public TextBox ClaveReceta;
            public MaskedTextBox PesoLitro;
            public TextBox Descripcion;
            public MaskedTextBox CostoEstimado;
            public MaskedTextBox CostoElaboracion;
            public Action<Inputs> ActualizarMargen;
            public MaskedTextBox MargenSugerido;
            public MaskedTextBox MargenConPrecio;
            public MaskedTextBox PrecioSugerido;
            public MaskedTextBox Precio;
            public CheckBox Diario;
            public TextBox ModoElaboracion;
            public ComboBox TipoReceta;
            public MaskedTextBox Cantidad;
        }



        public class unidades
        {
        
            public string unidad { get; set; }
        }

       public int validar = 0;
        public AgregarReceta()
        {
            InitializeComponent();
            _unidadesList=new List<unidades>();
           
            
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
            //_unidadesList.Add(new unidades { unidad = "PZA" });
            //_unidadesList.Add(new unidades { unidad = "CAJA" });
            //_unidadesList.Add(new unidades { unidad = "m" });
            //_unidadesList.Add(new unidades { unidad = "KG" });
            //_unidadesList.Add(new unidades { unidad = "LT" });
            //_unidadesList.Add(new unidades { unidad = "NA" });
            //_unidadesList.Add(new unidades { unidad = "20" });
            //_unidadesList.Add(new unidades { unidad = "GR" });
            //_unidadesList.Add(new unidades { unidad = "Pqt" });

            

            ActiveControl = tbCodigo;
            tbCodigo.Focus();
            btGuardar.Enabled = ValidarCampos();



            //cbunidad.DataSource = _unidadesList;
            //cbunidad.DataSource = _unidadesList;
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
                
                CostoElaboracion = tbCostoElaboracion,
                CostoEstimado = tbCostoEstimado,
                Ingredientes = dgvIngredientes,
                MargenSugerido = tbMargenSugerido,
                    Precio=tbPrecio,
                MargenConPrecio =tbMargenConPrecio,
                PrecioSugerido = tbPrecioSugerido,
                PesoLitro=tbPesoLitro,
                TipoReceta = cbTipoReceta,
                ActualizarMargen = ActualizarMargen
            });
        }
        private void tbCostoElaboracion_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Opcion.ValidarCaracter(e);
        }
        /*a todos los actualizarInput y actualizarMargen hay que ponerle en los parametros todos los inputs
         tambien descripcion y cdigoo. no pero no estaria mal por si luego lo modificamos*/
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
                MargenConPrecio = tbMargenConPrecio,
                PrecioSugerido = tbPrecioSugerido,
                Precio=tbPrecio,
                PesoLitro=tbPesoLitro,
                TipoReceta = cbTipoReceta
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
                CostoElaboracion = tbCostoElaboracion,
                CostoEstimado=tbCostoEstimado
            });
            btGuardar.Enabled = ValidarCampos();
            tsmGuardar.Enabled = ValidarCampos();

        }
        private void tbMargenConPrecioBE_TextChanged(object sender, EventArgs e)
        {
            //if (banderaejecucion)
            //{
                if(!Opcion.ValidarDouble(tbMargenConPrecioBE)) return;
                ActualizarPrecio(new Inputs
                 {
                     Precio = tbPrecioBE,
                     Ingredientes = dgvIngredientesBusqueda,
                     MargenConPrecio = tbMargenConPrecioBE,
                     CostoElaboracion = tbCostoElaboracionBE
                 });

           // }

        }

        private void btBorrarSeleccion_Click(object sender, EventArgs e)
        {
            Opcion.BorrarSeleccion(dgvIngredientes);
            btGuardar.Enabled = ValidarCampos();
        }
        private void tbPrecio_TextChanged(object sender, EventArgs e)
        {
            if (!Opcion.ValidarDouble(tbPrecio)) return;
            ActualizarMargen(new Inputs
            {
                MargenConPrecio = tbMargenConPrecio,
                Ingredientes = dgvIngredientes,
                CostoElaboracion = tbCostoElaboracion,
                Precio = tbPrecio,
                PrecioSugerido=tbPrecioSugerido,
                CostoEstimado=tbCostoEstimado
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

        /*bueno vamos a hacerlo como mecionas  */
        private bool ValidarCampos()
        {
            return (tbClaveReceta.Text != string.Empty && tbDescripcion.Text != string.Empty
                    && tbPrecio.Text != string.Empty && tbMargenConPrecio.Text != string.Empty &&
                                 tbPesoLitro.Text != string.Empty && tbCostoEstimado.Text != string.Empty 
                                 && txtinstrucciones.Text != string.Empty && dgvIngredientes.RowCount>0);
        }
        /*
         * CostoEstimado
         * PrecioSugerido
         * dgvIngredientes
         */
        private static void ActualizarInputs(Inputs inputs)
        {
            double sum = 0;
            inputs.Ingredientes.DataSource = inputs.Ingredientes.Tag;
            for (var i = 0; i < inputs.Ingredientes.Rows.Count; ++i)
            {
                var costo1 = Convert.ToDouble(inputs.Ingredientes.Rows[i].Cells[3].Value);
                var cantidad1 = Convert.ToDouble(inputs.Ingredientes.Rows[i].Cells[4].Value);
                sum += (costo1*cantidad1);
            }
            inputs.CostoEstimado.Text = sum.ToString(CultureInfo.InvariantCulture);
            if (inputs.TipoReceta.Items.Count <= 0) return;
            var lista = Opcion.JsonaListaGenerica<CbGenerico>((IRestResponse)inputs.TipoReceta.Tag);
            inputs.MargenSugerido.Text = lista[inputs.TipoReceta.SelectedIndex].Margen;

            inputs.ActualizarMargen(new Inputs
            {
                MargenConPrecio = inputs.MargenConPrecio,
                MargenSugerido = inputs.MargenSugerido,
                Ingredientes = inputs.Ingredientes,
                CostoElaboracion = inputs.CostoElaboracion,
                Precio = inputs.Precio,
                PrecioSugerido=inputs.PrecioSugerido,
                CostoEstimado=inputs.CostoEstimado
            });
            var costo = (sum) +
                        (inputs.CostoElaboracion.Text != string.Empty
                            ? Convert.ToDouble(inputs.CostoElaboracion.Text)
                            : 0);
            var margen = 1 - (Convert.ToDouble(inputs.MargenSugerido.Text)/100);
            var margenv2= (Math.Round((costo / margen), 2)).ToString(CultureInfo.InvariantCulture);
            inputs.PrecioSugerido.Text = margenv2;
           

         

        }

        /*este*/
        private void ActualizarMargen1(MaskedTextBox margenSugerido)
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
                             _listaArticuloBasica1 = parametros.Ingredientes.Tag as List<Articulo.Basica>;
                             _listaArticuloBasica2 = (listaArticulo.Select(x => x.CopiadoSencillo()).ToList());
                             if (_listaArticuloBasica1 != null)
                             {
                                 _listaArticuloBasica2.AddRange(_listaArticuloBasica1);
                             }
                             parametros.Ingredientes.Tag = _listaArticuloBasica2
                                     .GroupBy(p => p.ArtId)
                                     .Select(g => new Articulo.Basica
                                     {
                                         ArtId = g.Key,
                                         Clave = g.First().Clave,
                                         Descripcion = g.First().Descripcion,
                                         PrecioCompra = g.First().PrecioCompra,
                                         Cantidad = g.Sum(i => i.Cantidad)
                                     }).ToList();
                             btGuardar.Enabled = ValidarCampos();
                             //
                             btGuardar.Enabled = true;
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
            /*y el if si estaba mal desde antes*/
            if (inputs.MargenConPrecio.Text != string.Empty)
            {
                inputs.Precio.Text = (Math.Round(((sum) +
                                                    (inputs.CostoElaboracion.Text != string.Empty
                                                        ? Convert.ToDouble(inputs.CostoElaboracion.Text)
                                                        : 0))
                                                        /
                                                    (1 - (Convert.ToDouble(inputs.MargenConPrecio.Text)/100)), 2))
                    .ToString(CultureInfo.InvariantCulture);
               //
            }

            ValidarBusquedaVacia();
        }



        /*y este*/
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
           var margenprecio = Math.Round(((( ( costo/precio  )-1)*-1) * 100), 2).ToString(CultureInfo.InvariantCulture);
                inputs.MargenConPrecio.Text = margenprecio;
            //tbPrecioSugeridoBE.Text = margenprecio.ToString();
                   
            ValidarBusquedaVacia();
        }
        private void btBorrarLista_Click(object sender, EventArgs e)
        {
            Opcion.BorrarDataGridView(dgvIngredientes);
            ValidarBusquedaVacia();
            btGuardar.Enabled = ValidarCampos();
            
            
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
            Local.Receta.Clave = (inputs.ClaveReceta.Text);
            
            if (ValidarCampos())
            {
                Opcion.EjecucionAsync(Data.Receta.Lista, jsonResult =>
                {
                    if (!ValidarClave(inputs.ClaveReceta, jsonResult)) return;
                    var mde = new MensajeDeEspera();
                    BeginInvoke((MethodInvoker)(() =>
                    {
                        
                        if (chDiario.Checked==false)
                        {
                            tbcantidad.Text = "0";
                            
                        }
                        mde.Show();
                        var receta = new Receta{
                            Clave = inputs.ClaveReceta.Text,
                            CostoCreacion = double.Parse(inputs.CostoEstimado.Text),
                            CostoElaboracion = double.Parse(inputs.CostoElaboracion.Text),
                            Descripcion = inputs.Descripcion.Text,
                            //FechaModificacion = DateTime.Now,
                            Margen = double.Parse(inputs.MargenConPrecio.Text),
                            PesoLitro = Convert.ToDouble(inputs.PesoLitro.Text),
                            Precio = double.Parse(inputs.Precio.Text),
                            RecId = 0,
                            Diario = validar/*inputs.Diario.Checked?1:0*/,
                            ModoElaboracion = inputs.ModoElaboracion.Text,
                            TiporId=cbTipoReceta.SelectedIndex+1,
                        
                             Cantidadd = Convert.ToDouble(tbcantidad.Text) 
                           
                            
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
                            var ruta = new Receta.ImagenAndProcess
                            {
                                
                                Instrucciones = inputs.ModoElaboracion.Text,
                                RutaImagen = @"\\mercattoserver\Recetario\img\" + inputs.ClaveReceta.Text + a.ToString() + ".jpg"
                            };
                        }

                        Data.Receta.CReceta = receta;
                   // Data.Receta.Detalle.Actualizar();
                        Opcion.EjecucionAsync(Data.Receta.Insertar, resultado =>
                        {
                        
                     
                            Guardado(resultado,inputs);
                        }, x =>
                        {
                            Limpiar(inputs, mde);
                        });
                       
                        
                    }));
                });}}
        /*Aqui es donde guarda lo del detalle verdad*/
      

        private void Guardado(Action<IRestResponse> x, Inputs inputs)
        {
            var listRecetaDetalle = new List<Receta.Detalle>();
            BeginInvoke((MethodInvoker) (() => {
                for (var i = 0; i < inputs.Ingredientes.Rows.Count; i++)
                {
                    var cantidad = double.Parse(inputs.Ingredientes.Rows[i].Cells[4].Value.ToString());
                    var precioCompra = Convert.ToDouble(inputs.Ingredientes.Rows[i].Cells[3].Value);
                    var precioTotal = precioCompra * cantidad;
                    /*begin invoke*/
                    listRecetaDetalle.Add(new Receta.Detalle
                    {
                        RecId = Data.Receta.CReceta.RecId,
                        ArtId = Convert.ToInt32(inputs.Ingredientes.Rows[i].Cells[0].Value),
                        Cantidad = double.Parse(inputs.Ingredientes.Rows[i].Cells[4].Value.ToString()),
                        Clave = inputs.Ingredientes.Rows[i].Cells[1].Value.ToString(),
                        Descripcion = inputs.Ingredientes.Rows[i].Cells[2].Value.ToString(),
                        IdUnidad = 1,
                        PrecioCompra = Convert.ToDouble(inputs.Ingredientes.Rows[i].Cells[3].Value),
                        PrecioTotal = precioTotal,
                        TiporId = cbTipoReceta.SelectedIndex + 1


                    });
                }
            }
            
            ));
            //var listRecetaDetalle = new List<Receta.Detalle>();
           
            /*si y esta parte es la que pensaba usar para ya sea actualizar o insertar mira*/
            #region insertar o actualizar



            BeginInvoke((MethodInvoker) (() => 
            {
                if (tabControl1.SelectedTab == tabControl1.TabPages[0])
                {
                    Data.Receta.Detalle.CRecetaDetalle = listRecetaDetalle;

                    #region Insertar imagen y copiar a ruta            
                    if (MessageBox.Show(@"Desea agregar la imagen de la Receta", "Aviso", MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        openFileDialog1.Filter = "Image Files (*.png *.jpg *.bmp) | *.png; *.jpg; *.bmp | All Files(*.*) | *.* ";
                        openFileDialog1.Title = "Buscar Imagen";
                        openFileDialog1.FileName = "";
                        openFileDialog1.ShowDialog();
                        long a = int.Parse(DateTime.Now.ToString("yyyyMMdd"));

                        if (inputs.ModoElaboracion.Text == string.Empty)
                        {
                            var instructivo = new Receta.ImagenAndProcess
                            {
                                RecId = Data.Receta.CReceta.RecId,
                                Instrucciones = "",
                                RutaImagen = @"\\mercattoserver\Recetario\img\" + inputs.ClaveReceta.Text + a.ToString() + ".jpg"

                            };
                            Data.ReporteCocina.InsertarRutaeImagen(instructivo);
                            Opcion.Copycmdserver(openFileDialog1.FileName, @"\\mercattoserver\Recetario\img\" + inputs.ClaveReceta.Text + a.ToString() + ".jpg");
                        }
                        else
                        {
                            var listainstrucciones = new Receta.ImagenAndProcess
                            {
                                RecId = Data.Receta.CReceta.RecId,
                                Instrucciones = inputs.ModoElaboracion.Text,
                                RutaImagen = @"\\mercattoserver\Recetario\img\" + inputs.ClaveReceta.Text + a.ToString() + ".jpg"
                            };
                            Data.ReporteCocina.InsertarRutaeImagen(listainstrucciones);
                            Opcion.Copycmdserver(openFileDialog1.FileName, @"\\mercattoserver\Recetario\img\" + inputs.ClaveReceta.Text + a.ToString() + ".jpg");
                        }

                    }
                    else
                    {
                        if (inputs.ModoElaboracion.Text == string.Empty)
                        {
                            var instructivo = new Receta.ImagenAndProcess
                            {
                                RecId = Data.Receta.CReceta.RecId,
                                Instrucciones = "",
                                RutaImagen = ""
                            };
                            Data.ReporteCocina.InsertarRutaeImagen(instructivo);
                        }
                        else
                        {
                            var listainstrucciones = new Receta.ImagenAndProcess
                            {
                                RecId = Data.Receta.CReceta.RecId,
                                Instrucciones = inputs.ModoElaboracion.Text,
                                RutaImagen = ""
                            };
                            Data.ReporteCocina.InsertarRutaeImagen(listainstrucciones);
                        }

                    }
                    #endregion

                    Data.Receta.Detalle.Insertar(x);
                }
                else
                {
                    //Data.Receta.Detalle.Eliminar(x);
             
                    Data.Receta.Detalle.ARecetaDetalle = listRecetaDetalle;
                    Data.Receta.Detalle.Insertar(x);
                   
                }
                

            }));
            #endregion
            
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
             
            Pbreceta.InitialImage = null;
            Pbreceta.Image = null;

            if (tabControl1.SelectedTab == tabControl1.TabPages[0])
                Guardar(new Inputs
                {
                    ClaveReceta = tbClaveReceta,
                    CostoElaboracion = tbCostoElaboracion,
                    CostoEstimado = tbCostoEstimado,
                    Descripcion = tbDescripcion,
                    Diario = chDiarioBE,
                    Ingredientes = dgvIngredientes,
                    MargenConPrecio = tbMargenConPrecio,
                    MargenSugerido = tbMargenSugerido,
                    PesoLitro = tbPesoLitro,
                    Precio = tbPrecio,
                    ModoElaboracion = txtinstrucciones,
                    Cantidad = tbcantidad
                    

                });
            else 
            {

              
                BeginInvoke((MethodInvoker) (() =>
                {
                   
                    #region edicion de Presupuesto
                    int checadodiario;
                    if (chDiarioBE.Checked == true)
                    {
                        checadodiario = 1;
                    }
                    else
                    {
                        checadodiario = 0;
                    }
                    var listado = new List<Respuesta.Receta.ActualizaPresupuesto>();
                   var objeto =new Receta.ActualizaPresupuesto
                    {
                        RecId = Local.Receta.RecId,
                        Clave = tbBuscarReceta.Text,
                        CostoElaboracion = Convert.ToDouble(tbCostoEstimadoBE.Text),
                        CostoCreacion = Convert.ToDouble(tbCostoElaboracionBE.Text),
                        Margen = Convert.ToDouble(tbMargenConPrecioBE.Text),
                        TiporId = cbTipoBE.SelectedIndex + 1,
                        Descripcion = tbDescripcionBE.Text,
                        PesoLitro = Convert.ToDouble(tbPesoLitroBE.Text),/*peso x litros debe ser double tambien*/
                        //FechaModificacion = DateTime.Now,
                        Precio = Convert.ToDouble(tbPrecioBE.Text),
                        Diario = checadodiario,
                        Cantidadd = Convert.ToDouble(tbcantidadBEE.Text) 
                    };

                    Data.Receta.Detalle.ActualizarPresupuesto(objeto);
                    #endregion

                    #region editar ingredientes 
                    var listaingredientes = new List<Receta.Detalle>();
                    BeginInvoke((MethodInvoker)(() =>
                    {
                        for (var i = 0; i < dgvIngredientesBusqueda.Rows.Count; i++)
                        {
                            var cantidad = double.Parse(dgvIngredientesBusqueda.Rows[i].Cells[4].Value.ToString());
                            var precioCompra = Convert.ToDouble(dgvIngredientesBusqueda.Rows[i].Cells[3].Value);
                            var precioTotal = precioCompra * cantidad;
                            listaingredientes.Add(new Receta.Detalle
                            {
                                RecId = Local.Receta.RecId,
                                ArtId = Convert.ToInt32(dgvIngredientesBusqueda.Rows[i].Cells[0].Value),
                                Cantidad = double.Parse(dgvIngredientesBusqueda.Rows[i].Cells[4].Value.ToString()),
                                Clave = dgvIngredientesBusqueda.Rows[i].Cells[1].Value.ToString(),
                                Descripcion = dgvIngredientesBusqueda.Rows[i].Cells[2].Value.ToString(),
                                IdUnidad = 1,
                                PrecioCompra = Convert.ToDouble(dgvIngredientesBusqueda.Rows[i].Cells[3].Value),
                                PrecioTotal = precioTotal,

                            });
                        }
                        Data.Receta.Detalle.Eliminar();
                        Data.Receta.Detalle.ActualizarIngredientes(listaingredientes);

                    }));

                    #endregion

                    #region actualiza Ruta de imagen e Instrucciones
                    long a = int.Parse(DateTime.Now.ToString("yyyyMMdd"));

                    if (MessageBox.Show(@"Desea modificar la imagen", "Aviso", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string otro = Local.Receta.Ruta;
                        int final = otro.Length - 31;
                        string mundo = otro.Substring(31, final);
                        var uri = new Uri(@"file://mercattoserver/Recetario/img/" + mundo, UriKind.Absolute);
                        System.IO.File.Delete(@"\\mercattoserver\\C$\Recetario\img\" + mundo);
                        

                        openFileDialog1.Filter = "Image Files (*.png *.jpg *.bmp) | *.png; *.jpg; *.bmp | All Files(*.*) | *.* ";
                        openFileDialog1.Title = "Buscar Imagen";
                        openFileDialog1.FileName = "";
                        openFileDialog1.ShowDialog();

                        var listainstruccionesv1 = new Receta.ImagenAndProcess
                        {
                            RecId = Local.Receta.RecId,
                            Instrucciones = txtinstruccionesBE.Text,
                            RutaImagen = @"\\mercattoserver\Recetario\img\" + tbBuscarReceta.Text + a.ToString() + ".jpg"
                        };


                        Data.ReporteCocina.InsertarRutaeImagen(listainstruccionesv1);
                        Opcion.Copycmdserver(openFileDialog1.FileName, @"\\mercattoserver\Recetario\img\" + tbBuscarReceta.Text + a.ToString() + ".jpg");

                    }
                    else
                    {
                        var listainstruccionesv1 = new Receta.ImagenAndProcess
                        {
                            RecId = Local.Receta.RecId,
                            Instrucciones = txtinstruccionesBE.Text,
                            RutaImagen = @"\\mercattoserver\Recetario\img\" + tbBuscarReceta.Text + a.ToString() + ".jpg"
                        };

                        // string compara = 
                        if (txtinstruccionesBE.Text != Local.Receta.Ingredientes)
                        {
                            Data.Receta.Detalle.Eliminarrutaeimagen();
                            Data.ReporteCocina.InsertarRutaeImagen(listainstruccionesv1);

                           
                        }
                        //limpiarbusqueda();
                    }
                    limpiarbusqueda();
                    #endregion

                }));
               
          
            }
        }

        public void limpiarbusqueda()
        {
            tbPesoLitroBE.Text = "";
            cbTipoBE.SelectedIndex = 0;
            tbCostoElaboracionBE.Text = "";
            tbCostoElaboracionBE.Text = "";
            tbMargenConPrecioBE.Text = "";
            tbMargenSugeridoBE.Text = "";
            tbPrecioSugeridoBE.Text = "";
            tbPrecioBE.Text = "";
            txtinstruccionesBE.Text = "";
            Pbreceta.ImageLocation = @"\\mercattoserver\Recetario\img\sinimagen.jpg";
            dgvIngredientesBusqueda.DataSource = null;
            dgvIngredientesBusqueda.DataSource = "";
            dgvIngredientesBusqueda.Columns.Clear();
        }

        /****************************************************************************/
        private void btBuscarClave_Click(object sender, EventArgs e)
        {
            //double sum = 0;
            Cocina.DetalleCocina.Clave = tbBuscarReceta.Text == string.Empty ? "%" : tbBuscarReceta.Text;
            Opcion.EjecucionAsync(Data.ReporteCocina.BuscarRecetav2, jsonResult =>
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

                                         Local.Receta.RecId = resultado.RecId;
                                         Local.Receta.Ruta = resultado.Rutaimagen;
                                         Local.Receta.Ingredientes = resultado.Instrucciones;
                                         dgvIngredientesBusqueda.Tag = resultado.Ingredientes.Select(x => new Articulo.Basica
                                         {
                                             ArtId = x.ArtId,
                                             Clave = x.Clave,
                                             Descripcion = x.Descripcion,
                                             PrecioCompra = x.PrecioCompra,
                                             Cantidad = x.Cantidad
                                         }).ToList();
                                         tbPesoLitroBE.Text = resultado.PesoLitro.ToString();
                                         tbCostoElaboracionBE.Text = resultado.CostoElaboracion.ToString();
                                         
                                         tbPrecioBE.Text = resultado.Precio.ToString();
                                         tbDescripcionBE.Text = resultado.Descripcion;
                                       
                                        
                                          ActualizarInputs(new Inputs
                                          {
                                              ActualizarMargen = ActualizarMargen,
                                              Precio = tbPrecioBE,
                                              MargenConPrecio = tbMargenConPrecioBE,
                                              MargenSugerido = tbMargenSugeridoBE,
                                              Ingredientes = dgvIngredientesBusqueda,
                                              ClaveReceta = tbCodigoBE,
                                              PesoLitro = tbPesoLitroBE,
                                              Descripcion = tbDescripcionBE,
                                              CostoElaboracion = tbCostoElaboracionBE,
                                              CostoEstimado = tbCostoEstimadoBE,
                                              PrecioSugerido = tbPrecioSugeridoBE,
                                              ModoElaboracion = txtinstruccionesBE,
                                              Diario = chDiarioBE,
                                              TipoReceta = cbTipoBE
                                          });

                                         tbMargenConPrecioBE.Text = resultado.Margen.ToString();
                                         tbBuscarReceta.Text = resultado.Clave;
                                         cbTipoBE.SelectedIndex= resultado.TiporId - 1;
                                         tbCostoEstimadoBE.Text = resultado.CostoCreacion.ToString();                                     
                                         chDiarioBE.Checked = (resultado.Diario == 1);
                                         tbCodigoBE.Enabled = true;
                                         tbcantidadBEE.Text = resultado.Cantidadd.ToString();
                                    
                                         string datos = resultado.Instrucciones;
                                         txtinstruccionesBE.Text = datos;
                                         string calis = resultado.Rutaimagen.ToString();
                                         if (calis==null)
                                         {
                                             Pbreceta.Image = Image.FromFile(@"\\mercattoserver\Recetario\img\sinimagen.jpg");
                                         }
                                         else
                                         {
                                             Pbreceta.ImageLocation = calis;
                                         }
                                         
                                         btGuardar.Enabled = true;
                                     }));
                                 }, false);
                            brd.Show();
                            break;
                        default:
                            MessageBox.Show(this, @"No se encontraron recetas con los parametros de busqueda ingresados");
                            Console.WriteLine(jsonResult.Content);
                            Pbreceta.Image = Image.FromFile(@"\\mercattoserver\Recetario\img\sinimagen.jpg");
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
                CostoElaboracion = tbCostoElaboracionBE,
                CostoEstimado = tbCostoEstimadoBE,
                Ingredientes = dgvIngredientesBusqueda,
                MargenSugerido = tbMargenSugeridoBE,
                PrecioSugerido = tbPrecioSugeridoBE,
                PesoLitro = tbPesoLitroBE,
                Precio = tbPrecioBE,
                TipoReceta = cbTipoBE,
                MargenConPrecio = tbMargenConPrecioBE,
                ActualizarMargen = ActualizarMargen
               
            });
            btGuardar.Enabled = true;
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
            Local.Receta.Clave = (tbClaveReceta.Text);
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
            //ActualizarMargen(tbMargenSugerido);
            ActualizarInputs(new Inputs
            {
                CostoElaboracion = tbCostoElaboracion,
                CostoEstimado = tbCostoEstimado,
                Ingredientes = dgvIngredientes,
                MargenSugerido = tbMargenSugerido,
                PrecioSugerido = tbPrecioSugerido,
                TipoReceta = cbTipoReceta,
                MargenConPrecio = tbMargenConPrecioBE,
                PesoLitro = tbPesoLitroBE,
                Precio = tbPrecioBE,
                ActualizarMargen = ActualizarMargen
         
            });
        }

        private void tbBuscarReceta_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 /*&& ValidarBusquedaVacia1()*/)
            {
                btBuscarClave_Click(sender, new EventArgs());
            }
        }

        private void dgvIngredientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tbCostoEstimado_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void tbMargenConPrecioBE_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            if (Convert.ToInt16(tbMargenConPrecioBE.Text)<30) {
                MessageBox.Show("El margen no puede ser menor al 30%");
                tbMargenConPrecioBE.Clear();
                tbMargenConPrecioBE.Focus();
            }
        }

        private void dgvIngredientesBusqueda_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tbDescripcionBE_TextChanged(object sender, EventArgs e)
        {
            btGuardar.Enabled = ValidarCampos();
        }

        private void chDiario_CheckedChanged(object sender, EventArgs e)
        {
            if (chDiario.Checked == true)
            {
                lbcantidad.Visible = true;
                
                tbcantidad.Visible = true;

                validar = 1;
               
                
            }
            else
            {
                lbcantidad.Visible = false;
               
                tbcantidad.Visible = false;
               
            }
        }

        private void chDiarioBE_CheckedChanged(object sender, EventArgs e)
        {
            if (chDiarioBE.Checked == true)
            {
                
                lbcantidadBE.Visible = true;
                tbcantidadBEE.Visible = true;
                

                
                
            }
            else
            {
                lbcantidadBE.Visible = false;
               
                tbcantidadBEE.Visible = false;
                
            }

        }

        private void tbBuscarReceta_TextChanged(object sender, EventArgs e)
        {

        }
    }
}