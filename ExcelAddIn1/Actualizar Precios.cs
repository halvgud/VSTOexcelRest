using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

        public class Alerta
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
        }

        public BindingList<Reporte.RespuestaCocina.TablaPreciosNuevos> _listaXr;
        public List<Receta.IngredientesRecetaPrecio> ListIngredientesRecetaPrecios;
        public Reporte.RespuestaCocina.TablaPreciosNuevos LisTablaPreciosNuevos;
        public BindingList<Reporte.RespuestaCocina.TablaPreciosNuevos.MostrarTablaPreciosNuevos>  listaBinding;

        // public List<Reporte.RespuestaCocina.RepoActRec> ListaXr;

        private void Actualizar_Precios_Load(object sender, EventArgs e)
        {
            dgvrecetasact.Tag=new Alerta
            {
                Id = 1,
                Nombre = "Eliminar"
            };
         

          
            Opcion.EjecucionAsync(Data.Reporte.PreciosActualizarTabla, jsonResult =>
            {
                BeginInvoke((MethodInvoker)(() =>
                {
                    var lista =
                        Opcion.JsonaListaGenerica<Reporte.RespuestaCocina.TablaPreciosNuevos>(jsonResult);
                      _listaXr = new BindingList<Reporte.RespuestaCocina.TablaPreciosNuevos>(lista);
                      //                            Lunes = new BindingList<MenuDia>(Opcion.JsonaClaseGenerica2<Respuesta.MenuSemanal>(jsonResult).Lunes);

                     // LisTablaPreciosNuevos = Opcion.JsonaListaGenerica<Reporte.RespuestaCocina.TablaPreciosNuevos>(jsonResult)[0];
                      var col = new DataGridViewCheckBoxColumn
                      {
                          Name = "Alertagh",
                          DataPropertyName = "Alertagh",
                          HeaderText = @"Alerta",

                          //DataSource = _tiposrecetas,
                          //DisplayMember = "Alerta",
                          //ValueMember = "TipoReceta"
                      };


                      


                      dgvrecetasact.Columns.Add(col);
                    listaBinding =
                        new BindingList<Reporte.RespuestaCocina.TablaPreciosNuevos.MostrarTablaPreciosNuevos>(_listaXr
                        .Where(x => x.Modificacion == "Actualizar")
                        .Select(p => new Reporte.RespuestaCocina.TablaPreciosNuevos.MostrarTablaPreciosNuevos
                       {
                          Clave=  p.Clave,
                            Platillo=p.Platillo,
                            Alertagh=p.Alertagh
                            //en donde le agregaste la columna 
                            //cual es la funcion de php que manda traer esto
                        }).ToList());
                    dgvrecetasact.DataSource = listaBinding;
                    dgvrecetasact.Columns[2].ReadOnly = false;
                        dgvrecetasact.Columns["Platillo"].DefaultCellStyle.Alignment =
                          DataGridViewContentAlignment.TopLeft;
                      dgvrecetasact.Columns["Platillo"].Width = 220;
                      dgvrecetasact.Columns["Clave"].Width = 80;
                    dgvrecetasact.Columns["Platillo"].ReadOnly=true;
                    dgvrecetasact.Columns["Clave"].ReadOnly = true;
                    //var objeto = dgvrecetasact.Tag as Alerta;
                    //if (objeto != null)
                    //    dgvrecetasact.DataSource = dgvrecetasact.Tag as List<Reporte.RespuestaCocina.TablaPreciosNuevos>;
                    dgvrecetasact.Columns["Alertagh"].DisplayIndex = 2;
                      //dgvrecetasact.Columns["Alertagh"].Width = 80;

                  }));
                
            });




        }
        //valuechanged
        private Int32 rowIndex = -1;
        private void dgvrecetasact_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Cocina.RecetaActPrecio.Clave = dgvrecetasact.CurrentRow.Cells["Clave"].Value.ToString();
            rowIndex = e.RowIndex;
            Opcion.EjecucionAsync(Data.Reporte.PreciosTablaIngredientes, JsonResult =>
            {
                BeginInvoke((MethodInvoker)(() =>
                {
                    List<int> lista = new List<int>();
                    var w = Opcion.JsonaListaGenerica<Reporte.RespuestaCocina.IngredientesReceta>(JsonResult);
                    dgingredientesReceta.DataSource = w;

                    dgingredientesReceta.Columns["RecId"].Visible = false;
                    dgingredientesReceta.Columns["Status"].Visible = false;

                    dgingredientesReceta.Columns["Ingrediente"].DefaultCellStyle.Alignment=DataGridViewContentAlignment.TopLeft;
                    dgingredientesReceta.Columns["Ingrediente"].Width = 100;
                    dgingredientesReceta.ReadOnly = true;
                    dgingredientesReceta.Columns["Precio_Viejo"].DefaultCellStyle.Alignment=DataGridViewContentAlignment.MiddleCenter;
                    dgingredientesReceta.Columns["Precio_Nuevo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                 

                    //dgingredientesReceta.Columns.Add()

                }));
              
            });
     

            lbplatillo.Text = dgvrecetasact.CurrentRow.Cells["Platillo"].Value.ToString();

            var chk1 = listaBinding[rowIndex].Alertagh;
            
            if (e.ColumnIndex == 2)
            {
                Cocina.RecetaActPrecio.Clave = dgvrecetasact.CurrentRow.Cells["Clave"].Value.ToString();
                Data.Reporte.EliminarRegistroPrecioAct(j =>
                {
                    BeginInvoke((MethodInvoker)(() =>
                    {
                        var col = new DataGridViewCheckBoxColumn
                        {
                            Name = "Alerta",
                            //DataPropertyName = "TipoRecetaDgv",
                            HeaderText = @"Eliminar Alerta",
                            //DataSource = _tiposrecetas,
                            //DisplayMember = "TipoReceta",
                            //ValueMember = "TipoReceta"
                        };
                        dgvrecetasact.Columns.Clear();
                        Opcion.EjecucionAsync(Data.Reporte.PreciosActualizarTabla, jsonResult =>
                        {
                            BeginInvoke((MethodInvoker)(() =>
                            {
                                _listaXr = new BindingList<Reporte.RespuestaCocina.TablaPreciosNuevos>(Opcion.JsonaListaGenerica<Reporte.RespuestaCocina.TablaPreciosNuevos>(jsonResult));

                                LisTablaPreciosNuevos = Opcion.JsonaListaGenerica<Reporte.RespuestaCocina.TablaPreciosNuevos>(jsonResult)[0];
                                dgvrecetasact.DataSource = _listaXr.Where(x => x.Modificacion == "Actualizar").Select(p => new
                                {
                                    Clave = p.Clave,
                                    Platillo = p.Platillo,
                                }).ToList();

                                int w = dgvrecetasact.RowCount;
                                if (w==0)
                                {
                                    dgingredientesReceta.DataSource=null;
                                   // dgingredientesReceta.Columns.Clear();
                                    dgingredientesReceta.Refresh();
                                    lbplatillo.Text = " ";
                                }
                                /*en que punto le das matarile a la fila?*/

                                dgvrecetasact.Columns["Platillo"].DefaultCellStyle.Alignment =
                                    DataGridViewContentAlignment.TopLeft;
                                dgvrecetasact.Columns["Platillo"].Width = 220;
                                dgvrecetasact.Columns["Clave"].Width = 80;
                                dgvrecetasact.Columns["Platillo"].ReadOnly = true;
                                dgvrecetasact.Columns["Clave"].ReadOnly = true;

                                dgvrecetasact.Columns.Add(col);
                                dgvrecetasact.Columns["Alerta"].DisplayIndex = 2;
                                dgvrecetasact.Columns["Alerta"].Width = 80;

                            }));

                        });

                    }));

                });
            }
            else
            {

            }


            //foreach (DataGridViewRow row in dgvrecetasact.Rows)
            //{
            //    // number 3 represents the 4th column of dgv

            //}

            //DataGridViewCheckBoxColumn checkBox = dgvrecetasact.Rows[e.RowIndex].Cells["Alerta"] as DataGridViewCheckBoxColumn;


        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dgvrecetasact_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {


                //sigues hay viejo sip, vete con f11, tienes que agregar una columna en el json que sea valores 0, y luego esa la conviertes al datatable...Aimee tiene algo de eso creo
                // no con checkbox, pero si con combobox... es mas o menos parecido... preg sobre el de inicializar dgv, hay una parte que asigna el combobox a una columna del json
                // ps asi...
               

            

        }
    }
}
