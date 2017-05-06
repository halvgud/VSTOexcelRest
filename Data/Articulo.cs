using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;
using Herramienta;
using Herramienta.Config;
using RestSharp;


namespace Data
{
    public class Articulo
    {
        public static void Lista(Action<IRestResponse> callback, Form f1)
        {
            try
            {
var rest = new Rest(Local.Api.UrlApi, Local.Articulo.Lista + Local.Articulo.IdArticulo,Method.GET);
                rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido,Constantes.Http.TipoDeContenido.Json);
                rest.Cliente.ExecuteAsync(rest.Peticion, response =>{
                    switch (response.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            callback(response);
                            break;
                        default:
                            f1.BeginInvoke((MethodInvoker)(() =>
                            {
                                MessageBox.Show(f1, Opcion.JsonaString(response.Content));
}));
                            callback = x =>
                            {
                                
                                // Opcion.Mensaje(Opcion.JsonaString(response.Content));
                            };
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

        public static class Tipo
        {
            public static void Seleccionar(Action<IRestResponse> callback)
            {
                try
                {
                    var rest = new Rest(Local.Api.UrlApi, Local.Articulo.Tipo.Seleccionar,Method.GET);
                    rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido,Constantes.Http.TipoDeContenido.Json);
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

            public static void Guardar(Action<IRestResponse> callback, List<Respuesta.Articulo.Guardar.Tipo> guardarTipo)
            {
                try
                {
                    var rest = new Rest(Local.Api.UrlApi, Local.Articulo.Tipo.Guardar,Method.POST);
                    rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido,Constantes.Http.TipoDeContenido.Json);
                    rest.Peticion.AddJsonBody(guardarTipo);
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
        public static class MaximosMinimos
        {
            public static void Guardar(Action<IRestResponse> callback, List<Respuesta.Articulo.Guardar.MaximosMinimos> guardarMaximosMinimos)
            {
                try
                {
                    var rest = new Rest(Local.Api.UrlApi, Local.Articulo.MaximosMinimos.Guardar,Method.POST);
                    rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido,Constantes.Http.TipoDeContenido.Json);
                    rest.Peticion.AddJsonBody(guardarMaximosMinimos);
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
        public static class PrecioMargen
        {
            public static void Guardar(Action<IRestResponse> callback, List<Respuesta.Articulo.Guardar.PrecioMargen> guardarPrecioMargen)
            {
                try
                {
                    var rest = new Rest(Local.Api.UrlApi, Local.Articulo.PrecioMargen.Guardar,Method.POST);
                    rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido,Constantes.Http.TipoDeContenido.Json);
                    rest.Peticion.AddJsonBody(guardarPrecioMargen);
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
