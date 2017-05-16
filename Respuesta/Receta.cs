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
        public double CostoCreacion { get; set; }
        public double CostoElaboracion { get; set; }
        public double Margen { get; set; }
        public DateTime FechaModificacion { get; set; }
        public double PesoLitro { get; set; }
        public int Diario { get; set; }
        public double Cantidad { get; set; }
        public List<Detalle> Ingredientes { get; set; }
       
        public string ModoElaboracion { get; set; }
      
        public Basica CopiadoSencillo()
        {
            var art = new Basica {Clave = Clave, Descripcion = Descripcion, Cantidad = Cantidad, Precio = Precio};
            return art;
        }



        public class Imagen_and_Process
        {
            public int recid { get; set; }
            public string instruccion { get; set; }
            public string ruta { get; set; }
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

        }
        public class Congelados
        {
            public string estado_id { get; set; }
            public string art_id { get; set; }
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
                var art = new BasicaCopia { art_id = art_id, clave = clave, descripcion = descripcion, cantidad = cantidad};
                return art;
            }


        }

        public class BasicaCopia
        {
            public string art_id { get; set; }
            public string estado_id { get; set; }
            public string clave{ get; set; }
            public string descripcion { get; set; }
            public double cantidad { get; set; }
           // public string status { get; set; }
           // public DateTime fechaEntrada { get; set; }
        }

    }
        public class Agregarcongelados/* y esta clase para que es? para que hay mande los datos que se van a agregar  ..... te refieres a la de congelados si mmmmm y que los datos los puedas cambiar en el data */
        {
             public int id { get; set; }
            public string clave { get; set; }
            public string nombre { get; set; }
            public  List<Agregarcongelados> ListaAgregarcongeladoses { get; set; } 

        }

    public class Congelados
    {
        public string clave { get; set; }
        public string descripcion { get; set; }
        public double cantidad { get; set; }
        public int status { get; set; }
        public DateTime fechaEntrada { get; set; }
        public List<Congelados> ListaCongelados { get; set; }

}
}



