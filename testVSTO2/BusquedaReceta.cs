using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using Herramienta;
using Herramienta.Config;
using Respuesta;

namespace testVSTO2
{
    public partial class BusquedaReceta : Form
    {
        public BusquedaReceta(Action<List<Receta>> callback)
        {
            _callback = callback;
            InitializeComponent();
        }

        private readonly Action<List<Receta>> _callback;
        private List<Receta> _listaRecetas;
        private void btBuscar_Click(object sender, EventArgs e)
        {
            Local.Receta.Clave = (tbCodigo.Text);
            Opcion.EjecucionAsync(Data.Receta.Lista, jsonResult =>
            {
                BeginInvoke((MethodInvoker)(() =>
                {
                    switch (jsonResult.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            _listaRecetas = Opcion.JsonaListaGenerica<Receta>(jsonResult);
                            dgvRecetas.DataSource = _listaRecetas.Select(x => new { clave = x.Clave, descripcion = x.Descripcion, precio = x.Precio }).ToArray();
                            dgvRecetas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                            for (var x = 0; x < 3; x++)
                            {
                                dgvRecetas.Columns[x].ReadOnly = true;
                                dgvRecetas.Columns[x].DefaultCellStyle.BackColor = Color.LightGray;
                            }
                            break;
                        default:
                            MessageBox.Show(this, @"No se encontraron recetas con los parametros de busqueda ingresados");
                            break;
                    }
                }));
            });
        }

        private void dgvRecetas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var ingredientes = _listaRecetas[dgvRecetas.CurrentCell.RowIndex].Ingredientes;
            dgvIngredientes.DataSource = ingredientes.Select(x=>new {x.Clave,x.Descripcion,x.Cantidad,x.PrecioTotal}).ToList();
            dgvIngredientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tbPrecio.Text = _listaRecetas[dgvRecetas.CurrentCell.RowIndex].Precio.ToString(CultureInfo.InvariantCulture);
            tbMargenConPrecio.Text= _listaRecetas[dgvRecetas.CurrentCell.RowIndex].Margen.ToString(CultureInfo.InvariantCulture);
            tbDescripcion.Text = _listaRecetas[dgvRecetas.CurrentCell.RowIndex].Descripcion;
            tbCostoElaboracion.Text = _listaRecetas[dgvRecetas.CurrentCell.RowIndex].CostoElaboracion.ToString(CultureInfo.InvariantCulture);
            tbCostoEstimado.Text =_listaRecetas[dgvRecetas.CurrentCell.RowIndex].CostoCreacion.ToString(CultureInfo.InvariantCulture);
            tbClaveReceta.Text = _listaRecetas[dgvRecetas.CurrentCell.RowIndex].Clave;
            tbPesoLitro.Text = _listaRecetas[dgvRecetas.CurrentCell.RowIndex].PesoLitro.ToString(CultureInfo.InvariantCulture);
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            _listaRecetas[dgvRecetas.CurrentCell.RowIndex].CantidadDiario = double.Parse(tbCantidad.Text);
            _callback(new List<Receta> { _listaRecetas[dgvRecetas.CurrentCell.RowIndex] });
        }
    }
}
