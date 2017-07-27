using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Herramienta;
using Herramienta.Config;
using Microsoft.Office.Core;
using Respuesta;

namespace ExcelAddIn1
{
    public partial class Diario : Form
    {

       // private List<Receta.Congelados2> _listArticuloCongelado2=new List<Receta.Congelados2>();
        public int valor = 0;
        public int INNdex;
        public int IndeXX;

        private readonly List<final> _endList;
        public Diario()
        {
            InitializeComponent();
            _endList = new List<final>();
        }

        public class final
        {
            public int id { get; set; }
            public String destino { get; set; }
            
        }
    public List<Respuesta.Diario> lista;
        public List<Respuesta.DiarioX2> ListaX2s;
        public List<Reporte.RespuestaCocina.Comprobacion> _ListDiarioDs;
        public int XYZ;
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Diario_Load(object sender, EventArgs e)
        {
            //borrar si ya fue guardado el dato



     

            #region fechas

            string fecha = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd 07:00:00");
            string fecha1 = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd 21:00:00");
            string fecha1R = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd 00:00:00");
            var fechas = new Receta.Diaanterior
            {
                Fecha1 = fecha,
                Fecha2 = fecha1
            };

            Data.Reporte.AntesDiaanterior = fechas;
            Cocina.DiaAntesX2.FechaX2 = fecha1R;
            #endregion

            _endList.Add(new final {destino = "CONGELADO",  id = 1});
            _endList.Add(new final {destino="MERMA",id=2});
            _endList.Add(new final {destino="EMPLEADOS", id=3});

            dgreventa.Tag =new final { destino = "CONGELADO", id = 1 };
            dgreventa.Tag=new final { destino = "MERMA", id = 2 };
            dgreventa.Tag=new final { destino = "EMPLEADOS", id = 3 };
            var col2 = new DataGridViewImageColumn
            {
                Name = "Guardar",
                DataPropertyName = " ",
                HeaderText = @"",
                
            };

            var col3 = new DataGridViewComboBoxColumn
            {
             Name = "Destino",
             DataPropertyName = "Destino",
             HeaderText = @"Destino",
             DataSource = _endList,
             DisplayMember = "destino",
             ValueMember = "destino"     
            };

            var me = new MensajeDeEspera();
            me.Show();



                Opcion.EjecucionAsync(Data.Reporte.Yesterday, jsonResult =>
                {
                    BeginInvoke((MethodInvoker)(() =>
                    {
                        me.Close();
                        lista = Opcion.JsonaListaGenerica<Respuesta.Diario>(jsonResult);

                        dgDiario.RowHeadersVisible = false;
                        dgDiario.DataSource = lista;
                        dgDiario.Columns.Add(col2);
                        dgDiario.Columns["Guardar"].DisplayIndex = 9;
                        dgDiario.DefaultCellStyle.Font = new Font("Segoe UI Light", 8, FontStyle.Bold);
                        dgDiario.Columns["Guardar"].Width = 25;
                        dgDiario.Columns[0].Visible = false;
                        dgDiario.Columns[1].Width = 70;
                        dgDiario.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dgDiario.Columns[2].Width = 150;
                        dgDiario.Columns[3].Width = 40;
                        dgDiario.Columns[4].Width = 40;
                        dgDiario.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dgDiario.Columns[5].Width = 40;
                        dgDiario.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dgDiario.Columns[6].Width = 60;
                        dgDiario.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dgDiario.Columns[7].Width = 30;
                        dgDiario.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dgDiario.Columns[8].Width = 30;
                        dgDiario.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dgDiario.Columns[9].Width = 30;
                        dgDiario.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dgDiario.Columns[10].Width = 30;
                        dgDiario.Columns["Observacion"].Width = 200;

                        dgDiario.Columns["CC"].DefaultCellStyle.BackColor = Color.Coral;
                        dgDiario.Columns["SR"].DefaultCellStyle.BackColor = Color.Coral;
                    }));




                });

       



                Opcion.EjecucionAsync(Data.Reporte.Before, jsonResult =>
                {
                    BeginInvoke((MethodInvoker)(() =>
                    {
                        me.Close();

                        ListaX2s = Opcion.JsonaListaGenerica<Respuesta.DiarioX2>(jsonResult);
                        if (ListaX2s.Count == 0)
                        {
                            var listavacia = new Respuesta.DiarioX2
                            {
                                ArtId = "",
                                Clave = "",
                                Platillo = "",
                                RV = 0,
                                SR = 0,
                                S = 0,
                                CR = 0,
                                EstadoId = 0,
                                Fecha = ""
                            };
                            dgreventa.DataSource = listavacia;

                        }
                        else
                        {
                            dgreventa.DataSource = ListaX2s;
                            dgreventa.Columns[8].Visible = false;
                            dgreventa.Columns.Add(col3);
                            dgreventa.DefaultCellStyle.Font = new Font("Segoe UI Light", 8, FontStyle.Bold);
                            dgreventa.Columns[0].Width = 50;
                            dgreventa.Columns[0].ReadOnly = true;
                            dgreventa.Columns[1].Width = 50;
                            dgreventa.Columns[1].ReadOnly = true;
                            dgreventa.Columns[2].Width = 150;
                            dgreventa.Columns[2].ReadOnly = true;
                            dgreventa.Columns[3].Width = 40;
                            dgreventa.Columns[3].ReadOnly = true;
                            dgreventa.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            dgreventa.Columns[4].Width = 40;
                            dgreventa.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            dgreventa.Columns[5].Width = 40;
                            dgreventa.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            dgreventa.RowHeadersVisible = false;
                            dgreventa.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            dgreventa.Columns[6].Width = 80;

                        }



                    }));
                });

          
            Data.Reporte.RepDiarioAct(jsonResult =>
            {
                if (jsonResult!=null)
                {

                    BeginInvoke((MethodInvoker)(() =>
                    {
                        _ListDiarioDs = Opcion.JsonaListaGenerica<Respuesta.Reporte.RespuestaCocina.Comprobacion>(jsonResult);
                        for (int i = 0; i < dgDiario.RowCount; i++)
                        {
                            string y = dgDiario.Rows[i].Cells["Platillo"].Value.ToString();
                            for (int j = 0; j < _ListDiarioDs.Count; j++)
                            {
                                string x = _ListDiarioDs[j].Platillo;
                                if (x == y)
                                {
                                    XYZ = i;
                                    ((DataGridViewImageColumn)dgDiario.Columns["Guardar"]).ImageLayout = DataGridViewImageCellLayout.Stretch;
                                    dgDiario.Rows[i].Cells["CC"].Value = _ListDiarioDs[j].CC;
                                    //dgDiario.Columns[0].ima
                                    //dgDiario.CurrentRow.Cells[0].DefaultCellStyle = DataGridViewImageCell.MeasureTextPreferredSize(50, 50);
                                    dgDiario.Rows[i].Cells["Guardar"].Value = Image.FromFile(@"\\mercattoserver\Recetario\icon\correcto.jpg");
                                    dgDiario.Rows[i].ReadOnly = true;


                                }
                            }


                        }
                    }));
                }


            });








        }

        private void dgDiario_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {


            #region Sobrante Real
                double i = Convert.ToDouble(dgDiario.Rows[XYZ].Cells[4].Value);
                double y = Convert.ToDouble(dgDiario.Rows[XYZ].Cells[5].Value);
                dgDiario.Rows[e.RowIndex].Cells["S"].Value = Math.Round(i - y, 2);
            var sup = Math.Round(i - y, 2);
            #endregion

            if (sup == 0)
            {
                btguardardiario.Enabled = true;

            }







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
            XYZ = e.RowIndex;
            //var t = lista[valor].ListaCantidades.Where(x=>x.EstadoDescripcionId==1);
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
            var estado = 1;
            
            var listEstado = new List<Receta.Savedaily>();
            if (Convert.ToInt16(dgDiario.CurrentRow.Cells["S"].Value) == 0)
            {
                estado = -1;
                listEstado.Add(new Respuesta.Receta.Savedaily
                {
                    EstadoId = 5,
                    ArtId = dgDiario.CurrentRow.Cells[0].Value.ToString(),
                    Cantidad = 0,
                    Clave = dgDiario.CurrentRow.Cells[1].Value.ToString(),
                    Platillo = dgDiario.CurrentRow.Cells[2].Value.ToString(),
                    CantidadCocina = Convert.ToDouble(dgDiario.CurrentRow.Cells["CC"].Value),
                    Status = estado.ToString()

                });

                Data.MenuSemanal.savedaily = listEstado;
                Opcion.EjecucionAsync(Data.MenuSemanal.AgregarDiario, jsonResult =>
                {
                    BeginInvoke((MethodInvoker)(() =>
                    {
                        ((DataGridViewImageColumn)dgDiario.Columns["Guardar"]).ImageLayout = DataGridViewImageCellLayout.Stretch;
                        // dgDiario.Columns[0].ima
                        // dgDiario.CurrentRow.Cells[0].DefaultCellStyle = DataGridViewImageCell.MeasureTextPreferredSize(50, 50);
                        dgDiario.Rows[XYZ].Cells["Guardar"].Value = Image.FromFile(@"\\mercattoserver\Recetario\icon\correcto.jpg");
                        dgDiario.Rows[XYZ].ReadOnly = true;
                    }));


                });
                //MessageBox.Show("Dato guardado");
            }
            else
            {
                
                if (rbcongelado.Checked == true)
                {
                    listEstado.Add(new Respuesta.Receta.Savedaily
                    {
                        EstadoId = 1,
                        ArtId = dgDiario.CurrentRow.Cells[0].Value.ToString(),
                        Cantidad = Convert.ToDouble(txtcongelados.Text),
                        Clave = dgDiario.CurrentRow.Cells[1].Value.ToString(),
                        Platillo = dgDiario.CurrentRow.Cells[2].Value.ToString(),
                        CantidadCocina = Convert.ToDouble(dgDiario.CurrentRow.Cells["CC"].Value),
                        Status = estado.ToString()
                    });

                }
                if (rbmerma.Checked == true)
                {
                    listEstado.Add(new Receta.Savedaily
                    {
                        EstadoId = 2,
                        ArtId = dgDiario.CurrentRow.Cells[0].Value.ToString(),
                        Cantidad = Convert.ToDouble(txtmerma.Text),
                        Clave = dgDiario.CurrentRow.Cells[1].Value.ToString(),
                        Platillo = dgDiario.CurrentRow.Cells[2].Value.ToString(),
                        CantidadCocina = Convert.ToDouble(dgDiario.CurrentRow.Cells["CC"].Value),
                        Status = estado.ToString()
                    });
                }
                if (rbreventa.Checked == true)
                {
                    listEstado.Add(new Receta.Savedaily
                    {
                        EstadoId = 4,
                        ArtId = dgDiario.CurrentRow.Cells[0].Value.ToString(),
                        Cantidad = Convert.ToDouble(txtreventa.Text),
                        Clave = dgDiario.CurrentRow.Cells[1].Value.ToString(),
                        Platillo = dgDiario.CurrentRow.Cells[2].Value.ToString(),
                        CantidadCocina = Convert.ToDouble(dgDiario.CurrentRow.Cells["CC"].Value),
                        Status = estado.ToString()
                    });
                }
                Data.MenuSemanal.savedaily = listEstado;
                Opcion.EjecucionAsync(Data.MenuSemanal.AgregarDiario, jsonResult =>
                {
                    BeginInvoke((MethodInvoker)(() =>
                    {
                        ((DataGridViewImageColumn)dgDiario.Columns["Guardar"]).ImageLayout = DataGridViewImageCellLayout.Stretch;
                        // dgDiario.Columns[0].ima
                        // dgDiario.CurrentRow.Cells[0].DefaultCellStyle = DataGridViewImageCell.MeasureTextPreferredSize(50, 50);
                        dgDiario.Rows[XYZ].Cells["Guardar"].Value = Image.FromFile(@"\\mercattoserver\Recetario\icon\correcto.jpg");
                        dgDiario.Rows[XYZ].ReadOnly = true;
                    }));
                   

                });
                //var xx =new Diario();
                //xx.Show();
                
                

                



            }

        }

        private void rbcongelado_CheckedChanged(object sender, EventArgs e)
        {
            txtcongelados.Enabled = true;
            txtcongelados.Focus();
            txtcongelados.Visible = true;
            txtmerma.Text = "";
            txtmerma.Visible = false;
            txtreventa.Text = "";
            txtreventa.Visible = false;
            btguardardiario.Enabled = Validar();

        }

        private void rbmerma_CheckedChanged(object sender, EventArgs e)
        {
            txtmerma.Enabled = true;
            txtmerma.Focus();
            txtmerma.Visible = true;
            txtcongelados.Text = "";
            txtcongelados.Visible = false;
            txtreventa.Text = "";
            txtreventa.Visible = false;
            btguardardiario.Enabled = Validar();
        }

        private void rbreventa_CheckedChanged(object sender, EventArgs e)
        {
            txtreventa.Enabled = true;
            txtreventa.Focus();
            txtreventa.Visible = true;
            txtcongelados.Text = "";
            txtcongelados.Visible = false;
            txtmerma.Text = "";
            txtmerma.Visible = false;
            btguardardiario.Enabled = Validar();
            
        }

        private bool Validar()
        {
            return (txtreventa.Focus() == true || txtcongelados.Focus() == true || txtmerma.Focus() == true);
        }

        private void dgreventa_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {



          
            //double x = Convert.ToDouble(dgreventa.CurrentRow.Cells[3].Value);
            //double y = Convert.ToDouble(dgreventa.CurrentRow.Cells[4].Value);
            //dgreventa.Rows[e.RowIndex].Cells[5].Value = Math.Round(x - y, 2);

            //if (Convert.ToDouble(dgreventa.CurrentRow.Cells));

        }

        private void btguardarRV_Click(object sender, EventArgs e)
        {
            int index = Convert.ToInt16(dgreventa.CurrentRow.Cells[8].Value.ToString());
            Cocina.DiaAntesX2.EstadoId = index;
            if (Convert.ToDouble(dgreventa.CurrentRow.Cells[6].Value) == 0)
            {

               
                MessageBox.Show("guardado");
                Opcion.EjecucionAsync(Data.Reporte.ActX2, jsonResult =>
                {
                    BeginInvoke((MethodInvoker)(() =>
                    {
                       Opcion.BorrarSeleccionRV(dgreventa);
                        dgreventa.Columns["Destino"].DisplayIndex = 9;
                        dgreventa.Columns["EstadoId"].Visible = false;
                        
                        //guardado sin destino
                    }));
                });




            }

            else
            {
                //MessageBox.Show("no guardar sin antes poner el destino");

                //var xx = (dgreventa.Tag as final).id;
                var Mfecha = new Cocina.DiaAntesX2.DestinoDif {
                    EstadoId = Convert.ToInt16(dgreventa.Rows[INNdex].Cells[8].Value),
                    Id = (dgreventa.Tag as final).id
                 };

                Data.MenuSemanal.Destino = Mfecha;
                Cocina.DiaAntesX2.EstadoId = index;

                Opcion.EjecucionAsync(Data.MenuSemanal.ActualizarX2Fecha, jsonResult =>
                {



                    BeginInvoke((MethodInvoker)(() =>
                    {
                        Data.MenuSemanal.ActualizarX2Destino();
                        MessageBox.Show("Dato actualizado","Aceptar",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        Opcion.BorrarSeleccionRV(dgreventa);
                        dgreventa.Columns["Destino"].DisplayIndex = 9;
                        dgreventa.Columns["EstadoId"].Visible = false;


                        //guardado con destino
                    }
                    //
                    ));
                    
                });
                //




            }
            
        }

        private void dgreventa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgreventa_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (Convert.ToDouble(dgreventa.Rows[INNdex].Cells[6].Value) == 0)
            {

                dgreventa.Rows[INNdex].DefaultCellStyle.BackColor = Color.Green;
                //dgreventa.Rows[valor].Cells[8].Value=null;
                dgreventa.Rows[INNdex].Cells[8].ReadOnly = true;
                btguardarRV.Enabled = validacionvacio();



            }
            else
            {
                dgreventa.Rows[INNdex].DefaultCellStyle.BackColor = Color.Red;
                dgreventa.Rows[INNdex].Cells[8].ReadOnly = false;
                btguardarRV.Enabled = validacionReventa();
            }


        }

        private void dgreventa_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            INNdex = e.RowIndex;
        }

        public bool validacionReventa()
        {
            
            
            if (Convert.ToInt16(dgreventa.Rows[INNdex].Cells[6].Value) == 0)
            {
                dgreventa.Rows[valor].Cells["Destino"].Value = null;
            }
            
            return (dgreventa.Rows[INNdex].Cells["Destino"].Selected/* || dgreventa.Rows[INNdex].Cells[8].Value != null*/);
        }

        public bool validacionvacio()
        {
            if (Convert.ToInt16(dgreventa.Rows[INNdex].Cells[6].Value) == 0)
                {
                    dgreventa.Rows[INNdex].Cells["Destino"].Value = null;
                }
            return (dgreventa.Rows[INNdex].Cells["Destino"].Value==null);
        }


  

        private void dgDiario_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            //if (Convert.ToInt16(dgDiario.Rows[valor].Cells[9].Value) == 0)
            //{
            //    btguardardiario.Enabled = true;
            //}
        }

        private void reporteDiarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var DD = new DiarioCocina();
            DD.Show();
        }
    }
}
