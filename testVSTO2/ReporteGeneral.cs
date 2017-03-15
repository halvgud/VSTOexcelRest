using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using Herramienta;
using Respuesta;

namespace testVSTO2
{
    public partial class ReporteGeneral : Form
    {
        private static ReporteGeneral _alreadyOpened;
        public ReporteGeneral(Func<string[]> arreglo)
        {
            if (_alreadyOpened != null && !_alreadyOpened.IsDisposed)
            {
                _alreadyOpened.Focus();            // Bring the old one to top
                Shown += (s, e) => Close();  // and destroy the new one.
                return;
            }

            // Otherwise store this one as reference
            _alreadyOpened = this;
            InitializeComponent();
            var allowedTypes = new AutoCompleteStringCollection();
            allowedTypes.AddRange(arreglo());
            txtTagProveedor.AutoCompleteCustomSource = allowedTypes;
            txtTagProveedor.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtTagProveedor.AutoCompleteSource = AutoCompleteSource.CustomSource;
            dtFechaIni.Value = dtFechaFin.Value.AddDays(-30);
            ActualizarBusquedas();
            //Show();
        }

        public ReporteGeneral()
        {
            if (_alreadyOpened != null && !_alreadyOpened.IsDisposed)
            {
                _alreadyOpened.Focus();            // Bring the old one to top
                Shown += (s, e) => Close();  // and destroy the new one.
               
            }
        }

        private void ActualizarBusquedas()
        {
            Data.Reporte.UltimosRegistros(x =>
            {
                var d = Opcion.JsonaListaGenerica<CbGenerico>(x).Select(y => y.Nombre).ToArray();
                BeginInvoke((MethodInvoker)(() =>
                {
                    labelUltimo1.Text = d[0];
                    labelUltimo2.Text = d[1];   
                    labelUltimo3.Text = d[2];
                }));

            });
        }

        private void txtTagProveedor_TextChanged(object sender, EventArgs e)
        {

        }
        //TODO: Generar evento que capture el enter y ejecute una tarea asincrona que traiga los proveedores del web service
        private void txtTagProveedor_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            Busqueda();
        }

        private void Busqueda()
        {
            Opcion.EjecucionAsync(obtenerDatos => Data.Proveedor.Buscar(obtenerDatos,
               new Proveedor { Alias = "", ProId = 0, Nombre = txtTagProveedor.Text }),//agregar que lo saque del dgv
               x =>
               {
                   BeginInvoke((MethodInvoker)(() =>
                   {
                       var bindingSource1 = new BindingSource
                       {
                           DataSource = Opcion.JsonaListaGenerica<Proveedor>(x)
                       };
                       dgvProveedor.DataSource = bindingSource1;
                       for (var i = 0; i < dgvProveedor.Columns.Count - 2; i++)
                       {
                           dgvProveedor.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                       }
                       dgvProveedor.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                       dgvProveedor.AllowUserToAddRows = false;
                   }));
               });
        }
        private void labelUltimo1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtTagProveedor.Text = labelUltimo1.Text;
            Busqueda();
        }

        private void dgvProveedor_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvProveedor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvProveedor.AutoResizeColumns();
            dgvProveedor.AllowUserToResizeColumns = true;
        }

        private void labelUltimo2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtTagProveedor.Text = labelUltimo2.Text;
            Busqueda();
        }

        private void labelUltimo3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtTagProveedor.Text = labelUltimo3.Text;
            Busqueda();
        }

        private void dgvProveedor_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex <dgvProveedor.Columns.Count-1&e.ColumnIndex>0) e.Cancel = true;
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            if (txtTagProveedor.Text.Trim() != "")
            {
                Busqueda();
            }
        }

        private void btGenerar_Click(object sender, EventArgs e)
        {
            //
            Opcion.EjecucionAsync(x =>
            {
                Data.Reporte.ActualizarUltimoRegistro(x,new Reporte.General{ProId = txtTagProveedor.Text});
            }, y =>
            {
               //aactualizar lista
            });
            var cancelar = false;
            var mse = new MensajeDeEspera(() =>
            {
                var continuarCancelacion = MessageBox.Show(@"¿Desea detener la operación?",
                @"Alerta",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);
                if (continuarCancelacion != DialogResult.Yes)
                    return false;
                cancelar = true;
                return true;
            });
            mse.Show();
            var addIn = Globals.ThisAddIn;
            var arregloList = new List<string>();
            for (var i = 0; i < dgvProveedor.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dgvProveedor[dgvProveedor.Columns.Count-1, i].Value))
                {
                    arregloList.Add(dgvProveedor[0, i].Value.ToString());
                }
            }
            if (arregloList.Count < 1)
            {
                BeginInvoke((MethodInvoker)(() =>
                {
                    MessageBox.Show(@"No se encontró registros con los parámetros utilizados");
                }));
                return;
            }
            var respuestaReporteGeneral = new Reporte.General
            {
                CatId =  "%",
                DepId =  "%",
                FechaFin = dtFechaFin.Value,
                FechaIni = dtFechaIni.Value,
                ProId="0",
                ProId2 = arregloList,
                OrderBy = "ORDER BY a.margen1 DESC",
                IdTipo =  "%"
            };
            Data.Reporte.FechaIni = dtFechaIni.Value;
            Data.Reporte.FechaFin = dtFechaFin.Value;
            Data.Reporte.Categoria = "%";
            Data.Reporte.Departamento = "%";
            Opcion.EjecucionAsync(x =>
            {
                if (cbImprimir.Checked)
                    Data.Reporte.Imprimir(x, respuestaReporteGeneral);
                else
                    Data.Reporte.General(x, respuestaReporteGeneral);

            }, y =>
            {
                BeginInvoke((MethodInvoker)(() =>
                {
                    if (y != null && !cancelar)
                        if(cbImprimir.Checked)
                            addIn.ReporteImprimir(y, () => CerrarCuadroDeEspera(mse));
                        else
                            addIn.ReporteGeneral(y, ()  => CerrarCuadroDeEspera(mse));
                    else
                    {
                        CerrarCuadroDeEspera(mse);
                        BeginInvoke((MethodInvoker)(() =>
                        {
                            MessageBox.Show(@"No se encontró registros con los parámetros utilizados");
                        }));
                    }
                }));
            });
        }
        private void CerrarCuadroDeEspera(MensajeDeEspera mse)
        {
            BeginInvoke((MethodInvoker)(() =>
            {
               mse.Close();
               Close();
            }));

        }
    }
}
