
using System;
using System.Collections.Generic;
using System.Web.Http;
using Business = Jack.Business;
using Model = Jack.Model;

namespace Controllers.API
{
	public class FamiliaController : ApiController
	{

		[HttpGet()]
		public IList<Model.Familia> GetValues()
		{

			IList<Model.Familia> lstRetorno = null;
			Business.Familia oBusiness = default(Business.Familia);

            try
            {
                oBusiness = new Business.Familia();
                lstRetorno = oBusiness.LoadAll();

            }
            catch (Exception ex)
            {
                lstRetorno = null;
            }
            finally
            {
                oBusiness = null;
            }

			return lstRetorno;

		}

		[HttpGet()]
		public Model.Familia GetValue([FromUri()] int ID)
		{

			Model.Familia oRetorno = default(Model.Familia);
			Business.Familia oBusiness = default(Business.Familia);

            try
            {
                oBusiness = new Business.Familia();
                oRetorno = oBusiness.Find(ID);

            }
            catch (Exception ex)
            {
                oRetorno = null;
            }
            finally
            {
                oBusiness = null;
            }

			return oRetorno;

		}

		[HttpPost()]
		public void Salvar([FromUri()] Model.Familia oFamily)
		{
			//atualizando datas
			oFamily.DataAtualizacao = DateTime.Now;

			Business.Familia oBusiness = default(Business.Familia);
            try
            {
                oBusiness = new Business.Familia();
                oBusiness.Update(oFamily);
            }
            finally
            {
                oBusiness = null;
            }

		}

        [HttpDelete()]
        public void Delete([FromUri()] int ID)
        {
            Business.Familia oBusiness = default(Business.Familia);
            Model.Familia oDelete = default(Model.Familia);
            try
            {
                oBusiness = new Business.Familia();
                oDelete = new Model.Familia();
                oDelete.Codigo = ID;
                oBusiness.Delete(oDelete);

            }
            finally
            {
                oBusiness = null;
            }

        }

	}
}
