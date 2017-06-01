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
    public partial class AgregarCongelados : Form
    {

        private readonly List<Respuesta.Receta.Congelados> _listaCongelados;
        private readonly Action<List<Respuesta.Receta.Congelados>> _callback;
        public AgregarCongelados(List<Respuesta.Receta.Congelados> listaCongelados, Action<List<Respuesta.Receta.Congelados>> callback)
        {
            /*checa en la conversion de jsonResult a List... me suena que por ahi esta tronando porque aqui ya no trae registros*/
            _listaCongelados = listaCongelados;
            _callback = callback;
            InitializeComponent();
            dtgagregarcongelados.DataSource = _listaCongelados.ToArray();
            dtgagregarcongelados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        //public string descripcionagregar;
        //public Agregar_Congelados()
        //{
        //    InitializeComponent();

        //    Cocina.buscarcongelados.descripcion = lbdescripcion.Text == string.Empty ? "%" : lbdescripcion.Text;  /* asigna la clave a la variable estatica*/
        //    Opcion.EjecucionAsync(Data.ReporteCocina.Buscarcongelados, jsonResult => /* se ejecuta Data.Receta.Lista, el resultado se guarda en jsonResult*/
        //    {
        //        BeginInvoke((MethodInvoker)(() =>
        //        {
        //            switch (jsonResult.StatusCode)
        //            {
        //                case HttpStatusCode.OK:
        //                    var brd = /*aqui que ondas */
        //                     new BuscarCongelados(Opcion.JsonaListaGenerica<Receta.Congelados>(jsonResult), /*esta parte no le entiendo*/
        //                         resultado =>
        //                         {
        //                             BeginInvoke((MethodInvoker)(() => /*se manda llamar de nuevo a la interfaz*/
        //                             {
        //                                 dtgagregarcongelados.DataSource = resultado /*ni estas*/
        //                                  .ToList();
        //                             }));
        //                         });
        //                    brd.Show(); /*se muestra*/
        //                    break;
        //                default:
        //                    MessageBox.Show(this, @"No se encontraron recetas con los parametros de busqueda ingresados");
        //                    Console.WriteLine(jsonResult.Content);
        //                    break;
        //            }

        //        }));
        //    });


            //lbfechaagregar.Text = DateTime.Now.ToShortDateString();
            //lbdescripcion.Text = descripcionagregar;

            //Opcion.EjecucionAsync(Data.);


        }

     
     
}
