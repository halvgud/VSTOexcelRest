using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using testVSTO2.Prop;

namespace testVSTO2.Data
{
    class Receta
    {
        public static Respuesta.Receta CReceta=new Respuesta.Receta();

        public static void Lista(Action<IRestResponse> callback)
        {
            try
            {
                var rest = new Rest(Config.Local.Api.UrlApi, Config.Local.Receta.Lista + Config.Local.Receta.IdReceta,
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
                Opcion.Log(Config.Log.Interno.Categoria, "EXCEPCION: " + e.Message);
                // callback("CONTINUAR");
            }
        }
        public static void DetalleLista(Action<IRestResponse> callback)
        {
            try
            {
                var rest = new Rest(Config.Local.Api.UrlApi, Config.Local.Receta.DetalleLista + Config.Local.Receta.IdReceta,
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
                Opcion.Log(Config.Log.Interno.Categoria, "EXCEPCION: " + e.Message);
                // callback("CONTINUAR");
            }
        }

        public static void Insertar(Action<IRestResponse> callback)
        {
            try
            {
                var rest = new Rest(Config.Local.Api.UrlApi, Config.Local.Receta.Insertar, Method.POST);
                rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido, Constantes.Http.TipoDeContenido.Json);
                rest.Peticion.AddJsonBody(CReceta);
                rest.Cliente.ExecuteAsync(rest.Peticion, response =>
                {
                    switch (response.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            CReceta.rec_id= Convert.ToInt32(JObject.Parse(response.Content).Property("rec_id").Value);
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
            }
            
        }

        public class Detalle
        {
            public static List<Respuesta.Receta.Detalle> CRecetaDetalle = new List<Respuesta.Receta.Detalle>();

            public static void Insertar(Action<IRestResponse> callback)
            {
                var rest = new Rest(Config.Local.Api.UrlApi, Config.Local.Receta.InsertarDetalle, Method.POST);
                rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido, Constantes.Http.TipoDeContenido.Json);
                rest.Peticion.AddJsonBody(CRecetaDetalle);
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
        }
    }
}
