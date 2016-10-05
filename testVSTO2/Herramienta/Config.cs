namespace testVSTO2.Herramienta
{
    namespace Config
    {
        public static class Log
        {
            public static class Interno
            {
                public static string Articulo { get; set; } = "articulo.log";
                public static string Categoria { get; set; } = "categoria.log";
                public static string Departamento { get; set; } = "departamento.log";
            }

            
        }
        public static class Local
        {
            public static class Api
            {
                public static string UrlApi { get; set; } = "http://192.168.0.2/apiMovStock/public/";
                public static string IdSucursal { get; set; } = "2";
            }
            public static class Articulo
            {
                public static string Lista { get; set; } = "articulo/";
                public static string IdArticulo { get; set; } = "";

                public static class Tipo
                {
                    public static string Seleccionar { get; set; } = "articulo/tipo";
                    public static string Guardar { get; set; } = "articulo/tipo";
                }

                public static class MaximosMinimos
                {
                    public static string Guardar { get; set; } = "articulo/maximosminimos";
                }

                public static class PrecioMargen
                {
                    public static string Guardar { get; set; } = "articulo/preciomargen";
                }
            }

            public static class Receta
            {
                public static string Lista { get; set; } = "receta/";
                public static string DetalleLista { get; set; } = "receta/detalle/";
                public static int IdReceta { get; set; }
                public static string clave { get; set; }
                public static string Insertar { get; set; } = "receta";
                public static string InsertarDetalle { get; set; } = "receta/detalle";
                public static string Tipo { get; set; } = "receta/tipo";

            }
            public static class Categoria
            {
                public static string Lista { get; set; } = "categoria/";
            }

            public static class Ordenar
            {
                public static string Lista { get; set; } = "ordenar/lista";
            }

            public static class Departamento
            {
                public static string Lista { get; set; } = "departamento";
                public static string IdDepartamento { get; set; }
            }
            public static class Parametro
            {
                public static string UrlImportar { get; set; }
            }

            public static class Permiso
            {
                public static string Obtener { get; set; } = "permiso";
            }


            public static class Inventario
            {
                public static string UrlImportar { get; set; }
                public static string UrlExportar { get; set; }
                public static string UrlActualizar { get; set; }
            }

            public static class Ajuste
            {
                public static string UrlImportar { get; set; }
                public static string UrlExportar { get; set; }
                public static string UrlActualizar { get; set; }
            }

            public static class Proveedor
            {
                public static string Lista { get; set; } = "proveedor";
            }

            public static class Reporte
            {
                public static string General { get; set; } = "reporte/general";
                public static string Imprimir { get; set; } = "reporte/general/imprimir";
            }

            public static class Formulario
            {
                public static class Reporte
                {
                    public static string Ruta { get; set; } = "formula/reporte/";
                    public static string Imprimir { get; set; } = "imprimir";
                    public static string General { get; set; } = "general";
                }
            }

            public static class Sucursal
            {
                public static string Lista { get; set; } = "sucursal";
            }
        }
    }
}
