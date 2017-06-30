
using System;
using System.Collections.Generic;

namespace Respuesta
{

    public class CongeladoInventario
    {
        public  int EstadoInventario { get; set; }
        public int ArtIdInventario { get; set; }
        public string DescripcionInventario { get; set; }
        public double FechaInventario { get; set; }

    }
    public class Articulo
    {
        public int ArtId { get; set; }
        public string Clave { get; set; }
        public string ClaveAlterna { get; set; }
        public double PrecioCompra { get; set; }
        public double Cantidad { get; set; }
        public double PrecioVenta { get; set; }
        public string IdUnidad { get; set; }
        public string Descripcion { get; set; }
        public double PrecioTotal { get; set; }

        public Basica CopiadoSencillo()
        {
            var art = new Basica {Clave = Clave, Descripcion = Descripcion, PrecioCompra = PrecioCompra, Cantidad=Cantidad,ArtId=ArtId};
            return art;
        }
        public class Basica
        {
            public int  ArtId { get; set; }
            public string Clave { get; set; }
            public string Descripcion { get; set; }
            public double PrecioCompra { get; set; }
            public double Cantidad { get; set; }
            //public int Status { get; set; }
            //public DateTime Fecha { get; set; }
        }
        public class Guardar
        {
            public class Tipo
            {
                public string Clave { get; set; }
                public string tipo { get; set; }
            }
            public class MaximosMinimos
            {
                public string Clave { get; set; }
                public string InvMax { get; set; }
                public string InvMin { get; set; }
            }
            public class PrecioMargen
            {
                public string Clave { get; set; }
                public string Precio1 { get; set; }
                public string Margen1 { get; set; }
            }
        }
        
    }

}
