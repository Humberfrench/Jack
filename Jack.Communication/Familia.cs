using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jack.Library.Extensions;

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
