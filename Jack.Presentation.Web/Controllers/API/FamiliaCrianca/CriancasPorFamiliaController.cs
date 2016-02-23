using System;
using System.Collections.Generic;
using System.Web.Http;
using Jack.Model.DTOs;
using Jack.Business;

namespace Controllers.API
{ 

    public class CriancasPorFamiliaController : ApiController
    {
        [HttpGet()]
        public IList<DTOCrianca> GetValue(int ID)
        {
            IList<DTOCrianca> lstRetorno = null;
            FamiliaCrianca oBusiness = null;

            try
            {
                oBusiness = new FamiliaCrianca();
                lstRetorno = oBusiness.ObterCriancasByFamilia(ID);

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
    }
}
