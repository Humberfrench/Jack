using System;
using System.Collections.Generic;
using System.Web.Http;
using Business = Jack.Business;
using Model = Jack.Model;


namespace Controllers.API
{
	public class PresencaController : ApiController
	{
        [HttpGet()]
        public Model.Reuniao GetValues(int ID)
		{

			Model.Reuniao lstRetorno = null;
			Business.Reuniao oBusiness = null;

			try
            {
				oBusiness = new Business.Reuniao();
				lstRetorno = oBusiness.Find(ID);

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
