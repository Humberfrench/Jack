using Jack.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.Application
{
    public class Responsavel : ICrud<Model.Responsavel, int>
    {
        public Responsavel()
        {

        }

        public bool Delete(Model.Responsavel oTipo)
        {
            Repository.RepResponsavel oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Repository.RepResponsavel();
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

            Repository.RepResponsavel oDados = null;
            Model.Responsavel oRetorno = null;

            try
            {
                oDados = new Repository.RepResponsavel();
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
            Repository.RepResponsavel oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Repository.RepResponsavel();
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
            Repository.RepResponsavel oDados = null;
            IList<Model.Responsavel> lstRetorno = null;

            try
            {
                oDados = new Repository.RepResponsavel();
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
            Repository.RepResponsavel oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Repository.RepResponsavel();
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
