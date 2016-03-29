using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.Application
{
    public class Colaborador : ICrud<Model.Colaborador, int>
    {


        public Colaborador()
        {
        }

        #region "Outros Métodos"

        public IList<Model.Colaborador> ListaQuantidadeSacolasPorColaborador(int intAno)
        {

            Repository.Colaborador oDados = null;
            IList<Model.Colaborador> lstRetorno = null;

            try
            {
                oDados = new Repository.Colaborador();
                lstRetorno = oDados.ListaQuantidadeSacolasPorColaborador(intAno);
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
        public bool Delete(Model.Colaborador oTipo)
        {
            Repository.Colaborador oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Repository.Colaborador();
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

        public Model.Colaborador Find(int Identifier)
        {

            Repository.Colaborador oDados = null;
            Model.Colaborador oRetorno = null;

            try
            {
                oDados = new Repository.Colaborador();
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

        public bool Insert(Model.Colaborador oTipo)
        {
            Repository.Colaborador oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Repository.Colaborador();
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

        public IList<Model.Colaborador> LoadAll()
        {
            Repository.Colaborador oDados = null;
            IList<Model.Colaborador> lstRetorno = null;

            try
            {
                oDados = new Repository.Colaborador();
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

        public bool Update(Model.Colaborador oTipo)
        {
            Repository.Colaborador oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Repository.Colaborador();
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
