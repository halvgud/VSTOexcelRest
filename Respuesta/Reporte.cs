﻿using System;
using System.Collections.Generic;
using System.Dynamic;


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
                public string clave { get; set; }
                public string departamento { get; set; }
                public string categoria { get; set; }
                public string descripcion { get; set; }
                public string tipo { get; set; }
                public double existencia { get; set; }
                public double existenciaCedis { get; set; }
                public double consumoDiario { get; set; }
                public string puntoReorden { get; set; }
                public double inventarioMinimo { get; set; }
                public double inventarioMaximo { get; set; }
                public double factor { get; set; }
                public string cantidadVendida { get; set; }
                public string ventas { get; set; }
                public DateTime fechaUltimaCompra { get; set; }
                public string cantidadComprada { get; set; }
                public string radioInventario { get; set; }
                public string precioCompra { get; set; }
                public string precioVenta { get; set; }
                public string margen { get; set; }
                public string cantidadPedir { get; set; }
            }


            public class InventarioCongelados
            {
                public string id { get; set; }
                public string clave { get; set; }
                public string descripcion { get; set; }
                public Double existencia { get; set; }
                public string estado { get; set; }
                public string fechaEntrada { get; set; }

            }


            public class Posicion
            {
                public static int clave { get; } = 0;
                public static int departamento { get;  } = 1;
                public static int categoria { get; set; } = 2;
                public static int descripcion { get; set; } = 3;
                public static int tipo { get; set; } = 4;
                public static int existencia { get; set; } = 5;
                public static int existenciaCedis { get; set; } = 6;
                public static int consumoDiario { get; set; } = 7;
                public static int puntoReorden { get; set; } = 8;
                public static int inventarioMinimo { get; set; } = 9;
                public static int inventarioMaximo { get; set; } = 10;
                public static int factor { get; set; } = 11;
                public static int cantidadVendida { get; set; } = 12;
                public static int ventas { get; set; }=13;
                public static int fechaUltimaCompra { get; set; } = 14;
                public static int cantidadComprada { get; set; } = 15;
                public static int radioInventario { get; set; } = 16;
                public static int precioCompra { get; set; } = 17;
                public static int precioVenta { get; set; } = 18;
                public static int margen { get; set; } = 19;

            }
        }



        public class RespuestaCocina
        {

            //public static CocinaDetalle cocinadetalle { get; set; }

            public string Clave { get; set; }
            public string Receta { get; set; }
            public string TipoProducto { get; set; }
            public int CantidadInventario { get; set; }
            public string Categoria { get; set; }
            public string Estado { get; set; }
            public string Since { get; set; }
            public DateTime UltimaElaboracion { get; set; }
            public string Medida { get; set; }
            public string Consumopordia { get; set; }
            //public string Total { get; set; }
            //public string Nombre { get; set; }
            public Double Costo { get; set; }
            public Double Venta { get; set; }
            public Double Margen { get; set; }
            public int Qty { get; set; }
            public string Sale { get; set; }
            public string Profit { get; set; }
            public string Qtycongelado { get; set; }
            public string Preciocongelado { get; set; }
            public string Qtymermas { get; set; }
            public string Porcentajemerma { get; set; }
            public string Qtyperdidas { get; set; }
            public string Porcentajeperdida { get; set; }
            public string Qtyempleado { get; set; }
            public string Porcentajeempleado { get; set; }
           

            public List<IngredientesCocina> Ingredientes { get; set; }
            public class IngredientesCocina
            {
                public string Nombre { get; set; }
                public double Cantidad { get; set; }
                public double Medida { get; set; }
                public double Costo { get; set; }
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




        }
    }
}
