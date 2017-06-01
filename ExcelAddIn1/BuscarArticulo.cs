using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Respuesta;

namespace ExcelAddIn1
{
    public partial class BuscarArticulo : Form
    {
        private readonly List<Articulo> _listaArticulo;
        private readonly Action<List<Articulo>> _callback;
                
        public BuscarArticulo(List<Articulo> listaArticulo,Action<List<Articulo>> callback )
        {
            _listaArticulo = listaArticulo;
            _callback = callback;
            InitializeComponent();
            dgvListaArticulos.DataSource = _listaArticulo.Select(x => new { clave = x.Clave, descripcion = x.Descripcion, precioCompra = x.PrecioCompra }).ToArray();
            dgvListaArticulos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        

        private void btAceptar_Click(object sender, EventArgs e)
        {
            _listaArticulo[dgvListaArticulos.CurrentCell.RowIndex].Cantidad = double.Parse(tbCantidad.Text);
            _callback(new List<Articulo> { _listaArticulo[dgvListaArticulos.CurrentCell.RowIndex] });
            Close();
        }

        private void dgvListaArticulos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbCantidad.Text = @"1";
            tbCantidad.SelectionStart = 0;
            tbCantidad.SelectionLength = tbCantidad.Text.Length;
            tbCantidad.Focus();
        }

        private void tbCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && tbCantidad.Text.Trim().Length > 0)
            {
                btAceptar_Click(sender, new EventArgs());
            }
            else
            {
                //tbCantidad_Validating(sender,new CancelEventArgs());
            }
        }

        private void tbCantidad_TextChanged(object sender, EventArgs e)
        {
            btAceptar.Enabled = ValidarEspacioVacio();
        }

        private bool ValidarEspacioVacio()
        {
            double d = 1;
            errorProvider1.SetError(tbCantidad,
                double.TryParse(tbCantidad.Text, out d) ? string.Empty : "Favor de ingresar solo números");
            return tbCantidad.Text.Trim().Length > 0 && double.TryParse(tbCantidad.Text, out d);
        }

        private void tbCantidad_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
           // Regex regex = new Regex(@"^[0-9]*([0-9]+\.[0-9]{1,2})*$");
            ValidarEspacioVacio();

        }
    }
}
