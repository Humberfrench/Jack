using System;
using System.Collections.Generic;

namespace Jack.Application
{
    public class Kit : ICrud<Model.Kit, int>
    {

        public Kit()
        {
        }

        public bool Delete(Model.Kit oTipo)
        {
            Repository.Kit oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Repository.Kit();
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

            Repository.Kit oDados = null;
            Model.Kit oRetorno = null;

            try
            {
                oDados = new Repository.Kit();
                oRetorno = oDados.Find(Identifier);
            }
            catch (Exception ex)
            {
                oRetorno = null;
                throw ex;
            }
            finally
            {
                oDados = null;
            }

            return oRetorno;

        }

        public bool Insert(Model.Kit oTipo)
        {
            Repository.Kit oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Repository.Kit();
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
            Repository.Kit oDados = null;
            IList<Model.Kit> lstRetorno = null;

            try
            {
                oDados = new Repository.Kit();
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
            Repository.Kit oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Repository.Kit();
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
