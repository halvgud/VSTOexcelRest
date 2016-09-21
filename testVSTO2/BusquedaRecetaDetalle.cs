using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using testVSTO2.Respuesta;

namespace testVSTO2
{
    public partial class BusquedaRecetaDetalle : Form
    {
        private readonly List<Receta> _clave;
            public BusquedaRecetaDetalle(List<Receta> clave)
            {
                _clave = clave;
                InitializeComponent();
                dataGridView1.DataSource = _clave.Select(x=>new {x.clave,x.descripcion,x.precio}).ToArray();
            }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            var addIn = Globals.ThisAddIn;
            addIn.Agregar(_clave[dataGridView1.CurrentCell.RowIndex], double.Parse(tbCantidad.Text));
            Close();
        }
    }
}
