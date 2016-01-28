
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Net;
using System.Web.Http;

namespace Controllers.API
{
	public class DataReuniaoController : ApiController
	{

		[HttpGet()]
		public IList<Model.Reuniao> GetValues(int intAno)
		{
			Business.Reuniao oReuniao = new Business.Reuniao();
			List<Model.Reuniao> oReturn = default(List<Model.Reuniao>);

			oReturn = oReuniao.LoadByAnoCorrente(intAno);
			oReuniao = null;

			return oReturn;

		}


	}
}

//=======================================================
//Service provided by Telerik (www.telerik.com)
//Conversion powered by NRefactory.
//Twitter: @telerik
//Facebook: facebook.com/telerik
//=======================================================
