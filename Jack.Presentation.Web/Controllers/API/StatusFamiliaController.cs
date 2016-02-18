
using System;
using System.Collections.Generic;
using System.Web.Http;
using Business = Jack.Business;
using Model = Jack.Model;

namespace Controllers.API
{
	public class StatusFamiliaController : ApiController
	{
        [HttpGet()]
        public IList<Model.Status> GetValues()
        {

            IList<Model.Status> lstRetorno = null;
            Business.Status oBusiness = null;
            try
            {
                oBusiness = new Business.Status();
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

