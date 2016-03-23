using Jack.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.Business
{

    public class Presenca : ICrud<Model.Presenca, int>
    {


        private readonly Data.Familia repFamilia;
        private readonly Data.Reuniao repReuniao;
        private readonly Data.Presenca repPresenca;
        private readonly Data.IUnitWork unidadeTrabalho;

        public Presenca()
        {
            unidadeTrabalho = new Data.UnitWork();
            repReuniao = new Data.Reuniao(unidadeTrabalho);
            repFamilia = new Data.Familia(unidadeTrabalho);
            repPresenca = new Data.Presenca(unidadeTrabalho);

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

        public IList<Model.FamiliaPresenca> ObterPresencaPorMae(int intFamilia, int intAno)
        {

            IList<Model.FamiliaPresenca> lstRetorno = null;

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
