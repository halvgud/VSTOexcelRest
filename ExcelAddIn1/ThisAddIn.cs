using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Herramienta.Config;
using Excel = Microsoft.Office.Interop.Excel;
using Herramienta;
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
        public static Microsoft.Office.Tools.CustomTaskPane Recetario;
        public static Microsoft.Office.Tools.CustomTaskPane ReporteReceta;
        private Excel.Worksheet _reporte;   

        private void ThisAddIn_Startup(object sender, EventArgs e)
        {
            _reportes = new List<Reportes> {
            new Reportes { Nombre = "ReporteCocina"},
            new Reportes { Nombre= "Recetario" }
            };
            _reporteReceta = new SideBarReporteReceta();
            _recetario = new SideBarRecetario();

            ReporteReceta = CustomTaskPanes.Add(_reporteReceta, "ReporteCocina");
            ReporteReceta.Visible = false;
            ReporteReceta.Width = 280;
            Recetario = CustomTaskPanes.Add(_recetario, "Recetario");
            Recetario.Visible = false;
            Recetario.Width = 280;
            Application.WorkbookActivate +=
   Application_ActiveWorkbookChanges;
            Application.WorkbookDeactivate += Application_ActiveWorkbookChanges;
            Globals.ThisAddIn.Application.SheetSelectionChange += activeSheet_SelectionChange;
            _sheet1 = (Excel.Worksheet)Application.ActiveSheet;
        }

        Excel.Worksheet _sheet1;
        private List<Reportes> _reportes;
        void activeSheet_SelectionChange(object sh, Excel.Range target)
        {

            var oReportWs = InicializarExcelConTemplate("DetalleReceta");
            ((oReportWs.Range["A1"])).Value2 = target.Value2;
            //Microsoft.Office.Interop.Excel.Range excelCell = (Microsoft.Office.Interop.Excel.Range)target;
            //_reporte.Hyperlinks.Add(excelCell, "http://www.microsoft.com/", Type.Missing, target.Value2, target.Value2);

            //_sheet1 = (Excel.Worksheet)sh;
            //if (target.Row != 1 && (_reportes.FirstOrDefault(x => x.Nombre == _sheet1.Name) != null))
            //{
            //    try
            //    {
            //        _sheet1.Unprotect();
            //        Globals.ThisAddIn.Application.Cells.Locked = false;
            //        _sheet1.Protect(AllowSorting: true, AllowFiltering: true);
            //    }
            //    catch (Exception e)
            //    {
            //        Console.WriteLine(e.Message);
            //    }
            //}
            //else
            //{
            //    _sheet1.Unprotect();
            //}
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
            var rrg = Opcion.JsonaListaGenerica<Reporte.General.RespuestaCocina>(restResponse);
            var oReportWs = InicializarExcelConTemplate("ReporterCocina");
            if (oReportWs == null) return;
            var rowcount = rrg.Count + 2;
            _reporte.Range["A3:U"+rowcount].Value2 = InicializarLista(rrg);

            _reporte.Range["A3:X" + rowcount].Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
            _reporte.Range["A3:X" + rowcount].Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
            _reporte.Range["A3:X" + rowcount].Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
            _reporte.Range["A3:X" + rowcount].Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlContinuous;
            _reporte.Range["A3:X" + rowcount].Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
            _reporte.Range["A3:X" + rowcount].Borders.Color = Color.Black;
            _reporte.Range["A3:X" + rowcount].Font.Size = 8;
            _reporte.Range["A2:X2"].Interior.Color = ColorTranslator.ToOle(Color.Orange);
            _reporte.Range["Q1:X1"].Interior.Color = ColorTranslator.ToOle(Color.Orange);
            _reporte.Range["K3:K"+  rowcount].Interior.Color = ColorTranslator.ToOle(Color.Yellow);
            _reporte.Range["L3:L" + rowcount].Interior.Color = ColorTranslator.ToOle(Color.Green);
            _reporte.Range["O3:P" + rowcount].Interior.Color = ColorTranslator.ToOle(Color.Pink);
            _reporte.Range["P3:P" + rowcount].Interior.Color = ColorTranslator.ToOle(Color.Pink);
            
            _reporte.Range["B3:B" + rowcount].Columns.AutoFit();


            Application.Cells.Locked = false;
            Application.ScreenUpdating = true;
           

        }

        private static object[,] InicializarLista(IReadOnlyList<Reporte.General.RespuestaCocina> rrg)
        {
            var lista = new object[rrg.Count, 21];
            for (var x = 0; x < rrg.Count; x++)
            {
                lista[x, 0] = "'"+rrg[x].Clave;
                lista[x, 1] = rrg[x].Receta.ToString();
                lista[x, 2] = rrg[x].Categoria;
                lista[x, 3] = rrg[x].Estado;
                lista[x, 4] = rrg[x].UltimaElaboracion;
                lista[x, 5] = rrg[x].Medida;
                lista[x, 6] = rrg[x].consumopordia;
                lista[x, 7] = rrg[x].Costo;
                lista[x, 8] = rrg[x].Venta;
                lista[x, 9] = rrg[x].Margen;
                lista[x, 10] = rrg[x].Qty;
                lista[x, 11] = rrg[x].Sale;
                lista[x, 12] = rrg[x].Profit;
                lista[x, 13] = rrg[x].Qtycongelado;
                lista[x, 14] = rrg[x].Preciocongelado;
                lista[x, 15] = rrg[x].Qtymermas;
                lista[x, 16] = rrg[x].Porcentajemerma;
                lista[x, 17] = rrg[x].Qtyperdidas;
                lista[x, 18] = rrg[x].Porcentajeperdida;
                lista[x, 19] = rrg[x].Qtyempleado;
                lista[x, 20] = rrg[x].Porcentajeempleado;
                
            }
            return lista;

  

        }

        private void MouseClick(object sender, MouseEventArgs e)
        {
            var oReportWs = InicializarExcelConTemplate("DetalleReceta");
            Microsoft.Office.Interop.Excel.Range excelCell = (Microsoft.Office.Interop.Excel.Range)_reporte.Range["A:6"];
            _reporte.Hyperlinks.Add(excelCell, "http://www.microsoft.com/", Type.Missing, "Microsoft", "Microsoft");
        }

    }
}
