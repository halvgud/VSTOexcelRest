using System;
using System.Windows.Forms;
using Respuesta;
using Herramienta;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using PresentationControls;
using System.Globalization;
using System.Net;
using Herramienta.Config;
using Font = System.Drawing.Font;
using Label = System.Windows.Forms.Label;
using Point = System.Drawing.Point;
using Rectangle = System.Drawing.Rectangle;
using TextBox = System.Windows.Forms.TextBox;
using System.Drawing;

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
        public BindingList<MenuDiasSemana> LunesActual { get; set; }
        public BindingList<MenuDiasSemana> MartesActual { get; set; }
        public BindingList<MenuDiasSemana> MiercolesActual{ get; set; }
        public BindingList<MenuDiasSemana> JuevesActual { get; set; }
        public BindingList<MenuDiasSemana> ViernesActual{ get; set; }
        public BindingList<MenuDiasSemana> SabadoActual { get; set; }
        public BindingList<MenuDiasSemana> DomingoActual { get; set; }
        public class Inputs
        {
            public CheckBoxComboBox DiasSemana;
            public DataGridView DtvMenus;
        }

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
        private List<PlatilloReceta> _listareceta;
        private readonly List<TipoRecetas> _tiposrecetas;
        private readonly List<TipoUnidades> _tiposunidades;
        #endregion
        public MenuSemanal()
        {
            _listareceta = new List<PlatilloReceta>();
            _listaArticuloBasica1 = new List<IngredientesReceta>();
            _listaArticuloBasica2 = new List<IngredientesReceta>();
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


            //dgvLunes.Tag = new PropiedadesDgv { IdDia = 1, NombreDia = "LunesActual", LabelFecha = FechaLunes };
            //dgvMartes.Tag = new PropiedadesDgv { IdDia = 2, NombreDia = "MartesActual", LabelFecha = FechaMartes };
            //dgvMiercoles.Tag = new PropiedadesDgv { IdDia = 3, NombreDia = "MiercolesActual", LabelFecha = FechaMiercoles };
            //dgvJueves.Tag = new PropiedadesDgv { IdDia = 4, NombreDia = "JuevesActual", LabelFecha = FechaJueves };
            //dgvViernes.Tag = new PropiedadesDgv { IdDia = 5, NombreDia = "ViernesActual", LabelFecha = FechaViernes };
            //dgvSabado.Tag = new PropiedadesDgv { IdDia = 6, NombreDia = "SabadoActual", LabelFecha = FechaSabado };
            //dgvDomingo.Tag = new PropiedadesDgv { IdDia = 7, NombreDia = "DomingoActual", LabelFecha = FechaDomingo };


            _tiposrecetas.Add(new TipoRecetas { IdReceta = 1, TipoReceta = "Guarnicion" });
            _tiposrecetas.Add(new TipoRecetas { IdReceta = 2, TipoReceta = "Fritangas" });
            _tiposrecetas.Add(new TipoRecetas { IdReceta = 3, TipoReceta = "Plato Fuerte" });
            _tiposrecetas.Add(new TipoRecetas { IdReceta = 4, TipoReceta = "Postre" });

            _tiposunidades.Add(new TipoUnidades {IdUnidad = 1, Unidad = "PZA" });
            _tiposunidades.Add(new TipoUnidades { IdUnidad = 2, Unidad = "CAJA" });
            _tiposunidades.Add(new TipoUnidades { IdUnidad = 3, Unidad = "m" });
            _tiposunidades.Add(new TipoUnidades { IdUnidad = 4, Unidad = "KG" });
            _tiposunidades.Add(new TipoUnidades { IdUnidad = 5, Unidad = "LT" });
            _tiposunidades.Add(new TipoUnidades { IdUnidad = 6, Unidad = "NA" });
            _tiposunidades.Add(new TipoUnidades { IdUnidad = 7, Unidad = "20" });
            _tiposunidades.Add(new TipoUnidades { IdUnidad = 8, Unidad = "GR" });
            _tiposunidades.Add(new TipoUnidades { IdUnidad = 9, Unidad = "Pqt" });
            btImprimirPrevia.Enabled = false;
            btAgregarSemana.Enabled = false;
            btGuardar.Enabled = false;
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

                    var dataGridViewColumn1 = pivote.Columns["UnidadDgv"];
                    if (dataGridViewColumn1 != null) dataGridViewColumn1.DisplayIndex = 3;
                    pivote.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 6);
                    pivote.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    pivote.Enabled = false;
                    pivote.Columns[1].Width = 150;
                    var column = pivote.Columns["Unidad"];
                    if (column != null) column.Width = 10;
                    pivote.AllowUserToAddRows = false;
                    pivote.RowHeadersVisible = false;
                    var dataGridViewColumn = pivote.Columns["Cantidad"];
                    if (dataGridViewColumn != null)
                        dataGridViewColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    var gridViewColumn = pivote.Columns["PrecioCompra"];
                    if (gridViewColumn != null)
                        gridViewColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    var viewColumn = pivote.Columns["GananciaTotal"];
                    if (viewColumn != null)
                        viewColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                else
                {
                    InicializarDgv(c);
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
            });
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
        private void btAgregarSemana_Click(object sender, EventArgs e)
        {
            DtpFecha.Value = DateTime.Now;
            MoverDatosSemanaActual(this);
            ParamentrosdelPlatillo(this);
            if (!cbDias.CheckBoxItems[0].Checked) return;
            dgvLunes.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvMartes.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvMiercoles.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvJueves.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvViernes.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvSabado.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvDomingo.EditMode = DataGridViewEditMode.EditOnEnter;
       
        }
        private void MoverDatosSemanaActual(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                var view = c as DataGridView;
                if (view != null)
                {
                    var pivote = view;
                    var congelado = new DataGridViewTextBoxColumn
                    {
                        Name = "Congelado",
                        DataPropertyName = "Congelado",
                        HeaderText = @"Congelado"
                    };

                    var cantidadreceta = new DataGridViewTextBoxColumn
                    {
                        Name = "CantidadReceta",
                        DataPropertyName = "CantidadReceta",
                        HeaderText = @"CantidadReceta"
                    };
                    var fecha = DateTime.Parse((pivote.Tag as PropiedadesDgv)?.LabelFecha.Text, CultureInfo.CurrentCulture);
                    var result = DateTime.Compare(fecha, DateTime.Now);
                    if (cbDias.CheckBoxItems[Convert.ToInt32((view.Tag as PropiedadesDgv)?.IdDia)].Checked && result > 0)
                    {
                        pivote.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        pivote.Enabled = true;
                        pivote.EditMode = DataGridViewEditMode.EditOnEnter;
                        pivote.AllowUserToAddRows = true;
                        pivote.Columns.Add(congelado);
                        pivote.Columns.Add(cantidadreceta);
                        var dataGridViewColumn = pivote.Columns["CantidadReceta"];
                        if (dataGridViewColumn != null) dataGridViewColumn.DisplayIndex = 2;
                        var gridViewColumn = pivote.Columns["Congelado"];
                        if (gridViewColumn != null) gridViewColumn.DisplayIndex = 7;
                        pivote.Columns[7].ReadOnly = true;
                        pivote.Columns[5].ReadOnly = true;
                        //pivote.Columns[6].ReadOnly = true;
                        var viewColumn = pivote.Columns["CantidadReceta"];
                        if (viewColumn != null)
                            viewColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        var column = pivote.Columns["Congelado"];
                        if (column != null)
                            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        if (column != null) column.Width = 60;
                        var dataGridViewColumn1 = pivote.Columns["Cantidad"];
                        if (dataGridViewColumn1 != null) dataGridViewColumn1.Width = 50;
                    }
                    else 
                    {
                        for (var x = 0; x == 8; x++)
                        {
                            pivote.Columns[x].ReadOnly = false;
                        }
                        pivote.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        pivote.Enabled = false;
                        pivote.AllowUserToAddRows = true;
                        pivote.Columns.Add(congelado);
                        pivote.Columns.Add(cantidadreceta);
                        var dataGridViewColumn = pivote.Columns["CantidadReceta"];
                        if (dataGridViewColumn != null) dataGridViewColumn.DisplayIndex = 2;
                        var gridViewColumn = pivote.Columns["Congelado"];
                        if (gridViewColumn != null) gridViewColumn.DisplayIndex = 7;
                        pivote.Columns[7].ReadOnly = true;
                        pivote.Columns[5].ReadOnly = true;
                        //pivote.Columns[6].ReadOnly = true;
                        var viewColumn = pivote.Columns["CantidadReceta"];
                        if (viewColumn != null)
                            viewColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        var column = pivote.Columns["Congelado"];
                        if (column != null)
                            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        if (column != null) column.Width = 60;
                        var dataGridViewColumn1 = pivote.Columns["Cantidad"];
                        if (dataGridViewColumn1 != null) dataGridViewColumn1.Width = 50;
                    
                }
                    if (cbDias.CheckBoxItems[Convert.ToInt32((view.Tag as PropiedadesDgv)?.IdDia)].Checked) continue;
                    pivote.DataSource = null;
                    pivote.Rows.Clear();
                    pivote.Columns.Clear();
                }
                else
                {
                    MoverDatosSemanaActual(c);
                }
            }
        }
        private void ParamentrosdelPlatillo(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                var view = c as DataGridView;
                if (view != null)
                {
                    var pivote = view;
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
                                var dd = Opcion.JsonaClaseGenerica<PlatilloReceta>(y).Congelado;
                                pivote.Rows[i1].Cells["Congelado"].Value = dd;
                            });
                           
                           //////Opcion.EjecucionAsync( Data.MenuSemanal.SacarParamentrosReceta,jsonresult=>
                           //////{
                           //////    {
                           //////        var lista = Opcion.JsonaListaGenerica<PlatilloReceta>(jsonresult);
                           //////      _listareceta= lista
                           //////            .Select(g => new PlatilloReceta
                           //////            {
                           //////                CantidadElaboracion = g.CantidadElaboracion,
                           //////                CostoCreacion = g.CostoCreacion,
                           //////                CostoElaboracion=g.CostoElaboracion,
                           //////                Precio=g.Precio
                           //////            }).ToList();
                           //////    }
                           //////    var costocreacion = _listareceta.Select(x => x.CostoCreacion).ToArray();
                           //////    var costoelaboracion = _listareceta.Select(x => x.CostoElaboracion).ToArray();
                           //////    var precio =_listareceta.Select(x => x.Precio).ToArray();
                           //////    var cantidad =_listareceta.Select(x => x.CantidadElaboracion).ToArray();
                           //////    var sum = costoelaboracion[0] + costocreacion[0];
                           //////    var gananciatotal = cantidad[0] * precio[0];
                           //////    pivote.Rows[i1].Cells["CantidadReceta"].Value = cantidad[0];
                           //////    pivote.Rows[i1].Cells["PrecioCompra"].Value = Math.Round(sum,2);
                           //////    pivote.Rows[i1].Cells["GananciaTotal"].Value = Math.Round(gananciatotal,2);


                               //var costocreacion = Opcion.JsonaClaseGenerica<PlatilloReceta>(z).CostoCreacion;
                               //var costoelaboracion = Opcion.JsonaClaseGenerica<PlatilloReceta>(z).CostoElaboracion;
                               //var precio = Opcion.JsonaClaseGenerica<PlatilloReceta>(z).Precio;
                               //var sum = costocreacion + costoelaboracion;
                               //var ganaciatotal = cantidad * precio;
                               //pivote.Rows[i1].Cells["CantidadReceta"].Value = cantidad;
                               //pivote.Rows[i1].Cells["PrecioCompra"].Value = sum;
                               //pivote.Rows[i1].Cells["GananciaTotal"].Value = ganaciatotal;
                           //////});
                        }
            }
            foreach (DataGridViewRow row in pivote.Rows)
                    {
                        pivote.Rows[row.Index].Cells["Congelado"].Style.BackColor = Color.Aqua;
                    }
                }
                else
                {
                    ParamentrosdelPlatillo(c);
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
                var congelado = new DataGridViewTextBoxColumn
                {
                    Name = "Congelado",
                    DataPropertyName = "Congelado",
                    HeaderText = @"Congelado"
                };
                var cantidadprevia = new DataGridViewTextBoxColumn
                {
                    Name = "CantidadReceta",
                    DataPropertyName = "CantidadReceta",
                    HeaderText = @"CantidadReceta"
                };
                dgv.Columns.Add(col2);
                dgv.Columns.Add(col);
                dgv.Columns.Add(congelado);
                dgv.Columns.Add(cantidadprevia);
                    
                dgv.DataSource = (this[propertyName] as BindingList<MenuDia>);
            }
           
            dgv.Columns[0].ReadOnly = true;
            dgv.Columns[2].ReadOnly = true;
            dgv.Columns[5].ReadOnly = true;
            dgv.Columns[7].ReadOnly = true;
            var dataGridViewColumn = dgv.Columns["CantidadReceta"];
            if (dataGridViewColumn != null) dataGridViewColumn.DisplayIndex = 2;
            var gridViewColumn = dgv.Columns["Congelado"];
            if (gridViewColumn != null) gridViewColumn.DisplayIndex = 7;
            var viewColumn = dgv.Columns["UnidadDgv"];
            if (viewColumn != null) viewColumn.DisplayIndex = 5;
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
                    Name = "Unidad",
                    DataPropertyName = "Unidad",
                    HeaderText = @"Unidad",
                    DataSource = _tiposunidades,
                    DisplayMember = "Unidad",
                    ValueMember = "Unidad"
                };
                var congelado = new DataGridViewTextBoxColumn
                {
                    Name = "Congelado",
                    DataPropertyName = "Congelado",
                    HeaderText = @"Congelado"
                };
                var cantidadprevia = new DataGridViewTextBoxColumn
                {
                    Name = "CantidadReceta",
                    DataPropertyName = "CantidadReceta",
                    HeaderText = @"CantidadReceta"
                };
                pivote.Columns.Add(cantidadprevia);
                pivote.Columns.Add(col2);
                pivote.Columns.Add(col);
                pivote.Columns.Add(congelado);
                var dataGridViewColumn = pivote.Columns["CantidadReceta"];
                if (dataGridViewColumn != null) dataGridViewColumn.DisplayIndex = 2;
                var gridViewColumn = pivote.Columns["Congelado"];
                if (gridViewColumn != null) gridViewColumn.DisplayIndex = 7;
                var viewColumn = pivote.Columns["UnidadDgv"];
                if (viewColumn != null) viewColumn.DisplayIndex = 5;
                pivote.DataSource = (this[(pivote.Tag as PropiedadesDgv)?.NombreDia] as BindingList<MenuDia>);
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
            if (pivote.CurrentCell.ColumnIndex == 2 || pivote.CurrentCell.ColumnIndex==4 || pivote.CurrentCell.ColumnIndex==5)
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
                    if (result <= 0) continue;
                    for (var i = 0; i < pivote.Rows.Count; i++)
                    {
                        var cantidad = Convert.ToDouble(pivote.Rows[i].Cells["Cantidad"].Value);
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
                        Opcion.EjecucionAsync(Data.MenuSemanal.SacarParamentrosReceta, y =>
                        {
                            var recid = Opcion.JsonaClaseGenerica<PlatilloReceta>(y).RecId;
                            Opcion.EjecucionAsync(Data.MenuSemanal.SacarTipoId, z =>
                            {
                                var tipoid = Opcion.JsonaClaseGenerica<PlatilloReceta>(z).TipoId;
                                var i1 = i2;
                                var menu = new InsertarMenu
                                {
                                    RecId = recid,
                                    Fecha = (pivote.Tag as PropiedadesDgv)?.LabelFecha.Text,
                                    Cantidad = cantidadfinal,
                                    PrecioFinal = Convert.ToDouble(pivote.Rows[i1].Cells[4].Value.ToString()),
                                    TipoId = tipoid
                                };
                                Opcion.EjecucionAsync(x => {
                               Data.MenuSemanal.InsertarMenus(x, menu);
                                }, resultado =>
                                {
                                   
                                });});});
                        Data.MenuSemanal.UtilizarCongelado(1);
                        pivote.Enabled = false;
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
            {
                GuardarMenuSemanal(this);
            }
            btImprimirPrevia.Enabled = true;

        }
        private void dgvGenerico_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var pivote = (DataGridView)sender;
            if (!pivote.Rows[e.RowIndex].Cells[1].Selected & !pivote.Rows[e.RowIndex].Cells[1].Selected) return;
            if (pivote.Rows[e.RowIndex].Cells[0].Value != null)
            {
                pivote.Rows[e.RowIndex].Cells[1].ReadOnly = false;
            }
            else
            { 
                pivote.Rows[e.RowIndex].Cells[1].ReadOnly = true;
                MessageBox.Show(@"Seleccione el Tipo de Receta antes de insertar el Platillo", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            ParamentrosdelPlatillo(this);
            btGuardar.Enabled = true;
            if (Convert.ToDouble(pivote.Rows[rowIndex].Cells["Cantidad"].Value) > 0)
            {
                Data.MenuSemanal.SacarParamentrosReceta(z =>
                {
                var precio = Opcion.JsonaClaseGenerica<PlatilloReceta>(z).Precio;
                var cantidadreal2 = Convert.ToDouble(pivote.Rows[rowIndex].Cells["Cantidad"].Value);
                var cantidadreceta = Convert.ToDouble(pivote.Rows[rowIndex].Cells["CantidadReceta"].Value);
                var gananciatotal = precio * cantidadreal2;
                if (Equals(cantidadreal2, cantidadreceta))
                {
                    pivote.Rows[rowIndex].Cells["GananciaTotal"].Value =Math.Round(gananciatotal,2);

                }
                });
            }
         
            //if (!pivote.Rows[rowIndex].Cells[1].Selected) return;
            ////for (var i = 0; i < pivote.Rows.Count; i++)
            ////{
            ////    if (pivote.Rows[i].Cells[1].Value.Equals(pivote.Rows[i + 1].Cells[1].Value))
            ////    {
            ////        pivote.Rows[rowIndex].Cells[1].Value="";
            ////    }
            ////}

            //for (int currentRow = 0; currentRow < pivote.Rows.Count - 1; currentRow++)
            //{
            //    DataGridViewRow rowToCompare = pivote.Rows[currentRow];

            //    for (int otherRow = currentRow + 1; otherRow < pivote.Rows.Count; otherRow++)
            //    {
            //        DataGridViewRow row = pivote.Rows[otherRow];

            //        bool duplicateRow = false;

            //        for (int cellIndex = 1; cellIndex < row.Cells.Count; cellIndex++)
            //        {
            //            if (!rowToCompare.Cells[cellIndex].Value.Equals(row.Cells[cellIndex].Value))
            //            {
            //                duplicateRow = false;
            //                break;
            //            }
            //        }

            //        if (duplicateRow)
            //        {
            //            pivote.Rows.Remove(row);
            //            otherRow--;
            //        }
            //    }
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
            pivote.Rows[rowIndex].Cells[1].Value = "";
            pivote.Rows[rowIndex].Cells[6].Value = 0;
        }
                
        private void IngredientesPlatillos(Control parent)
        {  
            foreach (Control c in parent.Controls)
{
                var view = c as DataGridView;
                if (view != null)
                {
                    var pivote = view;
                    pivote.AllowUserToAddRows = false;
                    for (var i = 0; i < pivote.Rows.Count; i++)
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
                            var cantidadreal = Convert.ToDouble(pivote.Rows[i1].Cells["Cantidad"].Value);
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
                else
                {
                    IngredientesPlatillos(c);
                }
            }
        }
        private void btImprimirPrevia_Click_1(object sender, EventArgs e)
        {
            _listaArticuloBasica2 = new List<IngredientesReceta>();
            IngredientesPlatillos(this);
            var addIn = Globals.ThisAddIn;
           addIn.IngredientesMenu(_listaArticuloBasica2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //var diainicio = FirstDayOfWeek(DateTime.Today).ToShortDateString();
            //var diafinal = LastDayOfWeek(DateTime.Today).ToShortDateString();
            //FechaLunes.Text = Convert.ToDateTime(diainicio).ToShortDateString();
            //FechaMartes.Text = Convert.ToDateTime(diainicio).AddDays(1).ToShortDateString();
            //FechaMiercoles.Text = Convert.ToDateTime(diainicio).AddDays(2).ToShortDateString();
            //FechaJueves.Text = Convert.ToDateTime(diainicio).AddDays(3).ToShortDateString();
            //FechaViernes.Text = Convert.ToDateTime(diainicio).AddDays(4).ToShortDateString();
            //FechaSabado.Text = Convert.ToDateTime(diainicio).AddDays(5).ToShortDateString();
            //FechaDomingo.Text = Convert.ToDateTime(diafinal).ToShortDateString();
            //Opcion.EjecucionAsync(x =>
            //{
            //    var times = new Reporte.General
            //    {
            //        FechaIni = Convert.ToDateTime(diainicio),
            //        FechaFin = Convert.ToDateTime(diafinal)
            //    };
            //    Data.MenuSemanal.EditarMenuSemanaActual(x, times);
            //}, jsonResult =>
            //{
            //    if (jsonResult != null)
            //    {
            //        BeginInvoke((MethodInvoker)(() =>
            //        {
            //            switch (jsonResult.StatusCode)
            //            {
            //                case HttpStatusCode.OK:
            //                    LunesActual = new BindingList<MenuDiasSemana>(Opcion.JsonaClaseGenerica2<Respuesta.MenuSemanalActual>(jsonResult).LunesActual);
            //                    MartesActual = new BindingList<MenuDiasSemana>(Opcion.JsonaClaseGenerica2<Respuesta.MenuSemanalActual>(jsonResult).MartesActual);
            //                    MiercolesActual = new BindingList<MenuDiasSemana>(Opcion.JsonaClaseGenerica2<Respuesta.MenuSemanalActual>(jsonResult).MiercolesActual);
            //                    JuevesActual = new BindingList<MenuDiasSemana>(Opcion.JsonaClaseGenerica2<Respuesta.MenuSemanalActual>(jsonResult).JuevesActual);
            //                    ViernesActual = new BindingList<MenuDiasSemana>(Opcion.JsonaClaseGenerica2<Respuesta.MenuSemanalActual>(jsonResult).ViernesActual);
            //                    SabadoActual = new BindingList<MenuDiasSemana>(Opcion.JsonaClaseGenerica2<Respuesta.MenuSemanalActual>(jsonResult).SabadoActual);
            //                    DomingoActual = new BindingList<MenuDiasSemana>(Opcion.JsonaClaseGenerica2<Respuesta.MenuSemanalActual>(jsonResult).DomingoActual);
            //                    //InicializarDgv(this);
            //                    break;
            //                default:
            //                    MessageBox.Show(this, @"No se encontraron menus con los parametros de busqueda ingresados");
            //                    break;
            //            }
            //        }));
            //    }
            //});

        }
    }
}












