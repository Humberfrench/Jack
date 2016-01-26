using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.Business
{
    public class Status : ICrud<Model.Status, int>
    {


        public Status()
        {
        }

        public bool Delete(Model.Status oTipo)
        {
            Data.Status oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Data.Status();
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

        public Model.Status Find(int Identifier)
        {

            Data.Status oDados = null;
            Model.Status oRetorno = null;

            try
            {
                oDados = new Data.Status();
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

        public bool Insert(Model.Status oTipo)
        {
            Data.Status oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Data.Status();
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

        public IList<Model.Status> LoadAll()
        {
            Data.Status oDados = null;
            IList<Model.Status> lstRetorno = null;

            try
            {
                oDados = new Data.Status();
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

        public IList<Model.Status> LoadForCriancas()
        {
            IList<Model.Status> lstRetorno = null;

            try
            {
                lstRetorno = lstRetorno.Where(x => x.NivelStatus == "T" || x.NivelStatus == "C").ToList();
            }
            catch (Exception ex)
            {
                lstRetorno = null;
                throw ex;
            }

            return lstRetorno;
        }

        public IList<Model.Status> LoadForFamilia()
        {
            IList<Model.Status> lstRetorno = null;

            try
            {
                lstRetorno = lstRetorno.Where(x => x.NivelStatus == "T" || x.NivelStatus == "F").ToList();
            }
            catch (Exception ex)
            {
                lstRetorno = null;
                throw ex;
            }

            return lstRetorno;
        }

        public bool Update(Model.Status oTipo)
        {
            Data.Status oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Data.Status();
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
