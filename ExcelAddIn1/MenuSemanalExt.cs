using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Herramienta;
using Herramienta.Config;
using PresentationControls;
using Respuesta;
using RestSharp;

namespace ExcelAddIn1
{
    partial class MenuSemanal
    {
        public object this[string propertyName]
        {
            get { return typeof(MenuSemanal).GetProperty(propertyName).GetValue(this, null); }
            set { typeof(MenuSemanal).GetProperty(propertyName).SetValue(this, value, null); }
        }
        List<T> GetControlByName<T>(
    Control controlToSearch, string nameOfControlsToFind, bool searchDescendants)
    where T : class
        {
            List<T> result;
            result = new List<T>();
            foreach (Control c in controlToSearch.Controls)
            {
                if (c.Name == nameOfControlsToFind && c.GetType() == typeof(T))
                {
                    result.Add(c as T);
                }
                if (searchDescendants)
                {
                    result.AddRange(GetControlByName<T>(c, nameOfControlsToFind, true));
                }
            }
            return result;
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
        private List<IngredientesReceta> _listaArticuloBasica2;
        public List<Reporte.RespuestaCocina.TablaPreciosNuevos> ListaActualizarListr;
        public BindingList<Reporte.RespuestaCocina.TablaPreciosNuevos.MostrarTablaPreciosNuevos> ListaBindingAct;
        private List<PlatilloReceta> _listaPlatilloLunes;
        private List<PlatilloReceta> _listaPlatilloMartes;
        private List<PlatilloReceta> _listaPlatilloMiercoles;
        private List<PlatilloReceta> _listaPlatilloJueves;
        private List<PlatilloReceta> _listaPlatilloViernes;
        private List<PlatilloReceta> _listaPlatilloSabado;
        private List<PlatilloReceta> _listaPlatilloDomingo;
        private List<PlatilloReceta> _listaPlatilloArreglo;
        private List<PlatilloReceta> _listaPlatilloTodos;
        private readonly List<TipoRecetas> _tiposrecetas;
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
            public DataGridView DGV { get; set; }
        }
        public class TipoRecetas
        {
            public int IdReceta { get; set; }
            public string TipoReceta { get; set; }
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
        public IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
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
        private void dgvGenerico_MouseDown(object sender, MouseEventArgs e)
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
        private void dgvGenerico_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
        private void Generico_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var pivote = (DataGridView)sender;
            var rowIndex = pivote.CurrentCell.RowIndex;
            var valor = Convert.ToString(pivote.Rows[rowIndex].Cells[0].Value);
            var column = pivote.CurrentCell.ColumnIndex;
            var headerText = pivote.Columns[column].HeaderText;

            e.Control.KeyPress -= (dgvGenerico_KeyPress);
            if (pivote.CurrentCell.ColumnIndex == 2 || pivote.CurrentCell.ColumnIndex == 3 || pivote.CurrentCell.ColumnIndex == 5)
            {
                var tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += (dgvGenerico_KeyPress);
                }
            }
            //if (!headerText.Equals("Platillo")) return;
            //var autoText = e.Control as TextBox;
            //if (autoText == null) return;
            //autoText.AutoCompleteMode = AutoCompleteMode.Suggest;
            //autoText.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //Cocina.PlatillosMenus.Nombre = valor;
            //var dataCollection = new AutoCompleteStringCollection();
            //Opcion.EjecucionAsync(Data.MenuSemanal.ListaPlatilloRecetas, y =>
            //{
            //    var dd = Opcion.JsonaListaGenerica<PlatilloReceta>(y).Select(x => x.Platillo).ToArray();
            //    BeginInvoke((MethodInvoker)(() =>
            //    {
            //        dataCollection.AddRange(dd);
            //        autoText.AutoCompleteCustomSource = dataCollection;
            //    }));

            //});
        }
        public int Menidd;
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
        public void CargarComboBox(IRestResponse json, ComboBox tipoReceta)
        {
            BeginInvoke((MethodInvoker)(() =>
            {
                var bindingSource1 = new BindingSource
                {
                    DataSource = Opcion.JsonaListaGenerica<CbGenerico>(json)
                };
                tipoReceta.DataSource = bindingSource1;
                tipoReceta.DisplayMember = "Nombre";
                tipoReceta.ValueMember = "Id";
                tipoReceta.Tag = json;
            }));
        }

        private void montototal(Control parent1)
        {
            var view = parent1 as DataGridView;
            var pivote = view;
            double sum = 0;
            for (var x = 0; x < pivote.RowCount - 1; x++)
            {
                var ss = Convert.ToDouble(pivote.Rows[x].Cells["Venta"].Value);
                sum += (ss);
            }
            if (pivote.Name == "dgvLunes")
            {
                tbMontoLunes.Text = @"$" + sum.ToString(CultureInfo.InvariantCulture) + @".00";
            }
            if (pivote.Name == "dgvMartes")
            {
                tbMontoMartes.Text = @"$" + sum.ToString(CultureInfo.InvariantCulture) + @".00";
            }
            if (pivote.Name == "dgvMiercoles")
            {
                tbMontoMiercoles.Text = @"$" + sum.ToString(CultureInfo.InvariantCulture) + @".00";
            }
            if (pivote.Name == "dgvJueves")
            {
                tbMontoJueves.Text = @"$" + sum.ToString(CultureInfo.InvariantCulture) + @".00";
            }
            if (pivote.Name == "dgvViernes")
            {
                tbMontoViernes.Text = @"$" + sum.ToString(CultureInfo.InvariantCulture) + @".00";
            }
            if (pivote.Name == "dgvSabado")
            {
                tbMontoSabado.Text = @"$" + sum.ToString(CultureInfo.InvariantCulture) + @".00";
            }
            if (pivote.Name == "dgvDomingo")
            {
                tbMontoDomingo.Text = @"$" + sum.ToString(CultureInfo.InvariantCulture) + @".00";
            }
        }
    }
}
