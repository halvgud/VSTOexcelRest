using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;
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

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            _reportes = new List<Reportes> {
            new Reportes { Nombre = "ReporteInventario"},
            new Reportes { Nombre= "ReporteInventarioImprimir" }
            };
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

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
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
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
