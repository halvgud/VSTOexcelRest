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
using testVSTO2.Respuesta;

namespace testVSTO2
{
    public partial class ThisAddIn
    {
        SideBarImportarInformacion _inventario;
        private SideBarRecetario _recetario;
        public static Microsoft.Office.Tools.CustomTaskPane Inventario;
        public static Microsoft.Office.Tools.CustomTaskPane Recetario;
        private Excel.Worksheet _reporte;
        Excel.Worksheet _sheet1;
        private int _rowCount;
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
        }
        
        void activeSheet_SelectionChange(Object sh,Excel.Range target)
        {
            _sheet1 = (Excel.Worksheet)Application.ActiveSheet;
            if (target.Row != 1)
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
            else
            {
                _sheet1.Unprotect();
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
                if (!found) { 
                var ows = Application.Worksheets[1];// excel actual
                var sPath = Path.GetTempFileName(); // archivo temporal
                File.WriteAllBytes(sPath, Properties.Resources.FICHA_RECETA);//se copia el template
                var oTemplate = Application.Workbooks.Add(sPath); //path del template temporal
                var worksheet = oTemplate.Worksheets[nombreHoja] as Excel.Worksheet;//nombre del template
                worksheet?.Copy(After: ows);
                oTemplate.Close(false, missing, missing);
                File.Delete(sPath);
                }
                reportet = awa.Worksheets[nombreHoja] as Excel.Worksheet;//nombre de la hoja actual   

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return reportet;
        }
             
        public void ReporteGeneral(IRestResponse restResponse)
        {
            var rrg = Prop.Opcion.JsonaListaGenerica<Reporte.General.Respuesta>(restResponse);
            _rowCount = (rrg.Count + 1);
            _reporte =InicializarExcelConTemplate("ReporteInventario");
            var list = new List<string> { "P-1", "P-.5", "1", "4", "DESCONOCIDO" };
            var flatList = string.Join(",", list.ToArray());
            if (_reporte != null)
            {
                try
                {
                    Application.Cells.Locked = false;
                    var sourceRange = _reporte.Range["A" + 1 + ":S" + _rowCount];
                    foreach (
                        var l in
                            from Excel.Worksheet ws in Application.ActiveWorkbook.Worksheets
                            from l in ws.ListObjects.Cast<Excel.ListObject>()
                            select l)
                        sourceRange.Worksheet.ListObjects[l.Name].Delete();
                    sourceRange.Worksheet.ListObjects.Add(Excel.XlListObjectSourceType.xlSrcRange, sourceRange,
                        Type.Missing,
                        Excel.XlYesNoGuess.xlYes,
                        Type.Missing).Name = "tabla2";
                    sourceRange.Select();
                    sourceRange.Worksheet.ListObjects["tabla2"].TableStyle = "TableStyleLight8";
                    _reporte.Range["A1:S1"].Value2 = InicializarTitulos();
                    _reporte.Columns["A:C"].ColumnWidth = 10.71;
                    _reporte.Range["A1:S1"].Style.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    _reporte.Range["A1:S1"].Style.VerticalAlignment = Excel.XlVAlign.xlVAlignTop;
                    _reporte.Range["A1:S1"].WrapText = true;
                    _reporte.Columns["D:D"].ColumnWidth = 26.71;
                    _reporte.Columns["E:M"].ColumnWidth = 10.71;
                    _reporte.Columns["N:N"].ColumnWidth = 17;
                    _reporte.Columns["O:S"].ColumnWidth = 10.71;
                    _reporte.Range["A" + 2 + ":S" + _rowCount].Value2 = InicializarLista(rrg);
                    _reporte.Range["F" + 2 + ":F" + _rowCount].NumberFormat = "0.0";
                    _reporte.Range["E" + 2 + ":E" + _rowCount].Validation.Delete();
                    _reporte.Range["E" + 2 + ":E" + _rowCount].Validation.Add(Excel.XlDVType.xlValidateList,
                        Excel.XlDVAlertStyle.xlValidAlertInformation,
                        Excel.XlFormatConditionOperator.xlBetween,
                        flatList,
                        Type.Missing);
                    BloquearRango(_rowCount);
                    _sheet1.Protect(AllowSorting: true, AllowFiltering: true);

                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            else
            {
                MessageBox.Show(@"No se encontraron resultados con la busqueda indicada");
            }
        }

        private static string[,] InicializarTitulos()
        {
            var titulos = new string[1, 19];

            titulos[0, 0] = "Clave";
            titulos[0, 1] = "Departamento";
            titulos[0, 2] = "Categoria";
            titulos[0, 3] = "Producto";
            titulos[0, 4] = "Tipo";
            titulos[0, 5] = "Inventario Sistema";
            titulos[0, 6] = "Consumo Diario Promedio";
            titulos[0, 7] = "Punto de Re-ORDEN";
            titulos[0, 8] = "Inv. Min";
            titulos[0, 9] = "Inv. Max";
            titulos[0, 10] = "Factor";
            titulos[0, 11] = "Cantidad Articulos vendidors";
            titulos[0, 12] = "Ventas";
            titulos[0, 13] = "Fecha Ultima Compra";
            titulos[0, 14] = "Cantidad Comprada";
            titulos[0, 15] = "Radio Inventario";
            titulos[0, 16] = "Precio de Compra";
            titulos[0, 17] = "Precio Venta";
            titulos[0, 18] = "Margen";
            return titulos;
        }
        private static object[,] InicializarLista(IReadOnlyList<Reporte.General.Respuesta> rrg)
        {
            var lista = new object[rrg.Count, 19];
            for (var x = 0; x < rrg.Count; x++)
            {
                lista[x, 0] = rrg[x].clave+"";
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
                lista[x, 18] = Double.Parse(rrg[x].margen) / 100;
            }
            return lista;
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
            var rrg = Prop.Opcion.JsonaListaGenerica<Reporte.General.Respuesta>(restResponse);

            _reporte = InicializarExcelConTemplate("ReporteInventarioImprimir");
            _rowCount = rrg.Count + 4;
            if (_reporte != null)
            {
                try
                {
                    var lista = new string[rrg.Count, 9];
                    for (var x = 0; x < rrg.Count; x++)
                    {
                        lista[x, 0] = rrg[x].descripcion;
                        lista[x, 1] = rrg[x].tipo;
                        lista[x, 2] = rrg[x].existencia;
                        lista[x, 3] = rrg[x].consumoDiario;
                        lista[x, 5] = rrg[x].inventarioMinimo;
                        lista[x, 6] = rrg[x].inventarioMaximo;
                        lista[x, 7] = rrg[x].factor;
                    }
                    if (_reporte.AutoFilter != null)
                    {
                        _reporte.AutoFilterMode = false;
                    }
                    _reporte.Range["A" + 5 + ":I" + _rowCount].Value2 = lista;
                    for (var x = 0; x < rrg.Count; x++)
                    {
                        var c = (x + 5);
                        var formula= @"=SI(B" + c + @"=""P-.5"",""Semanal"",SI(B" + c + @"=""P-1"",""Semanal"",SI(B" + c + @"=1,REDONDEAR.MAS(F" + c + @"+(D" + c + @"*2),0),SI(B" + c + @"=4,REDONDEAR.MAS(F" + c + @"/2,0),""N/A""))))";
                        _reporte.Range["E" + c].FormulaLocal = formula;
                        formula = @"=SI(B" + c + @"=""P-.5"",REDONDEA.IMPAR((G" + c + @"-C" + c + @") / H" + c + @"),SI(B" + c + @" = ""P-1"",REDONDEAR.MAS(((G" + c + @" - C" + c + @") / H" + c + @"), 0), SI(B" + c + @" = 1,REDONDEAR.MAS((G" + c + @" / H" + c + @"), 0), SI(B" + c + @" = 4,SI(F" + c + @" > H" + c + @", F" + c + @", H" + c + @"),""PEDIDO DESCONOCIDO""))))";
                        _reporte.Range["I" + c].FormulaLocal = formula;
                    }
                    var oRng = _reporte.Range["A4", "I"+(rrg.Count+5)];
                    oRng.Cells.AutoFilter(9, ">0",
                                            Excel.XlAutoFilterOperator.xlAnd, Type.Missing, true);

                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        public void Agregar(Receta receta,double cantidad)
        {
            Prop.Config.Local.Receta.IdReceta = receta.rec_id;
            Prop.Opcion.EjecucionAsync(Data.Receta.DetalleLista, jsonResult =>
            {
                List<Receta.Detalle> rrd = Prop.Opcion.JsonaListaGenerica<Receta.Detalle>(jsonResult);
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
