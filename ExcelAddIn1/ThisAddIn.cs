using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Herramienta.Config;
using Excel = Microsoft.Office.Interop.Excel;
using Herramienta;
using Respuesta;
using Herramienta.Config;
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
            _sheet1 = (Excel.Worksheet)sh;
            if (target.Row != 1 && (_reportes.FirstOrDefault(x => x.Nombre == _sheet1.Name) != null))
            {
                try
                {
                    _sheet1.Unprotect();
                    Globals.ThisAddIn.Application.Cells.Locked = false;
                    _sheet1.Protect(AllowSorting: true, AllowFiltering: true);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                _sheet1.Unprotect();
            }
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
        public void ReporteCocina()
        {
            Application.ScreenUpdating = false;
            var oReportWs = InicializarExcelConTemplate("ReporterCocina");
            if (oReportWs == null) return;
            Application.Cells.Locked = false;
            Application.ScreenUpdating = true;
        }
    }
}
