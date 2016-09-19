using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using RestSharp;
using RestSharp.Deserializers;


namespace testVSTO2.Prop
{
    class Opcion
    {
        public static void InicializarVariables()
        {
            try
            {
                if (File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.ini")))
                {
                    var lineas = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.ini"));
                    var diccionario
                        =
                        (from Match m in
                            lineas.SelectMany(line => Regex.Matches(line, "(.+)\\.(.+)\\.(.+)=(.+)").Cast<Match>())
                         select new
                         {
                             clase = m.Groups[1].Value,
                             subclase = m.Groups[2].Value,
                             propiedad = m.Groups[3].Value,
                             valor = m.Groups[4].Value
                         }
                            ).ToList();
                    foreach (var elemento in diccionario)
                    {
                        var prop =
                                new Config().GetType()
                                    .GetNestedType(elemento.clase)
                                    .GetNestedType(elemento.subclase)
                                    .GetProperty(elemento.propiedad);
                        if (prop?.CanWrite ?? false)
                        {
                            prop?.SetValue(new Config(), Convert.ChangeType(elemento.valor, prop.PropertyType), null);
                        }
                    }

                }
                else
                {
                    Log("log_configuracion.txt", "Error al cargar configuraciones, se cargará configuracion default");
                }
            }
            catch (Exception a)
            {
                Log("log_configuracion.txt", "Error al leer configuraciones, se cargará configuracion default");
                Log("log_configuracion.txt", a.ToString());
            }
        }
        /// <summary>
        /// Función que realiza la escritura de mensajes a un archivo
        /// </summary>
        /// <param name="archivo">Archivo a generar</param>
        /// <param name="mensaje">Mensaje a escribir en archivo</param>
        /// <remarks></remarks>
        public static void Log(string archivo, string mensaje)
        {
            //variable que inicializa el streamwriter
            var txtMirror = default(StreamWriter);
            try
            {
                //si no existe, se crea
                txtMirror = new StreamWriter(archivo, true);
                txtMirror.WriteLine(DateTime.Now.ToLocalTime() + "::" + mensaje);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                txtMirror?.Close();
            }
        }

        public static List<T> JsonaListaGenerica<T>(IRestResponse json)
        {
            List<T> x=new List<T>();
            try
            {
                JsonDeserializer desSerializer = new JsonDeserializer();
                x = desSerializer.Deserialize<List<T>>(json);
                return x;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return x;
            }
            
        }


        public static void EjecucionAsync(Action<Action<IRestResponse>> accionInicial, Action<IRestResponse> accionFinal)
        {
            accionInicial(accionFinal);
        }
        public static void EjecucionAsync(Action<Action<IRestResponse>> accionInicial, Action<Action<IRestResponse>> accionFinal,Action<IRestResponse> callback)
        {
            accionInicial(x =>
            {
                accionFinal(callback);
            });
        }
        /* public static string LimpiarJson(string json)
         {
             return JObject.Parse(json.Substring(json.IndexOf('{'),
                       json.LastIndexOf('}') + 1 - json.IndexOf('{'))).ToString();
         }*/
    }
}
