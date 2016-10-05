using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using testVSTO2.Herramienta;
using testVSTO2.Herramienta.Config;
using testVSTO2.Respuesta;

namespace testVSTO2
{
    public partial class SideBarRecetario : UserControl
    {
        public SideBarRecetario()
        {
            InitializeComponent();
        }
        private List<Receta.Basica> _listaArticuloBasica1;
        private List<Receta.Basica> _listaArticuloBasica2;
        private List<Receta> _listaRecetas;
        private void btBuscar_Click(object sender, EventArgs e)
        {
            var br = new BusquedaReceta(receta =>
            {
                _listaRecetas.AddRange(receta);
                _listaRecetas = _listaRecetas.GroupBy(p => p.Clave).Select(g => new Receta
                {   
                    Clave = g.Key,
                    Cantidad = g.Sum(i=>i.Cantidad),
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
                for (var x = 0; x < 3; x++)
                {
                    dgvListaReceta.Columns[x].ReadOnly = true;
                    dgvListaReceta.Columns[x].DefaultCellStyle.BackColor = Color.LightGray;
                }
                dgvListaReceta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            });
            br.Show();
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
                             new BusquedaRecetaDetalle(Opcion.JsonaListaGenerica<Receta>(jsonResult),
                                 resultado =>
                                 {
                                     using (var addIn = Globals.ThisAddIn)
                                     {
                                         addIn.Agregar(resultado);
                                     }
                                 },true);
                            brd.Show();
                            break;
                        default:
                            throw new Exception(@"No se encontraron recetas con los parametros de busqueda ingresados");
                    }}));
            });
        }

        private void btSeleccion_Click(object sender, EventArgs e)
        {
            Opcion.BorrarSeleccion(dgvListaReceta);
        }

        private void btGuardar_Click(object sender, EventArgs e)
        {

        }

        private void dgvListaReceta_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
