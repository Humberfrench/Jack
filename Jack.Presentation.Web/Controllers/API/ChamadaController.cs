using System.Collections.Generic;
using System.Web.Http;
using Business = Jack.Business;
using Model = Jack.Model;

namespace Controllers.API
{
    public class ChamadaController : ApiController
	{

		[HttpGet()]
		public IList<Model.Familia> ObterChamada(int intReuniao)
		{
            Business.Familia oChamada = new Business.Familia();
			IList<Model.Familia> oReturn = default(List<Model.Familia>);

			oReturn = oChamada.ObterChamada(intReuniao);
			oChamada = null;

			return oReturn;
		}

	}
}

