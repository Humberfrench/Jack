using System;
using System.Collections.Generic;
using System.Linq;

namespace Jack.Application
{
    public class Sacolas
    {

        public IList<Model.Sacolas> ProcessaSacolas(int intAno)
        {
            IList<Model.Sacolas> lstSacolas = null;
            Repository.Sacolas oDados = null;

            try
            {
                oDados = new Repository.Sacolas();
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
            Repository.Sacolas oDados = null;
            int intSacola = 0;
            string[] aStrSacolas = null;

            try
            {
                oDados = new Repository.Sacolas();
                aStrSacolas = strListSacolasIn.Split(',');
                foreach (string strSacola in aStrSacolas)
                {
                    intSacola = Convert.ToInt32(strSacola);
                    oDados.GravarLogSacolas(intSacola);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oDados = null;
            }

        }

        public IList<Model.Sacolas> ObterSacolas(int intKit, int intNivel, string isPrinted)
        {
            IList<Model.Sacolas> lstSacolas = null;
            Repository.Sacolas oDados = null;

            try
            {
                oDados = new Repository.Sacolas();
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

        public IList<Model.Sacolas> ObterSacolasLivres(int intKit, int intNivel, string isPrinted)
        {
            IList<Model.Sacolas> lstSacolas = null;
            Repository.Sacolas oDados = null;

            try
            {
                oDados = new Repository.Sacolas();
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

        public IList<Model.Sacolas> ObterSacolas()
        {
            IList<Model.Sacolas> lstSacolas = null;
            Repository.Sacolas oDados = null;

            try
            {
                oDados = new Repository.Sacolas();
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
        public IList<Model.Sacolas> ObterSacolas(string strListSacolasIn)
        {

            IList<Model.Sacolas> lstSacolasOut = null;
            Repository.Sacolas oDados = null;

            try
            {
                oDados = new Repository.Sacolas();

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

        public IList<Model.KitSacola> ObterKitSacolas(int intKit)
        {

            IList<Model.KitSacola> lstSacolasOut = null;
            Repository.Sacolas oDados = null;

            try
            {
                oDados = new Repository.Sacolas();

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

        public IList<Model.Sacolas> ObterSacolas(int intKit, int intNivel)
        {
            IList<Model.Sacolas> lstSacolas = null;
            Repository.Sacolas oDados = null;

            try
            {
                oDados = new Repository.Sacolas();
                lstSacolas = oDados.ObterSacolas();

                if (intKit > 0 & intNivel > 0)
                {
                    lstSacolas = lstSacolas.Where(x => x.CodigoKit == intKit && x.NumeroNivel == intNivel).ToList().OrderBy(y => y.NumeroSacola).ToList() ;
                }
                else if (intKit > 0 & intNivel == 0)
                {
                    lstSacolas = lstSacolas.Where(x => x.CodigoKit == intKit).ToList().OrderBy(y => y.NumeroSacola).ToList();
                }
                else if (intKit == 0 & intNivel > 0)
                {
                    lstSacolas = lstSacolas.Where(x => x.NumeroNivel == intNivel).ToList().OrderBy(y => y.NumeroSacola).ToList();
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

        public IList<Model.Sacolas> ObterSacolas(int intSacolaFamilia)
        {
            IList<Model.Sacolas> lstSacolas = null;
            Repository.Sacolas oDados = null;

            try
            {
                oDados = new Repository.Sacolas();
                lstSacolas = oDados.ObterSacolas().Where(x => x.NumeroSacolaFamilia == intSacolaFamilia).ToList().OrderBy(y => y.NumeroSacola).ToList();
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

            Repository.Sacolas oDados = null;
            bool blnRetorno = false;


            try
            {
                oDados = new Repository.Sacolas();
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

            Repository.Sacolas oDados = null;
            bool blnRetorno = false;


            try
            {
                oDados = new Repository.Sacolas();
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

            Repository.Sacolas oDados = null;
            bool blnRetorno = false;


            try
            {
                oDados = new Repository.Sacolas();
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
