using System;
using System.Collections.Generic;


namespace Respuesta
{
   public class Receta
    {
        public int RecId { get; set; }
        public string Clave { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public double CostoCreacion { get; set; }
        public double CostoElaboracion { get; set; }
        public double Margen { get; set; }
        public  DateTime FechaModificacion { get; set; }
        public double PesoLitro { get; set; }
        public int Diario { get; set; }
        public double Cantidad { get; set; }
        public List<Detalle> Ingredientes { get; set; }
        public List<Congelados> ListaCongelados { get; set; }
        public  string ModoElaboracion { get; set; }


        public Basica CopiadoSencillo()
        {
            var art = new Basica { Clave = Clave, Descripcion = Descripcion, Cantidad = Cantidad, Precio=Precio };
            return art;
        }
        public class Basica
        {
            public string Clave { get; set; }
            public string Descripcion { get; set; }
            public double Precio { get; set; }
            public double Cantidad { get; set; }
        }



       public class Detalle
       {
            public int RecId { get; set; }
            public int ArtId { get; set; }
            public string Descripcion { get; set; }
            public string Clave { get; set; }
            public double Cantidad { get; set; }
            public double  PrecioCompra { get; set; }
            public double PrecioVenta { get; set; }
            public int IdUnidad { get; set; }
            public string Unidad { get; set; }
            public double PrecioTotal { get; set; }
       }

        public class Congelados
        {
            
            public string clave { get; set; }
            public string descripcion { get; set; }
            public double cantidad { get; set; }
            public int status { get; set; }
            public DateTime fechaEntrada { get; set; }
            public List<Congelados> ListaCongelados { get; set; }
        }

        public class Congelados2 
        {
             
        }
    }
}
