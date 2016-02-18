using System;
using System.Collections.Generic;
using System.Web.Http;
using Business = Jack.Business;
using Model = Jack.Model;


namespace Controllers.API
{
	public class DataReuniaoController : ApiController
	{

		[HttpGet()]
		public IList<Model.Reuniao> GetValues(int intAno)
		{
			Business.Reuniao oReuniao = new Business.Reuniao();
			IList<Model.Reuniao> oReturn = default(List<Model.Reuniao>);

			oReturn = oReuniao.LoadByAnoCorrente(intAno);
			oReuniao = null;

			return oReturn;

		}


	}
}
