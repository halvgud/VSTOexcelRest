using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Respuesta;

namespace ExcelAddIn1
{
    public partial class BuscarPlatillo : Form
    {
        private readonly List<MenuDia> _platillo;
        private readonly Action<BindingList<MenuDia>> _callback;
        private bool v;

        public BuscarPlatillo(List<MenuDia> platillo,DateTime diaSeleccionado, Action<BindingList<MenuDia>> callback, bool v)
        {
            _platillo = platillo;
            _callback = callback;
             this.v = v;
            InitializeComponent();
            //groupBox1.Enabled = false;
            btAgregarSemana.Enabled = false;
            dataGridView1.DataSource = _platillo.Select(x => new { platillo = x.Platillo, ultimaElaboracion=x.UltimaElaboracion }).ToArray();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 11);
            DeshabilitarRadioButtons(this,diaSeleccionado);
        }

        private int DevolverDia(string dia)
        {
            switch (dia)
            {
                case "Lunes": return 1;
                case "Martes": return 2;
                case "Miercoles": return 3;
                case "Jueves": return 4;
                case "Viernes": return 5;
                case "Sabado": return 6;
                case "Domingo": return 7;
                default:
                    return 0;
            }
        }
        private void DeshabilitarRadioButtons(Control ctrl,DateTime diaSeleccionado)
        {
            foreach (Control c in ctrl.Controls)
            {
                var view = c as RadioButton;
                if (view != null)
                {
                    int radioDay= DevolverDia(view.Name);
                    var result = DateTime.Compare(diaSeleccionado, DateTime.Today);
                    int day = 0;
                    day = (DateTime.Now.DayOfWeek == 0) ? 7 : (int)DateTime.Now.DayOfWeek;
                    view.Enabled = !(radioDay <= day);
                    view.Enabled = radioDay == day;

                    if (day == 7)
                    {
                        view.Enabled = true;
                    }
                }
                else
                {
                    DeshabilitarRadioButtons(c,diaSeleccionado);
                }
            }
        }
        private void btAgregarSemana_Click(object sender, EventArgs e)
        {
            if(Lunes.Checked)
            {
                if (_callback != null)
                {
                    _platillo[dataGridView1.CurrentCell.RowIndex].UltimaElaboracion=Lunes.Text;
                    _callback(new BindingList<MenuDia> { _platillo[dataGridView1.CurrentCell.RowIndex] });
                }
            }
            if(Martes.Checked)
            {
                if (_callback != null)
                {
                    _platillo[dataGridView1.CurrentCell.RowIndex].UltimaElaboracion = Martes.Text;
                    _callback(new BindingList<MenuDia> { _platillo[dataGridView1.CurrentCell.RowIndex] });
                }
            }
            if(Miercoles.Checked)
            {
                if (_callback != null)
                {
                    _platillo[dataGridView1.CurrentCell.RowIndex].UltimaElaboracion = Miercoles.Text;
                    _callback(new BindingList<MenuDia> { _platillo[dataGridView1.CurrentCell.RowIndex] });
                }
            }
            if(Jueves.Checked)
            {
                if (_callback != null)
                {
                    _platillo[dataGridView1.CurrentCell.RowIndex].UltimaElaboracion = Jueves.Text;
                    _callback(new BindingList<MenuDia> { _platillo[dataGridView1.CurrentCell.RowIndex] });
                }
            }
            if(Viernes.Checked)
            {
                if (_callback != null)
                {
                    _platillo[dataGridView1.CurrentCell.RowIndex].UltimaElaboracion = Viernes.Text;
                    _callback(new BindingList<MenuDia> { _platillo[dataGridView1.CurrentCell.RowIndex] });
                }
            }
            if(Sabado.Checked)
            {
                if (_callback != null)
                {
                    _platillo[dataGridView1.CurrentCell.RowIndex].UltimaElaboracion = Sabado.Text;
                    _callback(new BindingList<MenuDia> { _platillo[dataGridView1.CurrentCell.RowIndex] });
                }
            }
            if(Domingo.Checked)
            {
                if (_callback != null)
                {
                    _platillo[dataGridView1.CurrentCell.RowIndex].UltimaElaboracion = Domingo.Text;
                    _callback(new BindingList<MenuDia> { _platillo[dataGridView1.CurrentCell.RowIndex] });
                }
            }
            Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.RowCount>0)
            {
                groupBox1.Enabled = true;
                btAgregarSemana.Enabled = true;
            }
            else
            {
                groupBox1.Enabled = false;
                btAgregarSemana.Enabled = false;
            }
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dataGridView1 != null && dataGridView1.RowCount > 0)
            {
               dataGridView1.RowHeadersVisible = false;
                var dataGridViewColumn = dataGridView1.Columns["platillo"];
                if (dataGridViewColumn != null) dataGridViewColumn.Width = 400;
                var gridViewColumn = dataGridView1.Columns["UltimaElaboracion"];
                if (gridViewColumn != null)
                    gridViewColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
    }
}