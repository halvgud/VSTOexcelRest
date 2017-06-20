using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Herramienta;
using Herramienta.Config;
using Respuesta;

namespace ExcelAddIn1
{
    public partial class Diario : Form
    {

        private List<Receta.Congelados2> _listaArticuloCongelado = new List<Receta.Congelados2>();
        private List<Receta.Congelados2> _listArticuloCongelado2=new List<Receta.Congelados2>();
        public int valor = -1;

        // private readonly List<unidad> _unidades;
        public Diario()
        {
            InitializeComponent();
            //_unidades = new List<unidad>();
        }

        //public class congelado
        //{ 
        //    public inid { get; set; }
        //    public String unidadd { get; set; }
        //}
        public List<Respuesta.Diario> lista;

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Diario_Load(object sender, EventArgs e)
        {
   
            string fecha = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd 07:00:00");
            string fecha1 = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd 21:00:00");
            var fechas = new Receta.Diaanterior
            {
                Fecha1 = fecha,
                Fecha2 = fecha1
            };
            
            Data.Reporte.AntesDiaanterior = fechas;
            var col2 = new DataGridViewImageColumn
            {
                Name = " ",
                DataPropertyName = " ",
                HeaderText = @" ",


            };

            // Local.ReporteAnterior.Fecha = fecha;
            var me = new MensajeDeEspera();
            me.Show();
            Opcion.EjecucionAsync(Data.Reporte.Yesterday, jsonResult =>
            {
                BeginInvoke((MethodInvoker) (() =>
                {
                    me.Close();
                 lista = Opcion.JsonaListaGenerica<Respuesta.Diario>(jsonResult);
                
            
                    dgDiario.Columns.Add(col2);
                    dgDiario.Columns[0].Width = 10;

                    dgDiario.RowHeadersVisible = false;
                    dgDiario.DataSource = lista;
                    dgDiario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
               
                }));
            });
           
         
        }

        private void chCongelados_CheckedChanged(object sender, EventArgs e)
        {
            if (chCongelados.Checked == true)
            {
                txtcongelados.Enabled = true;
                txtcongelados.Focus();
                
            }
            else
            {
                txtcongelados.Enabled = false;
                txtcongelados.Text = "";

            }
          
        }

        private void chMerma_CheckedChanged(object sender, EventArgs e)
        {
            if (chMerma.Checked == true)
            {
                txtmerma.Enabled = true;
                txtmerma.Focus();
              
            }
            else
            {
                txtmerma.Enabled = false;
                txtmerma.Text = "";
            }
            
        }

        private void chEmpleados_CheckedChanged(object sender, EventArgs e)
        {
            if (chEmpleados.Checked == true)
            {
                txtempleados.Enabled = true;
                txtempleados.Focus();
               

            }
            else
            {
                txtempleados.Enabled = false;
           
                txtempleados.Text = "";
            }
      
        }

        private void chReventa_CheckedChanged(object sender, EventArgs e)
        {
           
            

            if (chReventa.Checked == true)
            {
                txtreventa.Enabled = true;
                txtreventa.Focus();
                
            }
            else
            {
                txtreventa.Enabled = false;
                txtreventa.Text = "";
                            
            }

           
        }

        private void dgDiario_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            #region Sobrante Real
            double i = Convert.ToDouble(dgDiario.CurrentRow.Cells[3].Value);
            double y = Convert.ToDouble(dgDiario.CurrentRow.Cells[4].Value);
            dgDiario.Rows[e.RowIndex].Cells[6].Value =Math.Round(i-y, 2);
            #endregion


     
        }

  

        private void txtcongelados_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==13)
            {
                MessageBox.Show("hola");
               
            }

            
        }

        private void dgDiario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            valor = e.RowIndex;
            var t = lista[valor].ListaCantidades.Where(x=>x.EstadoDescripcionId==1);
               // txtcongelados.Text = (t as Respuesta.Diario.Cantidades).Cantidad.ToString();
            

        }

        private void txtcongelados_TextChanged(object sender, EventArgs e)
        {
            btguardardiario.Enabled = true;
        }

        private void txtmerma_TextChanged(object sender, EventArgs e)
        {
            btguardardiario.Enabled = true;
        }

        private void txtreventa_TextChanged(object sender, EventArgs e)
        {
            btguardardiario.Enabled = true;
        }

        private void btguardardiario_Click(object sender, EventArgs e)
        {
            var listEstado = new List<Receta.Savedaily>();
            if (chCongelados.Checked==true)
            {
                listEstado.Add(new Respuesta.Receta.Savedaily
                {
                    EstadoId = 1,
                    ArtId = dgDiario.CurrentRow.Cells[1].Value.ToString(),
                    Cantidad = Convert.ToDouble(txtcongelados.Text),
                    Clave = dgDiario.CurrentRow.Cells[2].Value.ToString(),
                    Platillo = dgDiario.CurrentRow.Cells[3].Value.ToString()
                });

            }
            if (chMerma.Checked == true)
            {
                listEstado.Add(new Receta.Savedaily
                {
                    EstadoId = 2,
                    ArtId = dgDiario.CurrentRow.Cells[1].Value.ToString(),
                    Cantidad = Convert.ToDouble(txtmerma.Text),
                    Clave = dgDiario.CurrentRow.Cells[2].Value.ToString(),
                    Platillo = dgDiario.CurrentRow.Cells[3].Value.ToString()
                });
            }
            if (chReventa.Checked == true)
            {
                listEstado.Add(new Receta.Savedaily
                {
                    EstadoId = 4,
                    ArtId = dgDiario.CurrentRow.Cells[1].Value.ToString(),
                    Cantidad = Convert.ToDouble(txtreventa.Text),
                    Clave = dgDiario.CurrentRow.Cells[2].Value.ToString(),
                    Platillo = dgDiario.CurrentRow.Cells[3].Value.ToString()
                });
            }
            Data.MenuSemanal.AgregarDiario(listEstado);
            //Opcion.EjecucionAsync(Data.MenuSemanal.AgregarDiario,jsonResult=>
            //BeginInvoke((MethodInvoker)(() =>
            //{
            //    switch (jsonResult.StatusCode)
            //    {
            //        case HttpStatusCode.OK:



            //            break;

            //    }
            //})));


        }
    }
}
