using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Herramienta;
using Herramienta.Config;
using Respuesta;

namespace ExcelAddIn1
{
    public partial class BuscarArticulo : Form
    {
        private List<Articulo> _listaArticulo;
        private readonly Action<List<Articulo>> _callback;
                
        public BuscarArticulo(List<Articulo> listaArticulo,Action<List<Articulo>> callback )
        {
            _listaArticulo = listaArticulo;
            _callback = callback;
            InitializeComponent();
            //dgvListaArticulos.DataSource = _listaArticulo.Select(x => new { clave = x.Clave, descripcion = x.Descripcion, precioCompra = x.PrecioCompra }).ToArray();
            //dgvListaArticulos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
            tbCantidad.Enabled = true;
            btAceptar.Enabled = true;
            tbCantidad.Focus();
        }
        private void tbCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && tbCantidad.Text.Trim().Length > 0)
            {
                btAceptar_Click(sender, new EventArgs());
            }
        }
        private void tbCantidad_TextChanged(object sender, EventArgs e)
        {
            btAceptar.Enabled = ValidarEspacioVacio();
        }
        private bool ValidarEspacioVacio()
        {
            double d;
            errorProvider1.SetError(tbCantidad,
                double.TryParse(tbCantidad.Text, out d) ? string.Empty : "Favor de ingresar solo números");
            return tbCantidad.Text.Trim().Length > 0 && double.TryParse(tbCantidad.Text, out d);
        }

        private void tbCantidad_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
           // Regex regex = new Regex(@"^[0-9]*([0-9]+\.[0-9]{1,2})*$");
            ValidarEspacioVacio();
        }
        private void dgvListaArticulos_CurrentCellChanged(object sender, EventArgs e)
        {
          dgvListaArticulos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
          dgvListaArticulos.DefaultCellStyle.Font = new Font("Arial", 9);
          dgvListaArticulos.Columns[1].Width = 250;
          dgvListaArticulos.Columns[0].Width = 100;
          dgvListaArticulos.Columns[2].Width = 100;
          dgvListaArticulos.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
          dgvListaArticulos.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        private void BuscarArticulo_Load(object sender, EventArgs e)
        {
            txtIngrediente.Focus();
            tbCantidad.Enabled = false;
            btAceptar.Enabled = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Local.Articulo.IdArticulo = txtIngrediente.Text.Trim();
            Opcion.EjecucionAsync(x =>
            {
                Data.Articulo.Lista(x, this);
            }, jsonResult =>
            {
                BeginInvoke((MethodInvoker) (() =>
                {
                    _listaArticulo = Opcion.JsonaListaGenerica<Articulo>(jsonResult);
                    dgvListaArticulos.DataSource =
                        _listaArticulo.Select(
                            x => new {clave = x.Clave, descripcion = x.Descripcion, precioCompra = x.PrecioCompra})
                            .ToArray();
                }));
            });
          }

        private void txtIngrediente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button1_Click(sender, new EventArgs());
            }
        }
    }
      }
