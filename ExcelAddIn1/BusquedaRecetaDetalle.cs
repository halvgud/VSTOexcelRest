using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;
using Respuesta;


namespace ExcelAddIn1
{
    public partial class BusquedaRecetaDetalle : Form
    {
        private readonly List<Receta> _clave;
        private readonly List<Receta.Congelados> _claveCongelados;
        private readonly Action<Receta> _callback;
        private readonly Action<Receta.Congelados> _callbackCongelados;
        private readonly bool _banderaCongelados ;
        public BusquedaRecetaDetalle(List<Receta> clave, Action<Receta> callback,bool mostrarCantidad)
        {
                _clave = clave;
            _callback = callback;
                InitializeComponent();
                if (!mostrarCantidad)
                {
                    tbCantidad.Visible = false;
                    tbCantidad.Text = @"1";
                }
                dataGridView1.DataSource = _clave.Select(x=>new {clave = x.Clave,descripcion = x.Descripcion,precio = x.Precio}).ToArray();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        public BusquedaRecetaDetalle(List<Receta.Congelados> clave, Action<Receta.Congelados> callback, bool mostrarCantidad)
        {
            _claveCongelados = clave;
            _callbackCongelados = callback;
            InitializeComponent();
            if (!mostrarCantidad)
            {
                tbCantidad.Visible = false;
                tbCantidad.Text = @"1";
            }
            dataGridView1.DataSource = _claveCongelados.Select(x => new { clave = x.clave, descripcion = x.descripcion, cantidad = x.cantidad }).ToArray();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void btAceptar_Click(object sender, EventArgs e)
        {
            /*
            var addIn = Globals.ThisAddIn;
            addIn.Agregar(_clave[dataGridView1.CurrentCell.RowIndex], double.Parse(tbCantidad.Text));
            Close();*/
            if (_callback != null)
            {
                _clave[dataGridView1.CurrentCell.RowIndex].Cantidad = double.Parse(tbCantidad.Text);
                _callback(_clave[dataGridView1.CurrentCell.RowIndex]);
            }else
            {
                _claveCongelados[dataGridView1.CurrentCell.RowIndex].cantidad = double.Parse(tbCantidad.Text);
                _callbackCongelados(_claveCongelados[dataGridView1.CurrentCell.RowIndex]);
            }
            //if (_banderaCongelados)
            //{
            //    _claveCongelados[dataGridView1.CurrentCell.RowIndex].cantidad = double.Parse(tbCantidad.Text);
            //    _callback(_claveCongelados[dataGridView1.CurrentCell.RowIndex]);
            //}
            //else
            //{
             
            //}

            //COMENTADO POR SI LAS DUDASY USARSE MAS ADELANTE

            /*            _clave[dataGridView1.CurrentCell.RowIndex].Cantidad = double.Parse(tbCantidad.Text);
            _clave[dataGridView1.CurrentCell.RowIndex].Ingredientes = new List<Receta.Detalle>
            {
                _clave[dataGridView1.CurrentCell.RowIndex];
            };
            _callback(_clave[dataGridView1.CurrentCell.RowIndex]);*/


            Close();
        }


        private void tbCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Herramienta.Opcion.ValidarCaracter(e);
        }
        

    }
}
