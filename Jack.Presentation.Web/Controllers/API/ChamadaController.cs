
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
	public class ChamadaController : ApiController
	{

		[HttpGet()]
		public IList<Model.Familia> ObterChamada(int intReuniao)
		{
			Business.Familia oChamada = new Business.Familia();
			List<Model.Familia> oReturn = default(List<Model.Familia>);

			oReturn = oChamada.ObterChamada(intReuniao);
			oChamada = null;

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
