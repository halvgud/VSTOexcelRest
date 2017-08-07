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
        public double PrecioTotal { get; set; }
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
            public double PrecioTotal { get; set; }
            public int TiporId { get; set; }
            public double CostoCreacion { get; set; }
            public double CostoElaboracion { get; set; }
            public double Margen { get; set; }
            public double PesoLitro { get; set; }
            public int Diario { get; set; }
            public double CantidadDiario { get; set; }
            public  double CantidadElaboracion { get; set;}
            public  int UnidadElaboracion { get; set; }
        }

        public class InsertarReceta
        {
            public string Clave { get; set; }
            public string Descripcion { get; set; }
            public double Precio { get; set; }
            public double PrecioTotal { get; set; }
            public int TiporId { get; set; }
            public double CostoCreacion { get; set; }
            public double CostoElaboracion { get; set; }
            public double Margen { get; set; }
            public double PesoLitro { get; set; }
            public int Diario { get; set; }
            public double CantidadDiario { get; set; }
            public double CantidadElaboracion { get; set; }
            public int UnidadElaboracion { get; set; }
        }
        public class IngredientesRecetaPrecio
        {
            public string Clave { get; set; }
            public string Receta { get; set; }
            public Double PrecioAnterior { get; set; }
            public Double PrecioNuevo { get; set; }
        }

        public class Diaanterior
        {
            public string Fecha1 { get; set; }
            public string Fecha2 { get; set; }
            public string FechaIni { get; set; }
            public string FechaFin { get; set; }
        }

        public class DiaanteriorX2
        {
            public string Fecha1R { get; set; }
            public string Fecha2R { get; set; }
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

        public class Savedaily
        {
            public int EstadoDescripcionId { get; set; }
            public int EstadoInventarioId { get; set; }
            public string ArtId { get; set; }
            public string Clave { get; set; }
            public string Platillo { get; set; }
            public double Cantidad { get; set; }
            public double CantidadCocina { get; set; }
            public  string Fecha { get; set; }
            public  string Status { get; set; }
            public string Observacion { get; set; }
        }


        public class ReventaDiarios
        {
            public int EstadoDescripcionId { get; set; }
            public int EstadoInventarioId { get; set; }
            public string Clave { get; set; }
            public string Platillo { get; set; }
            public double Cantidad { get; set; }
            public string Fecha { get; set; }
        }


        public class Congelados
        {
          // public string EstadoId { get; set; } 
            public int EstadoId { get; set; }
            /*Te sale en la primer columna, porque esta aqui, tienes que hacer un select..... PERO EL ESTADO ID ES AUTO INCREMENTAL, y pCaraR qEue olo quieren aquiCRE_O QUE SI ES AUTO INCREMENTAL 
            POR QUE DE ESTE MISMO AGO LA BUSQUEDA ENTRE CONGELADOS , cual es tu duda entonces? si en el select no esta POR QUE NO ESTA GUARDANDO COMO ES DEVIDO MIRA */
            public string ArtId { get; set; }
            public string Clave { get; set; }
            public string Platillo { get; set; }
            public double Cantidad { get; set; }
            public List<Congelados> ListaCongelados { get; set; }

            public BasicaCopia CopiadoSencilloCongelado()
            {
                var art = new BasicaCopia {ArtId = ArtId, Clave = Clave, Descripcion = Platillo, Cantidad = Cantidad};

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
            public string Clave { get; set; }
            public string Descripcion { get; set; }
            public double Cantidad { get; set; }
            public string clave { get; set; }
            public string descripcion { get; set; }
            public double cantidad { get; set; }
            // public string status { get; set; }
            // public DateTime fechaEntrada { get; set; }
        }

        public class Congelados2
        {
            public int EstadoId { get; set; }
            /*Te sale en la primer columna, porque esta aqui, tienes que hacer un select..... PERO EL ESTADO ID ES AUTO INCREMENTAL, y pCaraR qEue olo quieren aquiCRE_O QUE SI ES AUTO INCREMENTAL 
            POR QUE DE ESTE MISMO AGO LA BUSQUEDA ENTRE CONGELADOS , cual es tu duda entonces? si en el select no esta POR QUE NO ESTA GUARDANDO COMO ES DEVIDO MIRA */
            public string ArtId { get; set; }
            public string Clave { get; set; }
            public string Platillo { get; set; }
            public double Cantidad { get; set; } 
        }

    }

    public class Agregarcongelados/* y esta clase para que es? para que hay mande los datos que se van a agregar  ..... te refieres a la de congelados si mmmmm y que los datos los puedas cambiar en el data */
        {
            public int Id { get; set; }
            public string Clave { get; set; }
            public string Nombre { get; set; }
            public  List<Agregarcongelados> ListaAgregarcongeladoses { get; set; } 
        }





