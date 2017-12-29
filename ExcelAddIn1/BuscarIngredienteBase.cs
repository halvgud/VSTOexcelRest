using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Herramienta;
using Herramienta.Config;
using Respuesta;
using RestSharp;

namespace ExcelAddIn1
{
    public partial class BuscarIngredienteBase: Form
    {
        private List<Articulo> _listaArticulo;
        private readonly Action<List<Articulo>> _callback;
        public BuscarIngredienteBase(List<Articulo> listaArticulo, Action<List<Articulo>> callback)
        {
            _listaArticulo = listaArticulo;
            _callback = callback;
            InitializeComponent();
                 Opcion.EjecucionAsync(Data.Receta.Unidad.UnidadIngredienteBase, x =>
                 {
                     CargarComboBoxUnidad(x, cbxUnidad);
                     CargarComboBoxUnidad(x, cbUnidadModificar);
                 });
        }
        private void CargarComboBoxUnidad(IRestResponse json, ComboBox unidad)
        {
            BeginInvoke((MethodInvoker)(() =>
            {
                var bindingSource1 = new BindingSource
                {
                    DataSource = Opcion.JsonaListaGenerica<CbGenerico>(json)
                };
                unidad.DataSource = bindingSource1;
                unidad.DisplayMember = "nombre";
                unidad.ValueMember = "id";
                unidad.Tag = json;
            }));
        }
        private void BuscarIngredienteBase_Load(object sender, EventArgs e)
        {
            ActiveControl = txtIngrediente;
            txtIngrediente.Focus();
            cbUnidadModificar.Visible = false;
            btGuardarUnidad.Visible = false;
            txtUnidadAgregar.Visible = false;
            btGuardar.Enabled = false;
            txtIngredienteReceta.Visible = false;
            txtCantidadReceta.Visible = false;
            txtUnidadReceta.Visible = false;
            btAceptarReceta.Visible = false;
            btActualizar.Enabled = false;
            btAgregaraReceta.Enabled = false;
        }
        private bool ValidarCampos()
        {
            return (txtIngrediente.Text != string.Empty && txtCosto.Text != string.Empty
                    && txtCantidad.Text != string.Empty);
        }
        private void btBuscar_Click(object sender, EventArgs e)
        {
            Local.Receta.Clave = txtIngrediente.Text == string.Empty ? "%" : txtIngrediente.Text;
            Opcion.EjecucionAsync(Data.Receta.IngredientesBase, jsonResult =>
            {
                if (jsonResult != null)
                {
                    BeginInvoke((MethodInvoker)(() =>
                    {
                        _listaArticulo = Opcion.JsonaListaGenerica<Articulo>(jsonResult);
                        dgvIngredientesBase.DataSource =
                        _listaArticulo.Select(
                            x => new {x.Clave,x.Descripcion,x.Cantidad,x.Unidad,x.PrecioCompra})
                            .ToArray();
                        var gridViewColumn12 = dgvIngredientesBase.Columns["Clave"];
                        if (gridViewColumn12 != null) gridViewColumn12.Visible = false;
                        var gridViewColumn122 = dgvIngredientesBase.Columns["Id"];
                        if (gridViewColumn122 != null) gridViewColumn122.Visible = false;
                        txtIngrediente.Text = "";
                    }));
                }
            });    
        }
        private void btActualizar_Click(object sender, EventArgs e)
        {
           
            if (dgvIngredientesBase.CurrentRow != null && dgvIngredientesBase.CurrentRow.Selected.ToString()!="")
            {
                var row = dgvIngredientesBase.CurrentCell.RowIndex;
                txtIngrediente.Text = dgvIngredientesBase.Rows[row].Cells[1].Value.ToString();
                txtCantidad.Text = dgvIngredientesBase.Rows[row].Cells[2].Value.ToString();
                cbxUnidad.Text = dgvIngredientesBase.Rows[row].Cells[3].Value.ToString();
                txtCosto.Text = dgvIngredientesBase.Rows[row].Cells[4].Value.ToString();
                txtId.Text = dgvIngredientesBase.Rows[row].Cells[0].Value.ToString();
            }
            else
            {
                MessageBox.Show(@"Selecciona el ingrediente que deseas editar");
            }   
        }
        private void btAgregaraReceta_Click(object sender, EventArgs e)
        {
            if (dgvIngredientesBase.CurrentRow != null && dgvIngredientesBase.CurrentRow.Selected.ToString()!= "")
            {
                var row = dgvIngredientesBase.CurrentCell.RowIndex;
                txtIngredienteReceta.Text = dgvIngredientesBase.Rows[row].Cells[1].Value.ToString();
                txtCantidadReceta.Text = dgvIngredientesBase.Rows[row].Cells[2].Value.ToString();
                txtUnidadReceta.Text = dgvIngredientesBase.Rows[row].Cells[3].Value.ToString();
                txtIngredienteReceta.Visible = true;
                txtCantidadReceta.Visible = true;
                txtUnidadReceta.Visible = true;
                btAceptarReceta.Visible = true;
                txtCantidadReceta.Enabled = true;
                btAceptarReceta.Enabled = true;
                txtCantidadReceta.Focus();
            }
            else
            {
                MessageBox.Show(@"Selecciona el ingrediente que deseas agregar a la receta");
            }
        }
        private bool ValidarEspacioVacio()
        {
            double d;
            errorProvider1.SetError(txtCantidadReceta,
                double.TryParse(txtCantidadReceta.Text, out d) ? string.Empty : "Favor de ingresar solo números");
            return txtCantidadReceta.Text.Trim().Length > 0 && double.TryParse(txtCantidadReceta.Text, out d);
        }
        private void btAceptarReceta_Click(object sender, EventArgs e)
        {
            
            _listaArticulo[dgvIngredientesBase.CurrentCell.RowIndex].Cantidad = double.Parse(txtCantidadReceta.Text);
            _callback(new List<Articulo> { _listaArticulo[dgvIngredientesBase.CurrentCell.RowIndex] });
            Close();
        }
        private void btGuardar_Click(object sender, EventArgs e)
        {
            var id =txtId.Text;
            if (id == "")
            {
                var ingrediente = new Receta.IngredientesBase
                {
                    //Id = Convert.ToInt32(id),
                    Descripcion = txtIngrediente.Text,
                    Cantidad = Convert.ToDouble(txtCantidad.Text),
                    Unidad = cbxUnidad.Text,
                    Costo = Convert.ToDouble(txtCosto.Text)
                };
                Data.Receta.CRecetaBase = ingrediente;
                Opcion.EjecucionAsync(Data.Receta.InsertarIngredienteBase, resultado =>
                {
                    MessageBox.Show(@"La informacion se a Guardado correctamente");
                });
            }
            else
            {
                var ingrediente = new Receta.IngredientesBase
                {
                    Id=Convert.ToInt32(id),
                    Descripcion = txtIngrediente.Text,
                    Cantidad = Convert.ToDouble(txtCantidad.Text),
                    Unidad = cbxUnidad.Text,
                    Costo = Convert.ToDouble(txtCosto.Text)
                };
                Data.Receta.ActualizarIngredienteBase(ingrediente);
            }
            txtIngrediente.Text = "";
            txtCosto.Text = "";
            txtId.Text = "";
            cbxUnidad.SelectedItem = "";
            txtCantidad.Text = "";
        }
        private void cbxAgregarUnidad_CheckedChanged(object sender, EventArgs e)
        {
            if (chAgregarUnidad.Checked)
            {
                chModificarUnidad.Checked = false;
                txtUnidadAgregar.Visible = true;
                btGuardarUnidad.Visible = true;
                btGuardarUnidad.Text = chAgregarUnidad.Checked? @"Guardar Unidad": @"Eliminar Unidad";
            }
            else
            {
                txtUnidadAgregar.Visible = false;
                btGuardarUnidad.Visible = false;
                txtUnidadAgregar.Text = "";
            }
        }
        private void txtIngrediente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btBuscar_Click(sender, new EventArgs());
            }
        }
        private void chModificarUnidad_CheckedChanged(object sender, EventArgs e)
        {
            if (chModificarUnidad.Checked)
            {
                chAgregarUnidad.Checked = false;
                cbUnidadModificar.Visible = true;
                btGuardarUnidad.Visible = true;
                lbUnidad.Visible = true;
                txtUnidadAgregar.Visible = true;
            }
            else
            {
                cbUnidadModificar.Visible = false;
                btGuardarUnidad.Visible = false;
                lbUnidad.Visible = false;
                txtUnidadAgregar.Text = "";
            }
        }
        private void txtCantidadReceta_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //ValidarEspacioVacio();
        }

        private void txtCantidadReceta_TextChanged(object sender, EventArgs e)
        {
            if (
                dgvIngredientesBase.Rows[dgvIngredientesBase.CurrentCell.RowIndex].Cells["Cantidad"].Value.ToString() !=
                txtCantidadReceta.Text && txtCantidadReceta.Text!="")
            {
                var cantidad =
                    Convert.ToDouble(dgvIngredientesBase.Rows[dgvIngredientesBase.CurrentCell.RowIndex].Cells["Cantidad"].Value);
                var preciocompra =
                    Convert.ToDouble(dgvIngredientesBase.Rows[dgvIngredientesBase.CurrentCell.RowIndex].Cells["PrecioCompra"].Value);
                var valor = preciocompra/cantidad;
                var preciototal = Convert.ToDouble(txtCantidadReceta.Text)*valor;
                _listaArticulo[dgvIngredientesBase.CurrentCell.RowIndex].PrecioCompra = preciototal;
            }
        }
        private void dgvIngredientesBase_SelectionChanged(object sender, EventArgs e)
        {
            btActualizar.Enabled = true;
            btAgregaraReceta.Enabled = true;
        }

        private void txtIngrediente_TextChanged(object sender, EventArgs e)
        {
            btGuardar.Enabled = ValidarCampos();
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            btGuardar.Enabled = ValidarCampos();
        }

        private void txtCosto_TextChanged(object sender, EventArgs e)
        {
            btGuardar.Enabled = ValidarCampos();
        }
    };
}
