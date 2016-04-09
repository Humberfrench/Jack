using Jack.DTO;
using Jack.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Jack.Application
{
    public class SacolasApp : ISacolasApp
    {

        public IList<DTO.Sacolas> ProcessaSacolas(int intAno)
        {
            IList<DTO.Sacolas> lstSacolas = null;
            Repository.SacolasRep oDados = null;

            try
            {
                oDados = new Repository.SacolasRep();
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
            Repository.SacolasRep oDados = null;
            int intSacola = 0;
            string[] aStrSacolas = null;

            try
            {
                oDados = new Repository.SacolasRep();
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

        public IList<DTO.Sacolas> ObterSacolas(int intKit, int intNivel, string isPrinted)
        {
            IList<DTO.Sacolas> lstSacolas = null;
            Repository.SacolasRep oDados = null;

            try
            {
                oDados = new Repository.SacolasRep();
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

        public IList<DTO.Sacolas> ObterSacolasLivres(int intKit, int intNivel, string isPrinted)
        {
            IList<DTO.Sacolas> lstSacolas = null;
            Repository.SacolasRep oDados = null;

            try
            {
                oDados = new Repository.SacolasRep();
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

        public IList<DTO.Sacolas> ObterSacolas()
        {
            IList<DTO.Sacolas> lstSacolas = null;
            Repository.SacolasRep oDados = null;

            try
            {
                oDados = new Repository.SacolasRep();
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
        public IList<DTO.Sacolas> ObterSacolas(string strListSacolasIn)
        {

            IList<DTO.Sacolas> lstSacolasOut = null;
            Repository.SacolasRep oDados = null;

            try
            {
                oDados = new Repository.SacolasRep();

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

        public IList<KitSacola> ObterKitSacolas(int intKit)
        {

            IList<KitSacola> lstSacolasOut = null;
            Repository.SacolasRep oDados = null;

            try
            {
                oDados = new Repository.SacolasRep();

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

        public IList<DTO.Sacolas> ObterSacolas(int intKit, int intNivel)
        {
            IList<DTO.Sacolas> lstSacolas = null;
            Repository.SacolasRep oDados = null;

            try
            {
                oDados = new Repository.SacolasRep();
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

        public IList<DTO.Sacolas> ObterSacolas(int intSacolaFamilia)
        {
            IList<DTO.Sacolas> lstSacolas = null;
            Repository.SacolasRep oDados = null;

            try
            {
                oDados = new Repository.SacolasRep();
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

            Repository.SacolasRep oDados = null;
            bool blnRetorno = false;


            try
            {
                oDados = new Repository.SacolasRep();
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

            Repository.SacolasRep oDados = null;
            bool blnRetorno = false;


            try
            {
                oDados = new Repository.SacolasRep();
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

            Repository.SacolasRep oDados = null;
            bool blnRetorno = false;


            try
            {
                oDados = new Repository.SacolasRep();
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
