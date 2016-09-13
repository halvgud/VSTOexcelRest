using RestSharp;

namespace testVSTO2.Data
{
    class Rest
    {
        public RestClient Cliente;
        public RestRequest Peticion;
        public Rest(string urlApi, string urlMetodo, Method tipo)
        {
            Cliente = new RestClient(urlApi);
            Peticion = new RestRequest(urlMetodo, tipo);
        }
    }
}
