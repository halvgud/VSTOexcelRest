namespace Herramienta
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

        public static class Cocina
        {
            public static class ReporteRecetario
            {
                public static string Orden { get; set; } = Properties.Settings.Default.Orden;
                public static string ReporteCocina { get; set; } = Properties.Settings.Default.ReporteReceta;
            }

           

            public static class Concepto
            {
                public static string OrdenConcepto { get; set; } = Properties.Settings.Default.Concepto;
            }
        }

       

        public static class Local
        {

            public static class Api
            {
                public static string UrlApi { get; set; } = Properties.Settings.Default.UrlApi;
                public static string UrlLocal { get; set; } = "http://localhost:8080/apimovstock/public/";
                public static string IdSucursal { get; set; } = Properties.Settings.Default.IdSucursal;
            }
            public static class Articulo
            {
                public static string Lista { get; set; } = Properties.Settings.Default.ArticuloLista;
                public static string IdArticulo { get; set; } = "";

                public static class Tipo
                {
                    public static string Seleccionar { get; set; } = Properties.Settings.Default.TipoSeleccionar;
                    public static string Guardar { get; set; } = Properties.Settings.Default.TipoGuardar;
                }

                public static class MaximosMinimos
                {
                    public static string Guardar { get; set; } = Properties.Settings.Default.MaximosMinimosGuardar;
                }

                public static class PrecioMargen
                {
                    public static string Guardar { get; set; } = Properties.Settings.Default.PrecioMargenGuardar;
                }
            }

            public static class Receta
            {
                public static string Lista { get; set; } = Properties.Settings.Default.RecetaLista;
                public static string DetalleLista { get; set; } = Properties.Settings.Default.RecetaDetalleLista;
                public static int IdReceta { get; set; }
                public static string clave { get; set; }
                public static string Insertar { get; set; } = Properties.Settings.Default.RecetaInsertar;
                public static string InsertarDetalle { get; set; } = Properties.Settings.Default.RecetaInsertarDetalle;
                public static string Tipo { get; set; } = Properties.Settings.Default.RecetaTipo;
            }
            public static class Categoria
            {
                public static string Lista { get; set; } = Properties.Settings.Default.CategoriaLista;
            }

            public static class Ordenar
            {
                public static string Lista { get; set; } = Properties.Settings.Default.OrdenarLista;
            }

            public static class Departamento
            {
                public static string Lista { get; set; } = Properties.Settings.Default.DepartamentoLista;
                public static string IdDepartamento { get; set; }
            }
            public static class Parametro
            {
                public static string UrlImportar { get; set; }
            }

            public static class Permiso
            {
                public static string Obtener { get; set; } = Properties.Settings.Default.PermisoObtener;
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
                public static string Lista { get; set; } = Properties.Settings.Default.ProveedorLista;
                public static string Buscar { get; set; } = Properties.Settings.Default.ProveedorBuscar;
            }

            public static class Reporte
            {
                public static string General { get; set; } = Properties.Settings.Default.ReporteGeneral;
                public static string Imprimir { get; set; } = Properties.Settings.Default.ReporteImprimir;
                public static string Tag { get; set; } = Properties.Settings.Default.ReporteTag;
                public static string TagPorNombre { get; set; } = Properties.Settings.Default.ReporteTagNombre;
                public static string UltimosRegistros { get; set; } =Properties.Settings.Default.ReporteUltimosRegistros;
                public static string ActualizarUltimoRegistro { get; set; } =Properties.Settings.Default.ReporteActualizarUltimoRegistro;
            }

            public static class Formulario
            {
                public static class Reporte
                {
                    public static string Ruta { get; set; } = Properties.Settings.Default.FormularioReporteRuta;
                    public static string Imprimir { get; set; } = Properties.Settings.Default.FormularioReporteImprimir;
                    public static string General { get; set; } = Properties.Settings.Default.FormularioReporteGeneral;
                }}

            public static class Sucursal
            {
                public static string Lista { get; set; } = Properties.Settings.Default.SucursalLista;
            }
        }
    }
}
