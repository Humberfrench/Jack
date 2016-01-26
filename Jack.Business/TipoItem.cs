using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.Business
{
    public class TipoItem : ICrud<Model.TipoItem, int>
    {


        public TipoItem()
        {
        }

        public bool Delete(Model.TipoItem oTipo)
        {
            Data.TipoItem oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Data.TipoItem();
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

            Data.TipoItem oDados = null;
            IList<Model.TipoItem> lstRetorno = null;

            try
            {
                oDados = new Data.TipoItem();
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

        public bool Insert(Model.TipoItem oTipo)
        {
            Data.TipoItem oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Data.TipoItem();
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
            Data.TipoItem oDados = null;
            IList<Model.TipoItem> lstRetorno = null;

            try
            {
                oDados = new Data.TipoItem();
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
            Data.TipoItem oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Data.TipoItem();
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
