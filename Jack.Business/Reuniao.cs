using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.Business
{
    public class Roupa : ICrud<Model.Roupa, int>
    {

        public Roupa()
        {
        }

        public bool Delete(Model.Roupa oTipo)
        {
            Data.Roupa oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Data.Roupa();
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

        public Model.Roupa Find(int Identifier)
        {

            Data.Roupa oDados = null;
            IList<Model.Roupa> lstRetorno = null;

            try
            {
                oDados = new Data.Roupa();
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

        public bool Insert(Model.Roupa oTipo)
        {
            Data.Roupa oDados = null;
            bool blnRetorno = false;


            try
            {
                oDados = new Data.Roupa();
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

        public IList<Model.Roupa> LoadAll()
        {
            Data.Roupa oDados = null;
            IList<Model.Roupa> lstRetorno = null;

            try
            {
                oDados = new Data.Roupa();
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

        public bool Update(Model.Roupa oTipo)
        {
            Data.Roupa oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Data.Roupa();
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
