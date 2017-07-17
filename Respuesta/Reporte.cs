using System;
using System.Collections.Generic;
using System.Dynamic;
using Microsoft.Office.Interop.Excel;


namespace Respuesta
{
    public class Reporte
    {
        public class General
        {
            public DateTime FechaIni { get; set; }
            public DateTime FechaFin { get; set; }
            public string DepId { get; set; }
            public string CatId { get; set; }
            public string ProId { get; set; }
            public List<string> ProId2 { get; set; } 
            public string OrderBy { get; set; }
            public string IdTipo { get; set; }
            public General() { }

           
            public class Respuesta
            {
                public string Clave { get; set; }
                public string Departamento { get; set; }
                public string Categoria { get; set; }
                public string Descripcion { get; set; }
                public string Tipo { get; set; }
                public double Existencia { get; set; }
                public double ExistenciaCedis { get; set; }
                public double ConsumoDiario { get; set; }
                public string PuntoReorden { get; set; }
                public double InventarioMinimo { get; set; }
                public double InventarioMaximo { get; set; }
                public double Factor { get; set; }
                public string CantidadVendida { get; set; }
                public string Ventas { get; set; }
                public DateTime FechaUltimaCompra { get; set; }
                public string CantidadComprada { get; set; }
                public string RadioInventario { get; set; }
                public string PrecioCompra { get; set; }
                public string PrecioVenta { get; set; }
                public string Margen { get; set; }
                public string CantidadPedir { get; set; }
            }

           


            public class InventarioCongelados
            {
                public string Id { get; set; }
                public string Clave { get; set; }
                public string Descripcion { get; set; }
                public Double Existencia { get; set; }
                public string Estado { get; set; }
                public string FechaEntrada { get; set; }

            }


            public class Posicion
            {
                public static int Clave { get; } = 0;
                public static int Departamento { get;  } = 1;
                public static int Categoria { get; set; } = 2;
                public static int Descripcion { get; set; } = 3;
                public static int Tipo { get; set; } = 4;
                public static int Existencia { get; set; } = 5;
                public static int ExistenciaCedis { get; set; } = 6;
                public static int ConsumoDiario { get; set; } = 7;
                public static int PuntoReorden { get; set; } = 8;
                public static int InventarioMinimo { get; set; } = 9;
                public static int InventarioMaximo { get; set; } = 10;
                public static int Factor { get; set; } = 11;
                public static int CantidadVendida { get; set; } = 12;
                public static int Ventas { get; set; }=13;
                public static int FechaUltimaCompra { get; set; } = 14;
                public static int CantidadComprada { get; set; } = 15;
                public static int RadioInventario { get; set; } = 16;
                public static int PrecioCompra { get; set; } = 17;
                public static int PrecioVenta { get; set; } = 18;
                public static int Margen { get; set; } = 19;

            }
        }



        public class RespuestaCocina
        {

            //public static CocinaDetalle cocinadetalle { get; set; }

            public string Clave { get; set; }
            public string Receta { get; set; }
            public string TipoProducto { get; set; }
            public double Cantidadinventario { get; set; }
            public string Categoria { get; set; }
            public string Estado { get; set; }
            public string Since { get; set; }
            public string UltimaElaboracion { get; set; }
            public  Double QtyUltimaElaboracion { get; set; }
            public string medida { get; set; }
            public string consumodia { get; set; }
            //public string Total { get; set; }
            //public string Nombre { get; set; }
            public Double Costo { get; set; }
            public Double Venta { get; set; }
            public Double Margen { get; set; }
            public Double Qty { get; set; }
            public Double Sinceqty { get; set; }
            
            public string Salesince { get; set; }
            
            public string ProfitSince { get; set; }
            public string Qtycongelado { get; set; }
            public string RecId { get; set; } 
            public string Preciocongelado { get; set; }
            public string Qtymermas { get; set; }
            public string Porcentajemerma { get; set; }
            public string Qtyperdidas { get; set; }
            public string Porcentajeperdida { get; set; }
            public string Qtyempleado { get; set; }
            public string Porcentajeempleado { get; set; }
            public string rutaimagen { get; set; }
            public string instrucciones { get; set; }
           
            

            public List<IngredientesCocina> Ingredientes { get; set; }
            public class IngredientesCocina
            {
                public string Nombre { get; set; }
                public double Cantidad { get; set; }
                public string Medida { get; set; }
                public double Costo { get; set; }
            }

            public class Ccocinadetalle
            {
                public string Clave { get; set; }
                public string Receta { get; set; }
                public string TipoProducto { get; set; }
                public double Cantidadinventario { get; set; }
                public string Categoria { get; set; }
                public string Estado { get; set; }
                public string Since { get; set; }
                public string UltimaElaboracion { get; set; }
                public Double QtyUltimaElaboracion { get; set; }
                public string medida { get; set; }
                public string consumodia { get; set; }
                //public string Total { get; set; }
                //public string Nombre { get; set; }
                public Double Costo { get; set; }
                public Double Venta { get; set; }
                public Double Margen { get; set; }
                public Double Sinceqty { get; set; }
                public Double Qty { get; set; }
                public string Salesince { get; set; }
                public string ProfitSince { get; set; }
                public string Qtycongelado { get; set; }
                public string RecId { get; set; }
                public string Preciocongelado { get; set; }
                public string Qtymermas { get; set; }
                public string Porcentajemerma { get; set; }
                public string Qtyperdidas { get; set; }
                public string Porcentajeperdida { get; set; }
                public string Qtyempleado { get; set; }
                public string Porcentajeempleado { get; set; }

            }

            public  class CocinaDetalle
            {
                public int NoMenus { get; set; }
                public double CantidadElaborada { get; set; }
                public double SobrantesPendiente { get; set; }
                public double Densidad { get; set; }
                public double Medida { get; set; }
                public string Receta { get; set; }
                public string Foto { get; set; }
                public double RecetaPara { get; set; }
                
            }

            public class Reportess
            {
                public int Id { get; set; }
                public string Orderby { get; set; }
                public DateTime FechaFinal { get; set; }
                public DateTime FechaInicio { get; set; }
            }



        }
    }
}
