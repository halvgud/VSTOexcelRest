﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;


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
        public double Cantidad { get; set; }
<<<<<<< HEAD
        public double Dcantidad { get; set; }
        public int Unidad { get; set; }
        public string Rutaimagen { get; set; }
        public string Instrucciones { get; set; }
        public List<Detalle> Ingredientes { get; set; }
       
=======
        public List<Detalle> Ingredientes { get; set; } 
>>>>>>> origin/master
        public string ModoElaboracion { get; set; }
      
        public Basica CopiadoSencillo()
        {
            var art = new Basica {Clave = Clave, Descripcion = Descripcion, Cantidad = Cantidad, Precio = Precio};
            return art;
        }
<<<<<<< HEAD

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
           // public DateTime FechaModificacion { get; set; }
            public double PesoLitro { get; set; }
            public int Diario { get; set; }
           // public double Cantidad { get; set; }
        }

        public class ImagenAndProcess
=======
    
        public class Imagen_and_Process
>>>>>>> origin/master
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
            public double Dcantidad { get; set; }
            public int Dunidad { get; set; }
            public int Diario { get; set; }

        }
        public class Congelados
        {
<<<<<<< HEAD
           public string EstadoId { get; set; } /*Te sale en la primer columna, porque esta aqui, tienes que hacer un select..... PERO EL ESTADO ID ES AUTO INCREMENTAL, y pCaraR qEue olo quieren aquiCRE_O QUE SI ES AUTO INCREMENTAL 
            POR QUE DE ESTE MISMO AGO LA BUSQUEDA ENTRE CONGELADOS , cual es tu duda entonces? si en el select no esta POR QUE NO ESTA GUARDANDO COMO ES DEVIDO MIRA */
            public string ArtId { get; set; }
           
            public string Clave { get; set; }
            public string Descripcion { get; set; }
            public double Cantidad { get; set; }
            public List<Congelados> ListaCongelados { get; set; }
           
            public BasicaCopia CopiadoSencilloCongelado()
            {
                var art = new BasicaCopia { ArtId = ArtId, Clave = Clave, Descripcion = Descripcion, Cantidad = Cantidad};
=======
            public string EstadoId { get; set; }
            public string ArtId { get; set; }
            // public string estado_id { get; set; }
            public string clave { get; set; }
            public string descripcion { get; set; }
            public double cantidad { get; set; }
            public List<Congelados> ListaCongelados { get; set; }
            //  public string status { get; set; } /*te lo cambie a string, con eso agarrara*/
            /*aqui estas confundiendo el status de activo e inactivo con el ESTADO de Congelado y los otros que hipoteticamente pudieran crearse :P*/
            //   public DateTime fechaEntrada { get; set; }

            public BasicaCopia CopiadoSencilloCongelado()
            {
                var art = new BasicaCopia { ArtId = ArtId, clave = clave, descripcion = descripcion, cantidad = cantidad};
>>>>>>> origin/master
                return art;
            }
        }

        public class BasicaCopia
        {
            public string ArtId { get; set; }
            public string EstadoId { get; set; }
<<<<<<< HEAD
            public string Clave{ get; set; }
            public string Descripcion { get; set; }
            public double Cantidad { get; set; }
=======
            public string clave{ get; set; }
            public string descripcion { get; set; }
            public double cantidad { get; set; }
>>>>>>> origin/master
           // public string status { get; set; }
           // public DateTime fechaEntrada { get; set; }
        }

    }
        public class Agregarcongelados/* y esta clase para que es? para que hay mande los datos que se van a agregar  ..... te refieres a la de congelados si mmmmm y que los datos los puedas cambiar en el data */
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



