
using System;
using System.Collections.Generic;
using System.Web.Http;
using Business = Jack.Business;
using Model = Jack.Model;

namespace Controllers.API
{
	public class StatusController : ApiController
	{
        [HttpGet()]
        public IList<Model.Status> GetValues()
        {

            IList<Model.Status> lstRetorno = null;
            Business.Status oBusiness = null;
            try
            {
                oBusiness = new Business.Status();
                lstRetorno = oBusiness.LoadAll();

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

  //      [HttpGet()]
		//public IList<Model.Status> LoadForChildrem()
		//{

		//	IList<Model.Status> lstRetorno = null;
		//	Business.Status oBusiness = null;
  //          try
  //          {
  //              oBusiness = new Business.Status();
  //              lstRetorno = oBusiness.LoadForCriancas();

  //          }
  //          catch (Exception ex)
  //          {
  //              lstRetorno = null;
  //              throw ex;
  //          }
  //          finally
  //          {
  //              oBusiness = null;
  //          }

		//	return lstRetorno;

		//}

		//[HttpGet()]
		//public IList<Model.Status> LoadForFamily()
		//{

		//	IList<Model.Status> lstRetorno = null;
		//	Business.Status oBusiness = null;
		//	try
  //          {
		//		oBusiness = new Business.Status();
		//		lstRetorno = oBusiness.LoadForFamilia();

		//	}
  //          catch (Exception ex)
  //          {
		//		lstRetorno = null;
  //              throw ex;
  //          }
  //          finally
  //          {
		//		oBusiness = null;
		//	}

		//	return lstRetorno;

		//}

	}
}

