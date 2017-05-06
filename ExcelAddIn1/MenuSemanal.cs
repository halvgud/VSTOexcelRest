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
using System.ComponentModel;



namespace ExcelAddIn1
{

    public partial class MenuSemanal : Form
    {
      
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
        private List<MenuDia> _dias;
        private List<MenuSemanal> _listasemanas;
        public MenuSemanal()
        {
            InitializeComponent();
            _listasemanas = new List<MenuSemanal>();
            _dias=new List<MenuDia>();
        }
        

        private void PopulateManualCombo()
        {
            cbDias.Items.Add("All");
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

        private void MenuSemanal_Load(object sender, EventArgs e)
        {
            PopulateManualCombo();
            //var i = Weekday(DateTime.Now, DayOfWeek.Monday);
            //DtpFecha.Format = DateTimePickerFormat.Custom;
         //DtpFecha.Value = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + 1);     
        }
        public static DateTime FirstDayOfWeek(DateTime date)
        {
            DayOfWeek fdow = CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
            int offset = fdow - date.DayOfWeek;
            DateTime fdowDate = date.AddDays(offset);
            return fdowDate;
        }
        List<MenuDia> Lunes;
        List<MenuDia> Martes;
        List<MenuDia> Miercoles;
        List<MenuDia> Jueves;
        List<MenuDia> Viernes;
        List<MenuDia> Sabado;
        List<MenuDia> Domingo;
        public static DateTime LastDayOfWeek(DateTime date)
        {
            DateTime ldowDate = FirstDayOfWeek(date).AddDays(6);
            return ldowDate;
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
                            dgvLunes.DataSource = Lunes;
                            dgvMartes.DataSource = Martes;
                            dgvMiercoles.DataSource = Miercoles;
                            dgvJueves.DataSource = Jueves;
                            dgvViernes.DataSource = Viernes;
                            dgvSabado.DataSource = Sabado;
                            dgvDomingo.DataSource = Domingo;
                    
                            for (var x = 0; x==7; x++)
                            {
                                dgvLunes.Columns[x].ReadOnly = true;
                                dgvLunes.Columns[x].DefaultCellStyle.BackColor = Color.Blue;
                                dgvMartes.Columns[x].ReadOnly = true;
                                dgvMartes.Columns[x].DefaultCellStyle.BackColor = Color.Blue;
                                dgvMiercoles.Columns[x].ReadOnly = true;
                                dgvMiercoles.Columns[x].DefaultCellStyle.BackColor = Color.Blue;
                                dgvJueves.Columns[x].ReadOnly = true;
                                dgvJueves.Columns[x].DefaultCellStyle.BackColor = Color.Beige;
                                dgvViernes.Columns[x].ReadOnly = true;
                                dgvViernes.Columns[x].DefaultCellStyle.BackColor = Color.Beige;
                                dgvSabado.Columns[x].ReadOnly = true;
                                dgvSabado.Columns[x].DefaultCellStyle.BackColor = Color.Beige;
                                dgvDomingo.Columns[x].ReadOnly = true;
                                dgvDomingo.Columns[x].DefaultCellStyle.BackColor = Color.Black;
                            }
                           
                            dgvLunes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                            dgvMartes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                            dgvMiercoles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                            dgvJueves.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                            dgvViernes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                            dgvSabado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                            dgvDomingo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                            dgvLunes.Enabled = false;
                            dgvMartes.Enabled = false;
                            dgvMiercoles.Enabled = false;
                            dgvJueves.Enabled = false;
                            dgvViernes.Enabled = false;
                            dgvSabado.Enabled = false;
                            dgvDomingo.Enabled = false;
                            break;
                        default:
                            MessageBox.Show(this, @"No se encontraron recetas con los parametros de busqueda ingresados");
                            break;
                    }
                }));
                }
            });
        }
        private void cbDias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDias.CheckBoxItems[0].Checked)
            {
                cbDias.CheckBoxItems[1].Checked = true;
                cbDias.CheckBoxItems[2].Checked = true;
                cbDias.CheckBoxItems[3].Checked = true;
                cbDias.CheckBoxItems[4].Checked = true;
                cbDias.CheckBoxItems[5].Checked = true;
                cbDias.CheckBoxItems[6].Checked = true;
                cbDias.CheckBoxItems[7].Checked = true;
            }
            else
            {
                cbDias.CheckBoxItems[1].Checked = false;
                cbDias.CheckBoxItems[2].Checked = false;
                cbDias.CheckBoxItems[3].Checked = false;
                cbDias.CheckBoxItems[4].Checked = false;
                cbDias.CheckBoxItems[5].Checked = false;
                cbDias.CheckBoxItems[6].Checked = false;
                cbDias.CheckBoxItems[7].Checked = false;  
            }
            return;
        }

        private void menudelddia(List<MenuDia> menu)
        {
            _dias.AddRange(menu);
            _dias = _dias.Select(g => new MenuDia
            {
                Tipo=g.Tipo,
                Platillo=g.Platillo,
                FechaElaboracion=g.FechaElaboracion,
                Cantidad=g.Cantidad,
                Unidad=g.Unidad,
                PrecioCompra=g.PrecioCompra,
                GananciaTotal=g.GananciaTotal
               

            }).ToList();
        }

        private void btAgregarSemana_Click(object sender, EventArgs e)
        {
            DtpFecha.Value = DateTime.Now;

            Opcion.EjecucionAsync(Data.Receta.Tipo.Lista, x =>
            {
                CargarComboBox(x, (DataGridViewComboBoxColumn)dgvLunes.Columns[0]);
                //CargarComboBox(x, (DataGridViewComboBoxColumn)dgvMartes.Columns[0]);
                CargarComboBox(x, (DataGridViewComboBoxColumn)dgvMiercoles.Columns[0]);
                //CargarComboBox(x, (DataGridViewComboBoxColumn)dgvJueves.Columns[0]);
               // CargarComboBox(x, (DataGridViewComboBoxColumn)dgvViernes.Columns[0]);
                CargarComboBox(x, (DataGridViewComboBoxColumn)dgvSabado.Columns[0]);
                CargarComboBox(x, (DataGridViewComboBoxColumn)dgvDomingo.Columns[0]);
            });

            //lunes
            if (cbDias.CheckBoxItems[1].Checked == true)
            {
                this.dgvLunes.Columns.Remove("FechaElaboracion");
                this.dgvLunes.Columns.Remove("Tipo");
                dgvLunes.Refresh();
                dgvLunes.EditMode = DataGridViewEditMode.EditOnKeystroke;
            }
            else
            {
                dgvLunes.DataSource = null;
                dgvLunes.Rows.Clear();
                //dgvJueves.Columns.Remove("TipoReceta");
                dgvLunes.Enabled = false;
            }

            //martes
            if (cbDias.CheckBoxItems[2].Checked == true)
            {
                this.dgvMartes.Columns.Remove("FechaElaboracion");
                this.dgvMartes.Columns.Remove("Tipo");
                dgvMartes.Refresh();
                dgvMartes.EditMode = DataGridViewEditMode.EditOnKeystroke;

            }
            else
            {
                dgvMartes.DataSource = null;
                dgvMartes.Rows.Clear();
                //dgvMartes.Columns.Remove("TipoReceta");
                dgvMartes.Enabled = false;
            }

            //miercoles
            if (cbDias.CheckBoxItems[3].Checked == true)
            {
                this.dgvMiercoles.Columns.Remove("FechaElaboracion");
                this.dgvMiercoles.Columns.Remove("Tipo");
                dgvMiercoles.Refresh();
                dgvMiercoles.EditMode = DataGridViewEditMode.EditOnKeystroke;
            }
            else
            {
                dgvMiercoles.DataSource = null;
                dgvMiercoles.Rows.Clear();
                //dgvMiercoles.Columns.Remove("TipoReceta");
                dgvMiercoles.Enabled = false;
            }

            //jueves
            if (cbDias.CheckBoxItems[3].Checked == true)
            {
                this.dgvJueves.Columns.Remove("FechaElaboracion");
                this.dgvJueves.Columns.Remove("Tipo");
                dgvJueves.Refresh();
                dgvJueves.EditMode = DataGridViewEditMode.EditOnKeystroke;
            }
            else
            {
                dgvJueves.DataSource = null;
                dgvJueves.Rows.Clear();
                //dgvJueves.Columns.Remove("TipoReceta");
                dgvJueves.Enabled = false;
            }

            // viernes
            if (cbDias.CheckBoxItems[4].Checked == true)
            {
                this.dgvViernes.Columns.Remove("FechaElaboracion");
                this.dgvViernes.Columns.Remove("Tipo");
                dgvViernes.Refresh();
                dgvViernes.EditMode = DataGridViewEditMode.EditOnKeystroke;
            }
            else
            {
             dgvViernes.DataSource = null;
                dgvViernes.Rows.Clear();
                //dgvViernes.Columns.Remove("TipoReceta");
                dgvViernes.Enabled = false;
            }

            // sabado
            if (cbDias.CheckBoxItems[5].Checked == true)
            {
                this.dgvSabado.Columns.Remove("FechaElaboracion");
                this.dgvSabado.Columns.Remove("Tipo");
                dgvSabado.Refresh();
                dgvSabado.EditMode = DataGridViewEditMode.EditOnKeystroke;
            }
            else
            {
                dgvSabado.DataSource = null;
                dgvSabado.Rows.Clear();
                //dgvSabado.Columns.Remove("TipoReceta");
                dgvSabado.Enabled = false;
            }

            //domingo
            if (cbDias.CheckBoxItems[6].Checked == true)
            {
                this.dgvDomingo.Columns.Remove("FechaElaboracion");
                this.dgvDomingo.Columns.Remove("Tipo");
                dgvDomingo.Refresh();
                dgvDomingo.EditMode = DataGridViewEditMode.EditOnKeystroke;
            }
            else
            {
                dgvDomingo.DataSource = null;
                dgvDomingo.Rows.Clear();
                //dgvDomingo.Columns.Remove("TipoReceta");
                dgvDomingo.Enabled = false;
            }

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
        private void dgvLunes_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvLunes.Columns.Count == 7)
            {
                //dgvLunes.Columns.Remove("Tipo");
                DataGridViewComboBoxColumn chkSelect = new DataGridViewComboBoxColumn();
                {
                    chkSelect.HeaderText = "TipoReceta";
                    chkSelect.Name = "chkSelect";
                    //chkSelect.Selected = false;
                    //aqui hay que poner un datasource falso... o sea creas una lista y lo igualas, con valores dummy que tiene
                    var listadgv = dgvLunes.DataSource as List<MenuSemanal>;
                }
                dgvLunes.Columns.Insert(0, chkSelect);
            }
          //dgvLunes.Rows[0].Cells["Select All"] = dgvLunes.Rows[0].Cells["Tipo"].Value;
        }
        private void dgvMiercoles_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvMiercoles.Columns.Count == 7)
            {
                DataGridViewColumn col = this.dgvMiercoles.Columns[0];
                DataGridViewComboBoxColumn chkSelect = new DataGridViewComboBoxColumn();
                {
                    //chkSelect.HeaderText = col.HeaderText;
                    //chkSelect.DropDownWidth = 160;
                    //chkSelect.Width = col.Width;
                    //chkSelect.DataSource = d;
                    //chkSelect.DisplayMember = "TipoReceta";
                    //chkSelect.ValueMember = "TipoReceta";
                    chkSelect.HeaderText = "TipoReceta";
                    chkSelect.Name = "chkSelect";
                    var listadgv = dgvMiercoles.DataSource as List<MenuSemanal>;
                    //this.dgvMiercoles.Columns.Remove(col);
                }
                dgvMiercoles.Columns.Insert(0, chkSelect);
            }
        }
        private void dgvMartes_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvMartes.Columns.Count == 7)
            {
                DataGridViewComboBoxColumn chkSelect = new DataGridViewComboBoxColumn();
                {
                    chkSelect.HeaderText = "TipoReceta";
                    chkSelect.Name = "chkSelect";
                    var listadgv = dgvMartes.DataSource as List<MenuSemanal>;
                }
                dgvMartes.Columns.Insert(0, chkSelect);
            }
        }
        private void dgvJueves_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvJueves.Columns.Count == 7)
            {
                DataGridViewComboBoxColumn chkSelect = new DataGridViewComboBoxColumn();
                {
                    chkSelect.HeaderText = "TipoReceta";
                    chkSelect.Name = "chkSelect";
                    var listadgv = dgvJueves.DataSource as List<MenuSemanal>;
                }
                dgvJueves.Columns.Insert(0, chkSelect);
            }

        }
        private void dgvViernes_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvViernes.Columns.Count == 7)
            {
                DataGridViewComboBoxColumn chkSelect = new DataGridViewComboBoxColumn();
                {
                    chkSelect.HeaderText = "TipoReceta";
                    chkSelect.Name = "chkSelect";
                    var listadgv = dgvViernes.DataSource as List<MenuSemanal>;
                }
                dgvViernes.Columns.Insert(0, chkSelect);
            }
        }
        private void dgvSabado_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvSabado.Columns.Count == 7)
            {
                DataGridViewComboBoxColumn chkSelect = new DataGridViewComboBoxColumn();
                {
                    chkSelect.HeaderText = "TipoReceta";
                    chkSelect.Name = "chkSelect";
                    var listadgv = dgvSabado.DataSource as List<MenuSemanal>;
                }
                dgvSabado.Columns.Insert(0, chkSelect);
            }
        }
        private void dgvDomingo_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvDomingo.Columns.Count == 7)
            {
                DataGridViewComboBoxColumn chkSelect = new DataGridViewComboBoxColumn();
                {
                    chkSelect.HeaderText = "TipoReceta";
                    chkSelect.Name = "chkSelect";
                    var listadgv = dgvDomingo.DataSource as List<MenuSemanal>;
                }
                dgvDomingo.Columns.Insert(0, chkSelect);
            }
         }

        //Drop and Drag datagridview rows
        private Rectangle _dragBoxFromMouseDown;
        private int _rowIndexFromMouseDown;
        private int _rowIndexOfItemUnderMouseToDrop;

        #region Lunes
        private void dgvLunes_MouseDown(object sender, MouseEventArgs e)
        {
            // Get the index of the item the mouse is below.
            _rowIndexFromMouseDown = dgvLunes.HitTest(e.X, e.Y).RowIndex;
            if (_rowIndexFromMouseDown != -1)
            {
                // Remember the point where the mouse down occurred.
                // The DragSize indicates the size that the mouse can move
                // before a drag event should be started.               
                Size dragSize = SystemInformation.DragSize;
                _dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2),
                    e.Y - (dragSize.Height / 2)),
                    dragSize);
            }
            else
                _dragBoxFromMouseDown = Rectangle.Empty;
        }
        private void dgvLunes_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                if (_dragBoxFromMouseDown != Rectangle.Empty && !_dragBoxFromMouseDown.Contains(e.X, e.Y))
                {
                    var platillo = dgvLunes.Rows[_rowIndexFromMouseDown].Cells["Platillo"].Value.ToString();
                    MenuDia c = Lunes.SingleOrDefault(x => x.Platillo == platillo);
                    DoDragDrop(new DragDropInfo(c), DragDropEffects.All);
                    Lunes.Remove(c);
                    dgvLunes.DataSource = null;
                    dgvLunes.DataSource = Lunes;
                }
            }
        }
        private void dgvLunes_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        // este es el evento final
        private void dgvLunes_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                Point clientPoint = dgvLunes.PointToClient(new Point(e.X, e.Y));
                _rowIndexOfItemUnderMouseToDrop = dgvLunes.HitTest(clientPoint.X, clientPoint.Y).RowIndex;
                if (e.Effect == DragDropEffects.Move)
                {
                    var c = e.Data.GetData(typeof(DragDropInfo)) as DragDropInfo;
                    Lunes.Add(c.Control);
                    dgvLunes.DataSource = null;
                    dgvLunes.DataSource=Lunes;
                }
            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
            }
        }
        #endregion

        #region Martes
        private void dgvMartes_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                if (_dragBoxFromMouseDown != Rectangle.Empty && !_dragBoxFromMouseDown.Contains(e.X, e.Y))
                {
                    var platillo = dgvMartes.Rows[_rowIndexFromMouseDown].Cells["Platillo"].Value.ToString();
                    MenuDia c = Martes.SingleOrDefault(x => x.Platillo == platillo);
                    DoDragDrop(new DragDropInfo(c), DragDropEffects.All);
                    Martes.Remove(c);
                    dgvMartes.DataSource = null;
                    dgvMartes.DataSource = Lunes;
                }
            }
        }

        private void dgvMartes_MouseDown(object sender, MouseEventArgs e)
        {
          
            _rowIndexFromMouseDown = dgvMartes.HitTest(e.X, e.Y).RowIndex;
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

        private void dgvMartes_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void dgvMartes_DragDrop(object sender, DragEventArgs e)
        {
            Point clientPoint = dgvMartes.PointToClient(new Point(e.X, e.Y));
            _rowIndexOfItemUnderMouseToDrop = dgvMartes.HitTest(clientPoint.X, clientPoint.Y).RowIndex;
            if (e.Effect == DragDropEffects.Move)
            {
                var c = e.Data.GetData(typeof(DragDropInfo)) as DragDropInfo;
                Martes.Add(c.Control);
                dgvMartes.DataSource = null;
                dgvMartes.DataSource = Martes;
            }
        }
        #endregion

        #region Miercoles
        private void dgvMiercoles_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                if (_dragBoxFromMouseDown != Rectangle.Empty && !_dragBoxFromMouseDown.Contains(e.X, e.Y))
                {
                    var platillo = dgvMiercoles.Rows[_rowIndexFromMouseDown].Cells["Platillo"].Value.ToString();
                    MenuDia c = Miercoles.SingleOrDefault(x => x.Platillo.ToString() == platillo);
                    DoDragDrop(new DragDropInfo(c), DragDropEffects.All);
                   Miercoles.Remove(c);
                    dgvMiercoles.DataSource = null;
                    dgvMiercoles.DataSource = Miercoles;
                }
            }
        }

        private void dgvMiercoles_MouseDown(object sender, MouseEventArgs e)
        {
            _rowIndexFromMouseDown = dgvMiercoles.HitTest(e.X, e.Y).RowIndex;
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

        private void dgvMiercoles_DragDrop(object sender, DragEventArgs e)
        {
            Point clientPoint = dgvMiercoles.PointToClient(new Point(e.X, e.Y));
            _rowIndexOfItemUnderMouseToDrop = dgvMiercoles.HitTest(clientPoint.X, clientPoint.Y).RowIndex;
            if (e.Effect == DragDropEffects.Move)
            {
                var c = e.Data.GetData(typeof(DragDropInfo)) as DragDropInfo;
                Miercoles.Add(c.Control);
                dgvMiercoles.DataSource = null;
                dgvMiercoles.DataSource = Miercoles;
            }
        }

        private void dgvMiercoles_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
        #endregion

        #region Jueves
        private void dgvJueves_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                if (_dragBoxFromMouseDown != Rectangle.Empty && !_dragBoxFromMouseDown.Contains(e.X, e.Y))
                {
                    var platillo = dgvJueves.Rows[_rowIndexFromMouseDown].Cells["Platillo"].Value.ToString();
                    MenuDia c = Jueves.SingleOrDefault(x => x.Platillo.ToString() == platillo);
                    DoDragDrop(new DragDropInfo(c), DragDropEffects.All);
                    Miercoles.Remove(c);
                    dgvJueves.DataSource = null;
                    dgvJueves.DataSource = Jueves;
                }
            }
        }

        private void dgvJueves_MouseDown(object sender, MouseEventArgs e)
        {
            _rowIndexFromMouseDown = dgvJueves.HitTest(e.X, e.Y).RowIndex;
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

        private void dgvJueves_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void dgvJueves_DragDrop(object sender, DragEventArgs e)
        {
            Point clientPoint = dgvJueves.PointToClient(new Point(e.X, e.Y));
            _rowIndexOfItemUnderMouseToDrop = dgvJueves.HitTest(clientPoint.X, clientPoint.Y).RowIndex;
            if (e.Effect == DragDropEffects.Move)
            {
                var c = e.Data.GetData(typeof(DragDropInfo)) as DragDropInfo;
                Jueves.Add(c.Control);
                dgvJueves.DataSource = null;
                dgvJueves.DataSource = Jueves;
            }
        }
        #endregion

        #region Viernes
        private void dgvViernes_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                if (_dragBoxFromMouseDown != Rectangle.Empty && !_dragBoxFromMouseDown.Contains(e.X, e.Y))
                {
                    var platillo = dgvViernes.Rows[_rowIndexFromMouseDown].Cells["Platillo"].Value.ToString();
                    MenuDia c = Viernes.SingleOrDefault(x => x.Platillo.ToString() == platillo);
                    DoDragDrop(new DragDropInfo(c), DragDropEffects.All);
                    Viernes.Remove(c);
                    dgvViernes.DataSource = null;
                    dgvViernes.DataSource = Viernes;
                }
            }
        }

        private void dgvViernes_MouseDown(object sender, MouseEventArgs e)
        {
            _rowIndexFromMouseDown = dgvViernes.HitTest(e.X, e.Y).RowIndex;
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

        private void dgvViernes_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void dgvViernes_DragDrop(object sender, DragEventArgs e)
        {
            Point clientPoint = dgvViernes.PointToClient(new Point(e.X, e.Y));
            _rowIndexOfItemUnderMouseToDrop = dgvViernes.HitTest(clientPoint.X, clientPoint.Y).RowIndex;
            if (e.Effect == DragDropEffects.Move)
            {
                var c = e.Data.GetData(typeof(DragDropInfo)) as DragDropInfo;
                Viernes.Add(c.Control);
                dgvViernes.DataSource = null;
                dgvViernes.DataSource = Viernes;
            }
        }
        #endregion

        #region Sabado
        private void dgvSabado_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                if (_dragBoxFromMouseDown != Rectangle.Empty && !_dragBoxFromMouseDown.Contains(e.X, e.Y))
                {
                    var platillo = dgvSabado.Rows[_rowIndexFromMouseDown].Cells["Platillo"].Value.ToString();
                    MenuDia c = Sabado.SingleOrDefault(x => x.Platillo.ToString() == platillo);
                    DoDragDrop(new DragDropInfo(c), DragDropEffects.All);
                    Sabado.Remove(c);
                    dgvSabado.DataSource = null;
                    dgvSabado.DataSource = Sabado;
                }
            }

        }

        private void dgvSabado_MouseDown(object sender, MouseEventArgs e)
        {
            _rowIndexFromMouseDown = dgvSabado.HitTest(e.X, e.Y).RowIndex;
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

        private void dgvSabado_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void dgvSabado_DragDrop(object sender, DragEventArgs e)
        {
            Point clientPoint = dgvSabado.PointToClient(new Point(e.X, e.Y));
            _rowIndexOfItemUnderMouseToDrop = dgvSabado.HitTest(clientPoint.X, clientPoint.Y).RowIndex;
            if (e.Effect == DragDropEffects.Move)
            {
                var c = e.Data.GetData(typeof(DragDropInfo)) as DragDropInfo;
                Sabado.Add(c.Control);
                dgvSabado.DataSource = null;
                dgvSabado.DataSource = Sabado;
            }
        }
        #endregion

        #region Domingo
        private void dgvDomingo_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                if (_dragBoxFromMouseDown != Rectangle.Empty && !_dragBoxFromMouseDown.Contains(e.X, e.Y))
                {
                    var platillo = dgvDomingo.Rows[_rowIndexFromMouseDown].Cells["Platillo"].Value.ToString();
                    MenuDia c = Domingo.SingleOrDefault(x => x.Platillo.ToString() == platillo);
                    DoDragDrop(new DragDropInfo(c), DragDropEffects.All);
                    Domingo.Remove(c);
                    dgvDomingo.DataSource = null;
                    dgvDomingo.DataSource = Domingo;
                }
            }
        }

        private void dgvDomingo_MouseDown(object sender, MouseEventArgs e)
        {
            _rowIndexFromMouseDown = dgvDomingo.HitTest(e.X, e.Y).RowIndex;
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

        private void dgvDomingo_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void dgvDomingo_DragDrop(object sender, DragEventArgs e)
        {
            Point clientPoint = dgvDomingo.PointToClient(new Point(e.X, e.Y));
            _rowIndexOfItemUnderMouseToDrop = dgvDomingo.HitTest(clientPoint.X, clientPoint.Y).RowIndex;
            if (e.Effect == DragDropEffects.Move)
            {
                var c = e.Data.GetData(typeof(DragDropInfo)) as DragDropInfo;
                Domingo.Add(c.Control);
                dgvDomingo.DataSource = null;
                dgvDomingo.DataSource = Domingo;
            }
        }
        #endregion
    }
}
    
