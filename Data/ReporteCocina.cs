using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Herramienta;
using Herramienta.Config;
using RestSharp;

namespace Data
{
   public class ReporteCocina
    {
        public static Respuesta.Receta.Congelados Cccongelados;

       public static Respuesta.Receta.Imagen_and_Process ImagenAndProcess;

       //public var CongeladoVar;
        
     

        public static void VersionDetallada(Action<IRestResponse> callback)
        {
            try
            {
                var rest = new Rest(Local.Api.UrlApi, Local.Reporte.General,
                    Method.POST);
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
        /*aqui tu 2do parametro no debe ser CbGenerico*/
        public static void VersionExtendida(Action<IRestResponse> callback, Respuesta.CbGenerico filtroGenerico )
        {
            try
            {
                /*url local?*/
                var rest = new Rest(Local.Api.UrlApi, Herramienta.Config.Cocina.ReporteRecetario.ReporteCocina,
                    Method.POST);
                rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido,
                    Constantes.Http.TipoDeContenido.Json);
                 rest.Peticion.AddJsonBody(filtroGenerico);
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


        public static void DDetalleReceta(Action<IRestResponse> callback, string clave)
        {
            try
            {
                /*url local?*/
                var rest = new Rest(Local.Api.UrlApi, Herramienta.Config.Cocina.DetalleCocina.CocinaDReceta,
                    Method.POST);
                rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido,
                    Constantes.Http.TipoDeContenido.Json);
                rest.Peticion.AddJsonBody(new { clave= clave});// la peticion debe ser un objeto
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

        public static void InsertarRutaeIMAGEN(List<Respuesta.Receta.Imagen_and_Process> instructivoList )
        {
            try
            {
                /*url local?*/
                var rest = new Rest(Local.Api.UrlApi, Herramienta.Config.Cocina.DetalleCocina.insertarinstruccion,
                    Method.POST);
                rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido,
                    Constantes.Http.TipoDeContenido.Json);
                rest.Peticion.AddJsonBody(instructivoList);// la peticion debe ser un objeto
                rest.Cliente.ExecuteAsync(rest.Peticion, response =>
                {
                    switch (response.StatusCode)
                    {
                        case HttpStatusCode.OK:
                          // callback(response);
                            break;
                        default:
                           // callback(null);
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


        public static void agregar_congeladobuscar(Action<IRestResponse> callback)
        {//es q lo escribi mal jeje
            try
            {
                var rest = new Rest(Local.Api.UrlApi, Herramienta.Config.Cocina.buscarcongelados.sacarclave,
                    Method.POST);
                rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido,
                    Constantes.Http.TipoDeContenido.Json);
                rest.Peticion.AddJsonBody(new { descripcion = Cocina.buscarcongelados.descripcion });
                // rest.Peticion.AddJsonBody(repGeneral);
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


        public static void Buscarcongelados(Action<IRestResponse> callback)
        {
            try
            {
                var rest = new Rest(Local.Api.UrlApi, Herramienta.Config.Cocina.buscarcongelados.bcongelados,
                    Method.POST);
                rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido,
                    Constantes.Http.TipoDeContenido.Json);
                rest.Peticion.AddJsonBody(new { descripcion = Cocina.buscarcongelados.descripcion });
                // rest.Peticion.AddJsonBody(repGeneral);
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

        public static void AgregarCongelados(Action<IRestResponse> callback, List<Respuesta.Receta.Congelados> agregarallice )
        {
            try
            {
                var rest = new Rest(Local.Api.UrlApi, Herramienta.Config.Cocina.agregarcongelados.agregar,
                    Method.POST);
                rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido,
                    Constantes.Http.TipoDeContenido.Json);
                rest.Peticion.AddJsonBody(agregarallice);
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

        public static void ActualizarCongelado(Action<IRestResponse> callback)
        {
            try
            {
                var rest = new Rest(Local.Api.UrlApi, Herramienta.Config.Cocina.buscarcongelados.cambioexistencia,
                    Method.POST);
                rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido,
                    Constantes.Http.TipoDeContenido.Json);
                rest.Peticion.AddJsonBody(Cccongelados);
                //rest.Peticion.AddJsonBody(new { estado_id = Cocina.buscarcongelados.descripcion });
                // rest.Peticion.AddJsonBody(repGeneral);
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
                //callback(null);
            }
        }

        public static void InabilitarCongelado(int estado_id)
        {
            try
            {
                var rest = new Rest(Local.Api.UrlApi, Herramienta.Config.Cocina.buscarcongelados.inabilitar,
                    Method.POST);
                rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido,
                    Constantes.Http.TipoDeContenido.Json);
                rest.Peticion.AddJsonBody(new
                {/*a que te refieres con eso*/
                   estado_id
                }
            );
                // rest.Peticion.AddJsonBody(repGeneral);
                rest.Cliente.ExecuteAsync(rest.Peticion, response =>
                {
                    switch (response.StatusCode)
                    {
                        case HttpStatusCode.OK:
                           // callback(response);
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

    }
}
