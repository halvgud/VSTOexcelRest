using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using testVSTO2.Prop;
using testVSTO2.Respuesta;

namespace testVSTO2
{
    public partial class AgregarReceta : Form
    {
        public AgregarReceta()
        {
            InitializeComponent();
        }

        private List<Articulo.Basica> _listaArticuloBasica1;
        private List<Articulo.Basica> _listaArticuloBasica2;
        private void btBuscar_Click(object sender, EventArgs e)
        {
            Config.Local.Articulo.IdArticulo = tbCodigo.Text;
            _listaArticuloBasica1 = new List<Articulo.Basica>();
            Opcion.EjecucionAsync(Data.Articulo.Lista, jsonResult => {
                BeginInvoke((MethodInvoker)(() => {
                    var brd =
                     new BuscarArticulo(Opcion.JsonaListaGenerica<Articulo>(jsonResult), listaArticulo => {
                         _listaArticuloBasica1 = dgvIngredientes.DataSource as List<Articulo.Basica>;
                         _listaArticuloBasica2 = (listaArticulo.Select(x => x.CopiadoSencillo()).ToList());
                         if (_listaArticuloBasica1 != null)
                         {
                             _listaArticuloBasica2.AddRange(_listaArticuloBasica1);
                         }
                         var listaAgrupada = _listaArticuloBasica2
                                       .GroupBy(p => p.clave)
                                       .Select(g => new Articulo.Basica()
                                                                           {
                                                                               clave = g.Key,
                                                                               descripcion = g.First().descripcion,
                                                                               precioCompra = g.First().precioCompra,
                                                                               cantidad = g.Sum(i => i.cantidad)
                                                                           })
                                                                            .ToList();
                         dgvIngredientes.DataSource = listaAgrupada;
                         tbCodigo.Text = "";
                         tbCodigo.Focus();
                         ActualizarInputs();
                     });
                    brd.Show();
                }));
            });
        }
        double sum = 0;
        private void ActualizarInputs()
        {
            sum = 0;
            for (var i = 0; i < dgvIngredientes.Rows.Count; ++i)
            {
                var costo1 = Convert.ToDouble(dgvIngredientes.Rows[i].Cells[2].Value);
                var cantidad1 = Convert.ToDouble(dgvIngredientes.Rows[i].Cells[3].Value);
                sum += (costo1 * cantidad1);
            }
            tbCostoEstimado.Text = sum.ToString(CultureInfo.InvariantCulture);
            tbMargenSugerido.Text = @"35%";
            var costo = (sum) + (tbCostoElaboracion.Text != string.Empty ? Convert.ToDouble(tbCostoElaboracion.Text) : 0);
            const double margen = 0.65;
            tbPrecioSugerido.Text = (Math.Round((costo / margen), 2)).ToString(CultureInfo.InvariantCulture);

        }

        private void tbCostoElaboracion_TextChanged(object sender, EventArgs e)
        {
            ActualizarInputs();
        }

        private void tbMargenConPrecio_TextChanged(object sender, EventArgs e)
        {
            if (!tbPrecio.Focused)
            {
                sum = 0;
                for (var i = 0; i < dgvIngredientes.Rows.Count; ++i)
                {
                    var costo = Convert.ToDouble(dgvIngredientes.Rows[i].Cells[2].Value);
                    var cantidad = Convert.ToDouble(dgvIngredientes.Rows[i].Cells[3].Value);
                    sum += (costo * cantidad);
                }
                if (tbMargenConPrecio.Text != string.Empty)
                {
                    tbPrecio.Text = (Math.Round(
                     (
                      (sum) + (tbCostoElaboracion.Text != string.Empty ? Convert.ToDouble(tbCostoElaboracion.Text) : 0)
                     ) /
                     (
                      1 - (Convert.ToDouble(tbMargenConPrecio.Text) / 100)
                     ), 2)).ToString(CultureInfo.InvariantCulture);
                }
            }
        }

        private void tbPrecio_TextChanged(object sender, EventArgs e)
        {
            if (!tbMargenConPrecio.Focused)
            {
                sum = 0;
                for (var i = 0; i < dgvIngredientes.Rows.Count; ++i)
                {
                    var costo1 = Convert.ToDouble(dgvIngredientes.Rows[i].Cells[2].Value);
                    var cantidad1 = Convert.ToDouble(dgvIngredientes.Rows[i].Cells[3].Value);
                    sum += (costo1 * cantidad1);
                }
                var costo = sum + (tbCostoElaboracion.Text != string.Empty ? Convert.ToDouble(tbCostoElaboracion.Text) : 0);
                if (tbPrecio.Text != string.Empty)
                {
                    var precio = Convert.ToDouble(tbPrecio.Text);

                    tbMargenConPrecio.Text = Math.Round(((1 - (costo / precio)) * 100), 2).ToString(CultureInfo.InvariantCulture);
                }
            }
        }

        private void tbCostoElaboracion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) ||
             char.IsSymbol(e.KeyChar) ||
             char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }
    }
}