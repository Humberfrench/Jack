using Jack.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.Application
{
    public class ResponsavelApp : ICrud<Model.Responsavel, int>, IResponsavelApp
    {
        public ResponsavelApp()
        {

        }

        public bool Delete(Model.Responsavel oTipo)
        {
            Repository.ResponsavelRep oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Repository.ResponsavelRep();
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

        public Model.Responsavel Find(int Identifier)
        {

            Repository.ResponsavelRep oDados = null;
            Model.Responsavel oRetorno = null;

            try
            {
                oDados = new Repository.ResponsavelRep();
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

        public bool Insert(Model.Responsavel oTipo)
        {
            Repository.ResponsavelRep oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Repository.ResponsavelRep();
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

        public IList<Model.Responsavel> LoadAll()
        {
            Repository.ResponsavelRep oDados = null;
            IList<Model.Responsavel> lstRetorno = null;

            try
            {
                oDados = new Repository.ResponsavelRep();
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

        public bool Update(Model.Responsavel oTipo)
        {
            Repository.ResponsavelRep oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Repository.ResponsavelRep();
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
