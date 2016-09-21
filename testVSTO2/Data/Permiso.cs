using System;
using System.Net;
using RestSharp;
using testVSTO2.Prop;

namespace testVSTO2.Data
{
    class Permiso
    {
        public static void ObtenerPermiso(Action<IRestResponse> callback)
        {
            try
            {
                var rest = new Rest(Config.Local.Api.UrlApi, Config.Local.Permiso.Obtener,
                    Method.GET);
                rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido,
                    Constantes.Http.TipoDeContenido.Json);
               var response= rest.Cliente.Execute(rest.Peticion);
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        callback(response);
                        break;
                    default:
                        throw new Exception(@"error al buscar permisos");
                }
               /* rest.Cliente.ExecuteAsync(rest.Peticion, response1 =>
                {
                    switch (response1.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            callback(response);
                            break;
                        default:
                            throw new Exception(@"error al buscar permisos");
                    }
                });*/
            }
            catch (Exception e)
            {
                Opcion.Log(Config.Log.Interno.Categoria, "EXCEPCION: " + e.Message);
                // callback("CONTINUAR");
            }
        }
    }
}
