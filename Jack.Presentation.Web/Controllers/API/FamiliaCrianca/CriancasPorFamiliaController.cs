using System;
using System.Collections.Generic;
using System.Web.Http;
using Jack.DTO;
using Jack.Application;

namespace Controllers.API
{ 

    public class CriancasPorFamiliaController : ApiController
    {
        [HttpGet()]
        public IList<DTOCrianca> GetValue(int ID)
        {
            IList<DTOCrianca> lstRetorno = null;
            FamiliaCriancaApp oApplication = null;

            try
            {
                oApplication = new FamiliaCriancaApp();
                lstRetorno = oApplication.ObterCriancasByFamilia(ID);

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
