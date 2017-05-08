using System;
using System.Windows.Forms;
using Respuesta;
using RestSharp;
using Herramienta;
using System.Collections.Generic;
using System.Linq;
using PresentationControls;
using System.Drawing;
using System.Globalization;
using System.Net;
using System.Reflection;
using System.Collections;

namespace ExcelAddIn1
{
    public partial class MenuSemanal : Form
    {
        #region Variables
        //Drop and Drag datagridview rows
        private Rectangle _dragBoxFromMouseDown;
        private int _rowIndexFromMouseDown;
        private int _rowIndexOfItemUnderMouseToDrop;

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
                this.Control = control;
            }
        }
        private List<MenuSemanal> _listasemanas;
        #endregion
        public MenuSemanal()
        {
            InitializeComponent();
            _listasemanas = new List<MenuSemanal>();
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

        public void CargarComboBox(IRestResponse json, DataGridViewComboBoxColumn tipoReceta)
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
        public class PropiedadesDGV
        {
            public int idDia { get; set; }
            public string NombreDia { get; set; }
        }

        private void MenuSemanal_Load(object sender, EventArgs e)
        {
            PopulateManualCombo();
            dgvLunes.Tag = new PropiedadesDGV{idDia=1, NombreDia="Lunes"};
            dgvMartes.Tag = new PropiedadesDGV { idDia = 2, NombreDia="Martes" };
            dgvMiercoles.Tag = new PropiedadesDGV { idDia = 3, NombreDia="Miercoles" };
            dgvJueves.Tag = new PropiedadesDGV { idDia = 4, NombreDia="Jueves" };
            dgvViernes.Tag = new PropiedadesDGV { idDia =5, NombreDia= "Viernes" };
            dgvSabado.Tag = new PropiedadesDGV { idDia = 6, NombreDia= "Sabado" };
            dgvDomingo.Tag = new PropiedadesDGV { idDia =7,NombreDia="Domingo"};
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
        private void InicializarDGV(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is DataGridView)
                {
                    DataGridView pivote = new DataGridView();
                    pivote = (DataGridView)c;
                    pivote.DataSource = this[(pivote.Tag as PropiedadesDGV).NombreDia] as List<MenuDia>;
                    for (var x = 0; x == 7; x++)
                    {
                        pivote.Columns[x].ReadOnly = true;
                    }
                    pivote.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    pivote.Enabled = false;
                }
                else
                {
                    InicializarDGV(c);
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
                            InicializarDGV(this);                       
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
            for (int x = 1; x <= 7; x++)
            {
                cbDias.CheckBoxItems[x].Checked = cbDias.CheckBoxItems[0].Checked;
            }
            return;
        }
        private void MoverDatosASemanaActual(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is DataGridView)
                {
                    DataGridView pivote = new DataGridView();
                    pivote = (DataGridView)c;
                    if (cbDias.CheckBoxItems[Convert.ToInt32((c.Tag as PropiedadesDGV).idDia)].Checked == true)
                    {
                        pivote.Columns.Remove("FechaElaboracion");
                        pivote.Columns.Remove("Tipo");
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
                    MoverDatosASemanaActual(c);
                }
            }
        }
        private void btAgregarSemana_Click(object sender, EventArgs e)
        {
            DtpFecha.Value = DateTime.Now;

            Opcion.EjecucionAsync(Data.Receta.Tipo.Lista, x =>
            {
                //CargarComboBox(x, (DataGridViewComboBoxColumn)dgvLunes.Columns[0]);
                //CargarComboBox(x, (DataGridViewComboBoxColumn)dgvMartes.Columns[0]);
                //CargarComboBox(x, (DataGridViewComboBoxColumn)dgvMiercoles.Columns[0]);
                //CargarComboBox(x, (DataGridViewComboBoxColumn)dgvJueves.Columns[0]);
                //CargarComboBox(x, (DataGridViewComboBoxColumn)dgvViernes.Columns[0]);
                //CargarComboBox(x, (DataGridViewComboBoxColumn)dgvSabado.Columns[0]);
                //CargarComboBox(x, (DataGridViewComboBoxColumn)dgvDomingo.Columns[0]);
            });

            MoverDatosASemanaActual(this);

            if (cbDias.CheckBoxItems[0].Checked==true)
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
        //creacion de la la columna combobox
       
        private void dgvDomingo_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //if (dgvDomingo.Columns.Count == 7)
            //{
            //    DataGridViewComboBoxColumn chkSelect = new DataGridViewComboBoxColumn();
            //    {
            //        chkSelect.HeaderText = "TipoReceta";
            //        chkSelect.Name = "chkSelect";
            //        var listadgv = dgvDomingo.DataSource as List<MenuSemanal>;
            //    }
            //    dgvDomingo.Columns.Insert(0, chkSelect);
            //}
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
                    MenuDia c =(this[(dgv.Tag as PropiedadesDGV).NombreDia] as List<MenuDia>).SingleOrDefault(x => x.Platillo.ToString() == platillo);
                    DoDragDrop(new DragDropInfo(c), DragDropEffects.All);
                    (this[(dgv.Tag as PropiedadesDGV).NombreDia] as List<MenuDia>).Remove(c);
                    dgv.DataSource = null;
                    dgv.DataSource = (this[(dgv.Tag as PropiedadesDGV).NombreDia] as List<MenuDia>);
                }
            }
        }//ddcdcdc
        private void dgvGenerico_MouseDown(object sender,MouseEventArgs e)
        {
            DataGridView pivote = (DataGridView)sender;
            _rowIndexFromMouseDown = pivote.HitTest(e.X, e.Y).RowIndex;
            if (_rowIndexFromMouseDown != -1)
            {
                Size dragSize = SystemInformation.DragSize;
                _dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2),
                    e.Y - (dragSize.Height / 2)),
                    dragSize);
            }
            else
                _dragBoxFromMouseDown = Rectangle.Empty;
        }
        private void dgvGenerico_DragDrop(object sender, DragEventArgs e)
        {
            DataGridView pivote = (DataGridView)sender;
            Point clientPoint = pivote.PointToClient(new Point(e.X, e.Y));
            _rowIndexOfItemUnderMouseToDrop = pivote.HitTest(clientPoint.X, clientPoint.Y).RowIndex;
            if (e.Effect == DragDropEffects.Move)
            {
                var c = e.Data.GetData(typeof(DragDropInfo)) as DragDropInfo;
                (this[(pivote.Tag as PropiedadesDGV).NombreDia] as List<MenuDia>).Add(c.Control);
                pivote.DataSource = null;
                pivote.DataSource = c;
            }
        }
        private void dgvGenerico_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
        #endregion
    }
}
    
