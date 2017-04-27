using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Herramienta;
using Herramienta.Config;
using Respuesta;


namespace ExcelAddIn1
{
    public partial class Congelados : Form
    {

        //private List<Articulo.Basica> _listaArticuloBasica1;

        public char KeyChar { get; set; }
        private List<Articulo.Basica> _listaArticuloBasica1;

        private List<Respuesta.CbGenerico> _listaplatillo;

        private List<Respuesta.Agregarcongelados> _listaagregarcongelados;
        public Boolean validacion;

        //private List<Respuesta.CbGenerico> _listaplatillo; 


        public class Inputs
        {
            public TextBox Nombre;
            public DataGridView ListaCongelados;
        }



        private static Congelados _alreadyOpened;
        public Congelados(Func<string[]> arreglo)
        {
            if (_alreadyOpened != null && !_alreadyOpened.IsDisposed)
            {
                _alreadyOpened.Focus();            // Bring the old one to top
                Shown += (s, e) => Close();  // and destroy the new one.
                return;
            }
            _alreadyOpened = this;
            InitializeComponent();
            var allowedTypes = new AutoCompleteStringCollection();
            allowedTypes.AddRange(arreglo());
            //txtbuscarcongelado.AutoCompleteCustomSource = allowedTypes;
            //txtbuscarcongelado.AutoCompleteMode = AutoCompleteMode.Suggest;
            //txtbuscarcongelado.AutoCompleteSource = AutoCompleteSource.CustomSource;

            txtbuscarcongeladoeditar.AutoCompleteCustomSource = allowedTypes;
            txtbuscarcongeladoeditar.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtbuscarcongeladoeditar.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }
        public Congelados()
        {
            if (_alreadyOpened != null && !_alreadyOpened.IsDisposed)
            {
                _alreadyOpened.Focus();            // Bring the old one to top
                Shown += (s, e) => Close();  // and destroy the new one.

            }
        }

        
        private bool ValidarVacia()
        {
            return txtbuscarcongelado.Text.Trim().Length > 0;
        }

        private void Congelados_Load(object sender, EventArgs e)
        {
            ActiveControl = txtbuscarcongelado;
            txtbuscarcongelado.Focus();
        }
        
        private void btbuscareditar_Click(object sender, EventArgs e)
        {
            Cocina.buscarcongelados.descripcion = txtbuscarcongeladoeditar.Text == string.Empty ? "%" : txtbuscarcongeladoeditar.Text;  /* asigna la clave a la variable estatica*/
            Opcion.EjecucionAsync(Data.ReporteCocina.Buscarcongelados, jsonResult => /* se ejecuta Data.Receta.Lista, el resultado se guarda en jsonResult*/
            {
                BeginInvoke((MethodInvoker)(() =>
                {
                    switch (jsonResult.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            var lista = Opcion.JsonaListaGenerica<Receta.Congelados>(jsonResult);
                            var brd = /*aqui que ondas */
                             new BuscarCongelados(lista, /*esta parte no le entiendo*/
                                 resultado =>
                                 {
                                     BeginInvoke((MethodInvoker)(() => /*se manda llamar de nuevo a la interfaz*/
                                     {
                                         dgvcongeladobuscaryeditar.DataSource = resultado.Select(g => new {g.estado_id, g.clave, g.descripcion, g.cantidad, g.status, g.fechaEntrada}) /*ni estas*/
                                          .ToList();
                                     }));
                                 },lista.ToArray(),0);

                            brd.Show(); /*se muestra*/
                            break;
                        default:
                            MessageBox.Show(this, @"No se encontraron recetas con los parametros de busqueda ingresados");
                            Console.WriteLine(jsonResult.Content);
                            break;
                    }

                }));
            });
        }


        private void btguardareditar_Click(object sender, EventArgs e)
        {

            int id = Convert.ToInt16(dgvcongeladobuscaryeditar.CurrentRow.Cells[0].Value);
            double canttidad = Convert.ToDouble(dgvcongeladobuscaryeditar.CurrentRow.Cells[3].Value);
            ///*aqui el problema es que estas creando el objeto despues de la ejecucion y es alreves
            // deja lo formo*/
            //;


            mse.Show();
            //var congeladosagregar = new Receta.Congelados
            //{
            //    estado_id = id,
            //    cantidad = canttidad

            //};
            //Data.ReporteCocina.Cccongelados = congeladosagregar;
            //Data.ReporteCocina.AgregarCongelados(y => {
            //    BeginInvoke((MethodInvoker)(() =>
            //    {
            //        mse.Close();
            //        dgvcongelados.DataSource = null;
            //        dgvcongelados.Rows.Clear();
            //        txtbuscarcongelado.Clear();

            //    }));
            //});

            var congeladosactualizar = new Receta.Congelados
            {
                estado_id = Convert.ToInt16(dgvcongeladobuscaryeditar.CurrentRow.Cells[0].Value),
                cantidad = double.Parse(dgvcongeladobuscaryeditar.CurrentRow.Cells[3].Value.ToString())
            };

            //Data.ReporteCocina.ActualizarCongelado
            Data.ReporteCocina.Cccongelados = congeladosactualizar;
            Data.ReporteCocina.ActualizarCongelado(y => {
                BeginInvoke((MethodInvoker)(() =>
                {
                    mse.Close();
                    dgvcongeladobuscaryeditar.DataSource = null;
                    dgvcongeladobuscaryeditar.Rows.Clear();
                    txtbuscarcongeladoeditar.Clear();

                }));
            }); 

            //MessageBox.Show("Datos actualizados");
            //dgvcongeladobuscaryeditar.DataSource = null;
            //dgvcongeladobuscaryeditar.Rows.Clear();


        }


        private void txtbuscarcongeladoeditar_TextChanged(object sender, EventArgs e)
        {

        }

       

        private void txtbuscarcongelado_KeyDown(object sender, KeyEventArgs e)
        {
           
           
           if (e.KeyCode == Keys.Enter)
            {

                if (tabControl1.SelectedTab == tabControl1.TabPages[0])
                {
                    
                }
                /*ya de aqui me encargo pero primero activo el office jeje*/
                    Cocina.buscarcongelados.descripcion = txtbuscarcongelado.Text == string.Empty ? "%" : txtbuscarcongelado.Text;  /* asigna la clave a la variable estatica*/
                Opcion.EjecucionAsync(Data.ReporteCocina.agregar_congeladobuscar, jsonResult => /* se ejecuta Data.Receta.Lista, el resultado se guarda en jsonResult*/
                {
                    BeginInvoke((MethodInvoker)(() =>
                    {
                        switch (jsonResult.StatusCode)
                        {
                            case HttpStatusCode.OK:

                                var lista = Opcion.JsonaListaGenerica<Respuesta.Receta.Congelados>(jsonResult);

                                var brd = new BuscarCongelados(lista, /*esta parte no le entiendo*/
                                    resultado =>
                                    {
                                        BeginInvoke((MethodInvoker) (() => /*se manda llamar de nuevo a la interfaz*/
                                        {
                                            dgvcongelados.DataSource =
                                                resultado.Select(x => new {x.art_id, x.clave, x.descripcion, x.cantidad})
                                                    /*ni estas*/
                                                    .ToList();


                                        }));
                                    },//aaa eso era jeje ya lo demas me encargo yo que es q mande al data de agregar y con el boton gia
                                    lista.Select(
                                        x =>
                                            new
                                            {
                                                x.art_id,
                                                x.clave,
                                                x.descripcion
                                            }).ToArray(),1);
                                
                    
                                brd.Show(); /*se muestra*/
                                break;
                            default:
                                MessageBox.Show(this, @"No se encontro el producto en la busqueda ");
                                Console.WriteLine(jsonResult.Content);
                                break;
                        }

                    }));
                });


                //Agregar_Congelados frm = new Agregar_Congelados();
                //frm.lbdescripcion.Text = txtbuscarcongelado.Text;
                //frm.Show();




            }

        }
        MensajeDeEspera mse = new MensajeDeEspera();
        private void btguardaragregar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(dgvcongelados.CurrentRow.Cells[0].Value);
            string Clavee = dgvcongelados.CurrentRow.Cells[1].Value.ToString();
            string descrippcion = dgvcongelados.CurrentRow.Cells[2].Value.ToString();
            double canttidad = Convert.ToDouble(dgvcongelados.CurrentRow.Cells[3].Value);
            /*aqui el problema es que estas creando el objeto despues de la ejecucion y es alreves
             deja lo formo*/;


            mse.Show();
            var congeladosagregar = new Receta.Congelados
            {
                art_id = id,
                clave = Clavee,
                descripcion = descrippcion,
                cantidad = canttidad

            };
            Data.ReporteCocina.Cccongelados = congeladosagregar;
            Data.ReporteCocina.AgregarCongelados(y => {
            BeginInvoke((MethodInvoker)(() =>
            {
                mse.Close();
                dgvcongelados.DataSource = null;
                dgvcongelados.Rows.Clear();
                txtbuscarcongelado.Clear();
                
            }));
            });
           
           
           


            //var congelados = new Receta.Congelados
            //{
            //    art_id = Convert.ToInt16(dgvcongelados.CurrentRow.Cells[0].Value),
            //    clave =
            //        dgvcongelados.CurrentRow.Cells[1].Value.ToString() == string.Empty
            //            ? "%"
            //            : dgvcongelados.CurrentRow.Cells[1].Value.ToString(),
            //    descripcion =
            //        dgvcongelados.CurrentRow.Cells[2].Value.ToString() == string.Empty
            //            ? "%"
            //            : dgvcongelados.CurrentRow.Cells[2].Value.ToString(),
            //    cantidad = double.Parse(dgvcongelados.CurrentRow.Cells[3].Value.ToString())
            //};

            //Data.ReporteCocina.AgregarCongelados(congelados);

            // MessageBox.Show("Agregado con exito");
            //dgvcongelados.DataSource = null;
            //dgvcongelados.Rows.Clear();

            //Cocina.AgregarCongelados.art_id = int.Parse(dgvcongelados.CurrentRow.Cells[0].Value.ToString());

            //Cocina.AgregarCongelados.clave = dgvcongelados.CurrentRow.Cells[1].Value.ToString() == string.Empty ? "%" : dgvcongelados.CurrentRow.Cells[1].Value.ToString();
            //Cocina.AgregarCongelados.descripcion = dgvcongelados.CurrentRow.Cells[2].Value.ToString() == string.Empty ? "%" : dgvcongelados.CurrentRow.Cells[2].Value.ToString();  /* asigna la clave a la variable estatica*/

            //Cocina.AgregarCongelados.cantidad = double.Parse(dgvcongelados.CurrentRow.Cells[3].Value.ToString());


        }

        private void tpbuscaryeditar_Click(object sender, EventArgs e)
        {

        }
    }

    internal class Controls
    {

    }
}
