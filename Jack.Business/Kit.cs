using System;
using System.Collections.Generic;

namespace Jack.Business
{
    public class Kit : ICrud<Model.Kit, int>
    {

        public Kit()
        {
        }

        public bool Delete(Model.Kit oTipo)
        {
            Data.Kit oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Data.Kit();
                blnRetorno = oDados.Delete(oTipo);
            }
            catch (Exception ex)
            {
                blnRetorno = false;
                throw ex;
            }
            finally
            {
                oDados = null;
            }

            return blnRetorno;

        }

        public Model.Kit Find(int Identifier)
        {

            Data.Kit oDados = null;
            IList<Model.Kit> lstRetorno = null;

            try
            {
                oDados = new Data.Kit();
                lstRetorno = oDados.LoadAll();
            }
            catch (Exception ex)
            {
                lstRetorno = null;
                throw ex;
            }
            finally
            {
                oDados = null;
            }

            return lstRetorno;

        }

        public bool Insert(Model.Kit oTipo)
        {
            Data.Kit oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Data.Kit();
                blnRetorno = oDados.Insert(oTipo);
            }
            catch (Exception ex)
            {
                blnRetorno = false;
                throw ex;
            }
            finally
            {
                oDados = null;
            }

            return blnRetorno;
        }

        public IList<Model.Kit> LoadAll()
        {
            Data.Kit oDados = null;
            IList<Model.Kit> lstRetorno = null;

            try
            {
                oDados = new Data.Kit();
                lstRetorno = oDados.LoadAll();
            }
            catch (Exception ex)
            {
                lstRetorno = null;
                throw ex;
            }
            finally
            {
                oDados = null;
            }

            return lstRetorno;

        }

        public bool Update(Model.Kit oTipo)
        {
            Data.Kit oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Data.Kit();
                blnRetorno = oDados.Update(oTipo);
            }
            catch (Exception ex)
            {
                blnRetorno = false;
                throw ex;
            }
            finally
            {
                oDados = null;
            }

            return blnRetorno;
        }
    }
}
