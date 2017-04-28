using System;
using System.Net;
using Herramienta;
using Herramienta.Config;
using RestSharp;


namespace Data
{
    public class Reporte
    {
        public static string Departamento { get; set; }
        public static string Categoria { get; set; }
        public static string Proveedor { get; set; }
        public static DateTime FechaIni { get; set; }
        public static DateTime FechaFin { get; set; }

        
        public static void General(Action<IRestResponse> callback, Respuesta.Reporte.General repGeneral)
        {
            try
            {
                var rest = new Rest(Local.Api.UrlApi, Local.Reporte.General,
                    Method.POST);
                rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido,
                    Constantes.Http.TipoDeContenido.Json);
                rest.Peticion.AddJsonBody(repGeneral);
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
        public static void Imprimir(Action<IRestResponse> callback, Respuesta.Reporte.General repGeneral)
        {
            try
            {
                var rest = new Rest(Local.Api.UrlApi, Local.Reporte.Imprimir,
                    Method.POST);
                rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido,
                    Constantes.Http.TipoDeContenido.Json);
                rest.Peticion.AddJsonBody(repGeneral);
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
                // callback("CONTINUAR");
            }
        }
        public static void Lista(Action<IRestResponse> callback)
        {
            try{
                var rest = new Rest(Local.Api.UrlApi, Local.Ordenar.Lista, Method.GET);
                rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido,
                    Constantes.Http.TipoDeContenido.Json);
                rest.Cliente.ExecuteAsync(rest.Peticion, response =>{
                    switch (response.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            callback(response);
                            break;
                        default:
                            //Opcion.Log(Config.Log.Interno.Departamento, response.Content);
                            throw new Exception(@"error al cargar orden");
                            // callback("CONTINUAR");
                    }
                        
                });
            }
            catch (Exception e)
            {
                Opcion.Log(Log.Interno.Departamento, "EXCEPCION: " + e.Message);
                // callback("CONTINUAR");
            }
        }

        public static void Tag(Action<IRestResponse> callback)
        {
            try
            {
                var rest = new Rest(Local.Api.UrlApi, Local.Reporte.Tag, Method.GET);
                rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido, Constantes.Http.TipoDeContenido.Json);
                rest.Cliente.ExecuteAsync(rest.Peticion, response =>
                {
                    switch (response.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            callback(response);
                            break;
                        default:
                            throw new Exception(@"Error al cargar el indice de tags");
                    }
                });
            }
            catch (Exception e)
            {
                Opcion.Log(Log.Interno.Departamento,"EXCEPCION: "+e.Message);
            }
        }

        public static void Listaplatillos(Action<IRestResponse> callback)
        {
            try
            {
                var rest = new Rest(Local.Api.UrlApi, Herramienta.Config.Cocina.Platillos.Listado, Method.GET);
                rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido, Constantes.Http.TipoDeContenido.Json);
                rest.Cliente.ExecuteAsync(rest.Peticion, response =>
                {
                    switch (response.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            callback(response);
                            break;
                        default:
                            throw new Exception(@"Error al cargar el indice de platillos");
                    }
                });
            }
            catch (Exception e)
            {
                Opcion.Log(Log.Interno.Departamento, "EXCEPCION: " + e.Message);
            }
        }

        public static void RepCongelados(Action<IRestResponse> callback)
        {
            try
            {
                var rest = new Rest(Local.Api.UrlApi, Herramienta.Config.Cocina.buscarcongelados.repcongelados, Method.GET);

                rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido, Constantes.Http.TipoDeContenido.Json);
                rest.Cliente.ExecuteAsync(rest.Peticion, response =>
                {
                    switch (response.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            callback(response);
                            break;
                        default:
                            throw new Exception(@"Error al cargar el indice de platillos");
                    }
                });
            }
            catch (Exception e)
            {
                Opcion.Log(Log.Interno.Departamento, "EXCEPCION: " + e.Message);
            }
        }

        public static void TagPorNombre(Action<IRestResponse> callback,Respuesta.Reporte.General repGeneral)
        {
            try
            {
                var rest = new Rest(Local.Api.UrlApi, Local.Reporte.Tag, Method.POST);
                rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido, Constantes.Http.TipoDeContenido.Json);
                rest.Peticion.AddJsonBody(repGeneral);
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
                // callback("CONTINUAR"    );

//                {
//                    "descripcion":"chuletas"
//}
            }
        }

        public static void UltimosRegistros(Action<IRestResponse> callback)
        {
            try
            {
                var rest = new Rest(Local.Api.UrlApi, Local.Reporte.UltimosRegistros, Method.GET);
                rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido, Constantes.Http.TipoDeContenido.Json);
                rest.Cliente.ExecuteAsync(rest.Peticion, response =>
                {
                    switch (response.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            callback(response);
                            break;
                        default:
                            throw new Exception(@"Error al cargar el indice de tags");
                    }
                });
            }
            catch (Exception e)
            {
                Opcion.Log(Log.Interno.Departamento, "EXCEPCION: " + e.Message);
            }
        }

        


        public static void ActualizarUltimoRegistro(Action<IRestResponse> callback,Respuesta.Reporte.General repGeneral)
        {
            try
            {
                var rest = new Rest(Local.Api.UrlApi, Local.Reporte.ActualizarUltimoRegistro, Method.POST);
                rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido, Constantes.Http.TipoDeContenido.Json);
                rest.Peticion.AddJsonBody(repGeneral);
                rest.Cliente.ExecuteAsync(rest.Peticion, response =>
                {
                    switch (response.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            callback(response);
                            break;
                        default:
                            throw new Exception(@"Error al guardar la busqueda");
                    }
                });
            }
            catch (Exception e)
            {
                Opcion.Log(Log.Interno.Departamento, "EXCEPCION: " + e.Message);
            }
            
        }
    }

}
