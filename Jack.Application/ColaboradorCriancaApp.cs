using System;
using System.Collections.Generic;

namespace Jack.Application
{
    public class ColaboradorCriancaApp : ICrud<Model.ColaboradorCrianca, int>
    {


        public ColaboradorCriancaApp()
        {
        }

        #region "Outros Métodos"

        public IList<Model.ColaboradorCrianca> ObterCriancasPorColaborador(int intColaborador, int intAno)
        {
            Repository.ColaboradorCriancaRep oDados = null;
            IList<Model.ColaboradorCrianca> lstRetorno = null;

            try
            {
                oDados = new Repository.ColaboradorCriancaRep();
                lstRetorno = oDados.ObterCriancasPorColaborador(intColaborador, intAno);
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

        #endregion

        #region "Crud"
        public bool Delete(Model.ColaboradorCrianca oTipo)
        {
            Repository.ColaboradorCriancaRep oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Repository.ColaboradorCriancaRep();
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

        public Model.ColaboradorCrianca Find(int Identifier)
        {

            Repository.ColaboradorCriancaRep oDados = null;
            Model.ColaboradorCrianca oRetorno = null;

            try
            {
                oDados = new Repository.ColaboradorCriancaRep();
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

        public bool Insert(Model.ColaboradorCrianca oTipo)
        {
            Repository.ColaboradorCriancaRep oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Repository.ColaboradorCriancaRep();
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

        public IList<Model.ColaboradorCrianca> LoadAll()
        {
            Repository.ColaboradorCriancaRep oDados = null;
            IList<Model.ColaboradorCrianca> lstRetorno = null;

            try
            {
                oDados = new Repository.ColaboradorCriancaRep();
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

        public bool Update(Model.ColaboradorCrianca oTipo)
        {
            Repository.ColaboradorCriancaRep oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Repository.ColaboradorCriancaRep();
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
        #endregion

    }
}
