﻿using System;
using System.Collections.Generic;

namespace Jack.Application
{
    public class ColaboradorCrianca : ICrud<Model.ColaboradorCrianca, int>
    {


        public ColaboradorCrianca()
        {
        }

        #region "Outros Métodos"

        public IList<Model.ColaboradorCrianca> ObterCriancasPorColaborador(int intColaborador, int intAno)
        {
            Repository.RepColaboradorCrianca oDados = null;
            IList<Model.ColaboradorCrianca> lstRetorno = null;

            try
            {
                oDados = new Repository.RepColaboradorCrianca();
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
            Repository.RepColaboradorCrianca oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Repository.RepColaboradorCrianca();
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

            Repository.RepColaboradorCrianca oDados = null;
            Model.ColaboradorCrianca oRetorno = null;

            try
            {
                oDados = new Repository.RepColaboradorCrianca();
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
            Repository.RepColaboradorCrianca oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Repository.RepColaboradorCrianca();
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
            Repository.RepColaboradorCrianca oDados = null;
            IList<Model.ColaboradorCrianca> lstRetorno = null;

            try
            {
                oDados = new Repository.RepColaboradorCrianca();
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
            Repository.RepColaboradorCrianca oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Repository.RepColaboradorCrianca();
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
