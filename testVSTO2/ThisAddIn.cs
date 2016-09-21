using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using RestSharp;
namespace testVSTO2
{
    public partial class ThisAddIn
    {
        SideBarImportarInformacion _inventario;
        private SideBarRecetario _recetario;
        public static Microsoft.Office.Tools.CustomTaskPane Inventario;
        public static Microsoft.Office.Tools.CustomTaskPane Recetario;
        private Excel.Worksheet _reporte;
       // internal Microsoft.Office.Interop.Excel.Application Application2;
        private void ThisAddIn_Startup(object sender, EventArgs e)
        {
            _inventario = new SideBarImportarInformacion();
            _recetario = new SideBarRecetario();
            Inventario = CustomTaskPanes.Add(_inventario, "Importar...");
            Inventario.Visible = false;
            Inventario.Width = 250;
            Recetario = CustomTaskPanes.Add(_recetario, "Recetario");
            Recetario.Visible = false;
            Recetario.Width = 250;
            Application.WorkbookActivate +=
           Application_ActiveWorkbookChanges;
            Application.WorkbookDeactivate +=
                Application_ActiveWorkbookChanges;
            Globals.ThisAddIn.Application.SheetSelectionChange += activeSheet_SelectionChange;
            _sheet1 = (Excel.Worksheet) Application.ActiveSheet;
            /* var oWB = Application.Workbooks.Add(missing);
             var oWS = oWB.Worksheets.Add(missing, missing, 1, missing) as Excel.Worksheet;
             var sPath = Path.GetTempFileName();
             File.WriteAllBytes(sPath,Properties.Resources.FICHA_RECETA);
             var oTemplate = Application.Workbooks.Add(sPath);
             (oTemplate.Worksheets[1] as Excel.Worksheet).Copy(missing, oWS);
             oTemplate.Close(false, missing, missing);
             File.Delete(sPath);
             var oReportWS = oWB.Worksheets["Template"] as Excel.Worksheet;
             ((oReportWS.Range["NOMBRE"]) as Excel.Range).Value2 = "Here I am!";*/

        }
        Excel.Worksheet _sheet1;
        void activeSheet_SelectionChange(Object sh,Excel.Range target)
        {
            _sheet1 = (Excel.Worksheet)Application.ActiveSheet;
            // Put your code here
            if (target.Row == 1)
            {
                _sheet1.Unprotect();
            }
            else
            {
                try
                {
                    Globals.ThisAddIn.Application.Cells.Locked = false;
                    BloquearRango(_rowCount);
                    _sheet1.Protect(AllowSorting: true, AllowFiltering: true);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        public Excel.Worksheet InicializarExcelConTemplate(string nombreHoja)
        {
            var reportet=new Excel.Worksheet();
            _sheet1 = (Excel.Worksheet)Application.ActiveSheet;
            _sheet1.Unprotect();
            try
            {
                var found = Application.Sheets.Cast<Excel.Worksheet>().Any(sheet => sheet.Name == nombreHoja);
                var awa = Application.Workbooks.Application;//nueva app
                var ows = Application.Worksheets[1];// excel actual
                var sPath = Path.GetTempFileName(); // archivo temporal
                File.WriteAllBytes(sPath, Properties.Resources.FICHA_RECETA);//se copia el template
                var oTemplate = Application.Workbooks.Add(sPath); //path del template temporal
                var worksheet = oTemplate.Worksheets[nombreHoja] as Excel.Worksheet;//nombre del template
                if (!found)
                    worksheet?.Copy(After: ows);
                oTemplate.Close(false, missing, missing);
                File.Delete(sPath);
                reportet = awa.Worksheets[nombreHoja] as Excel.Worksheet;//nombre de la hoja actual   

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return reportet;
        }
       
        private int _rowCount;
        public void ReporteGeneral(IRestResponse restResponse)
        {
            var rrg = Prop.Opcion.JsonaListaGenerica<Respuesta.Reporte.General.Respuesta>(restResponse);
            _rowCount = (rrg.Count + 1);
            _reporte =InicializarExcelConTemplate("ReporteInventario");
            if (_reporte != null)
            {
                try
                {
                    var list = new List<string> {"P-1", "P-.5", "1", "4", "DESCONOCIDO"};
                    var flatList = string.Join(",", list.ToArray());
                    var lista = new object[rrg.Count, 19];
                    for (var x = 0; x < rrg.Count; x++)
                    {
                        lista[x, 0] = rrg[x].clave;
                        lista[x, 1] = rrg[x].departamento;
                        lista[x, 2] = rrg[x].categoria;
                        lista[x, 3] = rrg[x].descripcion;
                        lista[x, 4] = rrg[x].tipo;
                        lista[x, 5] = (rrg[x].existencia);
                        lista[x, 6] = rrg[x].consumoDiario;
                        lista[x, 7] = rrg[x].puntoReorden;
                        lista[x, 8] = rrg[x].inventarioMinimo;
                        lista[x, 9] = rrg[x].inventarioMaximo;
                        lista[x, 10] = rrg[x].factor;
                        lista[x, 11] = rrg[x].cantidadVendida;
                        lista[x, 12] = rrg[x].ventas;
                        lista[x, 13] = rrg[x].fechaUltimaCompra.ToString(CultureInfo.InvariantCulture);
                        lista[x, 14] = rrg[x].cantidadComprada;
                        lista[x, 15] = rrg[x].radioInventario;
                        lista[x, 16] = rrg[x].precioCompra;
                        lista[x, 17] = rrg[x].precioVenta;
                        lista[x, 18] = Double.Parse(rrg[x].margen)/100;
                    }
                    Globals.ThisAddIn.Application.Cells.Locked = false;
                    _reporte.Range["A" + 2 + ":S" + _rowCount].Value2 = lista;
                    _reporte.Range["F" + 2 + ":F" + _rowCount].NumberFormat = "0.0";
                    var sourceRange = _reporte.Range["A" + 1 + ":S" + (rrg.Count+1)];
                    sourceRange.Worksheet.ListObjects.Add(Excel.XlListObjectSourceType.xlSrcRange,
 sourceRange, Type.Missing, Excel.XlYesNoGuess.xlYes, Type.Missing).Name =
 "tabla2";

                    sourceRange.Select();

                    sourceRange.Worksheet.ListObjects["tabla2"].TableStyle = "TableStyleLight8";
                    _reporte.Range["E" + 2 + ":E" + _rowCount].Validation.Delete();
                    _reporte.Range["E" + 2 + ":E" + _rowCount].Validation.Add(Excel.XlDVType.xlValidateList,
                           Excel.XlDVAlertStyle.xlValidAlertInformation,
                           Excel.XlFormatConditionOperator.xlBetween,
                           flatList,
                           Type.Missing);
                    BloquearRango(_rowCount);
                    _sheet1.Protect(AllowSorting:true, AllowFiltering:true);
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private void BloquearRango(int posicion)
        {
            _reporte.Range["A" + 2 + ":A" + posicion].Locked = true;
            _reporte.Range["B" + 2 + ":B" + posicion].Locked = true;
            _reporte.Range["C" + 2 + ":C" + posicion].Locked = true;
            _reporte.Range["D" + 2 + ":D" + posicion].Locked = true;
            _reporte.Range["F" + 2 + ":F" + posicion].Locked = true;
            _reporte.Range["G" + 2 + ":G" + posicion].Locked = true;
            _reporte.Range["H" + 2 + ":H" + posicion].Locked = true;
        }
        void Application_ActiveWorkbookChanges(Excel.Workbook wb)
        {
            // TODO: Active Workbook has changed. Ribbon should be updated.    
            wb.Unprotect();
        }
        public void ReporteImprimir(IRestResponse restResponse)
        {
            var rrg = Prop.Opcion.JsonaListaGenerica<Respuesta.Reporte.General.Respuesta>(restResponse);
            var reporte = InicializarExcelConTemplate("ReporteInventarioImprimir");
            if (reporte != null)
            {
                try
                {
                    var lista = new string[rrg.Count, 19];
                    for (var x = 0; x < rrg.Count; x++)
                    {
                        lista[x, 0] = rrg[x].clave;
                        lista[x, 1] = rrg[x].departamento;
                        lista[x, 2] = rrg[x].categoria;
                        lista[x, 3] = rrg[x].descripcion;
                        lista[x, 4] = rrg[x].tipo;
                        lista[x, 5] = rrg[x].existencia;
                        lista[x, 6] = rrg[x].consumoDiario;
                        lista[x, 7] = rrg[x].puntoReorden;
                        lista[x, 8] = rrg[x].inventarioMinimo;
                        lista[x, 9] = rrg[x].inventarioMaximo;
                        lista[x, 10] = rrg[x].factor;
                        lista[x, 11] = rrg[x].cantidadVendida;
                        lista[x, 12] = rrg[x].ventas;
                        lista[x, 13] = rrg[x].fechaUltimaCompra.ToString(CultureInfo.InvariantCulture);
                        lista[x, 14] = rrg[x].cantidadComprada;
                        lista[x, 15] = rrg[x].radioInventario;
                        lista[x, 16] = rrg[x].precioCompra;
                        lista[x, 17] = rrg[x].precioVenta;
                        lista[x, 18] = rrg[x].margen;
                    }
                    reporte.Range["A" + 2 + ":S" + rrg.Count].Value2 = lista;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public void Agregar(Respuesta.Receta receta,double cantidad)
        {
            Prop.Config.Local.Receta.IdReceta = receta.rec_id;
            Prop.Opcion.EjecucionAsync(Data.Receta.DetalleLista, jsonResult =>
            {
                List<Respuesta.Receta.Detalle> rrd = Prop.Opcion.JsonaListaGenerica<Respuesta.Receta.Detalle>(jsonResult);
                var oReportWs = InicializarExcelConTemplate("Receta");
                if (oReportWs != null)
                {
                    ((oReportWs.Range["NOMBRE"])).Value2 = receta.descripcion;
                    ((oReportWs.Range["PESO_LITRO"])).Value2 = receta.pesoLitro;
                    ((oReportWs.Range["LITROS_A_ELABORAR"])).Value2 = cantidad;
                    ((oReportWs.Range["CANTIDAD_A_ELABORAR"])).Value2 = cantidad*receta.pesoLitro   ;
                    ((oReportWs.Range["CODIGO"])).Value2 = receta.clave;
                    ((oReportWs.Range["MARGEN_ANTERIOR"])).Value2 = receta.margen;
                    ((oReportWs.Range["PRECIO_VENTA"])).Value2 = receta.precio;
                    ((oReportWs.Range["COSTO_PREPARACION"])).Value2 = receta.costoCreacion;
                    //oReportWs.Range["TABLA1"].CopyFromRecordset(ListToDataTable(rrd));
                    int inicioTabla = 5;
                    for (int i = 0; i <= rrd.Count; i++)
                    {          
                        oReportWs.Range["A" + inicioTabla].Value2 = rrd[i].clave; //clave
                        oReportWs.Range["B" + inicioTabla].Value2 = rrd[i].cantidad; //cantidad unitaria por medida
                        oReportWs.Range["C" + inicioTabla].Value2 = (rrd[i].cantidad)*cantidad; //cantidad total
                        oReportWs.Range["D" + inicioTabla].Value2 = rrd[i].unidad; //tipo de unidad
                        oReportWs.Range["E" + inicioTabla].Value2 = rrd[i].descripcion;//nombre
                        oReportWs.Range["F" + inicioTabla].Value2 = rrd[i].precioVenta; //valor unitario
                        oReportWs.Range["G" + inicioTabla].Value2 = (rrd[i].precioVenta)*((rrd[i].cantidad) * cantidad); //
                        inicioTabla++;
                    }
                }
            });     
        }
        public DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }

        private void ThisAddIn_Shutdown(object sender, EventArgs e)
        {
        }
        public static SideBarImportarInformacion SideBarImportarInformacion;
        public static Microsoft.Office.Tools.CustomTaskPane MyCustomTaskPane;


        protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject()
          {
              return new Ribbon1();
          }
        #region Código generado por VSTO

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InternalStartup()
        {
            Startup += ThisAddIn_Startup;
            Shutdown += ThisAddIn_Shutdown;
            
        }
        
        #endregion
    }
}
