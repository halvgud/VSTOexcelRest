using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Herramienta;

namespace ExcelAddIn1
{
    public partial class Actualizar_Precios : Form
    {
        public Actualizar_Precios()
        {
            InitializeComponent();
        }
        public List<Respuesta.Reporte.RespuestaCocina.RepoActRec> _ListaXR;
        private void Actualizar_Precios_Load(object sender, EventArgs e)
        {
            Opcion.EjecucionAsync(Data.Reporte.Rep_Act_Receta, jsonResult =>
            {
                BeginInvoke((MethodInvoker) (() =>
                {
                    _ListaXR = Opcion.JsonaListaGenerica<Respuesta.Reporte.RespuestaCocina.RepoActRec>(jsonResult);
                    if (_ListaXR == null)
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
                        dgvrecetasact.DataSource = _ListaXR;
                    }

                }));
            });
        }
    }
}
