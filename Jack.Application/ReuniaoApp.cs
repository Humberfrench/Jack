using Consumer.Tools;
using Jack.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.Application
{
    public class ReuniaoApp : ICrud<Model.Reuniao, int>
    {

        private readonly Repository.FamiliaRep repFamilia;
        private readonly Repository.ReuniaoRep repReuniao;
        private readonly Repository.PresencaRep repPresenca;
        private readonly Repository.IUnitWork unidadeTrabalho;

        public ReuniaoApp()
        {
            unidadeTrabalho = new Repository.UnitWork();
            repReuniao = new Repository.ReuniaoRep(unidadeTrabalho);
            repFamilia = new Repository.FamiliaRep(unidadeTrabalho);
            repPresenca = new Repository.PresencaRep(unidadeTrabalho);

        }

        public List<Model.Reuniao> GerarDatas(int intAno)
        {

            Model.Reuniao oReuniao = default(Model.Reuniao);
            List<Model.Reuniao> lstTmpReuniao = default(List<Model.Reuniao>);
            List<Model.Reuniao> lstAddReuniao = default(List<Model.Reuniao>);
            List<Model.Reuniao> lstReuniao = default(List<Model.Reuniao>);
            System.DateTime dateDados = default(System.DateTime);
            string strSabadosConfig = string.Empty;
            string[] aSabadosReuniao = null;

            try
            {
                lstTmpReuniao = new List<Model.Reuniao>();
                lstAddReuniao = new List<Model.Reuniao>();
                dateDados = new System.DateTime(intAno, 1, 1);
                while (dateDados.Year == intAno)
                {
                    oReuniao = new Model.Reuniao();
                    oReuniao.Ano = intAno;
                    oReuniao.Data = dateDados;
                    if (dateDados.DayOfWeek == DayOfWeek.Saturday)
                    {
                        lstTmpReuniao.Add(oReuniao);
                    }
                    dateDados = dateDados.AddDays(1);
                }

                lstReuniao = new List<Model.Reuniao>();
                strSabadosConfig = Util.Settings.Get("SabadosReuniao");
                aSabadosReuniao = strSabadosConfig.Split(',');

                for (int intMes = 1; intMes <= 12; intMes++)
                {
                    int intMesPesq = intMes;
                    lstAddReuniao = lstTmpReuniao.Where(x => x.Data.Month == intMesPesq).ToList();

                    lstReuniao.Add(lstAddReuniao[Convert.ToInt16(aSabadosReuniao[0]) - 1]);
                    lstReuniao.Add(lstAddReuniao[Convert.ToInt16(aSabadosReuniao[1]) - 1]);

                }
            }
            catch (Exception ex)
            {
                lstTmpReuniao = null;
                lstAddReuniao = null;
                throw ex;
            }
            finally
            {
                oReuniao = null;
            }


            return lstReuniao;

        }

        public IList<Model.Reuniao> Load(int intAno)
        {

            IList<Model.Reuniao> iListDatas = LoadAll().Where(x => x.AnoCorrente == intAno).ToList();
            return iListDatas;

        }
        public IList<DTOReuniao> LoadByAnoCorrente(int intAno)
        {
            IList<DTOReuniao> iListDatas = null;
            try
            {
                iListDatas = repReuniao.LoadByAnoCorrente(intAno);
            }
            catch (Exception ex)
            {
                iListDatas = null;
                throw ex;
            }
            return iListDatas;

        }
        public bool AddDatas(int intAno)
        {

            List<Model.Reuniao> lstDatas = null;
            bool blnretorno = false;
            DateTime dateDado = DateTime.Now;
            try
            {
                lstDatas = GerarDatas(intAno);
                foreach (Model.Reuniao oDado in lstDatas)
                {
                    dateDado = oDado.Data;
                    repReuniao.Insert(oDado);
                }
                blnretorno = true;
            }
            catch (Exception ex)
            {
                blnretorno = false;
                throw new Exception(string.Format("Erro inserindo a data: {0}" , dateDado.ToString()), ex);
            }
            lstDatas = null;
            return blnretorno;
        }

        public bool Delete(Model.Reuniao oTipo)
        {
            bool blnRetorno = false;

            try
            {
                blnRetorno = repReuniao.Delete(oTipo);
            }
            catch (Exception ex)
            {
                blnRetorno = false;
                throw ex;
            }
            return blnRetorno;

        }

        public Model.Reuniao Find(int Identifier)
        {

            Model.Reuniao oRetorno = null;

            try
            {
                oRetorno = repReuniao.Find(Identifier);
            }
            catch (Exception ex)
            {
                oRetorno = null;
                throw ex;
            }

            return oRetorno;

        }

        public bool Insert(Model.Reuniao oTipo)
        {
            bool blnRetorno = false;

            try
            {
                blnRetorno = repReuniao.Insert(oTipo);
            }
            catch (Exception ex)
            {
                blnRetorno = false;
                throw ex;
            }

            return blnRetorno;
        }

        public IList<Model.Reuniao> LoadAll()
        {
            IList<Model.Reuniao> lstRetorno = null;

            try
            {
                lstRetorno = repReuniao.LoadAll();
            }
            catch (Exception ex)
            {
                lstRetorno = null;
                throw ex;
            }

            return lstRetorno;

        }

        public bool Update(Model.Reuniao oTipo)
        {
            bool blnRetorno = false;

            try
            {
                blnRetorno = repReuniao.Update(oTipo);
            }
            catch (Exception ex)
            {
                blnRetorno = false;
                throw ex;
            }

            return blnRetorno;
        }

        public int ObterDatasReuniaoAno(DateTime strData, int intAno)
        {
            IList<Model.Reuniao> lstDados = null;
            int intRetorno = 0;

            try
            {
                lstDados = Load(intAno).Where(x => x.Data == strData).ToList();

                if (lstDados.Count > 0)
                {
                    intRetorno = lstDados[0].Codigo;
                }
                else {
                    intRetorno = 0;
                }

            }
            catch (Exception ex)
            {
                intRetorno = 0;
                throw ex;
            }
            finally
            {
                lstDados = null;
            }

            return intRetorno;

        }

    }
}
