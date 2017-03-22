using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Reflection;
using RestSharp;
using Herramienta;
using Respuesta;
using Herramienta.Config;

namespace testVSTO2
{
    public partial class ThisAddIn
    {
        SideBarImportarInformacion _inventario;
        private SideBarRecetario _recetario;
        public static Microsoft.Office.Tools.CustomTaskPane Inventario;
        public static Microsoft.Office.Tools.CustomTaskPane Recetario;
        private List<Reportes> _reportes; 
        class Reportes
        {
            public string Nombre { get; set; }
        }
        private Excel.Worksheet _reporte;
        Excel.Worksheet _sheet1;
        private int _rowCount;
        private void ThisAddIn_Startup(object sender, EventArgs e)
        {
            _reportes = new List<Reportes> { 
            new Reportes { Nombre = "ReporteInventario"},
            new Reportes { Nombre= "ReporteInventarioImprimir" }
            };
            _inventario = new SideBarImportarInformacion();
            _recetario = new SideBarRecetario();
            Inventario = CustomTaskPanes.Add(_inventario, "Importar...");
            Inventario.Visible = false;
            Inventario.Width = 280;
            Recetario = CustomTaskPanes.Add(_recetario, "Recetario");
            Recetario.Visible = false;
            Recetario.Width = 280;
            Application.WorkbookActivate +=
           Application_ActiveWorkbookChanges;
            Application.WorkbookDeactivate +=Application_ActiveWorkbookChanges;
            Globals.ThisAddIn.Application.SheetSelectionChange += activeSheet_SelectionChange;
            _sheet1 = (Excel.Worksheet) Application.ActiveSheet;
        }
        
        void activeSheet_SelectionChange(object sh,Excel.Range target)
        {
             _sheet1 = (Excel.Worksheet)sh;
            if (target.Row != 1 && (_reportes.FirstOrDefault(x=>x.Nombre== _sheet1.Name)!=null) )
            {
                try
                {
                    _sheet1.Unprotect();
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
            try
            {
                _sheet1 = (Excel.Worksheet)Application.ActiveSheet;
                _sheet1.Unprotect();
                var found = Application.Sheets.Cast<Excel.Worksheet>().Any(sheet => sheet.Name == nombreHoja);
                var awa = Application.Workbooks.Application;//nueva app
                if (!found) { 
                    var ows = Application.Worksheets[1];// excel actual
                    var sPath = Path.GetTempFileName(); // archivo temporal
                    File.WriteAllBytes(sPath, Properties.Resources.FICHA_RECETA);//se copia el template
                    var oTemplate = Application.Workbooks.Add(sPath); //path del template temporal  
                    var worksheet = oTemplate.Worksheets[nombreHoja] as Excel.Worksheet;//nombre del template
                    worksheet?.Copy(After: ows);oTemplate.Close(false, missing, missing);
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
                
        public void ReporteGeneral(IRestResponse restResponse,Action callback)
        {
            Application.ScreenUpdating = false;
            var rrg = Opcion.JsonaListaGenerica<Reporte.General.Respuesta>(restResponse);
            _rowCount = (rrg.Count + 1);
            _reporte =InicializarExcelConTemplate("ReporteInventario"); //TODO traer de la base de datos 
            var list = new List<string> { "P-1", "P-.5","PD", "1", "4", "DESCONOCIDO" };//TODO traer de la base de datos
            var flatList = string.Join(",", list.ToArray());
            if (_reporte != null)
            {
                try
                {
                    Application.Cells.Locked = false;
                    var oRng = _reporte.Range["A1", "T" + (rrg.Count+1)];
                    oRng.Cells.AutoFilter(1, Type.Missing,Excel.XlAutoFilterOperator.xlAnd, Type.Missing, true);
                    _reporte.Range[
                        "A" + 2 + ":T" + Globals.ThisAddIn.Application.ActiveSheet.Cells.Find("*", Missing.Value,
                            Missing.Value, Missing.Value, Excel.XlSearchOrder.xlByRows,
                           Excel.XlSearchDirection.xlPrevious, false, Missing.Value,
                            Missing.Value)
                            .Row].Value2 = "";
                    _reporte.Range["A" + 2 + ":T" + _rowCount].Value2 = InicializarLista(rrg); 
                    _reporte.Range["F" + 2 + ":F" + _rowCount].NumberFormat = "0.0";
                    _reporte.Range["T" + 2 + ":T" + _rowCount].NumberFormat = "0.000";
                    _reporte.Range["E" + 2 + ":E" + _rowCount].Validation.Delete();
                    _reporte.Range["E" + 2 + ":E" + _rowCount].Validation.Add(Excel.XlDVType.xlValidateList,
                    Excel.XlDVAlertStyle.xlValidAlertInformation,Excel.XlFormatConditionOperator.xlBetween,flatList,Type.Missing);
                    ConfigurarFormulas(Local.Formulario.Reporte.General, 2, rrg.Count, resultado =>
                    {
                        _sheet1.Protect(AllowSorting: true, AllowFiltering: true, UserInterfaceOnly: true);
                        callback();
                        Application.ScreenUpdating = true;
                    });
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);}
            }
            else
            {
                MessageBox.Show(@"No se encontraron resultados con la busqueda indicada");
            }
        }

        private void ConfigurarFormulas(string reporte,int posicion,int longitud, Action<Excel.Worksheet> callback)
        {

            Opcion.EjecucionAsync(parametro =>
            {
                Data.Formulario.Obtener(reporte, parametro);
            }, jsonResult =>
            {
                try
                {
                    var formulario = Opcion.JsonaListaGenerica<Formulario>(jsonResult);
                    for (var x = 0; x < longitud; x++)
                    {
                        var c = (x + posicion);
                        foreach (var t in formulario)
                        {
                            _reporte.Range[t.PosicionRegex(c)].FormulaLocal = t.FormulaRegex(_reporte, c);
                        }
                    }
                    callback(_reporte);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
               
            });
        }
        private static object[,] InicializarLista(IReadOnlyList<Reporte.General.Respuesta> rrg)
        {
            var lista = new object[rrg.Count, 20];
            for (var x = 0; x < rrg.Count; x++)
            {
                lista[x, Reporte.General.Posicion.clave]                = rrg[x].clave+"";
                lista[x, Reporte.General.Posicion.departamento]         = rrg[x].departamento;
                lista[x, Reporte.General.Posicion.categoria]            = rrg[x].categoria;
                lista[x, Reporte.General.Posicion.descripcion]          = rrg[x].descripcion;
                lista[x, Reporte.General.Posicion.tipo]                 = rrg[x].tipo;
                lista[x, Reporte.General.Posicion.existencia]           = rrg[x].existencia;
                lista[x, Reporte.General.Posicion.existenciaCedis]      = rrg[x].existenciaCedis;
                lista[x, Reporte.General.Posicion.consumoDiario]        = rrg[x].consumoDiario;
                lista[x, Reporte.General.Posicion.puntoReorden]         = rrg[x].puntoReorden;
                lista[x, Reporte.General.Posicion.inventarioMinimo]     = rrg[x].inventarioMinimo;
                lista[x, Reporte.General.Posicion.inventarioMaximo]     = rrg[x].inventarioMaximo;
                lista[x, Reporte.General.Posicion.factor]               = rrg[x].factor;
                lista[x, Reporte.General.Posicion.cantidadVendida]      = rrg[x].cantidadVendida;
                lista[x, Reporte.General.Posicion.ventas]               = rrg[x].ventas;
                lista[x, Reporte.General.Posicion.fechaUltimaCompra]    = rrg[x].fechaUltimaCompra.ToString(CultureInfo.InvariantCulture);
                lista[x, Reporte.General.Posicion.cantidadComprada]     = rrg[x].cantidadComprada;
                lista[x, Reporte.General.Posicion.radioInventario]      = rrg[x].radioInventario;
                lista[x, Reporte.General.Posicion.precioCompra]         = rrg[x].precioCompra;
                lista[x, Reporte.General.Posicion.precioVenta]          = rrg[x].precioVenta;
                lista[x, Reporte.General.Posicion.margen]               = double.Parse(rrg[x].margen) / 100;
            }
            return lista;
        }
        private void BloquearRango(int posicion)
        {
            _reporte.Range["A" + 2 + ":A" + posicion].Locked = true;//CLAVE
            _reporte.Range["B" + 2 + ":B" + posicion].Locked = true;//DEPARTAMENTO
            _reporte.Range["C" + 2 + ":C" + posicion].Locked = true;//CATEGORIA
            _reporte.Range["D" + 2 + ":D" + posicion].Locked = true;//PRODUCTO
            _reporte.Range["F" + 2 + ":F" + posicion].Locked = true;//INVENTARIO SISTEMA
            _reporte.Range["G" + 2 + ":G" + posicion].Locked = true;//INVENTARIO CEDIS
            _reporte.Range["H" + 2 + ":H" + posicion].Locked = true;//CONSUMO DIARIO PROMEDIO
            _reporte.Range["I" + 2 + ":I" + posicion].Locked = true;//PUNTO DE REORDEN  
            _reporte.Range["L" + 2 + ":L" + posicion].Locked = true;//FACTOR
            _reporte.Range["M" + 2 + ":M" + posicion].Locked = true;//CANTIDAD DE ARTICULOS VENDIDOS
            _reporte.Range["N" + 2 + ":N" + posicion].Locked = true;//VENTAS
            _reporte.Range["O" + 2 + ":O" + posicion].Locked = true;//FECHA DE ULTIMA COMPRA
            _reporte.Range["P" + 2 + ":P" + posicion].Locked = true;//CANTIDAD COMPRADA
            _reporte.Range["Q" + 2 + ":Q" + posicion].Locked = true;//RADIO INVENTARIO
            _reporte.Range["R" + 2 + ":R" + posicion].Locked = true;//PRECIO DE COMPRA
            _reporte.Range["T" + 2 + ":T" + posicion].Locked = true;//MARGEN
        }
        void Application_ActiveWorkbookChanges(Excel.Workbook wb)
        {
            // TODO: Active Workbook has changed. Ribbon should be updated.    
            //wb.Unprotect();
        }

        public void ReporteImprimir(IRestResponse restResponse,Action callback ){
            var rrg = Opcion.JsonaListaGenerica<Reporte.General.Respuesta>(restResponse);
            Application.ScreenUpdating = false;
            _reporte = InicializarExcelConTemplate("ReporteInventarioImprimir");
            _rowCount = rrg.Count + 4;
            if (_reporte != null)
            {
                try{
                    var lista = new object[rrg.Count, 10];
                    for (var x = 0; x < rrg.Count; x++)
                    {
                        lista[x, 0] = rrg[x].descripcion;
                        lista[x, 1] = rrg[x].tipo;
                        lista[x, 2] = rrg[x].existencia;
                        lista[x, 3] = rrg[x].consumoDiario;
                        lista[x, 5] = rrg[x].inventarioMinimo;
                        lista[x, 6] = rrg[x].inventarioMaximo;
                        lista[x, 7] = rrg[x].factor;
                        lista[x, 8] = rrg[x].radioInventario;
                    }
                    if (_reporte.AutoFilter != null)
                    {
                        _reporte.AutoFilterMode = false;
                    }
                    _reporte.Range["A" + 5 + ":J" + Globals.ThisAddIn.Application.ActiveSheet.Cells.Find("*", Missing.Value,
                           Missing.Value, Missing.Value, Excel.XlSearchOrder.xlByRows,
                          Excel.XlSearchDirection.xlPrevious, false, Missing.Value,
                           Missing.Value).Row+1].Value2 = "";_reporte.Range["A" + 5 + ":I" + _rowCount].Value2 = lista;
                    //LINEAS BORDES Y ESTRUCTURA DE EXCEL
                    _reporte.Range["A" + 5 + ":J" + _rowCount].Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                    _reporte.Range["A" + 5 + ":J" + _rowCount].Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
                    _reporte.Range["A" + 5 + ":J" + _rowCount].Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
                    _reporte.Range["A" + 5 + ":J" + _rowCount].Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlContinuous;
                    _reporte.Range["A" + 5 + ":J" + _rowCount].Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                    _reporte.Range["A" + 5 + ":J" + _rowCount].Borders.Color = Color.Black;
                    _reporte.Range["A" + 5 + ":J" + _rowCount].Font.Size = 8;
                    _reporte.Range["A" + 5 + ":J" + _rowCount].WrapText = true;
                    _reporte.Range["A"+5+":J"+_rowCount].Cells.HorizontalAlignment =Excel.XlHAlign.xlHAlignLeft;
                    _reporte.Range["J5:J"+_rowCount].Interior.Color = ColorTranslator.ToOle(Color.Yellow);
                    ConfigurarFormulas(Local.Formulario.Reporte.Imprimir, 5, rrg.Count, resultado =>
                    {
                        
                        resultado.Range["C" + 5 + ":D" + _rowCount].NumberFormat = "0.00";
                        resultado.Range["F" + 5 + ":H" + _rowCount].NumberFormat = "0.00";
                        resultado.Range["FECHA_INI_IMP"].Value2 = Data.Reporte.FechaIni;
                        resultado.Range["FECHA_FIN_IMP"].Value2 = Data.Reporte.FechaFin;
                        var oRng = resultado.Range["A4", "J" + (rrg.Count + 5)];
                        oRng.Cells.AutoFilter(10, ">0", Excel.XlAutoFilterOperator.xlAnd, Type.Missing, true);
                        callback();
                        Application.ScreenUpdating = true;
                    });
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        public void Agregar(Receta receta)
        {
            Local.Receta.IdReceta = receta.RecId;
             var oReportWs = InicializarExcelConTemplate("Receta");
            if (oReportWs == null) return;
            ((oReportWs.Range["NOMBRE"])).Value2 = receta.Descripcion;
            ((oReportWs.Range["PESO_LITRO"])).Value2 = receta.PesoLitro;
            ((oReportWs.Range["LITROS_A_ELABORAR"])).Value2 = receta.Cantidad;
            ((oReportWs.Range["CANTIDAD_A_ELABORAR"])).Value2 = receta.Cantidad*receta.PesoLitro;
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
                oReportWs.Range["C" + inicioTabla].Value2 = (t.Cantidad)*receta.Cantidad;
                //cantidad total
                oReportWs.Range["D" + inicioTabla].Value2 = t.Unidad; //tipo de unidad
                oReportWs.Range["E" + inicioTabla].Value2 = t.Descripcion; //nombre
                oReportWs.Range["F" + inicioTabla].Value2 = t.PrecioVenta; //valor unitario
                oReportWs.Range["G" + inicioTabla].Value2 = (t.PrecioVenta)*
                                                            ((t.Cantidad)*receta.Cantidad); //
                inicioTabla++;
            }
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
