using System;

namespace testVSTO2.Respuesta
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
            public string OrderBy { get; set; }

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
    }
}
