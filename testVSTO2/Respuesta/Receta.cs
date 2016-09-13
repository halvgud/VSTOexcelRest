using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testVSTO2.Respuesta
{
   public class Receta
    {
        public string rec_id { get; set; }
        public string clave { get; set; }
        public string descripcion { get; set; }
        public double precio { get; set; }
        public  double costoCreacion { get; set; }
        public double margen { get; set; }
        public  DateTime fechaModificacion { get; set; }
        public double pesoLitro { get; set; }

       public class Detalle
       {
            public string rec_id { get; set; }
            public string art_id { get; set; }
            public string descripcion { get; set; }
            public string clave { get; set; }
            public string cantidad { get; set; }
            public double  precioCompra { get; set; }
            public double precioVenta { get; set; }
            public int idUnidad { get; set; }
            public string unidad { get; set; }
            public double precioTotal { get; set; }
       }
    }
}
