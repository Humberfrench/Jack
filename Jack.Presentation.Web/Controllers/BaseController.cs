using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Jack.Presentation.Web.Controllers.MVC
{
    public class BaseController : Controller
    {
        public RestClientDispose CriaRestClient()
        {
            var client = new RestClientDispose(ConfigurationManager.AppSettings["EnderecoWebAPI"]);

            return client;
        }

        void Teste()
        {
            var request = new RestRequest("v1/UsuarioExternos/Acesso/AlterarMinhaFraseCor", Method.POST)
            {
                RequestFormat = DataFormat.Json
            };

        }

        protected T GetApiMethod<T>(string uri, Dictionary<string, object> parameters, out HttpStatusCode responseStatus)
        {
            using (var restClient = CriaRestClient())
            {
                var request = new RestRequest(uri, Method.GET);

                if (parameters != null && parameters.Count > 0)
                {
                    foreach (var item in parameters)
                    {
                        request.AddParameter(item.Key, item.Value);
                    }
                }

                var response = restClient.Execute(request);

                responseStatus = response.StatusCode;

                return response.StatusCode == HttpStatusCode.OK ? JsonConvert.DeserializeObject<T>(response.Content) : (T)Activator.CreateInstance(typeof(T));
            }
        }

        protected T PostApiMethod<T>(string uri, object model, out HttpStatusCode responseStatus)
        {
            using (var restClient = CriaRestClient())
            {
                var request = new RestRequest(uri, Method.POST) { RequestFormat = DataFormat.Json };

                request.AddBody(model);

                var response = restClient.Execute(request);

                responseStatus = response.StatusCode;

                return response.StatusCode == HttpStatusCode.OK ? JsonConvert.DeserializeObject<T>(response.Content) : (T)Activator.CreateInstance(typeof(T));
            }
        }

        protected IList<T> PageIndex<T>(IList<T> listModel, int index, int qtdItensPage)
        {
            int count = (qtdItensPage * index) <= listModel.Count() ? qtdItensPage : listModel.Count() % qtdItensPage;

            return listModel.ToList().GetRange((index - 1) * qtdItensPage, count);

            //how to call api
            // [AllowAnonymous]
            //[Route("Acesso/LogOff")]
            //[HttpGet]
            //public HttpResponseMessage LogOff(string cpf)
            //{
            //    _usuarioExternoAppService.LogOff(cpf);

            //    return Request.CreateResponse(HttpStatusCode.OK);
            //}
        }

    }

    public class RestClientDispose : RestClient, IDisposable
    {
        public RestClientDispose(string enderecoBaseApi)
            : base(enderecoBaseApi)
        {

        }

        public void Dispose()
        {

        }
    }
}
