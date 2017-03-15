
using System.Text.RegularExpressions;


namespace Respuesta
{
    public class Formulario
    {
        public string Formula { get; set; }
        public int Orden { get; set; }

        public string Posicion { get; set; }

        public string FormulaRegex(Microsoft.Office.Interop.Excel.Worksheet reporte, int c)
        {
            var r = Regex.Replace(Regex.Replace(Formula, "~c", c.ToString()), @"rango\(([A-Z]+\d+)\)", regex => reporte.Range[regex.Groups[1].Value.ToString()].Value2.ToString());
            return r;
        }

        public string PosicionRegex(int c)
        {
            return Regex.Replace(Posicion, "~c", c.ToString());
        }

    }
}
