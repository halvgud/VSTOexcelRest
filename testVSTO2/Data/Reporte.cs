using System;
using System.Net;
using RestSharp;
using testVSTO2.Prop;

namespace testVSTO2.Data
{
    class Reporte
    {
        public static void General(Action<IRestResponse> callback,Respuesta.Reporte.General repGeneral)
        {
            try
            {
                var rest = new Rest(Config.Local.Api.UrlApi, Config.Local.Reporte.General,
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
                Opcion.Log(Config.Log.Interno.Categoria, "EXCEPCION: " + e.Message);
                // callback("CONTINUAR");
            }
        }
    }
}
