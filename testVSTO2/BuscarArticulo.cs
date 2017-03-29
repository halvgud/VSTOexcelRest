using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Herramienta;
using Respuesta;

namespace testVSTO2
{
    public partial class BuscarArticulo : Form
    {
        private readonly List<Articulo> _listaArticulo;
        private readonly Action<List<Articulo>> _callback;
        public BuscarArticulo(List<Articulo> listaArticulo,Action<List<Articulo>> callback )
        {
            this.ActiveControl = tbCantidad;
            tbCantidad.Focus();
            _listaArticulo = listaArticulo;
            _callback = callback;
            InitializeComponent();
            dgvListaArticulos.DataSource = _listaArticulo.Select(x => new { x.clave, x.descripcion, x.precioCompra }).ToArray();
            dgvListaArticulos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        
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
           this.ActiveControl = tbCantidad;
            tbCantidad.Focus();
           
          
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
        private bool ValidarBusquedaVacia()
        {
            return btAceptar.Text.Trim().Length > 0;
        }

        private void tbCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && ValidarBusquedaVacia())
            {
                btAceptar_Click(sender, new EventArgs());
            }
        }
    }
}
