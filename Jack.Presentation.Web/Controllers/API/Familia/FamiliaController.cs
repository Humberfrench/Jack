
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
			FamiliaApp oApplication = null;

            oApplication = new FamiliaApp();
            lstRetorno = oApplication.Load();

            oApplication = null;

			return lstRetorno;

		}

		[HttpGet()]
		public DTOFamilia GetValue([FromUri()] int ID)
		{

            DTOFamilia oRetorno = null;
			FamiliaApp oApplication = default(FamiliaApp);

            try
            {
                oApplication = new FamiliaApp();
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
            FamiliaApp oApplication = null;
            try
            {
                oApplication = new FamiliaApp();
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
            FamiliaApp oApplication = null;
            try
            {
                oApplication = new FamiliaApp();
                oApplication.Delete(ID);

            }
            finally
            {
                oApplication = null;
            }

        }

	}
}
