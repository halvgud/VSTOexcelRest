using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;
using Microsoft.Office.Tools;
using testVSTO2.Respuesta;

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


namespace testVSTO2
{
    [ComVisible(true)]
    public class Ribbon1 : Office.IRibbonExtensibility
    {
        private Office.IRibbonUI ribbon;

        public Ribbon1()
        {
        }

        #region Miembros de IRibbonExtensibility

        public string GetCustomUI(string ribbonID)
        {
            return GetResourceText("testVSTO2.Ribbon1.xml");
        }

        #endregion

        #region Devoluciones de llamada de la cinta de opciones
        //Cree aquí métodos de devolución de llamada. Para obtener más información sobre los métodos de devolución de llamada, visite http://go.microsoft.com/fwlink/?LinkID=271226.

        public void Ribbon_Load(Office.IRibbonUI ribbonUI)
        {
            ribbon = ribbonUI;
            Prop.Opcion.EjecucionAsync(Data.Permiso.ObtenerPermiso, x =>
            {
                _listaribbon = Prop.Opcion.JsonaListaGenerica<Respuesta.Permiso.Respuesta>(x);
            });
            foreach (var elemento in _listaribbon)
            {
                listaBools.Add(elemento.IdControl,(elemento.Valor=="1"));
                SetearPermiso((elemento.Valor=="1"),elemento.IdControl);// GetType().GetMethod(elemento.Descripcion).Invoke(this, new object[] { elemento.Valor,elemento.IdControl });
            }

        }
        private List<Respuesta.Permiso.Respuesta> _listaribbon = new List<Respuesta.Permiso.Respuesta>();
        Dictionary<string, bool> listaBools = new Dictionary<string, bool>();
        public void ImportarInformacion(Office.IRibbonControl control)
        {
            ThisAddIn.Recetario.Visible = false;
            ThisAddIn.Inventario.Visible = true;

            SetearPermiso(true, control.Id);
        }

        public void AbrirRecetario(Office.IRibbonControl control)
        {
            ThisAddIn.Inventario.Visible = false;
            ThisAddIn.Recetario.Visible = true;
        }
        public void CrearReceta(Office.IRibbonControl control)
        {
            ThisAddIn.Inventario.Visible = false;
            ThisAddIn.Recetario.Visible = false;
            var ar=new AgregarReceta();
            ar.Show();
        }
        
        public bool BuscarPermiso(Office.IRibbonControl control)
        {
            return listaBools[control.Id];
        }

        public void SetearPermiso(bool isEnabled,string id)
        {
            listaBools[id] = isEnabled;
            ribbon.Invalidate();
        }
        public void AbrirConfiguracion(Office.IRibbonControl control)
        {
            
            ribbon.Invalidate();
        }
        #endregion

        #region Aplicaciones auxiliares

        private static string GetResourceText(string resourceName)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            string[] resourceNames = asm.GetManifestResourceNames();
            foreach (string t in resourceNames)
            {
                if (string.Compare(resourceName, t, StringComparison.OrdinalIgnoreCase) != 0) continue;
                using (var resourceReader = new StreamReader(asm.GetManifestResourceStream(t)))
                {
                    return resourceReader.ReadToEnd();
                }
            }
            return null;
        }

        #endregion
    }
}
