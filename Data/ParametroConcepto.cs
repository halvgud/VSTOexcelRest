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
    public class ParametroConcepto
    {
        public static void Lista(Action<IRestResponse> callback)
        {
            try
            {
                var rest = new Rest(/*Local.Api.UrlApi*/"http://localhost:8080/apimovstock/public/", Cocina.Concepto.OrdenConcepto,
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
