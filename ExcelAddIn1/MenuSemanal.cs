using System;
using System.Windows.Forms;
using Respuesta;
using Herramienta;
using System.Collections.Generic;
using System.ComponentModel;
using PresentationControls;
using System.Globalization;
using System.Net;
using Herramienta.Config;
using Font = System.Drawing.Font;
using Label = System.Windows.Forms.Label;
using Rectangle = System.Drawing.Rectangle;
using System.Drawing;
using System.Linq;
using Point = System.Drawing.Point;
using TextBox = System.Windows.Forms.TextBox;

namespace ExcelAddIn1
{
    public partial class MenuSemanal : Form
    {
        #region Variables
        //Drop and Drag datagridview rows
        private Rectangle _dragBoxFromMouseDown;
        private int _rowIndexFromMouseDown;
        //private List<IngredientesReceta> _listaIngredientesRecetas;

        //private int _rowIndexOfItemUnderMouseToDrop;

        public object this[string propertyName]
        {
            get { return typeof(MenuSemanal).GetProperty(propertyName).GetValue(this, null); }
            set { typeof(MenuSemanal).GetProperty(propertyName).SetValue(this, value, null); }
        }
        public BindingList<MenuDia> Lunes { get; set; }
        public BindingList<MenuDia> Martes { get; set; }
        public BindingList<MenuDia> Miercoles { get; set; }
        public BindingList<MenuDia> Jueves { get; set; }
        public BindingList<MenuDia> Viernes { get; set; }
        public BindingList<MenuDia> Sabado { get; set; }
        public BindingList<MenuDia> Domingo { get; set; }
        public class Inputs
        {
            public CheckBoxComboBox DiasSemana;
            public DataGridView DtvMenus;
        }

        public DataGridView DgvSeleccionado;
        public DataGridView Dgvbind;
        public class DragDropInfo
        {
            public MenuDia Control { get; set; }
            public DragDropInfo(MenuDia control)
            {
                Control = control;
            }
        }
        private List<IngredientesReceta> _listaArticuloBasica1;
        private  List<IngredientesReceta> _listaArticuloBasica2;
  

        private BindingList<MenuDia> _listaRecetaDiarias1;
        private List<MenuDia> _listaRecetaDiarias2;

        private readonly List<TipoRecetas> _tiposrecetas;
        private readonly List<TipoUnidades> _tiposunidades;
        #endregion
        public MenuSemanal()
        {
            _listaArticuloBasica1 = new List<IngredientesReceta>();
            _listaArticuloBasica2 = new List<IngredientesReceta>();
            _listaRecetaDiarias1 = new BindingList<MenuDia>();
            _listaRecetaDiarias2 = new List<MenuDia>();
            InitializeComponent();
            _tiposrecetas = new List<TipoRecetas>();
            _tiposunidades = new List<TipoUnidades>();
        }

        private void PopulateManualCombo()
        {
            cbDias.Items.Add("Todos");
            cbDias.Items.Add("Lunes");
            cbDias.Items.Add("Martes");
            cbDias.Items.Add("Miercoles");
            cbDias.Items.Add("Jueves");
            cbDias.Items.Add("Viernes");
            cbDias.Items.Add("Sabado");
            cbDias.Items.Add("Domingo");
        }
        public class PropiedadesDgv
        {
            public int IdDia { get; set; }
            public string NombreDia { get; set; }
            public Label LabelFecha { get; set; }
        }
        public class TipoRecetas
        {
            public  int IdReceta { get; set; }
            public  string TipoReceta { get; set; }
        }
        public class TipoUnidades
        {
            public int IdUnidad { get; set; }
            public string Unidad { get; set; }
        }
        private void MenuSemanal_Load(object sender, EventArgs e)
        {
            PopulateManualCombo();
            dgvLunes.Tag = new PropiedadesDgv { IdDia = 1, NombreDia = "Lunes", LabelFecha = FechaLunes };
            dgvMartes.Tag = new PropiedadesDgv { IdDia = 2, NombreDia = "Martes", LabelFecha = FechaMartes };
            dgvMiercoles.Tag = new PropiedadesDgv { IdDia = 3, NombreDia = "Miercoles", LabelFecha = FechaMiercoles };
            dgvJueves.Tag = new PropiedadesDgv { IdDia = 4, NombreDia = "Jueves", LabelFecha = FechaJueves };
            dgvViernes.Tag = new PropiedadesDgv { IdDia = 5, NombreDia = "Viernes", LabelFecha = FechaViernes };
            dgvSabado.Tag = new PropiedadesDgv { IdDia = 6, NombreDia = "Sabado", LabelFecha = FechaSabado };
            dgvDomingo.Tag = new PropiedadesDgv { IdDia = 7, NombreDia = "Domingo", LabelFecha = FechaDomingo };

            _tiposrecetas.Add(new TipoRecetas { IdReceta = 1, TipoReceta = "Guarnicion" });
            _tiposrecetas.Add(new TipoRecetas { IdReceta = 2, TipoReceta = "Fritangas" });
            _tiposrecetas.Add(new TipoRecetas { IdReceta = 3, TipoReceta = "Plato Fuerte" });
            _tiposrecetas.Add(new TipoRecetas { IdReceta = 4, TipoReceta = "Postre" });
            _tiposrecetas.Add(new TipoRecetas { IdReceta = 5, TipoReceta = "Diario" });
            _tiposrecetas.Add(new TipoRecetas { IdReceta = 6, TipoReceta = "Carniceria" });
            _tiposrecetas.Add(new TipoRecetas { IdReceta = 7, TipoReceta = "Salsas" });

            _tiposunidades.Add(new TipoUnidades {IdUnidad = 1, Unidad = "PZA" });
            _tiposunidades.Add(new TipoUnidades { IdUnidad = 2, Unidad = "CAJA" });
            _tiposunidades.Add(new TipoUnidades { IdUnidad = 3, Unidad = "m" });
            _tiposunidades.Add(new TipoUnidades { IdUnidad = 4, Unidad = "KG" });
            _tiposunidades.Add(new TipoUnidades { IdUnidad = 5, Unidad = "LT" });
            _tiposunidades.Add(new TipoUnidades { IdUnidad = 6, Unidad = "NA" });
            _tiposunidades.Add(new TipoUnidades { IdUnidad = 7, Unidad = "20" });
            _tiposunidades.Add(new TipoUnidades { IdUnidad = 8, Unidad = "GR" });
            _tiposunidades.Add(new TipoUnidades { IdUnidad = 9, Unidad = "Pqt" });
            btPreviaPlatilloGlobal.Enabled = false;
            btPreviaPlatillo.Enabled = false;
            btAgregarSemana.Enabled = false;
            btGuardar.Enabled = false;
            btDiarios.Enabled = false;
        }
        public static DateTime FirstDayOfWeek(DateTime date)
        {
            var fdow = CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
            var offset = fdow - date.DayOfWeek;
            var fdowDate = date.AddDays(offset);
            return fdowDate;
        }
        public static DateTime LastDayOfWeek(DateTime date)
        {
            var ldowDate = FirstDayOfWeek(date).AddDays(6);
            return ldowDate;
        }
        // ReSharper disable once FunctionComplexityOverflow
        private void InicializarDgv(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                var view = c as DataGridView;
                if (view != null)
                {
                    var pivote = view;
                    pivote.DataSource = null;
                    pivote.Rows.Clear();
                    pivote.Columns.Clear();
                    btGuardar.Enabled = false;
                    var col = new DataGridViewComboBoxColumn
                    {
                        Name = "TipoRecetaDgv",
                        DataPropertyName = "TipoRecetaDgv",
                        HeaderText = @"TipoReceta",
                        DataSource = _tiposrecetas,
                        DisplayMember = "TipoReceta",
                        ValueMember = "TipoReceta"
                    };
                    var col2 = new DataGridViewComboBoxColumn
                    {
                        Name = "UnidadDgv",
                        DataPropertyName = "UnidadDgv",
                        HeaderText = @"Unidad",
                        DataSource = _tiposunidades,
                        DisplayMember = "Unidad",
                        ValueMember = "Unidad"
                    };
                    pivote.Columns.Add(col);
                    pivote.Columns.Add(col2);
                    var propiedadesDgv = pivote.Tag as PropiedadesDgv;
                    if (propiedadesDgv != null)
                        pivote.DataSource = this[propiedadesDgv.NombreDia] as BindingList<MenuDia>;
                    pivote.Columns["CantidadReceta"].ReadOnly = true;
                    pivote.Columns["GananciaTotal"].ReadOnly = true;
                    pivote.Columns["PrecioCompra"].ReadOnly = true;
                    pivote.Columns["Congelado"].ReadOnly = true;
                    var dataGridViewColumn1 = pivote.Columns["UnidadDgv"];
                    if (dataGridViewColumn1 != null) dataGridViewColumn1.DisplayIndex = 4;
                    pivote.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 6);
                    //pivote.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    pivote.Enabled = false;
                    pivote.Columns[1].Width = 150;
                    var column = pivote.Columns["Unidad"];
                    if (column != null) column.Width = 10;
                    pivote.AllowUserToAddRows = true;
                    pivote.RowHeadersVisible = false;
                    var dataGridViewColumn = pivote.Columns["CantidadElaborar"];
                    if (dataGridViewColumn != null)
                        dataGridViewColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    var gridViewColumn = pivote.Columns["PrecioCompra"];
                    if (gridViewColumn != null)
                        gridViewColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    var viewColumn = pivote.Columns["GananciaTotal"];
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
                  
                    var fecha = DateTime.Parse((pivote.Tag as PropiedadesDgv)?.LabelFecha.Text, CultureInfo.CurrentCulture);
                    var result = DateTime.Compare(fecha, DateTime.Today);
                    if (result >= 0)
                    {
                        for (var x = 0; x < pivote.Rows.Count; x++)
                        {
                            pivote.Rows[x].Cells["Congelado"].Style.BackColor = Color.Aqua;
                            pivote.Rows[x].Cells["CantidadReceta"].Style.BackColor = Color.Orange;
                            pivote.Rows[x].Cells["PrecioCompra"].Style.BackColor = Color.Orange;
                            pivote.Rows[x].Cells["GananciaTotal"].Style.BackColor = Color.Orange;
                            if (column != null) column.Width = 10;
                            pivote.Columns[1].Width = 150;
                        }
                        pivote.Enabled = true;
                        pivote.DefaultCellStyle.BackColor = Color.Gainsboro;

                        btGuardar.Enabled = true;
                    }
                    else
                    {
                        for (var x = 0; x == 10; x++)
                        {
                            pivote.Columns[x].ReadOnly = true;
                        }
                        if (column != null) column.Width = 10;
                        pivote.Columns[1].Width = 150;
                        pivote.Columns["Congelado"].Visible = false;
                        pivote.Columns["CantidadReceta"].Visible = false;
                        pivote.Enabled = false;
                        pivote.DefaultCellStyle.BackColor = Color.Yellow;
                        
                    }
                    foreach (DataGridViewRow row in pivote.Rows)
                    {
                        pivote.Rows[row.Index].Cells["Congelado"].Style.BackColor = Color.Aqua;
                    }
                }
                else
                {
                    InicializarDgv(c);
                }
            }
        }
        private void BorrarDgv(Control parent)
        {
            foreach (Control c in parent.Controls)
{
                var view = c as DataGridView;
                if (view != null)
                {
                    
                   CheckForIllegalCrossThreadCalls = false;
                    var pivote = view;

                    pivote.DataSource = null;
                    pivote.Rows.Clear();
                    pivote.Columns.Clear();
                    btGuardar.Enabled = false;
                }
                else
                {
                    BorrarDgv(c);
                }
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
                    btGuardar.Enabled = false;
                    var propiedadesDgv = pivote.Tag as PropiedadesDgv;
                    if (propiedadesDgv != null)
                    pivote.DataSource = this[propiedadesDgv.NombreDia] as BindingList<MenuDia>;
                    var fecha = DateTime.Parse((pivote.Tag as PropiedadesDgv)?.LabelFecha.Text, CultureInfo.CurrentCulture);
                    var result = DateTime.Compare(fecha, DateTime.Today);
                    if (result >= 0)
                    {
                        for (var x = 0; x < pivote.Rows.Count; x++)
                        {
                            pivote.Columns["CantidadReceta"].Visible = true;
                            var dataGridViewColumn = pivote.Columns["Congelado"];
                            if (dataGridViewColumn != null) dataGridViewColumn.Visible = true;
                            var column = pivote.Columns["Unidad"];
                            if (column != null) column.Width = 10;
                            pivote.Columns[1].Width = 150;
                        }
                        pivote.Enabled = true;
                        pivote.Rows.Clear();
                        pivote.DefaultCellStyle.BackColor = Color.Gainsboro;

                        btGuardar.Enabled = true;
                    }
                    foreach (DataGridViewRow row in pivote.Rows)
                    {
                        pivote.Rows[row.Index].Cells["Congelado"].Style.BackColor = Color.Aqua;
                        pivote.Rows[row.Index].Cells["CantidadReceta"].Style.BackColor = Color.Orange;
                        pivote.Rows[row.Index].Cells["PrecioCompra"].Style.BackColor = Color.Orange;
                        pivote.Rows[row.Index].Cells["GananciaTotal"].Style.BackColor = Color.Orange;
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
            FechaLunes.Text = Convert.ToDateTime(diainicio).ToShortDateString();
            FechaMartes.Text = Convert.ToDateTime(diainicio).AddDays(1).ToShortDateString();
            FechaMiercoles.Text = Convert.ToDateTime(diainicio).AddDays(2).ToShortDateString();
            FechaJueves.Text= Convert.ToDateTime(diainicio).AddDays(3).ToShortDateString();
            FechaViernes.Text = Convert.ToDateTime(diainicio).AddDays(4).ToShortDateString();
            FechaSabado.Text = Convert.ToDateTime(diainicio).AddDays(5).ToShortDateString();
            FechaDomingo.Text = Convert.ToDateTime(diafinal).ToShortDateString();
            var diainicioactual = FirstDayOfWeek(DateTime.Today);
            var diadtp = (DtpFecha.Value);
            var dtpvalue = DtpFecha.Value.ToShortDateString();

            if (diadtp < diainicioactual)
            {
                Opcion.EjecucionAsync(x =>
            {
                   var times = new Reporte.General
                {
                    FechaIni = Convert.ToDateTime(diainicio),
                    FechaFin = Convert.ToDateTime(diafinal)
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
                            Lunes = new BindingList<MenuDia>(Opcion.JsonaClaseGenerica2<Respuesta.MenuSemanal>(jsonResult).Lunes);
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
                             MessageBox.Show(@"No se pueden agregar menus pasados, ya existe un menu semanal", "", MessageBoxButtons.OK, MessageBoxIcon.Error);  
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

                                    btDiarios.Enabled = true;
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
                        if (_agregarSemanaActual)
                        {
                            CheckForIllegalCrossThreadCalls = false;
                            btAgregarSemana.PerformClick();
                        }
                        else
                        {
                                DgvVacios(this);
                                MessageBox.Show(@"No se encontraron menus con los parametros de busqueda ingresados");
                                //InicializarDgv(this);
                            
                        }

                    }
                });

            }
        }
        private void cbDias_SelectedIndexChanged(object sender, EventArgs e)
        {   
            if (cbDias.Items.Count > 0)
            { 
                for (var x = 1; x <= 7; x++)
                {
                    cbDias.CheckBoxItems[x].Checked = cbDias.CheckBoxItems[0].Checked;
                }
            }
            btAgregarSemana.Enabled = true;
        }

        private bool _agregarSemanaActual = false;
        private void btAgregarSemana_Click(object sender, EventArgs e)
        {
            _agregarSemanaActual = true;
            DtpFecha.Value = FirstDayOfWeek(DateTime.Today);
            MoverDatosSemanaActual(this);
            if (!cbDias.CheckBoxItems[0].Checked) return;
            dgvLunes.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvMartes.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvMiercoles.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvJueves.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvViernes.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvSabado.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvDomingo.EditMode = DataGridViewEditMode.EditOnEnter;
           
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
                    var gridViewColumn = pivote.Columns["Congelado"];
                    if (gridViewColumn != null) gridViewColumn.Visible = true;
                    pivote.Columns["CantidadReceta"].Visible = true;
                    var fecha = DateTime.Parse((pivote.Tag as PropiedadesDgv)?.LabelFecha.Text, CultureInfo.CurrentCulture);
                    var result = DateTime.Compare(fecha, DateTime.Now);
                    if (cbDias.CheckBoxItems[Convert.ToInt32((view.Tag as PropiedadesDgv)?.IdDia)].Checked && result >= 0)
                    {
                        pivote.Enabled = true;
                        //pivote.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        pivote.EditMode = DataGridViewEditMode.EditOnEnter;
                        pivote.AllowUserToAddRows = true;
                        var gridViewColumn1 = pivote.Columns["MenId"];
                        if (gridViewColumn1 != null) gridViewColumn1.Visible = false;
                        var viewColumn1 = pivote.Columns["CantidadReceta"];
                        if (viewColumn1 != null) viewColumn1.Visible = true;
                        var column1 = pivote.Columns["Congelado"];
                        if (column1 != null) column1.Visible = true;
                        var dataGridViewColumn = pivote.Columns["UnidadDgv"];
                        if (dataGridViewColumn != null) dataGridViewColumn.DisplayIndex = 4;
                        pivote.DefaultCellStyle.BackColor = Color.Gainsboro;
                        for (var i = 0; i < pivote.Rows.Count; i++)
                        {
                            if (pivote.Rows.Count > 0 & Convert.ToString(pivote.Rows[i].Cells[1].Value) != "" && pivote.Rows[i].Cells[1].Value != null)
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
                                        pivote.Rows[i1].Cells["Congelado"].Value = dd;
                                        pivote.Rows[i1].Cells["Congelado"].Style.BackColor = Color.Aqua;
                                    }));
                                });
                              }
                            }
                        }
                    else
                    {
                        for (var x = 0; x < pivote.Rows.Count; x++)
                        {
                            pivote.Columns[x].ReadOnly = false;
                            pivote.Rows[x].Cells["Congelado"].Style.BackColor = Color.Aqua;
                            pivote.Rows[x].Cells["Congelado"].Style.BackColor = Color.Orange;
                            pivote.Rows[x].Cells["CantidadReceta"].Style.BackColor = Color.Orange;
                            pivote.Rows[x].Cells["PrecioCompra"].Style.BackColor = Color.Orange;
                            pivote.Rows[x].Cells["GananciaTotal"].Style.BackColor = Color.Orange;
                        }
                        pivote.Enabled = false;
                        //pivote.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        pivote.EditMode = DataGridViewEditMode.EditOnEnter;
                        pivote.AllowUserToAddRows = true;
                        var gridViewColumn1 = pivote.Columns["MenId"];
                        if (gridViewColumn1 != null) gridViewColumn1.Visible = false;
                        var viewColumn1 = pivote.Columns["CantidadReceta"];
                        if (viewColumn1 != null) viewColumn1.Visible = true;
                        var column1 = pivote.Columns["Congelado"];
                        if (column1 != null) column1.Visible = true;
                        var dataGridViewColumn = pivote.Columns["UnidadDgv"];
                        if (dataGridViewColumn != null) dataGridViewColumn.DisplayIndex = 4;
                    }
                    if (cbDias.CheckBoxItems[Convert.ToInt32((view.Tag as PropiedadesDgv)?.IdDia)].Checked) continue;
                
                    if (result >= 0)
                    {
                        pivote.Enabled = true;
                        pivote.Rows.Clear();
                        pivote.Columns.Clear();
                        pivote.DefaultCellStyle.BackColor = Color.Gainsboro;
                        for (var x = 0; x < pivote.Rows.Count; x++)
                        {
                            pivote.Rows[x].Cells["Congelado"].Style.BackColor = Color.Aqua;
                            pivote.Rows[x].Cells["CantidadReceta"].Style.BackColor = Color.Orange;
                            pivote.Rows[x].Cells["PrecioCompra"].Style.BackColor = Color.Orange;
                            pivote.Rows[x].Cells["GananciaTotal"].Style.BackColor = Color.Orange;
                        }
                    }
                    else
                    {
                        pivote.DefaultCellStyle.BackColor = Color.Yellow;
                    }
                    pivote.Rows.Clear();
                    pivote.Columns.Clear();
                    foreach (DataGridViewRow row in pivote.Rows)
                    {
                        pivote.Rows[row.Index].Cells["Congelado"].Style.BackColor = Color.Aqua;
                        pivote.Rows[row.Index].Cells["CantidadReceta"].Style.BackColor = Color.Orange;
                        pivote.Rows[row.Index].Cells["PrecioCompra"].Style.BackColor = Color.Orange;
                        pivote.Rows[row.Index].Cells["GananciaTotal"].Style.BackColor = Color.Orange;
                    }
                    btAgregarSemana.Enabled = false;
                    cbDias.Text = "";
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
                    if (pivote.Rows.Count > 0 & Convert.ToString(pivote.Rows[row].Cells[1].Value) != "" && pivote.Rows[row].Cells[1].Value != null)
                    {
                         var dato = Convert.ToString(pivote.Rows[row].Cells["Platillo"].Value.ToString());
                        char[] separador = { '(', ')' };
                        var valor = Convert.ToString(dato).Split(separador);
                        var clave = valor[1];
                        Cocina.PlatillosMenus.Clave = clave;
                        Data.MenuSemanal.ExistenciaCongelado(y =>
                        {
                            BeginInvoke((MethodInvoker)(() =>
                            {
                                var dd = Opcion.JsonaClaseGenerica<PlatilloReceta>(y).Congelado;
                                pivote.Rows[row].Cells["Congelado"].Value = dd;
                                pivote.Rows[row].Cells["Congelado"].Style.BackColor = Color.Aqua;
                            }));
                        });
                        Data.MenuSemanal.SacarParamentrosReceta(z =>
                        {
                            BeginInvoke((MethodInvoker)(() =>
                            {
                                var cantidadreceta = Opcion.JsonaClaseGenerica<PlatilloReceta>(z).CantidadReceta;
                                var preciocompra = Opcion.JsonaClaseGenerica<PlatilloReceta>(z).PrecioCompra;
                                //var ganaciatotal = Opcion.JsonaClaseGenerica<PlatilloReceta>(z).GanaciaTotal;
                                pivote.Rows[row].Cells["PrecioCompra"].Value = preciocompra;
                                //pivote.Rows[row].Cells["GananciaTotal"].Value = ganaciatotal;
                                pivote.Rows[row].Cells["CantidadReceta"].Value = cantidadreceta;
                            }));
                        });
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
                var col = new DataGridViewComboBoxColumn
                {
                    Name = "TipoRecetaDgv",
                    DataPropertyName = "TipoRecetaDgv",
                    HeaderText = @"TipoReceta",
                    DataSource = _tiposrecetas,
                    DisplayMember = "TipoReceta",
                    ValueMember = "TipoReceta"
                };
                var col2 = new DataGridViewComboBoxColumn
                {
                    Name = "UnidadDgv",
                    DataPropertyName = "UnidadDgv",
                    HeaderText = @"Unidad",
                    DataSource = _tiposunidades,
                    DisplayMember = "Unidad",
                    ValueMember = "Unidad"
                };  
                dgv.Columns.Add(col2);
                dgv.Columns.Add(col);
                dgv.DataSource = (this[propertyName] as BindingList<MenuDia>);
                //dgv.Columns[0].ReadOnly = true;
                //dgv.Columns[5].ReadOnly = true;
                var dataGridViewColum = dgv.Columns["MenId"];
                if (dataGridViewColum != null) dataGridViewColum.Visible = false;
                var viewColum = dgv.Columns["UnidadDgv"];
                if (viewColum != null) viewColum.DisplayIndex = 4;
                var dataGridViewColumn = dgv.Columns["CantidadElaborar"];
                if (dataGridViewColumn != null)
                    dataGridViewColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                var gridViewColumn = dgv.Columns["PrecioCompra"];
                if (gridViewColumn != null)
                    gridViewColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                var viewColumn = dgv.Columns["GananciaTotal"];
                if (viewColumn != null)
                    viewColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                var dataGridViewColumn2 = dgv.Columns["Congelado"];
                if (dataGridViewColumn2 != null)
                    dataGridViewColumn2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                var gridViewColumn2 = dgv.Columns["CantidadReceta"];
                if (gridViewColumn2 != null)
                    gridViewColumn2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns[1].Width = 150;
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    dgv.Rows[row.Index].Cells["Congelado"].Style.BackColor = Color.Aqua;
                    dgv.Rows[row.Index].Cells["CantidadReceta"].Style.BackColor = Color.Orange;
                    dgv.Rows[row.Index].Cells["PrecioCompra"].Style.BackColor = Color.Orange;
                    dgv.Rows[row.Index].Cells["GananciaTotal"].Style.BackColor = Color.Orange;

                }
            }            
        }
        private void dgvGenerico_MouseDown(object sender,MouseEventArgs e)
        {
            var pivote = (DataGridView)sender;
            _rowIndexFromMouseDown = pivote.HitTest(e.X, e.Y).RowIndex;
            if (_rowIndexFromMouseDown != -1)
            {
                var dragSize = SystemInformation.DragSize;
                _dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2),
                    e.Y - (dragSize.Height / 2)),
                    dragSize);
            }
            else
                _dragBoxFromMouseDown = Rectangle.Empty;
         
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
                pivote.DataSource = null;//esto es para el row
                var col = new DataGridViewComboBoxColumn
                {
                    Name = "TipoRecetaDgv",
                    DataPropertyName = "TipoRecetaDgv",
                    HeaderText = @"TipoReceta",
                    DataSource = _tiposrecetas,
                    DisplayMember = "TipoReceta",
                    ValueMember = "TipoReceta"
                };
                var col2 = new DataGridViewComboBoxColumn
                {
                    Name = "UnidadDgv",
                    DataPropertyName = "UnidadDgv",
                    HeaderText = @"Unidad",
                    DataSource = _tiposunidades,
                    DisplayMember = "Unidad",
                    ValueMember = "Unidad"
                };
                pivote.Columns.Add(col2);
                pivote.Columns.Add(col);
      
                pivote.DataSource = (this[(pivote.Tag as PropiedadesDgv)?.NombreDia] as BindingList<MenuDia>);
                var viewColumn = pivote.Columns["UnidadDgv"];
                if (viewColumn != null) viewColumn.DisplayIndex = 4;
                var dataGridViewColum = pivote.Columns["MenId"];
                if (dataGridViewColum != null) dataGridViewColum.Visible = false;
                var dataGridViewColumn = pivote.Columns["CantidadElaborar"];
                if (dataGridViewColumn != null)
                    dataGridViewColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                var gridViewColumn = pivote.Columns["PrecioCompra"];
                if (gridViewColumn != null)
                    gridViewColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                var viewColum = pivote.Columns["GananciaTotal"];
                if (viewColum != null)
                    viewColum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                var dataGridViewColumn2 = pivote.Columns["Congelado"];
                if (dataGridViewColumn2 != null)
                    dataGridViewColumn2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                var gridViewColumn2 = pivote.Columns["CantidadReceta"];
                if (gridViewColumn2 != null)
                    gridViewColumn2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                pivote.Columns[1].Width = 150;
                foreach (DataGridViewRow row in pivote.Rows)
                {
                    pivote.Rows[row.Index].Cells["Congelado"].Style.BackColor = Color.Aqua;
                    pivote.Rows[row.Index].Cells["CantidadReceta"].Style.BackColor = Color.Orange;
                    pivote.Rows[row.Index].Cells["PrecioCompra"].Style.BackColor = Color.Orange;
                    pivote.Rows[row.Index].Cells["GananciaTotal"].Style.BackColor = Color.Orange;
                }
            }
        }
        private void dgvGenerico_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
        #endregion
        private void Generico_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var pivote = (DataGridView)sender;
            var rowIndex = pivote.CurrentCell.RowIndex;
            var valor = Convert.ToString(pivote.Rows[rowIndex].Cells[0].Value);
            var column = pivote.CurrentCell.ColumnIndex;
            var headerText = pivote.Columns[column].HeaderText;

            e.Control.KeyPress -=(dgvGenerico_KeyPress);
            if (pivote.CurrentCell.ColumnIndex == 2 ||pivote.CurrentCell.ColumnIndex==3 || pivote.CurrentCell.ColumnIndex==5)
            {
                var tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress +=(dgvGenerico_KeyPress);
                }
            }
            if (!headerText.Equals("Platillo")) return;
            var autoText = e.Control as TextBox;
            if (autoText == null) return;
            autoText.AutoCompleteMode = AutoCompleteMode.Suggest;
            autoText.AutoCompleteSource = AutoCompleteSource.CustomSource;
            Cocina.PlatillosMenus.Nombre = valor;
            var dataCollection = new AutoCompleteStringCollection();
            Opcion.EjecucionAsync(Data.MenuSemanal.ListaPlatilloRecetas, y =>
            {
                var dd = Opcion.JsonaListaGenerica<PlatilloReceta>(y).Select(x => x.Platillo).ToArray();
                BeginInvoke((MethodInvoker)(() =>
                {
                    dataCollection.AddRange(dd);
                    autoText.AutoCompleteCustomSource = dataCollection;
                }));

            });
        }
        public int menidd;
        private static void GuardarMenuSemanal(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                var view = c as DataGridView;
                if (view != null)
                {
                    var pivote = view;
                    pivote.AllowUserToAddRows = false;
                    var fecha = DateTime.Parse((pivote.Tag as PropiedadesDgv)?.LabelFecha.Text, CultureInfo.CurrentCulture);
                    
                    var result = DateTime.Compare(fecha, DateTime.Now);
                    if (result < 0) continue;
                    for (var i = 0; i < pivote.Rows.Count; i++)
                    {
                        var dd = pivote.Rows[i].Cells[1].Value;
                        if ((string) dd != "")
                        {
                        var menid = Convert.ToInt32(pivote.Rows[i].Cells["MenId"].Value);
                        var cantidad = Convert.ToDouble(pivote.Rows[i].Cells["CantidadElaborar"].Value);
                        var congelado = Convert.ToDouble(pivote.Rows[i].Cells["Congelado"].Value);
                        var cantidadfinal = cantidad - congelado;
                        var dato = Convert.ToString(pivote.Rows[i].Cells["Platillo"].Value.ToString());
                        char[] separador = { '(', ')' };
                        var valor = dato.Split(separador);
                        var clave = valor[1];
                        Cocina.PlatillosMenus.Clave = clave;
                        var tipo = Convert.ToString(pivote.Rows[i].Cells["TipoRecetaDgv"].Value.ToString());
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
                                        PrecioFinal = Convert.ToDouble(pivote.Rows[i1].Cells["PrecioCompra"].Value.ToString()),
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
                                        PrecioFinal = Convert.ToDouble(pivote.Rows[i1].Cells["PrecioCompra"].Value.ToString()),
                                        TipoId = tipoid
                                    };
                                    Data.MenuSemanal.ActualizarMenuActual(menu);
                                }       
                                    });});
                        Data.MenuSemanal.UtilizarCongelado(1);
                        pivote.Enabled = false;
                    }
                    }
                }
                else
                {
                   GuardarMenuSemanal(c);
                }
            }
        }
        private void btGuardar_Click(object sender, EventArgs e)
        {
            GuardarMenuSemanal(this);
            btPreviaPlatilloGlobal.Enabled = true;
            btPreviaPlatillo.Enabled = true;
        }
        private void dgvGenerico_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var pivote = (DataGridView)sender;
            if (!pivote.Rows[e.RowIndex].Cells[1].Selected & !pivote.Rows[e.RowIndex].Cells[1].Selected) return;
            pivote.AllowUserToAddRows = true;
            if (pivote.Rows[e.RowIndex].Cells[0].Value != null)
            {
                pivote.Rows[e.RowIndex].Cells[1].ReadOnly = false;
                pivote.Rows[e.RowIndex].Cells["Congelado"].Style.BackColor = Color.Aqua;
                pivote.Rows[e.RowIndex].Cells["CantidadReceta"].Style.BackColor = Color.Orange;
                pivote.Rows[e.RowIndex].Cells["PrecioCompra"].Style.BackColor = Color.Orange;
                pivote.Rows[e.RowIndex].Cells["GananciaTotal"].Style.BackColor = Color.Orange;
            }
            else
            { 
                pivote.Rows[e.RowIndex].Cells[1].ReadOnly = true;
                MessageBox.Show(@"Seleccione el tipo de receta antes de seleccionar el platillo");

            }
            menidd = Convert.ToInt32(pivote.Rows[e.RowIndex].Cells["MenId"].Value);
            //var bs = new BindingSource();
            //pivote.DataSource = bs;
            DgvSeleccionado=pivote;
            

        }
        private void dgvGenerico_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }
        private void dgvGenerico_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var pivote = (DataGridView)sender;
            var rowIndex = pivote.CurrentCell.RowIndex;
            btGuardar.Enabled = true;
      

            if (Convert.ToDouble(pivote.Rows[rowIndex].Cells["CantidadElaborar"].Value) > 0 && Convert.ToString(pivote.Rows[rowIndex].Cells[1].Value)!="")
            {
                var dato = Convert.ToString(pivote.Rows[e.RowIndex].Cells["Platillo"].Value.ToString());
                char[] separador = { '(', ')' };
                var valor = Convert.ToString(dato).Split(separador);
                var clave = valor[1];
                Cocina.PlatillosMenus.Clave = clave;
                Data.MenuSemanal.SacarParamentrosReceta(z =>
                {
                    var precio = Opcion.JsonaClaseGenerica<PlatilloReceta>(z).PrecioCompra;
                    var cantidadreal2 = Convert.ToDouble(pivote.Rows[rowIndex].Cells["CantidadElaborar"].Value);
                    //var cantidadreceta = Convert.ToDouble(pivote.Rows[rowIndex].Cells["CantidadReceta"].Value);
                    var gananciatotal = precio * cantidadreal2;
                     pivote.Rows[rowIndex].Cells["GananciaTotal"].Value = Math.Round(gananciatotal, 2);
                });
            }

            if (!pivote.Rows[rowIndex].Cells[1].Selected || pivote.Rows[e.RowIndex].Cells["Platillo"].Value == null)
             return;
            DetallePlatillos(pivote);
            //for (var x = 0; x < pivote.Rows.Count - 2; x++)
            //{
            //    if (pivote.Rows[x].Cells["Platillo"].Value.ToString() !=
            //        pivote.Rows[rowIndex].Cells["Platillo"].Value.ToString()) continue;
            //    pivote.Rows[rowIndex].Cells[1].Value = "";
            //    MessageBox.Show(@"El platillo ya fue seleecionado antes, favor de ingresar un nuevo platillo", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}


        }
        private void dgvGenerico_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            var pivote = (DataGridView)sender;
            var rowIndex = pivote.CurrentCell.RowIndex;
            //var col = pivote.Columns[pivote.CurrentCell.ColumnIndex];
            var col2 = pivote.Rows[rowIndex].Cells[0].Selected;
            if (!(col2)) return;
            pivote.CommitEdit(DataGridViewDataErrorContexts.Commit);
            pivote.Rows[rowIndex].Cells["Platillo"].Value = "";
            pivote.Rows[rowIndex].Cells["Congelado"].Value = 0;
            pivote.Rows[rowIndex].Cells["MenId"].Value = 0;
            pivote.Rows[rowIndex].Cells["PrecioCompra"].Value = 0;
            pivote.Rows[rowIndex].Cells["GananciaTotal"].Value = 0;
            pivote.Rows[rowIndex].Cells["CantidadReceta"].Value = 0;
            pivote.Rows[rowIndex].Cells["CantidadElaborar"].Value = 0;
            pivote.AllowUserToAddRows = true;
        }      
        private void IngredientesPlatillosGlobal(Control parent)
        {  
            foreach (Control c in parent.Controls)
             {
                var view = c as DataGridView;
                if (view != null)
                {
                    var pivote = view;
                    pivote.AllowUserToAddRows = false;
                    var fecha = DateTime.Parse((pivote.Tag as PropiedadesDgv)?.LabelFecha.Text, CultureInfo.CurrentCulture);
                    var result = DateTime.Compare(fecha, DateTime.Now);
                    if (result < 0) continue;
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
                            var cantidadreal = Convert.ToDouble(pivote.Rows[i1].Cells["CantidadElaborar"].Value);
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
                                                Fecha = (pivote.Tag as PropiedadesDgv)?.LabelFecha.Text,
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
                                                Fecha = (pivote.Tag as PropiedadesDgv)?.LabelFecha.Text,
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
                                Fecha = g.First().Fecha
                            }).ToList();
                    }
                    }
                }
                else
                {
                    IngredientesPlatillosGlobal(c);
                }
            }
        }
        private void IngredientesPlatillo(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                var view = c as DataGridView;
                if (view != null)
                {
                    var pivote = view;
                    pivote.AllowUserToAddRows = false;
                    var fecha = DateTime.Parse((pivote.Tag as PropiedadesDgv)?.LabelFecha.Text, CultureInfo.CurrentCulture);
                    var result = DateTime.Compare(fecha, DateTime.Now);
                    if (result < 0) continue;
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
                                var cantidadreal = Convert.ToDouble(pivote.Rows[i1].Cells["CantidadElaborar"].Value);
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
                                                    Fecha = (pivote.Tag as PropiedadesDgv)?.LabelFecha.Text,
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
                                                    Fecha = (pivote.Tag as PropiedadesDgv)?.LabelFecha.Text,
                                                }).ToList();
                                        }
                                    });
                            });
                            _listaArticuloBasica2.AddRange(_listaArticuloBasica1);
                        }
                    }
                }
                else
                {
                    IngredientesPlatillo(c);
                }
            }
        }
        private void btEditarSemana_Click(object sender, EventArgs e)
        {
            var diainicio = FirstDayOfWeek(DateTime.Today).ToShortDateString();
            var diafinal = LastDayOfWeek(DateTime.Today).ToShortDateString();
            FechaLunes.Text = Convert.ToDateTime(diainicio).ToShortDateString();
            FechaMartes.Text = Convert.ToDateTime(diainicio).AddDays(1).ToShortDateString();
            FechaMiercoles.Text = Convert.ToDateTime(diainicio).AddDays(2).ToShortDateString();
            FechaJueves.Text = Convert.ToDateTime(diainicio).AddDays(3).ToShortDateString();
            FechaViernes.Text = Convert.ToDateTime(diainicio).AddDays(4).ToShortDateString();
            FechaSabado.Text = Convert.ToDateTime(diainicio).AddDays(5).ToShortDateString();
            FechaDomingo.Text = Convert.ToDateTime(diafinal).ToShortDateString();
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
                                btDiarios.Enabled = true;
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
                pivote.Rows[e.RowIndex].Cells["CantidadElaborar"].Value = @"0";
            }
        }
        private void btBorrarFila_Click(object sender, EventArgs e)
        {
            if(dgvDomingo.RowCount>0 )
            {
                Opcion.BorrarFila(DgvSeleccionado);
                Data.MenuSemanal.EliminarelPlatillo(menidd);
                InicializarDgv(this);
            }
        }
        private void btDiarios_Click(object sender, EventArgs e)
        {
            if(LabelLunes.Text!="")
            {
               PlatillosDiarios(this);
            }
        }
        private void btPreviaPlatilloGlobal_Click(object sender, EventArgs e)
        {
            _listaArticuloBasica2 = new List<IngredientesReceta>();
            IngredientesPlatillosGlobal(this);
            var addIn = Globals.ThisAddIn;
            addIn.IngredientesMenuGlobal(_listaArticuloBasica2);
        }
        private void btPreviaPlatillo_Click(object sender, EventArgs e)
        {
            _listaArticuloBasica2 = new List<IngredientesReceta>();
            IngredientesPlatillo(this);
            var addIn = Globals.ThisAddIn;
            addIn.IngredientesMenuxPlatillo(_listaArticuloBasica2);
        }
        private void PlatillosDiarios(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                var view = c as DataGridView;
                if (view != null)

               {
                    var pivote = view;
                    pivote.AllowUserToAddRows = true;
                    var fecha = DateTime.Parse((pivote.Tag as PropiedadesDgv)?.LabelFecha.Text);
                    var result = DateTime.Compare(fecha, DateTime.Today);
                    if (result >= 0)
                    {
                        pivote.Enabled = true;
                        pivote.DefaultCellStyle.BackColor = Color.Gainsboro;
                        Cocina.PlatillosMenus.TipooId = Convert.ToString(5);
                        var bs = new BindingSource();
                        for (var i = 0; i < pivote.Rows.Count; i++)
                        {
                            if (Convert.ToString(pivote.Rows[0].Cells[1].Value) == "")
                            {
                                //pivote.Rows.Remove(pivote.Rows[0]);
                                pivote.Rows.RemoveAt(0);
                            }
                        }
                        Opcion.EjecucionAsync(Data.MenuSemanal.ListaDiarios, jsonResult =>
                   {
                       BeginInvoke((MethodInvoker)(() =>
                {
                var brd = Opcion.JsonaListaGenerica<MenuDia>(jsonResult);
                {
                        var propiedadesDgv = pivote.Tag as PropiedadesDgv;
                        if (propiedadesDgv != null)
                            _listaRecetaDiarias1 = this[propiedadesDgv.NombreDia] as BindingList<MenuDia>;
                               _listaRecetaDiarias2 = brd.ToList();
                                       if (_listaRecetaDiarias1 != null)
                                       {
                                           _listaRecetaDiarias2.AddRange(_listaRecetaDiarias1);
                                       }
                                  
                   _listaRecetaDiarias2 = _listaRecetaDiarias2.OrderBy(x => x.TipoRecetaDgv).ToList();
                    bs.DataSource = _listaRecetaDiarias2;
                    bs.EndEdit();
                        for (int i = 0; i < bs.Count; i++)
                        {
                            bs.ResetItem(i);
                        }
                        pivote.DataSource = bs;
                        pivote.EndEdit();
                        pivote.EditMode = DataGridViewEditMode.EditOnEnter;
                        pivote.ReadOnly = false;
                        pivote.AllowUserToAddRows = true;
                        for (var x = 0; x < pivote.Rows.Count; x++)
                        {
                            if (pivote.Rows.Count > 0)
                            {
                                        var i1 = x;
                                        pivote.Rows[i1].Cells["Congelado"].Style.BackColor = Color.Aqua;
                                        pivote.Rows[i1].Cells["CantidadReceta"].Style.BackColor = Color.Orange;
                                        pivote.Rows[i1].Cells["PrecioCompra"].Style.BackColor = Color.Orange;
                                        pivote.Rows[i1].Cells["GananciaTotal"].Style.BackColor = Color.Orange;
                            }
                            var propiedadDgv = pivote.Tag as PropiedadesDgv;
                            if (propiedadDgv != null)
                                _listaRecetaDiarias1 = this[propiedadDgv.NombreDia] as BindingList<MenuDia>;
                            btAgregarSemana.Enabled = false;
                            btDiarios.Enabled = false;
                            cbDias.Text = "";
                            pivote.AllowUserToAddRows = true;
                        }
                    }
                }));
                   });
                      
                    }
                }
                else
                {
                    PlatillosDiarios(c);
                }
            }
        }
    }
}












