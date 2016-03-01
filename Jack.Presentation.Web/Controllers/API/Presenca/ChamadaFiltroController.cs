using Jack.Model.DTOs;
using System.Collections.Generic;
using System.Web.Http;
using Business = Jack.Business;
using Model = Jack.Model;
using System.Linq;

namespace Controllers.API
{
    public class ChamadaFiltroController : ApiController
	{

		[HttpGet()]
		public IList<DTOFamiliaChamada> GetValue([FromUri()] int ID, [FromUri()] string Letter)
        {
            Business.Familia oChamada = new Business.Familia();
			IList<DTOFamiliaChamada> oReturn = new List<DTOFamiliaChamada>();

			oReturn = oChamada.ObterChamada(ID).Where( x => x.Nome.Substring(0,1) == Letter).ToList();

			oChamada = null;

			return oReturn;
		}
        public IList<DTOMneumonicos> GetValues([FromUri()] int ID)
        {
            Business.Familia oChamada = new Business.Familia();
            IList<DTOMneumonicos> oReturn = new List<DTOMneumonicos>();

            oReturn = oChamada.ObterChamada(ID).OrderBy(x => x.Nome)
                              .Select(y => y.Nome.Substring(0, 1)).Distinct()
                              .Select(x => new DTOMneumonicos(x)).ToList();

            oChamada = null;

            oReturn.Add(new DTOMneumonicos("Todos"));
            return oReturn;
        }

    }
}

