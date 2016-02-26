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
		public IList<Model.Reuniao> GetValues([FromUri()] int ID)
		{
			Business.Reuniao oReuniao = new Business.Reuniao();
			IList<Model.Reuniao> oReturn = default(List<Model.Reuniao>);

			oReturn = oReuniao.LoadByAnoCorrente(ID);
			oReuniao = null;

			return oReturn;

		}


	}
}
