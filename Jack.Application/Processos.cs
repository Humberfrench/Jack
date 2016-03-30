using Jack.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Jack.Application
{
    public class Processos
    {

        /// <summary>
        /// Processa os representantes da Reunião, a presença.
        /// </summary>
        /// <param name="strPresenca">Lista de Pessoas para registrar</param>
        /// <returns>Boolean</returns>
        /// <remarks></remarks>
        public bool ProcessaPresencasRepresentantesReuniao(string strPresenca)
        {

            Repository.Processos oDados = null;
            bool blnRetorno = false;
            int intReuniao = 0;
            string[] aStrPresenca = strPresenca.Split(',');

            try
            {
                oDados = new Repository.Processos();
                for (int intCont = 0; intCont <= (aStrPresenca.Length - 1); intCont++)
                {
                    if (!string.IsNullOrEmpty(aStrPresenca[intCont].Trim()))
                    {
                        intReuniao = Convert.ToInt32(aStrPresenca[intCont]);
                    }
                    blnRetorno = oDados.ProcessaPresencasRepresentantesReuniao(intReuniao);
                }

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

        /// <summary>
        /// Processa os representantes da Reunião, a presença.
        /// </summary>
        /// <param name="intReuniao">Pessoas para registrar</param>
        /// <returns>Boolean</returns>
        /// <remarks></remarks>
        public bool ProcessaPresencasRepresentantesReuniao(int intReuniao)
        {

            Repository.Processos oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Repository.Processos();
                blnRetorno = oDados.ProcessaPresencasRepresentantesReuniao(intReuniao);
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

        public bool ProcesaPresenca(int intAno)
        {
            Repository.Processos oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Repository.Processos();
                blnRetorno = oDados.ProcesaPresenca(intAno);
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

        public bool ProcesaGeral(int intAno)
        {
            Repository.Processos oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Repository.Processos();
                blnRetorno = oDados.ProcesaGeral(intAno);
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


        /// <summary>
        /// Roda processo de Atualizar Dadosa de Crianças
        /// </summary>
        /// <param name="intCrianca">Código da Criança</param>
        /// <returns>Boolean</returns>
        /// <remarks></remarks>
        public bool AtualizaDadosCrianca(int intCrianca)
        {

            Repository.Processos oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Repository.Processos();
                blnRetorno = oDados.AtualizaDadosCrianca(intCrianca);
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


        /// <summary>
        /// Roda processo de Atualizar Dadosa de Crianças
        /// </summary>
        /// <returns>Boolean</returns>
        /// <remarks></remarks>
        public bool AtualizaDadosCrianca()
        {

            Repository.Processos oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Repository.Processos();
                blnRetorno = oDados.AtualizaDadosCrianca();
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

        /// <summary>
        /// Roda processo de Atualizar Dadosa de Mães
        /// </summary>
        /// <returns>Boolean</returns>
        /// <remarks></remarks>
        public bool AtualizaDadosMae()
        {

            Repository.Processos oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Repository.Processos();
                blnRetorno = oDados.AtualizaDadosMae();
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
        /// <summary>
        /// Obter lista de crianças inconsistentes
        /// </summary>
        /// <returns>Objeto com a lista de Valores Tipo: List(Of Model.CriancasInconsistentes)</returns>
        /// <remarks></remarks>
        public IList<CriancasInconsistentes> ObterCriancasInconsistentes()
        {

            Repository.Processos oDados = null;
            IList<CriancasInconsistentes> lstRetorno = null;

            try
            {
                oDados = new Repository.Processos();
                lstRetorno = oDados.ObterCriancasInconsistentes();
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

        /// <summary>
        /// Obter Nome das mães sem crianças
        /// </summary>
        /// <returns>Objeto com a lista de Valores Tipo: List(Of Model.Familia)</returns>
        /// <remarks></remarks>
        public IList<Model.Familia> ObterFamiliasComZeroCriancas()
        {

            Repository.Processos oDados = null;
            IList<Model.Familia> lstRetorno = null;

            try
            {
                oDados = new Repository.Processos();
                lstRetorno = oDados.ObterFamiliasComZeroCriancas();
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

        /// <summary>
        /// Obter Lista de Familias Inconsistentes
        /// </summary>
        /// <returns>Objeto com a lista de Valores Tipo: List(Of Model.Familia)</returns>
        /// <remarks></remarks>
        public IList<Model.Familia> ObterFamiliasInconsistentes()
        {

            Repository.Processos oDados = null;
            IList<Model.Familia> lstRetorno = null;

            try
            {
                oDados = new Repository.Processos();
                lstRetorno = oDados.ObterFamiliasInconsistentes();
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
