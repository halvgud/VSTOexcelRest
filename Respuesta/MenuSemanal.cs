using System.Collections.Generic;

namespace Respuesta
{
    public class MenuSemanal
    {
        public List<MenuDia> Lunes { get; set; } 
        public List<MenuDia> Martes { get; set; }
        public List<MenuDia> Miercoles { get; set; }
        public List<MenuDia> Jueves { get; set; }
        public List<MenuDia> Viernes { get; set; }
        public List<MenuDia> Sabado { get; set; }
        public List<MenuDia> Domingo { get; set; } 
        public MenuSemanal()
        {
            var claseDia = new MenuDia { TipoRecetaDgv = "", Platillo = "", CantidadElaborar = 0, UnidadDgv = "", PrecioCompra = 0, GananciaTotal= 0, Congelado = 0, MenId = 0};
            Lunes = new List<MenuDia> {claseDia};
            Martes = new List<MenuDia> {claseDia};
            Miercoles = new List<MenuDia> {claseDia};
            Jueves = new List<MenuDia> {claseDia};
            Viernes = new List<MenuDia> {claseDia};
            Sabado = new List<MenuDia> {claseDia};
            Domingo = new List<MenuDia> {claseDia};
        }
    }
    public class MenuDia
    {
      
        public string TipoRecetaDgv { get; set; }
        public string Platillo { get; set; }
        public double CantidadReceta { get; set; }
        public double CantidadElaborar { get; set; }
        public string UnidadDgv { get; set; }
        public double PrecioCompra { get; set; }
        public double GananciaTotal { get; set; }
        public int Congelado { get; set; }
       public int MenId { get; set; }
        public List<IngredientesReceta> Ingredientes { get; set; }
    }


    public class PlatilloReceta
    {
        public int RecId { get; set; }
        public  int TipoId { get; set; }
        public  string Platillo { get; set; }
        public string Clave { get; set; }
        public  double Congelado { get; set; }
        public int EstadoId { get; set; }
        public double CantidadReceta { get; set; }
        public double CostoElaboracion { get; set; }
        public double CostoCreacion { get; set; }
        public double GanaciaTotal { get; set; }
        public double PrecioCompra { get; set; }
        public double Precio { get; set; }
    }

    public class InsertarMenu
    {
        public  int MenId { get; set; }
        public int RecId { get; set; }
        public string Fecha { get; set; }
        public double Cantidad { get; set; }
        public  double PrecioFinal { get; set; }
        public  int TipoId { get; set; }
    }


    public class IngredientesReceta
    {
        public string ClaveReceta { get; set; }
        public string DescripcionReceta { get; set; }
       public string ArtId { get; set; }
        public string Descripcion { get; set; }
        public string Clave { get; set; }
        public double Cantidad { get; set; }
        public string Unidad { get; set; }
        public double PrecioCompra { get; set; }
        public  string Fecha { get; set; }
    }



 

    public class ListaDiario
    {
        public List<Diario> ListDiarios { get; set; } 
        //public ListaDiario()
        //{
        //    var Anterior = new Diario {Clave = "",Platillo = "",CantidadProgramada = 0,CantidadCocina = 0,CantidadVendida = 0,Sobrantes = 0,Observacion = ""};
        //    ListDiarios=new List<Diario> {Anterior};
        //} 
    }

    public class Diario
    {
        public int ArtId { get; set; }
        public string Clave { get; set; }
        public string Platillo { get; set; }
        public double CP { get; set; }
        public double CC { get; set; }
        public double CV { get; set; }
        public string Unidad { get; set; }
        public double SR { get; set; }
        public double S { get; set; }
        public string Observacion { get; set; }
        public List<Cantidades> ListaCantidades { get; set; }
        public class Cantidades
        {
            public int EstadoDescripcionId { get; set; }

            public double Cantidad { get; set; }
        }
    }


    public class DiarioX2
    {
        public string ArtId { get; set; }
        public string Clave { get; set; }
        public string Platillo { get; set; }
        public double CR { get; set; }
        public double RV { get; set; }
        public double SR { get; set; }
        public double S { get; set; }
        public string Fecha { get; set; }
        public int EstadoId { get; set; }
    }



}
