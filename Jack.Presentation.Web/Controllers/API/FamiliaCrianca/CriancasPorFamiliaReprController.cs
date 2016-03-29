using System;
using System.Collections.Generic;
using System.Web.Http;
using Jack.Model.DTOs;
using Jack.Application;

namespace Controllers.API
{
	public class CriancasPorFamiliaReprController : ApiController
	{
		public IList<DTOCriancaRepresentante> GetValue(int ID)
        {

			IList<DTOCriancaRepresentante> lstRetorno = null;
			FamiliaCrianca oApplication = default(FamiliaCrianca);

            try
            {
                oApplication = new FamiliaCrianca();
                lstRetorno = oApplication.ObterCriancasByFamiliaWithRep(ID);

            }
            catch (Exception ex)
            {
                lstRetorno = null;
                throw ex;
            }
            finally
            {
                oApplication = null;
            }

			return lstRetorno;

		}

	}
}
