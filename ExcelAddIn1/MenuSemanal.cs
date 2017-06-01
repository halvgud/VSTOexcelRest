using System;
using System.Windows.Forms;
using Respuesta;

using Herramienta;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using PresentationControls;
using System.Drawing;
using System.Globalization;
using System.Net;


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
            public MenuDia Control { get; private set; }
            public DragDropInfo(MenuDia control)
            {
                Control = control;
            }
        }
        private List<TipoRecetas> _tiposrecetas;
        private List<MenuSemanal> _listasemanas;
        private static MenuSemanal _alreadyOpened;
        #endregion
        public MenuSemanal(Func<string[]> arreglo)
        {

            if (_alreadyOpened != null && !_alreadyOpened.IsDisposed)
            {
                _alreadyOpened.Focus();            // Bring the old one to top
                Shown += (s, e) => Close();  // and destroy the new one.
                return;
            }
            _alreadyOpened = this;
            InitializeComponent();
            var allowedTypes = new AutoCompleteStringCollection();
            allowedTypes.AddRange(arreglo());


         //LuRows[1].AutoCompleteCustomSource = allowedTypes;
         //   txtbuscarcongeladoeditar.AutoCompleteMode = AutoCompleteMode.Suggest;
         //   txtbuscarcongeladoeditar.AutoCompleteSource = AutoCompleteSource.CustomSource;
        
        _listasemanas = new List<MenuSemanal>();
            _tiposrecetas = new List<TipoRecetas>();
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
            public int IdReceta { get; set; }
            public string TipoReceta { get; set; }
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
        }
        public static DateTime FirstDayOfWeek(DateTime date)
        {
            DayOfWeek fdow = CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
            int offset = fdow - date.DayOfWeek;
            DateTime fdowDate = date.AddDays(offset);
            return fdowDate;
        }
        public static DateTime LastDayOfWeek(DateTime date)
        {
            DateTime ldowDate = FirstDayOfWeek(date).AddDays(6);
            return ldowDate;
        }
        private void InicializarDgv(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is DataGridView)
                {
                    var pivote = (DataGridView)c;
                    pivote.DataSource = null;
                    pivote.Rows.Clear();
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
                    pivote.Columns.Add(col);
                    var propiedadesDgv   = pivote.Tag as PropiedadesDgv;
                    if (propiedadesDgv != null)
                        pivote.DataSource = this[propiedadesDgv.NombreDia] as BindingList<MenuDia>;
                    for (var x = 0; x == 7; x++)
                    {
                        pivote.Columns[x].ReadOnly = true;
                    }

                    //if (pivote.ColumnCount == 1)
                    //{
                    //    pivote.Columns.Remove("TipoRecetaDGV");
                    //}
                    pivote.AllowUserToAddRows = false;
                    pivote.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    pivote.Enabled = false;
                  

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
            if (cbDias.CheckBoxItems[0].Checked)
            {
                dgvLunes.EditMode = DataGridViewEditMode.EditOnEnter;
                dgvMartes.EditMode = DataGridViewEditMode.EditOnEnter;
                dgvMiercoles.EditMode = DataGridViewEditMode.EditOnEnter;
                dgvJueves.EditMode = DataGridViewEditMode.EditOnEnter;
                dgvViernes.EditMode = DataGridViewEditMode.EditOnEnter;
                dgvSabado.EditMode = DataGridViewEditMode.EditOnEnter;
                dgvDomingo.EditMode = DataGridViewEditMode.EditOnEnter;
            }
        }
        private void MoverDatosSemanaActual(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                var view = c as DataGridView;
                if (view != null)
                {
                    var pivote = view;
                    DateTime fecha = DateTime.Parse((pivote.Tag as PropiedadesDgv)?.LabelFecha.Text, CultureInfo.CurrentCulture);
                    int result = DateTime.Compare(fecha, DateTime.Now);
                    if (cbDias.CheckBoxItems[Convert.ToInt32((view.Tag as PropiedadesDgv)?.IdDia)].Checked & result>0)
                    {
                        for (var x = 0; x == 7; x++)
                        {
                            pivote.Columns[x].ReadOnly = false;
                        }
                        pivote.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        pivote.Enabled = true;
                        pivote.EditMode = DataGridViewEditMode.EditOnEnter;
                        pivote.AllowUserToAddRows = true;

                    }
                    else if (cbDias.CheckBoxItems[Convert.ToInt32((view.Tag as PropiedadesDgv)?.IdDia)].Checked)
                    {
                        pivote.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        pivote.Enabled = true;
                        pivote.EditMode = DataGridViewEditMode.EditOnEnter;
                        pivote.AllowUserToAddRows = true;
        
                    }
                    else
                    {
                         pivote.DataSource = null;
                        pivote.Rows.Clear();
                    }
                }
                else
                {
                    MoverDatosSemanaActual(c);
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
                    // The DataTable column name.
                    // People.Property matching the DT column.
                    dgv.Columns.Add(col);
                    dgv.DataSource = (this[propertyName] as BindingList<MenuDia>);
                }
                dgv.Columns.Remove("FechaElaboracion");
                dgv.Columns[0].ReadOnly = true;
            }
        }
        private void dgvGenerico_MouseDown(object sender,MouseEventArgs e)
        {
            DataGridView pivote = (DataGridView)sender;
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
                pivote.Columns.Add(col);
                pivote.DataSource = (this[(pivote.Tag as PropiedadesDgv)?.NombreDia] as BindingList<MenuDia>);
               pivote.Columns.Remove("FechaElaboracion");
              //  DataGridViewComboBoxCell comboCell = (DataGridViewComboBoxCell)pivote.Rows[pivote.Rows.Count-1].Cells[0];
            }
        }
        private void dgvGenerico_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
        #endregion

        private void btGuardar_Click(object sender, EventArgs e)
        {

        }
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
            }
        }

        private void dgvLunes_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //if (dgvLunes.CurrentCell.ColumnIndex == 1)
            //{
            //    var prodCode = e.Control as List<MenuDia>;
            //    if (prodCode != null)
            //    {
            //        prodCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //        prodCode.AutoCompleteCustomSource = ClientListDropDown();
            //        prodCode.AutoCompleteSource = AutoCompleteSource.CustomSource;

            //    }
            //}
            //else
            //{
            //    TextBox prodCode = e.Control as TextBox;
            //    if (prodCode != null)
            //    {
            //        prodCode.AutoCompleteMode = AutoCompleteMode.None;

              }
            }
}

    
