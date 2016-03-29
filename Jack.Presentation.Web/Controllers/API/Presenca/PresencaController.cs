using System;
using System.Collections.Generic;
using System.Web.Http;
using Application = Jack.Application;
using Model = Jack.Model;


namespace Controllers.API
{
	public class PresencaController : ApiController
	{
        [HttpGet()]
        public Model.Reuniao GetValues(int ID)
		{

			Model.Reuniao lstRetorno = null;
			Application.Reuniao oApplication = null;

			try
            {
				oApplication = new Application.Reuniao();
				lstRetorno = oApplication.Find(ID);

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
