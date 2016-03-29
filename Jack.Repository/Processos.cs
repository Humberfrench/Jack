using Consumer.Data.Basic.Data;
using System;
using System.Collections.Generic;
using System.Data;


namespace Jack.Repository
{
    public class Processos
    {

        #region "Batch - Processos"

        /// <summary>
        /// Processa Presença de Representante na Reunião
        /// </summary>
        /// <param name="intReuniao">Código da Reunião</param>
        /// <returns>Boolean</returns>
        /// <remarks></remarks>
        public bool ProcessaPresencasRepresentantesReuniao(int intReuniao)
        {
            Command oCommand = null;
            IList<Model.Familia> lstRetorno = null;
            bool oRetorno = false;
            try
            {
                lstRetorno = new List<Model.Familia>();
                oCommand = new Command("CECAMKey");
                oCommand.CommandText = "pr_upd_presenca_representado";
                oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                oCommand.Parameters.Add(new Parameter("@id_reuniao", System.Data.DbType.Int32, 75, intReuniao));
                oCommand.ExecuteNonQuery();
                oRetorno = true;
            }
            catch (Exception ex)
            {
                oRetorno = false;
                throw ex;
            }
            finally
            {
                oCommand.Dispose();
                oCommand = null;
            }
            return oRetorno;

        }

        /// <summary>
        /// Atualiza os Dados das Crianças
        /// </summary>
        /// <returns>Boolean</returns>
        /// <remarks></remarks>
        public bool AtualizaDadosCrianca()
        {
            Command oCommand = null;
            bool oRetorno = false;
            try
            {
                oCommand = new Command("CECAMKey");
                oCommand.CommandText = "pr_atualiza_dados_crianca";
                oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                oCommand.ExecuteNonQuery();
                oRetorno = true;
            }
            catch (Exception ex)
            {
                oRetorno = false;
                throw ex;
            }
            finally
            {
                oCommand.Dispose();
                oCommand = null;
            }
            return oRetorno;

        }

        /// <summary>
        /// Atualiza os Dados das Crianças
        /// </summary>
        /// <param name="intCrianca">Código da Criança</param>
        /// <returns>Boolean</returns>
        /// <remarks></remarks>
        public bool AtualizaDadosCrianca(int intCrianca)
        {
            Command oCommand = null;
            bool oRetorno = false;
            try
            {
                oCommand = new Command("CECAMKey");
                oCommand.CommandText = "pr_atualiza_dados_crianca_unitario";
                oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                oCommand.Parameters.Add(new Parameter("@id_crianca", DbType.Int32, intCrianca));
                oCommand.ExecuteNonQuery();
                oRetorno = true;
            }
            catch (Exception ex)
            {
                oRetorno = false;
                throw ex;
            }
            finally
            {
                oCommand.Dispose();
                oCommand = null;
            }
            return oRetorno;

        }

        /// <summary>
        /// Atualiza os Dados das Mães
        /// </summary>
        /// <returns>Boolean</returns>
        /// <remarks></remarks>
        public bool AtualizaDadosMae()
        {
            Command oCommand = null;
            bool oRetorno = false;
            try
            {
                oCommand = new Command("CECAMKey");
                oCommand.CommandText = "[pr_inativa_mae_sem_crianca]";
                oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                oCommand.ExecuteNonQuery();
                oRetorno = true;
            }
            catch (Exception ex)
            {
                oRetorno = false;
                throw ex;
            }
            finally
            {
                oCommand.Dispose();
                oCommand = null;
            }
            return oRetorno;

        }

        public bool ProcesaPresenca(int intAno)
        {
            Command oCommand = null;
            bool oRetorno = false;
            try
            {
                oCommand = new Command("CECAMKey");
                oCommand.CommandText = "[pr_upd_presenca_representado_todos]";
                oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                oCommand.Parameters.Add(new Parameter("@nr_Ano", DbType.Int32, intAno));
                oCommand.ExecuteNonQuery();
                oRetorno = true;
            }
            catch (Exception ex)
            {
                oRetorno = false;
                throw ex;
            }
            finally
            {
                oCommand.Dispose();
                oCommand = null;
            }
            return oRetorno;

        }

        public bool ProcesaGeral(int intAno)
        {
            Command oCommand = null;
            bool oRetorno = false;
            try
            {
                oCommand = new Command("CECAMKey");
                oCommand.CommandText = "[pr_processa_sacola]";
                oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                oCommand.Parameters.Add(new Parameter("@nr_Ano", DbType.Int32, (object)intAno));
                oCommand.Parameters.Add(new Parameter("@is_mostrar_resultado", DbType.String, 1, "N"));
                oCommand.ExecuteNonQuery();
                oRetorno = true;
            }
            catch (Exception ex)
            {
                oRetorno = false;
                throw ex;
            }
            finally
            {
                oCommand.Dispose();
                oCommand = null;
            }
            return oRetorno;

        }


        /// <summary>
        /// Relatório de Inconsistências de Crianças
        /// </summary>
        /// <returns>List(Of Model.CriancasInconsistentes) - Lista de Crianças Inconsistentes</returns>
        /// <remarks></remarks>
        public IList<Model.CriancasInconsistentes> ObterCriancasInconsistentes()
        {

            Command oCommand = null;
            IList<Model.CriancasInconsistentes> lstRetorno = null;
            DataTable dtDados = null;
            Model.CriancasInconsistentes oRetorno = null;

            try
            {
                lstRetorno = new List<Model.CriancasInconsistentes>();
                oCommand = new Command("CECAMKey");
                oCommand.CommandText = "pr_rel_inconsist_criancas";
                oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                dtDados = oCommand.GetDataTable();
                foreach (DataRow dr in dtDados.Rows)
                {
                    oRetorno = new Model.CriancasInconsistentes();
                    oRetorno.Codigo = Convert.ToInt32(dr["id_crianca"].ToString());
                    oRetorno.NomeMae = dr["nm_mae"].ToString();
                    oRetorno.Nome = dr["nm_crianca"].ToString();
                    oRetorno.DescricaoIdade = dr["Idade"].ToString();
                    oRetorno.DescricaoStatus = dr["ds_status"].ToString();
                    oRetorno.DataNascimento = Convert.ToDateTime(dr["dt_nascimento"].ToString());
                    oRetorno.Sexo = dr["ds_sexo"].ToString();
                    oRetorno.Calcado = Convert.ToInt32(dr["nr_calcado"].ToString());
                    oRetorno.Roupa = dr["nr_roupa"].ToString();
                    lstRetorno.Add(oRetorno);
                }

            }
            catch (Exception ex)
            {
                lstRetorno = null;
                throw ex;
            }
            finally
            {
                oCommand.Dispose();
                oRetorno = null;
                dtDados = null;
            }

            return lstRetorno;

        }

        public IList<Model.Familia> ObterFamiliasInconsistentes()
        {

            Command oCommand = null;
            IList<Model.Familia> lstRetorno = null;
            DataTable dtDados = null;
            Model.Familia oRetorno = null;

            try
            {
                lstRetorno = new List<Model.Familia>();
                oCommand = new Command("CECAMKey");
                oCommand.CommandText = "pr_rel_inconsist_familia";
                oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                dtDados = oCommand.GetDataTable();
                foreach (DataRow dr in dtDados.Rows)
                {
                    oRetorno = new Model.Familia();
                    oRetorno.Codigo = Convert.ToInt32(dr["id_familia"].ToString());
                    oRetorno.Nome = dr["nm_mae"].ToString();
                    oRetorno.Nivel = Convert.ToInt32(dr["nr_nivel_espera"].ToString());
                    oRetorno.IsSacolinha = dr["is_sacolinha"].ToString();
                    oRetorno.IsConsistente = dr["is_consistente"].ToString();
                    lstRetorno.Add(oRetorno);
                }

            }
            catch (Exception ex)
            {
                lstRetorno = null;
                throw ex;
            }
            finally
            {
                oCommand.Dispose();
                oRetorno = null;
                dtDados = null;
            }

            return lstRetorno;

        }

        public IList<Model.Familia> ObterFamiliasComZeroCriancas()
        {

            Command oCommand = null;
            IList<Model.Familia> lstRetorno = null;
            DataTable dtDados = null;
            Model.Familia oRetorno = null;

            try
            {
                lstRetorno = new List<Model.Familia>();
                oCommand = new Command("CECAMKey");
                oCommand.CommandText = "pr_rel_familia_crianca_zero";
                oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                dtDados = oCommand.GetDataTable();
                foreach (DataRow dr in dtDados.Rows)
                {
                    oRetorno = new Model.Familia();
                    oRetorno.Codigo = Convert.ToInt32(dr["id_familia"].ToString());
                    oRetorno.Nome = dr["nm_mae"].ToString();
                    oRetorno.Nivel = Convert.ToInt32(dr["nr_nivel_espera"].ToString());
                    oRetorno.IsSacolinha = dr["is_sacolinha"].ToString();
                    oRetorno.IsConsistente = dr["is_consistente"].ToString();
                    lstRetorno.Add(oRetorno);
                }

            }
            catch (Exception ex)
            {
                lstRetorno = null;
                throw ex;
            }
            finally
            {
                oCommand.Dispose();
                oRetorno = null;
                dtDados = null;
            }

            return lstRetorno;

        }

        #endregion

    }
}
