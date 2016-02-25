using System;
using System.Collections.Generic;
using System.Web.Http;
using Business = Jack.Business;
using Model = Jack.Model;


namespace Controllers.API
{
	public class CriancaController : ApiController
	{
        [HttpGet()]
        public IList<Model.Criancas> GetValues()
        {

            IList<Model.Criancas> lstRetorno = null;
            Business.Criancas oBusiness = null;

            try
            {
                oBusiness = new Business.Criancas();
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
        public Model.Criancas GetValue([FromUri()] int ID)
        {

            Model.Criancas oRetorno = null;
            Business.Criancas oBusiness = null;

            try
            {
                oBusiness = new Business.Criancas();
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
    }
}
