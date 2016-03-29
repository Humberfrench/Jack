using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.Application
{
    public class KitItem : ICrud<Model.KitItem, int>
    {


        public KitItem()
        {
        }

        public bool Delete(Model.KitItem oTipo)
        {
            Repository.KitItem oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Repository.KitItem();
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

        public Model.KitItem Find(int Identifier)
        {

            Repository.KitItem oDados = null;
            Model.KitItem oRetorno = null;

            try
            {
                oDados = new Repository.KitItem();
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

        public bool Insert(Model.KitItem oTipo)
        {
            Repository.KitItem oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Repository.KitItem();
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

        public IList<Model.KitItem> LoadAll()
        {
            Repository.KitItem oDados = null;
            IList<Model.KitItem> lstRetorno = null;

            try
            {
                oDados = new Repository.KitItem();
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

        public bool Update(Model.KitItem oTipo)
        {
            Repository.KitItem oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Repository.KitItem();
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

        public IList<Model.KitItem> LoadKitItemByKit(int intKit)
        {
            Repository.KitItem oDados = null;
            IList<Model.KitItem> lstRetorno = null;

            try
            {
                oDados = new Repository.KitItem();
                lstRetorno = oDados.LoadKitItemByKit(intKit);
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

    }
}
