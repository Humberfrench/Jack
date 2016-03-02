
using System;
using System.Collections.Generic;
using System.Web.Http;
using Jack.Business;
using Jack.Model.DTOs;

namespace Controllers.API
{
	public class StatusFamiliaController : ApiController
	{
        [HttpGet()]
        public IList<DTOStatus> GetValues()
        {

            IList<DTOStatus> lstRetorno = null;
            Status oBusiness = null;
            try
            {
                oBusiness = new Status();
                lstRetorno = oBusiness.LoadForFamilia();

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

