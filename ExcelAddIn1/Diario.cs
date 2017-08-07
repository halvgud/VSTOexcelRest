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
        private List<IngredientesReceta> _listaArticuloBasica2;
        private List<IngredientesReceta> _listaArticuloBasica3;

        private readonly List<Final> _endList;
        public int EstadoInventarioIdd;
        public Diario()
        {
            _listaArticuloBasica1 = new List<IngredientesReceta>();
            _listaArticuloBasica2 = new List<IngredientesReceta>();
            _listaArticuloBasica3 = new List<IngredientesReceta>();
            InitializeComponent();
            _endList = new List<Final>();
        }
        public class Final
        {
            public int Id { get; set; }
            public String Destino { get; set; }
            
        }
        public List<Respuesta.Diario> Lista;
        public List<DiarioX2> ListaX2S;
        public List<Reporte.RespuestaCocina.Comprobacion> ListDiarioDs;
        public List<Cocina.ReporteDiarioCocina.FechasReporte> _ListfechasList;
        public int Xyz;

        private void Diario_Load(object sender, EventArgs e)
        {
            //borrar si ya fue guardado el dato
            #region fechas

            string fecha = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd 07:00:00");
            string fecha1 = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd 21:00:00");
            string fecha1R = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd 00:00:00");
            var fechas = new Receta.Diaanterior
            {
                Fecha1 = fecha,
                Fecha2 = fecha1
            };

            Data.Reporte.AntesDiaanterior = fechas;
            //Cocina.DiaAntesX2.FechaX2 = fecha1R;
            #endregion

            _endList.Add(new Final {Destino = "CONGELADO",  Id = 1});
            _endList.Add(new Final {Destino="MERMA",Id=2});
            _endList.Add(new Final {Destino="EMPLEADOS", Id=3});
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
                        var dataGridViewColumn = dgvInventarioPlatillos.Columns["Guardar"];
                        if (dataGridViewColumn != null) dataGridViewColumn.DisplayIndex = 9;
                        dgvInventarioPlatillos.DefaultCellStyle.Font = new Font("Segoe UI Light", 8, FontStyle.Bold);
                        var gridViewColumn = dgvInventarioPlatillos.Columns["Guardar"];
                        if (gridViewColumn != null) gridViewColumn.Width = 30;
                        dgvInventarioPlatillos.Columns[0].Visible = false;
                        //var gridViewColumn1 = dgvInventarioPlatillos.Columns["EstadoInventarioId"];
                        //if (gridViewColumn1 != null)
                        //    gridViewColumn1.Visible = false;
                        dgvInventarioPlatillos.Columns[1].Width = 70;
                        //dgvInventarioPlatillos.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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
                        //dgvInventarioPlatillos.Columns[9].Width = 30;
                        //dgvInventarioPlatillos.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dgvInventarioPlatillos.Columns[10].Width = 30;
                        var viewColumn = dgvInventarioPlatillos.Columns["Observacion"];
                        if (viewColumn != null) viewColumn.Width = 290;

                        var column = dgvInventarioPlatillos.Columns["CR"];
                        if (column != null)
                            column.DefaultCellStyle.BackColor = Color.Coral;
                        var dataGridViewColumn1 = dgvInventarioPlatillos.Columns["SR"];
                        if (dataGridViewColumn1 != null)
                            dataGridViewColumn1.DefaultCellStyle.BackColor = Color.Coral;

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
                                        dgvInventarioPlatillos.Rows[i].Cells["CR"].Value = ListDiarioDs[j].CR;
                                        dgvInventarioPlatillos.Rows[i].Cells["SR"].Value = ListDiarioDs[j].SR;
                                        dgvInventarioPlatillos.Rows[i].Cells["Observacion"].Value = ListDiarioDs[j].Observacion;
                                        dgvInventarioPlatillos.Rows[i].Cells["EstadoInventarioId"].Value = ListDiarioDs[j].EstadoInventarioId;
                                        dgvInventarioPlatillos.Rows[i].Cells["Guardar"].Value = Image.FromFile(@"\\mercattoserver\Recetario\icon\correcto.jpg");
                                        dgvInventarioPlatillos.Rows[i].ReadOnly = true;
                                    }
                                }
                            }
                        });
                    }));
                });          
        }
        private void btGuardar_Click(object sender, EventArgs e)
        {
            var fecha = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
            var estado = 1;
            var listEstado = new List<Receta.Savedaily>();
            var row = dgvInventarioPlatillos.CurrentCell.RowIndex;
            var inventarioid= Convert.ToInt32(dgvInventarioPlatillos.Rows[row].Cells["EstadoInventarioId"].Value);

            if (dgvInventarioPlatillos.CurrentRow != null && Convert.ToInt16(dgvInventarioPlatillos.CurrentRow.Cells["S"].Value) == 0)
            {
                //estado = -1;
                if (inventarioid == 0)
                {
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
                    Data.MenuSemanal.savedaily = listEstado;
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

                                                dgvInventarioPlatillos.Rows[i].Cells["EstadoInventarioId"].Value = ListDiarioDs[j].EstadoInventarioId;
                                            dgvInventarioPlatillos.Rows[i].Cells["Observacion"].Value = ListDiarioDs[j].Observacion;
                                            dataGridViewImageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
                                            dgvInventarioPlatillos.Rows[Xyz].Cells["Guardar"].Value = Image.FromFile(@"\\mercattoserver\Recetario\icon\correcto.jpg");
                                            dgvInventarioPlatillos.Rows[Xyz].ReadOnly = true;
                                        }
                                    }
                                }
                            }));
                        });
                    });
                }
                else
                {
                    var listado=new Receta.Savedaily
                    {
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
                    Data.MenuSemanal.savedaily = listEstado;
                    Opcion.EjecucionAsync(Data.MenuSemanal.AgregarDiario, jsonResult =>
                    {
                        BeginInvoke((MethodInvoker)(() =>
                        {
                            var dataGridViewImageColumn = (DataGridViewImageColumn)dgvInventarioPlatillos.Columns["Guardar"];
                            if (dataGridViewImageColumn != null)
                                dataGridViewImageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
                            dgvInventarioPlatillos.Rows[Xyz].Cells["Guardar"].Value = Image.FromFile(@"\\mercattoserver\Recetario\icon\correcto.jpg");
                            dgvInventarioPlatillos.Rows[Xyz].ReadOnly = true;
                        }));
                    });
                } 
            }
            else
            {
                if (inventarioid == 0)
                {
                    if (rbcongelado.Checked)
                    {
                        listEstado.Add(new Receta.Savedaily
                        {
                            EstadoDescripcionId = 1,
                            ArtId = dgvInventarioPlatillos.CurrentRow.Cells[0].Value.ToString(),
                            Cantidad = Convert.ToDouble(dgvInventarioPlatillos.CurrentRow.Cells["SR"].Value),
                            Clave = dgvInventarioPlatillos.CurrentRow.Cells[1].Value.ToString(),
                            Platillo = dgvInventarioPlatillos.CurrentRow.Cells[2].Value.ToString(),
                            CantidadCocina = Convert.ToDouble(dgvInventarioPlatillos.CurrentRow.Cells["CR"].Value),
                            Status = estado.ToString(),
                            Observacion = dgvInventarioPlatillos.CurrentRow.Cells["Observacion"].Value.ToString(),
                            Fecha = fecha
                        });
                        Data.MenuSemanal.savedaily = listEstado;
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

                                                    dgvInventarioPlatillos.Rows[i].Cells["EstadoInventarioId"].Value = ListDiarioDs[j].EstadoInventarioId;
                                                dgvInventarioPlatillos.Rows[i].Cells["Observacion"].Value = ListDiarioDs[j].Observacion;
                                                dataGridViewImageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
                                                dgvInventarioPlatillos.Rows[Xyz].Cells["Guardar"].Value = Image.FromFile(@"\\mercattoserver\Recetario\icon\correcto.jpg");
                                                dgvInventarioPlatillos.Rows[Xyz].ReadOnly = true;
                                            }
                                        }
                                    }
                                }));
                            });
                        });
                    }
                
                if (rbmerma.Checked)
                    {
                        listEstado.Add(new Receta.Savedaily
                        {
                            EstadoDescripcionId = 2,
                            ArtId = dgvInventarioPlatillos.CurrentRow.Cells[0].Value.ToString(),
                            Cantidad = Convert.ToDouble(dgvInventarioPlatillos.CurrentRow.Cells["SR"].Value),
                            Clave = dgvInventarioPlatillos.CurrentRow.Cells[1].Value.ToString(),
                            Platillo = dgvInventarioPlatillos.CurrentRow.Cells[2].Value.ToString(),
                            CantidadCocina = Convert.ToDouble(dgvInventarioPlatillos.CurrentRow.Cells["CR"].Value),
                            Status = estado.ToString(),
                            Observacion = dgvInventarioPlatillos.CurrentRow.Cells["Observacion"].Value.ToString(),
                            Fecha = fecha
                        });
                        Data.MenuSemanal.savedaily = listEstado;
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

                                                    dgvInventarioPlatillos.Rows[i].Cells["EstadoInventarioId"].Value = ListDiarioDs[j].EstadoInventarioId;
                                                dgvInventarioPlatillos.Rows[i].Cells["Observacion"].Value = ListDiarioDs[j].Observacion;
                                                dataGridViewImageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
                                                dgvInventarioPlatillos.Rows[Xyz].Cells["Guardar"].Value = Image.FromFile(@"\\mercattoserver\Recetario\icon\correcto.jpg");
                                                dgvInventarioPlatillos.Rows[Xyz].ReadOnly = true;
                                            }
                                        }
                                    }
                                }));
                            });
                        });
                    }
                    
                    if (rbreventa.Checked)
                    {
                        listEstado.Add( new Receta.Savedaily
                        {
                            EstadoDescripcionId = 4,
                            ArtId = dgvInventarioPlatillos.CurrentRow.Cells[0].Value.ToString(),
                            Cantidad = Convert.ToDouble(dgvInventarioPlatillos.CurrentRow.Cells["SR"].Value),
                            Clave = dgvInventarioPlatillos.CurrentRow.Cells[1].Value.ToString(),
                            Platillo = dgvInventarioPlatillos.CurrentRow.Cells[2].Value.ToString(),
                            CantidadCocina = Convert.ToDouble(dgvInventarioPlatillos.CurrentRow.Cells["CR"].Value),
                            Status = estado.ToString(),
                            Observacion = dgvInventarioPlatillos.CurrentRow.Cells["Observacion"].Value.ToString(),
                            Fecha = fecha
                        });
                        Data.MenuSemanal.savedaily = listEstado;
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

                                                    dgvInventarioPlatillos.Rows[i].Cells["EstadoInventarioId"].Value = ListDiarioDs[j].EstadoInventarioId;
                                                dgvInventarioPlatillos.Rows[i].Cells["Observacion"].Value = ListDiarioDs[j].Observacion;
                                                dataGridViewImageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
                                                dgvInventarioPlatillos.Rows[Xyz].Cells["Guardar"].Value = Image.FromFile(@"\\mercattoserver\Recetario\icon\correcto.jpg");
                                                dgvInventarioPlatillos.Rows[Xyz].ReadOnly = true;
                                            }
                                        }
                                    }
                                }));
                            });
                        });
                    }
                }
                else
                {
                    if (rbcongelado.Checked)
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
                            Observacion = dgvInventarioPlatillos.CurrentRow.Cells["Observacion"].Value.ToString(),
                            Fecha = fecha
                        };
                        Data.MenuSemanal.ActualizarDestino(listado);

                        BeginInvoke((MethodInvoker)(() =>
                        {
                            var dataGridViewImageColumn = (DataGridViewImageColumn)dgvInventarioPlatillos.Columns["Guardar"];
                            if (dataGridViewImageColumn != null)
                                dataGridViewImageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
                            dgvInventarioPlatillos.Rows[Xyz].Cells["Guardar"].Value = Image.FromFile(@"\\mercattoserver\Recetario\icon\correcto.jpg");
                            dgvInventarioPlatillos.Rows[Xyz].ReadOnly = true;
                        }));
                    }
                    if (rbmerma.Checked)
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
                            Observacion = dgvInventarioPlatillos.CurrentRow.Cells["Observacion"].Value.ToString(),
                            Fecha = fecha
                        };
                        Data.MenuSemanal.ActualizarDestino(listado);

                        BeginInvoke((MethodInvoker)(() =>
                        {
                            var dataGridViewImageColumn = (DataGridViewImageColumn)dgvInventarioPlatillos.Columns["Guardar"];
                            if (dataGridViewImageColumn != null)
                                dataGridViewImageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
                            dgvInventarioPlatillos.Rows[Xyz].Cells["Guardar"].Value = Image.FromFile(@"\\mercattoserver\Recetario\icon\correcto.jpg");
                            dgvInventarioPlatillos.Rows[Xyz].ReadOnly = true;
                        }));
                    }

                    if (rbreventa.Checked)
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
                            Observacion = dgvInventarioPlatillos.CurrentRow.Cells["Observacion"].Value.ToString(),
                            Fecha = fecha
                        };
                        Data.MenuSemanal.ActualizarDestino(listado);

                        BeginInvoke((MethodInvoker)(() =>
                        {
                            var dataGridViewImageColumn = (DataGridViewImageColumn)dgvInventarioPlatillos.Columns["Guardar"];
                            if (dataGridViewImageColumn != null)
                                dataGridViewImageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
                            dgvInventarioPlatillos.Rows[Xyz].Cells["Guardar"].Value = Image.FromFile(@"\\mercattoserver\Recetario\icon\correcto.jpg");
                            dgvInventarioPlatillos.Rows[Xyz].ReadOnly = true;
                        }));
                    }
                }
            }
        }
        private void dgvInventarioPlatillos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Xyz = e.RowIndex;
        }
        private void dgvInventarioPlatillos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            #region Sobrante 
            var z = Convert.ToDouble(dgvInventarioPlatillos.Rows[Xyz].Cells[4].Value);
            var y = Convert.ToDouble(dgvInventarioPlatillos.Rows[Xyz].Cells[5].Value);
            dgvInventarioPlatillos.Rows[e.RowIndex].Cells["S"].Value = Math.Round(z - y, 2);
            var sobrante = Math.Round(z - y, 2);
 
            for (int i = 0; i < dgvInventarioPlatillos.RowCount; i++)
            {
                if (Convert.ToInt32(dgvInventarioPlatillos.Rows[i].Cells["S"].Value)==0)
                {
                    BeginInvoke((MethodInvoker)(() =>
                    {
                        rbcongelado.Checked = false;
                    rbmerma.Checked = false;
                    rbreventa.Checked = false;
                    btGuardar.Enabled = true;
                   }));
                }
            }
            #endregion 
        }

        private void btCargarDiarios_Click(object sender, EventArgs e)
        {
            var fechainicior = DateTime.Now.AddDays(-31).ToString("yyyy-MM-dd");
            var fechafinalr = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
            var fechas = new Cocina.ReporteDiarioCocina.FechasReporte
            {
                FechaIni = fechainicior,
                FechaFin = fechafinalr
            };

            Opcion.EjecucionAsync(x =>
            {
                Data.Reporte.RepoDiarioD(x, fechas);
            }, jsonResult =>
            {
                BeginInvoke((MethodInvoker)(() =>
                {
                    switch (jsonResult.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            dgvDiarios.DataSource = Opcion.JsonaListaGenerica<Respuesta.Reporte.RespuestaCocina.Repo_Diario>(jsonResult);
                            break;
                        default:
                            MessageBox.Show(@"Comunicar al area de Sistemas");
                            break;
                    }
                    dgvDiarios.RowHeadersVisible = false;
                    dgvDiarios.DefaultCellStyle.Font = new Font("Segoe UI Light", 8, FontStyle.Bold);
                    dgvDiarios.Columns[0].Width = 90;
                    //dgvInventarioPlatillos.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvDiarios.Columns[1].Width = 250;
                    dgvDiarios.Columns[2].Width = 120;
                    dgvDiarios.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvDiarios.Columns[3].Width = 50;
                    dgvDiarios.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvDiarios.Columns[4].Width = 50;
                    dgvDiarios.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvDiarios.Columns[5].Width = 50;
                    dgvDiarios.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvDiarios.Columns[6].Width = 150;
                    dgvDiarios.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvDiarios.Columns[7].Width = 150;
                    dgvDiarios.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    var column = dgvDiarios.Columns["CE"];
                    if (column != null)
                        column.DefaultCellStyle.BackColor = Color.Coral;
                    var dataGridViewColumn1 = dgvDiarios.Columns["CR"];
                    if (dataGridViewColumn1 != null)
                        dataGridViewColumn1.DefaultCellStyle.BackColor = Color.Coral;
                }));
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
        {
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
            //var row = dgvInventarioPlatillos.CurrentCell.RowIndex;
            const int estado = 1;
            for (var i = 0; i < dgvDiarios.Rows.Count; i++)
            {
              var lista = new Receta.ReventaDiarios
            {
                EstadoInventarioId = Convert.ToInt32(dgvDiarios.CurrentRow.Cells["EstadoInventarioId"].Value),
                EstadoDescripcionId = 5,
                Cantidad = 0,
                Clave = dgvDiarios.CurrentRow.Cells[0].Value.ToString(),
                Platillo = dgvDiarios.CurrentRow.Cells[1].Value.ToString(),
                Fecha = fecha
                };
            Data.MenuSemanal.ActualizarReventadiarios(lista);

            BeginInvoke((MethodInvoker)(() =>
            {
                var dataGridViewImageColumn = (DataGridViewImageColumn)dgvInventarioPlatillos.Columns["Guardar"];
                if (dataGridViewImageColumn != null)
                    dataGridViewImageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
                dgvInventarioPlatillos.Rows[Xyz].Cells["Guardar"].Value = Image.FromFile(@"\\mercattoserver\Recetario\icon\correcto.jpg");
                dgvInventarioPlatillos.Rows[Xyz].ReadOnly = true;
            }));
            }
        }
    }
 }
                
