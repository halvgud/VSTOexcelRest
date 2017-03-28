using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Respuesta;

namespace testVSTO2
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
            dgvListaArticulos.DataSource = _listaArticulo.Select(x => new { x.clave, x.descripcion, x.precioCompra }).ToArray();
            dgvListaArticulos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.ActiveControl = tbCantidad;
            tbCantidad.Focus();
        }
        private void btAceptar_Click(object sender, EventArgs e)
        {
            _listaArticulo[dgvListaArticulos.CurrentCell.RowIndex].cantidad = double.Parse(tbCantidad.Text);
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

        private void BuscarArticulo_Load(object sender, EventArgs e)
        {
            ActiveControl = tbCantidad;
            tbCantidad.Focus();
        }

        private void tbCantidad_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void dgvListaArticulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BuscarArticulo_Activated(object sender, EventArgs e)
        {
           this.ActiveControl = tbCantidad;
            tbCantidad.Focus();
        }

        private void BuscarArticulo_Shown(object sender, EventArgs e)
        {
            this.ActiveControl =tbCantidad ;
            tbCantidad.Focus();
            tbCantidad.Select();
        }
    }
}
