using System;
using System.Collections.Generic;
using System.Net;
using Herramienta;
using Herramienta.Config;
using Respuesta;
using RestSharp;
using System.Windows.Forms;




namespace Data
{
   public class MenuSemanal
    {
        public static DateTime FechaIni;
        public static DateTime FechaFin;
        public static Respuesta.InsertarMenu CmInsertarMenu= new Respuesta.InsertarMenu();

        public static Cocina.DiaAntesX2.DestinoDif Destino = new Cocina.DiaAntesX2.DestinoDif();

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

        public static void CargarMenuSemanaActual(Action<IRestResponse> callback, Respuesta.Reporte.General fechas)
        {
            try
            {
                var rest = new Rest(Local.Api.UrlApi, Cocina.DiasSemana.CargarMenuActual, Method.POST);
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
            }
        }
        public static void CargarPlatilloDiarios(Action<IRestResponse> callback)
        {
            try
            {
                var rest = new Rest(Local.Api.UrlApi, Cocina.PlatillosMenus.RecetasDiarias,
                    Method.POST);
                rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido,
                    Constantes.Http.TipoDeContenido.Json);
                rest.Peticion.AddJsonBody(new { Cocina.PlatillosMenus.TipoId});
                callback(rest.Cliente.Execute(rest.Peticion));
            }
            catch (Exception e)
            {
                Opcion.Log(Log.Interno.Categoria, "EXCEPCION: " + e.Message);
                callback(null);
            }
        }
        public static void EliminarelPlatillo( int menidd)
        {
            var rest = new Rest(Local.Api.UrlApi, Cocina.PlatillosMenus.EliminarPlatillo, Method.POST);
            rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido, Constantes.Http.TipoDeContenido.Json);
            rest.Peticion.AddJsonBody(new {MenId=menidd});
            rest.Cliente.ExecuteAsync(rest.Peticion, response =>
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        break;
                    default:
                        throw new Exception(@"No se realizo la actualizacion");
                }
            });
        }
        public static void ListaDiarios(Action<IRestResponse> callback/*, Form f1)*/)
        {
            try
            {
                var rest = new Rest(Local.Api.UrlApi, Cocina.PlatillosMenus.ListaDiarios + Cocina.PlatillosMenus.TipooId, Method.GET);

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
       }
        //public static List<Respuesta.InsertarMenu> CActualizarMenus = new List<Respuesta.InsertarMenu>();
        //public static void ActualizarMenu(Action<IRestResponse> callback, Respuesta.InsertarMenu lista)
        //{
        //    var rest = new Rest(Local.Api.UrlApi, Cocina.DiasSemana.ActualizarMenuActual, Method.POST);
        //    rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido, Constantes.Http.TipoDeContenido.Json);
        //    rest.Peticion.AddJsonBody(lista);
        //    rest.Cliente.ExecuteAsync(rest.Peticion, response =>
        //    {
        //        switch (response.StatusCode)
        //        {
        //            case HttpStatusCode.OK:
        //                callback(response);
        //                break;
        //            default:
        //                throw new Exception(@"error al buscar articulo");
        //        }
        //    });
        //}

        public static void ActualizarMenuActual(Respuesta.InsertarMenu actualiza)
        {
            var rest = new Rest(Local.Api.UrlApi, Cocina.DiasSemana.ActualizarMenuActual, Method.POST);
            rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido, Constantes.Http.TipoDeContenido.Json);
            rest.Peticion.AddJsonBody(actualiza);
            rest.Cliente.ExecuteAsync(rest.Peticion, response =>
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        break;
                    default:
                        throw new Exception(@"Los datos no se pudieron actualizar");
                }
            });
        }

        public static void AgregarDiario(Action<IRestResponse> callback)
        {
            try
            {
                var rest = new Rest(Local.Api.UrlApi, Cocina.Agregarcongelados.Agregar, Method.POST);
                rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido,
                    Constantes.Http.TipoDeContenido.Json);
                rest.Peticion.AddJsonBody(savedaily);
                //rest.Peticion.AddJsonBody(repGeneral);
                rest.Cliente.ExecuteAsync(rest.Peticion, response =>
                {
                    switch (response.StatusCode)
                    {
                        case HttpStatusCode.OK: //ell callback es para cuando quieres hacer una accion al terminar tu query
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
                //callback(null);
            }
        }

        public static void Verificacion(Action<IRestResponse> callback)  
        {
            try
            {
                var rest = new Rest(Local.Api.UrlApi, Cocina.Validardiario.Valido, Method.POST);
                rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido,
                    Constantes.Http.TipoDeContenido.Json);
                rest.Peticion.AddJsonBody(new {ArtId=Cocina.Validardiario.ArtId});
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

        public static void AntesX2(Action<IRestResponse> callback)
        {
            try
            {
                var rest = new Rest(Local.Api.UrlApi, Cocina.Validardiario.Valido, Method.POST);
                rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido,
                    Constantes.Http.TipoDeContenido.Json);
                rest.Peticion.AddJsonBody(new { ArtId = Cocina.Validardiario.ArtId });
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

        public static void ActualizarX2Destino()
        {
            try
            {
                var rest = new Rest(Local.Api.UrlApi, Cocina.DiaAntesX2.ActualizarX2_Destino, Method.POST);
                rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido,
                    Constantes.Http.TipoDeContenido.Json);
                rest.Peticion.AddJsonBody(Destino);
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

        public static void ActualizarX2Fecha(Action<IRestResponse> callback)
        {
            try
            {
                var rest = new Rest(Local.Api.UrlApi, Cocina.DiaAntesX2.ActualizarX2_Fecha, Method.POST);
                rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido,
                    Constantes.Http.TipoDeContenido.Json);
                rest.Peticion.AddJsonBody(new {EstadoId= Cocina.DiaAntesX2.EstadoId });
                //rest.Peticion.AddJsonBody(repGeneral);
                rest.Cliente.ExecuteAsync(rest.Peticion, response =>
                {
                    switch (response.StatusCode)
                    {
                        case HttpStatusCode.OK: //ell callback es para cuando quieres hacer una accion al terminar tu query
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
                //callback(null);
            }
        }
    }
}
