using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Jack.Presentation.Web.Controllers.API.Familia
{
    public class CriancasPorFamiliaController : ApiController
    {
        [HttpGet()]
        public IList<Model.Criancas> GetValue(int ID)
        {
            IList<Model.Criancas> lstRetorno = null;
            Business.FamiliaCrianca oBusiness = null;

            try
            {
                oBusiness = new Business.FamiliaCrianca();
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
