using System;
using System.Collections.Generic;

namespace Jack.Application
{
    public class Representante
    {


        public Representante()
        {
        }
        public List<Model.Familia> ObterMaes(int intFamilia)
        {

            List<Model.Familia> lstDados = null;
            Repository.Representante objDados = null;


            try
            {
                objDados = new Repository.Representante();
                lstDados = new List<Model.Familia>();
                lstDados = objDados.ObterMaes(intFamilia);

            }
            catch (Exception ex)
            {
                lstDados = null;
                throw ex;
            }
            finally
            {
                objDados = null;
            }

            return lstDados;

        }

        public bool Add(int intFamilaRepresentante, int intFamilaRepresentada)
        {

            bool blnReturn = false;
            Repository.Representante objDados = null;


            try
            {
                objDados = new Repository.Representante();
                blnReturn = objDados.Add(intFamilaRepresentante, intFamilaRepresentada);

            }
            catch (Exception ex)
            {
                blnReturn = false;
                throw ex;
            }
            finally
            {
                objDados = null;
            }

            return blnReturn;
        }
        public bool Del(int intFamilaRepresentante, int intFamilaRepresentada)
        {

            bool blnReturn = false;
            Repository.Representante objDados = null;


            try
            {
                objDados = new Repository.Representante();
                blnReturn = objDados.Del(intFamilaRepresentante, intFamilaRepresentada);

            }
            catch (Exception ex)
            {
                blnReturn = false;
                throw ex;
            }
            finally
            {
                objDados = null;
            }

            return blnReturn;
        }
    }
}
