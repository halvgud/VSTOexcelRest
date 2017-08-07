using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Herramienta;
using Herramienta.Config;
using Respuesta;

namespace ExcelAddIn1
{
    public partial class ActualizarPrecios : Form
    {
        public ActualizarPrecios()
        {
            InitializeComponent();
        }

        public List<Reporte.RespuestaCocina.RepoActRec> _listaXr;
        public List<Receta.IngredientesRecetaPrecio> ListIngredientesRecetaPrecios;

        public List<Reporte.RespuestaCocina.RepoActRec> ListaXr;

        private void Actualizar_Precios_Load(object sender, EventArgs e)
        {
            Opcion.EjecucionAsync(Data.Reporte.Rep_Act_Receta, jsonResult =>
            {
                BeginInvoke((MethodInvoker) (() =>
                {
                    ListaXr = Opcion.JsonaListaGenerica<Reporte.RespuestaCocina.RepoActRec>(jsonResult);
                    if (ListaXr == null)
                    {
                        var listavacia = new Reporte.RespuestaCocina.RepoActRec
                        {
                            Clave = " ",
                            Receta = " ",
                            Unidad = " ",
                            Precio = 0,
                            FechaModificacion = " "
                        };
                        dgvrecetasact.DataSource = listavacia;
                   
                       
                    }
                    else
                    {
                        dgvrecetasact.DataSource = ListaXr;
                    }

                }));
            });
        }

        private void dgvrecetasact_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvrecetasact.CurrentRow != null)
                Local.Receta.IngredienteActualizar.Rec_id = Convert.ToInt16(dgvrecetasact.CurrentRow.Cells[0].Value);
            Opcion.EjecucionAsync(Data.Reporte.MostrarIngredientesReceta, jsonResult =>
            {
                BeginInvoke((MethodInvoker)(() =>
                {
                    ListIngredientesRecetaPrecios = Opcion.JsonaListaGenerica<Receta.IngredientesRecetaPrecio>(jsonResult);

                    if (ListIngredientesRecetaPrecios.Count == 0)
                    {
                        dgvingredientes.DataSource = new Receta.IngredientesRecetaPrecio
                        {
                            Clave = "",
                            Receta = "",
                            PrecioAnterior = 0,
                            PrecioNuevo = 0
                        };
                        //dgvingredientes.DataSource = lista;
                    }
                    else
                    {
                        dgvingredientes.DataSource = ListIngredientesRecetaPrecios;
                    }
                }));

               
                
            });
        }
    }
}
