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
        //public List<Congelados> ListaCongelados { get; set; }
        public  string ModoElaboracion { get; set; }
        public  List<Semana> ListaSemana { get; set; } 
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


        public class Semana
        {
            public static DateTime Lunes { get; set; }
            public static DateTime Martes { get; set; }
            public static DateTime Miercoles { get; set; }
            public static DateTime Jueves { get; set; }
            public static DateTime Viernes { get; set; }
            public static DateTime Sabado { get; set; }
            public static DateTime Domingo { get; set; }
        }
        public class MenuSemana
        {
            public string Tipo { get; set; }
            public string Platillo { get; set; }
            public  int Fecha { get; set; }
            public  int Cantidad { get; set; }
            public string Unidad { get; set; }
            public  int Precio { get; set; }
            public  int Ganancia { get; set; }
         }
        public class Congelados
        {
            public int estado_id { get; set; }
            public string clave { get; set; }
            public string descripcion { get; set; }
            public double cantidad { get; set; }
            public string status { get; set; }/*te lo cambie a string, con eso agarrara*/
            /*aqui estas confundiendo el status de activo e inactivo con el ESTADO de Congelado y los otros que hipoteticamente pudieran crearse :P*/
            public DateTime fechaEntrada { get; set; }
            public List<Congelados> ListaCongelados { get; set; }
        }
 }
}


       public class MenuDia
       {
           public string Tipo { get; set; }
           public string Platillo { get; set; }
           public int Fecha { get; set; }
           public int Cantidad { get; set; }
           public string Unidad { get; set; }
           public int Precio { get; set; }
           public int Ganancia { get; set; }
       }


      

       
    


