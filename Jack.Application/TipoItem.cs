﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.Application
{
    public class TipoItem : ICrud<Model.TipoItem, int>
    {


        public TipoItem()
        {
        }

        public bool Delete(Model.TipoItem oTipo)
        {
            Repository.TipoItem oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Repository.TipoItem();
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

        public Model.TipoItem Find(int Identifier)
        {

            Repository.TipoItem oDados = null;
            Model.TipoItem oRetorno = null;

            try
            {
                oDados = new Repository.TipoItem();
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

        public bool Insert(Model.TipoItem oTipo)
        {
            Repository.TipoItem oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Repository.TipoItem();
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

        public IList<Model.TipoItem> LoadAll()
        {
            Repository.TipoItem oDados = null;
            IList<Model.TipoItem> lstRetorno = null;

            try
            {
                oDados = new Repository.TipoItem();
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

        public bool Update(Model.TipoItem oTipo)
        {
            Repository.TipoItem oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Repository.TipoItem();
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