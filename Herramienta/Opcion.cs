using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Herramienta.Config;
using Newtonsoft.Json;
using Respuesta;
using RestSharp;
using RestSharp.Deserializers;


namespace Herramienta
{
   public class Opcion
    {

       /// <summary>
       /// Función que realiza la escritura de mensajes a un archivo
       /// </summary>
       /// <param name="archivo">Archivo a generar</param>
       /// <param name="mensaje">Mensaje a escribir en archivo</param>
       /// <remarks></remarks>



       public static void Validacionesgenerales(string dato,string tabla)
       {
           
       }
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


       public static void Deletecmdserver(string deletePath, string directory)
        {


                var command = "NET USE " + directory + " /user:" + "Administrador" + " " + "Sysadmin11";
                ExecuteCommand(command, 5000);

                command = "del /Q " + deletePath ;
                ExecuteCommand(command, 5000);


                command = "NET USE " + deletePath + " /delete /y";
                ExecuteCommand(command, 5000);


          }

        public static void Copycmdserver(string filePath, string savePath)
        {
            var directoryName = Path.GetDirectoryName(savePath);
            if (directoryName != null)
            {
                var directory = directoryName.Trim();
                var filenameToSave = Path.GetFileName(savePath);

                if (!directory.EndsWith("\\"))
                    filenameToSave = "\\" + filenameToSave;

                var command = "NET USE " + directory + " /delete";
                ExecuteCommand(command, 5000);

                command = "NET USE " + directory + " /user:" +"Administrador" + " " +"Sysadmin11";
                ExecuteCommand(command, 5000);
                
                command = " copy \"" + filePath + "\"  \"" + directory + filenameToSave + "\"";
                ExecuteCommand(command, 5000);


                command = "NET USE " + directory + " /delete";
                ExecuteCommand(command, 5000);
         

            }
        }

        public static int ExecuteCommand(string command, int timeout)
        {
            var processInfo = new ProcessStartInfo("cmd.exe", "/C " + command)
            {
                CreateNoWindow = true,
                UseShellExecute = false,
                WorkingDirectory = "C:\\",
            };

            var process = Process.Start(processInfo);
            if (process != null)
            {
                process.WaitForExit(timeout);
               // var exitCode = process.ExitCode;
                process.Close();
                return 1;
            }
            return 0;
        }


        public static List<T> JsonaListaGenerica<T>(IRestResponse json)
        {
          List<T> x=new List<T>();
            try
            {
                var desSerializer = new JsonDeserializer();
                x = desSerializer.Deserialize<List<T>>(json);
                return x;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return x;
            }
        }
        public static T JsonaClaseGenerica<T>(IRestResponse json) where T : new()
        {
           T x = new T();
            try
            {
                var desSerializer = new JsonDeserializer();
                x = desSerializer.Deserialize<List<T>>(json)[0];
                return x;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return x;
            }
        }
        /*Cuando hagan commit, antes de hacerlo los 2 hacen este cambio
         a la funcion de arriba le cambian el nombre en Refactorizar (Clic derecho->refactorizar)
         Le ponen JsonAListaGenerica
         y a la funcion de abajo se queda como JsonaClaseGenerica*/
        public static T JsonaClaseGenerica2<T>(IRestResponse json) where T : new()
        {
            T x = new T();
            try
            {
                var desSerializer = new JsonDeserializer();
                x = desSerializer.Deserialize<T>(json);
               // x = 
                return x;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return x;
            }
        }


        public static string JsonaString(string json)
        {
            dynamic myObject = JsonConvert.DeserializeObject<dynamic>(json);
            dynamic mensaje = myObject.message ?? myObject.mensaje;
            return Convert.ToString(mensaje);
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
        public static void BorrarSeleccion(DataGridView ingredientes)
        {
            if (ingredientes.CurrentCell.RowIndex == -1 || ingredientes.Rows.Count <= 0) return;
            var result = ingredientes.DataSource as List<Respuesta.Articulo.Basica>;
            if (result == null) return;
            result.RemoveAt(ingredientes.CurrentCell.RowIndex);
            ingredientes.DataSource = null;
            ingredientes.Refresh();
            ingredientes.DataSource = result;
        }

        public static void BorrarDataGridView(DataGridView dgv)
        {
            dgv.DataSource = null;
            dgv.Refresh();
        }
        public static bool ValidarDouble(Control text)
        {
            var regex = new System.Text.RegularExpressions.Regex(@"^[0-9]*(?:\.[0-9]*)?$");
            if (!regex.IsMatch(text.Text))
            {
                text.Text = "";
                return false;
            }
            return true;
        }
        public static bool ValidarCaracter(KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                return  true;
            }
            return false;
        }
        private void LimpiarControles(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c.HasChildren)
                {
                    LimpiarControles(c);
                }
                else if (c is TextBox)
                {
                    ((TextBox)c).Clear();
                }
                else if (c is CheckBox)
                {

                    ((CheckBox)c).Checked = false;
                }

                else if (c is RadioButton)
                {
                    ((RadioButton)c).Checked = false;
                }
            }
        }

        public static void EjecucionAsyncAction(Action<Action<IRestResponse>> accionInicial, Action<IRestResponse> accionFinal, Action<IRestResponse> p)
        {
            accionInicial(accionFinal);
            //throw new NotImplementedException();
        }

        public static object JsonaListaGenerica<T>(object jsonResult)
        {
            throw new NotImplementedException();
        }
    }
}
