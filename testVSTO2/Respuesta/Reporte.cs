using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testVSTO2.Respuesta
{
    public class Reporte
    {
        public class General
        {
            public DateTime fechaIni { get; set; }
            public DateTime fechaFin { get; set; }
            public int dep_id { get; set; }
            public int cat_id { get; set; }

            public class Respuesta
            {
                public string clave { get; set; }
                public string departamento { get; set; }
                public string categoria { get; set; }
                public string descripcion { get; set; }
                public string tipo { get; set; }
                public string existencia { get; set; }
                public string consumoDiario { get; set; }
                public string puntoReorden { get; set; }
                public string inventarioMinimo { get; set; }
                public string inventarioMaximo { get; set; }
                public string factor { get; set; }
                public string cantidadVendida { get; set; }
                public string ventas { get; set; }
                public DateTime fechaUltimaCompra { get; set; }
                public string cantidadComprada { get; set; }
                public string radioInventario { get; set; }
                public string precioCompra { get; set; }
                public string precioVenta { get; set; }
                public string margen { get; set; }
            }
        }
    }
}
