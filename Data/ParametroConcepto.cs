using System;
using System.Net;
using Herramienta;
using Herramienta.Config;
using RestSharp;

namespace Data
{
    public class ParametroProducto
    {
        public static void Lista(Action<IRestResponse> callback)
        {

            try
            {
                var rest = new Rest(Local.Api.UrlApi, Cocina.ordenarproducto.OrdenConcepto,
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
                            throw new Exception(@"error al buscar producto");
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
