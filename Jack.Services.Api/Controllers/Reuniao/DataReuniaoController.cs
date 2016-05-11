using Jack.Application;
using Jack.DTO;
using System.Collections.Generic;
using System.Web.Http;

namespace Controllers.API
{
    public class DataReuniaoController : ApiController
    {

        [HttpGet()]
        public IList<DTOReuniao> GetValues([FromUri()] int ID)
        {
            ReuniaoApp oReuniao = new ReuniaoApp();
            IList<DTOReuniao> oReturn = null;

            oReturn = oReuniao.LoadByAnoCorrente(ID);
            oReuniao = null;

            return oReturn;

        }


    }
}
