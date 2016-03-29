
using Jack.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Web.Http;
using Jack.Application;

namespace Controllers.API
{
    public class StatusController : ApiController
	{
        [HttpGet()]
        public IList<DTOStatus> GetValues()
        {

            IList<DTOStatus> lstRetorno = null;
            Status oApplication = null;
            try
            {
                oApplication = new Status();
                lstRetorno = oApplication.Load();
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

  //      [HttpGet()]
		//public IList<Model.Status> LoadForChildrem()
		//{

		//	IList<Model.Status> lstRetorno = null;
		//	Application.Status oApplication = null;
  //          try
  //          {
  //              oApplication = new Application.Status();
  //              lstRetorno = oApplication.LoadForCriancas();

  //          }
  //          catch (Exception ex)
  //          {
  //              lstRetorno = null;
  //              throw ex;
  //          }
  //          finally
  //          {
  //              oApplication = null;
  //          }

		//	return lstRetorno;

		//}

		//[HttpGet()]
		//public IList<Model.Status> LoadForFamily()
		//{

		//	IList<Model.Status> lstRetorno = null;
		//	Application.Status oApplication = null;
		//	try
  //          {
		//		oApplication = new Application.Status();
		//		lstRetorno = oApplication.LoadForFamilia();

		//	}
  //          catch (Exception ex)
  //          {
		//		lstRetorno = null;
  //              throw ex;
  //          }
  //          finally
  //          {
		//		oApplication = null;
		//	}

		//	return lstRetorno;

		//}

	}
}

