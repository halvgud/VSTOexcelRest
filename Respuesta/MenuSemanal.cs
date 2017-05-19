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

        public MenuSemanal()
        {
            var claseDia = new MenuDia { TipoRecetaDgv = "", Platillo = "", FechaElaboracion = new DateTime(), Cantidad = 0, Unidad = "", PrecioCompra = 0, GananciaTotal = 0 };
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
        public string Unidad { get; set; }
        public double PrecioCompra { get; set; }
        public double GananciaTotal { get; set; }
    }

    public class AutoCompletePlatillo
    {
        public string Id { get; set; }
        public  string Tipo { get; set; }
        public  string Platillo { get; set; }
    }
}
