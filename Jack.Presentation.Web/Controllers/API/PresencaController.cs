
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
	public class PresencaController : ApiController
	{

		[HttpGet()]
		public IList<Model.Familia> GetValue(int ID)
		{

			List<Model.Familia> lstRetorno = null;
			Business.Presenca oBusiness = default(Business.Presenca);

			try {
				oBusiness = new Business.Presenca();
				lstRetorno = oBusiness.Load(ID);

			} catch (Exception ex) {
				lstRetorno = null;
			} finally {
				oBusiness = null;
			}

			return lstRetorno;
		}

		public List<Model.FamiliaPresenca> ObterPresencaPorMae(int Familia, int Ano)
		{

			List<Model.FamiliaPresenca> lstRetorno = null;
			Business.Presenca oBusiness = default(Business.Presenca);

			try {
				oBusiness = new Business.Presenca();
				lstRetorno = oBusiness.ObterPresencaPorMae(Familia, Ano);

			} catch (Exception ex) {
				lstRetorno = null;
			} finally {
				oBusiness = null;
			}

			return lstRetorno;
		}

	}
}

//=======================================================
//Service provided by Telerik (www.telerik.com)
//Conversion powered by NRefactory.
//Twitter: @telerik
//Facebook: facebook.com/telerik
//=======================================================
