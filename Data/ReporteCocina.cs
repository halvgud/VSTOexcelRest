using System;
using System.Collections.Generic;
using System.Net;
using Herramienta;
using Herramienta.Config;
using RestSharp;

namespace Data
{
   public class ReporteCocina
    {
        public static Respuesta.Receta.Congelados Cccongelados;
<<<<<<< HEAD
       public static Respuesta.Receta.ImagenAndProcess ImagenAndProcess;

       //public var CongeladoVar;
=======

      

       public static Respuesta.Receta.ImagenAndProcess ImagenAndProcess;

       //public var CongeladoVar;
        
     


>>>>>>> origin/master
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
                var rest = new Rest(Local.Api.UrlApi, Cocina.ReporteRecetario.ReporteCocina,
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
<<<<<<< HEAD
=======


>>>>>>> origin/master
        public static void BuscarRecetav2(Action<IRestResponse> callback)
        {
            try
            {
                var rest = new Rest(Local.Api.UrlApi, Herramienta.Config.Cocina.DetalleCocina.Breceta,
                    Method.POST);
                rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido,
                    Constantes.Http.TipoDeContenido.Json);
                rest.Peticion.AddJsonBody(new { Clave = Cocina.DetalleCocina.Clave});// la peticion debe ser un objeto
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

<<<<<<< HEAD
=======


>>>>>>> origin/master
        public static void DDetalleReceta(Action<IRestResponse> callback, string clave)
        {
            try
            {
                /*url local?*/
                var rest = new Rest(Local.Api.UrlApi, Cocina.DetalleCocina.CocinaDReceta,
                    Method.POST);
                rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido,
                    Constantes.Http.TipoDeContenido.Json);
                rest.Peticion.AddJsonBody(new {clave});// la peticion debe ser un objeto
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
<<<<<<< HEAD
=======

>>>>>>> origin/master

        public static void InsertarRutaeImagen(Respuesta.Receta.ImagenAndProcess instructivoclass )
        {
            try
            {
                /*url local?*/
                var rest = new Rest(Local.Api.UrlApi, Herramienta.Config.Cocina.DetalleCocina.Insertarinstruccion,
                    Method.POST);
                rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido,
                    Constantes.Http.TipoDeContenido.Json);
                rest.Peticion.AddJsonBody(instructivoclass);// la peticion debe ser un objeto
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


<<<<<<< HEAD
=======

>>>>>>> origin/master
        public static void agregar_congeladobuscar(Action<IRestResponse> callback)
        {//es q lo escribi mal jeje
            try
            {
<<<<<<< HEAD
                var rest = new Rest(Local.Api.UrlApi, Herramienta.Config.Cocina.Buscarcongelados.Sacarclave,
                    Method.POST);
                rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido,
                    Constantes.Http.TipoDeContenido.Json);
                rest.Peticion.AddJsonBody(new { descripcion = Cocina.Buscarcongelados.Descripcion });
                // rest.Peticion.AddJsonBody(repGeneral);
=======


                var rest = new Rest(Local.Api.UrlApi, Cocina.Buscarcongelados.Sacarclave,
                    Method.POST);
                rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido,
                    Constantes.Http.TipoDeContenido.Json);
                rest.Peticion.AddJsonBody(new {Cocina.Buscarcongelados.Descripcion });
              // rest.Peticion.AddJsonBody(repGeneral);
>>>>>>> origin/master
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
<<<<<<< HEAD
                var rest = new Rest(Local.Api.UrlApi, Herramienta.Config.Cocina.Buscarcongelados.Bcongelados,
                    Method.POST);
                rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido,
                    Constantes.Http.TipoDeContenido.Json);
                rest.Peticion.AddJsonBody(new { descripcion = Cocina.Buscarcongelados.Descripcion });
=======

          
                var rest = new Rest(Local.Api.UrlApi, Cocina.Buscarcongelados.Bcongelados,
                    Method.POST);
                rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido,
                    Constantes.Http.TipoDeContenido.Json);
                rest.Peticion.AddJsonBody(new {Cocina.Buscarcongelados.Descripcion });

>>>>>>> origin/master
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
<<<<<<< HEAD
                var rest = new Rest(Local.Api.UrlApi, Herramienta.Config.Cocina.Agregarcongelados.Agregar,
                    Method.POST);
=======

          
                var rest = new Rest(Local.Api.UrlApi, Cocina.Agregarcongelados.Agregar,Method.POST);
>>>>>>> origin/master
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

<<<<<<< HEAD
                var rest = new Rest(Local.Api.UrlApi, Cocina.Buscarcongelados.UtilizarCongelados,
                    Method.POST);
=======
               var rest = new Rest(Local.Api.UrlApi, Cocina.Buscarcongelados.Cambioexistencia,
                  Method.POST);
>>>>>>> origin/master
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
<<<<<<< HEAD
=======



>>>>>>> origin/master
        public static void InabilitarCongelado(int estadoId)
        {
            try
            {
<<<<<<< HEAD
                var rest = new Rest(Local.Api.UrlApi,Cocina.Buscarcongelados.Inabilitar,
                    Method.POST);
=======

                var rest = new Rest(Local.Api.UrlApi,Cocina.Buscarcongelados.Inabilitar,
                Method.POST);
>>>>>>> origin/master
                rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido,
                    Constantes.Http.TipoDeContenido.Json);
                rest.Peticion.AddJsonBody(new
                {/*a que te refieres con eso*/
                   estado_id = estadoId
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
                        //callback(null);
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
