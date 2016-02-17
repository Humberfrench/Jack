using Jack.Library.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jack.Communication
{
    public class Familia
    {
        public string GetFamilias()
        {
            string strFamilias = string.Empty;
            Business.Familia oFamilia = null;

            try
            {
               
                oFamilia = new Business.Familia();
                strFamilias = oFamilia.LoadAll().ToList().ToJSON();
                
            }
            catch  (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oFamilia = null;
            }

            return strFamilias;
        }
    }
}
