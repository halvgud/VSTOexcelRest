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
            var claseDia = new MenuDia { TipoRecetaDgv = "", Platillo = "", Cantidad = 0, UnidadDgv = "", PrecioCompra = 0, GananciaTotal= 0};
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
        //public DateTime FechaElaboracion { get; set; }
        public double Cantidad { get; set; }
        public string UnidadDgv { get; set; }
        public double PrecioCompra { get; set; }
        public double GananciaTotal { get; set; }
        public List<IngredientesReceta> Ingredientes { get; set; }
    }


    public class MenuSemanalActual
    {
        public List<MenuDiasSemana> LunesActual { get; set; }
        public List<MenuDiasSemana> MartesActual { get; set; }
        public List<MenuDiasSemana> MiercolesActual { get; set; }
        public List<MenuDiasSemana> JuevesActual { get; set; }
        public List<MenuDiasSemana> ViernesActual { get; set; }
        public List<MenuDiasSemana> SabadoActual { get; set; }
        public List<MenuDiasSemana> DomingoActual { get; set; }
        public MenuSemanalActual()
        {
            var claseDia = new MenuDiasSemana { TipoRecetaDgv = "", Platillo = "",CantidadReceta = 0,Cantidad = 0, Unidad = "", PrecioCompra = 0, GananciaTotal = 0, Congelado = 0};
            LunesActual = new List<MenuDiasSemana> { claseDia };
            MartesActual = new List<MenuDiasSemana> { claseDia };
            MiercolesActual = new List<MenuDiasSemana> { claseDia };
            JuevesActual = new List<MenuDiasSemana> { claseDia };
            ViernesActual = new List<MenuDiasSemana> { claseDia };
            SabadoActual = new List<MenuDiasSemana> { claseDia };
            DomingoActual = new List<MenuDiasSemana> { claseDia };
        }
    }
    public class MenuDiasSemana
    {
        public string TipoRecetaDgv { get; set; }
        public string Platillo { get; set; }
        //public DateTime FechaElaboracion { get; set; }
        public double CantidadReceta { get; set; }
        public double Cantidad { get; set; }
        public string Unidad { get; set; }
        public double PrecioCompra { get; set; }
        public double GananciaTotal { get; set; }
        public  double Congelado { get; set; }
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
        public double CantidadElaboracion { get; set; }
        public double CostoElaboracion { get; set; }
        public double CostoCreacion { get; set; }
        public double Precio { get; set; }
        public List<PlatilloReceta> ListaPlatillos{ get; set; }
    }

    public class InsertarMenu
    {
        public int RecId { get; set; }
        public string Fecha { get; set; }
        public double Cantidad { get; set; }
        public  double PrecioFinal { get; set; }
        public  int TipoId { get; set; }
    }

    public class IngredientesReceta
    {
       public string ArtId { get; set; }
         public string Clave { get; set; }
        public  string Descripcion { get; set; }
        public double PrecioCompra { get; set; }
        public  double Cantidad { get; set; }
        public  string Fecha { get; set; }
        public  string Unidad { get; set; }
    }
}
