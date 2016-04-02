using System;
using System.Collections.Generic;
using System.Web.Http;
using Application = Jack.Application;
using Model = Jack.Model;


namespace Controllers.API
{
	public class CriancaController : ApiController
	{
        [HttpGet()]
        public IList<Model.Criancas> GetValues()
        {

            IList<Model.Criancas> lstRetorno = null;
            Application.CriancasApp oApplication = null;

            try
            {
                oApplication = new Application.CriancasApp();
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
        public Model.Criancas GetValue([FromUri()] int ID)
        {

            Model.Criancas oRetorno = null;
            Application.CriancasApp oApplication = null;

            try
            {
                oApplication = new Application.CriancasApp();
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
    }
}
