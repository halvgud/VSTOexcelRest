﻿using System;
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
        public Congelados()
        {
            InitializeComponent();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            //    Local.Receta.clave = tbBuscarReceta.Text == string.Empty ? "%" : tbBuscarReceta.Text;
            //    Opcion.EjecucionAsync(Data.Receta.Lista, jsonResult =>
            //    {
            //        BeginInvoke((MethodInvoker)(() =>
            //        {
            //            switch (jsonResult.StatusCode)
            //            {
            //                case HttpStatusCode.OK:
            //                    var brd =
            //                     new BusquedaRecetaDetalle(Opcion.JsonaListaGenerica<Receta>(jsonResult),
            //                         resultado =>
            //                         {
            //                             BeginInvoke((MethodInvoker)(() =>
            //                             {
            //                                 dgvIngredientesBusqueda.DataSource = resultado.Ingredientes
            //                                 .Select(x => new Articulo.Basica
            //                                 {
            //                                     ArtId = x.ArtId,
            //                                     Clave = x.Clave,
            //                                     Descripcion = x.Descripcion,
            //                                     PrecioCompra = x.PrecioCompra,
            //                                     Cantidad = x.Cantidad
            //                                 }).ToList();
            //                                 tbPrecioBE.Text = resultado.Precio.ToString(CultureInfo.InvariantCulture);
            //                                 tbDescripcionBE.Text = resultado.Descripcion;
            //                                 tbPesoLitroBE.Text = resultado.PesoLitro.ToString(CultureInfo.InvariantCulture);
            //                                 tbMargenConPrecioBE.Text = resultado.Margen.ToString(CultureInfo.InvariantCulture);
            //                                 chDiarioBE.Checked = (resultado.Diario == 1);
            //                                 tbCodigoBE.Enabled = true; tbCostoElaboracionBE.Text =
            //                                      resultado.CostoElaboracion.ToString(CultureInfo.InvariantCulture);
            //                                 btBuscarBE.Enabled = true;
            //                             }));
            //                         }, false);
            //                    brd.Show();
            //                    break;
            //                default:
            //                    MessageBox.Show(this, @"No se encontraron recetas con los parametros de busqueda ingresados");
            //                    Console.WriteLine(jsonResult.Content);
            //                    break;
            //            }

            //        }));
            ////    });
        }
    }
}
