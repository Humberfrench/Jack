
using System;
using System.Collections.Generic;
using System.Web.Http;
using Jack.Business;
using Jack.Model.DTOs;

namespace Controllers.API
{
	public class FamiliaController : ApiController
	{

		[HttpGet()]
		public IList<DTOFamilia> GetValues()
		{

            IList<DTOFamilia> lstRetorno = null;
			Familia oBusiness = null;

            try
            {
                oBusiness = new Familia();
                lstRetorno = oBusiness.Load();

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

		[HttpGet()]
		public DTOFamilia GetValue([FromUri()] int ID)
		{

            DTOFamilia oRetorno = null;
			Familia oBusiness = default(Familia);

            try
            {
                oBusiness = new Familia();
                oRetorno = oBusiness.Obter(ID);

            }
            catch (Exception ex)
            {
                oRetorno = null;
                throw ex;
            }
            finally
            {
                oBusiness = null;
            }

			return oRetorno;

		}

		//[HttpPost()]
		//public void Salvar([FromUri()] Familia oFamily)
		//{
		//	//atualizando datas
		//	oFamily.DataAtualizacao = DateTime.Now;

		//	Familia oBusiness = null;
  //          try
  //          {
  //              oBusiness = new Familia();
  //              oBusiness.Update(oFamily);
  //          }
  //          finally
  //          {
  //              oBusiness = null;
  //          }

		//}

        [HttpDelete()]
        public void Delete([FromUri()] int ID)
        {
            Familia oBusiness = null;
            try
            {
                oBusiness = new Familia();
                oBusiness.Delete(ID);

            }
            finally
            {
                oBusiness = null;
            }

        }

	}
}
