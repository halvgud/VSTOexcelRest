using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using Herramienta;
using Herramienta.Config;
using Respuesta;


namespace ExcelAddIn1
{
    public partial class Congelados : Form
    {
        private List<Receta.Congelados> _listagregarcongelado1;
        public char KeyChar { get; set; }
        private List<Receta.Congelados> _listaagregarcongelado2;
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
            Cocina.Buscarcongelados.Descripcion = txtbuscarcongeladoeditar.Text == string.Empty ? "%" : txtbuscarcongeladoeditar.Text;  /* asigna la clave a la variable estatica*/
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
                                         dgvcongeladobuscaryeditar.DataSource = resultado.Select(g => new { g.estado_id,g.clave, g.descripcion, g.cantidad}) /*ni estas*/
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

            MensajeDeEspera mse = new MensajeDeEspera();
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
                //estado_id = (dgvcongeladobuscaryeditar.CurrentRow.Cells[0].Value).ToString(),
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
        }

        private void txtbuscarcongelado_KeyDown(object sender, KeyEventArgs e)
        {       
           if (e.KeyCode == Keys.Enter)
            {
                if (tabControl1.SelectedTab == tabControl1.TabPages[0])
                /*ya de aqui me encargo pero primero activo el office jeje*/
                    Cocina.Buscarcongelados.Descripcion = txtbuscarcongelado.Text == string.Empty ? "%" : txtbuscarcongelado.Text;  /* asigna la clave a la variable estatica*/
                Opcion.EjecucionAsync(Data.ReporteCocina.agregar_congeladobuscar, jsonResult => /* se ejecuta Data.Receta.Lista, el resultado se guarda en jsonResult*/
                {
                    BeginInvoke((MethodInvoker)(() =>
                    {
                        switch (jsonResult.StatusCode)
                        {
                            case HttpStatusCode.OK:
                                var lista = Opcion.JsonaListaGenerica<Receta.Congelados>(jsonResult);
                                BeginInvoke((MethodInvoker)(() =>
                                {
                                    var brd = new BuscarCongelados(lista, /*esta parte no le entiendo*/
                                    resultado =>
                                    {
                                        BeginInvoke((MethodInvoker) (() => /*se manda llamar de nuevo a la interfaz*/
                                        {
                                            /*razonamiento de aime*/ 
                                            _listagregarcongelado1 = dgvcongelados.DataSource as List<Receta.Congelados>;
                                            _listaagregarcongelado2 = resultado.ToList();

                                            if (_listagregarcongelado1 != null)
                                            {
                                                _listaagregarcongelado2.AddRange(_listagregarcongelado1);
                                            }
                                            dgvcongelados.DataSource = _listaagregarcongelado2
                                                .GroupBy(p => p.art_id)
                                                .Select(g => new Receta.Congelados
                                                {
                                                    art_id = g.Key,
                                                    clave = g.First().clave,
                                                    descripcion = g.First().descripcion,
                                                   cantidad = g.Sum(i => i.cantidad)

                                                }).ToList();
                                            for (var x = 0; x == 4; x++)
                                            {
                                                dgvcongelados.Columns[x].ReadOnly = true;
                                                dgvcongelados.Columns[x].DefaultCellStyle.BackColor = Color.LightGray;
                                            }
                                            dgvcongelados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                                            txtbuscarcongelado.Text = "";
                                        }));
                                    }//aaa eso era jeje ya lo demas me encargo yo que es q mande al data de agregar y con el boton gia
                           );
                                brd.Show(); /*se muestra*/
                                }));
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
       
        private void btguardaragregar_Click(object sender, EventArgs e)
        {
            
            MensajeDeEspera mse = new MensajeDeEspera();
            mse.Show();
           
            Data.ReporteCocina.AgregarCongelados(y => {
            BeginInvoke((MethodInvoker)(() =>
            {
                mse.Close();
                
                dgvcongelados.DataSource = null;
                dgvcongelados.Rows.Clear();
                txtbuscarcongelado.Clear();
                
            }));
            },_listaagregarcongelado2);
       
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
        private void btborrarselect_Click(object sender, EventArgs e)
        {
            if (dgvcongelados.CurrentCell.RowIndex == -1 || dgvcongelados.Rows.Count <= 0) return;
            var result = dgvcongelados.DataSource as List<Respuesta.Receta.Congelados>;
            if (result == null) return;
            int fila = dgvcongelados.CurrentCell.RowIndex;
            result.RemoveAt(dgvcongelados.CurrentCell.RowIndex);
            _listaagregarcongelado2.RemoveAt(fila);
            dgvcongelados.DataSource = null;
            dgvcongelados.Refresh();
            dgvcongelados.DataSource = result;
        }

        private void btborrarall_Click(object sender, EventArgs e)
        {
            Opcion.BorrarDataGridView(dgvcongelados);
            _listaagregarcongelado2.Clear();
        }
        private void btbaja_Click(object sender, EventArgs e)
        {
            Data.ReporteCocina.InabilitarCongelado( Convert.ToInt32(dgvcongeladobuscaryeditar.CurrentRow.Cells[0].Value.ToString()));
            dgvcongeladobuscaryeditar.DataSource = null;
            dgvcongeladobuscaryeditar.Rows.Clear();
        }
    }
    internal class Controls
    {
    }
}
