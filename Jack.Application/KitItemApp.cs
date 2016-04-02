using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.Application
{
    public class KitItemApp : ICrud<Model.KitItem, int>
    {


        public KitItemApp()
        {
        }

        public bool Delete(Model.KitItem oTipo)
        {
            Repository.KitItemRep oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Repository.KitItemRep();
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

            Repository.KitItemRep oDados = null;
            Model.KitItem oRetorno = null;

            try
            {
                oDados = new Repository.KitItemRep();
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
            Repository.KitItemRep oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Repository.KitItemRep();
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
            Repository.KitItemRep oDados = null;
            IList<Model.KitItem> lstRetorno = null;

            try
            {
                oDados = new Repository.KitItemRep();
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
            Repository.KitItemRep oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Repository.KitItemRep();
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
            Repository.KitItemRep oDados = null;
            IList<Model.KitItem> lstRetorno = null;

            try
            {
                oDados = new Repository.KitItemRep();
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
