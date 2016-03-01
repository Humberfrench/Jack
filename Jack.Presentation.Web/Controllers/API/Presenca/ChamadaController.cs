using Jack.Model.DTOs;
using System.Collections.Generic;
using System.Web.Http;
using Business = Jack.Business;

namespace Controllers.API
{
    public class ChamadaController : ApiController
	{

		[HttpGet()]
		public IList<DTOFamiliaChamada> GetValue([FromUri()] int ID)
        {
            Business.Familia oChamada = new Business.Familia();
			IList<DTOFamiliaChamada> oReturn = default(List<DTOFamiliaChamada>);

			oReturn = oChamada.ObterChamada(ID);
			oChamada = null;

			return oReturn;
		}


        [HttpPost]
        public void PostValue([FromUri()] int intFamilia, imt intReuniao)
        {
            DTOPresenca presencaMae;
            presencaMae = new DTOPresenca();
            Business.Presenca oChamada = new Business.Presenca();

            //oChamada.
        }

    }
}

