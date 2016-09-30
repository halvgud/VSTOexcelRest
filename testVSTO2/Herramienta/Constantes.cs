namespace testVSTO2.Herramienta
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
    }
}
