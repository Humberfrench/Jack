using Jack.Model;
using System;
using System.Collections.Generic;

namespace Jack.Application
{
    public class RepresentanteApp : IRepresentanteApp
    {


        public RepresentanteApp()
        {
        }
        public List<Model.Familia> ObterMaes(int intFamilia)
        {

            List<Model.Familia> lstDados = null;
            Repository.RepresentanteRep objDados = null;


            try
            {
                objDados = new Repository.RepresentanteRep();
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
            Repository.RepresentanteRep objDados = null;


            try
            {
                objDados = new Repository.RepresentanteRep();
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
            Repository.RepresentanteRep objDados = null;


            try
            {
                objDados = new Repository.RepresentanteRep();
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
