using System;
using System.Collections.Generic;
using System.Web.Http;
using Jack.Model.DTOs;
using Jack.Business;

namespace Controllers.API
{
	public class CriancasPorFamiliaReprController : ApiController
	{
		public IList<DTOCriancaRepresentante> GetValue(int ID)
        {

			IList<DTOCriancaRepresentante> lstRetorno = null;
			FamiliaCrianca oBusiness = default(FamiliaCrianca);

            try
            {
                oBusiness = new FamiliaCrianca();
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
