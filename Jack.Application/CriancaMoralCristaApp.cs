using System;
using System.Collections.Generic;

namespace Jack.Application
{
    public class CriancaMoralCristaApp : ICrud<Model.CriancaMoralCrista, int>
    {
        public CriancaMoralCristaApp()
        {

        }

        public bool Delete(Model.CriancaMoralCrista oTipo)
        {
            Repository.CriancaMoralCristaRep oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Repository.CriancaMoralCristaRep();
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

        public Model.CriancaMoralCrista Find(int Identifier)
        {

            Repository.CriancaMoralCristaRep oDados = null;
            Model.CriancaMoralCrista oRetorno = null;

            try
            {
                oDados = new Repository.CriancaMoralCristaRep();
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

        public bool Insert(Model.CriancaMoralCrista oTipo)
        {
            Repository.CriancaMoralCristaRep oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Repository.CriancaMoralCristaRep();
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

        public IList<Model.CriancaMoralCrista> LoadAll()
        {
            Repository.CriancaMoralCristaRep oDados = null;
            IList<Model.CriancaMoralCrista> lstRetorno = null;

            try
            {
                oDados = new Repository.CriancaMoralCristaRep();
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

        public bool Update(Model.CriancaMoralCrista oTipo)
        {
            Repository.CriancaMoralCristaRep oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Repository.CriancaMoralCristaRep();
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
