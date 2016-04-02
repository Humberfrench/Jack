using Jack.DTO;
using System.Collections.Generic;
using System.Web.Http;
using Application = Jack.Application;

namespace Controllers.API
{
    public class ChamadaController : ApiController
	{

		[HttpGet()]
		public IList<DTOFamiliaChamada> GetValue([FromUri()] int ID)
        {
            Application.FamiliaApp oChamada = new Application.FamiliaApp();
			IList<DTOFamiliaChamada> oReturn = default(List<DTOFamiliaChamada>);

			oReturn = oChamada.ObterChamada(ID);
			oChamada = null;

			return oReturn;
		}


        [HttpPost]
        public void PostValue([FromUri()] int intFamilia, int intReuniao)
        {
            DTOPresenca presencaMae;
            presencaMae = new DTOPresenca(intFamilia, intReuniao);
            Application.PresencaApp oChamada = new Application.PresencaApp();

            oChamada.Registrar(presencaMae);
        }

    }
}

