using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testVSTO2.Prop
{
    class Constantes
    {
        public class Http
        {

            public class RequestHeaders
            {
                public static readonly string Json = "application/json";
            }
            public static readonly string ObtenerTipoDeContenido = "Content-type";
            public static readonly string Autenticacion = "Authorization";
            public class TipoDeContenido
            {

                public static readonly string Json = "application/json; charset=utf-8";
                public static readonly string Xml = "application/xml; charset=utf-8";
            }
            public class MetodoHttp
            {
                public static readonly string Post = "POST";
                public static readonly string Get = "GET";
            }
        }

        public class Gcm
        {
            public class Parametro
            {
                public static readonly string CollapseKey = "collapse_key";
                public static readonly string TimeToLive = "time_to_live";
                public static readonly string DelayWhileIdle = "delay_while_idle";
                public static readonly string Message = "message";
                public static readonly string Data = "data";
                public static readonly string Time = "Time";
                public static readonly string RegistrationIds = "registration_ids";
            }
        }
    }
}
