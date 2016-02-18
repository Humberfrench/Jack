using System;
using System.Collections.Generic;
using System.Web.Http;
using Business = Jack.Business;
using Model = Jack.Model;


namespace Controllers.API
{
    public class TipoItemController : ApiController
	{

		[HttpGet()]
		public IList<Model.TipoItem> GetValues()
		{

			IList<Model.TipoItem> lstRetorno = null;
			Business.TipoItem oBusiness = default(Business.TipoItem);

            try
            {
                oBusiness = new Business.TipoItem();
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

		[HttpGet()]
		public Model.TipoItem GetValue( [FromUri()] int ID)
		{

			Model.TipoItem oRetorno = default(Model.TipoItem);
			Business.TipoItem oBusiness = default(Business.TipoItem);

			try {
				oBusiness = new Business.TipoItem();
				oRetorno = oBusiness.Find(ID);

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

		[HttpPost()]
		public void Salvar( [FromUri()] Model.TipoItem oFamily)
		{
			Business.TipoItem oBusiness = default(Business.TipoItem);
			try
            {
				oBusiness = new Business.TipoItem();
				oBusiness.Update(oFamily);
			}
            finally
            {
				oBusiness = null;
			}

		}

		[HttpDelete()]
		public void Delete(	[FromUri()] int ID)
		{
			Business.TipoItem oBusiness = default(Business.TipoItem);
			Model.TipoItem oDelete = default(Model.TipoItem);
			try {
				oBusiness = new Business.TipoItem();
				oDelete = new Model.TipoItem();
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
