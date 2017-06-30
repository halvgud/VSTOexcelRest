using System;

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

            
            public class  DetalleCocina
            {
               public static string CocinaDReceta { get; set; } = Properties.Settings.Default.DetalleRecetaCocina;
               public  static string Clave { get; set; }
                public static string Breceta { get; set; } = Properties.Settings.Default.Buscarrecetav1;

                public static string Insertarinstruccion { get; set; } = Properties.Settings.Default.INSERTARRUTAEIMAGEN;


            }

            public class Prueba
            {
                public static string Calis { get; set; } = Properties.Settings.Default.prueba;
            }

            public class Platillos
            {
                public static string Listado { get; set; } = Properties.Settings.Default.listaplatillos;
                public static string Clave { get; set; }
            }
<<<<<<< HEAD
=======

            public class Validardiario
            {
                public static string Valido { get; set; } = Properties.Settings.Default.ValidacionDiaria;
                public static string ArtId { get; set; }
            }

            public class DiaAntesX2
            {
                public static string FechaX2 { get; set; }
                public static string ActualizarX2 { get; set; } = Properties.Settings.Default.ActualizarDiarioX2;
                public static int EstadoId { get; set; }
                public static string ActualizarX2_Destino { get; set; } = Properties.Settings.Default.ActualizarDiarioDestinoX2;
                public static string ActualizarX2_Fecha { get; set; } = Properties.Settings.Default.ActualizarDiarioFechaX2;
                
                public class DestinoDif
                {
                    public  int Id { get; set;}
                    public  int EstadoId { get; set; }
                }


                public static string X2 { get; set; } = Properties.Settings.Default.DiarioAntesX2;
            }

>>>>>>> origin/master
            public class PlatillosMenus
            {
                public static string ListaPlatillos { get; set; } = Properties.Settings.Default.TiposPlatillosDiarios;
                public static string EditarMenuSemanalActual { get; set; } = Properties.Settings.Default.EditarMenuSemanal;
                public static string CompararCantidadElaborar { get; set; } = Properties.Settings.Default.EditarMenuSemanal;
                public static string SacarMsReceta { get; set; } = Properties.Settings.Default.RecetaporClave;
                public static string SacarTipoId { get; set; } = Properties.Settings.Default.TipoIdporNombre;
                public static string ExistenciaCongelado { get; set; }=Properties.Settings.Default.ExistenciaCongeladoMenu;
                public static string UsarCongelado { get; set; } = Properties.Settings.Default.SacarCongelado;
                public static string IngredientesMenu { get; set; } = Properties.Settings.Default.ListaIngredientesMenu;
                public static string Clave { get; set; }
                public static string Nombre { get; set; }
                public static string RecId { get; set; }
                public static string CantidadElaboracion { get; set; }
            }

<<<<<<< HEAD
=======

>>>>>>> origin/master
            public class Buscarcongelados
            {
                public static string Bcongelados { get; set; } = Properties.Settings.Default.buscarcongelados;
                public static string Descripcion { get; set; }
                public static string UtilizarCongelados { get; set; } = Properties.Settings.Default.SacarCongelado;
                public static string Existencia { get; set; }
                public static Int32 EstadoId { get; set; }

                public static string Inabilitar { get; set; } = Properties.Settings.Default.inabilitarcongelado;

                public static string Sacarclave { get; set; } = Properties.Settings.Default.Agrega_BuscarCongelado;

                public static string Repcongelados { get; set; } = Properties.Settings.Default.ReporteCongelado;
            }


            public class Agregarcongelados
            {
                public static StringComparer ArtId { get; set;}
                public static string Clave { get; set; }
                public static string Descripcion { get; set; }
                public static double Cantidad { get; set; }
                public static string Agregar { get; set; } = Properties.Settings.Default.AgregarCongelado1;
                public static string Agregarcantidad { get; set; } 
            }

            public class DiasSemana

            {
                public static string Diasemana { get; set; } = Properties.Settings.Default.menu;
                public static string EditarMenuSemanalActual { get; set; } = Properties.Settings.Default.EditarMenuSemanal;
                public static string GuardarRecetas { get; set; } = Properties.Settings.Default.InsertarMenuDia;
            }
           

            public static class Ordenarproducto
            {
                public static string OrdenConcepto { get; set; } = Properties.Settings.Default.ordenarproducto;
            }
        }

       

        public static class Local
        {

            public static class Api
            {
                public static string UrlApi { get; set; } = Properties.Settings.Default.UrlApi;
                public static string UrlLocal { get; set; } = "http://192.168.0.36:8080/apimovstock/public/";
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
                public static string Clave { get; set; }
                public static string Insertar { get; set; } = Properties.Settings.Default.RecetaInsertar;
                public static string InsertarDetalle { get; set; } = Properties.Settings.Default.RecetaInsertarDetalle;
                public static string Tipo { get; set; } = Properties.Settings.Default.RecetaTipo;
                public static string TipoUnidad { get; set; } = Properties.Settings.Default.TipoUnidades;
                public static int RecId { get; set; }
                public  static  string Ruta { get; set; }
                public static string Ingredientes { get; set; }

                public static string ActualizarPresupuesto { get; set; } = Properties.Settings.Default.actualizarpresupuesto;
                public static string EliminarIngre { get; set; } = Properties.Settings.Default.eliminaringredientes;

                public static string Actualizarrutaeimagen { get; set; } = Properties.Settings.Default.actualizar_ruta_e_instrucciones;
                
            }
            public class ReporteAnterior
            {
                public static string DatosAnteriores { get; set; } = Properties.Settings.Default.DiaAntes;
                public static string Fecha { get; set; }

               
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
