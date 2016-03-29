
using System;
using System.Collections.Generic;
using System.Web.Http;
using Jack.Model.DTOs;
using Jack.Application;

namespace Controllers.API
{
	public class StatusCriancaController : ApiController
	{
        [HttpGet()]
        public IList<DTOStatus> GetValues()
        {

            IList<DTOStatus> lstRetorno = null;
            Status oApplication = null;
            try
            {
                oApplication = new Status();
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

