
using System;
using System.Collections.Generic;
using System.Web.Http;
using Jack.Application;
using Jack.Model.DTOs;

namespace Controllers.API
{
	public class StatusFamiliaController : ApiController
	{
        [HttpGet()]
        public IList<DTOStatus> GetValues()
        {

            IList<DTOStatus> lstRetorno = null;
            Status oApplication = null;
            try
            {
                oApplication = new Status();
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

