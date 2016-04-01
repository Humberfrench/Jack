using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.Application
{
    public class Roupa : ICrud<Model.Roupa, int>
    {

        public Roupa()
        {

        }

        public bool Delete(Model.Roupa oTipo)
        {
            Repository.RepRoupa oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Repository.RepRoupa();
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

            Repository.RepRoupa oDados = null;
            Model.Roupa oRetorno = null;

            try
            {
                oDados = new Repository.RepRoupa();
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

        public bool Insert(Model.Roupa oTipo)
        {
            Repository.RepRoupa oDados = null;
            bool blnRetorno = false;


            try
            {
                oDados = new Repository.RepRoupa();
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
            Repository.RepRoupa oDados = null;
            IList<Model.Roupa> lstRetorno = null;

            try
            {
                oDados = new Repository.RepRoupa();
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
            Repository.RepRoupa oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Repository.RepRoupa();
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
