using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Net;
using Herramienta;
using Herramienta.Config;
using RestSharp;
namespace Data
{
    public class Receta
    {
        public static Respuesta.Receta CReceta=new Respuesta.Receta();
        public static void Lista(Action<IRestResponse> callback)
        {
            try
            {
                var rest = new Rest(Local.Api.UrlApi, Local.Receta.Lista + Local.Receta.Clave,
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
        public static void DetalleLista(Action<IRestResponse> callback)
        {
            try
            {
                var rest = new Rest(Local.Api.UrlApi, Local.Receta.DetalleLista + Local.Receta.IdReceta,
                    Method.GET);
                rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido,
                    Constantes.Http.TipoDeContenido.Json);
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
            catch (Exception e)
            {
                Opcion.Log(Log.Interno.Categoria, "EXCEPCION: " + e.Message);
                // callback("CONTINUAR");
            }
        }
        public static void Insertar(Action<IRestResponse> callback)
        {
            try
            {
                var rest = new Rest(Local.Api.UrlApi, Local.Receta.Insertar, Method.POST);
                rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido, Constantes.Http.TipoDeContenido.Json);
                rest.Peticion.AddJsonBody(CReceta);
                rest.Cliente.ExecuteAsync(rest.Peticion, response =>
                {
                    switch (response.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            CReceta.RecId= Convert.ToInt32(JObject.Parse(response.Content).Property("RecId").Value);
                            callback(response);
                            break;
                        default:
                            throw new Exception(@"error al buscar articulo");
                    }
                });
            }
            catch (Exception e)
            {
                Opcion.Log(Log.Interno.Categoria, "EXCEPCION: " + e.Message);
            }   
        }
        public class Detalle
        {
            public static List<Respuesta.Receta.Detalle> CRecetaDetalle = new List<Respuesta.Receta.Detalle>();
            public static  List<Respuesta.Receta.Detalle> ARecetaDetalle=new List<Respuesta.Receta.Detalle>();

            public static void InsertarDetalle(Action<IRestResponse> callback)
            {
                var rest = new Rest(Local.Api.UrlApi, Local.Receta.InsertarDetalle, Method.POST);
                rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido, Constantes.Http.TipoDeContenido.Json);
                rest.Peticion.AddJsonBody(CRecetaDetalle);
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
            public static void ActualizarIngredientes(List<Respuesta.Receta.Detalle> actualiza)
            { 
                var rest = new Rest(Local.Api.UrlApi, Local.Receta.InsertarDetalle, Method.POST);
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
            public static void ActualizarPresupuesto(Respuesta.Receta.ActualizaPresupuesto actualiza)
            {
                var rest = new Rest(Local.Api.UrlApi, Local.Receta.ActualizarPresupuesto, Method.POST);
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
            public static void Eliminar()
            {
                var rest = new Rest(Local.Api.UrlApi, Local.Receta.EliminarIngre, Method.POST);
                rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido, Constantes.Http.TipoDeContenido.Json);
                rest.Peticion.AddJsonBody(new {Local.Receta.RecId});
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
            public static void Eliminarrutaeimagen()
            {
                try
                {
                    var rest = new Rest(Local.Api.UrlApi, Local.Receta.Actualizarrutaeimagen,
                        Method.POST);
                    rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido,
                        Constantes.Http.TipoDeContenido.Json);
                    rest.Peticion.AddJsonBody(new {Local.Receta.RecId });
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
        }
        public class Tipo
        {
            public static void ListaTipo(Action<IRestResponse> callback)
            {
                try
                {
                    var rest = new Rest(Local.Api.UrlApi, Local.Receta.Tipo,
                        Method.GET);
                    rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido,
                        Constantes.Http.TipoDeContenido.Json);
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
                catch (Exception e)
                {
                    Opcion.Log(Log.Interno.Categoria, "EXCEPCION: " + e.Message);
                    // callback("CONTINUAR");
                }
            }
        }
        public class Unidad
        {
            public static void TipoUnidades(Action<IRestResponse> callback)
            {
                try
                {
                    var rest = new Rest(Local.Api.UrlApi, Local.Receta.TipoUnidad,
                        Method.GET);
                    rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido,
                        Constantes.Http.TipoDeContenido.Json);
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
                catch (Exception e)
                {
                    Opcion.Log(Log.Interno.Categoria, "EXCEPCION: " + e.Message);
                    // callback("CONTINUAR");
                }
            }
        }
    }
}
