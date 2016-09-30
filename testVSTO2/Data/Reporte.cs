using System;
using System.Net;
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
                var rest = new Rest(Local.Api.UrlApi,Local.Reporte.General,
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
