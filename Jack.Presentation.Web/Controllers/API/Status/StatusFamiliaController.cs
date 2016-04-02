
using System;
using System.Collections.Generic;
using System.Web.Http;
using Jack.Application;
using Jack.DTO;

namespace Controllers.API
{
	public class StatusFamiliaController : ApiController
	{
        [HttpGet()]
        public IList<DTOStatus> GetValues()
        {

            IList<DTOStatus> lstRetorno = null;
            StatusApp oApplication = null;
            try
            {
                oApplication = new StatusApp();
                lstRetorno = oApplication.LoadForFamilia();

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

