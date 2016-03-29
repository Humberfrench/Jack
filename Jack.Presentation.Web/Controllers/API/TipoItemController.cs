using System;
using System.Collections.Generic;
using System.Web.Http;
using Application = Jack.Application;
using Model = Jack.Model;


namespace Controllers.API
{
    public class TipoItemController : ApiController
	{

		[HttpGet()]
		public IList<Model.TipoItem> GetValues()
		{

			IList<Model.TipoItem> lstRetorno = null;
			Application.TipoItem oApplication = default(Application.TipoItem);

            try
            {
                oApplication = new Application.TipoItem();
                lstRetorno = oApplication.LoadAll();

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
		public Model.TipoItem GetValue( [FromUri()] int ID)
		{

			Model.TipoItem oRetorno = default(Model.TipoItem);
			Application.TipoItem oApplication = default(Application.TipoItem);

			try {
				oApplication = new Application.TipoItem();
				oRetorno = oApplication.Find(ID);

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
		public void Salvar( [FromUri()] Model.TipoItem oFamily)
		{
			Application.TipoItem oApplication = default(Application.TipoItem);
			try
            {
				oApplication = new Application.TipoItem();
				oApplication.Update(oFamily);
			}
            finally
            {
				oApplication = null;
			}

		}

		[HttpDelete()]
		public void Delete(	[FromUri()] int ID)
		{
			Application.TipoItem oApplication = default(Application.TipoItem);
			Model.TipoItem oDelete = default(Model.TipoItem);
			try {
				oApplication = new Application.TipoItem();
				oDelete = new Model.TipoItem();
				oDelete.Codigo = ID;
				oApplication.Delete(oDelete);

			}
            finally
            {
				oApplication = null;
			}

		}
	}
}
