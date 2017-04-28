using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Herramienta;
using Respuesta;

// TODO:  Siga estos pasos para habilitar el elemento (XML) de la cinta de opciones:

// 1: Copie el siguiente bloque de código en la clase ThisAddin, ThisWorkbook o ThisDocument.

//  protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject()
//  {
//      return new Ribbon1();
//  }

// 2. Cree métodos de devolución de llamada en el área "Devolución de llamadas de la cinta de opciones" de esta clase para controlar acciones del usuario,
//    como hacer clic en un botón. Nota: si ha exportado esta cinta de opciones desde el diseñador de la cinta de opciones,
//    mueva el código de los controladores de eventos a los métodos de devolución de llamada y modifique el código para que funcione con el
//    modelo de programación de extensibilidad de la cinta de opciones (RibbonX).

// 3. Asigne atributos a las etiquetas de control del archivo XML de la cinta de opciones para identificar los métodos de devolución de llamada apropiados en el código.  

// Para obtener más información, vea la documentación XML de la cinta de opciones en la Ayuda de Visual Studio Tools para Office.


namespace ExcelAddIn1
{
    [ComVisible(true)]
    public class Ribbon1 : Office.IRibbonExtensibility
    {
        private Office.IRibbonUI _ribbon;

        public Ribbon1()
        {
        }
        public void AbrirRecetario(Office.IRibbonControl control)
        {
            ThisAddIn.ReporteReceta.Visible = false;
             ThisAddIn.Recetario.Visible = true;
        }

        public void AbrirReporteReceta(Office.IRibbonControl control)
        {
            ThisAddIn.Recetario.Visible = false;
            ThisAddIn.ReporteReceta.Visible = true;
        }
        //public void DetalleMenu(Office.IRibbonControl control)
        //{
        //    //ThisAddIn.DetalleMenu.Visible = true;
        //    ThisAddIn.ReporteReceta.Visible = false;
        //    ThisAddIn.Recetario.Visible = false;


        //}

        //public void PRUEBA(Office.IRibbonControl control)
        //{
        //    ThisAddIn.Recetario
        //}

        public void AbrirMenuSemanal(Office.IRibbonControl control)
        {
            var ms = new MenuSemanal();
            ms.Show();
        }
        public void CrearReceta(Office.IRibbonControl control)
        {
            var ar = new AgregarReceta();
            ar.Show();
        }

        public void ReporteCongelados(Office.IRibbonControl control)
        {
            var addIn = Globals.ThisAddIn;

            Opcion.EjecucionAsync(Data.Reporte.RepCongelados, y =>
            {
                addIn.ReporteCongelados(y);
            });
           
        }

        public void CapturaCongelado(Office.IRibbonControl control)
        {
            // seguir mañana
            var cc1 = new Congelados();
            cc1.Show();

            Opcion.EjecucionAsync(Data.Reporte.Listaplatillos, y =>
            {


                var cc = new Congelados(() =>
                {
                    var d = Opcion.JsonaListaGenerica<CbGenerico>(y).Select(x => x.Nombre).ToArray();
                    return d;
                });
                cc1.BeginInvoke((MethodInvoker)(() =>
                {
                    if (!cc.Visible)
                    {
                        cc.Show();
                    }
                    cc1.Hide();
                }));
            });
        }


        public bool BuscarPermiso(Office.IRibbonControl control)
        {
            return true;
        }


        #region Miembros de IRibbonExtensibility

        public string GetCustomUI(string ribbonID)
        {
            return GetResourceText("ExcelAddIn1.Ribbon1.xml");
        }

        #endregion

        #region Devoluciones de llamada de la cinta de opciones
        //Cree aquí métodos de devolución de llamada. Para obtener más información sobre los métodos de devolución de llamada, visite http://go.microsoft.com/fwlink/?LinkID=271226.

        public void Ribbon_Load(Office.IRibbonUI ribbonUI)
        {
            this._ribbon = ribbonUI;
        }

        #endregion

        #region Aplicaciones auxiliares

        private static string GetResourceText(string resourceName)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            string[] resourceNames = asm.GetManifestResourceNames();
            for (int i = 0; i < resourceNames.Length; ++i)
            {
                if (string.Compare(resourceName, resourceNames[i], StringComparison.OrdinalIgnoreCase) == 0)
                {
                    using (StreamReader resourceReader = new StreamReader(asm.GetManifestResourceStream(resourceNames[i])))
                    {
                        if (resourceReader != null)
                        {
                            return resourceReader.ReadToEnd();
                        }
                    }
                }
            }
            return null;
        }

        #endregion
    }
}
