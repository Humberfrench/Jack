using System;
using System.Collections.Generic;

namespace Jack.Application
{
    public class KitApp : ICrud<Model.Kit, int>
    {

        public KitApp()
        {
        }

        public bool Delete(Model.Kit oTipo)
        {
            Repository.KitRep oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Repository.KitRep();
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

            Repository.KitRep oDados = null;
            Model.Kit oRetorno = null;

            try
            {
                oDados = new Repository.KitRep();
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
            Repository.KitRep oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Repository.KitRep();
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
            Repository.KitRep oDados = null;
            IList<Model.Kit> lstRetorno = null;

            try
            {
                oDados = new Repository.KitRep();
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
            Repository.KitRep oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Repository.KitRep();
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
