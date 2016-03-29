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
            Repository.Roupa oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Repository.Roupa();
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

            Repository.Roupa oDados = null;
            Model.Roupa oRetorno = null;

            try
            {
                oDados = new Repository.Roupa();
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
            Repository.Roupa oDados = null;
            bool blnRetorno = false;


            try
            {
                oDados = new Repository.Roupa();
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
            Repository.Roupa oDados = null;
            IList<Model.Roupa> lstRetorno = null;

            try
            {
                oDados = new Repository.Roupa();
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
            Repository.Roupa oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Repository.Roupa();
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
