﻿using System;
using System.Net.NetworkInformation;

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
                public static string ReporteCocinaPlatillo { get; set; } = Properties.Settings.Default.ReporteCocinaPlatillo;


            }

            public class ReporteDiarioCocina
            {
                public static string ReportePlatillosHoy { get; set; } = Properties.Settings.Default.ReporteHoy;
                public static string Reporte { get; set; } = Properties.Settings.Default.ReporteDiarioX;
                public static string CargarRepoNew { get; set; } = Properties.Settings.Default.ActRecetaDiaria;
                public static string CargarEstadoMañana { get; set; } = Properties.Settings.Default.MostrarEstadoMañana;
                public static string ReporteNuevoRegistro { get; set; } = Properties.Settings.Default.DiarioNuevoRegistro;
                public static string CargarRepoNew2 { get; set; } = Properties.Settings.Default.ActRecetaDiaria2;
                public static string Fecha { get; set; }

                public class FechasReporte
                {
                    public string FechaIni { get; set; }
                    public string FechaFin { get; set; }
                }
            }
             public static class ActReceta
             {
                 public static string ReporteActualizarReceta { get; set; } = Properties.Settings.Default.RepActReceta;
             }
            
            public class  DetalleCocina
            {
               public static string CocinaDReceta { get; set; } = Properties.Settings.Default.DetalleRecetaCocina;
               public  static string Clave { get; set; }
                public  static string RecId { get; set; }
                public static string Breceta { get; set; } = Properties.Settings.Default.Buscarrecetav1;

                public static string RecetaArticulo { get; set; } = Properties.Settings.Default.BuscarRecetaArticulos;

                public static string Insertarinstruccion { get; set; } = Properties.Settings.Default.INSERTARRUTAEIMAGEN;

                public class ReporteDetalle
                {
                    public string clave { get; set; }
                    public string FechaInicio { get; set; }
                    public string FechaFinal { get; set; }
                }

                public class ReporteInventarioHistorial
                {
                    public DateTime Fecha1 { get; set; }
                    public DateTime Fecha2 { get; set; }
                }

                public static string ReporteCongeladoFechas = Properties.Settings.Default.RepoCongeladoFechado;
            }

            public class RecetaActPrecio
            {
                public static string ActRecetaPrice = Properties.Settings.Default.ActPrecioReceta;
                public static string ActRecetaPrecioCompra = Properties.Settings.Default.ActualizacionRecetaPrecio;
                public static string TablaPreciosNuevos = Properties.Settings.Default.TablaDifPrecios;
                public static string Ingredientes = Properties.Settings.Default.TablaDifPrecioIngredientes;
                public static string ProductoActualizarPrecio = Properties.Settings.Default.PrecioActualizarProducto;
                public static string EliminarProductoPrecio = Properties.Settings.Default.EliminarRegistroPrecio;
               public static string Clave { get; set; }



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
                public static string ActualizarX2Destino { get; set; } = Properties.Settings.Default.ActualizarDiarioDestinoX2;
                public static string CargarDiarios { get; set; } = Properties.Settings.Default.ReporteDiario;
                
                public class DestinoDif
                {
                    public  int Id { get; set;}
                    public  int EstadoId { get; set; }
                }


                public static string X2 { get; set; } = Properties.Settings.Default.DiarioAntesX2;
            }


            public class PlatillosMenus
            {
                public static string PlatilloMenu { get; set; } = Properties.Settings.Default.RecetaMenuSemanal;
                public static string ListaPlatillos { get; set; } = Properties.Settings.Default.TiposPlatillosDiarios;
                public static string ListaPlatilloClave { get; set; } = Properties.Settings.Default.PlatilloporClave;
                public static string SacarMsReceta { get; set; } = Properties.Settings.Default.RecetaporClave;
                public static string SacarTipoId { get; set; } = Properties.Settings.Default.TipoIdporNombre;
                public static string ExistenciaCongelado { get; set; }=Properties.Settings.Default.ExistenciaCongeladoMenu;
                public static string UsarCongelado { get; set; } = Properties.Settings.Default.SacarCongelado;
                public static string IngredientesMenu { get; set; } = Properties.Settings.Default.ListaIngredientesMenu;
                public static string RecetasDiarias { get; set; } = Properties.Settings.Default.CargarRecetasDiarias;
                public static string Clave { get; set; }
                public static string Nombre { get; set; }
                public static string RecId { get; set; }
                public  static  string TipoId { get; set; }
                public static string MenId { get; set; }
                public static string ListaDiarios { get; set; } = Properties.Settings.Default.DiariosLista;
                public static string TipooId { get; set; } = "";
                public static string EliminarPlatillo { get; set; } = Properties.Settings.Default.EliminarPlatillo;
            }


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
                public static int EstadoInventarioId { get; set; }
                public static string Agregar { get; set; } = Properties.Settings.Default.AgregarCongelado1;
                public static string AgregarMañana { get; set; } = Properties.Settings.Default.InsertarDiariodeMañana;
                public static string ActualizarMañana { get; set; } = Properties.Settings.Default.ActualizarDiariodeMañana;
                public static string ActualizarDestino { get; set; } = Properties.Settings.Default.ActualizarDestino;
                public static string Agregarcantidad { get; set; } 
            }

            public class DiasSemana

            {
                public static string Diasemana { get; set; } = Properties.Settings.Default.menu;
                public static string CargarMenuActual { get; set; } = Properties.Settings.Default.CargarSemanaActual;
                public static string GuardarRecetas { get; set; } = Properties.Settings.Default.InsertarMenuDia;
                public static string ActualizarMenuActual { get; set; } = Properties.Settings.Default.ActualizarMenuSemanal;
                public static string MenId { get; set; }
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

                public class IngredienteActualizar
                {
                    public static string IngredientesAct { get; set; } = Properties.Settings.Default.IngActReceta;
                    public static int Rec_id { get; set; }
                 }
                
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
