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
        public int TiporId { get; set; }
        public double CostoCreacion { get; set; }
        public double CostoElaboracion { get; set; }
        public double Margen { get; set; }
        public DateTime FechaModificacion { get; set; }
        public double PesoLitro { get; set; }
        public int Diario { get; set; }
        public double CantidadDiario { get; set; }
        public double CantidadElaboracion { get; set; }
        public int UnidadElaboracion { get; set; }
        public string Rutaimagen { get; set; }
        public string Instrucciones { get; set; }
        public List<Detalle> Ingredientes { get; set; }
        public string ModoElaboracion { get; set; }
      
        public Basica CopiadoSencillo()
        {
            var art = new Basica {Clave = Clave, Descripcion = Descripcion, Cantidad = CantidadDiario, Precio = Precio};
            return art;
        }

        public class ActualizaPresupuesto
        {
            public int RecId { get; set; }
            public string Clave { get; set; }
            public string Descripcion { get; set; }
            public double Precio { get; set; }
            public int TiporId { get; set; }
            public double CostoCreacion { get; set; }
            public double CostoElaboracion { get; set; }
            public double Margen { get; set; }
            public DateTime FechaModificacion { get; set; }
            public double PesoLitro { get; set; }
            public int Diario { get; set; }
            public double CantidadDiario { get; set; }
            public  double CantidadElaboracion { get; set;}
            public  int UnidadElaboracion { get; set; }
        }

        public class ImagenAndProcess
        {
            public int RecId { get; set; }
            public string Instrucciones { get; set; }
            public string RutaImagen { get; set; }
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
            public double PrecioCompra { get; set; }
            public double PrecioVenta { get; set; }
            public int IdUnidad { get; set; }
            public string Unidad { get; set; }
            public double PrecioTotal { get; set; }
            public int TiporId { get; set; }
        }
        public class Congelados
        {
           public string EstadoId { get; set; } 
            public string ArtId { get; set; }
           
            public string Clave { get; set; }
            public string Descripcion { get; set; }
            public double Cantidad { get; set; }
            public List<Congelados> ListaCongelados { get; set; }
           
            public BasicaCopia CopiadoSencilloCongelado()
            {
                var art = new BasicaCopia { ArtId = ArtId, Clave = Clave, Descripcion = Descripcion, Cantidad = Cantidad};
                return art;
            }
        }

        public class BasicaCopia
        {
            public string ArtId { get; set; }
            public string EstadoId { get; set; }
            public string Clave{ get; set; }
            public string Descripcion { get; set; }
            public double Cantidad { get; set; }
        }

    }
        public class Agregarcongelados
        {
             public int Id { get; set; }
            public string Clave { get; set; }
            public string Nombre { get; set; }
            public  List<Agregarcongelados> ListaAgregarcongeladoses { get; set; } 

        }

    public class Congelados
    {
        public string Clave { get; set; }
        public string Descripcion { get; set; }
        public double Cantidad { get; set; }
        public int Status { get; set; }
        public DateTime FechaEntrada { get; set; }
        public List<Congelados> ListaCongelados { get; set; }
}
}



