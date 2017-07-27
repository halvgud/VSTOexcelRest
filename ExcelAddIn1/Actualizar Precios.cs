using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Herramienta;

namespace ExcelAddIn1
{
    public partial class ActualizarPrecios : Form
    {
        public ActualizarPrecios()
        {
            InitializeComponent();
        }
        public List<Respuesta.Reporte.RespuestaCocina.RepoActRec> ListaXr;
        private void Actualizar_Precios_Load(object sender, EventArgs e)
        {
            Opcion.EjecucionAsync(Data.Reporte.Rep_Act_Receta, jsonResult =>
            {
                BeginInvoke((MethodInvoker) (() =>
                {
                    ListaXr = Opcion.JsonaListaGenerica<Respuesta.Reporte.RespuestaCocina.RepoActRec>(jsonResult);
                    if (ListaXr == null)
                    {
                        var listavacia = new Respuesta.Reporte.RespuestaCocina.RepoActRec
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
    }
}
