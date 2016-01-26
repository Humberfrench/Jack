using System;
using System.Collections.Generic;
using System.Linq;
using Jack;

namespace Jack.Business
{
    public class Calcado : ICrud<Model.Calcado, int>
    {


        public Calcado()
        {
        }

        public bool Delete(Model.Calcado oTipo)
        {
            Data.Calcado oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Data.Calcado();
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

        public Model.Calcado Find(int Identifier)
        {

            Data.Calcado oDados = null;
            Model.Calcado oRetorno = null;

            try
            {
                oDados = new Data.Calcado();
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

        public bool Insert(Model.Calcado oTipo)
        {
            Data.Calcado oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Data.Calcado();
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

        public IList<Model.Calcado> LoadAll()
        {
            Data.Calcado oDados = null;
            IList<Model.Calcado> lstRetorno = null;

            try
            {

                oDados = new Data.Calcado();
                lstRetorno = oDados.LoadAll().OrderByDescending(x => x.MedidaIdade).ToList().OrderBy(y => y.Sexo).ToList().OrderBy(z => z.IdadeInicial).ToList();

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

        public bool Update(Model.Calcado oTipo)
        {
            Data.Calcado oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Data.Calcado();
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