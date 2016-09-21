using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testVSTO2.Prop
{
    public class Config
    {
        public class Log
        {
            public class Interno
            {
                public static string Articulo { get; set; } = "articulo.log";
                public static string Categoria { get; set; } = "categoria.log";
                public static string Departamento { get; set; } = "departamento.log";
            }

            
        }
        public class Local
        {
            public class Api
            {
                public static string UrlApi { get; set; } = "http://mercattoserver/apiMovStock/public/";
            }
            public class Articulo
            {
                public static string Lista { get; set; } = "articulo/";
                public static string IdArticulo { get; set; } = "";

                public class Tipo
                {
                    public static string Seleccionar { get; set; } = "articulo/tipo";
                }
            }

            public class Receta
            {
                public static string Lista { get; set; } = "receta/";
                public static string DetalleLista { get; set; } = "receta/detalle/";
                public static int IdReceta { get; set; }
                public static string clave { get; set; }
                public static string Insertar { get; set; } = "receta";
                public static string InsertarDetalle { get; set; } = "receta/detalle";
                public static string Tipo { get; set; } = "receta/tipo";

            }
            public class Categoria
            {
                public static string Lista { get; set; } = "categoria/";
            }

            public class Departamento
            {
                public static string Lista { get; set; } = "departamento";
                public static string IdDepartamento { get; set; }
            }
            public class Parametro
            {
                public static string UrlImportar { get; set; }
            }

            public class Permiso
            {
                public static string Obtener { get; set; } = "permiso";
            }


            public class Inventario
            {
                public static string UrlImportar { get; set; }
                public static string UrlExportar { get; set; }
                public static string UrlActualizar { get; set; }
            }

            public class Ajuste
            {
                public static string UrlImportar { get; set; }
                public static string UrlExportar { get; set; }
                public static string UrlActualizar { get; set; }
            }

            public class Proveedor
            {
                public static string Lista { get; set; } = "proveedor";
            }

            public class Reporte
            {
                public static string General { get; set; } = "reporte/general";
            }
        }
    }
}
