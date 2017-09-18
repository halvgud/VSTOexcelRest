using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Respuesta;
namespace ExcelAddIn1
{
    public partial class BusquedaRecetaDetalle : Form
    {
        private readonly List<Receta> _clave;
        private readonly Action<Receta> _callback;

        public BusquedaRecetaDetalle(List<Receta> clave, Action<Receta> callback,bool mostrarCantidad)
        {
                _clave = clave;
            _callback = callback;
                InitializeComponent();
                if (!mostrarCantidad)
                {
                    tbCantidad.Visible = true;
                    tbCantidad.Text = @"1";
                }
                dataGridView1.DataSource = _clave.Select(x=>new {clave = x.Clave,descripcion = x.Descripcion,precio = x.Precio}).ToArray();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
      
        private void btAceptar_Click(object sender, EventArgs e)
        {
            if (_callback != null)
            {
                _clave[dataGridView1.CurrentCell.RowIndex].CantidadDiario = double.Parse(tbCantidad.Text);
                _callback(_clave[dataGridView1.CurrentCell.RowIndex]);
            }
            //else
            //{
            //    _claveReceta[dataGridView1.CurrentCell.RowIndex].Precio= double.Parse(tbCantidad.Text);
            //    _callbackReceta(_claveReceta[dataGridView1.CurrentCell.RowIndex]);
            //}
            Close();
        }
        private void tbCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Herramienta.Opcion.ValidarCaracter(e);
        }


        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 9);
            dataGridView1.Columns[1].Width = 250;
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void BusquedaRecetaDetalle_Load(object sender, EventArgs e)
        {

        }
    }
}
