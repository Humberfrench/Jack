using Consumer.Data.Basic.Data;
using Jack.DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace Jack.Repository
{
    public class RepFamiliaCrianca
    {

        public RepFamiliaCrianca() : base()
        {
        }

        /// <summary>
        /// Método para inserir o registro
        /// </summary>
        /// <param name="intCrianca">Criança</param>
        /// <param name="intFamilia">Familia</param>
        /// <returns>Boolean. Se a operação foi um sucesso, true.</returns>
        /// <remarks></remarks>
        public bool Insert(int intFamilia, int intCrianca)
        {
            Command oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Command("CECAMKey");

                oDados.CommandText = "pr_AddCriancasFamilia";
                oDados.CommandType = CommandType.StoredProcedure;

                oDados.Parameters.Add(new Parameter("@id_familia", DbType.Int32, intFamilia));
                oDados.Parameters.Add(new Parameter("@id_crianca", DbType.Int32, intCrianca));
                oDados.Execute();
                blnRetorno = true;

            }
            catch (Exception ex)
            {
                blnRetorno = false;
                throw ex;
            }
            finally
            {
                oDados.Dispose();
                oDados = null;
            }

            return blnRetorno;

        }


        /// <summary>
        /// Método para excluir o registro
        /// </summary>
        /// <param name="intFamilia">Familia</param>
        /// <returns>Boolean. Se a operação foi um sucesso, true.</returns>
        /// <remarks></remarks>
        public bool DeleteFamilia(int intFamilia)
        {
            Command oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Command("CECAMKey");

                oDados.CommandText = "pr_DeleteAllCriancasFamilia";
                oDados.CommandType = CommandType.StoredProcedure;

                oDados.Parameters.Add(new Parameter("@id_familia", DbType.Int32, intFamilia));
                oDados.Execute();
                blnRetorno = true;

            }
            catch (Exception ex)
            {
                blnRetorno = false;
                throw ex;
            }
            finally
            {
                oDados.Dispose();
                oDados = null;
            }

            return blnRetorno;

        }


        /// <summary>
        /// Método para excluir o registro
        /// </summary>
        /// <param name="intFamilia">Familia</param>
        /// <param name="intCrianca">Criança</param>
        /// <returns>Boolean. Se a operação foi um sucesso, true.</returns>
        /// <remarks></remarks>
        public bool DeleteCrianca(int intFamilia, int intCrianca)
        {
            Command oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Command("CECAMKey");

                oDados.CommandText = "pr_DeleteCriancasFamilia";
                oDados.CommandType = CommandType.StoredProcedure;

                oDados.Parameters.Add(new Parameter("@id_familia", DbType.Int32, intFamilia));
                oDados.Parameters.Add(new Parameter("@id_crianca", DbType.Int32, intCrianca));
                oDados.Execute();
                blnRetorno = true;

            }
            catch (Exception ex)
            {
                blnRetorno = false;
                throw ex;
            }
            finally
            {
                oDados.Dispose();
                oDados = null;
            }

            return blnRetorno;

        }

        public List<DTOCrianca> ObterCriancasByFamilia(int intFamilia)
        {

            Command oDados = null;
            List<DTOCrianca> lstDados = null;
            DTOCrianca objDados = null;
            DataTable dtDados = null;
            try
            {
                oDados = new Command("CECAMKey");
                dtDados = new DataTable();

                oDados.CommandText = "pr_ObterCriancasFamilia";
                oDados.CommandType = CommandType.StoredProcedure;

                oDados.Parameters.Add(new Parameter("@id_familia", DbType.Int32, intFamilia));
                dtDados = oDados.GetDataTable();


                lstDados = new List<DTOCrianca>();

                foreach (DataRow dr in dtDados.Rows)
                {
                    objDados = new DTOCrianca();
                    objDados.Codigo = Convert.ToInt32(dr["id_crianca"]);
                    objDados.Nome = dr["nm_crianca"].ToString();
                    objDados.Idade = Convert.ToInt32(dr["nr_idade"]);
                    objDados.MedidaIdade = dr["ds_medida_idade"].ToString();
                    objDados.DataNascimento = Convert.ToDateTime(dr["dt_nascimento"]);
                    objDados.Sexo = dr["ds_sexo"].ToString();
                    objDados.Calcado = Convert.ToInt32(dr["nr_calcado"]);
                    objDados.Roupa = dr["nr_roupa"].ToString();
                    objDados.CodigoKit = Convert.ToInt32(dr["id_kit"]);
                    objDados.Kit = dr["ds_kit"].ToString();
                    objDados.CodigoStatus = Convert.ToInt32(dr["id_status"]);
                    objDados.Status = dr["ds_status"].ToString();
                    objDados.IsSacolinha = dr["is_sacolinha"].ToString();
                    objDados.IsConsistente = dr["is_consistente"].ToString();
                    objDados.IsMoralCrista = dr["is_moral_crista"].ToString();
                    objDados.IsCriancaMaior = dr["is_crianca_maior"].ToString();
                    objDados.IsNecessidadeEspecial = dr["is_necessidade_especial"].ToString();
                    objDados.IdadeNominalReduzida = dr["ds_idade_nominal_resumido"].ToString();
                    objDados.IdadeNominal = dr["ds_idade_nominal"].ToString();
                    objDados.DataCriacao = Convert.ToDateTime(dr["dt_create"].ToString());
                    objDados.DataAtualizacao = Convert.ToDateTime(dr["dt_update"].ToString());
                    lstDados.Add(objDados);
                }
            }
            catch (Exception ex)
            {
                lstDados = null;
                throw ex;
            }
            finally
            {
                objDados = null;
                dtDados = null;
                oDados.Dispose();
                oDados = null;
            }

            return lstDados;

        }

        public List<DTOCriancaRepresentante> ObterCriancasByFamiliaWithRep(int intFamilia)
        {

            Command oDados = null;
            List<DTOCriancaRepresentante> lstDados = null;
            DTOCriancaRepresentante objDados = null;
            DataTable dtDados = null;

            try
            {
                oDados = new Command("CECAMKey");
                dtDados = new DataTable();

                oDados.CommandText = "pr_ObterCriancasFamiliarep";
                oDados.CommandType = CommandType.StoredProcedure;

                oDados.Parameters.Add(new Parameter("@id_familia", DbType.Int32, intFamilia));
                dtDados = oDados.GetDataTable();


                lstDados = new List<DTOCriancaRepresentante>();

                foreach (DataRow dr in dtDados.Rows)
                {
                    objDados = new DTOCriancaRepresentante();
                    objDados.Codigo = Convert.ToInt32(dr["id_crianca"]);
                    objDados.Nome = dr["nm_crianca"].ToString();
                    objDados.Idade = Convert.ToInt32(dr["nr_idade"]);
                    objDados.MedidaIdade = dr["ds_medida_idade"].ToString();
                    objDados.DataNascimento = Convert.ToDateTime(dr["dt_nascimento"]);
                    objDados.Sexo = dr["ds_sexo"].ToString();
                    objDados.Calcado = Convert.ToInt32(dr["nr_calcado"]);
                    objDados.Roupa = dr["nr_roupa"].ToString();
                    objDados.CodigoKit = Convert.ToInt32(dr["id_kit"]);
                    objDados.Kit = dr["ds_kit"].ToString();
                    objDados.CodigoStatus = Convert.ToInt32(dr["id_status"]);
                    objDados.Status = dr["ds_status"].ToString();
                    objDados.IsSacolinha = dr["is_sacolinha"].ToString();
                    objDados.IsConsistente = dr["is_consistente"].ToString();
                    objDados.IsMoralCrista = dr["is_moral_crista"].ToString();
                    objDados.IsCriancaMaior = dr["is_crianca_maior"].ToString();
                    objDados.IsNecessidadeEspecial = dr["is_necessidade_especial"].ToString();
                    objDados.IdadeNominalReduzida = dr["ds_idade_nominal_resumido"].ToString();
                    objDados.IdadeNominal = dr["ds_idade_nominal"].ToString();
                    objDados.DataCriacao = Convert.ToDateTime(dr["dt_create"].ToString());
                    objDados.DataAtualizacao = Convert.ToDateTime(dr["dt_update"].ToString());
                    objDados.Familia = dr["nm_mae"].ToString();
                    objDados.FamiliaCodigo = Convert.ToInt32(dr["id_familia"].ToString());
                    lstDados.Add(objDados);
                }
            }
            catch (Exception ex)
            {
                lstDados = null;
                throw ex;
            }
            finally
            {
                objDados = null;
                dtDados = null;
                oDados.Dispose();
                oDados = null;
            }

            return lstDados;

        }

    }
}
