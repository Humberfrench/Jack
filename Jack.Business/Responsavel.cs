using Jack.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.Business
{
    public class Responsavel : ICrud<Model.Responsavel, int>
    {
        public Responsavel()
        {

        }

        public bool Delete(Model.Responsavel oTipo)
        {
            Data.Responsavel oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Data.Responsavel();
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

            Data.Responsavel oDados = null;
            Model.Responsavel oRetorno = null;

            try
            {
                oDados = new Data.Responsavel();
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
            Data.Responsavel oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Data.Responsavel();
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
            Data.Responsavel oDados = null;
            IList<Model.Responsavel> lstRetorno = null;

            try
            {
                oDados = new Data.Responsavel();
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
            Data.Responsavel oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Data.Responsavel();
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
