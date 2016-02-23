
using System;
using System.Collections.Generic;
using System.Web.Http;
using Business = Jack.Business;
using Model = Jack.Model;

namespace Controllers.API
{
	public class CriancasPorFamiliaReprController : ApiController
	{
		public IList<Model.Criancas> ObterCriancasByRepresentante(int ID)
		{

			IList<Model.Criancas> lstRetorno = null;
			Business.FamiliaCrianca oBusiness = default(Business.FamiliaCrianca);

            try
            {
                oBusiness = new Business.FamiliaCrianca();
                lstRetorno = oBusiness.ObterCriancasByFamiliaWithRep(ID);

            }
            catch (Exception ex)
            {
                lstRetorno = null;
                throw ex;
            }
            finally
            {
                oBusiness = null;
            }

			return lstRetorno;

		}

	}
}
