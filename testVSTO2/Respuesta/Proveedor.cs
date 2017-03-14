using System;

namespace testVSTO2.Respuesta
{
    class Proveedor
    {
        public int ProId { get; set; }
        public string Nombre { get; set; }
        public string Representante { get; set; }
        public string Alias { get; set; }
        public string[] Tags { get; set; }

        public bool Seleccionar { get; set; }
    }
}
