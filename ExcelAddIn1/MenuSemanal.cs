using System;
using System.Windows.Forms;
using Respuesta;
using Herramienta;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Net;
using System.Drawing;
using System.Linq;
using Herramienta.Config;
using Rectangle = System.Drawing.Rectangle;

namespace ExcelAddIn1
{
    public partial class MenuSemanal : Form
    {
        #region Variables
        //Drop and Drag datagridview rows
        private Rectangle _dragBoxFromMouseDown;
        private int _rowIndexFromMouseDown;
        DataGridView dgv1Lunes { get; set; }
        DataGridView dgv1Martes { get; set; }
        DataGridView dgv1Miercoles { get; set; }
        DataGridView dgv1Jueves { get; set; }
        DataGridView dgv1Viernes { get; set; }
        DataGridView dgv1Sabado { get; set; }
        DataGridView dgv1Domingo { get; set; }
        #endregion
        public MenuSemanal()
        {
            _listaArticuloBasica1 = new List<IngredientesReceta>();
            _listaArticuloBasica2 = new List<IngredientesReceta>();
            _listaPlatilloLunes = new List<PlatilloReceta>();
            _listaPlatilloMartes= new List<PlatilloReceta>();
            _listaPlatilloMiercoles = new List<PlatilloReceta>();
            _listaPlatilloJueves = new List<PlatilloReceta>();
            _listaPlatilloViernes = new List<PlatilloReceta>();
            _listaPlatilloSabado = new List<PlatilloReceta>();
            _listaPlatilloDomingo = new List<PlatilloReceta>();
            _listaPlatilloArreglo= new List<PlatilloReceta>();
            _listaPlatilloTodos= new List<PlatilloReceta>();
            InitializeComponent();
            dgv1Lunes = dgvLunes;
            dgv1Martes = dgvMartes;
            dgv1Miercoles = dgvMiercoles;
            dgv1Jueves = dgvJueves;
            dgv1Viernes = dgvViernes;
            dgv1Sabado = dgvSabado;
            dgv1Domingo = dgvDomingo;
            _tiposrecetas = new List<TipoRecetas>();
        }

       
        private void MenuSemanal_Load(object sender, EventArgs e)
        {
            Opcion.EjecucionAsync(Data.ParametroProducto.Lista, x =>
            {
                CargarComboBox(x, cbTipoReceta);
            });

            DoubleBuffered = true;
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
                              ListaActualizarListr   = liq.Where(x => x.Modificacion == "Actualizar").ToList();
                                if (ListaActualizarListr.Count > 0)
                                {
                                    if ((MessageBox.Show(@"Visualizar Menu de Productos con Precio Nuevo", @" ", MessageBoxButtons.YesNo) == DialogResult.Yes))
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
            PopulateManualCombo();
            dgvLunes.Tag = new PropiedadesDgv { IdDia = 1, NombreDia = "Lunes", LabelFecha = FechaLunes,DGV=dgvLunes };
            dgvMartes.Tag = new PropiedadesDgv { IdDia = 2, NombreDia = "Martes", LabelFecha = FechaMartes, DGV = dgvMartes };
            dgvMiercoles.Tag = new PropiedadesDgv { IdDia = 3, NombreDia = "Miercoles", LabelFecha = FechaMiercoles, DGV = dgvMiercoles };
            dgvJueves.Tag = new PropiedadesDgv { IdDia = 4, NombreDia = "Jueves", LabelFecha = FechaJueves, DGV = dgvJueves };
            dgvViernes.Tag = new PropiedadesDgv { IdDia = 5, NombreDia = "Viernes", LabelFecha = FechaViernes , DGV = dgvViernes};
            dgvSabado.Tag = new PropiedadesDgv { IdDia = 6, NombreDia = "Sabado", LabelFecha = FechaSabado , DGV = dgvSabado};
            dgvDomingo.Tag = new PropiedadesDgv { IdDia = 7, NombreDia = "Domingo", LabelFecha = FechaDomingo , DGV = dgvDomingo};

            _tiposrecetas.Add(new TipoRecetas { IdReceta = 1, TipoReceta = "Guarnicion" });
            _tiposrecetas.Add(new TipoRecetas { IdReceta = 2, TipoReceta = "Fritangas" });
            _tiposrecetas.Add(new TipoRecetas { IdReceta = 3, TipoReceta = "Res" });
            _tiposrecetas.Add(new TipoRecetas { IdReceta = 4, TipoReceta = "Postre" });
            _tiposrecetas.Add(new TipoRecetas { IdReceta = 5, TipoReceta = "Diario" });
            _tiposrecetas.Add(new TipoRecetas { IdReceta = 6, TipoReceta = "Carniceria" });
            _tiposrecetas.Add(new TipoRecetas { IdReceta = 7, TipoReceta = "Salsas" });
            _tiposrecetas.Add(new TipoRecetas { IdReceta = 8, TipoReceta = "Cerdo" });
            _tiposrecetas.Add(new TipoRecetas { IdReceta = 9, TipoReceta = "Pollo" });
            _tiposrecetas.Add(new TipoRecetas { IdReceta = 10, TipoReceta = "Mariscos" });
            btPreviaPlatilloGlobal.Enabled = false;
            btPreviaPlatillo.Enabled = false;
            btAgregarSemana.Enabled = false;
            btGuardar.Enabled = false;
            tbPlatillo.Enabled= false;
            cbTipoReceta.Enabled = false;
            btPlatillo.Enabled= false;
            ckPlatillo.Enabled = false;
            ckTipoReceta.Enabled = false;
            label2.Enabled = false;
            btOrdenTrabajo.Enabled = false;
            vScrollBar2.Enabled = false;
            btImprimirMenu.Enabled=false;
            btBorrarFila.Enabled = false;
        }
        // ReSharper disable once FunctionComplexityOverflow
        private void InicializarDgv(Control parent)
        {          
            foreach (Control c in parent.Controls)
            {
                IncializarDgvDetalle(c);
            }
        }
        bool flagDataSource = false;
        private void IncializarDgvDetalle(Control parent1)
        {
            var view = parent1 as DataGridView;
            if (view != null)
            {
                var pivote = view;
                if (!flagDataSource) { 
                pivote.DataSource = null;
                pivote.Rows.Clear();
                pivote.Columns.Clear();
                btGuardar.Enabled = false;
                    //var col = new DataGridViewComboBoxColumn
                    //{
                    //    Name = "TipoReceta",
                    //    DataPropertyName = "TipoReceta",
                    //    HeaderText = @"TipoReceta",
                    //    DataSource = _tiposrecetas,
                    //    DisplayMember = "TipoReceta",
                    //    ValueMember = "TipoReceta"
                    //};

                    //pivote.Columns.Add(col);
                }
                var propiedadesDgv = pivote.Tag as PropiedadesDgv;
                if (propiedadesDgv != null && !flagDataSource)
                pivote.DataSource = this[propiedadesDgv.NombreDia] as BindingList<MenuDia>;
                //pivote.Columns["CantidadReceta"].ReadOnly = true;
                pivote.Columns["Venta"].ReadOnly = true;
                pivote.Columns["Precio"].ReadOnly = true;
                pivote.Columns["Congelado"].ReadOnly = true;
                pivote.Columns["Unidad"].ReadOnly = true;
                pivote.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                //pivote.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 6);
                pivote.Columns[0].Width = 70;
                pivote.Columns[1].Width = 230;
                pivote.Columns["Unidad"].Width = 40;
                pivote.Columns["Venta"].Width = 50;
                pivote.Columns["Congelado"].Width = 50;
                pivote.Columns["Precio"].Width = 50;
                pivote.Columns["CantidadElab"].Width = 65;
                pivote.AllowUserToAddRows = true;
                pivote.RowHeadersVisible = false;
                pivote.Columns["Unidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                var dataGridViewColumn = pivote.Columns["CantidadElab"];
                if (dataGridViewColumn != null)
                    dataGridViewColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                var gridViewColumn = pivote.Columns["Precio"];
                if (gridViewColumn != null)
                    gridViewColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                var viewColumn = pivote.Columns["Venta"];
                if (viewColumn != null)
                    viewColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                var dataGridViewColumn2 = pivote.Columns["Congelado"];
                if (dataGridViewColumn2 != null)
                    dataGridViewColumn2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                var gridViewColumn2 = pivote.Columns["CantidadReceta"];
                if (gridViewColumn2 != null)
                    gridViewColumn2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                var gridViewColumn1 = pivote.Columns["MenId"];
                if (gridViewColumn1 != null) gridViewColumn1.Visible = false;
                pivote.Columns["UltimaElaboracion"].Visible = false;
                pivote.Columns["CantidadReceta"].Visible = false;
                montototal(pivote);

                var fecha = DateTime.Parse((pivote.Tag as PropiedadesDgv)?.LabelFecha.Text, CultureInfo.CurrentCulture);
                var result = DateTime.Compare(fecha, DateTime.Today);
                if (result >= 0)
                {
                    for (var x = 0; x < pivote.Rows.Count; x++)
                    {
                        if (Convert.ToInt32(pivote.Rows[x].Cells["Congelado"].Value) > 0)
                        {
                            MessageBox.Show(@"Existe congelado en en Menú del dia " + @" " + (pivote.Tag as PropiedadesDgv)?.NombreDia + @" " + @"favor de verificar");
                        }
                        //pivote.Rows[x].Cells["CantidadReceta"].Style.BackColor = Color.Orange;
                        pivote.Rows[x].Cells["Precio"].Style.BackColor = Color.Orange;
                        pivote.Rows[x].Cells["Venta"].Style.BackColor = Color.Orange;
                        pivote.Rows[x].Cells["Unidad"].Style.BackColor = Color.Orange;
                        //pivote.Columns["Congelado"].Width = 80;
                        //pivote.Columns["Precio"].Width = 80;
                    }
                    pivote.Enabled = true;
                    pivote.DefaultCellStyle.BackColor = Color.Gainsboro;

                    btGuardar.Enabled = true;
                }
                else
                {
                    pivote.Columns["TipoReceta"].ReadOnly = true;
                    pivote.Columns["Platillo"].ReadOnly = true;
                    pivote.Columns["CantidadReceta"].ReadOnly = true;
                    pivote.Columns["CantidadElab"].ReadOnly = true;
                    pivote.Columns["Unidad"].ReadOnly = true;
                    pivote.Columns["Precio"].ReadOnly = true;
                    pivote.Columns["Venta"].ReadOnly = true;
                    pivote.Columns["Congelado"].ReadOnly = true;
                    pivote.Columns["MenId"].ReadOnly = true;
                    pivote.Columns["Congelado"].Width = 80;
                    pivote.Columns["Precio"].Width = 80;
                    pivote.Columns["CantidadElab"].Width = 65;
                    pivote.Columns["Congelado"].Visible = false;
                    pivote.Columns["CantidadReceta"].Visible = false;
                    pivote.DefaultCellStyle.BackColor = Color.Yellow;
                   
                }
                foreach (DataGridViewRow row in pivote.Rows)
                {
                    
                    pivote.Rows[row.Index].Cells["Congelado"].Style.BackColor = Color.Aqua;
                }
            }
            else
            {
                InicializarDgv(parent1);
            }
        }
        private void DgvVacios(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                var view = c as DataGridView;
                if (view != null)
                {
                    CheckForIllegalCrossThreadCalls = false;
                    var pivote = view;
                    var fecha = DateTime.Parse((pivote.Tag as PropiedadesDgv)?.LabelFecha.Text, CultureInfo.CurrentCulture);
                    var result = DateTime.Compare(fecha, DateTime.Today);
                    if (result >= 0)
                    {
                        ////BindingList<MenuDia> filavacia=new BindingList<MenuDia>();
                        ////filavacia.Add(new MenuDia());

                        //pivote.DataSource = new BindingList<MenuDia>();

                        pivote.Rows.Clear();
                        IncializarDgvDetalle(pivote);


                    }
                    foreach (DataGridViewRow row in pivote.Rows)
                    {
                        pivote.Rows[row.Index].Cells["Congelado"].Style.BackColor = Color.Aqua;
                        pivote.Rows[row.Index].Cells["CantidadReceta"].Style.BackColor = Color.Orange;
                        pivote.Rows[row.Index].Cells["Precio"].Style.BackColor = Color.Orange;
                        pivote.Rows[row.Index].Cells["Venta"].Style.BackColor = Color.Orange;
                    }
                }
                else
                {
                    DgvVacios(c);
                }
            }
        }
        private void DtpFecha_ValueChanged(object sender, EventArgs e)
        {
            var diainicio = FirstDayOfWeek(DtpFecha.Value).ToShortDateString();
            var diafinal = LastDayOfWeek(DtpFecha.Value).ToShortDateString();
            var lunes = Convert.ToDateTime(diainicio).ToShortDateString();
            FechaLunes.Text = Convert.ToDateTime(diainicio).ToShortDateString();
            var martes= Convert.ToDateTime(diainicio).AddDays(1).ToShortDateString();
            FechaMartes.Text= Convert.ToDateTime(diainicio).AddDays(1).ToShortDateString();
            var miercoles= Convert.ToDateTime(diainicio).AddDays(2).ToShortDateString();
            FechaMiercoles.Text = Convert.ToDateTime(diainicio).AddDays(2).ToShortDateString();
            var jueves = Convert.ToDateTime(diainicio).AddDays(3).ToShortDateString();
            FechaJueves.Text= Convert.ToDateTime(diainicio).AddDays(3).ToShortDateString();
            var viernes = Convert.ToDateTime(diainicio).AddDays(4).ToShortDateString();
            FechaViernes.Text= Convert.ToDateTime(diainicio).AddDays(4).ToShortDateString();
            var sabado = Convert.ToDateTime(diainicio).AddDays(5).ToShortDateString();
            FechaSabado.Text= Convert.ToDateTime(diainicio).AddDays(5).ToShortDateString();
            var domingo= Convert.ToDateTime(diafinal).ToShortDateString();
            FechaDomingo.Text= Convert.ToDateTime(diafinal).ToShortDateString();
            LabelLunes.Text = @"Lunes: " + lunes;
            LabelMartes.Text = @"Martes: " + martes;
            LabelMiercoles.Text = @"Miercoles: " + miercoles;
            LabelJueves.Text = @"Jueves: " + jueves;
            LabelViernes.Text = @"Viernes:" + viernes;
            LabelSabado.Text = @"Sabado:" + sabado;
            LabelDomingo.Text = @"Domingo:" + domingo;
            var diainicioactual = FirstDayOfWeek(DateTime.Today);
            var diadtp = (DtpFecha.Value);
            var dtpvalue = DtpFecha.Value.ToShortDateString();
            vScrollBar2.Enabled = true;

            btPlatillo.Enabled = !(diadtp < diainicioactual);
            //cbTipoReceta.Enabled = !(diadtp < diainicioactual);
            //tbPlatillo.Enabled = !(diadtp < diainicioactual);
            label2.Enabled = !(diadtp < diainicioactual);
            ckPlatillo.Enabled = !(diadtp < diainicioactual);
            ckTipoReceta.Enabled = !(diadtp < diainicioactual);
            btOrdenTrabajo.Enabled = !(diadtp < diainicioactual);
            btBorrarFila.Enabled= !(diadtp < diainicioactual);
            btImprimirMenu.Enabled= !(diadtp < diainicioactual);
            if (diadtp < diainicioactual)
            {
                Opcion.EjecucionAsync(x =>
            {
                   var times = new Reporte.General
                {
                    FechaFin = Convert.ToDateTime(diafinal),
                    FechaIni = Convert.ToDateTime(diainicio)
                };
                Data.MenuSemanal.CargarDias(x, times);
            }, jsonResult =>
            {
                if (jsonResult != null) { 
                BeginInvoke((MethodInvoker)(() =>
                {
                    switch (jsonResult.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            Lunes= new BindingList<MenuDia>(Opcion.JsonaClaseGenerica2<Respuesta.MenuSemanal>(jsonResult).Lunes);
                            Martes =  new BindingList<MenuDia>(Opcion.JsonaClaseGenerica2<Respuesta.MenuSemanal>(jsonResult).Martes);
                            Miercoles = new BindingList<MenuDia>(Opcion.JsonaClaseGenerica2<Respuesta.MenuSemanal>(jsonResult).Miercoles);
                            Jueves =  new BindingList<MenuDia>(Opcion.JsonaClaseGenerica2<Respuesta.MenuSemanal>(jsonResult).Jueves);
                            Viernes = new  BindingList<MenuDia>(Opcion.JsonaClaseGenerica2<Respuesta.MenuSemanal>(jsonResult).Viernes);
                            Sabado = new BindingList<MenuDia>(Opcion.JsonaClaseGenerica2<Respuesta.MenuSemanal>(jsonResult).Sabado);
                            Domingo = new BindingList<MenuDia>(Opcion.JsonaClaseGenerica2<Respuesta.MenuSemanal>(jsonResult).Domingo);
                            InicializarDgv(this);
                            break;
                        default:
                            MessageBox.Show(this, @"No se encontraron menus con los parametros de busqueda ingresados");
                            break;
                    }
                }));
                }
                else
                {
                    if (_agregarSemanaActual)
                    {
                        CheckForIllegalCrossThreadCalls = false;
                        btAgregarSemana.PerformClick();
                    }
                    else
                    {
                      BorrarDgv(this);
                        MessageBox.Show(@"No se encontraron menus con los parametros de busqueda ingresados");
                    }
                }
            });
        }
            else
            {
                Opcion.EjecucionAsync(x =>
                {
                    var times = new Reporte.General
                    {
                        FechaIni = Convert.ToDateTime(diainicio),
                        FechaFin = Convert.ToDateTime(diafinal)
                    };
                    Data.MenuSemanal.CargarMenuSemanaActual(x, times);
                }, jsonResult =>
                {
                    if (jsonResult != null)
                    {
                        if (dtpvalue==diainicio && _agregarSemanaActual)
                        {
                             MessageBox.Show(@"No se pueden agregar menús pasados, ya existe un menú semanal", "", MessageBoxButtons.OK, MessageBoxIcon.Error);  
                        }
                        BeginInvoke((MethodInvoker)(() =>
                        {
                            switch (jsonResult.StatusCode)
                            {
                                case HttpStatusCode.OK:
                                    Lunes = new BindingList<MenuDia>(Opcion.JsonaClaseGenerica2<Respuesta.MenuSemanal>(jsonResult).Lunes);
                                    Martes = new BindingList<MenuDia>(Opcion.JsonaClaseGenerica2<Respuesta.MenuSemanal>(jsonResult).Martes);
                                    Miercoles = new BindingList<MenuDia>(Opcion.JsonaClaseGenerica2<Respuesta.MenuSemanal>(jsonResult).Miercoles);
                                    Jueves = new BindingList<MenuDia>(Opcion.JsonaClaseGenerica2<Respuesta.MenuSemanal>(jsonResult).Jueves);
                                    Viernes = new BindingList<MenuDia>(Opcion.JsonaClaseGenerica2<Respuesta.MenuSemanal>(jsonResult).Viernes);
                                    Sabado = new BindingList<MenuDia>(Opcion.JsonaClaseGenerica2<Respuesta.MenuSemanal>(jsonResult).Sabado);
                                    Domingo = new BindingList<MenuDia>(Opcion.JsonaClaseGenerica2<Respuesta.MenuSemanal>(jsonResult).Domingo);
                                    InicializarDgv(this);
                                    btGuardar.Enabled = true;
                                    btAgregarSemana.Enabled = false;
                                    cbDias.Text = "";
                                    break;
                                default:
                                    MessageBox.Show(this, @"No se encontraron menus con los parametros de busqueda ingresados");
                                    break;
                            }
                        }));
                    }
                    else
                    {
                        if (_agregarSemanaActual && btAgregarSemana.Enabled)
                        {
                            CheckForIllegalCrossThreadCalls = false;
                            btAgregarSemana.PerformClick();
                        }
                        else
                        {
                            DgvVacios(this);
                            MessageBox.Show(@"No se encontraron menus con los parametros de busqueda ingresados");
                        }
                    }
                });
            }
        }
        private bool _agregarSemanaActual = false;
        private void btAgregarSemana_Click(object sender, EventArgs e)
        {
            this.SuspendLayout();
            _agregarSemanaActual = true;
            DtpFecha.Value = FirstDayOfWeek(DateTime.Today.AddDays(7));
            MoverDatosSemanaActual(this);
            btAgregarSemana.Enabled = false;
            cbDias.Text = "";
            ResumeLayout();
            if (!cbDias.CheckBoxItems[0].Checked) return;
        }
        // ReSharper disable once FunctionComplexityOverflow
        private void MoverDatosSemanaActual(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                var view = c as DataGridView;
                if (view != null)
                {
                    var pivote = view;
                    var fecha = DateTime.Parse((pivote.Tag as PropiedadesDgv)?.LabelFecha.Text, CultureInfo.CurrentCulture);
                    var result = DateTime.Compare(fecha, DateTime.Now);
                    if (cbDias.CheckBoxItems[Convert.ToInt32((view.Tag as PropiedadesDgv)?.IdDia)].Checked && result > 0)
                    {
                        IncializarDgvDetalle(pivote);
                        for (var i = 0; i < pivote.Rows.Count-1; i++)
                        {
                            pivote.Rows[i].Cells["MenId"].Value = 0;
                            var platillo= pivote.Rows[i].Cells[1].Value;
                            if ((string)platillo!= "")
                            {
                                var dato = Convert.ToString(pivote.Rows[i].Cells["Platillo"].Value.ToString());
                                char[] separador = { '(', ')' };
                                var valor = Convert.ToString(dato).Split(separador);
                                var clave = valor[1];
                                Cocina.PlatillosMenus.Clave = clave;
                                var i1 = i;
                                Data.MenuSemanal.ExistenciaCongelado(y =>
                                {
                                    BeginInvoke((MethodInvoker)(() =>
                                    {
                                        var dd = Opcion.JsonaClaseGenerica<PlatilloReceta>(y).Congelado;
                                    if (dd > 0)
                                        {
                                            pivote.Rows[i1].Cells["Congelado"].Value = dd;
                                            //MessageBox.Show(@"Existe congelado en en Menú del dia " + @" " + pivote.Name + @" " + @"favor de verificar");
                                            pivote.Rows[i1].Cells["Congelado"].Style.BackColor = Color.Aqua;
                                        }
                                    }));
                                });
                              }   
                        }
                    }
                    if (cbDias.CheckBoxItems[Convert.ToInt32((view.Tag as PropiedadesDgv)?.IdDia)].Checked) continue;
                    pivote.DefaultCellStyle.BackColor = Color.Gainsboro;
                    pivote.Columns["TipoReceta"].ReadOnly = false;
                    pivote.Columns["Platillo"].ReadOnly = false;
                    pivote.Columns["CantidadElab"].ReadOnly = false;
                    //var viewColumn1 = pivote.Columns["CantidadReceta"];
                    //if (viewColumn1 != null) viewColumn1.Visible = true;
                    var column1 = pivote.Columns["Congelado"];
                    if (column1 != null) column1.Visible = true; 
                    pivote.Rows.Clear();
                    montototal(pivote);
                }

                else
                {
                    MoverDatosSemanaActual(c);
                }
            }
        }
    private void DetallePlatillos(Control parent)
        {
            var view = parent as DataGridView;
            if (view != null)
            {
                var pivote = view;
                var row = pivote.CurrentCell.RowIndex;
                for (var i = 0; i < pivote.Rows.Count -1; i++)
                {
                    if (pivote.Rows.Count > 0 & Convert.ToString(pivote.Rows[i].Cells[1].Value) != "" && pivote.Rows[i].Cells[1].Value != null)
                    {
                         var dato = Convert.ToString(pivote.Rows[i].Cells["Platillo"].Value.ToString());
                        char[] separador = { '(', ')' };
                        var valor = Convert.ToString(dato).Split(separador);
                        var clave = valor[1];
                        Cocina.PlatillosMenus.Clave = clave;
                        Data.MenuSemanal.ExistenciaCongelado(y =>
                        {
                            BeginInvoke((MethodInvoker)(() =>
                            {
                                var dd = Opcion.JsonaClaseGenerica<PlatilloReceta>(y).Congelado;
                                pivote.Rows[i-1].Cells["Congelado"].Value = dd;
                                //pivote.Rows[i].Cells["Congelado"].Style.BackColor = Color.Aqua;
                                if (Convert.ToInt16(pivote.Rows[i-1].Cells["Congelado"].Value) > 0)
                                {
                                    MessageBox.Show(@"Existe congelado en en Menú del dia favor de verificar");
                                }
                            }));
                        });
                        Data.MenuSemanal.SacarParamentrosReceta(z =>
                        {
                            BeginInvoke((MethodInvoker)(() =>
                            {
                                //var cantidadreceta = Opcion.JsonaClaseGenerica<PlatilloReceta>(z).CantidadReceta;
                                var precio = Opcion.JsonaClaseGenerica<PlatilloReceta>(z).Precio;
                                var unidad = Opcion.JsonaClaseGenerica<PlatilloReceta>(z).Unidad;
                                pivote.Rows[i-1].Cells["Precio"].Value = precio;
                                //pivote.Rows[i].Cells["CantidadReceta"].Value = cantidadreceta;
                                pivote.Rows[i-1].Cells["Unidad"].Value = unidad;
                            }));
                        });
                    }
                    montototal(pivote);
                }
            }
        }
        #region FuncionesParaMoverRows
        private void dgvGenerico_MouseMove(object sender,MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) != MouseButtons.Left) return;
            if (_dragBoxFromMouseDown == Rectangle.Empty || _dragBoxFromMouseDown.Contains(e.X, e.Y)) return;
            var dgv = (DataGridView)sender;
            var platillo =dgv.Rows[_rowIndexFromMouseDown].Cells["Platillo"].Value.ToString();
            var c =(this[(dgv.Tag as PropiedadesDgv)?.NombreDia] as BindingList<MenuDia>)?.SingleOrDefault(x => x.Platillo.ToString() == platillo);
            DoDragDrop(new DragDropInfo(c), DragDropEffects.All);
            var propertyName = (dgv.Tag as PropiedadesDgv)?.NombreDia;
            if (propertyName != null)
            {
                (this[propertyName] as BindingList<MenuDia>)?.Remove(c);
                dgv.DataSource = null;
                //var col = new DataGridViewComboBoxColumn
                //{
                //    Name = "TipoReceta",
                //    DataPropertyName = "TipoReceta",
                //    HeaderText = @"TipoReceta",
                //    DataSource = _tiposrecetas,
                //    DisplayMember = "TipoReceta",
                //    ValueMember = "TipoReceta"
                //};
               
                //dgv.Columns.Add(col);
                dgv.DataSource = (this[propertyName] as BindingList<MenuDia>);
                var dataGridViewColum = dgv.Columns["MenId"];
                if (dataGridViewColum != null) dataGridViewColum.Visible = false;
                dgv.Columns["CantidadReceta"].Visible = false;
                dgv.Columns["UltimaElaboracion"].Visible = false;
                dgv.Columns["Unidad"].DefaultCellStyle.Alignment=DataGridViewContentAlignment.MiddleCenter;
                var dataGridViewColumn = dgv.Columns["CantidadElab"];
                if (dataGridViewColumn != null)
                    dataGridViewColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                var gridViewColumn = dgv.Columns["Precio"];
                if (gridViewColumn != null)
                    gridViewColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                var viewColumn = dgv.Columns["Venta"];
                if (viewColumn != null)
                    viewColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                var dataGridViewColumn2 = dgv.Columns["Congelado"];
                if (dataGridViewColumn2 != null)
                  dataGridViewColumn2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //var gridViewColumn2 = dgv.Columns["CantidadReceta"];
                //if (gridViewColumn2 != null)
                //    gridViewColumn2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns[0].Width = 70;
                dgv.Columns[1].Width = 230;
                dgv.Columns["Unidad"].Width = 40;
                dgv.Columns["Venta"].Width = 50;
                dgv.Columns["Congelado"].Width = 50;
                dgv.Columns["Precio"].Width = 50;
                dgv.Columns["CantidadElab"].Width = 65;
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    dgv.Rows[row.Index].Cells["Congelado"].Style.BackColor = Color.Aqua;
                    //dgv.Rows[row.Index].Cells["CantidadReceta"].Style.BackColor = Color.Orange;
                    dgv.Rows[row.Index].Cells["Precio"].Style.BackColor = Color.Orange;
                    dgv.Rows[row.Index].Cells["Venta"].Style.BackColor = Color.Orange;
                    dgv.Rows[row.Index].Cells["Unidad"].Style.BackColor = Color.Orange;
                }
            }            
        }
        
        private void dgvGenerico_DragDrop(object sender, DragEventArgs e)
        {
            var pivote = (DataGridView)sender;
            pivote.AllowUserToAddRows = false;
            for (var i = 0; i < pivote.Rows.Count; i++)
            {
                if (/*pivote.Rows.Count > 0 & */Convert.ToString(pivote.Rows[i].Cells[1].Value) == "")
                {
                    pivote.Rows.Remove(pivote.Rows[pivote.Rows.Count-1]);
                }
            }
            pivote.AllowUserToAddRows = true;
            if (e.Effect == DragDropEffects.Move)
            {
                var c = e.Data.GetData(typeof(DragDropInfo)) as DragDropInfo;  
                (this[(pivote.Tag as PropiedadesDgv)?.NombreDia] as BindingList<MenuDia>)?.Add(c?.Control);
               
                pivote.DataSource = null;
                //var col = new DataGridViewComboBoxColumn
                //{
                //    Name = "TipoReceta",
                //    DataPropertyName = "TipoReceta",
                //    HeaderText = @"TipoReceta",
                //    DataSource = _tiposrecetas,
                //    DisplayMember = "TipoReceta",
                //    ValueMember = "TipoReceta"
                //};
                //pivote.Columns.Add(col);
                /*por aqui */
                pivote.DataSource = (this[(pivote.Tag as PropiedadesDgv)?.NombreDia] as BindingList<MenuDia>);
                var dataGridViewColum = pivote.Columns["MenId"];
                if (dataGridViewColum != null) dataGridViewColum.Visible = false;
                pivote.Columns["UltimaElaboracion"].Visible = false;
                pivote.Columns["CantidadReceta"].Visible = false;
                var dataGridViewColumn = pivote.Columns["CantidadElab"];
                if (dataGridViewColumn != null)
                    dataGridViewColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                var gridViewColumn = pivote.Columns["Precio"];
                if (gridViewColumn != null)
                    gridViewColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                var viewColum = pivote.Columns["Venta"];
                if (viewColum != null)
                    viewColum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                var dataGridViewColumn2 = pivote.Columns["Congelado"];
                if (dataGridViewColumn2 != null)
                    dataGridViewColumn2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //var gridViewColumn2 = pivote.Columns["CantidadReceta"];
                //if (gridViewColumn2 != null)
                //    gridViewColumn2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; 
                    pivote.Columns["Unidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                pivote.Columns[0].Width = 70;
                pivote.Columns[1].Width = 230;
                pivote.Columns["Unidad"].Width = 40;
                pivote.Columns["Venta"].Width = 50;
                pivote.Columns["Congelado"].Width = 50;
                pivote.Columns["Precio"].Width = 50;
                pivote.Columns["CantidadElab"].Width = 65;
                foreach (DataGridViewRow row in pivote.Rows)
                {
                    pivote.Rows[row.Index].Cells["Congelado"].Style.BackColor = Color.Aqua;
                    //pivote.Rows[row.Index].Cells["CantidadReceta"].Style.BackColor = Color.Orange;
                    pivote.Rows[row.Index].Cells["Precio"].Style.BackColor = Color.Orange;
                    pivote.Rows[row.Index].Cells["Venta"].Style.BackColor = Color.Orange;
                    pivote.Rows[row.Index].Cells["Unidad"].Style.BackColor = Color.Orange;
                }
            }
        }
        #endregion  
        private static void GuardarDgv(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                GuardarMenuSemanal(c);
            }
        }
        private static void GuardarMenuSemanal(Control parent1)
        {
            var view = parent1 as DataGridView;
                if (view != null)
                {
                    var pivote = view;
                 
                    pivote.AllowUserToAddRows = false;
                    var fecha = DateTime.Parse((pivote.Tag as PropiedadesDgv)?.LabelFecha.Text, CultureInfo.CurrentCulture);
                    
                    var result = DateTime.Compare(fecha, DateTime.Now);
                    if (result >= 0) { 
                    for (var i = 0; i < pivote.Rows.Count; i++)
                    {
                        var dd = pivote.Rows[i].Cells[1].Value;
                        if ((string) dd != "")
                        {
                        var menid = Convert.ToInt32(pivote.Rows[i].Cells["MenId"].Value);
                        var cantidad = Convert.ToDouble(pivote.Rows[i].Cells["CantidadElab"].Value);
                        var congelado = Convert.ToDouble(pivote.Rows[i].Cells["Congelado"].Value);
                        var cantidadfinal = cantidad - congelado;
                        var dato = Convert.ToString(pivote.Rows[i].Cells["Platillo"].Value.ToString());
                        char[] separador = { '(', ')' };
                        var valor = dato.Split(separador);
                        var clave = valor[1];
                        Cocina.PlatillosMenus.Clave = clave;
                        var tipo = Convert.ToString(pivote.Rows[i].Cells["TipoReceta"].Value.ToString());
                        Cocina.PlatillosMenus.Nombre = tipo;
                        var i2 = i;
                            var fechadia = Convert.ToString((pivote.Tag as PropiedadesDgv)?.LabelFecha.Text);
                            var fechaguardar = Convert.ToDateTime(fechadia).ToString("yyyy-MM-dd");

                            Opcion.EjecucionAsync(Data.MenuSemanal.SacarParamentrosReceta, y =>
                        {
                            var recid = Opcion.JsonaClaseGenerica<PlatilloReceta>(y).RecId;
                            Opcion.EjecucionAsync(Data.MenuSemanal.SacarTipoId, z =>
                            {
                                var tipoid = Opcion.JsonaClaseGenerica<PlatilloReceta>(z).TipoId;
                                var i1 = i2;
                                if (menid==0)
                                {
                                    var menu = new InsertarMenu
                                    {
                                        RecId = recid,
                                        Fecha = fechaguardar,
                                        Cantidad = cantidadfinal,
                                        PrecioFinal = Convert.ToDouble(pivote.Rows[i1].Cells["Precio"].Value.ToString()),
                                        TipoId = tipoid
                                    };
                                        Opcion.EjecucionAsync(x => {

                                        Data.MenuSemanal.InsertarMenus(x, menu);
                                    }, resultado =>
                                    {
                                    });      
                                }
                                else
                                {
                                    var menu = new InsertarMenu
                                    {
                                        MenId=Convert.ToInt32(menid),
                                        RecId = recid,
                                        Fecha = fechaguardar,
                                        Cantidad = cantidadfinal,
                                        PrecioFinal = Convert.ToDouble(pivote.Rows[i1].Cells["Precio"].Value.ToString()),
                                        TipoId = tipoid
                                    };
                                    Data.MenuSemanal.ActualizarMenuActual(menu);
                                }       
                            });});
                            Data.MenuSemanal.UtilizarCongelado(5);
                            pivote.Enabled = false;
                        }
                      
                    }
                }
            }
            else
                {
                  GuardarDgv(parent1);
                }
        }
        private void btGuardar_Click(object sender, EventArgs e)
        {
            this.SuspendLayout();
            var me = new MensajeDeEspera();
            me.Show();
            GuardarDgv(this);
            me.Close();
            MessageBox.Show(@"El Menú Semanal se a guardado correctamente");
            btPreviaPlatilloGlobal.Enabled = true;
            btPreviaPlatillo.Enabled = true;
            ResumeLayout();
        }
        private void dgvGenerico_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var pivote = (DataGridView)sender;
            if (!pivote.Rows[e.RowIndex].Cells[1].Selected & !pivote.Rows[e.RowIndex].Cells[1].Selected) return;
            pivote.AllowUserToAddRows = true;
            //if (pivote.Rows[e.RowIndex].Cells[0].Value != null)
            //{
                //pivote.Rows[e.RowIndex].Cells[1].ReadOnly = false;
                pivote.Rows[e.RowIndex].Cells["Congelado"].Style.BackColor = Color.Aqua;
                //pivote.Rows[e.RowIndex].Cells["CantidadReceta"].Style.BackColor = Color.Orange;
                pivote.Rows[e.RowIndex].Cells["Precio"].Style.BackColor = Color.Orange;
                pivote.Rows[e.RowIndex].Cells["Venta"].Style.BackColor = Color.Orange;
                pivote.Rows[e.RowIndex].Cells["Unidad"].Style.BackColor = Color.Orange;
            //}
            //else
            //{ 
            //    pivote.Rows[e.RowIndex].Cells[1].ReadOnly = true;
            //    MessageBox.Show(@"Seleccione el tipo de receta antes de seleccionar el platillo");
            //}
            Menidd = Convert.ToInt32(pivote.Rows[e.RowIndex].Cells["MenId"].Value);
            DgvSeleccionado=pivote;
        }
        private void dgvGenerico_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var pivote = (DataGridView)sender;

            var rowIndex = pivote.CurrentCell.RowIndex;
            btGuardar.Enabled = true;
            if (Convert.ToDouble(pivote.Rows[rowIndex].Cells["CantidadElab"].Value.ToString()) > 0 && Convert.ToString(pivote.Rows[rowIndex].Cells[1].Value) != "" && btAgregarSemana.Enabled==false)
            {
                var dato = Convert.ToString(pivote.Rows[rowIndex].Cells["Platillo"].Value.ToString());
                char[] separador = { '(', ')' };
                var valor = Convert.ToString(dato).Split(separador);
                var clave = valor[1];
                Cocina.PlatillosMenus.Clave = clave;
                Data.MenuSemanal.SacarParamentrosReceta(z =>
                {
                    var precio = Opcion.JsonaClaseGenerica<PlatilloReceta>(z).Precio;
                    var cantidadreal2 = Convert.ToDouble(pivote.Rows[rowIndex].Cells["CantidadElab"].Value.ToString());
                    var gananciatotal = precio * cantidadreal2;
                    pivote.Rows[rowIndex].Cells["Venta"].Value = Math.Round(gananciatotal, 2);
                });
                montototal(pivote);
            }

            if (!pivote.Rows[e.RowIndex].Cells[1].Selected || pivote.Rows[e.RowIndex].Cells["Platillo"].Value == null)
             return;
            DetallePlatillos(pivote);
        }
        private void dgvGenerico_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            var pivote = (DataGridView)sender;
            var rowIndex = pivote.CurrentCell.RowIndex;
            var col = pivote.Columns[pivote.CurrentCell.ColumnIndex];
            var col2 = pivote.Rows[rowIndex].Cells[0].Selected;
            if (!(col2)) return;
            pivote.CommitEdit(DataGridViewDataErrorContexts.Commit);
            pivote.Rows[rowIndex].Cells["Platillo"].Value = "";
            pivote.Rows[rowIndex].Cells["Congelado"].Value = 0;
            pivote.Rows[rowIndex].Cells["MenId"].Value = 0;
            pivote.Rows[rowIndex].Cells["Precio"].Value = 0;
            pivote.Rows[rowIndex].Cells["Venta"].Value = 0;
            //pivote.Rows[rowIndex].Cells["CantidadReceta"].Value = 0;
            pivote.Rows[rowIndex].Cells["CantidadElab"].Value = 0;
            pivote.Rows[rowIndex].Cells["Unidad"].Value = "";
            pivote.AllowUserToAddRows = true;
        }
        private  void IngredientesGlobalDgv(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                IngredientesPlatillosGlobal(c);
            }
        }
        private void IngredientesPlatillosGlobal(Control parent1)
        {
            var view = parent1 as DataGridView;
            if (view != null)
                {
                    var pivote = view;
                    pivote.AllowUserToAddRows = false;
                    var fecha = DateTime.Parse((pivote.Tag as PropiedadesDgv)?.LabelFecha.Text, CultureInfo.CurrentCulture);
                    var result = DateTime.Compare(fecha, DateTime.Now);
                    if (result > 0)
                    { 
                    for (var i = 0; i < pivote.Rows.Count; i++)
                    {
                        var dd = pivote.Rows[i].Cells[1].Value;
                        if ((string) dd != "")
                        {
                        var dato = Convert.ToString(pivote.Rows[i].Cells["Platillo"].Value.ToString());
                        char[] separador = { '(', ')' };
                        var valor = dato.Split(separador);
                        var clave = valor[1];
                        Cocina.PlatillosMenus.Clave = clave;

                        var i1 = i;
                        Opcion.EjecucionAsync(Data.MenuSemanal.SacarParamentrosReceta, y =>
                        {
                            var recid = Opcion.JsonaClaseGenerica<PlatilloReceta>(y).RecId;
                            Cocina.PlatillosMenus.RecId = Convert.ToString(recid);
                            var cantidadreceta = Convert.ToDouble(pivote.Rows[i1].Cells["CantidadReceta"].Value);
                            var cantidadreal = Convert.ToDouble(pivote.Rows[i1].Cells["CantidadElab"].Value);
                            var congelado = Convert.ToDouble(pivote.Rows[i1].Cells["Congelado"].Value);
                            var cantidadfinal = cantidadreal - congelado;
                            Opcion.EjecucionAsync(Data.MenuSemanal.IngredientesMenuPlatillos,
                                jsonResult =>
                                {
                                    // ReSharper disable once CompareOfFloatsByEqualityOperator
                                    if (cantidadfinal == cantidadreceta)
                                    {
                                        var lista = Opcion.JsonaListaGenerica<IngredientesReceta>(jsonResult);

                                        _listaArticuloBasica1 = lista
                                            .GroupBy(p => p.ArtId)
                                            .Select(g => new IngredientesReceta
                                            {
                                                ArtId = g.Key,
                                                Clave = g.First().Clave,
                                                Descripcion = g.First().Descripcion,
                                                Cantidad = g.Sum(q=>q.Cantidad),
                                                Unidad = g.First().Unidad,
                                                Fecha = Convert.ToString((pivote.Tag as PropiedadesDgv)?.LabelFecha.Text),
                                            }).ToList();
                                    }
                                    else
                                    {
                                        var difcantidad = Math.Round(cantidadfinal/cantidadreceta, 2);
                                        var lista = Opcion.JsonaListaGenerica<IngredientesReceta>(jsonResult);

                                        _listaArticuloBasica1 = lista
                                            .GroupBy(p => p.ArtId)
                                            .Select(g => new IngredientesReceta
                                            {
                                                ArtId = g.Key,
                                                Clave = g.First().Clave,
                                                Descripcion = g.First().Descripcion,
                                                Cantidad = Math.Round(g.Sum(q => q.Cantidad) * difcantidad,2),
                                                Unidad = g.First().Unidad,
                                                Fecha = Convert.ToString((pivote.Tag as PropiedadesDgv)?.LabelFecha.Text),
                                            }).ToList();
                                           }
                                        });
                                   }); 
                        _listaArticuloBasica2.AddRange(_listaArticuloBasica1);
                        _listaArticuloBasica2 = _listaArticuloBasica2.GroupBy(p => p.ArtId)
                            .Select(g => new IngredientesReceta
                            {
                                ArtId = g.Key,
                                Clave = g.First().Clave,
                                Descripcion = g.First().Descripcion,
                                Cantidad = g.Sum(b => b.Cantidad),
                                Unidad = g.First().Unidad,
                                Fecha = Convert.ToString(g.First().Fecha)
                            }).ToList();
                    }
                    }
                }
            }
            else
                {
                    IngredientesGlobalDgv(parent1);
                }
        }
        private void IngredientesPlatilloDgv(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                IngredientesPlatillo(c);
            }
        }
        private void IngredientesPlatillo(Control parent1)
        {
            var view = parent1 as DataGridView;
            if (view != null)
                {
                    var pivote = view;
                    pivote.AllowUserToAddRows = false;
                    var fecha = DateTime.Parse((pivote.Tag as PropiedadesDgv)?.LabelFecha.Text, CultureInfo.CurrentCulture);
                    var result = DateTime.Compare(fecha, DateTime.Now);
                    if (result > 0)
                {
                    for (var i = 0; i < pivote.Rows.Count; i++)
                    {
                        var dd = pivote.Rows[i].Cells[1].Value;
                        if ((string) dd != "")
                        {
                            var dato = Convert.ToString(pivote.Rows[i].Cells["Platillo"].Value.ToString());
                            char[] separador = { '(', ')' };
                            var valor = dato.Split(separador);
                            var clave = valor[1];
                            Cocina.PlatillosMenus.Clave = clave;

                            var i1 = i;
                            Opcion.EjecucionAsync(Data.MenuSemanal.SacarParamentrosReceta, y =>
                            {
                                var recid = Opcion.JsonaClaseGenerica<PlatilloReceta>(y).RecId;
                                Cocina.PlatillosMenus.RecId = Convert.ToString(recid);
                                var cantidadreceta = Convert.ToDouble(pivote.Rows[i1].Cells["CantidadReceta"].Value);
                                var cantidadreal = Convert.ToDouble(pivote.Rows[i1].Cells["CantidadElab"].Value);
                                var congelado = Convert.ToDouble(pivote.Rows[i1].Cells["Congelado"].Value);
                                var cantidadfinal = cantidadreal - congelado;
                                Opcion.EjecucionAsync(Data.MenuSemanal.IngredientesMenuPlatillos,
                                    jsonResult =>
                                    {
                                    // ReSharper disable once CompareOfFloatsByEqualityOperator
                                    if (cantidadfinal == cantidadreceta)
                                        {
                                            var lista = Opcion.JsonaListaGenerica<IngredientesReceta>(jsonResult);

                                            _listaArticuloBasica1 = lista
                                                .GroupBy(p => p.ArtId)
                                                .Select(g => new IngredientesReceta
                                                {
                                                    ArtId = g.Key,
                                                    DescripcionReceta = dato,
                                                    Clave = g.First().Clave,
                                                    Descripcion = g.First().Descripcion,
                                                    Cantidad = g.Sum(q => q.Cantidad),
                                                    Unidad = g.First().Unidad,
                                                    Fecha = Convert.ToString((pivote.Tag as PropiedadesDgv)?.LabelFecha.Text),
                                                }).ToList();
                                        }
                                        else
                                        {
                                            var difcantidad = Math.Round(cantidadfinal / cantidadreceta, 2);
                                            var lista = Opcion.JsonaListaGenerica<IngredientesReceta>(jsonResult);

                                            _listaArticuloBasica1 = lista
                                                .GroupBy(p => p.ArtId)
                                                .Select(g => new IngredientesReceta
                                                {
                                                    ArtId = g.Key,
                                                    DescripcionReceta=dato,
                                                    Clave = g.First().Clave,
                                                    Descripcion = g.First().Descripcion,
                                                    Cantidad = Math.Round(g.Sum(q => q.Cantidad) * difcantidad, 2),
                                                    Unidad = g.First().Unidad,
                                                    Fecha = Convert.ToString((pivote.Tag as PropiedadesDgv)?.LabelFecha.Text),
                                                }).ToList();
                                        }
                                    });
                            });
                            _listaArticuloBasica2.AddRange(_listaArticuloBasica1);
                        }
                    }
                }
              }
                else
                {
                    IngredientesPlatilloDgv(parent1);
                }   
        }

        private void SacarMenuSemanal(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                ImprimirMenuSemanal(c);
            }
        }
        private void ImprimirMenuSemanal(Control parent1)
        {
            var view = parent1 as DataGridView;
            if (view != null)
            {
                var pivote = view;
                pivote.AllowUserToAddRows = false;
                if (pivote.RowCount>0)
                {
                    var dgvseleccionado = pivote.CurrentRow;

                    for (var i = 0; i < pivote.Rows.Count; i++)
                    {
                        var dd = pivote.Rows[i].Cells[1].Value;
                        if ((string)dd != "")
                        {
                            var dato = Convert.ToString(pivote.Rows[i].Cells["Platillo"].Value.ToString());
                            char[] separador = { '(', ')' };
                            var valor = dato.Split(separador);
                            var platillo = valor[0];
                            var cantidadelab = Convert.ToDouble(pivote.Rows[i].Cells["CantidadElab"].Value);
                            var tiporeceta = pivote.Rows[i].Cells["TipoReceta"].Value.ToString();
                            var unidad = Convert.ToString(pivote.Rows[i].Cells["Unidad"].Value);
                            var precio = Convert.ToDouble(pivote.Rows[i].Cells["Precio"].Value);
                            var venta = Convert.ToDouble(pivote.Rows[i].Cells["venta"].Value);
                            var fecha = (pivote.Tag as PropiedadesDgv)?.LabelFecha.Text;
                            var dia= (pivote.Tag as PropiedadesDgv)?.NombreDia;
                            if(pivote.Name=="dgvLunes")
                            {
                              _listaPlatilloLunes.Add(new PlatilloReceta { Platillo = platillo, CantidadElab = cantidadelab,
                                TipoReceta = tiporeceta, Unidad = unidad, Precio = precio, Venta = venta, Fecha = "Lunes:" + fecha, UltimaElaboracion=dia });
                            }
                             if(pivote.Name=="dgvMartes")
                            {
                              _listaPlatilloMartes.Add(new PlatilloReceta { Platillo = platillo, CantidadElab = cantidadelab,
                                TipoReceta = tiporeceta, Unidad = unidad, Precio = precio, Venta = venta, Fecha = "Martes:" + fecha, UltimaElaboracion=dia });
                            }
                               if(pivote.Name=="dgvMiercoles")
                            {
                              _listaPlatilloMiercoles.Add(new PlatilloReceta { Platillo = platillo, CantidadElab = cantidadelab,
                                TipoReceta = tiporeceta, Unidad = unidad, Precio = precio, Venta = venta, Fecha = "Miercoles:" + fecha, UltimaElaboracion=dia });
                            }
                             if(pivote.Name=="dgvJueves")
                            {
                              _listaPlatilloJueves.Add(new PlatilloReceta { Platillo = platillo, CantidadElab = cantidadelab,
                                TipoReceta = tiporeceta, Unidad = unidad, Precio = precio, Venta = venta, Fecha = "Jueves:" + fecha, UltimaElaboracion=dia });
                            }
                               if(pivote.Name=="dgvViernes")
                            {
                              _listaPlatilloViernes.Add(new PlatilloReceta { Platillo = platillo, CantidadElab = cantidadelab,
                                TipoReceta = tiporeceta, Unidad = unidad, Precio = precio, Venta = venta, Fecha = "Viernes:" + fecha, UltimaElaboracion=dia });
                            }
                             if(pivote.Name=="dgvSabado")
                            {
                              _listaPlatilloSabado.Add(new PlatilloReceta { Platillo = platillo, CantidadElab = cantidadelab,
                                TipoReceta = tiporeceta, Unidad = unidad, Precio = precio, Venta = venta, Fecha = "Sabado:" + fecha, UltimaElaboracion=dia });
                            }
                               if(pivote.Name=="dgvDomingo")
                            {
                              _listaPlatilloDomingo.Add(new PlatilloReceta { Platillo = platillo, CantidadElab = cantidadelab,
                                TipoReceta = tiporeceta, Unidad = unidad, Precio = precio, Venta = venta, Fecha = "Domingo:" + fecha, UltimaElaboracion=dia });
                            }
                        }                        
                    }   
                }
                _listaPlatilloArreglo.Add(new PlatilloReceta
                {
                    Lunes = _listaPlatilloLunes,
                    Martes = _listaPlatilloMartes,
                    Miercoles = _listaPlatilloMiercoles,
                    Jueves = _listaPlatilloJueves,
                    Viernes = _listaPlatilloViernes,
                    Sabado = _listaPlatilloSabado,
                    Domingo = _listaPlatilloDomingo
                });
            }
            else
            {
                SacarMenuSemanal(parent1);
            }
     
        }
        private void btEditarSemana_Click(object sender, EventArgs e)
        {
            var diainicio = FirstDayOfWeek(DateTime.Today).ToShortDateString();
            var diafinal = LastDayOfWeek(DateTime.Today).ToShortDateString();
            var lunes = Convert.ToDateTime(diainicio).ToShortDateString();
            FechaLunes.Text = Convert.ToDateTime(diainicio).ToShortDateString();
            var martes = Convert.ToDateTime(diainicio).AddDays(1).ToShortDateString();
            FechaMartes.Text = Convert.ToDateTime(diainicio).AddDays(1).ToShortDateString();
            var miercoles = Convert.ToDateTime(diainicio).AddDays(2).ToShortDateString();
            FechaMiercoles.Text = Convert.ToDateTime(diainicio).AddDays(2).ToShortDateString();
            var jueves = Convert.ToDateTime(diainicio).AddDays(3).ToShortDateString();
            FechaJueves.Text = Convert.ToDateTime(diainicio).AddDays(3).ToShortDateString();
            var viernes = Convert.ToDateTime(diainicio).AddDays(4).ToShortDateString();
            FechaViernes.Text = Convert.ToDateTime(diainicio).AddDays(4).ToShortDateString();
            var sabado = Convert.ToDateTime(diainicio).AddDays(5).ToShortDateString();
            FechaSabado.Text = Convert.ToDateTime(diainicio).AddDays(5).ToShortDateString();
            var domingo = Convert.ToDateTime(diafinal).ToShortDateString();
            FechaDomingo.Text = Convert.ToDateTime(diafinal).ToShortDateString();
            LabelLunes.Text = @"Lunes: " + lunes;
            LabelMartes.Text = @"Martes: " + martes;
            LabelMiercoles.Text = @"Miercoles: " + miercoles;
            LabelJueves.Text = @"Jueves: " + jueves;
            LabelViernes.Text = @"Viernes:" + viernes;
            LabelSabado.Text = @"Sabado:" + sabado;
            LabelDomingo.Text = @"Domingo:" + domingo;
            Opcion.EjecucionAsync(x =>
            {
                var times = new Reporte.General
                {
                    FechaFin = Convert.ToDateTime(diafinal),
                    FechaIni = Convert.ToDateTime(diainicio)
                };
                Data.MenuSemanal.CargarMenuSemanaActual(x, times);
            }, jsonResult =>
            {
                if (jsonResult != null)
                {
                    BeginInvoke((MethodInvoker)(() =>
                    {
                    switch (jsonResult.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            Lunes = new BindingList<MenuDia>(Opcion.JsonaClaseGenerica2<Respuesta.MenuSemanal>(jsonResult).Lunes);
                            Martes = new BindingList<MenuDia>(Opcion.JsonaClaseGenerica2<Respuesta.MenuSemanal>(jsonResult).Martes);
                            Miercoles = new BindingList<MenuDia>(Opcion.JsonaClaseGenerica2<Respuesta.MenuSemanal>(jsonResult).Miercoles);
                            Jueves = new BindingList<MenuDia>(Opcion.JsonaClaseGenerica2<Respuesta.MenuSemanal>(jsonResult).Jueves);
                            Viernes = new BindingList<MenuDia>(Opcion.JsonaClaseGenerica2<Respuesta.MenuSemanal>(jsonResult).Viernes);
                            Sabado = new BindingList<MenuDia>(Opcion.JsonaClaseGenerica2<Respuesta.MenuSemanal>(jsonResult).Sabado);
                            Domingo = new BindingList<MenuDia>(Opcion.JsonaClaseGenerica2<Respuesta.MenuSemanal>(jsonResult).Domingo);
                            InicializarDgv(this);
                            btGuardar.Enabled = true;
                            btPreviaPlatillo.Enabled = false;
                            btPreviaPlatilloGlobal.Enabled = false;
                            btPlatillo.Enabled = true;
                            //cbTipoReceta.Enabled = true;
                            //tbPlatillo.Enabled = true;
                            label2.Enabled = true;
                            ckPlatillo.Enabled = true;
                            ckTipoReceta.Enabled = true;
                            btOrdenTrabajo.Enabled = true;
                            vScrollBar2.Enabled = true;
                            btBorrarFila.Enabled=true;
                            btImprimirMenu.Enabled = true;

                                break;
                            default:
                                MessageBox.Show(this, @"No se encontraron menus con los parametros de busqueda ingresados");
                                break;
                        }
                    }));
                }
                else
                {
                    BorrarDgv(this);
                    MessageBox.Show(@"No se encontraron menus con los parametros de busqueda ingresados");
                }
            });
        }
        private void dgvGenerico_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            var pivote = (DataGridView) sender;
            if (e.Exception != null &&
                e.Context == DataGridViewDataErrorContexts.Commit)
            {
                pivote.Rows[e.RowIndex].Cells["CantidadElab"].Value = @"0";
            }
        }
        private void btBorrarFila_Click(object sender, EventArgs e)
        {
            if (dgvLunes.RowCount > 0)
            {
                Opcion.BorrarFila(DgvSeleccionado);
                Data.MenuSemanal.EliminarelPlatillo(Menidd);
                InicializarDgv(this);
            }
        }
        private void btPreviaPlatilloGlobal_Click(object sender, EventArgs e)
        {
            _listaArticuloBasica2 = new List<IngredientesReceta>();
            IngredientesGlobalDgv(this);
            var addIn = Globals.ThisAddIn;
            addIn.IngredientesMenuGlobal(_listaArticuloBasica2);
        }
        private void btPreviaPlatillo_Click(object sender, EventArgs e)
        {
            _listaArticuloBasica2 = new List<IngredientesReceta>();
            IngredientesPlatilloDgv(this);
            var addIn = Globals.ThisAddIn;
            addIn.IngredientesMenuxPlatillo(_listaArticuloBasica2);
        }
        private void btPlatillo_Click(object sender, EventArgs e)
        {
            var mde = new MensajeDeEspera();
            if (ckPlatillo.Checked)
            {
                mde.Show();
                Cocina.PlatillosMenus.Clave = tbPlatillo.Text == string.Empty ? "%" : tbPlatillo.Text;
                Opcion.EjecucionAsync(Data.MenuSemanal.BuscarRecetaMenu, jsonResult =>
                {
                    if (jsonResult != null)
                    {
                        BeginInvoke((MethodInvoker)(() =>
                        {
                            switch (jsonResult.StatusCode)
                            {
                                case HttpStatusCode.OK:
                                    mde.Close();
                                    var listarecetas = new BuscarPlatillo(Opcion.JsonaListaGenerica<MenuDia>(jsonResult), DtpFecha.Value, resultado =>
                                    {
                                        var dia = resultado;
                                        var diaseleccionado = dia.Select(x => x.UltimaElaboracion).ToArray();
                                        var dgv = GetControlByName<DataGridView>(this, "dgv" + diaseleccionado[0], true).FirstOrDefault();
                                        BeginInvoke((MethodInvoker)(() =>
                                        {
                                            var newdgv = dgv.DataSource as BindingList<MenuDia>;
                                            BindingList<MenuDia> la = (resultado);

                                                flagDataSource = true;
                                                if (this[diaseleccionado[0]] != null)
                                                {
                                                    if (newdgv != null)
                                                        foreach ( MenuDia md in (newdgv))
                                                        {
                                                            la.Add(md);
                                                        }
                                                }
                                            var ordenarporTipo= new BindingList<MenuDia>(la.OrderBy(x => x.TipoReceta).ToList());
                                            dgv.DataSource = ordenarporTipo;
                                            IncializarDgvDetalle(dgv);
                                            DetallePlatillos(dgv);
                                        }));
                                    }         
                                    , false);
                                  listarecetas.Show();
                                    flagDataSource = false;
                                    break;
                                default:
                                    MessageBox.Show(this, @"No se encontraron recetas con los parametros de busqueda ingresados");
                                    Console.WriteLine(jsonResult.Content);
                                    break;
                            }
                        }));
                    }
                    
                });
            }
             if (ckTipoReceta.Checked)
            {
                mde.Show();
                Cocina.PlatillosMenus.Nombre = cbTipoReceta.Text == string.Empty ? "%" : cbTipoReceta.Text;
                Opcion.EjecucionAsync(Data.MenuSemanal.ListaPlatilloRecetas, jsonResult =>
                {
                    if (jsonResult != null)
                    {
                        BeginInvoke((MethodInvoker)(() =>
                        {
                            switch (jsonResult.StatusCode)
                            {
                                case HttpStatusCode.OK:
                                    mde.Close();
                                    var listarecetas = new BuscarPlatillo(Opcion.JsonaListaGenerica<MenuDia>(jsonResult), DtpFecha.Value, resultado =>
                                    {
                                        var dia = resultado;
                                        var diaseleccionado = dia.Select(x => x.UltimaElaboracion).ToArray();
                                        var dgv = GetControlByName<DataGridView>(this, "dgv" + diaseleccionado[0], true).FirstOrDefault();
                                        BeginInvoke((MethodInvoker)(() =>
                                        {

                                            var newdgv = dgv.DataSource as BindingList<MenuDia>;
                                            BindingList<MenuDia> la = (resultado);

                                            flagDataSource = true;
                                            if (this[diaseleccionado[0]] != null)
                                            {
                                                if (newdgv != null)
                                                    foreach (MenuDia md in (newdgv))
                                                    {
                                                        la.Add(md);
                                                    }
                                            }
                                            var ordenarporTipo = new BindingList<MenuDia>(la.OrderBy(x => x.TipoReceta).ToList());
                                            dgv.DataSource = ordenarporTipo;
                                            IncializarDgvDetalle(dgv);
                                            DetallePlatillos(dgv);

                                        }));
                                    },
                                    false);
                                    listarecetas.Show();
                                    break;
                                default:
                                    MessageBox.Show(this, @"No se encontraron recetas con los parametros de busqueda ingresados");
                                    Console.WriteLine(jsonResult.Content);
                                    break;
                            }
                        }));
                    }
                });
            }
           
         }
        private void ckPlatillo_CheckedChanged(object sender, EventArgs e)
        {
            if (ckPlatillo.Checked)
            {
                tbPlatillo.Enabled= true;
                btPlatillo.Enabled = true;
                cbTipoReceta.Enabled = false;
                ckTipoReceta.Checked = false;
            }
            else
            {
                tbPlatillo.Enabled= false;
                //btPlatillo.Enabled = false;
            }
        }
        private void ckTipoReceta_CheckedChanged(object sender, EventArgs e)
        {
            if (ckTipoReceta.Checked)
            {
                cbTipoReceta.Enabled = true;
                btPlatillo.Enabled = true;
                tbPlatillo.Enabled = false;
                ckPlatillo.Checked = false;
            }
            else
            {
                cbTipoReceta.Enabled= false;
                //btPlatillo.Enabled = false;
            }
        }
        private void btOrdenTrabajo_Click(object sender, EventArgs e)
        {
            if (DgvSeleccionado.CurrentRow != null && (DgvSeleccionado.CurrentRow.Cells[1].Selected && DgvSeleccionado.RowCount > 0))
            {
                var me = new MensajeDeEspera();
                me.Show();
                var dato = Convert.ToString(DgvSeleccionado.CurrentRow.Cells["Platillo"].Value.ToString());
                    char[] separador = { '(', ')' };
                    var valor = dato.Split(separador);
                    var clave = valor[1];
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
                        if (jsonResult != null)
                        {
                            BeginInvoke((MethodInvoker)(() =>
                            {
                            switch (jsonResult.StatusCode)
                            {
                                case HttpStatusCode.OK:
                            me.Close();
                            var listaCocina = Opcion.JsonaListaGenerica<Reporte.RespuestaCocina>(jsonResult)[0];
                            var FechaActual = Convert.ToString((DgvSeleccionado.Tag as PropiedadesDgv)?.LabelFecha.Text);
                            var CantidadReal = Convert.ToString(DgvSeleccionado.CurrentRow.Cells["CantidadElab"].Value);
                            listaCocina.Consumodia = CantidadReal;
                            listaCocina.UltimaElaboracion = FechaActual;
                            listaCocina.Cantidadinventario = Convert.ToDouble(CantidadReal);
                            var addIn = Globals.ThisAddIn;
                            addIn.OrdendeTrabajo(listaCocina);
                                        break;
                                    default:
                                        MessageBox.Show(this, @"No se encontraron menus con los parametros de busqueda ingresados");
                                        break;
                                }
                            }));
                        }
                        else
                        {
                            MessageBox.Show(this, @"No se encontro informacion con los parametros de busqueda ingresados");
                        }
                    }
                );
              
            }
        }
        private void vScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.OldValue > e.NewValue && dgvLunes!=null)
            {
                //arriba
                dgvLunes.FirstDisplayedScrollingRowIndex = dgvLunes.Rows[0].Index;
                dgvMartes.FirstDisplayedScrollingRowIndex = dgvMartes.Rows[0].Index;
                dgvMiercoles.FirstDisplayedScrollingRowIndex = dgvMiercoles.Rows[0].Index;
                dgvJueves.FirstDisplayedScrollingRowIndex = dgvJueves.Rows[0].Index;
                dgvViernes.FirstDisplayedScrollingRowIndex = dgvViernes.Rows[0].Index;
                dgvSabado.FirstDisplayedScrollingRowIndex = dgvSabado.Rows[0].Index;
                dgvDomingo.FirstDisplayedScrollingRowIndex = dgvDomingo.Rows[0].Index;
            }
            else
            {
                //abajo
                if (dgvLunes != null)
                    dgvLunes.FirstDisplayedScrollingRowIndex = dgvLunes.FirstDisplayedScrollingRowIndex + 1;
                dgvMartes.FirstDisplayedScrollingRowIndex = dgvMartes.FirstDisplayedScrollingRowIndex + 1;
                dgvMiercoles.FirstDisplayedScrollingRowIndex = dgvMiercoles.FirstDisplayedScrollingRowIndex + 1;
                dgvJueves.FirstDisplayedScrollingRowIndex = dgvJueves.FirstDisplayedScrollingRowIndex + 1;
                dgvViernes.FirstDisplayedScrollingRowIndex = dgvViernes.FirstDisplayedScrollingRowIndex + 1;
                dgvSabado.FirstDisplayedScrollingRowIndex = dgvSabado.FirstDisplayedScrollingRowIndex + 1;
                dgvDomingo.FirstDisplayedScrollingRowIndex = dgvDomingo.FirstDisplayedScrollingRowIndex + 1;
            }
                   
        }
        private void btImprimirMenu_Click(object sender, EventArgs e)
        {
            _listaPlatilloArreglo = new List<PlatilloReceta>();
            SacarMenuSemanal(this);
            var addIn = Globals.ThisAddIn;
            addIn.MenuSemanal(_listaPlatilloArreglo);

        }
    }
}