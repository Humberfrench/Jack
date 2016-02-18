
using System;
using System.Collections.Generic;
using System.Web.Http;
using Business = Jack.Business;
using Model = Jack.Model;

namespace Controllers.API
{
	public class FamiliaCriancaController : ApiController
	{
		public IList<Model.Criancas> ObterCriancas(int ID)
		{

			IList<Model.Criancas> lstRetorno = null;
			Business.FamiliaCrianca oBusiness = default(Business.FamiliaCrianca);

            try
            {
                oBusiness = new Business.FamiliaCrianca();
                lstRetorno = oBusiness.ObterCriancasByFamilia(ID);

            }
            catch (Exception ex)
            {
                lstRetorno = null;
            }
            finally
            {
                oBusiness = null;
            }

			return lstRetorno;

		}


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
            }
            finally
            {
                oBusiness = null;
            }

			return lstRetorno;

		}

	}
}
