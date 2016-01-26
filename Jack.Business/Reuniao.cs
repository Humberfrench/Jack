using Consumer.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.Business
{
    public class Reuniao : ICrud<Model.Reuniao, int>
    {

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
        public IList<Model.Reuniao> LoadByAnoCorrente(int intAno)
        {

            IList<Model.Reuniao> iListDatas = LoadAll().Where(x => x.AnoCorrente == intAno).ToList();
            return iListDatas;

        }
        public bool AddDatas(int intAno)
        {

            List<Model.Reuniao> lstDatas = null;
            bool blnretorno = false;
            Data.Reuniao oDados = null;
            DateTime dateDado = DateTime.Now;
            try
            {
                lstDatas = GerarDatas(intAno);
                oDados = new Data.Reuniao();
                foreach (Model.Reuniao oDado in lstDatas)
                {
                    dateDado = oDado.Data;
                    oDados.Insert(oDado);
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
            Data.Reuniao oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Data.Reuniao();
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

        public Model.Reuniao Find(int Identifier)
        {

            Data.Reuniao oDados = null;
            Model.Reuniao oRetorno = null;

            try
            {
                oDados = new Data.Reuniao();
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

        public bool Insert(Model.Reuniao oTipo)
        {
            Data.Reuniao oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Data.Reuniao();
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

        public IList<Model.Reuniao> LoadAll()
        {
            Data.Reuniao oDados = null;
            IList<Model.Reuniao> lstRetorno = null;

            try
            {
                oDados = new Data.Reuniao();
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

        public bool Update(Model.Reuniao oTipo)
        {
            Data.Reuniao oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Data.Reuniao();
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

        public int ObterDatasReuniaoAno(DateTime strData, int intAno)
        {
            IEnumerable<Model.Reuniao> iPesq = null;
            IList<Model.Reuniao> lstDados = null;
            int intRetorno = 0;

            try
            {
                lstDados = Load(intAno).Where(x => x.Data == strData).ToList();

                if (iPesq.ToList().Count > 0)
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
                iPesq = null;
                lstDados = null;
            }

            return intRetorno;

        }

    }
}
