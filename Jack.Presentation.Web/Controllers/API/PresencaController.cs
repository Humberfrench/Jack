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
		public IList<Model.Familia> GetValue(int ID)
		{

			IList<Model.Familia> lstRetorno = null;
			Business.Presenca oBusiness = default(Business.Presenca);

            try
            {
                oBusiness = new Business.Presenca();
                lstRetorno = oBusiness.Load(ID);

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

		public IList<Model.FamiliaPresenca> ObterPresencaPorMae(int Familia, int Ano)
		{

			IList<Model.FamiliaPresenca> lstRetorno = null;
			Business.Presenca oBusiness = default(Business.Presenca);

			try
            {
				oBusiness = new Business.Presenca();
				lstRetorno = oBusiness.ObterPresencaPorMae(Familia, Ano);

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

	}
}
