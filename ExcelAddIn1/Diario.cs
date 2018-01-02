using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Herramienta;
using Herramienta.Config;
using Respuesta;
using System.Net;


namespace ExcelAddIn1
{
    public partial class Diario : Form
    {
        public int Valor = 0;
        public int InNdex;
        public int IndeXx;
        private List<IngredientesReceta> _listaArticuloBasica1;
        // ReSharper disable once FieldCanBeMadeReadOnly.Local
        private List<IngredientesReceta> _listaArticuloBasica2;
        private List<IngredientesReceta> _listaArticuloBasica3;
        private BindingList<Reporte.RespuestaCocina.RepoDiario> _listaPlatilloHoy;
        private BindingList<Respuesta.Diario> _listainventario;
        private BindingList<Reporte.RespuestaCocina.Comprobacion> _listinvcomprobacion;
        public int EstadoInventarioIdd;
        public Diario()
        {
            _listinvcomprobacion= new BindingList<Reporte.RespuestaCocina.Comprobacion>();
            _listainventario=new BindingList<Respuesta.Diario>();
            _listaArticuloBasica1 = new List<IngredientesReceta>();
            _listaArticuloBasica2 = new List<IngredientesReceta>();
            _listaArticuloBasica3 = new List<IngredientesReceta>();
            _listaPlatilloHoy=new BindingList<Reporte.RespuestaCocina.RepoDiario>();
            InitializeComponent();
        }
        public class Final
        {
            public int Id { get; set; }
            public String Destino { get; set; }      
        }
     
        public List<Respuesta.Diario> Lista;
        public List<DiarioX2> ListaX2S;
        public List<Reporte.RespuestaCocina.Comprobacion> ListDiarioDs;
        public List<Cocina.ReporteDiarioCocina.FechasReporte> ListfechasList;
        public int Xyz;

        private void Diario_Load(object sender, EventArgs e)
        {
            dgvInventarioPlatillos.AllowUserToAddRows = true;

            PlatillosHoy();
            btGuardarDiarios.Enabled = false;
            btPreviaGlobal.Enabled = false;
            btPreviaPlatillo.Enabled = false;
            #region fechas

            var fecha = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd 07:00:00");
            var fecha1 = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd 22:00:00");
            var fecha1R = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
            var fechas = new Receta.Diaanterior
            {
                Fecha1 = fecha,
                Fecha2 = fecha1
            };

            Data.Reporte.AntesDiaanterior = fechas;
            Cocina.DiaAntesX2.FechaX2 = fecha1R;
            #endregion
            var col2 = new DataGridViewImageColumn
            {
                Name = "Guardar",
                DataPropertyName = " ",
                HeaderText = @"",

            };
            var me = new MensajeDeEspera();
            me.Show();
            Opcion.EjecucionAsync(Data.Reporte.Yesterday, jsonResult =>
                {
                    BeginInvoke((MethodInvoker)(() =>
                    {
                        me.Close();
                        _listainventario= new BindingList<Respuesta.Diario>(Opcion.JsonaListaGenerica<Respuesta.Diario>(jsonResult));
                        dgvInventarioPlatillos.DataSource = _listainventario;
                        dgvInventarioPlatillos.RowHeadersVisible = false;
                        dgvInventarioPlatillos.Columns.Add(col2);
                        //var column1 = dgvInventarioPlatillos.Columns["Clave"];
                        //if (column1 != null)
                        //    column1.ReadOnly = true;
                        //var dataGridViewColumn2 = dgvInventarioPlatillos.Columns["Platillo"];
                        //if (dataGridViewColumn2 != null)
                        //    dataGridViewColumn2.ReadOnly = true;
                        //var viewColumn2 = dgvInventarioPlatillos.Columns["CV"];
                        //if (viewColumn2 != null)
                        //    viewColumn2.ReadOnly = true;
                        //var gridViewColumn2 = dgvInventarioPlatillos.Columns["CP"];
                        //if (gridViewColumn2 != null)
                        //    gridViewColumn2.ReadOnly = true;
                        //var column2 = dgvInventarioPlatillos.Columns["S"];
                        //if (column2 != null)
                        //    column2.ReadOnly = true;
                        var dataGridViewColumn3 = dgvInventarioPlatillos.Columns["Unidad"];
                        if (dataGridViewColumn3 != null)
                            dataGridViewColumn3.ReadOnly = true;
                        var dataGridViewColumn = dgvInventarioPlatillos.Columns["Guardar"];
                        if (dataGridViewColumn != null) dataGridViewColumn.DisplayIndex = 9;
                        dgvInventarioPlatillos.DefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
                        var gridViewColumn = dgvInventarioPlatillos.Columns["Guardar"];
                        if (gridViewColumn != null) gridViewColumn.Width = 30;
                        dgvInventarioPlatillos.Columns[0].Visible = false;
                        var gridViewColumn1 = dgvInventarioPlatillos.Columns["EstadoInventarioId"];
                        if (gridViewColumn1 != null) gridViewColumn1.Visible = false;
                        dgvInventarioPlatillos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dgvInventarioPlatillos.Columns[1].Width = 100;
                        dgvInventarioPlatillos.Columns[2].Width = 370;
                        dgvInventarioPlatillos.Columns[3].Width = 60;
                        dgvInventarioPlatillos.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dgvInventarioPlatillos.Columns[4].Width = 60;
                        dgvInventarioPlatillos.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dgvInventarioPlatillos.Columns[5].Width = 60; dgvInventarioPlatillos.RowHeadersVisible = false;
                        dgvInventarioPlatillos.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dgvInventarioPlatillos.Columns[6].Width = 75;
                        dgvInventarioPlatillos.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dgvInventarioPlatillos.Columns[7].Width = 50;
                        dgvInventarioPlatillos.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dgvInventarioPlatillos.Columns[8].Width = 50;
                        dgvInventarioPlatillos.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dgvInventarioPlatillos.Columns[10].Width = 30;
                        var viewColumn = dgvInventarioPlatillos.Columns["Observacion"];
                        if (viewColumn != null) viewColumn.Width = 200;
                        dgvInventarioPlatillos.Columns["Guardar"].Width = 30;

                        var column = dgvInventarioPlatillos.Columns["CR"];
                        if (column != null)
                            column.DefaultCellStyle.BackColor = Color.Coral;
                        var dataGridViewColumn1 = dgvInventarioPlatillos.Columns["SR"];
                        if (dataGridViewColumn1 != null)
                            dataGridViewColumn1.DefaultCellStyle.BackColor = Color.Coral;
                        var viewColumn1 = dgvInventarioPlatillos.Columns["Observacion"];
                        if (viewColumn1 != null)
                            viewColumn1.DefaultCellStyle.BackColor = Color.Coral;
                        ActualizadoDgv();
                        dgvInventarioPlatillos.Enabled = true;
                        dgvInventarioPlatillos.AllowUserToAddRows = true;

                    }));
                });
        }
        public string Observacion;
        public string ObservacionActualizada;
        private void btGuardar_Click(object sender, EventArgs e)
        {
            var fecha = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
            const int estado = 1;
            const int estadonegativo = -1;
            var listEstado = new List<Receta.Savedaily>();
            var row = dgvInventarioPlatillos.CurrentCell.RowIndex;
            var inventarioid= Convert.ToInt32(dgvInventarioPlatillos.Rows[row].Cells["EstadoInventarioId"].Value);
                if (inventarioid == 0)
                {
                    var observacion1 = dgvInventarioPlatillos.Rows[row].Cells["Observacion"].Value;
                    if (observacion1 != null && (string)observacion1 != "")
                    {
                        Observacion = observacion1.ToString();
                    }
                    else
                    {
                        Observacion = "";
                    }
                    if (rbcongelado.Checked)
                    {

                        if (dgvInventarioPlatillos.CurrentRow != null)
                            listEstado.Add(new Receta.Savedaily
                            {
                                EstadoDescripcionId = 1,
                                ArtId = dgvInventarioPlatillos.CurrentRow.Cells[0].Value.ToString(),
                                Cantidad = Convert.ToDouble(dgvInventarioPlatillos.CurrentRow.Cells["SR"].Value),
                                Clave = dgvInventarioPlatillos.CurrentRow.Cells[1].Value.ToString(),
                                Platillo = dgvInventarioPlatillos.CurrentRow.Cells[2].Value.ToString(),
                                CantidadCocina = Convert.ToDouble(dgvInventarioPlatillos.CurrentRow.Cells["CR"].Value),
                                Status = estado.ToString(),
                                Observacion = Observacion,
                                Fecha = fecha
                            });
                        Data.MenuSemanal.Savedaily = listEstado;
                        Opcion.EjecucionAsync(Data.MenuSemanal.AgregarDiario, jsonResult =>
                        {
                            ActualizadoDgv();
                        });
                } 
                if (rbmerma.Checked)
                    {

                        if (dgvInventarioPlatillos.CurrentRow != null)
                            listEstado.Add(new Receta.Savedaily
                            {
                                EstadoDescripcionId = 2,
                                ArtId = dgvInventarioPlatillos.CurrentRow.Cells[0].Value.ToString(),
                                Cantidad = Convert.ToDouble(dgvInventarioPlatillos.CurrentRow.Cells["SR"].Value),
                                Clave = dgvInventarioPlatillos.CurrentRow.Cells[1].Value.ToString(),
                                Platillo = dgvInventarioPlatillos.CurrentRow.Cells[2].Value.ToString(),
                                CantidadCocina = Convert.ToDouble(dgvInventarioPlatillos.CurrentRow.Cells["CR"].Value),
                                Status = estadonegativo.ToString(),
                                Observacion = Observacion,
                                Fecha = fecha
                            });
                        Data.MenuSemanal.Savedaily = listEstado;
                        Opcion.EjecucionAsync(Data.MenuSemanal.AgregarDiario, jsonResult =>
                        {
                            ActualizadoDgv();
                        });
                    }           
                    if (rbreventa.Checked)
                    {
                        if (dgvInventarioPlatillos.CurrentRow != null)
                            listEstado.Add( new Receta.Savedaily
                            {
                                EstadoDescripcionId = 4,
                                ArtId = dgvInventarioPlatillos.CurrentRow.Cells[0].Value.ToString(),
                                Cantidad = Convert.ToDouble(dgvInventarioPlatillos.CurrentRow.Cells["SR"].Value),
                                Clave = dgvInventarioPlatillos.CurrentRow.Cells[1].Value.ToString(),
                                Platillo = dgvInventarioPlatillos.CurrentRow.Cells[2].Value.ToString(),
                                CantidadCocina = Convert.ToDouble(dgvInventarioPlatillos.CurrentRow.Cells["CR"].Value),
                                Status = estado.ToString(),
                                Observacion = Observacion,
                                Fecha = fecha
                            });
                        Data.MenuSemanal.Savedaily = listEstado;
                        Opcion.EjecucionAsync(Data.MenuSemanal.AgregarDiario, jsonResult =>
                        {
                            ActualizadoDgv();
                        });
                    }
                    if (rbregistrado.Checked)
                    {
                        if (dgvInventarioPlatillos.CurrentRow != null)
                            listEstado.Add(new Receta.Savedaily
                            {
                                EstadoDescripcionId = 5,
                                ArtId = dgvInventarioPlatillos.CurrentRow.Cells[0].Value.ToString(),
                                Cantidad = Convert.ToDouble(dgvInventarioPlatillos.CurrentRow.Cells["SR"].Value),
                                Clave = dgvInventarioPlatillos.CurrentRow.Cells[1].Value.ToString(),
                                Platillo = dgvInventarioPlatillos.CurrentRow.Cells[2].Value.ToString(),
                                CantidadCocina = Convert.ToDouble(dgvInventarioPlatillos.CurrentRow.Cells["CR"].Value),
                                Status = estadonegativo.ToString(),
                                Observacion = Observacion,
                                Fecha = fecha
                            });
                        Data.MenuSemanal.Savedaily = listEstado;
                        Opcion.EjecucionAsync(Data.MenuSemanal.AgregarDiario, jsonResult =>
                        {
                            ActualizadoDgv();
                        }); 
                }
            }
                else
                {
                    var observacionactualizada = dgvInventarioPlatillos.Rows[row].Cells["Observacion"].Value;
                    if (observacionactualizada != null && (string)observacionactualizada != "")
                    {
                        char[] separador = { '(', ')' };
                        var valor = Convert.ToString(observacionactualizada).Split(separador);
                        ObservacionActualizada = valor[1];
                    }
                    else
                    {
                        ObservacionActualizada = "";
                    }
                    if (rbcongelado.Checked)
                    {
                        if (dgvInventarioPlatillos.CurrentRow != null)
                        {
                            var listado = new Receta.Savedaily
                            {
                                EstadoDescripcionId = 1,
                                EstadoInventarioId = inventarioid,
                                ArtId = dgvInventarioPlatillos.CurrentRow.Cells[0].Value.ToString(),
                                Cantidad = Convert.ToDouble(dgvInventarioPlatillos.CurrentRow.Cells["SR"].Value),
                                Clave = dgvInventarioPlatillos.CurrentRow.Cells[1].Value.ToString(),
                                Platillo = dgvInventarioPlatillos.CurrentRow.Cells[2].Value.ToString(),
                                CantidadCocina = Convert.ToDouble(dgvInventarioPlatillos.CurrentRow.Cells["CR"].Value),
                                Status = estado.ToString(),
                                Observacion = ObservacionActualizada,
                                Fecha = fecha
                            };
                            Data.MenuSemanal.ActualizarDestino(listado);
                        }
                        ActualizadoDgv();
                    MessageBox.Show(@"Los datos se han actualizado correctamente");
                }
                    if (rbmerma.Checked)
                    {
                        if (dgvInventarioPlatillos.CurrentRow != null)
                        {
                            var listado = new Receta.Savedaily
                            {
                                EstadoDescripcionId = 2,
                                EstadoInventarioId = inventarioid,
                                ArtId = dgvInventarioPlatillos.CurrentRow.Cells[0].Value.ToString(),
                                Cantidad = Convert.ToDouble(dgvInventarioPlatillos.CurrentRow.Cells["SR"].Value),
                                Clave = dgvInventarioPlatillos.CurrentRow.Cells[1].Value.ToString(),
                                Platillo = dgvInventarioPlatillos.CurrentRow.Cells[2].Value.ToString(),
                                CantidadCocina = Convert.ToDouble(dgvInventarioPlatillos.CurrentRow.Cells["CR"].Value),
                                Status = estadonegativo.ToString(),
                                Observacion = ObservacionActualizada,
                                Fecha = fecha
                            };
                            Data.MenuSemanal.ActualizarDestino(listado);
                        }
                        ActualizadoDgv();
                    MessageBox.Show(@"Los datos se han actualizado correctamente");
                }
                    if (rbreventa.Checked)
                    {
                        if (dgvInventarioPlatillos.CurrentRow != null)
                        {
                            var listado = new Receta.Savedaily
                            {
                                EstadoInventarioId = inventarioid,
                                EstadoDescripcionId = 4,
                                ArtId = dgvInventarioPlatillos.CurrentRow.Cells[0].Value.ToString(),
                                Cantidad = Convert.ToDouble(dgvInventarioPlatillos.CurrentRow.Cells["SR"].Value),
                                Clave = dgvInventarioPlatillos.CurrentRow.Cells[1].Value.ToString(),
                                Platillo = dgvInventarioPlatillos.CurrentRow.Cells[2].Value.ToString(),
                                CantidadCocina = Convert.ToDouble(dgvInventarioPlatillos.CurrentRow.Cells["CR"].Value),
                                Status = estado.ToString(),
                                Observacion = ObservacionActualizada,
                                Fecha = fecha
                            };
                            Data.MenuSemanal.ActualizarDestino(listado);
                        }
                        ActualizadoDgv();
                    MessageBox.Show(@"Los datos se han actualizado correctamente");
                }
                    if (rbregistrado.Checked)
                    {
                        if (dgvInventarioPlatillos.CurrentRow != null)
                        {
                            var listado = new Receta.Savedaily
                            {
                                EstadoInventarioId = inventarioid,
                                EstadoDescripcionId = 5,
                                ArtId = dgvInventarioPlatillos.CurrentRow.Cells[0].Value.ToString(),
                                Cantidad = Convert.ToDouble(dgvInventarioPlatillos.CurrentRow.Cells["SR"].Value),
                                Clave = dgvInventarioPlatillos.CurrentRow.Cells[1].Value.ToString(),
                                Platillo = dgvInventarioPlatillos.CurrentRow.Cells[2].Value.ToString(),
                                CantidadCocina = Convert.ToDouble(dgvInventarioPlatillos.CurrentRow.Cells["CR"].Value),
                                Status = estadonegativo.ToString(),
                                Observacion = ObservacionActualizada,
                                Fecha = fecha
                            };
                            Data.MenuSemanal.ActualizarDestino(listado);
                        }
                        ActualizadoDgv();
                       MessageBox.Show(@"Los datos se han actualizado correctamente");
                }
            }
            rbregistrado.Checked = false;
            rbreventa.Checked = false;
            rbmerma.Checked = false;
            rbcongelado.Checked = false;
            btGuardar.Enabled = false;
        }
        private void dgvInventarioPlatillos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Xyz = e.RowIndex;
        }
        private void dgvInventarioPlatillos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvInventarioPlatillos.CurrentCell== null) return;
            var rowIndex = dgvInventarioPlatillos.CurrentCell.RowIndex;
            btGuardar.Enabled = true;
            if (dgvInventarioPlatillos.Rows.Count >0 && dgvInventarioPlatillos.Rows[rowIndex].Cells["Clave"].Value != null 
                && dgvInventarioPlatillos.Rows[rowIndex].Cells["Clave"].Value.ToString() != "" && dgvInventarioPlatillos.Rows[rowIndex].Cells["Platillo"].Value == null)
            {
                var fecha1R = DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd");
                var fecha2R = DateTime.Now.ToString("yyyy-MM-dd");
                var clave = dgvInventarioPlatillos.Rows[rowIndex].Cells["Clave"].Value.ToString();
                Opcion.EjecucionAsync(x =>
                {
                    var datos = new Reporte.General
                    {
                        FechaIni = Convert.ToDateTime(fecha1R),
                        FechaFin = Convert.ToDateTime(fecha2R),
                        Clave = clave

                    };
                    Data.Reporte.ReporteDiarioNuevoRegistro(x, datos);
                }, json =>
                {
                    if (json != null)
                    {
                        switch (json.StatusCode)
                        {
                            case HttpStatusCode.OK:
                                var lista = Opcion.JsonaClaseGenerica<Reporte.RespuestaCocina.Comprobacion>(json);
                                dgvInventarioPlatillos.Rows[rowIndex].Cells["Platillo"].Value = lista.Platillo;
                                dgvInventarioPlatillos.Rows[rowIndex].Cells["Unidad"].Value = lista.Unidad;
                                dgvInventarioPlatillos.Rows[rowIndex].Cells["CP"].Value = lista.CP;
                                dgvInventarioPlatillos.Rows[rowIndex].Cells["ArtId"].Value = lista.ArtId;
                                break;
                            default:
                                MessageBox.Show(this,
                                    @"No se encontraron menus con los parametros de busqueda ingresados");
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show(@"La clave ingresada no existe, Favor de verificar");
                    }
                });

            }
            if (dgvInventarioPlatillos.Rows.Count > rowIndex && dgvInventarioPlatillos.Rows[rowIndex].Cells["Platillo"].Value != null &&
                dgvInventarioPlatillos.Rows[rowIndex].Cells["Platillo"].Value.ToString() != "" && dgvInventarioPlatillos.Rows[rowIndex].Cells["Clave"].Value==null)
            {
                var fecha1R = DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd");
                var fecha2R = DateTime.Now.ToString("yyyy-MM-dd");
                var clave = dgvInventarioPlatillos.Rows[rowIndex].Cells["Platillo"].Value.ToString();
                Opcion.EjecucionAsync(x =>
                {
                    var datos = new Reporte.General
                    {
                        FechaIni = Convert.ToDateTime(fecha1R),
                        FechaFin = Convert.ToDateTime(fecha2R),
                        Clave = clave

                    };
                    Data.Reporte.ReporteDiarioNuevoRegistro(x, datos);
                }, json =>
                {
                    if (json != null)
                    {
                        switch (json.StatusCode)
                        {
                            case HttpStatusCode.OK:
                                var lista = Opcion.JsonaClaseGenerica<Reporte.RespuestaCocina.Comprobacion>(json);
                                dgvInventarioPlatillos.Rows[rowIndex].Cells["Clave"].Value = lista.Clave;
                                dgvInventarioPlatillos.Rows[rowIndex].Cells["CP"].Value = lista.CP;
                                dgvInventarioPlatillos.Rows[rowIndex].Cells["ArtId"].Value = lista.ArtId;
                                dgvInventarioPlatillos.Rows[rowIndex].Cells["Unidad"].Value = lista.Unidad;
                                break;
                            default:
                                MessageBox.Show(this,
                                    @"No se encontraron menus con los parametros de busqueda ingresados");
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show(@"El nombre del platillo no es el correcto, favor de verificar");
                    }
                });

            }
           
            var z = Convert.ToDouble(dgvInventarioPlatillos.Rows[Xyz].Cells[4].Value);
            var y = Convert.ToDouble(dgvInventarioPlatillos.Rows[Xyz].Cells[5].Value);
            dgvInventarioPlatillos.Rows[e.RowIndex].Cells["S"].Value = Math.Round(z - y, 2);
            dgvInventarioPlatillos.AllowUserToAddRows = true;
            dgvInventarioPlatillos.Enabled = true;
            dgvInventarioPlatillos.EditMode = DataGridViewEditMode.EditOnEnter;
        }
        private void btCargarDiarios_Click(object sender, EventArgs e)
        {
            dgvDiarios.DataSource = null;
            dgvDiarios.Columns.Clear();
            dgvDiarios.Rows.Clear();
            var fechainicior = DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd");
            var fechafinalr = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
            var fechas = new Cocina.ReporteDiarioCocina.FechasReporte
            {
                FechaIni = fechainicior,
                FechaFin = fechafinalr
            };
            var me = new MensajeDeEspera();
            me.Show();
            Opcion.EjecucionAsync(x =>
            {
                Data.Reporte.RepoDiarioD(x, fechas);
            }, jsonResult =>
            {
            if (jsonResult != null)
            {
                BeginInvoke((MethodInvoker)(() =>
                {
                    switch (jsonResult.StatusCode)
                    {
                        case HttpStatusCode.OK:

                           var list=new List<Reporte.RespuestaCocina.RepoDiario>(Opcion.JsonaListaGenerica<Reporte.RespuestaCocina.RepoDiario>(jsonResult));
                            var nuevalis = new BindingList<Reporte.RespuestaCocina.RepoDiario>(list);  
                            nuevalis.AddNew();
                            foreach (Reporte.RespuestaCocina.RepoDiario dd in (_listaPlatilloHoy))
                            {
                                if (nuevalis != null)
                                {
                                    nuevalis.Add(dd);
                                }
                            }
                                dgvDiarios.DataSource = nuevalis;
                            break;
                            default:
                            MessageBox.Show(@"Comunicar al area de Sistemas");
                            break;
                    }
                    DiseñoDgvDiario();
                    btGuardarDiarios.Enabled = true;
                    btPreviaGlobal.Enabled = true;
                    btPreviaPlatillo.Enabled = true;
                    CarganewDiario();
                    me.Close();
                }));
                 
                }
            else
            {
                    BeginInvoke((MethodInvoker)(() =>
                    {
                        dgvDiarios.DataSource = _listaPlatilloHoy;
                        DiseñoDgvDiario();
                        btGuardarDiarios.Enabled = true;
                        btPreviaGlobal.Enabled = true;
                        btPreviaPlatillo.Enabled = true;
                        CarganewDiario();
                        me.Close();
                    }));
                }
            });
            //var dataGridViewColumn = dgvDiarios.Columns["Platillo"];
            //if (dataGridViewColumn != null) dataGridViewColumn.ReadOnly = true;
            //var gridViewColumn = dgvDiarios.Columns["Clave"];
            //if (gridViewColumn != null) gridViewColumn.ReadOnly = true;
            //var viewColumn = dgvDiarios.Columns["Existencia"];
            //if (viewColumn != null)
            //    viewColumn.ReadOnly = true;
            //var column = dgvDiarios.Columns["CP"];
            //if (column != null) column.ReadOnly = true;
            //var dataGridViewColumn1 = dgvDiarios.Columns["Ventaanterior"];
            //if (dataGridViewColumn1 != null)
            //    dataGridViewColumn1.ReadOnly = true;
            //var gridViewColumn1 = dgvDiarios.Columns["VentaPromedio"];
            //if (gridViewColumn1 != null)
            //    gridViewColumn1.ReadOnly = true;
            var viewColumn1 = dgvDiarios.Columns["EstadoMañana"];
            if (viewColumn1 != null)
                viewColumn1.Visible = false;

        }
        private void rbreventa_CheckedChanged(object sender, EventArgs e)
        {
            btGuardar.Enabled = true;
        }
        private void rbcongelado_CheckedChanged(object sender, EventArgs e)
        {
            btGuardar.Enabled = true;
        }
        private void rbmerma_CheckedChanged(object sender, EventArgs e)
        {
            btGuardar.Enabled = true;
        }
        private void rbregistrado_CheckedChanged(object sender, EventArgs e)
        {
            btGuardar.Enabled = true;
        }
        private void btPreviaGlobal_Click(object sender, EventArgs e)
        {
            dgvDiarios.AllowUserToAddRows = false;
            for (var i = 0; i < dgvDiarios.Rows.Count; i++)
            {
                var clave = Convert.ToString(dgvDiarios.Rows[i].Cells["Clave"].Value.ToString());
                var platillo = Convert.ToString(dgvDiarios.Rows[i].Cells["Platillo"].Value.ToString());
                var cantidadpro = Convert.ToDouble(dgvDiarios.Rows[i].Cells["CP"].Value);
                var cantidadelaborar = Convert.ToDouble(dgvDiarios.Rows[i].Cells["CE"].Value);
                var existencia = Convert.ToDouble(dgvDiarios.Rows[i].Cells["Existencia"].Value);
                var cantidadelareal = Convert.ToDouble(cantidadpro + existencia);
                Cocina.PlatillosMenus.Clave = clave;
                Opcion.EjecucionAsync(Data.MenuSemanal.SacarParamentrosReceta, y =>
                {
                    var recid = Opcion.JsonaClaseGenerica<PlatilloReceta>(y).RecId;
                    Cocina.PlatillosMenus.RecId = Convert.ToString(recid);
                    Opcion.EjecucionAsync(Data.MenuSemanal.IngredientesMenuPlatillos,
                        jsonResult =>
                        {
                                        // ReSharper disable once CompareOfFloatsByEqualityOperator
                                        if (cantidadelareal == cantidadelaborar)
                            {
                                var lista = Opcion.JsonaListaGenerica<IngredientesReceta>(jsonResult);

                                _listaArticuloBasica1 = lista
                                    .GroupBy(p => p.ArtId)
                                    .Select(g => new IngredientesReceta
                                    {
                                        ArtId = g.Key,
                                        DescripcionReceta = platillo,
                                        Clave = g.First().Clave,
                                        Descripcion = g.First().Descripcion,
                                        Cantidad = g.Sum(q => q.Cantidad),
                                        Unidad = g.First().Unidad,
                                        Fecha = DateTime.Now.ToString("yyyy-MM-dd"),
                                    }).ToList();
                            }
                            else
                            {
                                var difcantidad = Math.Round(cantidadelaborar / cantidadelareal, 2);
                                var lista = Opcion.JsonaListaGenerica<IngredientesReceta>(jsonResult);

                                _listaArticuloBasica1 = lista
                                    .GroupBy(p => p.ArtId)
                                    .Select(g => new IngredientesReceta
                                    {
                                        ArtId = g.Key,
                                        DescripcionReceta = platillo,
                                        Clave = g.First().Clave,
                                        Descripcion = g.First().Descripcion,
                                        Cantidad = Math.Round(g.Sum(q => q.Cantidad) * difcantidad, 2),
                                        Unidad = g.First().Unidad,
                                        Fecha = DateTime.Now.ToString("yyyy-MM-dd"),
                                    }).ToList();
                            }
                        });
                });
                _listaArticuloBasica3.AddRange(_listaArticuloBasica1);
                _listaArticuloBasica3 = _listaArticuloBasica3.GroupBy(p => p.ArtId)
                         .Select(g => new IngredientesReceta
                         {
                             ArtId = g.Key,
                             Clave = g.First().Clave,
                             Descripcion = g.First().Descripcion,
                             Cantidad = g.Sum(b => b.Cantidad),
                             Unidad = g.First().Unidad,
                             Fecha = g.First().Fecha
                         }).ToList();
            }
            var addIn = Globals.ThisAddIn;
            addIn.IngredientesMenuGlobal(_listaArticuloBasica3);
        }
        private void btPreviaPlatillo_Click(object sender, EventArgs e)
        {   /*if (dgvDiarios.CurrentRow.Cells["CE"] != 0)*/
                    dgvDiarios.AllowUserToAddRows = false;
                    for (var i = 0; i < dgvDiarios.Rows.Count; i++)
                    {
                var clave= Convert.ToString(dgvDiarios.Rows[i].Cells["Clave"].Value);
                var platillo= Convert.ToString(dgvDiarios.Rows[i].Cells["Platillo"].Value);
                var cantidadpro = Convert.ToDouble(dgvDiarios.Rows[i].Cells["CP"].Value);
                var cantidadelaborar= Convert.ToDouble(dgvDiarios.Rows[i].Cells["CE"].Value);
                var existencia= Convert.ToDouble(dgvDiarios.Rows[i].Cells["Existencia"].Value);
                var cantidadelareal =Convert.ToDouble(cantidadpro + existencia) ;
                Cocina.PlatillosMenus.Clave = clave;
                            Opcion.EjecucionAsync(Data.MenuSemanal.SacarParamentrosReceta, y =>
                            {
                                var recid = Opcion.JsonaClaseGenerica<PlatilloReceta>(y).RecId;
                                Cocina.PlatillosMenus.RecId = Convert.ToString(recid);
                                Opcion.EjecucionAsync(Data.MenuSemanal.IngredientesMenuPlatillos,
                                    jsonResult =>
                                    {
                                        // ReSharper disable once CompareOfFloatsByEqualityOperator
                                        if (cantidadelareal == cantidadelaborar)
                                        {
                                            var lista = Opcion.JsonaListaGenerica<IngredientesReceta>(jsonResult);

                                            _listaArticuloBasica1 = lista
                                                .GroupBy(p => p.ArtId)
                                                .Select(g => new IngredientesReceta
                                                {
                                                    ArtId = g.Key,
                                                    DescripcionReceta = platillo,
                                                    Clave = g.First().Clave,
                                                    Descripcion = g.First().Descripcion,
                                                    Cantidad = g.Sum(q => q.Cantidad),
                                                    Unidad = g.First().Unidad,
                                                    Fecha = DateTime.Now.ToString("yyyy-MM-dd"),
                                                }).ToList();
                                        }
                                        else
                                        {
                                            var difcantidad = Math.Round(cantidadelaborar / cantidadelareal, 2);
                                            var lista = Opcion.JsonaListaGenerica<IngredientesReceta>(jsonResult);

                                            _listaArticuloBasica1 = lista
                                                .GroupBy(p => p.ArtId)
                                                .Select(g => new IngredientesReceta
                                                {
                                                    ArtId = g.Key,
                                                    DescripcionReceta = platillo,
                                                    Clave = g.First().Clave,
                                                    Descripcion = g.First().Descripcion,
                                                    Cantidad = Math.Round(g.Sum(q => q.Cantidad) * difcantidad, 2),
                                                    Unidad = g.First().Unidad,
                                                    Fecha = DateTime.Now.ToString("yyyy-MM-dd"),
                                                }).ToList();
                                        }
                                    });
                                    });   
                        _listaArticuloBasica2.AddRange(_listaArticuloBasica1); 
                                  }
               
                            var addIn = Globals.ThisAddIn;
                            addIn.IngredientesMenuxPlatillo(_listaArticuloBasica2);
        }
        private void btEditar_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < dgvInventarioPlatillos.RowCount; i++)
            {
                var y = dgvInventarioPlatillos.Rows[i].Selected;
                if (!y) continue;
                dgvInventarioPlatillos.Rows[i].Cells["CR"].ReadOnly = false;
                dgvInventarioPlatillos.Rows[i].Cells["SR"].ReadOnly = false;
                dgvInventarioPlatillos.Rows[i].Cells["Observacion"].ReadOnly = false;
            }
        }
        private void btGuardarDiarios_Click(object sender, EventArgs e)
        {
            var fecha = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
            var fechaactual = DateTime.Now.ToString("yyyy-MM-dd");
            //var row = dgvInventarioPlatillos.CurrentCell.RowIndex;
            const int estado =-1;
            var listEstado = new List<Receta.Savedaily>();
            if (MessageBox.Show(@"La informacion a guardar es la correcta", @"Aviso", MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question) == DialogResult.Yes)
            { 
               
                for (var i = 0; i < dgvDiarios.Rows.Count; i++)
            {
                if (dgvDiarios.Rows[i].Cells["Clave"].Value !=null)
                {
                        var lista= new Receta.Savedaily
                    {
                  ArtId = dgvDiarios.Rows[i].Cells["ArtId"].Value.ToString(),
                  Cantidad =0,
                  Clave = dgvDiarios.Rows[i].Cells["Clave"].Value.ToString(),
                  Platillo = dgvDiarios.Rows[i].Cells["Platillo"].Value.ToString(),
                  CantidadCocina = Convert.ToDouble(dgvDiarios.Rows[i].Cells["CantidadCocina"].Value),
                  Observacion = dgvDiarios.Rows[i].Cells["Observacion"].Value.ToString(),
                  Fecha = fecha,
                  EstadoInventarioId = Convert.ToInt32(dgvDiarios.Rows[i].Cells["EstadoInventarioId"].Value),  
                  EstadoDescripcionId = 5,
                  Status = estado.ToString()
                };
                 Data.MenuSemanal.ActualizarReventadiarios(lista);
                  }
                    BeginInvoke((MethodInvoker)(() =>
                {
                    var dataGridViewImageColumn = (DataGridViewImageColumn)dgvInventarioPlatillos.Columns["Guardar"];
                    if (dataGridViewImageColumn != null)
                        dataGridViewImageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
                    dgvInventarioPlatillos.Rows[Xyz].Cells["Guardar"].Value = Image.FromFile(@"\\mercattoserver\Recetario\icon\correcto.jpg");
                    dgvInventarioPlatillos.Rows[Xyz].ReadOnly = true;
                }));
            }
            MessageBox.Show(@"Los datos se han guardado correctamente");
            }
            else
            {
                MessageBox.Show(@"Verifica los datos");
            }
            ActualizadoDgv();
            GuardadodeMañana();
            CarganewDiario();

        }
        private void GuardadodeMañana()
        {
            var listaDiariosMa = new List<Receta.DiariosMañana>();
            var listaActualizarMa = new List<Receta.DiariosMañana>();

            var fechaactual = DateTime.Now.ToString("yyyy-MM-dd");
            for (var i = 0; i < dgvDiarios.Rows.Count; i++)
            {
                var idmañana = Convert.ToInt32(dgvDiarios.Rows[i].Cells["EstadoMañana"].Value);
                if (idmañana == 0)
                {
                if(dgvDiarios.Rows[i].Cells["Clave"].Value!=null)
                { 
                listaDiariosMa.Add(new Receta.DiariosMañana
                    {
                        ArtId = dgvDiarios.Rows[i].Cells["ArtId"].Value.ToString(),
                        Clave = dgvDiarios.Rows[i].Cells["Clave"].Value.ToString(),
                        Platillo = dgvDiarios.Rows[i].Cells["Platillo"].Value.ToString(),
                        CantidadCocina = Convert.ToDouble(dgvDiarios.Rows[i].Cells["CR"].Value.ToString()),
                        CantidadElaborar = Convert.ToDouble(dgvDiarios.Rows[i].Cells["CE"].Value.ToString()),
                        Fecha = fechaactual,
                        Observacion = ""
                    });
                }
                }
                else
                {
                    if (dgvDiarios.Rows[i].Cells["Clave"].Value != null)
                    {
                        var listaActualiza= new Receta.DiariosMañana
                    {
                        ArtId = dgvDiarios.Rows[i].Cells["ArtId"].Value.ToString(),
                        Clave = dgvDiarios.Rows[i].Cells["Clave"].Value.ToString(),
                        Platillo = dgvDiarios.Rows[i].Cells["Platillo"].Value.ToString(),
                        CantidadCocina = Convert.ToDouble(dgvDiarios.Rows[i].Cells["CR"].Value.ToString()),
                        CantidadElaborar = Convert.ToDouble(dgvDiarios.Rows[i].Cells["CE"].Value.ToString()),
                        Fecha = fechaactual,
                        Observacion = "",
                        EstadoInventarioId = idmañana
                    };
                    Data.MenuSemanal.ActualizarDiarioMa(listaActualiza);
                    }
                }
            }
            Data.MenuSemanal.InsertarDiarioMañana(listaDiariosMa);    
        }
        private void btEliminarFila_Click(object sender, EventArgs e)
        {
            if (dgvDiarios.RowCount > 0)
            {
                var fecha = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
                const int estado = -1;
                if (dgvDiarios.CurrentRow != null)
                {
                    var lista = new Receta.Savedaily
                    {
                        ArtId = dgvDiarios.CurrentRow.Cells["ArtId"].Value.ToString(),
                        Cantidad = 0,
                        Clave = dgvDiarios.CurrentRow.Cells["Clave"].Value.ToString(),
                        Platillo = dgvDiarios.CurrentRow.Cells["Platillo"].Value.ToString(),
                        CantidadCocina = Convert.ToDouble(dgvDiarios.CurrentRow.Cells["CantidadCocina"].Value),
                        Observacion = dgvDiarios.CurrentRow.Cells["Observacion"].Value.ToString(),
                        Fecha = fecha,
                        EstadoInventarioId = Convert.ToInt32(dgvDiarios.CurrentRow.Cells["EstadoInventarioId"].Value),
                        EstadoDescripcionId = 5,
                        Status = estado.ToString()
                    };
                    Data.MenuSemanal.ActualizarReventadiarios(lista);
                }
                Opcion.BorrarFilaDiarios(dgvDiarios);
                DiseñoDgvDiario();
                BeginInvoke((MethodInvoker)(() =>
                {
                    var dataGridViewImageColumn = (DataGridViewImageColumn)dgvInventarioPlatillos.Columns["Guardar"];
                    if (dataGridViewImageColumn != null)
                        dataGridViewImageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
                    dgvInventarioPlatillos.Rows[Xyz].Cells["Guardar"].Value = Image.FromFile(@"\\mercattoserver\Recetario\icon\correcto.jpg");
                    dgvInventarioPlatillos.Rows[Xyz].ReadOnly = true;
                }));
                ActualizadoDgv();
                CarganewDiario();
            }
            MessageBox.Show(this, @"Platillo eliminado con existo");
        }
        private void DiseñoDgvDiario()
        {
            dgvDiarios.RowHeadersVisible = false;
            dgvDiarios.DefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            //dgvDiarios.DefaultCellStyle.Font = new Font("Segoe UI Light", 8, FontStyle.Bold);
            dgvDiarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDiarios.Columns[0].Width = 110;
            dgvDiarios.Columns[1].Width = 370;
            dgvDiarios.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDiarios.Columns[2].Width = 100;
            dgvDiarios.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDiarios.Columns[3].Width = 60;
            dgvDiarios.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDiarios.Columns[4].Width = 60;
            dgvDiarios.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDiarios.Columns[5].Width = 60;
            dgvDiarios.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDiarios.Columns[6].Width = 130;
            dgvDiarios.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDiarios.Columns[7].Width = 140;
            var dataGridViewColumn = dgvDiarios.Columns["EstadoInventarioId"];
            if (dataGridViewColumn != null)
                dataGridViewColumn.Visible = false;
            var viewColumn1 = dgvDiarios.Columns["Estadomañana"];
            if (viewColumn1 != null) viewColumn1.Visible = false;
            var gridViewColumn = dgvDiarios.Columns["CantidadCocina"];
            if (gridViewColumn != null) gridViewColumn.Visible = false;
            var viewColumn = dgvDiarios.Columns["ArtId"];
            if (viewColumn != null) viewColumn.Visible = false;
            var gridViewColumn1 = dgvDiarios.Columns["Observacion"];
            if (gridViewColumn1 != null) gridViewColumn1.Visible = false;
            var column = dgvDiarios.Columns["CE"];
            if (column != null)
                column.DefaultCellStyle.BackColor = Color.Coral;
            var dataGridViewColumn1 = dgvDiarios.Columns["CR"];
            if (dataGridViewColumn1 != null)
                dataGridViewColumn1.DefaultCellStyle.BackColor = Color.Coral;
        }
        private void CarganewDiario()
        {
            var fecha1R = DateTime.Now.ToString("yyyy-MM-dd");
            var fecha2R = DateTime.Now.ToString("yyyy-MM-dd");
            Opcion.EjecucionAsync(x =>
            {
                var times = new Reporte.General
                {
                    FechaIni = Convert.ToDateTime(fecha1R),
                    FechaFin = Convert.ToDateTime(fecha2R)
                };
                Data.Reporte.MostrarEstado(x, times);
            }, z =>
            {
                if (z != null)
                {
                    BeginInvoke((MethodInvoker)(() =>
                    {
                        switch (z.StatusCode)
                        {
                            case HttpStatusCode.OK:
                              ListDiarioDs = Opcion.JsonaListaGenerica<Reporte.RespuestaCocina.Comprobacion>(z);
                                for (var i = 0; i < dgvDiarios.RowCount; i++)
                                {
                                    var y = Convert.ToInt32(dgvDiarios.Rows[i].Cells["ArtId"].Value);
                                    // ReSharper disable once ForCanBeConvertedToForeach
                                    for (var j = 0; j < ListDiarioDs.Count; j++)
                                    {
                                        var x = Convert.ToInt32(ListDiarioDs[j].ArtId);
                                        if (x == y)
                                        {
                                            Xyz = i;   
                                            dgvDiarios.Rows[i].Cells["CE"].Value = ListDiarioDs[j].CE;
                                            dgvDiarios.Rows[i].Cells["CR"].Value = ListDiarioDs[j].CR;
                                            dgvDiarios.Rows[i].Cells["EstadoMañana"].Value = ListDiarioDs[j].EstadoManana;
                                        }
                                    }
                                }
                                break;
                            default:
                                MessageBox.Show(this, @"No se encontraron menus con los parametros de busqueda ingresados");
                                break;
                        }
                    }));
                }
            });
        }
        private void PlatillosHoy()
        {
            var fechainicior = DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd");
            var fechafinalr = DateTime.Now.ToString("yyyy-MM-dd");
            var fechas = new Cocina.ReporteDiarioCocina.FechasReporte
            {
                FechaIni = fechainicior,
                FechaFin = fechafinalr
            };
            Opcion.EjecucionAsync(x =>
            {
                Data.Reporte.RepoPlatillosdeHoy(x, fechas);
            }, w =>
            {
                if (w != null)
                {
                    //BeginInvoke((MethodInvoker)(() =>
                    //{
                        switch (w.StatusCode)
                        {
                            case HttpStatusCode.OK:

                                _listaPlatilloHoy =
                                    new BindingList<Reporte.RespuestaCocina.RepoDiario>(
                                        Opcion.JsonaListaGenerica<Reporte.RespuestaCocina.RepoDiario>(w));
                                break;
                            default:
                                MessageBox.Show(@"Comunicar al area de Sistemas");
                                break;
                        }
                    //}));

                }
            });
        }
    
        private void ActualizadoDgv()
        {
            var fecha1R = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
            var fecha2R = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
            Opcion.EjecucionAsync(x =>
            {
                var times = new Reporte.General
                {
                    FechaIni = Convert.ToDateTime(fecha1R),
                    FechaFin = Convert.ToDateTime(fecha2R)
                };
                Data.Reporte.RepDiarioAct(x, times);
            }, z =>
            {
                if (z != null)
                {
                    BeginInvoke((MethodInvoker)(() =>
                    {
                        switch (z.StatusCode)

                        {
                            case HttpStatusCode.OK:
                                _listinvcomprobacion = new BindingList<Reporte.RespuestaCocina.Comprobacion>(Opcion.JsonaListaGenerica<Reporte.RespuestaCocina.Comprobacion>(z));
                                for (var i = 0; i < dgvInventarioPlatillos.RowCount; i++)
                                {
                                    var y =Convert.ToInt32(dgvInventarioPlatillos.Rows[i].Cells["ArtId"].Value);
                                    // ReSharper disable once ForCanBeConvertedToForeach
                                    for (var j = 0; j < _listinvcomprobacion.Count; j++)
                                    {
                                        var x = Convert.ToInt32(_listinvcomprobacion[j].ArtId);
                                        if (x == y)
                                        {
                                            Xyz = i;
                                            var dataGridViewImageColumn = (DataGridViewImageColumn)dgvInventarioPlatillos.Columns["Guardar"];
                                            if (dataGridViewImageColumn != null)
                                                dataGridViewImageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
                                            dgvInventarioPlatillos.Rows[i].Cells["CR"].Value = _listinvcomprobacion[j].CR;
                                            dgvInventarioPlatillos.Rows[i].Cells["SR"].Value = _listinvcomprobacion[j].SR;
                                            dgvInventarioPlatillos.Rows[i].Cells["Observacion"].Value = _listinvcomprobacion[j].Observacion;
                                            dgvInventarioPlatillos.Rows[i].Cells["EstadoInventarioId"].Value = _listinvcomprobacion[j].EstadoInventarioId;
                                            var dataGridViewColumn = dgvInventarioPlatillos.Columns["EstadoInventarioId"];
                                            if (dataGridViewColumn != null)
                                                dataGridViewColumn.Visible = false;
                                            dgvInventarioPlatillos.Rows[i].Cells["Guardar"].Value = Image.FromFile(@"\\mercattoserver\Recetario\icon\correcto.jpg");
                                            dgvInventarioPlatillos.Rows[i].ReadOnly = true;
                                        }
                                    }
                                }
                                break;
                            default:
                                MessageBox.Show(this, @"No se encontraron menus con los parametros de busqueda ingresados");
                                break;
                        }
                    }));
                }
            });

            Opcion.EjecucionAsync(x =>
            {
                var times = new Reporte.General
                {
                    FechaIni = Convert.ToDateTime(fecha1R),
                    FechaFin = Convert.ToDateTime(fecha2R)
                };
                Data.Reporte.MostrarEstado(x, times);
            }, z =>
            {
                if (z != null)
                {
                    BeginInvoke((MethodInvoker)(() =>
                    {
                        switch (z.StatusCode)
                        {
                            case HttpStatusCode.OK:
                                _listinvcomprobacion= new BindingList<Reporte.RespuestaCocina.Comprobacion>(Opcion.JsonaListaGenerica<Reporte.RespuestaCocina.Comprobacion>(z));
                                for (var i = 0; i < dgvInventarioPlatillos.RowCount; i++)
                                {
                                    var y = Convert.ToInt32(dgvInventarioPlatillos.Rows[i].Cells["ArtId"].Value);
                                    // ReSharper disable once ForCanBeConvertedToForeach
                                    for (var j = 0; j < _listinvcomprobacion.Count; j++)
                                    {
                                        var x = Convert.ToInt32(_listinvcomprobacion[j].ArtId);
                                        if (x == y)
                                        {
                                            Xyz = i;
                                            dgvInventarioPlatillos.Rows[i].Cells["CR"].Value =_listinvcomprobacion[j].CR;
                                        }
                                    }
                                }
                                break;
                            default:
                                MessageBox.Show(this, @"No se encontraron menus con los parametros de busqueda ingresados");
                                break;
                        }
                    }));
                }
            });
        }
        private void dgvInventarioPlatillos_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception != null &&
                e.Context == DataGridViewDataErrorContexts.Commit)
            {
                dgvInventarioPlatillos.Rows[e.RowIndex].Cells["CR"].Value = @"0";
                dgvInventarioPlatillos.Rows[e.RowIndex].Cells["SR"].Value = @"0";
            }
        }
        private void dgvDiarios_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception != null &&
                e.Context == DataGridViewDataErrorContexts.Commit)
            {
                dgvInventarioPlatillos.Rows[e.RowIndex].Cells["CE"].Value = @"0";
                dgvInventarioPlatillos.Rows[e.RowIndex].Cells["CR"].Value = @"0";
            }
        }

        private void btOrdendeTrabajo_Click(object sender, EventArgs e)
        {
            if (dgvDiarios.CurrentRow.Selected  && dgvDiarios.RowCount > 0 &&
                dgvDiarios.CurrentRow.Cells["Clave"].Value.ToString()!= ""|| dgvDiarios.CurrentRow.Cells["Platillo"].Value.ToString() != "")
            {
                    var clave = Convert.ToString(dgvDiarios.CurrentRow.Cells["Clave"].Value.ToString());
                    Cocina.DetalleCocina.Clave = clave;
                   
                    Opcion.EjecucionAsync(x =>
                    {
                        var detallereceta = new Cocina.DetalleCocina.ReporteDetalle
                        {
                            clave = clave
                        };
                        Data.ReporteCocina.DDetalleReceta(x, detallereceta);
                    }, jsonResult =>
                    {
                        var listaCocina = Opcion.JsonaListaGenerica<Reporte.RespuestaCocina>(jsonResult)[0];
                        var FechaActual = DateTime.Today.ToShortDateString();
                        var CantidadReal = Convert.ToString(dgvDiarios.CurrentRow.Cells["CE"].Value);
                        listaCocina.Consumodia = CantidadReal;
                        listaCocina.UltimaElaboracion = FechaActual;
                        if (Convert.ToInt32(dgvDiarios.CurrentRow.Cells["CR"].Value) != 0 &&
                            Convert.ToInt32(dgvDiarios.CurrentRow.Cells["CR"].Value) > 0)
                        {
                            listaCocina.Cantidadinventario = Convert.ToInt32(dgvDiarios.CurrentRow.Cells["CR"].Value);
                        }
                        else
                        {
                            listaCocina.Cantidadinventario = 0;
                        }
                        var addIn = Globals.ThisAddIn;
                        addIn.OrdendeTrabajo(listaCocina);
                    }
                );
            }
        }

        private void dgvDiarios_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var rowIndex = dgvDiarios.CurrentCell.RowIndex;
            btGuardar.Enabled = true;
            if (dgvDiarios.Rows.Count > rowIndex && dgvDiarios.Rows[rowIndex].Cells["Clave"].Value != null &&
                dgvDiarios.Rows[rowIndex].Cells["Clave"].Value.ToString() != "" && dgvDiarios.Rows[rowIndex].Cells["Platillo"].Value == null)
            {
                var fecha1R = DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd");
                var fecha2R = DateTime.Now.ToString("yyyy-MM-dd");
                var clave = dgvDiarios.Rows[rowIndex].Cells["Clave"].Value.ToString(); 
                Opcion.EjecucionAsync(x =>
                {
                    var datos = new Reporte.General
                    {
                        FechaIni = Convert.ToDateTime(fecha1R),
                        FechaFin = Convert.ToDateTime(fecha2R),
                        Clave = clave

                    };
                    Data.Reporte.ReporteDiarioNuevoRegistro(x, datos);
                }, z =>
                {
                    if (z != null)
                    {
                            switch (z.StatusCode)
                            {
                                case HttpStatusCode.OK:
                                    var lista=Opcion.JsonaClaseGenerica<Reporte.RespuestaCocina.Comprobacion>(z);
                                    dgvDiarios.Rows[rowIndex].Cells["Platillo"].Value = lista.Platillo;
                                    dgvDiarios.Rows[rowIndex].Cells["Existencia"].Value = lista.Existencia;
                                    dgvDiarios.Rows[rowIndex].Cells["CP"].Value = lista.CP;
                                    dgvDiarios.Rows[rowIndex].Cells["CE"].Value = lista.CE;
                                    dgvDiarios.Rows[rowIndex].Cells["CR"].Value = lista.CR;
                                    dgvDiarios.Rows[rowIndex].Cells["VentaAnterior"].Value = lista.VentaAnterior;
                                    dgvDiarios.Rows[rowIndex].Cells["VentaPromedio"].Value = lista.VentaPromedio;
                                    dgvDiarios.Rows[rowIndex].Cells["EstadoInventarioId"].Value = lista.EstadoInventarioId;
                                    dgvDiarios.Rows[rowIndex].Cells["ArtId"].Value = lista.ArtId;
                                    dgvDiarios.Rows[rowIndex].Cells["Observacion"].Value = lista.Observacion;
                                    dgvDiarios.Rows[rowIndex].Cells["CantidadCocina"].Value = lista.CantidadCocina;
                                    dgvDiarios.Rows[rowIndex].Cells["EstadoMañana"].Value = lista.EstadoManana;
                                    break;
                                default:
                                    MessageBox.Show(this, @"No se encontraron menus con los parametros de busqueda ingresados");
                                    break;
                            }
                    }
                    else
                    {
                        MessageBox.Show(@"La clave ingresada no existe, Favor de verificar");
                    }
                });
            }

            if (dgvDiarios.Rows.Count > rowIndex && dgvDiarios.Rows[rowIndex].Cells["Platillo"].Value != null &&
                dgvDiarios.Rows[rowIndex].Cells["Platillo"].Value.ToString() != "" && dgvDiarios.Rows[rowIndex].Cells["Clave"].Value == null)
            {
                var fecha1R = DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd");
                var fecha2R = DateTime.Now.ToString("yyyy-MM-dd");
                var clave = dgvDiarios.Rows[rowIndex].Cells["Platillo"].Value.ToString();
                Opcion.EjecucionAsync(x =>
                {
                    var datos = new Reporte.General
                    {
                        FechaIni = Convert.ToDateTime(fecha1R),
                        FechaFin = Convert.ToDateTime(fecha2R),
                        Clave = clave

                    };
                    Data.Reporte.ReporteDiarioNuevoRegistro(x, datos);
                }, z =>
                {
                    if (z != null)
                    {
                        switch (z.StatusCode)
                        {
                            case HttpStatusCode.OK:
                                var lista = Opcion.JsonaClaseGenerica<Reporte.RespuestaCocina.Comprobacion>(z);
                                dgvDiarios.Rows[rowIndex].Cells["Clave"].Value = lista.Clave;
                                dgvDiarios.Rows[rowIndex].Cells["Existencia"].Value = lista.Existencia;
                                dgvDiarios.Rows[rowIndex].Cells["CP"].Value = lista.CP;
                                dgvDiarios.Rows[rowIndex].Cells["CE"].Value = lista.CE;
                                dgvDiarios.Rows[rowIndex].Cells["CR"].Value = lista.CR;
                                dgvDiarios.Rows[rowIndex].Cells["VentaAnterior"].Value = lista.VentaAnterior;
                                dgvDiarios.Rows[rowIndex].Cells["VentaPromedio"].Value = lista.VentaPromedio;
                                dgvDiarios.Rows[rowIndex].Cells["EstadoInventarioId"].Value = lista.EstadoInventarioId;
                                dgvDiarios.Rows[rowIndex].Cells["ArtId"].Value = lista.ArtId;
                                dgvDiarios.Rows[rowIndex].Cells["Observacion"].Value = lista.Observacion;
                                dgvDiarios.Rows[rowIndex].Cells["CantidadCocina"].Value = lista.CantidadCocina;
                                dgvDiarios.Rows[rowIndex].Cells["EstadoMañana"].Value = lista.EstadoManana;
                                break;
                            default:
                                MessageBox.Show(this, @"No se encontraron menus con los parametros de busqueda ingresados");
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show(@"El nombre del platillo no es el correcto, favor de verificar");
                    }
                });

            }
        }
    }
 }
                
