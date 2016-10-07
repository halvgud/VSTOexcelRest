using System;
using System.Net;
using System.Windows.Forms;
using RestSharp;
using testVSTO2.Herramienta;
using testVSTO2.Herramienta.Config;

namespace testVSTO2.Data
{
    class Reporte
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
                            MessageBox.Show(@"No se encontró registros con los parámetros utilizados");
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
                            MessageBox.Show(@"No se encontró registros con los parámetros utilizados");
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
    }
}
