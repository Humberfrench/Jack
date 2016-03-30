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
            Application.Familia oChamada = new Application.Familia();
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
            Application.Presenca oChamada = new Application.Presenca();

            oChamada.Registrar(presencaMae);
        }

    }
}

