using System;
using System.Collections.Generic;

namespace Jack.Business
{
    public class ColaboradorCrianca : ICrud<Model.ColaboradorCrianca, int>
    {


        public ColaboradorCrianca()
        {
        }

        #region "Outros Métodos"

        public IList<Model.ColaboradorCrianca> ObterCriancasPorColaborador(int intColaborador, int intAno)
        {
            Data.ColaboradorCrianca oDados = null;
            IList<Model.ColaboradorCrianca> lstRetorno = null;

            try
            {
                oDados = new Data.ColaboradorCrianca();
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
            Data.ColaboradorCrianca oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Data.ColaboradorCrianca();
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

            Data.ColaboradorCrianca oDados = null;
            Model.ColaboradorCrianca oRetorno = null;

            try
            {
                oDados = new Data.ColaboradorCrianca();
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
            Data.ColaboradorCrianca oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Data.ColaboradorCrianca();
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
            Data.ColaboradorCrianca oDados = null;
            IList<Model.ColaboradorCrianca> lstRetorno = null;

            try
            {
                oDados = new Data.ColaboradorCrianca();
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
            Data.ColaboradorCrianca oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Data.ColaboradorCrianca();
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
