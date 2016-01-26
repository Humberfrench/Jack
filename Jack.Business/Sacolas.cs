using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.Business
{
    public class Sacolas
    {

        public List<Model.Sacolas> ProcessaSacolas(int intAno)
        {

            List<Model.Sacolas> lstSacolas = null;
            Data.Sacolas oDados = null;

            try
            {
                oDados = new Data.Sacolas();
                lstSacolas = oDados.ProcessaSacolas(intAno);

            }
            catch (Exception ex)
            {
                lstSacolas = null;
                throw ex;
            }
            finally
            {
                oDados = null;
            }

            return lstSacolas;

        }


        public void GravarLogSacolas(string strListSacolasIn)
        {
            List<Model.Sacolas> lstSacolas = null;
            Data.Sacolas oDados = null;
            int intSacola = 0;
            string[] aStrSacolas = null;

            try
            {
                oDados = new Data.Sacolas();
                aStrSacolas = strListSacolasIn.Split(',');
                foreach (string strSacola in aStrSacolas)
                {
                    intSacola = Convert.ToInt32(strSacola);
                    oDados.GravarLogSacolas(intSacola);
                }

            }
            catch (Exception ex)
            {
                lstSacolas = null;
                throw ex;
            }
            finally
            {
                oDados = null;
            }

        }

        public List<Model.Sacolas> ObterSacolas(int intKit, int intNivel, string isPrinted)
        {
            List<Model.Sacolas> lstSacolas = null;
            Data.Sacolas oDados = null;

            try
            {
                oDados = new Data.Sacolas();
                lstSacolas = oDados.ObterSacolas(intKit, intNivel, isPrinted);

            }
            catch (Exception ex)
            {
                lstSacolas = null;
                throw ex;
            }
            finally
            {
                oDados = null;
            }

            return lstSacolas;

        }

        public List<Model.Sacolas> ObterSacolasLivres(int intKit, int intNivel, string isPrinted)
        {
            List<Model.Sacolas> lstSacolas = null;
            Data.Sacolas oDados = null;

            try
            {
                oDados = new Data.Sacolas();
                lstSacolas = oDados.ObterSacolasLivres(intKit, intNivel, isPrinted);

            }
            catch (Exception ex)
            {
                lstSacolas = null;
                throw ex;
            }
            finally
            {
                oDados = null;
            }

            return lstSacolas;

        }

        public List<Model.Sacolas> ObterSacolas()
        {
            List<Model.Sacolas> lstSacolas = null;
            Data.Sacolas oDados = null;

            try
            {
                oDados = new Data.Sacolas();
                lstSacolas = oDados.ObterSacolas();

            }
            catch (Exception ex)
            {
                lstSacolas = null;
                throw ex;
            }
            finally
            {
                oDados = null;
            }

            return lstSacolas;

        }
        public List<Model.Sacolas> ObterSacolas(string strListSacolasIn)
        {

            List<Model.Sacolas> lstSacolasOut = null;
            Data.Sacolas oDados = null;

            try
            {
                oDados = new Data.Sacolas();

                lstSacolasOut = oDados.ObterSacolas(strListSacolasIn);

            }
            catch (Exception ex)
            {
                lstSacolasOut = null;
                throw ex;
            }
            finally
            {
                oDados = null;
            }

            return lstSacolasOut;

        }

        public List<Model.KitSacola> ObterKitSacolas(int intKit)
        {

            List<Model.KitSacola> lstSacolasOut = null;
            Data.Sacolas oDados = null;

            try
            {
                oDados = new Data.Sacolas();

                lstSacolasOut = oDados.ObterKitSacolas(intKit);

            }
            catch (Exception ex)
            {
                lstSacolasOut = null;
                throw ex;
            }
            finally
            {
                oDados = null;
            }

            return lstSacolasOut;

        }

        public List<Model.Sacolas> ObterSacolas(int intKit, int intNivel)
        {
            List<Model.Sacolas> lstSacolas = null;
            Data.Sacolas oDados = null;
            IOrderedEnumerable<Model.Sacolas> iPesq = default(IOrderedEnumerable<Model.Sacolas>);


            try
            {
                oDados = new Data.Sacolas();
                lstSacolas = oDados.ObterSacolas();

                if (intKit > 0 & intNivel > 0)
                {
                    iPesq = from oDado in lstSacolaswhere oDado.CodigoKit == intKit & oDado.NumeroNivel == intNivelorderby oDado.NumeroSacola;

                    lstSacolas = iPesq.ToList();
                }
                else if (intKit > 0 & intNivel == 0)
                {
                    iPesq = from oDado in lstSacolaswhere oDado.CodigoKit == intKitorderby oDado.NumeroSacola;

                    lstSacolas = iPesq.ToList();
                }
                else if (intKit == 0 & intNivel > 0)
                {
                    iPesq = from oDado in lstSacolaswhere oDado.NumeroNivel == intNivelorderby oDado.NumeroSacola;

                    lstSacolas = iPesq.ToList();
                }

            }
            catch (Exception ex)
            {
                lstSacolas = null;
                throw ex;
            }
            finally
            {
                oDados = null;
            }

            return lstSacolas;

        }

        public List<Model.Sacolas> ObterSacolas(int intSacolaFamilia)
        {
            List<Model.Sacolas> lstSacolas = null;
            Data.Sacolas oDados = null;
            IOrderedEnumerable<Model.Sacolas> iPesq = default(IOrderedEnumerable<Model.Sacolas>);


            try
            {
                oDados = new Data.Sacolas();
                lstSacolas = oDados.ObterSacolas();

                iPesq = from oDado in lstSacolaswhere oDado.NumeroSacolaFamilia == intSacolaFamiliaorderby oDado.NumeroSacola;

                lstSacolas = iPesq.ToList();

            }
            catch (Exception ex)
            {
                lstSacolas = null;
                throw ex;
            }
            finally
            {
                oDados = null;
            }

            return lstSacolas;

        }


        public bool AddSacolaCrianca(int intCrianca)
        {

            Data.Sacolas oDados = null;
            bool blnRetorno = false;


            try
            {
                oDados = new Data.Sacolas();
                blnRetorno = oDados.AddSacolaCrianca(intCrianca);

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

        public bool AddSacolaColaboradorCrianca(int intCrianca, int intColaborador, int intAno, bool isDevolvida)
        {

            Data.Sacolas oDados = null;
            bool blnRetorno = false;


            try
            {
                oDados = new Data.Sacolas();
                blnRetorno = oDados.AddSacolaColaboradorCrianca(intCrianca, intColaborador, intAno, isDevolvida);

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


        public bool AddSacolaColaboradorSacola(int intSacola, int intColaborador, int intAno, bool isDevolvida)
        {

            Data.Sacolas oDados = null;
            bool blnRetorno = false;


            try
            {
                oDados = new Data.Sacolas();
                blnRetorno = oDados.AddSacolaColaboradorSacola(intSacola, intColaborador, intAno, isDevolvida);

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

    }


}
