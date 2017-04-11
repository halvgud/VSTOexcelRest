using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using Herramienta;
using Herramienta.Config;
using Respuesta;

namespace ExcelAddIn1
{
    public partial class SideBarRecetario : UserControl
    {
        public SideBarRecetario()
        {
            InitializeComponent();
            _listaRecetas = new List<Receta>();
        }
        private List<Receta.Basica> _listaArticuloBasica1;
        private List<Receta.Basica> _listaArticuloBasica2;
        private List<Receta> _listaRecetas;
        private void btBuscar_Click(object sender, EventArgs e)
        {
            var br = new BusquedaReceta(AgregarListaRecetas);
            br.Show();
        }

        private void AgregarListaRecetas(List<Receta> receta)
        {
            _listaRecetas.AddRange(receta);
            _listaRecetas = _listaRecetas.GroupBy(p => p.Clave).Select(g => new Receta
            {
                Clave = g.Key,
                Cantidad = g.Sum(i => i.Cantidad),
                CostoCreacion = g.First().CostoCreacion,
                CostoElaboracion = g.First().CostoElaboracion,
                Descripcion = g.First().Descripcion,
                Diario = g.First().Diario,
                FechaModificacion = g.First().FechaModificacion,
                Ingredientes = g.First().Ingredientes,
                Margen = g.First().Margen,
                PesoLitro = g.First().PesoLitro
            }).ToList();
            _listaArticuloBasica1 = dgvListaReceta.DataSource as List<Receta.Basica>;
            _listaArticuloBasica2 = (receta.Select(x => x.CopiadoSencillo()).ToList());
            if (_listaArticuloBasica1 != null)
            {
                _listaArticuloBasica2.AddRange(_listaArticuloBasica1);
            }
            dgvListaReceta.DataSource = _listaArticuloBasica2
                .GroupBy(p => p.Clave).Select(g => new Receta.Basica
                {
                    Clave = g.Key,
                    Descripcion = g.First().Descripcion,
                    Cantidad = g.Sum(i => i.Cantidad),
                    Precio = g.First().Precio
                }).ToList();
            dgvListaReceta.Columns[0].ReadOnly = true;
            dgvListaReceta.Columns[0].DefaultCellStyle.BackColor = Color.LightGray;
            dgvListaReceta.Columns[1].ReadOnly = true;
            dgvListaReceta.Columns[1].DefaultCellStyle.BackColor = Color.LightGray;
            dgvListaReceta.Columns[2].ReadOnly = true;
            dgvListaReceta.Columns[2].DefaultCellStyle.BackColor = Color.LightGray;
            ValidarFecha();
            dgvListaReceta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void btBuscarReceta_Click(object sender, EventArgs e)
        {
            Local.Receta.clave = (tbBuscarReceta.Text);
            Opcion.EjecucionAsync(Data.Receta.Lista, jsonResult =>
            {
                BeginInvoke((MethodInvoker) (() =>  
                {
                    switch (jsonResult.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            var brd =
                             new BusquedaRecetaDetalle(Opcion.JsonaListaGenerica<Receta>(jsonResult),CargarFormatoReceta, true);
                            brd.Show();
                            break;
                        default:
                            MessageBox.Show(this, (Opcion.JsonaString(jsonResult.Content)));
                            break;
                    }}));
            });
        }

        private void CargarFormatoReceta(Receta resultado)
        {
            using (var addIn = Globals.ThisAddIn)
            {
                addIn.Agregar(resultado);
            }
        }

        private void btSeleccion_Click(object sender, EventArgs e)
        {
            Opcion.BorrarSeleccion(dgvListaReceta);
        }

        private void btGuardar_Click(object sender, EventArgs e)
        {
            //TODO guardar en bd ms_menu_dia o actualizar,según sea el caso
        }

        private void dgvListaReceta_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {//TODO cargar recetario
            CargarFormatoReceta(_listaRecetas[e.RowIndex]);
        }

        private void dtFecha_ValueChanged(object sender, EventArgs e)
        {
           //TODO hacer query para traer registros de la bd y cargar fechas pasadas
           btBuscar.Enabled= ValidarFecha();
        }

        private bool ValidarFecha()
        {
            if (dtFecha.Value.Day < DateTime.Now.Day)
            {
                dgvListaReceta.Columns[3].ReadOnly = true;
                dgvListaReceta.Columns[3].DefaultCellStyle.BackColor = Color.LightGray;
                return false;
            }
            else
            {
                dgvListaReceta.Columns[3].ReadOnly = false;
                dgvListaReceta.Columns[3].DefaultCellStyle.BackColor = Color.Beige;
                return true;
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

    }
}
