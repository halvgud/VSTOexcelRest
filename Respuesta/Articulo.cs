
using System;

namespace Respuesta
{
    public class Articulo
    {
        public int art_id { get; set; }
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
            var art = new Basica {Clave = clave, Descripcion = descripcion, PrecioCompra = precioCompra, Cantidad=cantidad,ArtId=art_id};
            return art;
        }
        public class Basica
        {
            public int  ArtId { get; set; }
            public string Clave { get; set; }
            public string Descripcion { get; set; }
            public double PrecioCompra { get; set; }
            public double Cantidad { get; set; }
            public int status { get; set; }
            public DateTime fecha { get; set; }
        }

   

        public class Guardar
        {
            public class Tipo
            {
                public string clave { get; set; }
                public string tipo { get; set; }
            }

            public class MaximosMinimos
            {
                public string clave { get; set; }
                public string invMax { get; set; }
                public string invMin { get; set; }
            }

            public class PrecioMargen
            {
                public string clave { get; set; }
                public string precio1 { get; set; }
                public string margen1 { get; set; }
            }
        }
        
    }

}
