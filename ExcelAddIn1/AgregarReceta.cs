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
using System.ComponentModel;

namespace ExcelAddIn1
{
    public partial class AgregarReceta : Form
    {
        private List<Articulo.Basica> _listaArticuloBasica1;
        private List<Articulo.Basica> _listaArticuloBasica2;
        public List<Reporte.RespuestaCocina.TablaPreciosNuevos> _ListaActualizarListr;
        public BindingList<Reporte.RespuestaCocina.TablaPreciosNuevos.MostrarTablaPreciosNuevos> listaBindingAct;
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
            public MaskedTextBox PrecioTotal;
            public CheckBox Diario;
            public TextBox ModoElaboracion;
            public ComboBox TipoReceta;
            public MaskedTextBox CantidadElaboracion;
            public ComboBox UnidadElaboracion;
            public MaskedTextBox CantidadDiario;
        }

        public int Reccid;
        public int Validar;
        public int y;
        public AgregarReceta()
        {
            InitializeComponent();
            #region CargarComboBox
            Opcion.EjecucionAsync(Data.Receta.Tipo.ListaTipo, x =>
            {
                CargarComboBoxTipo(x, cbTipoReceta);
                CargarComboBoxTipo(x, cbTipoBE);
            });
            Opcion.EjecucionAsync(Data.Receta.Unidad.TipoUnidades, x =>
            {
                CargarComboBoxUnidad(x, cbUnidadElaboracion);
                CargarComboBoxUnidad(x, cbUnidadElaboracionBE);
            });
        }
        public void CargarComboBoxTipo(IRestResponse json, ComboBox tipoReceta)
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
        private void CargarComboBoxUnidad(IRestResponse json, ComboBox tipoUnidad)
        {
            BeginInvoke((MethodInvoker)(() =>
            {
                var bindingSource1 = new BindingSource
                {
                    DataSource = Opcion.JsonaListaGenerica<CbGenerico>(json)
                };
                tipoUnidad.DataSource = bindingSource1;
                tipoUnidad.DisplayMember = "nombre";
                tipoUnidad.ValueMember = "id";
                tipoUnidad.Tag = json;
            }));
        }
        #endregion
        private void tbClaveReceta_TextChanged(object sender, EventArgs e)
        {
            btGuardar.Enabled = ValidarCampos();
        }
        private void tbDescripcion_TextChanged(object sender, EventArgs e)
        {
            btGuardar.Enabled = ValidarCampos();
        }
        private void AgregarReceta_Load(object sender, EventArgs e)
        {
            ActiveControl = tbBuscarReceta;
            tbBuscarReceta.Focus();
            tabCon.TabPages.Remove(tabPage1);
            //tmActualizar.Enabled = true;
            //tmActualizar.Start();
            Data.Reporte.PreciosActualizarTabla(t =>
            {
                if (t != null)
                {
                    BeginInvoke((MethodInvoker)(() =>
                    {
                        var liq = Opcion.JsonaListaGenerica<Reporte.RespuestaCocina.TablaPreciosNuevos>(t);
            switch (t.StatusCode)
                {
                  case HttpStatusCode.OK:
                        _ListaActualizarListr = liq.Where(x => x.Modificacion =="Actualizar").ToList();
                        if (_ListaActualizarListr.Count>0)
                        {
                            if ((MessageBox.Show(@"Visualizar Menu de Productos con Precio Nuevo", " ", MessageBoxButtons.YesNo) == DialogResult.Yes))
                            {
                                    ActualizarPrecios frm = new ActualizarPrecios();
                                    frm.Show();
                                
                            }
                        }
                    break;
                }
            }));
             }
          });
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
                Precio = tbPrecio,
                MargenConPrecio = tbMargenConPrecio,
                PrecioSugerido = tbPrecioSugerido,
                PesoLitro = tbPesoLitro,
                TipoReceta = cbTipoReceta,
                ActualizarMargen = ActualizarMargen,
                CantidadElaboracion = tbCantidadElaboracion,
                UnidadElaboracion = cbUnidadElaboracion
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
                MargenConPrecio = tbMargenConPrecio,
                PrecioSugerido = tbPrecioSugerido,
                Precio = tbPrecio,
                PesoLitro = tbPesoLitro,
                TipoReceta = cbTipoReceta,
                CantidadElaboracion = tbCantidadElaboracion,
                UnidadElaboracion = cbUnidadElaboracion
            });
            btGuardar.Enabled = ValidarCampos();
        }
        private void tbMargenConPrecio_TextChanged(object sender, EventArgs e)
        {
            if (!Opcion.ValidarDouble(tbMargenConPrecio)) return;
            ActualizarPrecio(new Inputs
            {
                PrecioTotal = tbPrecioTotalBE,
                Ingredientes = dgvIngredientes,
                MargenConPrecio = tbMargenConPrecio,
                CostoElaboracion = tbCostoElaboracion,
                CostoEstimado = tbCostoEstimado
            });
            btGuardar.Enabled = ValidarCampos();
        }
        private void tbMargenConPrecioBE_TextChanged(object sender, EventArgs e)
        {
            if (!Opcion.ValidarDouble(tbMargenConPrecioBE)) return;
            ActualizarPrecio(new Inputs
            {
                Precio = tbPrecioBE,
                PrecioTotal=tbPrecioTotalBE,
                Ingredientes = dgvIngredientesBusqueda,
                MargenConPrecio = tbMargenConPrecioBE,
                CostoElaboracion = tbCostoElaboracionBE
            });
            btGuardar.Enabled = ValidarCamposBe();
        }
        private void btBorrarSeleccion_Click(object sender, EventArgs e)
        {
            Opcion.BorrarSeleccion(dgvIngredientes);
            ActualizarInputs(new Inputs
            {
                CostoElaboracion = tbCostoElaboracion,
                CostoEstimado = tbCostoEstimado,
                Ingredientes = dgvIngredientes,
                MargenSugerido = tbMargenSugerido,
                MargenConPrecio = tbMargenConPrecio,
                PrecioSugerido = tbPrecioSugerido,
                Precio = tbPrecio,
                PesoLitro = tbPesoLitro,
                TipoReceta = cbTipoReceta,
                CantidadElaboracion = tbCantidadElaboracion,
                UnidadElaboracion = cbUnidadElaboracion
            });
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
                PrecioSugerido = tbPrecioSugerido,
                CostoEstimado = tbCostoEstimado,
                ActualizarMargen = ActualizarMargen
            });
            btGuardar.Enabled = ValidarCampos();
        }
        private void tbPrecioBE_TextChanged(object sender, EventArgs e)
        {
            if (!Opcion.ValidarDouble(tbPrecioBE)) return;
            ActualizarMargen(new Inputs
            {
                MargenConPrecio = tbMargenConPrecioBE,
                Ingredientes = dgvIngredientesBusqueda,
                CostoElaboracion = tbCostoElaboracionBE,
                PrecioTotal=tbPrecioTotalBE,
                Precio = tbPrecioBE,
                CostoEstimado = tbCostoEstimadoBE,
                ActualizarMargen = ActualizarMargen
            });
            btGuardar.Enabled = ValidarCamposBe();
        }
        private bool ValidarCampos()
        {
            return (tbClaveReceta.Text != string.Empty && tbDescripcion.Text != string.Empty
                    && tbPrecio.Text != string.Empty && tbMargenConPrecio.Text != string.Empty &&
                                 /*tbPesoLitro.Text != string.Empty &&*/ tbCostoEstimado.Text != string.Empty
                                 && txtinstrucciones.Text != string.Empty && dgvIngredientes.RowCount > 0 &&
                                 tbCantidadElaboracion.Text != string.Empty);
        }

        private bool ValidarCamposBe()
        {
            return (tbBuscarReceta.Text != string.Empty && tbDescripcionBE.Text != string.Empty
                    && tbPrecioBE.Text != string.Empty && tbMargenConPrecioBE.Text != string.Empty &&
                               tbPrecioTotalBE.Text != string.Empty && tbCostoEstimadoBE.Text != string.Empty
                                 && txtinstruccionesBE.Text != string.Empty && dgvIngredientesBusqueda.RowCount > 0 &&
                                 tbCantidadElaboracionBE.Text != string.Empty);
        }
        private static void ActualizarInputs(Inputs inputs)
        {
            double sum = 0;
            inputs.Ingredientes.DataSource = inputs.Ingredientes.Tag;
            for (var i = 0; i < inputs.Ingredientes.Rows.Count; ++i)
            {
                var costo1 = Convert.ToDouble(inputs.Ingredientes.Rows[i].Cells[3].Value);
                var cantidad1 = Convert.ToDouble(inputs.Ingredientes.Rows[i].Cells[4].Value);
                sum += (costo1 * cantidad1);
            }
            inputs.CostoEstimado.Text = sum.ToString(CultureInfo.InvariantCulture);
            //if (inputs.TipoReceta.Items.Count <= 0) return;
            //var lista = Opcion.JsonaListaGenerica<CbGenerico>((IRestResponse)inputs.TipoReceta.Tag);
            //    inputs.MargenSugerido.Text = lista[inputs.TipoReceta.SelectedIndex+1].Margen;
     


            inputs.ActualizarMargen(new Inputs
            {
                MargenConPrecio = inputs.MargenConPrecio,
                MargenSugerido = inputs.MargenSugerido,
                Ingredientes = inputs.Ingredientes,
                CostoElaboracion = inputs.CostoElaboracion,
                PrecioTotal = inputs.PrecioTotal,
                PrecioSugerido = inputs.PrecioSugerido,
                CostoEstimado = inputs.CostoEstimado
            });
            var costo = (sum) +
                        (inputs.CostoElaboracion.Text != string.Empty
                            ? Convert.ToDouble(inputs.CostoElaboracion.Text)
                            : 0);
            //var margen = 1 - (Convert.ToDouble(inputs.MargenSugerido.Text) / 100);
            //var margenv2 = (Math.Round((costo / margen), 2)).ToString(CultureInfo.InvariantCulture);
            //inputs.PrecioSugerido.Text = margenv2;
        }
        private void ActualizarPrecio(Inputs inputs)
        {
            if (inputs.PrecioTotal.Focused) return;
            double sum = 0;
            for (var i = 0; i < inputs.Ingredientes.Rows.Count; ++i)
            {
                var costo = Convert.ToDouble(inputs.Ingredientes.Rows[i].Cells[3].Value);
                var cantidad = Convert.ToDouble(inputs.Ingredientes.Rows[i].Cells[4].Value);
                sum += (costo * cantidad);
            }
            if (inputs.MargenConPrecio.Text != string.Empty)
            {
                //inputs.PrecioTotal.Text = (Math.Round(((sum) +
                //                                    (inputs.CostoElaboracion.Text != string.Empty
                //                                        ? Convert.ToDouble(inputs.CostoElaboracion.Text)
                //                                        : 0))
                //                                        /
                //                                    (1 - (Convert.ToDouble(inputs.MargenConPrecio.Text) / 100)), 2))
                //    .ToString(CultureInfo.InvariantCulture);
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
                sum += (costo1 * cantidad1);
            }
            var costo = sum + (inputs.CostoElaboracion.Text != string.Empty
                            ? Convert.ToDouble(inputs.CostoElaboracion.Text)
                            : 0);
            if (inputs.PrecioTotal.Text == string.Empty) return;
            var precio = Convert.ToDouble(inputs.PrecioTotal.Text);
            var margenprecio = Math.Round(((((costo / precio) - 1) * -1) * 100), 2).ToString(CultureInfo.InvariantCulture);
            inputs.MargenConPrecio.Text = margenprecio;
            ValidarBusquedaVacia();
        }
        private void BuscarReceta(Action<Inputs> actualizarInputs, Inputs parametros)
        {
            Local.Articulo.IdArticulo = parametros.ClaveReceta.Text.Trim();
            Opcion.EjecucionAsync(x =>
            {
                Data.Articulo.Lista(x, this);
            }, jsonResult =>
            {
                BeginInvoke((MethodInvoker)(() =>
                {
                    var brd = new BuscarArticulo(Opcion.JsonaListaGenerica<Articulo>(jsonResult), listaArticulo=>
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
                            btGuardar.Enabled = true;
                            for (var x = 0; x == 3; x++)
                            {
                                parametros.Ingredientes.Columns[x].ReadOnly = true;
                                parametros.Ingredientes.Columns[x].DefaultCellStyle.BackColor = Color.LightGray;
                            }
                            parametros.Ingredientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                            //parametros.Ingredientes.RowHeadersVisible = false;
                            var dataGridViewColumn = parametros.Ingredientes.Columns["Cantidad"];
                            if (dataGridViewColumn != null)
                                dataGridViewColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            var gridViewColumn = parametros.Ingredientes.Columns["PrecioCompra"];
                            if (gridViewColumn != null)
                                gridViewColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            parametros.ClaveReceta.Text = "";
                            parametros.ClaveReceta.Focus();
                            actualizarInputs(parametros);
                        }));
                    });
                    brd.Show();
                }));
            });
        }
        private void btBorrarLista_Click(object sender, EventArgs e)
        {
            Opcion.BorrarDataGridView(dgvIngredientes);
            btGuardar.Enabled = ValidarCampos();
            MessageBox.Show(this, @"Lista eliminada con exito");
            tbPrecio.Text = "";
            tbMargenConPrecio.Text = "";
            tbCostoElaboracion.Text = "";

        }
        private bool ValidarClave(Control claveReceta, IRestResponse jsonResult)
        {
            if (jsonResult.StatusCode != HttpStatusCode.OK) return true;
            BeginInvoke((MethodInvoker)(() =>
            {
                MessageBox.Show(this, @"La Clave ingresada ya existe");
                claveReceta.Text = "";
                claveReceta.Focus();
                btGuardar.Enabled = true;
            }));
            return false;
        }

        #region Guardar a Actualizar Receta
        private void btGuardar_Click(object sender, EventArgs e)
        {
            tabCon.TabPages.Add(tabPage1);
            Pbreceta.InitialImage = null;
            Pbreceta.Image = null;
            Reccid = Local.Receta.RecId;
            if (Reccid==0)
                Guardar(new Inputs
                {
                    ClaveReceta = tbBuscarReceta,
                    CostoElaboracion = tbCostoElaboracionBE,
                    CostoEstimado = tbCostoEstimadoBE,
                    Descripcion = tbDescripcionBE,
                    TipoReceta = cbTipoBE,
                    //Diario = chDiario,
                    Ingredientes = dgvIngredientesBusqueda,
                    MargenConPrecio = tbMargenConPrecioBE,
                    //MargenSugerido = tbMargenSugeridoBE,
                    PesoLitro = tbPesoLitroBE,
                    Precio = tbPrecioBE,
                    ModoElaboracion = txtinstruccionesBE,
                    CantidadElaboracion = tbCantidadElaboracionBE,
                    //CantidadDiario = tbCantidadDiario,
                    UnidadElaboracion = cbUnidadElaboracionBE,
                    PrecioTotal = tbPrecioTotalBE
                });
            else
            {
                tabCon.TabPages.Remove(tabPage1);
                BeginInvoke((MethodInvoker)(() =>
                {
                    #region edicion de Presupuesto
                    tbPesoLitroBE.Text = tbPesoLitroBE.Text=="" ? @"0" : tbPesoLitroBE.Text;
                 
                    Reccid = Reccid == 0 ? 0 : Local.Receta.RecId;
                    var objeto = new Receta.ActualizaPresupuesto
                    {
                        RecId = Local.Receta.RecId,
                        Clave = tbBuscarReceta.Text,
                        CostoElaboracion = Convert.ToDouble(tbCostoElaboracionBE.Text),
                        CostoCreacion = Convert.ToDouble(tbCostoEstimadoBE.Text),
                        Margen = Convert.ToDouble(tbMargenConPrecioBE.Text),
                        TiporId = cbTipoBE.SelectedIndex + 1,
                        Descripcion = tbDescripcionBE.Text,
                        PesoLitro = Convert.ToDouble(tbPesoLitroBE.Text),
                        Precio = Convert.ToDouble(tbPrecioBE.Text),
                        PrecioTotal=Convert.ToDouble(tbPrecioTotalBE.Text),
                        //Diario = checadodiario,
                        //CantidadDiario = Convert.ToDouble(tbCantidadDiarioBE.Text),
                        CantidadElaboracion = Convert.ToDouble(tbCantidadElaboracionBE.Text),
                        UnidadElaboracion = cbUnidadElaboracionBE.SelectedIndex + 1
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
                                PrecioTotal = precioTotal

                            });
                        }
                        Data.Receta.Detalle.Eliminar();
                        Data.Receta.Detalle.ActualizarIngredientes(listaingredientes);

                    }));
                    #endregion
                    #region actualiza Ruta de imagen e Instrucciones
                    BeginInvoke((MethodInvoker)(() =>
                    {
                        long a = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
                        //if (Local.Receta.Ruta==null || Local.Receta.Ruta==String.Empty)
                        //{
                        //    //openFileDialog1.Filter =
                        //    //    @"Image Files (*.png *.jpg *.bmp) | *.png; *.jpg; *.bmp | All Files(*.*) | *.* ";
                        //    //openFileDialog1.Title = @"Buscar Imagen";
                        //    //openFileDialog1.FileName = "";
                        //    //openFileDialog1.ShowDialog();
                        //}
                        //else
                        //{
                        //    //var otro = Local.Receta.Ruta;
                        //    //var final = otro.Length - 31;
                        //    //var mundo = otro.Substring(31, final);
                        //    //// ReSharper disable once ObjectCreationAsStatement
                        //    //new Uri(@"file://mercattoserver/Recetario/img/" + mundo, UriKind.Absolute);
                        //    //System.IO.File.Delete(@"\\mercattoserver\\C$\Recetario\img\" + mundo);
                        //    //openFileDialog1.Filter = @"Image Files (*.png *.jpg *.bmp) | *.png; *.jpg; *.bmp | All Files(*.*) | *.* ";
                        //    //openFileDialog1.Title = @"Buscar Imagen";
                        //    //openFileDialog1.FileName = "";
                        //    //openFileDialog1.ShowDialog();
                        //}
                        if(_agregarImagen || !string.IsNullOrEmpty(Pbreceta.ImageLocation) && Pbreceta.ImageLocation!=null)
                        {
                        var listainstruccionesv1 = new Receta.ImagenAndProcess
                        {
                            RecId = Local.Receta.RecId,
                            Instrucciones = txtinstruccionesBE.Text,
                            RutaImagen = @"\\mercattoserver\Recetario\img\" + tbBuscarReceta.Text + a.ToString() + ".jpg"
                         };
                        Data.ReporteCocina.InsertarRutaeImagen(listainstruccionesv1);
                        Opcion.Copycmdserver(openFileDialog1.FileName, @"\\mercattoserver\Recetario\img\" + tbBuscarReceta.Text + a.ToString() + ".jpg");
                       }
                    if(_agregarImagen==false && openFileDialog1.FileName==null || string.IsNullOrEmpty(Pbreceta.ImageLocation)) 
                    {
                        var listainstruccionesv1 = new Receta.ImagenAndProcess
                        {
                            RecId = Local.Receta.RecId,
                            Instrucciones = txtinstruccionesBE.Text,
                            RutaImagen = ""
                        };
                        if (txtinstruccionesBE.Text != Local.Receta.Ingredientes)
                        {
                            Data.Receta.Detalle.Eliminarrutaeimagen();
                            Data.ReporteCocina.InsertarRutaeImagen(listainstruccionesv1);
                        }
                    }
                        //tabCon.TabPages.Remove(tabPage1);

                        _agregarImagen = false;
                    }));

                    #endregion
                }));
                MessageBox.Show(@"Los Datos de la Receta se han actualizado correctamente");
                Limpiarbusqueda();
            } 
        }
        private void Guardar(Inputs inputs)
        {
            btGuardar.Enabled = false;
            Local.Receta.Clave = (inputs.ClaveReceta.Text);
            if (ValidarCamposBe())
            {
                Opcion.EjecucionAsync(Data.Receta.Lista, jsonResult =>
                {
                    if (!ValidarClave(inputs.ClaveReceta, jsonResult)) return;
                    var mde = new MensajeDeEspera();
                    BeginInvoke((MethodInvoker)(() =>
                    {
                        var checadodiario = chDiario.Checked ? 1 : 0;
                        if (checadodiario != 0)
                        {
                            cbUnidadElaboracionBE.Text = Convert.ToString(cbUnidadElaboracionBE.SelectedIndex + 3);
                            tbCantidadElaboracionBE.Text = tbCantidadDiarioBE.Text;
                        }
                        else
                        {
                            tbCantidadDiarioBE.Text = @"0";
                        }
                        mde.Show();
                        var receta = new Receta
                        {
       
                            RecId = Local.Receta.RecId,
                            Clave = tbBuscarReceta.Text,
                            CostoElaboracion = Convert.ToDouble(tbCostoElaboracionBE.Text),
                            CostoCreacion = Convert.ToDouble(tbCostoEstimadoBE.Text),
                            Margen = Convert.ToDouble(tbMargenConPrecioBE.Text),
                            TiporId = cbTipoBE.SelectedIndex + 1,
                            Descripcion = tbDescripcionBE.Text,
                            PesoLitro = Convert.ToDouble(tbPesoLitroBE.Text),
                            Precio = Convert.ToDouble(tbPrecioBE.Text),
                            PrecioTotal = Convert.ToDouble(tbPrecioTotalBE.Text),
                            //Diario = checadodiario,
                            //CantidadDiario = Convert.ToDouble(tbCantidadDiarioBE.Text),
                            CantidadElaboracion = Convert.ToDouble(tbCantidadElaboracionBE.Text),
                            UnidadElaboracion = cbUnidadElaboracionBE.SelectedIndex + 1
                        };
                        Data.Receta.CReceta = receta;
                        Opcion.EjecucionAsync(Data.Receta.Insertar, resultado =>
                        {
                            Guardado(resultado, inputs);
                        }, x =>
                        {
                            Limpiar(inputs, mde);
                        });
                    }));
                });
            }
        }
        private void Guardado(Action<IRestResponse> x, Inputs inputs)
        {
            var listRecetaDetalle = new List<Receta.Detalle>();
            BeginInvoke((MethodInvoker)(() => {
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
            }
            ));
            #region insertar o actualizar
            BeginInvoke((MethodInvoker)(() =>
            {
                if (tabCon.SelectedTab == tabCon.TabPages[0])
                {
                    Data.Receta.Detalle.CRecetaDetalle = listRecetaDetalle;

                    #region Insertar imagen y copiar a ruta       

                    long a = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
                    if (_agregarImagen)
                    {
                        var listainstruccionesv1 = new Receta.ImagenAndProcess
                        {
                            RecId = Data.Receta.CReceta.RecId,
                            Instrucciones = txtinstruccionesBE.Text,
                            RutaImagen = @"\\mercattoserver\Recetario\img\" + tbBuscarReceta.Text + a.ToString() + ".jpg"
                        };
                        Data.ReporteCocina.InsertarRutaeImagen(listainstruccionesv1);
                        Opcion.Copycmdserver(openFileDialog1.FileName, @"\\mercattoserver\Recetario\img\" + tbBuscarReceta.Text + a.ToString() + ".jpg");
                    }
                    else
                    {
                        var instructivo = new Receta.ImagenAndProcess
                        {
                            RecId = Data.Receta.CReceta.RecId,
                            Instrucciones = inputs.ModoElaboracion.Text,
                            RutaImagen = ""
                        };
                        Data.ReporteCocina.InsertarRutaeImagen(instructivo);
                    }

     
                    _agregarImagen = false;
                    //if (MessageBox.Show(@"Desea agregar la imagen de la Receta", @"Aviso", MessageBoxButtons.YesNo,

                    //                  MessageBoxIcon.Question) == DialogResult.Yes)
                    //{
                    //    //openFileDialog1.Filter = @"Image Files (*.png *.jpg *.bmp *.jpeg *.gif) | *.png; *.jpg; *.bmp; *.jpeg  | All Files(*.*) | *.* ";
                    //    //openFileDialog1.Title = @"Buscar Imagen";
                    //    //openFileDialog1.FileName = "";
                    //    //openFileDialog1.ShowDialog();
                    //    long a = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
                    //    var image =Convert.ToString( Pbreceta);
                    //    var dd = @"\\mercattoserver\Recetario\img\" + inputs.ClaveReceta.Text + a.ToString() + ".jpg";
                    //    image = dd;


                    //    var instructivo = new Receta.ImagenAndProcess
                    //    {
                    //        RecId = Data.Receta.CReceta.RecId,
                    //        Instrucciones = inputs.ModoElaboracion.Text,
                    //        RutaImagen = image
                    //    };
                    //    Data.ReporteCocina.InsertarRutaeImagen(instructivo);
                    //    Opcion.Copycmdserver(openFileDialog1.FileName, @"\\mercattoserver\Recetario\img\" + inputs.ClaveReceta.Text + a.ToString() + ".jpg");
                    //}

                    //else
                    //{
                    //    var instructivo = new Receta.ImagenAndProcess
                    //    {
                    //        RecId = Data.Receta.CReceta.RecId,
                    //        Instrucciones = inputs.ModoElaboracion.Text,
                    //        RutaImagen = ""
                    //    };
                    //    Data.ReporteCocina.InsertarRutaeImagen(instructivo);

                    //}
                    #endregion
                    Data.Receta.Detalle.InsertarDetalle(x);
                }
                else
                {
                    Data.Receta.Detalle.ARecetaDetalle = listRecetaDetalle;
                    Data.Receta.Detalle.InsertarDetalle(x);
                }
            }));
            #endregion    
        }
        #endregion
        #region Limpiar
        private void Limpiar(Inputs inputs, MensajeDeEspera mde)
        {
            BeginInvoke((MethodInvoker)(() =>
            {
                mde?.Close();
                MessageBox.Show(this, @"Se a guardado con éxito  Clave :" + inputs.ClaveReceta.Text);
                inputs.ClaveReceta.Text = "";
                inputs.CantidadElaboracion.Text = "";
                inputs.Precio.Text = "";
                inputs.PesoLitro.Text = "";
                inputs.Descripcion.Text = "";
                inputs.TipoReceta.TabIndex = 0;
                inputs.UnidadElaboracion.TabIndex = 0;
                inputs.MargenConPrecio.Text = "";
                inputs.MargenConPrecio.Text = Convert.ToString("");
                inputs.ModoElaboracion.Text = "";
                inputs.CostoElaboracion.Text = "";
                inputs.CostoEstimado.Text = "";
                inputs.CostoEstimado.Text = null;
                inputs.CostoEstimado.Clear();
                inputs.PrecioTotal.Text = "";
                inputs.CostoEstimado.Text = Convert.ToString("0");
                inputs.Ingredientes.DataSource = null;
                inputs.Ingredientes.DataSource = "";
                inputs.Ingredientes.Columns.Clear();
                //inputs.Ingredientes.Rows.Clear();
                inputs.Ingredientes.Update();
                mde?.Close();
            }));
        }
        public void Limpiarbusqueda()
        {
            txtClave.Text = "";
            tbCodigoBE.Text = "";
            tbBuscarReceta.Text = "";
            tbDescripcionBE.Text = "";
            tbPesoLitroBE.Text = "";
            tbCantidadElaboracionBE.Text = "";
            cbUnidadElaboracionBE.SelectedIndex = 0;
            cbTipoBE.SelectedIndex =0;
            tbCostoElaboracionBE.Text = "";
            tbMargenConPrecioBE.Text = "";
            tbMargenConPrecioBE.Text = Convert.ToString("");
            tbMargenSugeridoBE.Text = "";
            tbPrecioSugeridoBE.Text = "";
            tbPrecioBE.Text = "";
            tbPrecioTotalBE.Text = "";
            txtinstruccionesBE.Text = "";
            tbCostoEstimadoBE.Text = "";
            tbCostoEstimadoBE.Clear();
            tbCostoEstimadoBE.Text = null;
            tbCostoEstimadoBE.Text = Convert.ToString("0");
            Pbreceta.ImageLocation = @"\\mercattoserver\Recetario\img\sinimagen.jpg";
            dgvIngredientesBusqueda.DataSource = null;
            dgvIngredientesBusqueda.DataSource = "";
        }
        #endregion
        private void btBuscarClave_Click(object sender, EventArgs e)
        {
          
            Cocina.DetalleCocina.Clave = tbBuscarReceta.Text == string.Empty ? "%" : tbBuscarReceta.Text;
            Opcion.EjecucionAsync(Data.ReporteCocina.BuscarRecetav2, jsonResult =>
            {
                if (jsonResult!=null)
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
                                         Reccid = Local.Receta.RecId;
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
                                         tbPesoLitroBE.Text = resultado.PesoLitro.ToString(CultureInfo.InvariantCulture);
                                         tbCostoElaboracionBE.Text = resultado.CostoElaboracion.ToString(CultureInfo.InvariantCulture);
                                         tbPrecioBE.Text = resultado.Precio.ToString(CultureInfo.InvariantCulture);
                                         tbPrecioTotalBE.Text = resultado.PrecioTotal.ToString(CultureInfo.InvariantCulture);
                                         tbDescripcionBE.Text = resultado.Descripcion;/*@"Receta:"+ resultado.Descripcion + @"   
                                       " +@"Clave:" + resultado.Clave;*/
                                         txtClave.Text = resultado.Clave;
                                         cbTipoBE.SelectedIndex = resultado.TiporId - 1;
                                         cbUnidadElaboracionBE.SelectedIndex = resultado.UnidadElaboracion - 1;
                                         ActualizarInputs(new Inputs
                                         {
                                             ActualizarMargen = ActualizarMargen,
                                             Precio = tbPrecioBE,
                                             PrecioTotal=tbPrecioTotalBE,
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
                                             //Diario = chDiarioBE,
                                             //TipoReceta = cbTipoBE,
                                             CantidadElaboracion = tbCantidadElaboracionBE,
                                             UnidadElaboracion = cbUnidadElaboracionBE,
                                             //CantidadDiario = tbCantidadDiarioBE
                                         });

                                         tbMargenConPrecioBE.Text = resultado.Margen.ToString(CultureInfo.InvariantCulture);
                                         tbBuscarReceta.Text = resultado.Clave;
                                         tbBuscarReceta.ForeColor = Color.WhiteSmoke;
                                         cbTipoBE.SelectedIndex = resultado.TiporId - 1;
                                         tbCostoEstimadoBE.Text = resultado.CostoCreacion.ToString(CultureInfo.InvariantCulture);
                                         //chDiarioBE.Checked = (resultado.Diario == 1);
                                         tbCodigoBE.Enabled = true;
                                         tbCantidadElaboracionBE.Text = resultado.CantidadElaboracion.ToString(CultureInfo.InvariantCulture);
                                         cbUnidadElaboracionBE.SelectedIndex = resultado.UnidadElaboracion - 1;
                                         var datos = resultado.Instrucciones;
                                         txtinstruccionesBE.Text = datos;
                                         var calis = resultado.Rutaimagen;
                                         if (calis == null)
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
            }
            else
                {
                    Opcion.EjecucionAsync(Data.ReporteCocina.BuscarRecetaArticulos, t =>
                    {
                            BeginInvoke((MethodInvoker)(() =>
                            {
                                switch (t.StatusCode)
                                {
                                    case HttpStatusCode.OK:
                                        var brd =
                                         new BusquedaRecetaDetalle(Opcion.JsonaListaGenerica<Receta>(t),
                                             resultado =>
                                             {
                                                 BeginInvoke((MethodInvoker)(() =>
                                                 {
                                                     Local.Receta.RecId = resultado.RecId;
                                                     Reccid = Local.Receta.RecId;
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
                                                     tbPesoLitroBE.Text = resultado.PesoLitro.ToString(CultureInfo.InvariantCulture);
                                                     tbCostoElaboracionBE.Text = resultado.CostoElaboracion.ToString(CultureInfo.InvariantCulture);
                                                     tbPrecioBE.Text = resultado.Precio.ToString(CultureInfo.InvariantCulture);
                                                     tbPrecioTotalBE.Text = resultado.PrecioTotal.ToString(CultureInfo.InvariantCulture);
                                                     tbDescripcionBE.Text = resultado.Descripcion;
                                                     txtClave.Text = resultado.Clave;
                                                     cbTipoBE.SelectedIndex = resultado.TiporId - 1;
                                                     cbUnidadElaboracionBE.SelectedIndex = resultado.UnidadElaboracion - 1;
                                                     ActualizarInputs(new Inputs
                                                     {
                                                         ActualizarMargen = ActualizarMargen,
                                                         Precio = tbPrecioBE,
                                                         PrecioTotal = tbPrecioTotalBE,
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
                                             //Diario = chDiarioBE,
                                                          TipoReceta = cbTipoBE,
                                                         CantidadElaboracion = tbCantidadElaboracionBE,
                                                         UnidadElaboracion = cbUnidadElaboracionBE,
                                             //CantidadDiario = tbCantidadDiarioBE
                                         });

                                                     tbMargenConPrecioBE.Text = resultado.Margen.ToString(CultureInfo.InvariantCulture);
                                                     tbBuscarReceta.Text = resultado.Clave;
                                                     cbTipoBE.SelectedIndex = resultado.TiporId - 1;
                                                     tbCostoEstimadoBE.Text = resultado.CostoCreacion.ToString(CultureInfo.InvariantCulture);
                                         //chDiarioBE.Checked = (resultado.Diario == 1);
                                         tbCodigoBE.Enabled = true;
                                                     tbCantidadElaboracionBE.Text = resultado.CantidadElaboracion.ToString(CultureInfo.InvariantCulture);
                                                     cbUnidadElaboracionBE.SelectedIndex = resultado.UnidadElaboracion - 1;
                                                     var datos = resultado.Instrucciones;
                                                     txtinstruccionesBE.Text = datos;
                                                     var calis = resultado.Rutaimagen;
                                                     if (calis == null)
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
                                        Console.WriteLine(t.Content);
                                        Pbreceta.Image = Image.FromFile(@"\\mercattoserver\Recetario\img\sinimagen.jpg");
                                        break;
                                }
                            }));
                    });
                    btGuardar.Enabled = true;

                }
            });
            btGuardar.Enabled = true;
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
                PrecioTotal=tbPrecioTotalBE,
                TipoReceta = cbTipoBE,
                MargenConPrecio = tbMargenConPrecioBE,
                ActualizarMargen = ActualizarMargen,
                CantidadElaboracion = tbCantidadElaboracionBE,
                UnidadElaboracion = cbUnidadElaboracionBE,
                //CantidadDiario = tbCantidadDiarioBE
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
            btGuardar.Enabled = ValidarCampos();
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
            if (e.KeyChar == 13 && ValidarBusquedaVacia())
            {
                btBuscar_Click(sender, new EventArgs());
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
            ActualizarInputs(new Inputs
            {
                ActualizarMargen = ActualizarMargen,
                CostoElaboracion = tbCostoElaboracionBE,
                CostoEstimado = tbCostoEstimadoBE,
                Ingredientes = dgvIngredientesBusqueda,
                MargenSugerido = tbMargenSugeridoBE,
                MargenConPrecio = tbMargenConPrecioBE,
                PrecioSugerido = tbPrecioSugeridoBE,
                Precio = tbPrecioBE,
                PrecioTotal=tbPrecioTotalBE,
                PesoLitro = tbPesoLitroBE,
                TipoReceta = cbTipoBE,
                CantidadElaboracion = tbCantidadElaboracionBE,
                UnidadElaboracion = cbUnidadElaboracionBE
            });
            MessageBox.Show(this, @"Registro eliminado con exito");
        }
        private void btBorrarListaBE_Click(object sender, EventArgs e)
        {
            Opcion.BorrarDataGridView(dgvIngredientesBusqueda);
            MessageBox.Show(this, @"Lista eliminada con exito");
            tbPrecioTotalBE.Text = "";
            tbMargenConPrecioBE.Text = "";
            tbCostoElaboracionBE.Text = "";     
        }
        private bool ValidarBusquedaVacia1()
        {
            return tbCodigoBE.Text.Trim().Length > 0;
        }
        private bool ValidarBusquedaVacia2()
        {
            return tbBuscarReceta.Text.Trim().Length > 0;
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
            ActualizarInputs(new Inputs
            {
                CostoElaboracion = tbCostoElaboracion,
                CostoEstimado = tbCostoEstimado,
                Ingredientes = dgvIngredientes,
                MargenSugerido = tbMargenSugerido,
                PrecioSugerido = tbPrecioSugerido,
                TipoReceta = cbTipoReceta,
                MargenConPrecio = tbMargenConPrecio,
                PesoLitro = tbPesoLitroBE,
                Precio = tbPrecioBE,
                ActualizarMargen = ActualizarMargen,
                CantidadElaboracion = tbCantidadElaboracion,
                UnidadElaboracion = cbUnidadElaboracion
            });
        }
        private void tbBuscarReceta_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btBuscarClave_Click(sender, new EventArgs());
            }
        }
        private void tbDescripcionBE_TextChanged(object sender, EventArgs e)
        {
            btGuardar.Enabled = ValidarCamposBe();
        }
        private void chDiario_CheckedChanged(object sender, EventArgs e)
        {
            //if (chDiario.Checked)
            //{
            //    tbCantidadDiario.Visible = true;
            //    lbCantidadDiario.Visible = true;
            //    tbCantidadElaboracion.Visible = false;
            //    cbUnidadElaboracion.Visible = false;
            //    lbCantidadElaboracion.Visible = false;
            //    Validar = 1;
            //}
            //else
            //{
            //    tbCantidadDiario.Visible = false;
            //    lbCantidadDiario.Visible = false;
            //    tbCantidadElaboracion.Visible = true;
            //    cbUnidadElaboracion.Visible = true;
            //    lbCantidadElaboracion.Visible = true;
            //}
        }
        private void chDiarioBE_CheckedChanged(object sender, EventArgs e)
        {
            //if (chDiarioBE.Checked)
            //{
            //    tbCantidadDiarioBE.Visible = true;
            //    lbCantidadDiarioBE.Visible = true;
            //    tbCantidadElaboracionBE.Visible = false;
            //    cbUnidadElaboracionBE.Visible = false;
            //    lbCantidadElaboracionBE.Visible = false;
            //    Validar = 1;
            //}
            //else
            //{
            //    tbCantidadDiarioBE.Visible = false;
            //    lbCantidadDiarioBE.Visible = false;
            //    tbCantidadElaboracionBE.Visible = true;
            //    cbUnidadElaboracionBE.Visible = true;
            //    lbCantidadElaboracionBE.Visible = true;
            //}
        }
        private void tbCantidadElaboracion_TextChanged(object sender, EventArgs e)
        {
            Opcion.ValidarDouble(tbCantidadElaboracion);
            btGuardar.Enabled = ValidarCampos();
        }
        private void tbCantidadDiario_TextChanged(object sender, EventArgs e)
        {
            //Opcion.ValidarDouble(tbCantidadDiario);
        }
        private void tbCantidadElaboracionBE_TextChanged(object sender, EventArgs e)
        {
            Opcion.ValidarDouble(tbCantidadElaboracionBE);
            btGuardar.Enabled = ValidarCamposBe();
        }
        private void tbCantidadDiarioBE_TextChanged(object sender, EventArgs e)
        {
            //Opcion.ValidarDouble(tbCantidadDiarioBE);
        }
        private void tbMargenConPrecio_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //if (tbMargenConPrecio.Text == "") return;
            //if (!(Convert.ToDouble(tbMargenConPrecio.Text) < 30)) return;
            //MessageBox.Show(@"El margen no puede ser menor al 30%");
            //tbMargenConPrecio.Clear();
            //tbMargenConPrecio.Focus();
        }
        private void tbMargenConPrecioBE_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //if (Convert.ToDouble(tbMargenConPrecioBE.Text) <= 0)
            //{
            //    MessageBox.Show(@"La receta no cuenta con un margen, revisar los costos");

            //}
        }
        private void tbCostoEstimado_TextChanged(object sender, EventArgs e)
        {
            if (!Opcion.ValidarDouble(tbCostoEstimado)) return;
            ActualizarInputs(new Inputs
            {
                ActualizarMargen = ActualizarMargen,
                CostoElaboracion = tbCostoElaboracion,
                CostoEstimado = tbCostoEstimado,
                Ingredientes = dgvIngredientes,
                MargenSugerido = tbMargenSugerido,
                MargenConPrecio = tbMargenConPrecio,
                PrecioSugerido = tbPrecioSugerido,
                Precio = tbPrecio,
                PesoLitro = tbPesoLitro,
                TipoReceta = cbTipoReceta,
                CantidadElaboracion = tbCantidadElaboracion,
                UnidadElaboracion = cbUnidadElaboracion
            });
        }
        private void tbCostoEstimadoBE_TextChanged(object sender, EventArgs e)
      {
            if (!Opcion.ValidarDouble(tbCostoEstimadoBE)) return;
            ActualizarInputs(new Inputs
            {
                ActualizarMargen = ActualizarMargen,
                CostoElaboracion = tbCostoElaboracionBE,
                CostoEstimado = tbCostoEstimadoBE,
                Ingredientes = dgvIngredientesBusqueda,
                MargenSugerido = tbMargenSugeridoBE,
                MargenConPrecio = tbMargenConPrecioBE,
                PrecioSugerido = tbPrecioSugeridoBE,
                Precio = tbPrecioBE,
                PrecioTotal=tbPrecioTotalBE,
                PesoLitro = tbPesoLitroBE,
                TipoReceta = cbTipoBE,
                CantidadElaboracion = tbCantidadElaboracionBE,
                UnidadElaboracion = cbUnidadElaboracionBE
            });
        }
        private void dgvIngredientes_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            ActualizarInputs(new Inputs
            {
                ActualizarMargen = ActualizarMargen,
                CostoElaboracion = tbCostoElaboracionBE,
                CostoEstimado = tbCostoEstimadoBE,
                Ingredientes = dgvIngredientesBusqueda,
                MargenSugerido = tbMargenSugeridoBE,
                MargenConPrecio = tbMargenConPrecioBE,
                PrecioSugerido = tbPrecioSugeridoBE,
                Precio = tbPrecioBE,
                PrecioTotal=tbPrecioTotalBE,
                PesoLitro = tbPesoLitroBE,
                TipoReceta = cbTipoBE,
                CantidadElaboracion = tbCantidadElaboracionBE,
                UnidadElaboracion = cbUnidadElaboracionBE
            });
        }
        private void dgvIngredientesBusqueda_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            ActualizarInputs(new Inputs
            {
                ActualizarMargen = ActualizarMargen,
                CostoElaboracion = tbCostoElaboracionBE,
                CostoEstimado = tbCostoEstimadoBE,
                Ingredientes = dgvIngredientesBusqueda,
                MargenSugerido = tbMargenSugeridoBE,
                MargenConPrecio = tbMargenConPrecioBE,
                PrecioSugerido = tbPrecioSugeridoBE,
                Precio = tbPrecioBE,
                PrecioTotal=tbPrecioTotalBE,
                PesoLitro = tbPesoLitroBE,
                TipoReceta = cbTipoBE,
                CantidadElaboracion = tbCantidadElaboracionBE,
                UnidadElaboracion = cbUnidadElaboracionBE
            });
        }
        private void txtinstrucciones_TextChanged(object sender, EventArgs e)
        {
            btGuardar.Enabled = ValidarCampos();
        }
        private void txtinstruccionesBE_TextChanged(object sender, EventArgs e)
        {
            btGuardar.Enabled = ValidarCamposBe();
        }
        private void tbCostoElaboracionBE_TextChanged(object sender, EventArgs e)
        {
            if (!Opcion.ValidarDouble(tbCostoEstimadoBE)) return;
            ActualizarMargen(new Inputs
            {
                MargenConPrecio = tbMargenConPrecioBE,
                Ingredientes = dgvIngredientesBusqueda,
                CostoElaboracion = tbCostoElaboracionBE,
                Precio = tbPrecioBE,
                PrecioTotal=tbPrecioTotalBE,
                CostoEstimado = tbCostoEstimadoBE,
                ActualizarMargen = ActualizarMargen
            });
            btGuardar.Enabled = ValidarCamposBe();
        }
        private void tbPesoLitroBE_TextChanged(object sender, EventArgs e)
        {
            btGuardar.Enabled = true;
        }
        private void tbBuscarReceta_TextChanged(object sender, EventArgs e)
        {
            btBuscarClave.Enabled = ValidarBusquedaVacia2();
        }
        private void tabCon_SelectedIndexChanged(object sender, EventArgs e)
        {
            btGuardar.Text = tabCon.SelectedTab == tabCon.TabPages[1] ? @"Guardar" : @"Guardar y Actualizar";
        }
        private void dgvIngredientesBusqueda_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvIngredientesBusqueda.Rows[e.RowIndex].Cells[0].ReadOnly = true;
            dgvIngredientesBusqueda.Rows[e.RowIndex].Cells[1].ReadOnly = true;
            dgvIngredientesBusqueda.Rows[e.RowIndex].Cells[2].ReadOnly = true;
            dgvIngredientesBusqueda.Rows[e.RowIndex].Cells[3].ReadOnly = true;
        }

        private void dgvIngredientesBusqueda_CurrentCellChanged(object sender, EventArgs e)
        {
            for (var i = 0; i < dgvIngredientesBusqueda.RowCount; i++)
            {
                dgvIngredientesBusqueda.Rows[i].Cells[0].ReadOnly = true;
                dgvIngredientesBusqueda.Rows[i].Cells[1].ReadOnly = true;
                dgvIngredientesBusqueda.Rows[i].Cells[2].ReadOnly = true;
                dgvIngredientesBusqueda.Rows[i].Cells[3].ReadOnly = true;
                dgvIngredientesBusqueda.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvIngredientesBusqueda.DefaultCellStyle.Font = new Font("Arial", 9);
                dgvIngredientesBusqueda.Columns[0].Width = 60;
                dgvIngredientesBusqueda.Columns["Clave"].Width = 90;
                dgvIngredientesBusqueda.Columns["Cantidad"].Width = 110;
                dgvIngredientesBusqueda.Columns["Descripcion"].Width = 270;
                dgvIngredientesBusqueda.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvIngredientesBusqueda.Columns["PrecioCompra"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }   

        }
        private void dgvIngredientesBusqueda_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception != null &&
                e.Context == DataGridViewDataErrorContexts.Commit)
            {
                dgvIngredientesBusqueda.Rows[e.RowIndex].Cells["Cantidad"].Value = @"1";
            }
        }
        private void tbPrecioBE_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Si deseas modificar el precio de la receta, realizalo desde SICAR");
        }

        //private void btActualizacion_Click(object sender, EventArgs e)
        //{
        //    ActualizarPrecios frm = new ActualizarPrecios();
        //    frm.Show();
        //}

        private void tbPrecioTotalBE_TextChanged(object sender, EventArgs e)
        {
            if (!Opcion.ValidarDouble(tbPrecioBE)) return;
            ActualizarMargen(new Inputs
            {
                MargenConPrecio = tbMargenConPrecioBE,
                Ingredientes = dgvIngredientesBusqueda,
                CostoElaboracion = tbCostoElaboracionBE,
                PrecioTotal = tbPrecioTotalBE,
                CostoEstimado = tbCostoEstimadoBE,
                ActualizarMargen = ActualizarMargen
            });
            btGuardar.Enabled = ValidarCamposBe();

        }

        private void tmActualizar_Tick(object sender, EventArgs e)
        {
            
            //if (y==6)
            //{
            //    Data.Reporte.ExistenciProductoActualizar(t =>
            //    {
            //        switch (t.StatusCode)
            //        {
            //            case HttpStatusCode.OK:
            //                var actprecio = new ActualizarPrecios();
            //                actprecio.Show();
            //                //tmActualizar.Stop();
            //               // tmActualizar.Enabled = false;
            //               // y = 0;
            //                break;
            //        }

            //    });

            //}
            //y = y + 1;
            ////for (int i = 0; i <= 5; i++)
            ////{
            ////    //var comprobacion;
            ////    if (i == 3)
            ////    {


            ////    }

            ////}

        }
        private bool _agregarImagen= false;

        private void btImagen_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(@"Desea agregar la imagen de la receta", @"Aviso", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _agregarImagen = true;
                if (Local.Receta.Ruta == null || Local.Receta.Ruta == String.Empty)
                {
                    openFileDialog1.Filter = @"Image Files (*.png *.jpg *.bmp) | *.png; *.jpg; *.bmp | All Files(*.*) | *.* ";
                    openFileDialog1.Title = @"Buscar Imagen";
                    openFileDialog1.FileName = "";
                    DialogResult result = openFileDialog1.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        Pbreceta.Image = Image.FromFile(openFileDialog1.FileName);
                    }
                }
                else
                {
                    var otro = Local.Receta.Ruta;
                    var final = otro.Length - 31;
                    var mundo = otro.Substring(31, final);
                    // ReSharper disable once ObjectCreationAsStatement
                    new Uri(@"file://mercattoserver/Recetario/img/" + mundo, UriKind.Absolute);
                    System.IO.File.Delete(@"\\mercattoserver\\C$\Recetario\img\" + mundo);
                    openFileDialog1.Filter = @"Image Files (*.png *.jpg *.bmp) | *.png; *.jpg; *.bmp | All Files(*.*) | *.* ";
                    openFileDialog1.Title = @"Buscar Imagen";
                    openFileDialog1.FileName = "";
                    DialogResult result = openFileDialog1.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        Pbreceta.Image = Image.FromFile(openFileDialog1.FileName);
                    }
                }
            }
       }

        private void btImprimirReceta_Click(object sender, EventArgs e)
        {
            Cocina.DetalleCocina.Clave = tbBuscarReceta.Text == string.Empty ? "%" : tbBuscarReceta.Text;
           
            Opcion.EjecucionAsync(x =>
            {
                var detallereceta = new Cocina.DetalleCocina.ReporteDetalle
                {
                    clave = tbBuscarReceta.Text
                };
                Data.ReporteCocina.DDetalleReceta(x, detallereceta);
            }, jsonResult =>
            {
               Reporte.RespuestaCocina listaCocina= Opcion.JsonaListaGenerica<Reporte.RespuestaCocina>(jsonResult)[0];
                var addIn = Globals.ThisAddIn;
                addIn.DatosReceta(listaCocina);
            }
            );        
        }

        private void tbBuscarReceta_Click(object sender, EventArgs e)
        {
            tbBuscarReceta.ForeColor = Color.Black;
        }
    }
}