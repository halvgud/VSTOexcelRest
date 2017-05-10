using System;
using System.Windows.Forms;
using Respuesta;

using Herramienta;
using System.Collections.Generic;
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
        public List<MenuDia> Lunes { get; set; }
        public List<MenuDia> Martes { get; set; }
        public List<MenuDia> Miercoles { get; set; }
        public List<MenuDia> Jueves { get; set; }
        public static List<MenuDia> Viernes { get; set; }
        public List<MenuDia> Sabado { get; set; }
        public List<MenuDia> Domingo { get; set; }
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
       // private List<MenuSemanal> _listasemanas;
        #endregion
        public MenuSemanal()
        {
            InitializeComponent();
           // _listasemanas = new List<MenuSemanal>();
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

        //public void CargarComboBox(IRestResponse json, DataGridViewComboBoxColumn tipoReceta)
        //{
        //    BeginInvoke((MethodInvoker)(() =>
        //    {
        //        var bindingSource1 = new BindingSource
        //        {
        //            DataSource = Opcion.JsonaListaGenerica<CbGenerico>(json)
        //        };
        //        tipoReceta.DataSource = bindingSource1;
        //        tipoReceta.DisplayMember = "Nombre";
        //        tipoReceta.ValueMember = "id";
        //        tipoReceta.Tag = json;
        //    }));
        //}

   
        public class PropiedadesDgv
        {
            public int IdDia { get; set; }
            public string NombreDia { get; set; }
        }

        public class TipoRecetas
        {
            public int IdReceta { get; set; }
            public string TipoReceta { get; set; }
        }

        private void MenuSemanal_Load(object sender, EventArgs e)
        {
            PopulateManualCombo();
            dgvLunes.Tag = new PropiedadesDgv{IdDia=1, NombreDia="Lunes"};
            dgvMartes.Tag = new PropiedadesDgv { IdDia = 2, NombreDia="Martes" };
            dgvMiercoles.Tag = new PropiedadesDgv { IdDia = 3, NombreDia="Miercoles" };
            dgvJueves.Tag = new PropiedadesDgv { IdDia = 4, NombreDia="Jueves" };
            dgvViernes.Tag = new PropiedadesDgv { IdDia =5, NombreDia= "Viernes" };
            dgvSabado.Tag = new PropiedadesDgv { IdDia = 6, NombreDia= "Sabado" };
            dgvDomingo.Tag = new PropiedadesDgv { IdDia =7,NombreDia="Domingo"};

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
                    var col = new DataGridViewComboBoxColumn
                    {
                        Name = "TipoRecetaDGV",
                        DataPropertyName = "TipoRecetaDGV",
                        HeaderText = @"TipoReceta",
                        DataSource = _tiposrecetas,
                        DisplayMember = "TipoReceta",
                        ValueMember = "TipoReceta"
                    };

                    // The DataTable column name.
                    // People.Property matching the DT column.
                    pivote.Columns.Add(col);
                    pivote.DataSource = this[(pivote.Tag as PropiedadesDgv)?.NombreDia] as List<MenuDia>;
                    for (var x = 0; x == 7; x++)
                    {
                        pivote.Columns[x].ReadOnly = true;
                    }
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
            string diainicio = FirstDayOfWeek(DtpFecha.Value).ToShortDateString();
            string diafinal = LastDayOfWeek(DtpFecha.Value).ToShortDateString();
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
                            Lunes = Opcion.JsonaClaseGenerica2<Respuesta.MenuSemanal>(jsonResult).Lunes;
                            Martes = Opcion.JsonaClaseGenerica2<Respuesta.MenuSemanal>(jsonResult).Martes;
                            Miercoles = Opcion.JsonaClaseGenerica2<Respuesta.MenuSemanal>(jsonResult).Miercoles;
                            Jueves = Opcion.JsonaClaseGenerica2<Respuesta.MenuSemanal>(jsonResult).Jueves;
                            Viernes = Opcion.JsonaClaseGenerica2<Respuesta.MenuSemanal>(jsonResult).Viernes;
                            Sabado = Opcion.JsonaClaseGenerica2<Respuesta.MenuSemanal>(jsonResult).Sabado;
                            Domingo = Opcion.JsonaClaseGenerica2<Respuesta.MenuSemanal>(jsonResult).Domingo;
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
        private void MoverDatosSemanaActual(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                var view = c as DataGridView;
                if (view != null)
                {
                    var pivote = view;
                    if (cbDias.CheckBoxItems[Convert.ToInt32((view.Tag as PropiedadesDgv)?.IdDia)].Checked)
                    {
                        pivote.Columns.Remove("FechaElaboracion");
                        pivote.Enabled = true;
                        pivote.EditMode = DataGridViewEditMode.EditOnKeystroke;
                    }
                    else
                    {
                        pivote.DataSource = null;
                        pivote.Rows.Clear();
                        pivote.Enabled = false;
                    }
                }
                else
                {
                    MoverDatosSemanaActual(c);
                }
            }
        }
        private void btAgregarSemana_Click(object sender, EventArgs e)
        {
            DtpFecha.Value = DateTime.Now;
            ValidarFecha(this);

            MoverDatosSemanaActual(this);

            if (cbDias.CheckBoxItems[0].Checked)
            {
                dgvLunes.EditMode = DataGridViewEditMode.EditOnKeystroke;
                dgvMartes.EditMode = DataGridViewEditMode.EditOnKeystroke;
                dgvMiercoles.EditMode = DataGridViewEditMode.EditOnKeystroke;
                dgvJueves.EditMode = DataGridViewEditMode.EditOnKeystroke;
                dgvViernes.EditMode = DataGridViewEditMode.EditOnKeystroke;
                dgvSabado.EditMode = DataGridViewEditMode.EditOnKeystroke;
                dgvDomingo.EditMode = DataGridViewEditMode.EditOnKeystroke;
            }
            }

  
        private void ValidarFecha(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                var view = c as DataGridView;
                if (view == null) continue;
                var pivote = view;
                pivote.DataSource = this[(pivote.Tag as PropiedadesDgv)?.NombreDia] as List<MenuDia>;

                if (DtpFecha.Value.Day < DateTime.Now.Day )
                {
                    for (var x = 0; x == 7; x++)
                    {
                        pivote.Columns[x].ReadOnly = true;
                    }
                    pivote.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    pivote.Enabled = false;
                }
                else
                {
                    ValidarFecha(c);
                }
            }
        }

        #region FuncionesParaMoverRows
        private void dgvGenerico_MouseMove(object sender,MouseEventArgs e)
        {
            if((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                if (_dragBoxFromMouseDown != Rectangle.Empty && !_dragBoxFromMouseDown.Contains(e.X, e.Y))
                {
                    var dgv = (DataGridView)sender;
                    var platillo =dgv.Rows[_rowIndexFromMouseDown].Cells["Platillo"].Value.ToString();
                    MenuDia c =(this[(dgv.Tag as PropiedadesDgv)?.NombreDia] as List<MenuDia>)?.SingleOrDefault(x => x.Platillo.ToString() == platillo);
                    DoDragDrop(new DragDropInfo(c), DragDropEffects.All);
                    (this[(dgv.Tag as PropiedadesDgv)?.NombreDia] as List<MenuDia>)?.Remove(c);
                    dgv.DataSource = null;
                    var col = new DataGridViewComboBoxColumn
                    {
                        Name = "TipoRecetaDGV",
                        DataPropertyName = "TipoRecetaDGV",
                        HeaderText = @"TipoReceta",
                        DataSource = _tiposrecetas,
                        DisplayMember = "TipoReceta",
                        ValueMember = "TipoReceta"
                    };
                    // The DataTable column name.
                    // People.Property matching the DT column.
                    dgv.Columns.Add(col);
                    dgv.DataSource = (this[(dgv.Tag as PropiedadesDgv)?.NombreDia] as List<MenuDia>);
                    dgv.Columns.Remove("FechaElaboracion");
                    dgv.Columns[0].ReadOnly = true;

                }
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
                (this[(pivote.Tag as PropiedadesDgv)?.NombreDia] as List<MenuDia>)?.Add(c?.Control);
                pivote.DataSource = null;//esto es para el row
                var col = new DataGridViewComboBoxColumn
                {
                    Name = "TipoRecetaDGV",
                    DataPropertyName = "TipoRecetaDGV",
                    HeaderText = @"TipoReceta",
                    DataSource = _tiposrecetas,
                    DisplayMember = "TipoReceta",
                    ValueMember = "TipoReceta"
                };
                pivote.Columns.Add(col);
                pivote.DataSource = (this[(pivote.Tag as PropiedadesDgv)?.NombreDia] as List<MenuDia>);
               pivote.Columns.Remove("FechaElaboracion");
              //  DataGridViewComboBoxCell comboCell = (DataGridViewComboBoxCell)pivote.Rows[pivote.Rows.Count-1].Cells[0];
            }
        }
        private void dgvGenerico_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
        #endregion
    }
}
    
