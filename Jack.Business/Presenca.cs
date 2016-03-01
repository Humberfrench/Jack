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


        public Presenca()
        {
        }

        public bool Delete(Model.Presenca oTipo)
        {

            Data.Presenca oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Data.Presenca();
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

        public Model.Presenca Find(int Identifier)
        {

            Data.Presenca oDados = null;
            Model.Presenca oRetorno = null;

            try
            {
                oDados = new Data.Presenca();
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
        public bool Registrar(DTOPresenca presencaMae)
        {
            Data.Presenca oDados = null;
            Data.Familia oFamilia = null;
            Data.Reuniao oReuniao = null;
            bool blnRetorno = false;
            Model.Presenca modelPresenca = null;

            try
            {
                oDados = new Data.Presenca();
                oFamilia = new Data.Familia();
                oReuniao = new Data.Reuniao();
                modelPresenca = new Model.Presenca();

                modelPresenca.Familia = oFamilia.Find(presencaMae.Familia);
                modelPresenca.Reuniao = oReuniao.Find(presencaMae.Reuniao);
                blnRetorno = oDados.Insert(modelPresenca);
            }
            catch (Exception ex)
            {
                blnRetorno = false;
                throw ex;
            }
            finally
            {
                oDados = null;
                oFamilia = null;
                oReuniao = null;
                modelPresenca = null;
            }

            return blnRetorno;

        }
        public bool Insert(Model.Presenca oTipo)
        {

            Data.Presenca oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Data.Presenca();
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

            Data.Presenca oDados = null;
            IList<Model.Presenca> lstRetorno = null;

            try
            {
                oDados = new Data.Presenca();
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

        public IList<Model.Familia> Load(int intReuniao)
        {

            Data.Presenca oDados = null;
            IList<Model.Familia> lstRetorno = null;

            try
            {
                oDados = new Data.Presenca();
                lstRetorno = oDados.Load(intReuniao);
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

        public bool Update(Model.Presenca oTipo)
        {

            Data.Presenca oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Data.Presenca();
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

        public List<Model.FamiliaPresenca> ObterPresencaPorMae(int intFamilia, int intAno)
        {

            Data.Presenca oDados = null;
            List<Model.FamiliaPresenca> lstRetorno = null;

            try
            {
                oDados = new Data.Presenca();
                lstRetorno = oDados.ObterPresencaPorMae(intFamilia, intAno);
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
