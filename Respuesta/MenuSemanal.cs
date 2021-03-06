﻿using System.Collections.Generic;
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
            var claseDia = new MenuDia { TipoReceta = "", Platillo = "", CantidadElab = 0, Unidad = "", Precio = 0, Venta= 0, Congelado = 0, MenId = 0};
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
        public string TipoReceta { get; set; }
        public string Platillo { get; set; }
        public double CantidadReceta { get; set; }
        public double CantidadElab { get; set; }
        public string Unidad { get; set; }
        public double Precio  { get; set; }
        public double Venta  { get; set; }
        public double Congelado { get; set; }
        public int MenId { get; set; }
        public string UltimaElaboracion { get; set; }
        public List<IngredientesReceta> Ingredientes { get; set; }
    }

    public class PlatilloReceta
    {
        public string TipoReceta { get; set; }
        public int RecId { get; set; }
        public  int TipoId { get; set; }
        public  string Platillo { get; set; }
        public string Clave { get; set; }
        public  double Congelado { get; set; }
        public int EstadoId { get; set; }
        public double CantidadReceta { get; set; }
        public double CantidadElab { get; set; }
        public double CostoElaboracion { get; set; }
        public double CostoCreacion { get; set; }
        public double Venta { get; set; }
        public double PrecioCompra { get; set; }
        public double Precio { get; set; }
        public string Unidad { get; set; }
        public int MenId { get; set; }
        public string UltimaElaboracion { get; set; }
        public string Fecha { get; set; }
        public List<PlatilloReceta> Lunes { get; set; }
        public List<PlatilloReceta> Martes { get; set; }
        public List<PlatilloReceta> Miercoles { get; set; }
        public List<PlatilloReceta> Jueves { get; set; }
        public List<PlatilloReceta> Viernes { get; set; }
        public List<PlatilloReceta> Sabado { get; set; }
        public List<PlatilloReceta> Domingo { get; set; }
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
    public class Diario
    {
        public int ArtId { get; set; }
        public string Clave { get; set; }
        public string Platillo { get; set; }
        public double CP { get; set; }
        public double CR { get; set; }
        public double CV { get; set; }
        public string Unidad { get; set; }    
        public double S { get; set; }
        public double SR { get; set; }
        public string Observacion { get; set; }
        public int EstadoInventarioId { get; set; }
    }
    public class DiarioX2
    {
        public string ArtId { get; set; }
        public string Clave { get; set; }
        public string Platillo { get; set; }
        // ReSharper disable once InconsistentNaming
        public double CR { get; set; }
        // ReSharper disable once InconsistentNaming
        public double RV { get; set; }
        // ReSharper disable once InconsistentNaming
        public double SR { get; set; }
        public double S { get; set; }
        public string Fecha { get; set; }
        public int EstadoId { get; set; }
    }

    public class ReportePlatilllosDiarios
    {
        public  string Clave { get; set; }
        public string Platillo { get; set; }
        public  double Existencia { get; set; }
        // ReSharper disable once InconsistentNaming
        public  double CP { get; set; }
        // ReSharper disable once InconsistentNaming
        public double CE { get; set; }
        // ReSharper disable once InconsistentNaming
        public double CR { get; set; }
        public  double VentaAnterios { get; set; }
        public  double VentaPromedio { get; set; }
    }



}
