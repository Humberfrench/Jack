using Jack.Model.DTOs;
using System.Collections.Generic;
using System.Web.Http;
using Business = Jack.Business;
using Model = Jack.Model;

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

	}
}

