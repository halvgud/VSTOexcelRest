﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;
using Respuesta;


namespace testVSTO2
{
    public partial class BusquedaRecetaDetalle : Form
    {
        private readonly List<Receta> _clave;
        private readonly Action<Receta> _callback;
        public BusquedaRecetaDetalle(List<Receta> clave, Action<Receta> callback,bool mostrarCantidad)
        {
                _clave = clave;_callback = callback;
                InitializeComponent();
                if (!mostrarCantidad)
                {
                    tbCantidad.Visible = false;
                    tbCantidad.Text = @"1";
                }
                dataGridView1.DataSource = _clave.Select(x=>new {clave = x.Clave,descripcion = x.Descripcion,precio = x.Precio}).ToArray();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            /*
            var addIn = Globals.ThisAddIn;
            addIn.Agregar(_clave[dataGridView1.CurrentCell.RowIndex], double.Parse(tbCantidad.Text));
            Close();*/
            _clave[dataGridView1.CurrentCell.RowIndex].CantidadDiario = double.Parse(tbCantidad.Text);
            _callback(_clave[dataGridView1.CurrentCell.RowIndex]);
            Close();
        }

        private void tbCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Herramienta.Opcion.ValidarCaracter(e);
        }
        

    }
}
