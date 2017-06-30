using System;
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
        public List<AutoCompletePlatillo> IdList { get; set; }
        public MenuSemanal()
        {
            var claseDia = new MenuDia { TipoRecetaDgv = "", Platillo = "", FechaElaboracion = new DateTime(), Cantidad = 0, UnidadDgv = "", PrecioCompra = 0, GananciaTotal = 0};
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
        public DateTime FechaElaboracion { get; set; }
        public double Cantidad { get; set; }
        public string UnidadDgv { get; set; }
        public double PrecioCompra { get; set; }
        public double GananciaTotal { get; set; }
    }

    public class AutoCompletePlatillo
    {
        public int RecId { get; set; }
        public  int TipoId { get; set; }
        public  string Platillo { get; set; }
        public string Clave { get; set; }
        public  double Congelado { get; set; }
        public List<AutoCompletePlatillo> ListaPlatillos{ get; set; }
    }

    public class InsertarMenu
    {
        public int RecId { get; set; }
        public string Fecha { get; set; }
        public double Cantidad { get; set; }
        public  double PrecioFinal { get; set; }
        public  int TipoId { get; set; }
    }


    public class ListasInsertarMenus
    {
        public List<InsertarMenu> LunesMenus { get; set; }
        public List<InsertarMenu> MartesMenus { get; set; }
        public  List<InsertarMenu> MiercolesMenus { get; set; }
        public List<InsertarMenu> JuevesMenus { get; set; }
        public List<InsertarMenu>ViernesMenus { get; set; } 
        public List<InsertarMenu>SabadoMenus { get; set; } 
        public  List<InsertarMenu> DomingoMenus { get; set; }

       
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
