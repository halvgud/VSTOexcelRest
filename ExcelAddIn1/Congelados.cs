using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
    public partial class Congelados : Form
    {

        //private List<Articulo.Basica> _listaArticuloBasica1;

        public char KeyChar { get; set; }
        private List<Articulo.Basica> _listaArticuloBasica1;
        private List<Respuesta.CbGenerico> _listaplatillo; 

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
            txtbuscarcongelado.AutoCompleteCustomSource = allowedTypes;
            txtbuscarcongelado.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtbuscarcongelado.AutoCompleteSource = AutoCompleteSource.CustomSource;

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
                            var brd = /*aqui que ondas */
                             new BuscarCongelados(Opcion.JsonaListaGenerica<Receta.Congelados>(jsonResult), /*esta parte no le entiendo*/
                                 resultado =>
                                 {
                                     BeginInvoke((MethodInvoker)(() => /*se manda llamar de nuevo a la interfaz*/
                                     {
                                         dgvcongeladobuscaryeditar.DataSource = resultado.Select(g => new {g.estado_id, g.clave, g.descripcion, g.cantidad, g.status, g.fechaEntrada}) /*ni estas*/
                                          .ToList();
                                     }));
                                 });
                            if (tpagregar.Visible == true)
                            {
                                brd.lbcantidad.Visible = true;
                                brd.lbdescripcion.Visible = true;
             
                            }
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

        }


        private void txtbuscarcongeladoeditar_TextChanged(object sender, EventArgs e)
        {

        }

       

        private void txtbuscarcongelado_KeyDown(object sender, KeyEventArgs e)
        {
           if (e.KeyCode == Keys.Enter)
            {

                Cocina.buscarcongelados.descripcion = txtbuscarcongelado.Text == string.Empty ? "%" : txtbuscarcongelado.Text;  /* asigna la clave a la variable estatica*/
                Opcion.EjecucionAsync(Data.ReporteCocina.Buscarcongelados, jsonResult => /* se ejecuta Data.Receta.Lista, el resultado se guarda en jsonResult*/
                {
                    BeginInvoke((MethodInvoker)(() =>
                    {
                        switch (jsonResult.StatusCode)
                        {
                            case HttpStatusCode.OK:
                                var brd = /*aqui que ondas */
                                 new BuscarCongelados(Opcion.JsonaListaGenerica<Respuesta.Receta.Congelados>(jsonResult), /*esta parte no le entiendo*/
                                     resultado =>
                                     {
                                         BeginInvoke((MethodInvoker)(() => /*se manda llamar de nuevo a la interfaz*/
                                         {
                                             dgvcongeladobuscaryeditar.DataSource = resultado /*ni estas*/
                                              .ToList();
                                         }));
                                     });
                                if (tpagregar.Visible == true)
                                {
                                    brd.lbcantidad.Visible = true;
                                    brd.lbdescripcion.Visible = true;
                                    brd.lbtclave.Visible = true;
                                    brd.lbtdescripcion.Visible = true;
                                    brd.txtcantidad.Visible = true;
                                }
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

      
    }

    internal class Controls
    {

    }
}
