﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using testVSTO2.Respuesta;

namespace testVSTO2
{
    public partial class BuscarArticulo : Form
    {
        private List<Articulo> _listaArticulo;
        private Action<List<Articulo>> _callback;
        public BuscarArticulo(List<Articulo> listaArticulo,Action<List<Articulo>> callback )
        {
            _listaArticulo = listaArticulo;
            _callback = callback;
            InitializeComponent();
            dgvListaArticulos.DataSource = _listaArticulo.Select(x => new { x.clave, x.descripcion, x.precioCompra }).ToArray();
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
    }
}
