using Jack.DTO;
using Jack.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.Application
{
    public class StatusApp : ICrud<Model.Status, int>
    {

        private readonly Repository.StatusRep repStatus;
        private readonly Repository.IUnitWork unidadeTrabalho;

        public StatusApp()
        {
            unidadeTrabalho = new Repository.UnitWork();
            repStatus = new Repository.StatusRep(unidadeTrabalho);
        }

        public bool Delete(Model.Status oTipo)
        {
            bool blnRetorno = false;

            try
            {
                blnRetorno = repStatus.Delete(oTipo);
            }
            catch (Exception ex)
            {
                blnRetorno = false;
                throw ex;
            }

            return blnRetorno;

        }

        public Model.Status Find(int Identifier)
        {

            Model.Status oRetorno = null;

            try
            {
                oRetorno = repStatus.Find(Identifier);
            }
            catch (Exception ex)
            {
                oRetorno = null;
                throw ex;
            }

            return oRetorno;

        }

        public bool Insert(Model.Status oTipo)
        {
            bool blnRetorno = false;

            try
            {
                blnRetorno = repStatus.Insert(oTipo);
            }
            catch (Exception ex)
            {
                blnRetorno = false;
                throw ex;
            }

            return blnRetorno;
        }

        public IList<Model.Status> LoadAll()
        {
            IList<Model.Status> lstRetorno = null;

            try
            {
                lstRetorno = repStatus.LoadAll();
            }
            catch (Exception ex)
            {
                lstRetorno = null;
                throw ex;
            }

            return lstRetorno;

        }

        public IList<DTOStatus> LoadForCriancas()
        {
            IList<DTOStatus> lstRetorno = null;

            try
            {
                lstRetorno = Load().Where(x => x.NivelStatus == "T" || x.NivelStatus == "C").ToList();
            }
            catch (Exception ex)
            {
                lstRetorno = null;
                throw ex;
            }

            return lstRetorno;
        }

        public IList<DTOStatus> LoadForFamilia()
        {
            IList<DTOStatus> lstRetorno = null;

            try
            {
                lstRetorno = Load().Where(x => x.NivelStatus == "T" || x.NivelStatus == "F").ToList();
            }
            catch (Exception ex)
            {
                lstRetorno = null;
                throw ex;
            }

            return lstRetorno;
        }

        public IList<DTOStatus> Load()
        {
            IList<DTOStatus> lstRetorno = null;

            try
            {
                lstRetorno = repStatus.Load();
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
            bool blnRetorno = false;

            try
            {
                blnRetorno = repStatus.Update(oTipo);
            }
            catch (Exception ex)
            {
                blnRetorno = false;
                throw ex;
            }

            return blnRetorno;
        }
    }
}
