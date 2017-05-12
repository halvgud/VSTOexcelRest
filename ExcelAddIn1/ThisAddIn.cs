using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Herramienta.Config;
using Excel = Microsoft.Office.Interop.Excel;
using Herramienta;
using Microsoft.Office.Tools.Excel;
using Respuesta;
using RestSharp;

namespace ExcelAddIn1
{
    public partial class ThisAddIn
    {
        class Reportes
        {
            public string Nombre { get; set; }
        }
        private SideBarReporteReceta _reporteReceta;
        private SideBarRecetario _recetario;
        //private DetalleMenu _detallemenu;
        public static Microsoft.Office.Tools.CustomTaskPane Recetario;
        public static Microsoft.Office.Tools.CustomTaskPane ReporteReceta;
        //public static Microsoft.Office.Tools.CustomTaskPane DetalleMenu;
        private Excel.Worksheet _reporte;

        public NamedRange ClickRange { get; }

        private void ThisAddIn_Startup(object sender, EventArgs e)
        {
            _reportes = new List<Reportes> {
            new Reportes {Nombre = "ReporteCocina"},
            new Reportes {Nombre= "Recetario"},

            //Comentar despues de usar
            //new Reportes {Nombre="DetalleMenu"}
            };
            _reporteReceta = new SideBarReporteReceta();
            _recetario = new SideBarRecetario();

            //Comentar despues de usar
            //_detallemenu = new DetalleMenu();

            ReporteReceta = CustomTaskPanes.Add(_reporteReceta, "Reporte Cocina");
            ReporteReceta.Visible = false;
            ReporteReceta.Width = 280;
            Recetario = CustomTaskPanes.Add(_recetario, "Recetario");
            Recetario.Visible = false;
            Recetario.Width = 280;

            //comentar desp
            //DetalleMenu = CustomTaskPanes.Add(_detallemenu, "Detalle Menu");
            //DetalleMenu.Visible = false;
            //DetalleMenu.Width = 280;
            Application.WorkbookActivate += Application_ActiveWorkbookChanges;
            Application.WorkbookDeactivate += Application_ActiveWorkbookChanges;
            Globals.ThisAddIn.Application.SheetSelectionChange += activeSheet_SelectionChange;
            this.Application.SheetBeforeDoubleClick += Application_SheetBeforeDoubleClick;
            _sheet1 = (Excel.Worksheet)Application.ActiveSheet;


        }
        void Application_SheetBeforeDoubleClick(object sh,
        Excel.Range target, ref bool cancel)
        {

            

            _sheet1 = (Excel.Worksheet)Application.ActiveSheet;
            if (_sheet1.Name == "ReporterCocina" && target.Column == 1)
            {
                cancel = true;
      
                var excel = target.EntireRow.Value2;

                Cocina.DetalleCocina.Clave = excel[1,1].ToString();


                Opcion.EjecucionAsync(x =>
                {
                    Data.ReporteCocina.DDetalleReceta(x, Cocina.DetalleCocina.Clave);
                }, jsonResult =>
                {
                    Reporte.RespuestaCocina listCocina = Opcion.JsonaClaseGenerica<Reporte.RespuestaCocina>(jsonResult);
                   // Reporte.RespuestaCocina.CocinaDetalle lista = Opcion.JsonaClaseGenerica<Reporte.RespuestaCocina.CocinaDetalle>(jsonResult);
                    var excelazo = InicializarExcelConTemplate("DetalleReceta");
                    excelazo.Range["A1:N2"].Interior.Color = ColorTranslator.ToOle(Color.Peru);
                    excelazo.Range["A4:A7"].Interior.Color = ColorTranslator.ToOle(Color.Peru);
                    excelazo.Range["F4:N4"].Interior.Color = ColorTranslator.ToOle(Color.Peru);
                    excelazo.Range["F6:N6"].Interior.Color = ColorTranslator.ToOle(Color.Peru);
                    excelazo.Range["F9:N9"].Interior.Color = ColorTranslator.ToOle(Color.Peru);
                    excelazo.Range["B7:D7"].Interior.Color = ColorTranslator.ToOle(Color.Peru);
                    excelazo.Range["C21"].Interior.Color = ColorTranslator.ToOle(Color.Peru);
                    //excelazo.Range["M7"].NumberFormat = "##.## %";

                    if (excelazo == null) return;
                    ((excelazo.Range["A1"])).Value2 = listCocina.receta;
                    ((excelazo.Range["M7"])).Value2 = listCocina.Margen;
                    //((excelazo.Range["K5"])).Value2 =lista.CantidadElaborada ;
                    ((excelazo.Range["F7"])).Value2 = listCocina.ultimaElaboracion;
                    ((excelazo.Range["N5"])).Value2 = listCocina.Venta;
                    //((excelazo.Range["G7"])).Value2 = lista.Densidad;
                    ((excelazo.Range["G5"])).Value2 = listCocina.rec_id;
                    ((excelazo.Range["H7"])).Value2 =listCocina.medida;
                    //((excelazo.Range["L10"])).Value2 = lista.Foto;
                    ((excelazo.Range["M5"])).Value2 = listCocina.Costo;
                    //((excelazo.Range["N5"])).Value2 = rrc.Venta;
                    //((excelazo.Range["L5"])).Value2 = lista.SobrantesPendiente;
                    ((excelazo.Range["F5"])).Value2 = listCocina.Since;
                    ((excelazo.Range["H5"])).Value2 = listCocina.Qtycongelado;
                    ((excelazo.Range["B4"])).Value2 = listCocina.TipoProducto;

                }

                );
                Reporte.RespuestaCocina rrc=new Reporte.RespuestaCocina(); //? y este para que? para meterle lo que hay en reporte .respuestacocina, pero ya lo tienes en la clase
                //de arriba, listCocina 
                //Opcion.EjecucionAsync(Data.ReporteCocina.DDetalleReceta(x,Cocina.DetalleCocina.Clave));

                //Reporte.RespuestaCocina rrc = new Reporte.RespuestaCocina
                //{
                //    // SEGUIR EL LUNES

                //    clave = excel[1, 1],
                //    receta = excel[1, 2],
                //    Since = excel[1, 7].ToString(),
                //    ultimaElaboracion = excel[1, 8].ToString(),
                //   Costo = (Convert.ToDouble(excel[1, 11])).ToString(),
                //    Venta = (Convert.ToDouble(excel[1, 12])).ToString(),
                //    Margen = (Convert.ToDouble(excel[1, 13])/100).ToString(),
                //    medida = excel[1,9].ToString(),

                //  };
                //rrc.clave = "";
                /*algo asi... */
                /*y esto de abajo que? es la que te digo de echo mas abajo esta, pero esta petición que hace?
                 porque son 2? la de arriba y esta?mmmmmm entonces la puedo meter esta dentro de la otra veradd aaaaaaaaaaaaaaa 
                 si verdad, pero porque son 2???????
                 que hace esta versionDetallada? nada al parecer de echo esa tu a metiste hay y no supe por que
                  yo?? cuando?  o.O entonces cual es tu duda?creo que ya la solucionaste es en esta parte de abajo esos datos no mostraba nada en detalle receta perate no te desconectes voy a intentar algo */
                //Opcion.EjecucionAsync(Data.ReporteCocina.VersionDetallada, jsonResult =>
                //{
                   

                   
                //   // ((excelazo.Range["G5"])).Value2 = rrc.rec_id;




                //} );
                }

        }


        Excel.Worksheet _sheet1;
        private List<Reportes> _reportes;
         
        void activeSheet_SelectionChange(object sh, Excel.Range target)
        {

        }
        void Application_ActiveWorkbookChanges(Excel.Workbook wb)
        {
            // TODO: Active Workbook has changed. Ribbon should be updated.    
            //wb.Unprotect();
        }
        public void Agregar(Receta receta)
        {
            Local.Receta.IdReceta = receta.RecId;
            var oReportWs = InicializarExcelConTemplate("Receta");
            if (oReportWs == null) return;
            ((oReportWs.Range["NOMBRE"])).Value2 = receta.Descripcion;
            ((oReportWs.Range["PESO_LITRO"])).Value2 = receta.PesoLitro;
            ((oReportWs.Range["LITROS_A_ELABORAR"])).Value2 = receta.Cantidad;
            ((oReportWs.Range["CANTIDAD_A_ELABORAR"])).Value2 = receta.Cantidad * receta.PesoLitro;
            ((oReportWs.Range["CODIGO"])).Value2 = receta.Clave;
            ((oReportWs.Range["MARGEN_ANTERIOR"])).Value2 = receta.Margen;
            ((oReportWs.Range["PRECIO_VENTA"])).Value2 = receta.Precio;
            ((oReportWs.Range["COSTO_PREPARACION"])).Value2 = receta.CostoCreacion;
            //oReportWs.Range["TABLA1"].CopyFromRecordset(ListToDataTable(rrd));
            int inicioTabla = 5;
            foreach (Receta.Detalle t in receta.Ingredientes)
            {
                oReportWs.Range["A" + inicioTabla].Value2 = t.Clave; //Clave
                oReportWs.Range["B" + inicioTabla].Value2 = t.Cantidad;
                //cantidad unitaria por medida
                oReportWs.Range["C" + inicioTabla].Value2 = (t.Cantidad) * receta.Cantidad;
                //cantidad total
                oReportWs.Range["D" + inicioTabla].Value2 = t.Unidad; //tipo de unidad
                oReportWs.Range["E" + inicioTabla].Value2 = t.Descripcion; //nombre
                oReportWs.Range["F" + inicioTabla].Value2 = t.PrecioVenta; //valor unitario
                oReportWs.Range["G" + inicioTabla].Value2 = (t.PrecioVenta) *
                                                            ((t.Cantidad) * receta.Cantidad); //
                inicioTabla++;
            }
        }
        private void ThisAddIn_Shutdown(object sender, EventArgs e)
        {
        }
        public Excel.Worksheet InicializarExcelConTemplate(string nombreHoja)
        {
            try
            {
                _sheet1 = (Excel.Worksheet)Application.ActiveSheet;
                _sheet1.Unprotect();
                var found = Application.Sheets.Cast<Excel.Worksheet>().Any(sheet => sheet.Name == nombreHoja);
                var awa = Application.Workbooks.Application;//nueva app
                if (!found)
                {
                    var ows = Application.Worksheets[1];// excel actual
                    var sPath = Path.GetTempFileName(); // archivo temporal
                    File.WriteAllBytes(sPath, Properties.Resources.FICHA_RECETA);//se copia el template
                    var oTemplate = Application.Workbooks.Add(sPath); //path del template temporal  
                    var worksheet = oTemplate.Worksheets[nombreHoja] as Excel.Worksheet;//nombre del template
                    worksheet?.Copy(After: ows); oTemplate.Close(false, missing, missing);
                    File.Delete(sPath);
                }
                _reporte = awa.Worksheets[nombreHoja] as Excel.Worksheet;//nombre de la hoja actual   
                _reporte?.Activate();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return _reporte;
        }
        public static bool BuscarPermiso()
        {
            return true;
        }

        #region Código generado por VSTO

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        ///         public static Microsoft.Office.Tools.CustomTaskPane MyCustomTaskPane;
        protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject()
        {
            return new Ribbon1();
        }
        private void InternalStartup()
        {
            this.Startup += new EventHandler(ThisAddIn_Startup);
            this.Shutdown += new EventHandler(ThisAddIn_Shutdown);
        }

        #endregion

        //template recetario
        public void ReporteCocina(IRestResponse restResponse)
        {
            Application.ScreenUpdating = false;
            var rrg = Opcion.JsonaListaGenerica<Reporte.RespuestaCocina>(restResponse);
            var oReportWs = InicializarExcelConTemplate("ReporterCocina");
            if (oReportWs == null) return;
            var rowcount = rrg.Count + 2;
            _reporte.Range["A3:X" + rowcount].Value2 = InicializarLista(rrg);
            _reporte.Range["A3:X" + rowcount].Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
            _reporte.Range["A3:X" + rowcount].Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
            _reporte.Range["A3:X" + rowcount].Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
            _reporte.Range["A3:X" + rowcount].Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlContinuous;
            _reporte.Range["A3:X" + rowcount].Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
            _reporte.Range["O3:P" + rowcount].NumberFormat = "$ #,##0.00";
            _reporte.Range["O3:O" + rowcount].NumberFormat= "$ #,##0.00";
            _reporte.Range["R3:R" + rowcount].NumberFormat = "$ #,##0.00";
            _reporte.Range["A3:X" + rowcount].HorizontalAlignment= Excel.XlHAlign.xlHAlignCenter;
            //_reporte.Range["A3:O" + rowcount].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            _reporte.Range["A3:X" + rowcount].Borders.Color = Color.Black;
            _reporte.Range["A3:X" + rowcount].Font.Size = 8;
            _reporte.Range["A2:X2"].Interior.Color = ColorTranslator.ToOle(Color.Orange);
            _reporte.Range["Q1:X1"].Interior.Color = ColorTranslator.ToOle(Color.Orange);
            _reporte.Range["K3:K"+  rowcount].Interior.Color = ColorTranslator.ToOle(Color.Yellow);
            _reporte.Range["L3:L" + rowcount].Interior.Color = ColorTranslator.ToOle(Color.Green);
            _reporte.Range["O3:P" + rowcount].Interior.Color = ColorTranslator.ToOle(Color.Pink);
            _reporte.Range["P3:P" + rowcount].Interior.Color = ColorTranslator.ToOle(Color.Pink);
            
            _reporte.Range["B3:B" + rowcount].Columns.AutoFit();
            _reporte.Range["E3:E" + rowcount].Columns.AutoFit();
            _reporte.Range["G3:G" + rowcount].Columns.AutoFit();


            Application.Cells.Locked = false;
            Application.ScreenUpdating = true;
           

        }


        //template Congelados
        public void ReporteCongelados(IRestResponse restResponse)
        {
            Application.ScreenUpdating = false;
            var rrgc = Opcion.JsonaListaGenerica<Reporte.General.InventarioCongelados>(restResponse);
            var oReportWs = InicializarExcelConTemplate("Congelados");
            if (oReportWs == null) return;
            var rowcount = rrgc.Count + 6;//olle pero cuando aumente que ondas con esta paarte tener que poner una variable que se aumente sola un count
            /*nop, no puedes meter por ejemplo el rrgc.Count+7 dentro de la linea de abajo porque no lo agarra... lo tienes que meter en una viarable ya fijona*/
            /**/
            _reporte.Range["A7:F" + rowcount].Value2 = InicializarLista(rrgc);
            _reporte.Range["A7:F" + rowcount].Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
            _reporte.Range["A7:F" + rowcount].Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
            _reporte.Range["A7:F" + rowcount].Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
            _reporte.Range["A7:F" + rowcount].Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlContinuous;
            _reporte.Range["A7:F" + rowcount].Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
           
            _reporte.Range["A7:F" + rowcount].Borders.Color = Color.Black;
            _reporte.Range["A7:F" + rowcount].Font.Size = 8;

            _reporte.Range["A7:F"+rowcount].HorizontalAlignment=Excel.XlHAlign.xlHAlignCenter;
            _reporte.Range["B7:F" + rowcount].HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
            _reporte.Range["C7:F" + rowcount].HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
            _reporte.Range["D7:F" + rowcount].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            _reporte.Range["F7:F" + rowcount].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;


            _reporte.Range["E7:E" + rowcount].Interior.Color = Color.Aqua;

            //_reporte.Range["A7=F" + rowcount].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            //_reporte.Range["A2:X2"].Interior.Color = ColorTranslator.ToOle(Color.Orange);
            //_reporte.Range["Q1:X1"].Interior.Color = ColorTranslator.ToOle(Color.Orange);
            //_reporte.Range["K3:K" + rowcount].Interior.Color = ColorTranslator.ToOle(Color.Yellow);
            //_reporte.Range["L3:L" + rowcount].Interior.Color = ColorTranslator.ToOle(Color.Green);
            //_reporte.Range["O3:P" + rowcount].Interior.Color = ColorTranslator.ToOle(Color.Pink);
            //_reporte.Range["P3:P" + rowcount].Interior.Color = ColorTranslator.ToOle(Color.Pink);

            _reporte.Range["C7:F" + rowcount].Columns.AutoFit();
            _reporte.Range["B7:F" + rowcount].Columns.AutoFit();
            _reporte.Range["F6:F" + rowcount].Columns.AutoFit();
            _reporte.Range["D6:F" + rowcount].Columns.AutoFit();


            Application.Cells.Locked = false;
            Application.ScreenUpdating = true;


        }

        private static object[,] InicializarLista(IReadOnlyList<Reporte.General.InventarioCongelados> rrgc)
        {
            var lista = new object[rrgc.Count, 7];
            for (var x = 0; x < rrgc.Count; x++)
            {
                lista[x, 0] = rrgc[x].id;
                lista[x, 1] = "'"+rrgc[x].clave;
                lista[x, 2] = rrgc[x].descripcion;
                lista[x, 3] = rrgc[x].existencia;
                lista[x, 4] = rrgc[x].estado;
                lista[x, 5] = rrgc[x].fechaEntrada;
            }
            return lista;



        }

        private static object[,] InicializarLista(IReadOnlyList<Reporte.RespuestaCocina> rrg)
        {
            var lista = new object[rrg.Count, 24];
            for (var x = 0; x < rrg.Count; x++)
            {
                lista[x, 0] = "'"+rrg[x].clave;
                lista[x, 1] = rrg[x].receta.ToString();
                lista[x, 2] = rrg[x].TipoProducto;
                lista[x, 3] = rrg[x].cantidadinventario;
                lista[x, 4] = rrg[x].categoria;
               
                string dato = rrg[x].Estado;
                if (string.IsNullOrEmpty(dato))
                {
                    lista[x, 5] = "N/A";
                }
                else
                {
                    lista[x, 5] = rrg[x].Estado;
                }
                lista[x, 6] = rrg[x].Since;
                lista[x, 7] = rrg[x].ultimaElaboracion;
                lista[x, 8] = rrg[x].medida;
                lista[x, 9] = rrg[x].consumodia;
                lista[x, 10] = rrg[x].Costo;
                lista[x, 11] = rrg[x].Venta;
                lista[x, 12] = rrg[x].Margen;
                lista[x, 13] = rrg[x].qty;
                lista[x, 14] = rrg[x].salesince;
                lista[x, 15] = rrg[x].ProfitSince;
                
                var qty = rrg[x].Qtycongelado;
                if (string.IsNullOrEmpty(qty))
                {
                    lista[x, 16] = "N/A";
                }
                else
                {
                    lista[x, 16] = rrg[x].Qtycongelado;
                }
                var pcongelado = rrg[x].Preciocongelado;
                if (string.IsNullOrEmpty(pcongelado))
                {
                    lista[x, 17] = "N/A";
                }
                else
                {
                    lista[x, 17] = rrg[x].Preciocongelado;

                }
                lista[x, 18] = rrg[x].Qtymermas;
                lista[x, 19] = rrg[x].Porcentajemerma;
                lista[x, 20] = rrg[x].Qtyperdidas;
                lista[x, 21] = rrg[x].Porcentajeperdida;
                lista[x, 22] = rrg[x].Qtyempleado;
                lista[x, 23] = rrg[x].Porcentajeempleado;
            }
            return lista;

  

        }



    }
}
