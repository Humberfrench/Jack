using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Jack.Presentation.Web.Controllers.API
{
    public class AnosController : ApiController
    {
        public List<string> GetValues()
        {
            List<string> listaRetorno = new List<string>();
            for (int ano = 2014; ano <= 2020; ano++)
            {
                listaRetorno.Add(ano.ToString());
            }
            return listaRetorno;
        }
    }
}
