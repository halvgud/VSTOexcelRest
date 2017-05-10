using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
       }
    public class MenuDia
    {
        public string TipoRecetaDGV { get; set; }
        public string Platillo { get; set; }
        public DateTime FechaElaboracion { get; set; }
        public double Cantidad { get; set; }
        public string Unidad { get; set; }
        public double PrecioCompra { get; set; }
        public double GananciaTotal { get; set; }
    }

}
