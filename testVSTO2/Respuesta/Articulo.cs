
namespace testVSTO2.Respuesta
{
    public class Articulo
    {
        public int art_id { get; set; }
        public string clave { get; set; }
        public string claveAlterna { get; set; }
        public double precioCompra { get; set; }
        public double cantidad { get; set; }
        public double precioVenta { get; set; }
        public string idUnidad { get; set; }
        public string descripcion { get; set; }
        public double precioTotal { get; set; }

        public Basica CopiadoSencillo()
        {
            var art = new Basica {clave = clave, descripcion = descripcion, precioCompra = precioCompra, cantidad=cantidad,art_id=art_id};
            return art;
        }
        public class Basica
        {
            public int  art_id { get; set; }
            public string clave { get; set; }
            public string descripcion { get; set; }
            public double precioCompra { get; set; }
            public double cantidad { get; set; }
        }
    }

}
