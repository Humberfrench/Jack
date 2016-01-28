
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
	public class FamiliaCriancaController : ApiController
	{
		public IList<Model.Criancas> ObterCriancas(int ID)
		{

			List<Model.Criancas> lstRetorno = null;
			Business.FamiliaCrianca oBusiness = default(Business.FamiliaCrianca);

			try {
				oBusiness = new Business.FamiliaCrianca();
				lstRetorno = oBusiness.ObterCriancasByFamilia(ID);

			} catch (Exception ex) {
				lstRetorno = null;
			} finally {
				oBusiness = null;
			}

			return lstRetorno;

		}


		public IList<Model.Criancas> ObterCriancasByRepresentante(int ID)
		{

			List<Model.Criancas> lstRetorno = null;
			Business.FamiliaCrianca oBusiness = default(Business.FamiliaCrianca);

			try {
				oBusiness = new Business.FamiliaCrianca();
				lstRetorno = oBusiness.ObterCriancasByFamiliaWithRep(ID);

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
