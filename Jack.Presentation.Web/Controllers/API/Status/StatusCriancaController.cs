
using System;
using System.Collections.Generic;
using System.Web.Http;
using Jack.DTO;
using Jack.Application;

namespace Controllers.API
{
	public class StatusCriancaController : ApiController
	{
        [HttpGet()]
        public IList<DTOStatus> GetValues()
        {

            IList<DTOStatus> lstRetorno = null;
            StatusApp oApplication = null;
            try
            {
                oApplication = new StatusApp();
                lstRetorno = oApplication.LoadForCriancas();

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

