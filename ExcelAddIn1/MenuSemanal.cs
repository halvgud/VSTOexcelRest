﻿using System;
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

        public class DragDropInfo
        {
            public MenuDia Control { get; set; }
            public DragDropInfo(MenuDia control)
            {
                Control = control;
            }
        }
        private readonly List<TipoRecetas> _tiposrecetas;
        private readonly List<TipoUnidades> _tiposunidades;
        private DataGridView sender;
        #endregion
        public MenuSemanal()
        {
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
            dgvLunes.Tag = new PropiedadesDgv { IdDia = 1, NombreDia = "Lunes", LabelFecha = FechaLunes};
            dgvMartes.Tag = new PropiedadesDgv { IdDia = 2, NombreDia="Martes" ,LabelFecha=FechaMartes};
            dgvMiercoles.Tag = new PropiedadesDgv { IdDia = 3, NombreDia="Miercoles", LabelFecha=FechaMiercoles};
            dgvJueves.Tag = new PropiedadesDgv { IdDia = 4, NombreDia="Jueves", LabelFecha=FechaJueves};
            dgvViernes.Tag = new PropiedadesDgv { IdDia =5, NombreDia= "Viernes",LabelFecha=FechaViernes };
            dgvSabado.Tag = new PropiedadesDgv { IdDia = 6, NombreDia= "Sabado",LabelFecha=FechaSabado };
            dgvDomingo.Tag = new PropiedadesDgv { IdDia =7,NombreDia="Domingo",LabelFecha=FechaDomingo};

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
                    // The DataTable column name.
                    // People.Property matching the DT column.
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
                    
                    pivote.Columns[4].DisplayIndex = 4;
                    pivote.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 6);
                    pivote.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    pivote.Enabled = false;
                    pivote.Columns[1].Width = 110;
                    pivote.AllowUserToAddRows = false;
                    pivote.RowHeadersVisible = false;
                    pivote.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    pivote.Columns["PrecioCompra"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    pivote.Columns["GananciaTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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
        }
        private void btAgregarSemana_Click(object sender, EventArgs e)
        {
            DtpFecha.Value = DateTime.Now;
            MoverDatosSemanaActual(this);
            CongeladoPlatillo(this);
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
                    var fecha = DateTime.Parse((pivote.Tag as PropiedadesDgv)?.LabelFecha.Text, CultureInfo.CurrentCulture);
                    var result = DateTime.Compare(fecha, DateTime.Now);
                    if (cbDias.CheckBoxItems[Convert.ToInt32((view.Tag as PropiedadesDgv)?.IdDia)].Checked && result > 0)
                    {
                        pivote.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        pivote.Enabled = true;
                        pivote.EditMode = DataGridViewEditMode.EditOnEnter;
                        pivote.AllowUserToAddRows = true;
                        pivote.Columns.Remove("FechaElaboracion");
                        pivote.Columns.Add(congelado);
                        pivote.Columns[6].DisplayIndex = 6;
                        pivote.Columns[6].ReadOnly = true;
                        pivote.Columns["Congelado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                    else 
                    {
                        for (var x = 0; x == 7; x++)
                        {
                            pivote.Columns[x].ReadOnly = false;
                        }
                        pivote.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        pivote.Enabled = false;
                        pivote.AllowUserToAddRows = true;
                        pivote.Columns.Remove("FechaElaboracion");
                        pivote.Columns.Add(congelado);
                        pivote.Columns[6].DisplayIndex = 6;
                        pivote.Columns[6].ReadOnly = true;
                        pivote.Columns["Congelado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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
        private static void CongeladoPlatillo(Control parent)
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
                                var dd = Opcion.JsonaClaseGenerica<AutoCompletePlatillo>(y).Congelado;
                                pivote.Rows[i1].Cells["Congelado"].Value = dd;
 
                            });}}

                    foreach (DataGridViewRow row in pivote.Rows)
                    {
                        pivote.Rows[row.Index].Cells["Congelado"].Style.BackColor = Color.CadetBlue;
                    }
                }
                else
                {
                    CongeladoPlatillo(c);
                }
            }
        }
        #region FuncionesParaMoverRows
        private void dgvGenerico_MouseMove(object sender,MouseEventArgs e)
        {
            if((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                if (_dragBoxFromMouseDown == Rectangle.Empty || _dragBoxFromMouseDown.Contains(e.X, e.Y)) return;
                var dgv = (DataGridView)sender;
                var platillo =dgv.Rows[_rowIndexFromMouseDown].Cells["Platillo"].Value.ToString();
                MenuDia c =(this[(dgv.Tag as PropiedadesDgv)?.NombreDia] as BindingList<MenuDia>)?.SingleOrDefault(x => x.Platillo.ToString() == platillo);
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
                    dgv.Columns.Add(col2);
                    dgv.Columns.Add(col);
                    dgv.Columns.Add(congelado);
                    dgv.DataSource = (this[propertyName] as BindingList<MenuDia>);
                }
                dgv.Columns.Remove("FechaElaboracion");
                dgv.Columns[0].ReadOnly = true;
                dgv.Columns[4].ReadOnly = true;
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
           // var clientPoint = pivote.PointToClient(new Point(e.X, e.Y));
           // _rowIndexOfItemUnderMouseToDrop = pivote.HitTest(clientPoint.X, clientPoint.Y).RowIndex;
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
                pivote.Columns.Add(col2);
                pivote.Columns.Add(col);
                pivote.Columns.Add(congelado);
                pivote.DataSource = (this[(pivote.Tag as PropiedadesDgv)?.NombreDia] as BindingList<MenuDia>);
                pivote.Columns.Remove("FechaElaboracion");
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

            e.Control.KeyPress -= new KeyPressEventHandler(dgvGenerico_KeyPress);
            if (pivote.CurrentCell.ColumnIndex == 2 || pivote.CurrentCell.ColumnIndex==4 || pivote.CurrentCell.ColumnIndex==5)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(dgvGenerico_KeyPress);
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
                var dd = Opcion.JsonaListaGenerica<AutoCompletePlatillo>(y).Select(x => x.Platillo).ToArray();
                BeginInvoke((MethodInvoker)(() =>
                {
                    dataCollection.AddRange(dd);
                    autoText.AutoCompleteCustomSource = dataCollection;
                }));

            });
        }
        private void GuardarMenuSemanal(Control parent)
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
                        Opcion.EjecucionAsync(Data.MenuSemanal.SacarRecId, y =>
                        {
                            var recid = Opcion.JsonaListaGenerica<AutoCompletePlatillo>(y).Select(x => x.RecId).ToArray();
                            Opcion.EjecucionAsync(Data.MenuSemanal.SacarTipoId, z =>
                            {
                                var tipoid = Opcion.JsonaListaGenerica<AutoCompletePlatillo>(z).Select(x => x.TipoId).ToArray();
                                var i1 = i2;
                                var menu = new InsertarMenu
                                {
                                    RecId = recid[0],
                                    Fecha = (pivote.Tag as PropiedadesDgv)?.LabelFecha.Text,
                                    Cantidad = cantidadfinal,
                                    PrecioFinal = Convert.ToDouble(pivote.Rows[i1].Cells[4].Value.ToString()),
                                    TipoId = tipoid[0]
                                };
                                Opcion.EjecucionAsync(x => {
                               Data.MenuSemanal.InsertarMenus(x, menu);
                                }, resultado =>
                                {
                                   
                                });});});
                        DataGridView dgvnuevo = (DataGridView)sender;
                        
                    }
                    BeginInvoke((MethodInvoker)(() =>
                    {
                        pivote.DataSource = null;
                        pivote.Rows.Clear();
                        pivote.Columns.Clear();
                    }));
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
        }
<<<<<<< HEAD
        List<int> _array = new List<int>();
        private void BorrarFila_KeyDown(object sender, KeyEventArgs e)
        {
            var pivote = (DataGridView)sender;
            int liIndex;
            if ((e.KeyCode == Keys.Delete))
            {
                e.Handled = true;
                liIndex = ((DataGridView)(sender)).CurrentRow.Index;
                pivote.Rows.RemoveAt(liIndex);
=======
        private void dgvGenerico_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var pivote = (DataGridView)sender;
            if (!pivote.Rows[e.RowIndex].Cells[1].Selected & !pivote.Rows[e.RowIndex].Cells[1].Selected) return;
            if (pivote.Rows[e.RowIndex].Cells[0].Value != null)
            {
                pivote.Rows[e.RowIndex].Cells[1].ReadOnly = false;
>>>>>>> origin/master
            }
            else
            { 
                pivote.Rows[e.RowIndex].Cells[1].ReadOnly = true;
                MessageBox.Show(@"Seleccione el Tipo de Receta antes de insertar el Platillo", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (pivote.Rows[e.RowIndex].Cells[0].Selected)
            {
                pivote.Columns[1].Frozen = true;

            }
            else if (pivote.Rows[e.RowIndex].Cells[2].Selected)
            {
                pivote.Columns[1].Frozen = true;
                pivote.Columns[3].Frozen = true;
            }
            else if (pivote.Rows[e.RowIndex].Cells[3].Selected)
            {
                pivote.Columns[2].Frozen = true;
                pivote.Columns[4].Frozen = true;
            }
            else if (pivote.Rows[e.RowIndex].Cells[4].Selected)
            {
                pivote.Columns[3].Frozen = true;
                pivote.Columns[5].Frozen = true;
            }
            else if (pivote.Rows[e.RowIndex].Cells[5].Selected)
            {
                pivote.Columns[4].Frozen = true;
                pivote.Columns[6].Frozen = true;
            }
            else if (pivote.Rows[e.RowIndex].Cells[6].Selected)
            {
                pivote.Columns[5].Frozen = true;
                pivote.Columns[7].Frozen = true;
            }
            else
            {
                pivote.Columns[1].Frozen = false;
                pivote.Columns[2].Frozen = false;
                pivote.Columns[3].Frozen = false;
                pivote.Columns[4].Frozen = false;
                pivote.Columns[5].Frozen = false;
                pivote.Columns[6].Frozen = false;
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
            CongeladoPlatillo(this);
        }
        private void dgvGenerico_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            var pivote = (DataGridView)sender;
            var rowIndex = pivote.CurrentCell.RowIndex;
            var col = pivote.Columns[pivote.CurrentCell.ColumnIndex];
            if (!(col is DataGridViewComboBoxColumn)) return;
            pivote.CommitEdit(DataGridViewDataErrorContexts.Commit);
            pivote.Rows[rowIndex].Cells[1].Value = "";
            pivote.Rows[rowIndex].Cells[6].Value = 0;
        }
    }
}








