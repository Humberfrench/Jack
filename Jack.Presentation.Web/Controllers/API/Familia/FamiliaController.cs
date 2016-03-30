
using System;
using System.Collections.Generic;
using System.Web.Http;
using Jack.Application;
using Jack.DTO;

namespace Controllers.API
{
	public class FamiliaController : ApiController
	{

		[HttpGet()]
		public IList<DTOFamilia> GetValues()
		{

            IList<DTOFamilia> lstRetorno = null;
			Familia oApplication = null;

            try
            {
                oApplication = new Familia();
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

		[HttpGet()]
		public DTOFamilia GetValue([FromUri()] int ID)
		{

            DTOFamilia oRetorno = null;
			Familia oApplication = default(Familia);

            try
            {
                oApplication = new Familia();
                oRetorno = oApplication.Obter(ID);

            }
            catch (Exception ex)
            {
                oRetorno = null;
                throw ex;
            }
            finally
            {
                oApplication = null;
            }

			return oRetorno;

		}

        [HttpPost()]
        public void Salvar([FromBody()] DTOFamilia family)
        {
            Familia oApplication = null;
            try
            {
                oApplication = new Familia();
                oApplication.Gravar(family);
            }
            finally
            {
                oApplication = null;
            }

        }

        [HttpDelete()]
        public void Delete([FromUri()] int ID)
        {
            Familia oApplication = null;
            try
            {
                oApplication = new Familia();
                oApplication.Delete(ID);

            }
            finally
            {
                oApplication = null;
            }

        }

	}
}
