using System;
using System.Collections.Generic;
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
        public int EstadoInventarioIdd;
        public Diario()
        {
            _listaArticuloBasica1 = new List<IngredientesReceta>();
            _listaArticuloBasica2 = new List<IngredientesReceta>();
            _listaArticuloBasica3 = new List<IngredientesReceta>();
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
            btGuardarDiarios.Enabled = false;
            btPreviaGlobal.Enabled = false;
            btPreviaPlatillo.Enabled = false;
            //borrar si ya fue guardado el dato
            #region fechas

            var fecha = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd 07:00:00");
            var fecha1 = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd 22:00:00");
            var fecha1R =DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
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
                        Lista = Opcion.JsonaListaGenerica<Respuesta.Diario>(jsonResult);

                        dgvInventarioPlatillos.RowHeadersVisible = false;
                        dgvInventarioPlatillos.DataSource = Lista;
                        dgvInventarioPlatillos.Columns.Add(col2);
                        dgvInventarioPlatillos.Columns["Clave"].ReadOnly = true;
                        dgvInventarioPlatillos.Columns["Platillo"].ReadOnly = true;
                        dgvInventarioPlatillos.Columns["CV"].ReadOnly = true;
                        dgvInventarioPlatillos.Columns["CP"].ReadOnly = true;
                        dgvInventarioPlatillos.Columns["S"].ReadOnly = true;
                        dgvInventarioPlatillos.Columns["Unidad"].ReadOnly = true;
                        var dataGridViewColumn = dgvInventarioPlatillos.Columns["Guardar"];
                        if (dataGridViewColumn != null) dataGridViewColumn.DisplayIndex = 9;
                        dgvInventarioPlatillos.DefaultCellStyle.Font = new Font("Segoe UI Light", 8, FontStyle.Bold);
                        var gridViewColumn = dgvInventarioPlatillos.Columns["Guardar"];
                        if (gridViewColumn != null) gridViewColumn.Width = 30;
                        dgvInventarioPlatillos.Columns[0].Visible = false;
                        var gridViewColumn1 = dgvInventarioPlatillos.Columns["EstadoInventarioId"];
                        if (gridViewColumn1 != null)
                            gridViewColumn1.Visible = false;
                        dgvInventarioPlatillos.Columns[1].Width = 70;
                        dgvInventarioPlatillos.Columns[2].Width = 220;
                        dgvInventarioPlatillos.Columns[3].Width = 40;
                        dgvInventarioPlatillos.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dgvInventarioPlatillos.Columns[4].Width = 40;
                        dgvInventarioPlatillos.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dgvInventarioPlatillos.Columns[5].Width = 40;
                        dgvInventarioPlatillos.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dgvInventarioPlatillos.Columns[6].Width = 75;
                        dgvInventarioPlatillos.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dgvInventarioPlatillos.Columns[7].Width = 50;
                        dgvInventarioPlatillos.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dgvInventarioPlatillos.Columns[8].Width =50;
                        dgvInventarioPlatillos.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dgvInventarioPlatillos.Columns[10].Width = 30;
                        var viewColumn = dgvInventarioPlatillos.Columns["Observacion"];
                        if (viewColumn != null) viewColumn.Width = 290;

                        var column = dgvInventarioPlatillos.Columns["CR"];
                        if (column != null)
                            column.DefaultCellStyle.BackColor = Color.Coral;
                        var dataGridViewColumn1 = dgvInventarioPlatillos.Columns["SR"];
                        if (dataGridViewColumn1 != null)
                            dataGridViewColumn1.DefaultCellStyle.BackColor = Color.Coral;
<<<<<<< HEAD
                        dgvInventarioPlatillos.Columns["Observacion"].DefaultCellStyle.BackColor = Color.Coral;
=======
<<<<<<< HEAD

                        Data.Reporte.RepDiarioAct(xxx =>

                        {
                            ListDiarioDs = Opcion.JsonaListaGenerica<Respuesta.Reporte.RespuestaCocina.Comprobacion>(xxx);
                            for (var i = 0; i < dgvInventarioPlatillos.RowCount; i++)
                            {
                                var y = dgvInventarioPlatillos.Rows[i].Cells["Platillo"].Value.ToString();
                                for (var j = 0; j < ListDiarioDs.Count; j++)
                                {
                                    var x = ListDiarioDs[j].Platillo;
                                    if (x == y)
                                    {
                                        Xyz = i;
                                        var dataGridViewImageColumn = (DataGridViewImageColumn)dgvInventarioPlatillos.Columns["Guardar"];
                                        if (dataGridViewImageColumn != null)
                                            dataGridViewImageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
                                        dgvInventarioPlatillos.Rows[i].Cells["CR"].Value = ListDiarioDs[j].Cr;
                                        dgvInventarioPlatillos.Rows[i].Cells["SR"].Value = ListDiarioDs[j].Sr;
                                        dgvInventarioPlatillos.Rows[i].Cells["Observacion"].Value = ListDiarioDs[j].Observacion;
                                        dgvInventarioPlatillos.Rows[i].Cells["EstadoInventarioId"].Value = ListDiarioDs[j].EstadoInventarioId;
                                        dgvInventarioPlatillos.Rows[i].Cells["Guardar"].Value = Image.FromFile(@"\\mercattoserver\Recetario\icon\correcto.jpg");
                                        dgvInventarioPlatillos.Rows[i].ReadOnly = true;
                                    }
                                }
                            }
                        });
=======
>>>>>>> origin/master
                        ActualizadoDgv();
>>>>>>> 9e6b4dc81df1acd0c5142c700f76c015d8b0d931
                    }));
            });
        }
        public string Observacion;
        public string ObservacionActualizada;
        private void btGuardar_Click(object sender, EventArgs e)
        {
            var fecha = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
            const int estado = 1;
            var listEstado = new List<Receta.Savedaily>();
            var row = dgvInventarioPlatillos.CurrentCell.RowIndex;
            var inventarioid= Convert.ToInt32(dgvInventarioPlatillos.Rows[row].Cells["EstadoInventarioId"].Value);
                if (inventarioid == 0)
                {
<<<<<<< HEAD
=======
<<<<<<< HEAD
                    listEstado.Add(new Respuesta.Receta.Savedaily
                    {
                        EstadoDescripcionId = 5,
                        ArtId = dgvInventarioPlatillos.CurrentRow.Cells[0].Value.ToString(),
                        Cantidad = Convert.ToDouble(dgvInventarioPlatillos.CurrentRow.Cells["SR"].Value),
                        Clave = dgvInventarioPlatillos.CurrentRow.Cells[1].Value.ToString(),
                        Platillo = dgvInventarioPlatillos.CurrentRow.Cells[2].Value.ToString(),
                        CantidadCocina = Convert.ToDouble(dgvInventarioPlatillos.CurrentRow.Cells["CR"].Value),
                        Status = estado.ToString(),
                        Observacion = dgvInventarioPlatillos.CurrentRow.Cells["Observacion"].Value.ToString(),
                        Fecha = fecha
                    });
                    Data.MenuSemanal.Savedaily = listEstado;
                    Opcion.EjecucionAsync(Data.MenuSemanal.AgregarDiario, jsonResult =>
                    {
                        Data.Reporte.RepDiarioAct(xxx =>

                        {
                            ListDiarioDs = Opcion.JsonaListaGenerica<Respuesta.Reporte.RespuestaCocina.Comprobacion>(xxx);
                            BeginInvoke((MethodInvoker)(() =>
                            {
                                for (var i = 0; i < dgvInventarioPlatillos.RowCount; i++)
                                {
                                    var y = dgvInventarioPlatillos.Rows[i].Cells["Platillo"].Value.ToString();
                                    for (var j = 0; j < ListDiarioDs.Count; j++)
                                    {
                                        var x = ListDiarioDs[j].Platillo;
                                        if (x == y)
                                        {
                                            Xyz = i;
                                            var dataGridViewImageColumn = (DataGridViewImageColumn)dgvInventarioPlatillos.Columns["Guardar"];
                                            if (dataGridViewImageColumn != null)
=======
>>>>>>> 9e6b4dc81df1acd0c5142c700f76c015d8b0d931

>>>>>>> origin/master
                    var observacion1 = dgvInventarioPlatillos.Rows[row].Cells["Observacion"].Value;
                    if (observacion1 != null && (string)observacion1 != "")
                    {
<<<<<<< HEAD
                        EstadoInventarioId = inventarioid,
                        EstadoDescripcionId = 5,
                        ArtId = dgvInventarioPlatillos.CurrentRow.Cells[0].Value.ToString(),
                        Cantidad = Convert.ToDouble(dgvInventarioPlatillos.CurrentRow.Cells["SR"].Value),
                        Clave = dgvInventarioPlatillos.CurrentRow.Cells[1].Value.ToString(),
                        Platillo = dgvInventarioPlatillos.CurrentRow.Cells[2].Value.ToString(),
                        CantidadCocina = Convert.ToDouble(dgvInventarioPlatillos.CurrentRow.Cells["CR"].Value),
                        Status = estado.ToString(),
                        Observacion = dgvInventarioPlatillos.CurrentRow.Cells["Observacion"].Value.ToString(),
                        Fecha = fecha
                    };
                    Data.MenuSemanal.ActualizarDestino(listado);
                    Data.MenuSemanal.Savedaily = listEstado;
                    Opcion.EjecucionAsync(Data.MenuSemanal.AgregarDiario, jsonResult =>
=======
                        Observacion = observacion1.ToString();
                    }
                    else
>>>>>>> 9e6b4dc81df1acd0c5142c700f76c015d8b0d931
                    {
                        Observacion = "";
                    }
                    if (rbcongelado.Checked)
                    {
<<<<<<< HEAD
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
                        Data.MenuSemanal.savedaily = listEstado;
=======
                        listEstado.Add(new Receta.Savedaily
                        {
                            EstadoDescripcionId = 1,
                            ArtId = dgvInventarioPlatillos.CurrentRow.Cells[0].Value.ToString(),
                            Cantidad = Convert.ToDouble(dgvInventarioPlatillos.CurrentRow.Cells["SR"].Value),
                            Clave = dgvInventarioPlatillos.CurrentRow.Cells[1].Value.ToString(),
                            Platillo = dgvInventarioPlatillos.CurrentRow.Cells[2].Value.ToString(),
                            CantidadCocina = Convert.ToDouble(dgvInventarioPlatillos.CurrentRow.Cells["CR"].Value),
                            Status = estado.ToString(),
                            Observacion = Observacion.ToString(),
                            Fecha = fecha
                        });
                        Data.MenuSemanal.Savedaily = listEstado;
>>>>>>> origin/master
                        Opcion.EjecucionAsync(Data.MenuSemanal.AgregarDiario, jsonResult =>
                        {
                            ActualizadoDgv();
                        });
                } 
                if (rbmerma.Checked)
                    {
<<<<<<< HEAD
                        if (dgvInventarioPlatillos.CurrentRow != null)
                            listEstado.Add(new Receta.Savedaily
                            {
                                EstadoDescripcionId = 2,
                                ArtId = dgvInventarioPlatillos.CurrentRow.Cells[0].Value.ToString(),
                                Cantidad = Convert.ToDouble(dgvInventarioPlatillos.CurrentRow.Cells["SR"].Value),
                                Clave = dgvInventarioPlatillos.CurrentRow.Cells[1].Value.ToString(),
                                Platillo = dgvInventarioPlatillos.CurrentRow.Cells[2].Value.ToString(),
                                CantidadCocina = Convert.ToDouble(dgvInventarioPlatillos.CurrentRow.Cells["CR"].Value),
                                Status = estado.ToString(),
                                Observacion = Observacion,
                                Fecha = fecha
                            });
                        Data.MenuSemanal.savedaily = listEstado;
=======
                        listEstado.Add(new Receta.Savedaily
                        {
                            EstadoDescripcionId = 2,
                            ArtId = dgvInventarioPlatillos.CurrentRow.Cells[0].Value.ToString(),
                            Cantidad = Convert.ToDouble(dgvInventarioPlatillos.CurrentRow.Cells["SR"].Value),
                            Clave = dgvInventarioPlatillos.CurrentRow.Cells[1].Value.ToString(),
                            Platillo = dgvInventarioPlatillos.CurrentRow.Cells[2].Value.ToString(),
                            CantidadCocina = Convert.ToDouble(dgvInventarioPlatillos.CurrentRow.Cells["CR"].Value),
                            Status = estado.ToString(),
                            Observacion = Observacion.ToString(),
                            Fecha = fecha
                        });
                        Data.MenuSemanal.Savedaily = listEstado;
>>>>>>> origin/master
                        Opcion.EjecucionAsync(Data.MenuSemanal.AgregarDiario, jsonResult =>
                        {
                            ActualizadoDgv();
                        });
                    }           
                    if (rbreventa.Checked)
                    {
<<<<<<< HEAD
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
                        Data.MenuSemanal.savedaily = listEstado;
=======
                        listEstado.Add( new Receta.Savedaily
                        {
                            EstadoDescripcionId = 4,
                            ArtId = dgvInventarioPlatillos.CurrentRow.Cells[0].Value.ToString(),
                            Cantidad = Convert.ToDouble(dgvInventarioPlatillos.CurrentRow.Cells["SR"].Value),
                            Clave = dgvInventarioPlatillos.CurrentRow.Cells[1].Value.ToString(),
                            Platillo = dgvInventarioPlatillos.CurrentRow.Cells[2].Value.ToString(),
                            CantidadCocina = Convert.ToDouble(dgvInventarioPlatillos.CurrentRow.Cells["CR"].Value),
                            Status = estado.ToString(),
                            Observacion = Observacion.ToString(),
                            Fecha = fecha
                        });
                        Data.MenuSemanal.Savedaily = listEstado;
>>>>>>> origin/master
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
                                Status = estado.ToString(),
                                Observacion = Observacion,
                                Fecha = fecha
                            });
                        Data.MenuSemanal.savedaily = listEstado;
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
                                Status = estado.ToString(),
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
                                Status = estado.ToString(),
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
            var z = Convert.ToDouble(dgvInventarioPlatillos.Rows[Xyz].Cells[4].Value);
            var y = Convert.ToDouble(dgvInventarioPlatillos.Rows[Xyz].Cells[5].Value);
            dgvInventarioPlatillos.Rows[e.RowIndex].Cells["S"].Value = Math.Round(z - y, 2);
        }
        private void btCargarDiarios_Click(object sender, EventArgs e)
        {
            dgvDiarios.DataSource = null;
            dgvDiarios.Columns.Clear();
            dgvDiarios.Rows.Clear();
            var fechainicior = DateTime.Now.AddDays(-31).ToString("yyyy-MM-dd");
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
<<<<<<< HEAD
                            dgvDiarios.DataSource = Opcion.JsonaListaGenerica<Respuesta.Reporte.RespuestaCocina.RepoDiario>(jsonResult);
=======
                            dgvDiarios.DataSource = Opcion.JsonaListaGenerica<Reporte.RespuestaCocina.Repo_Diario>(jsonResult);
<<<<<<< HEAD
                            dgvDiarios.Columns["Platillo"].ReadOnly = true;
                            dgvDiarios.Columns["Clave"].ReadOnly = true;
                            dgvDiarios.Columns["Existencia"].ReadOnly = true;
                            dgvDiarios.Columns["CP"].ReadOnly = true;
                            dgvDiarios.Columns["Ventaanterior"].ReadOnly = true;
                            dgvDiarios.Columns["VentaPromedio"].ReadOnly = true;
=======
>>>>>>> 9e6b4dc81df1acd0c5142c700f76c015d8b0d931
>>>>>>> origin/master
                            break;
                        default:
                            MessageBox.Show(@"Comunicar al area de Sistemas");
                            break;
                    }
                    DiseñoDgvDiario();
                    btGuardarDiarios.Enabled = true;
                    btPreviaGlobal.Enabled = true;
                    btPreviaPlatillo.Enabled = true;
                    me.Close();
                }));
                 
                }
            else
            {
                    BeginInvoke((MethodInvoker)(() =>
                    {
                        me.Close();
                        MessageBox.Show(@"No se encontraron datos con los parametros de busqueda ingresados");
                    }));
                   
            }
            });
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
                var clave= Convert.ToString(dgvDiarios.Rows[i].Cells["Clave"].Value.ToString());
                var platillo= Convert.ToString(dgvDiarios.Rows[i].Cells["Platillo"].Value.ToString());
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
            const int estado =1;
            var listEstado = new List<Receta.Savedaily>();
            if (MessageBox.Show(@"La informacion a guardar es la correcta", @"Aviso", MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question) == DialogResult.Yes)
            { 
                for (var i = 0; i < dgvDiarios.Rows.Count; i++)
            {
              var lista = new Receta.Savedaily
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
                    listEstado.Add(new Receta.Savedaily
                    {
                        ArtId = dgvDiarios.Rows[i].Cells["ArtId"].Value.ToString(),
                        Clave = dgvDiarios.Rows[i].Cells["Clave"].Value.ToString(),
                        Platillo = dgvDiarios.Rows[i].Cells["Platillo"].Value.ToString(),
                        CantidadCocina = Convert.ToDouble(dgvDiarios.Rows[i].Cells["CR"].Value.ToString()),
                        Fecha = fechaactual
                    });
                    Data.MenuSemanal.savedaily = listEstado;
                    Opcion.EjecucionAsync(Data.MenuSemanal.AgregarDiario, jsonResult =>
                    {
                    });

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
            }
            MessageBox.Show(this, @"Platillo eliminado con existo");
        }
        private void DiseñoDgvDiario()
        {
            dgvDiarios.RowHeadersVisible = false;
            dgvDiarios.DefaultCellStyle.Font = new Font("Segoe UI Light", 8, FontStyle.Bold);
            dgvDiarios.Columns[0].Width = 100;
            dgvDiarios.Columns[1].Width = 200;
            dgvDiarios.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDiarios.Columns[2].Width = 110;
            dgvDiarios.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDiarios.Columns[3].Width = 40;
            dgvDiarios.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDiarios.Columns[4].Width = 40;
            dgvDiarios.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDiarios.Columns[5].Width = 40;
            dgvDiarios.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDiarios.Columns[6].Width = 140;
            dgvDiarios.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDiarios.Columns[7].Width = 150;
            var dataGridViewColumn = dgvDiarios.Columns["EstadoInventarioId"];
            if (dataGridViewColumn != null)
                dataGridViewColumn.Visible = false;
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
                                ListDiarioDs = Opcion.JsonaListaGenerica<Reporte.RespuestaCocina.Comprobacion>(z);
                                for (var i = 0; i < dgvInventarioPlatillos.RowCount; i++)
                                {
                                    var y = dgvInventarioPlatillos.Rows[i].Cells["Platillo"].Value.ToString();
                                    // ReSharper disable once ForCanBeConvertedToForeach
                                    for (var j = 0; j < ListDiarioDs.Count; j++)
                                    {
                                        var x = ListDiarioDs[j].Platillo;
                                        if (x == y)
                                        {
                                            Xyz = i;
                                            var dataGridViewImageColumn = (DataGridViewImageColumn)dgvInventarioPlatillos.Columns["Guardar"];
                                            if (dataGridViewImageColumn != null)
                                                dataGridViewImageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
                                            dgvInventarioPlatillos.Rows[i].Cells["CR"].Value = ListDiarioDs[j].CR;
                                            dgvInventarioPlatillos.Rows[i].Cells["SR"].Value = ListDiarioDs[j].SR;
                                            dgvInventarioPlatillos.Rows[i].Cells["Observacion"].Value = ListDiarioDs[j].Observacion;
                                            dgvInventarioPlatillos.Rows[i].Cells["EstadoInventarioId"].Value = ListDiarioDs[j].EstadoInventarioId;
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
    }
 }
                
