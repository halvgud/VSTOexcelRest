using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;
using System.IO;

namespace testVSTO2
{
    public partial class ThisAddIn
    {
        SideBarImportarInformacion _inventario;
        private SideBarRecetario _recetario;
        public static Microsoft.Office.Tools.CustomTaskPane Inventario;
        public static Microsoft.Office.Tools.CustomTaskPane Recetario;
       // internal Microsoft.Office.Interop.Excel.Application Application2;
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            _inventario = new SideBarImportarInformacion();
            _recetario = new SideBarRecetario();
            Inventario = this.CustomTaskPanes.Add(_inventario, "Importar...");
            Inventario.Visible = false;
            Inventario.Width = 250;
            Recetario = this.CustomTaskPanes.Add(_recetario, "Recetario");
            Recetario.Visible = false;
            Recetario.Width = 250;
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

        public void Agregar(Respuesta.Receta receta,double cantidad)
        {
            Prop.Config.Local.Receta.IdReceta = receta.rec_id;
            Prop.Opcion.EjecucionAsync(Data.Receta.DetalleLista, jsonResult =>
            {
                List<Respuesta.Receta.Detalle> rrd = Prop.Opcion.JsonaListaGenerica<Respuesta.Receta.Detalle>(jsonResult);
                var oWb = Application.Workbooks.Application;
                var oWs = oWb.Worksheets.Item["Hoja1"];
                var sPath = Path.GetTempFileName();
                File.WriteAllBytes(sPath, Properties.Resources.FICHA_RECETA);
                var oTemplate = Application.Workbooks.Add(sPath);
                var worksheet = oTemplate.Worksheets[1] as Excel.Worksheet;
                worksheet?.Copy(After: oWs);
                oTemplate.Close(false, missing, missing);
                File.Delete(sPath);
                var oReportWs = oWb.Worksheets["Receta"] as Excel.Worksheet;
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
                        oReportWs.Range["C" + inicioTabla].Value2 = double.Parse(rrd[i].cantidad)*cantidad; //cantidad total
                        oReportWs.Range["D" + inicioTabla].Value2 = rrd[i].unidad; //tipo de unidad
                        oReportWs.Range["E" + inicioTabla].Value2 = rrd[i].descripcion;//nombre
                        oReportWs.Range["F" + inicioTabla].Value2 = rrd[i].precioVenta; //valor unitario
                        oReportWs.Range["G" + inicioTabla].Value2 = (rrd[i].precioVenta)*(double.Parse(rrd[i].cantidad) * cantidad); //
                        inicioTabla++;
                    }
                }
            });     
        }
        public static DataTable ListToDataTable<T>(IList<T> lst)
        {

            var currentDT = CreateTable<T>();

            Type entType = typeof(T);

            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entType);
            foreach (T item in lst)
            {
                DataRow row = currentDT.NewRow();
                foreach (PropertyDescriptor prop in properties)
                {

                    if (prop.PropertyType == typeof(Nullable<decimal>) || prop.PropertyType == typeof(Nullable<int>) || prop.PropertyType == typeof(Nullable<Int64>))
                    {
                        if (prop.GetValue(item) == null)
                            row[prop.Name] = 0;
                        else
                            row[prop.Name] = prop.GetValue(item);
                    }
                    else
                        row[prop.Name] = prop.GetValue(item);



                }
                currentDT.Rows.Add(row);
            }

            return currentDT;

        }

        public static DataTable CreateTable<T>()
        {
            Type entType = typeof(T);
            DataTable tbl = new DataTable("Tabla1");
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entType);
            foreach (PropertyDescriptor prop in properties)
            {
                if (prop.PropertyType == typeof(Nullable<decimal>))
                    tbl.Columns.Add(prop.Name, typeof(decimal));
                else if (prop.PropertyType == typeof(Nullable<int>))
                    tbl.Columns.Add(prop.Name, typeof(int));
                else if (prop.PropertyType == typeof(Nullable<Int64>))
                    tbl.Columns.Add(prop.Name, typeof(Int64));
                else
                    tbl.Columns.Add(prop.Name, prop.PropertyType);
            }
            return tbl;
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
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
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
            
        }
        
        #endregion
    }
}
