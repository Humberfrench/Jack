using Jack.Model.DTOs;
using System.Collections.Generic;
using System.Web.Http;
using Application = Jack.Application;
using Model = Jack.Model;
using System.Linq;

namespace Controllers.API
{
    public class ChamadaFiltroController : ApiController
	{

		[HttpGet()]
		public IList<DTOFamiliaChamada> GetValue([FromUri()] int ID, [FromUri()] string Letter)
        {
            Application.Familia oChamada = new Application.Familia();
			IList<DTOFamiliaChamada> oReturn = new List<DTOFamiliaChamada>();

			oReturn = oChamada.ObterChamada(ID).Where( x => x.Nome.Substring(0,1) == Letter).ToList();

			oChamada = null;

			return oReturn;
		}
        public IList<DTOMneumonicos> GetValues([FromUri()] int ID)
        {
            Application.Familia oChamada = new Application.Familia();
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

