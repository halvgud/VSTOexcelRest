using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testVSTO2.Respuesta
{
    public class Articulo
    {
        public string art_id { get; set; }
        public string clave { get; set; }
        public string claveAlterna { get; set; }
        public double precioCompra { get; set; }
        public double cantidad { get; set; }
        public double precioVenta { get; set; }
        public string idUnidad { get; set; }
        public string descripcion { get; set; }
        public double precioTotal { get; set; }

        public Basica CopiadoSencillo()
        {
            var art = new Basica {clave = clave, descripcion = descripcion, precioCompra = precioCompra, cantidad=cantidad};
            return art;
        }
        public class Basica
        {
            public string clave { get; set; }
            public string descripcion { get; set; }
            public double precioCompra { get; set; }
            public double cantidad { get; set; }
        }
    }

}
