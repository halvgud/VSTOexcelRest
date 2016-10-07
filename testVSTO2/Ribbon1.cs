using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using testVSTO2.Herramienta;
using Office = Microsoft.Office.Core;
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
        private Office.IRibbonUI _ribbon;

        #region Miembros de IRibbonExtensibility

        public string GetCustomUI(string ribbonId)
        {
            return GetResourceText("testVSTO2.Ribbon1.xml");
        }

        #endregion

        #region Devoluciones de llamada de la cinta de opciones
        //Cree aquí métodos de devolución de llamada. Para obtener más información sobre los métodos de devolución de llamada, visite http://go.microsoft.com/fwlink/?LinkID=271226.

        public void Ribbon_Load(Office.IRibbonUI ribbonUi)
        {
            _ribbon = ribbonUi;
            Opcion.EjecucionAsync(Data.Permiso.ObtenerPermiso, x =>
            {
                _listaribbon = Opcion.JsonaListaGenerica<Permiso.Respuesta>(x);
            });
            foreach (var elemento in _listaribbon)
            {
                _listaBools.Add(elemento.IdControl,(elemento.Valor=="1"));
                SetearPermiso((elemento.Valor=="1"),elemento.IdControl);// GetType().GetMethod(elemento.Descripcion).Invoke(this, new object[] { elemento.Valor,elemento.IdControl });
            }

        }
        private List<Permiso.Respuesta> _listaribbon = new List<Permiso.Respuesta>();
        readonly Dictionary<string, bool> _listaBools = new Dictionary<string, bool>();
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
        }public void CrearReceta(Office.IRibbonControl control)
        {
            ThisAddIn.Inventario.Visible = false;
            ThisAddIn.Recetario.Visible = false;
            var ar=new AgregarReceta();
            ar.Show();
        }

        public void GuardarPrecioMargen(Office.IRibbonControl control)
        {
            try
            {

                string name = Globals.ThisAddIn.Application.ActiveSheet.Name;
                if (name.Equals(@"ReporteInventario"))
                {
                    var mse = new MensajeDeEspera();
                    mse.Show();
                    var sheet = Globals.ThisAddIn.Application.ActiveSheet;
                    var nInLastRow = sheet.Cells.Find("*", Missing.Value,
    Missing.Value, Missing.Value, Microsoft.Office.Interop.Excel.XlSearchOrder.xlByRows,
    Microsoft.Office.Interop.Excel.XlSearchDirection.xlPrevious, false, Missing.Value, Missing.Value)
    .Row;
                    object[,] value = sheet.Range["A2","T" + nInLastRow].Value;
                    var lista = new List<Articulo.Guardar.PrecioMargen>();
                    for (var x =1; x <= (value.Length / 20); x++)
                    {
                        lista.Add(new Articulo.Guardar.PrecioMargen
                        {
                            clave = value[x, Reporte.General.Posicion.clave+1].ToString(),
                            precio1 = value[x, Reporte.General.Posicion.precioVenta+1].ToString(),
                            margen1 = value[x, Reporte.General.Posicion.margen+1].ToString()
                        });
                    }
                    Opcion.EjecucionAsync(x =>
                    {
                        Data.Articulo.PrecioMargen.Guardar(x, lista);
                    }, y =>{
                        mse.BeginInvoke((MethodInvoker)(() =>
                        {
                            mse.Close();
                        }));
                        MessageBox.Show(Opcion.JsonaString(y.Content));
                    });
                }
                else
                {
                    throw new Exception(@"Debes escoger la hoja de trabajo 'ReporteInventario' para seleccionar esta opción.");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void GuardarMaximosMinimos(Office.IRibbonControl control)
        {
            try
            {

                string name = Globals.ThisAddIn.Application.ActiveSheet.Name;
                if (name.Equals(@"ReporteInventario"))
                {
                    var mse = new MensajeDeEspera();
                    mse.Show();
                    var sheet = Globals.ThisAddIn.Application.ActiveSheet;
                    var nInLastRow = sheet.Cells.Find("*", Missing.Value,
    Missing.Value, Missing.Value, Microsoft.Office.Interop.Excel.XlSearchOrder.xlByRows,
    Microsoft.Office.Interop.Excel.XlSearchDirection.xlPrevious, false, Missing.Value, Missing.Value)
    .Row;
                    object[,] value = sheet.Range["A2", "K" + nInLastRow].Value;
                    var lista = new List<Articulo.Guardar.MaximosMinimos>();
                    for (var x = 1; x <= (value.Length / 11); x++)
                    {
                        lista.Add(new Articulo.Guardar.MaximosMinimos
                        {
                            clave = value[x, Reporte.General.Posicion.clave+1].ToString(),
                            invMin = value[x, Reporte.General.Posicion.inventarioMinimo+1].ToString(),
                            invMax = value[x, Reporte.General.Posicion.inventarioMaximo+1].ToString()
                        });
                    }
                    Opcion.EjecucionAsync(x =>
                    {
                        Data.Articulo.MaximosMinimos.Guardar(x, lista);
                    }, y =>
                    {
                        mse.BeginInvoke((MethodInvoker)(() =>
                        {

                            mse.Close();
                        }));
                        MessageBox.Show(Opcion.JsonaString(y.Content));
                        Console.WriteLine(y.Content);
                    });
                }
                else
                {
                    throw new Exception(@"Debes escoger la hoja de trabajo 'ReporteInventario' para seleccionar esta opción.");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void GuardarTipoArticulo(Office.IRibbonControl control)
        {
            try
            {

                string name = Globals.ThisAddIn.Application.ActiveSheet.Name;
                if (name.Equals(@"ReporteInventario"))
                {
                    var mse = new MensajeDeEspera();
                    mse.Show();var sheet = Globals.ThisAddIn.Application.ActiveSheet;
                    var nInLastRow = sheet.Cells.Find("*", Missing.Value,
                        Missing.Value, Missing.Value, Microsoft.Office.Interop.Excel.XlSearchOrder.xlByRows,
                        Microsoft.Office.Interop.Excel.XlSearchDirection.xlPrevious, false, Missing.Value, Missing.Value)
                        .Row;
                    object[,] value = sheet.Range["A2", "E" + nInLastRow].Value;
                   var lista = new List<Articulo.Guardar.Tipo>();
                    for (var x = 1; x <= (value.Length/5); x++)
                    {
                        lista.Add(new Articulo.Guardar.Tipo
                        {
                            clave = value[x, Reporte.General.Posicion.clave+1].ToString(),
                            tipo = value[x, Reporte.General.Posicion.tipo+1].ToString()
                        });
                    }
                    Opcion.EjecucionAsync(x =>
                    {
                        Data.Articulo.Tipo.Guardar(x, lista);

                    }, y =>
                    {
                        mse.BeginInvoke((MethodInvoker)(() =>
                        {

                            mse.Close();
                        }));
                        MessageBox.Show(Opcion.JsonaString(y.Content));
                        Console.WriteLine(y.Content);
                    });
                }
                else
                {
                    MessageBox.Show(
                        @"Debes escoger la hoja de trabajo 'ReporteInventario' para seleccionar esta opción.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        public bool BuscarPermiso(Office.IRibbonControl control)
        {
            return _listaBools[control.Id];
        }

        public void SetearPermiso(bool isEnabled,string id)
        {
            _listaBools[id] = isEnabled;
            _ribbon.Invalidate();
        }
        public void AbrirConfiguracion(Office.IRibbonControl control)
        {
            
            _ribbon.Invalidate();
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
