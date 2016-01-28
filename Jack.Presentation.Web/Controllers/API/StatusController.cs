
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
	public class StatusController : ApiController
	{

		[HttpGet()]
		public IList<Model.Status> LoadForChildrem()
		{

			List<Model.Status> lstRetorno = null;
			Business.Status oBusiness = null;
			try {
				oBusiness = new Business.Status();
				lstRetorno = oBusiness.LoadForCriancas();

			} catch (Exception ex) {
				lstRetorno = null;
			} finally {
				oBusiness = null;
			}

			return lstRetorno;


		}

		[HttpGet()]
		public IList<Model.Status> LoadForFamily()
		{

			List<Model.Status> lstRetorno = null;
			Business.Status oBusiness = null;
			try {
				oBusiness = new Business.Status();
				lstRetorno = oBusiness.LoadForFamilia();

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
