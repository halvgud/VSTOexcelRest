using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Policy;
using Herramienta;
using Herramienta.Config;
using RestSharp;


namespace Data
{
    public class Reporte
    {
        public static string Departamento { get; set; }
        public static string Categoria { get; set; }
        public static string Proveedor { get; set; }
        public static DateTime FechaIni { get; set; }
        public static DateTime FechaFin { get; set; }

        
        public static Respuesta.Receta.Diaanterior AntesDiaanterior;
        public static Respuesta.Receta.DiaanteriorX2 AntesDiaanteriorX2;
        public static Cocina.DetalleCocina.ReporteInventarioHistorial FechaHistorial;
        public static Cocina.ReporteDiarioCocina.FechasReporte FechasReporte;
  
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
                            callback(null);
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

        public static void Tag(Action<IRestResponse> callback)
        {
            try
            {
                var rest = new Rest(Local.Api.UrlApi, Local.Reporte.Tag, Method.GET);
                rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido, Constantes.Http.TipoDeContenido.Json);
                rest.Cliente.ExecuteAsync(rest.Peticion, response =>
                {
                    switch (response.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            callback(response);
                            break;
                        default:
                            throw new Exception(@"Error al cargar el indice de tags");
                    }
                });
            }
            catch (Exception e)
            {
                Opcion.Log(Log.Interno.Departamento,"EXCEPCION: "+e.Message);
            }
        }

        public static void Listaplatillos(Action<IRestResponse> callback)
        {
            try
            {
                var rest = new Rest(Local.Api.UrlApi, Herramienta.Config.Cocina.Platillos.Listado, Method.GET);
                rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido, Constantes.Http.TipoDeContenido.Json);
                rest.Cliente.ExecuteAsync(rest.Peticion, response =>
                {
                        switch (response.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            callback(response);
                            break;
                        default:
                            throw new Exception(@"Error al cargar el indice de platillos");
                    }
                });
            }
            catch (Exception e)
            {
                Opcion.Log(Log.Interno.Departamento, "EXCEPCION: " + e.Message);
            }
        }

        public static void Rep_Act_Receta(Action<IRestResponse> callback)
        {
            try
            {
                var rest = new Rest(Local.Api.UrlApi, Cocina.ActReceta.ReporteActualizarReceta, Method.GET);
                rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido, Constantes.Http.TipoDeContenido.Json);
                rest.Cliente.ExecuteAsync(rest.Peticion, response =>
                {
                    switch (response.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            callback(response);
                            break;
                        default:
                            throw new Exception(@"Recetas no encontradas");
                    }
                });
            }
            catch (Exception e)
            {
                Opcion.Log(Log.Interno.Departamento, "EXCEPCION: " + e.Message);
            }
        }

        public static void RepDiarioAct2(Action<IRestResponse> callback)
        {
            try
            {
                var rest = new Rest(Local.Api.UrlApi,Cocina.ReporteDiarioCocina.CargarRepoNew2, Method.GET);
                rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido, Constantes.Http.TipoDeContenido.Json);
                rest.Cliente.ExecuteAsync(rest.Peticion, response =>
                {
                    switch (response.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            callback(response);
                            break;
                        default:
                            callback(null);
                            break;
                            //throw new Exception(@"Error al cargar el indice de platillos");
                    }
                });
            }
            catch (Exception e)
            {
                Opcion.Log(Log.Interno.Departamento, "EXCEPCION: " + e.Message);
            }
        }

        public static void RepDiarioAct(Action<IRestResponse> callback, Respuesta.Reporte.General fecha)
        {
            try
            {
                var rest = new Rest(Local.Api.UrlApi,Cocina.ReporteDiarioCocina.CargarRepoNew, Method.POST);
                rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido, Constantes.Http.TipoDeContenido.Json);
                rest.Peticion.AddJsonBody(fecha);
                rest.Cliente.ExecuteAsync(rest.Peticion, response =>
                {
                    switch (response.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            callback(response);
                            break;
                        default:
                            callback(null);
                            break;
                    }
                });
            }
            catch (Exception e)
            {
                Opcion.Log(Log.Interno.Categoria, "EXCEPCION: " + e.Message);
            }
        }


        public static void RepCongelados(Action<IRestResponse> callback)
        {
            try
            {
                var rest = new Rest(Local.Api.UrlApi, Herramienta.Config.Cocina.Buscarcongelados.Repcongelados, Method.GET);
                rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido, Constantes.Http.TipoDeContenido.Json);
                rest.Cliente.ExecuteAsync(rest.Peticion, response =>
                {
                    switch (response.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            callback(response);
                            break;
                        default:
                            throw new Exception(@"Error al cargar el indice de platillos");
                    }
                });
            }
            catch (Exception e)
            {
                Opcion.Log(Log.Interno.Departamento, "EXCEPCION: " + e.Message);
            }
        }

        public static void RepCongeladosFechados(Action<IRestResponse> callback)
        {
            try
            {
                var rest = new Rest(Local.Api.UrlApi, Cocina.DetalleCocina.ReporteCongeladoFechas, Method.POST);
                rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido, Constantes.Http.TipoDeContenido.Json);
                rest.Peticion.AddJsonBody(FechaHistorial);
                rest.Cliente.ExecuteAsync(rest.Peticion, response =>
                {
                    switch (response.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            callback(response);
                            break;
                        default:
                            callback(null);
                            break;
                    }
                });
            }
            catch (Exception e)
            {
                Opcion.Log(Log.Interno.Categoria, "EXCEPCION: " + e.Message);
                // callback("CONTINUAR"    );

                //                {
                //                    "descripcion":"chuletas"
                //}
            }
        }


        public static void TagPorNombre(Action<IRestResponse> callback,Respuesta.Reporte.General repGeneral)
        {
            try
            {
                var rest = new Rest(Local.Api.UrlApi, Local.Reporte.Tag, Method.POST);
                rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido, Constantes.Http.TipoDeContenido.Json);
                rest.Peticion.AddJsonBody(repGeneral);
                rest.Cliente.ExecuteAsync(rest.Peticion, response =>
                {
                    switch (response.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            callback(response);
                            break;
                        default:
                            callback(null);
                            break;
                    }
                });
            }
            catch (Exception e)
            {
                Opcion.Log(Log.Interno.Categoria, "EXCEPCION: " + e.Message);
                // callback("CONTINUAR"    );

//                {
//                    "descripcion":"chuletas"
//}
            }
        }

        public static void UltimosRegistros(Action<IRestResponse> callback)
        {
            try
            {
                var rest = new Rest(Local.Api.UrlApi, Local.Reporte.UltimosRegistros, Method.GET);
                rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido, Constantes.Http.TipoDeContenido.Json);
                rest.Cliente.ExecuteAsync(rest.Peticion, response =>
                {
                    switch (response.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            callback(response);
                            break;
                        default:
                            throw new Exception(@"Error al cargar el indice de tags");
                    }
                });
            }
            catch (Exception e)
            {
                Opcion.Log(Log.Interno.Departamento, "EXCEPCION: " + e.Message);
            }
        }

        


        public static void ActualizarUltimoRegistro(Action<IRestResponse> callback,Respuesta.Reporte.General repGeneral)
        {
            try
            {
                var rest = new Rest(Local.Api.UrlApi, Local.Reporte.ActualizarUltimoRegistro, Method.POST);
                rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido, Constantes.Http.TipoDeContenido.Json);
                rest.Peticion.AddJsonBody(repGeneral);
                rest.Cliente.ExecuteAsync(rest.Peticion, response =>
                {
                    switch (response.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            callback(response);
                            break;
                        default:
                            throw new Exception(@"Error al guardar la busqueda");
                    }
                });
            }
            catch (Exception e)
            {
                Opcion.Log(Log.Interno.Departamento, "EXCEPCION: " + e.Message);
            }
            /*olle saves que desde que agregue lo del mensaje de espera me empezo a pasar eso 
             donde esta el msj de espera
             ?*/
        }

        public static void Yesterday(Action<IRestResponse> callback)
        {
            try
            {
                var rest = new Rest(Local.Api.UrlApi, Local.ReporteAnterior.DatosAnteriores, Method.POST);
                rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido, Constantes.Http.TipoDeContenido.Json);
                rest.Peticion.AddJsonBody(AntesDiaanterior);
                rest.Cliente.ExecuteAsync(rest.Peticion, response =>
                {
                    switch (response.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            //CReceta.RecId = Convert.ToInt32(JObject.Parse(response.Content).Property("RecId").Value);
                            callback(response);
                            break;
                        default:
                            throw new Exception(@"Error al buscar la Informacion deseada");
                    }
                });
            }
            catch (Exception e)
            {
                Opcion.Log(Log.Interno.Categoria, "EXCEPCION: " + e.Message);
            }

          

        }

        public static void Before(Action<IRestResponse> callback)
        {
            try
            {
                var rest = new Rest(Local.Api.UrlApi, Cocina.DiaAntesX2.X2, Method.POST);
                rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido, Constantes.Http.TipoDeContenido.Json);
                rest.Peticion.AddJsonBody(new {FechaX3 =Cocina.DiaAntesX2.FechaX2});
                rest.Cliente.ExecuteAsync(rest.Peticion, response =>
                {
                    switch (response.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            //CReceta.RecId = Convert.ToInt32(JObject.Parse(response.Content).Property("RecId").Value);
                            callback(response);
                            break;
                        default:
                            throw new Exception(@"Error al buscar la Informacion deseada");
                    }
                });
            }
            catch (Exception e)
            {
                Opcion.Log(Log.Interno.Categoria, "EXCEPCION: " + e.Message);
            }

        

        }

        public static void MostrarIngredientesReceta(Action<IRestResponse> callback)
        {
            try
            {
                var rest = new Rest(Local.Api.UrlApi, Local.Receta.IngredienteActualizar.IngredientesAct, Method.POST);
                rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido, Constantes.Http.TipoDeContenido.Json);
                rest.Peticion.AddJsonBody(new {Rec_id=Local.Receta.IngredienteActualizar.Rec_id});
                rest.Cliente.ExecuteAsync(rest.Peticion, response =>
                {
                    switch (response.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            callback(response);
                            break;
                        default:
                            callback(null);
                            break;
                    }
                });
            }
            catch (Exception e)
            {
                Opcion.Log(Log.Interno.Categoria, "EXCEPCION: " + e.Message);
                // callback("CONTINUAR"    );

                //                {
                //                    "descripcion":"chuletas"
                //}
            }
        }

        public static void ActX2(Action<IRestResponse> callback)
        {
            try
            {
                var rest = new Rest(Local.Api.UrlApi, Cocina.DiaAntesX2.ActualizarX2, Method.POST);
                rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido, Constantes.Http.TipoDeContenido.Json);
                rest.Peticion.AddJsonBody(new { EstadoId = Cocina.DiaAntesX2.EstadoId});
                rest.Cliente.ExecuteAsync(rest.Peticion, response =>
                {
                    switch (response.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            //CReceta.RecId = Convert.ToInt32(JObject.Parse(response.Content).Property("RecId").Value);
                            callback(response);
                            break;
                        default:
                            throw new Exception(@"Error al buscar la Informacion deseada");
                    }
                });
            }
            catch (Exception e)
            {
                Opcion.Log(Log.Interno.Categoria, "EXCEPCION: " + e.Message);
            }



        }


        public static void RepoDiarioD(Action<IRestResponse> callback,Cocina.ReporteDiarioCocina.FechasReporte fechas )
        {
            try
            {
                var rest = new Rest(Local.Api.UrlApi, Cocina.ReporteDiarioCocina.reporte, Method.POST);
                rest.Peticion.AddHeader(Constantes.Http.ObtenerTipoDeContenido, Constantes.Http.TipoDeContenido.Json);
                rest.Peticion.AddJsonBody(fechas);
                rest.Cliente.ExecuteAsync(rest.Peticion, response =>
                {
                    switch (response.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            //CReceta.RecId = Convert.ToInt32(JObject.Parse(response.Content).Property("RecId").Value);
                            callback(response);
                            break;
                        default:
                            callback(null);
                            break;
                            //throw new Exception(@"Error al buscar la Informacion deseada");
                    }
                });
            }
            catch (Exception e)
            {
                Opcion.Log(Log.Interno.Categoria, "EXCEPCION: " + e.Message);
            }



        }


    }

}
