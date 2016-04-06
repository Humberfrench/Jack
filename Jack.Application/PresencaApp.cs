using Jack.DTO;
using System;
using System.Collections.Generic;

namespace Jack.Application
{

    public class PresencaApp : ICrud<Model.Presenca, int>
    {


        private readonly Repository.FamiliaRep repFamilia;
        private readonly Repository.ReuniaoRep repReuniao;
        private readonly Repository.PresencaRep repPresenca;
        private readonly Repository.IUnitWork unidadeTrabalho;

        public PresencaApp()
        {
            unidadeTrabalho = new Repository.UnitWork();
            repReuniao = new Repository.ReuniaoRep(unidadeTrabalho);
            repFamilia = new Repository.FamiliaRep(unidadeTrabalho);
            repPresenca = new Repository.PresencaRep(unidadeTrabalho);

        }

        public bool Delete(Model.Presenca oTipo)
        {

            bool blnRetorno = false;

            try
            {
                blnRetorno = repPresenca.Delete(oTipo);
            }
            catch (Exception ex)
            {
                blnRetorno = false;
                throw ex;
            }

            return blnRetorno;

        }

        public Model.Presenca Find(int Identifier)
        {

            Model.Presenca oRetorno = null;

            try
            {
                oRetorno = repPresenca.Find(Identifier);
            }
            catch (Exception ex)
            {
                oRetorno = null;
                throw ex;
            }

            return oRetorno;

        }
        public bool Registrar(DTOPresenca presencaMae)
        {
            bool blnRetorno = false;
            Model.Presenca modelPresenca = null;

            try
            {
                modelPresenca = new Model.Presenca();

                modelPresenca.Familia = repFamilia.Find(presencaMae.Familia);
                modelPresenca.Reuniao = repReuniao.Find(presencaMae.Reuniao);
                blnRetorno = repPresenca.Insert(modelPresenca);
            }
            catch (Exception ex)
            {
                blnRetorno = false;
                throw ex;
            }
            finally
            {
                modelPresenca = null;
            }

            return blnRetorno;

        }
        public bool Insert(Model.Presenca oTipo)
        {

            bool blnRetorno = false;

            try
            {
                blnRetorno = repPresenca.Insert(oTipo);
            }
            catch (Exception ex)
            {
                blnRetorno = false;
                throw ex;
            }

            return blnRetorno;
        }

        public bool InsertLote(IList<Model.Presenca> lstFamilia)
        {

            bool blnRetorno = false;
            int intCont = 0;
            try
            {
                foreach (Model.Presenca oDado in lstFamilia)
                {
                    blnRetorno = Insert(oDado);
                    if (!blnRetorno)
                    {
                        throw new Exception(string.Format("Tentativa de Gravar Presença falhou. Antes foram gravados {0} de {1}  registros.", intCont.ToString() , lstFamilia.Count ));
                    }
                    intCont = intCont + 1;
                }
            }
            catch (Exception ex)
            {
                blnRetorno = false;
                throw ex;
            }

            return blnRetorno;
        }

        public IList<Model.Presenca> LoadAll()
        {

            IList<Model.Presenca> lstRetorno = null;

            try
            {
                lstRetorno = repPresenca.LoadAll();
            }
            catch (Exception ex)
            {
                lstRetorno = null;
                throw ex;
            }

            return lstRetorno;

        }

        public IList<Model.Familia> Load(int intReuniao)
        {

            IList<Model.Familia> lstRetorno = null;

            try
            {
                lstRetorno = repPresenca.Load(intReuniao);
            }
            catch (Exception ex)
            {
                lstRetorno = null;
                throw ex;
            }

            return lstRetorno;

        }

        public bool Update(Model.Presenca oTipo)
        {

            bool blnRetorno = false;

            try
            {
                blnRetorno = repPresenca.Update(oTipo);
            }
            catch (Exception ex)
            {
                blnRetorno = false;
                throw ex;
            }

            return blnRetorno;
        }

        public IList<FamiliaPresenca> ObterPresencaPorMae(int intFamilia, int intAno)
        {

            IList<FamiliaPresenca> lstRetorno = null;

            try
            {
                lstRetorno = repPresenca.ObterPresencaPorMae(intFamilia, intAno);
            }
            catch (Exception ex)
            {
                lstRetorno = null;
                throw ex;
            }

            return lstRetorno;

        }
    }
}
