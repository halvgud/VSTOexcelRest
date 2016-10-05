using System;
using System.Net;
using RestSharp;
using testVSTO2.Herramienta;
using testVSTO2.Herramienta.Config;

namespace testVSTO2.Data
{
    class Permiso
    {
        public static void ObtenerPermiso(Action<IRestResponse> callback)
        {
            try
            {
                var rest = new Rest(Local.Api.UrlApi, Local.Permiso.Obtener,
                    Method.POST);
                rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido,
                    Constantes.Http.TipoDeContenido.Json);
                rest.Peticion.AddJsonBody(new {Nombre= Environment.MachineName.ToUpper()});
               var response= rest.Cliente.Execute(rest.Peticion);
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:callback(response);
                        break;
                    default:
                        throw new Exception(@"error al buscar permisos");
                }
            }
            catch (Exception e)
            {
                Opcion.Log(Log.Interno.Categoria, "EXCEPCION: " + e.Message);
                // callback("CONTINUAR");
            }
        }
    }
}
