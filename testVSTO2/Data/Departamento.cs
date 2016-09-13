﻿using System;
using System.Net;
using RestSharp;
using testVSTO2.Prop;

namespace testVSTO2.Data
{
    class Departamento
    {
        public static void Lista(Action<IRestResponse> callback)
        {
            try
            {
                var rest = new Rest(Config.Local.Api.UrlApi, Config.Local.Departamento.Lista,
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
                            //Opcion.Log(Config.Log.Interno.Departamento, response.Content);
                           throw new Exception(@"error al cargar Departamentos");
                           // callback("CONTINUAR");
                    }

                });
            }
            catch (Exception e)
            {
                Opcion.Log(Config.Log.Interno.Departamento, "EXCEPCION: " + e.Message);
               // callback("CONTINUAR");
            }
        }
    }
}
