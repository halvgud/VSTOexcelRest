using System;
using System.Collections.Generic;
using System.Net;
using Herramienta;
using Herramienta.Config;
using RestSharp;


namespace Data
{
   public class MenuSemanal
    {
        public static DateTime FechaIni;
        public static DateTime FechaFin;
        public static Respuesta.InsertarMenu CmInsertarMenu= new Respuesta.InsertarMenu();
        public static List<Respuesta.Receta.Savedaily> savedaily = new List<Respuesta.Receta.Savedaily>();

        
        public static void CargarDias(Action<IRestResponse> callback,Respuesta.Reporte.General fechas)
        {
            try
            {
                var rest = new Rest(Local.Api.UrlApi,Cocina.DiasSemana.Diasemana, Method.POST);
                rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido, Constantes.Http.TipoDeContenido.Json);
                rest.Peticion.AddJsonBody(fechas);
                rest.Cliente.ExecuteAsync(rest.Peticion, response =>
                {
                    switch (response.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            callback(response);
                            break;
                        default:
                            callback(null);
                            break;
                    }
                });
            }
            catch (Exception e)
            {
                Opcion.Log(Log.Interno.Categoria, "EXCEPCION: " + e.Message);
            }
        }

        public static void EditarMenuSemanaActual(Action<IRestResponse> callback, Respuesta.Reporte.General fechas)
        {
            try
            {
                var rest = new Rest(Local.Api.UrlApi, Cocina.DiasSemana.EditarMenuSemanalActual, Method.POST);
                rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido, Constantes.Http.TipoDeContenido.Json);
                rest.Peticion.AddJsonBody(fechas);
                rest.Cliente.ExecuteAsync(rest.Peticion, response =>
                {
                    switch (response.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            callback(response);
                            break;
                        default:
                            callback(null);
                            break;
                    }
                });
            }
            catch (Exception e)
            {
                Opcion.Log(Log.Interno.Categoria, "EXCEPCION: " + e.Message);
            }
        }
        public static void ListaPlatilloRecetas(Action<IRestResponse> callback)
        {
            try
            {
                var rest = new Rest(Local.Api.UrlApi, Cocina.PlatillosMenus.ListaPlatillos,
                    Method.POST);
                rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido,
                    Constantes.Http.TipoDeContenido.Json);
                rest.Peticion.AddJsonBody(new {Cocina.PlatillosMenus.Nombre});
                rest.Cliente.ExecuteAsync(rest.Peticion, response =>
                {
                    switch (response.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            callback(response);
                            break;
                        default:
                            callback(null);
                            break;
                    }
                });
            }
            catch (Exception e)
            {
                Opcion.Log(Log.Interno.Categoria, "EXCEPCION: " + e.Message);
                callback(null);
            }
        }
        public static void CompararCantidadElaborar(Action<IRestResponse> callback)
        {
            try
            {
                var rest = new Rest(Local.Api.UrlApi, Cocina.PlatillosMenus.CompararCantidadElaborar,
                    Method.POST);
                rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido,
                    Constantes.Http.TipoDeContenido.Json);
                rest.Peticion.AddJsonBody(new { Cocina.PlatillosMenus.Clave });
                callback(rest.Cliente.Execute(rest.Peticion));
            }
            catch (Exception e)
            {
                Opcion.Log(Log.Interno.Categoria, "EXCEPCION: " + e.Message);
                callback(null);
            }
        }
        public static void SacarTipoId(Action<IRestResponse> callback)
        {
            try
            {
                var rest = new Rest(Local.Api.UrlApi, Cocina.PlatillosMenus.SacarTipoId,
                    Method.POST);
                rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido,
                    Constantes.Http.TipoDeContenido.Json);
                rest.Peticion.AddJsonBody(new { Cocina.PlatillosMenus.Nombre});
                callback(rest.Cliente.Execute(rest.Peticion));
            }
            catch (Exception e)
            {
                Opcion.Log(Log.Interno.Categoria, "EXCEPCION: " + e.Message);
                callback(null);
            }
        }
        public static void SacarParamentrosReceta(Action<IRestResponse> callback)
        {
            try
            {
                var rest = new Rest(Local.Api.UrlApi, Cocina.PlatillosMenus.SacarMsReceta,
                    Method.POST);
                rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido,
                    Constantes.Http.TipoDeContenido.Json);
                rest.Peticion.AddJsonBody(new { Cocina.PlatillosMenus.Clave });
                callback(rest.Cliente.Execute(rest.Peticion));
            }
            catch (Exception e)
            {
                Opcion.Log(Log.Interno.Categoria, "EXCEPCION: " + e.Message);
                callback(null);
            }
        }
        public static void ExistenciaCongelado(Action<IRestResponse> callback)
        {
            try
            {
                var rest = new Rest(Local.Api.UrlApi, Cocina.PlatillosMenus.ExistenciaCongelado,
                    Method.POST);
                rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido,
                    Constantes.Http.TipoDeContenido.Json);
                rest.Peticion.AddJsonBody(new { Cocina.PlatillosMenus.Clave });
                callback(rest.Cliente.Execute(rest.Peticion));
            }
            catch (Exception e)
            {
                Opcion.Log(Log.Interno.Categoria, "EXCEPCION: " + e.Message);
                callback(null);
            }
        }
        public static void UtilizarCongelado(int estadoId)
        {
            try
            {
                var rest = new Rest(Local.Api.UrlApi, Cocina.PlatillosMenus.UsarCongelado,
                    Method.POST);
                rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido,
                    Constantes.Http.TipoDeContenido.Json);
                rest.Peticion.AddJsonBody(new
                {
                    EstadoId = estadoId
                }
            );
                rest.Cliente.ExecuteAsync(rest.Peticion, response =>
                {
                    switch (response.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            break;
                    }
                });
            }
            catch (Exception e)
            {
                Opcion.Log(Log.Interno.Categoria, "EXCEPCION: " + e.Message);
                //callback(null);
            }
        }
        public static void IngredientesMenuPlatillos(Action<IRestResponse> callback)
        {
            try
            {
                var rest = new Rest(Local.Api.UrlApi, Cocina.PlatillosMenus.IngredientesMenu,
                    Method.POST);
                rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido,
                    Constantes.Http.TipoDeContenido.Json);
                rest.Peticion.AddJsonBody(new { Cocina.PlatillosMenus.RecId});
                callback(rest.Cliente.Execute(rest.Peticion));
            }
            catch (Exception e)
            {
                Opcion.Log(Log.Interno.Categoria, "EXCEPCION: " + e.Message);
                callback(null);
            }
        }
        public static void ListaIngredientes(Action<IRestResponse> callback)
        {
            try
            {
                var rest = new Rest(Local.Api.UrlApi, Cocina.PlatillosMenus.IngredientesMenu + Cocina.PlatillosMenus.Clave,
                    Method.GET);
                rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido,
                    Constantes.Http.TipoDeContenido.Json);
                rest.Cliente.ExecuteAsync(rest.Peticion, callback);
            }
            catch (Exception e)
            {
                Opcion.Log(Log.Interno.Categoria, "EXCEPCION: " + e.Message);
                // callback("CONTINUAR");
            }
        }
        public static List<Respuesta.InsertarMenu> CInsertarMenus= new List<Respuesta.InsertarMenu>();
        public static void InsertarMenus(Action<IRestResponse> callback, Respuesta.InsertarMenu lista)
        {
var rest = new Rest(Local.Api.UrlApi, Cocina.DiasSemana.GuardarRecetas, Method.POST);
            rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido, Constantes.Http.TipoDeContenido.Json);
            rest.Peticion.AddJsonBody(lista);
            rest.Cliente.ExecuteAsync(rest.Peticion, response =>
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        callback(response);
                        break;
                    default:
                        throw new Exception(@"error al buscar articulo");
                }
            });
<<<<<<< HEAD
          }
=======
}

        public static void AgregarDiario(List<Respuesta.Receta.Savedaily> estadoList )
        {
            try
            {
                var rest = new Rest(Local.Api.UrlApi, Cocina.Agregarcongelados.Agregar, Method.POST);
                rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido,
                    Constantes.Http.TipoDeContenido.Json);
                rest.Peticion.AddJsonBody(estadoList);
                //rest.Peticion.AddJsonBody(repGeneral);
                rest.Cliente.ExecuteAsync(rest.Peticion, response =>
                {
                    switch (response.StatusCode)
                    {
                        case HttpStatusCode.OK: //ell callback es para cuando quieres hacer una accion al terminar tu query
                            //callback(response);
                            break;
                        default:
                           //callback(null);
                            break;
                    }
                });
            }
            catch (Exception e)
            {
                Opcion.Log(Log.Interno.Categoria, "EXCEPCION: " + e.Message);
                //callback(null);
            }
        }

        public static void Verificacion(Action<IRestResponse> callback)
        {
            try
            {
                var rest = new Rest(Local.Api.UrlApi, Cocina.PlatillosMenus.SacarRecId,
                    Method.POST);
                rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido,
                    Constantes.Http.TipoDeContenido.Json);
                rest.Peticion.AddJsonBody(new { Cocina.PlatillosMenus.Clave });
                callback(rest.Cliente.Execute(rest.Peticion));
            }
            catch (Exception e)
            {
                Opcion.Log(Log.Interno.Categoria, "EXCEPCION: " + e.Message);
                callback(null);
            }
        }

>>>>>>> origin/master
    }
}
