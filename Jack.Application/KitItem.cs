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
            Repository.RepKitItem oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Repository.RepKitItem();
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

            Repository.RepKitItem oDados = null;
            Model.KitItem oRetorno = null;

            try
            {
                oDados = new Repository.RepKitItem();
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
            Repository.RepKitItem oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Repository.RepKitItem();
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
            Repository.RepKitItem oDados = null;
            IList<Model.KitItem> lstRetorno = null;

            try
            {
                oDados = new Repository.RepKitItem();
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
            Repository.RepKitItem oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Repository.RepKitItem();
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
            Repository.RepKitItem oDados = null;
            IList<Model.KitItem> lstRetorno = null;

            try
            {
                oDados = new Repository.RepKitItem();
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
