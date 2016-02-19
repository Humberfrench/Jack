using Consumer.Data.Basic.Data;
using System;
using System.Collections.Generic;
using System.Data;

namespace Jack.Data
{
    public class FamiliaCrianca
    {

        public FamiliaCrianca() : base()
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

        public List<Model.Criancas> ObterCriancasByFamilia(int intFamilia)
        {

            Command oDados = null;
            List<Model.Criancas> lstDados = null;
            Model.Criancas objDados = null;
            DataTable dtDados = null;

            try
            {
                oDados = new Command("CECAMKey");
                dtDados = new DataTable();

                oDados.CommandText = "pr_ObterCriancasFamilia";
                oDados.CommandType = CommandType.StoredProcedure;

                oDados.Parameters.Add(new Parameter("@id_familia", DbType.Int32, intFamilia));
                dtDados = oDados.GetDataTable();


                lstDados = new List<Model.Criancas>();

                foreach (DataRow dr in dtDados.Rows)
                {
                    objDados = new Model.Criancas();
                    objDados.Codigo = Convert.ToInt32(dr["id_crianca"]);
                    objDados.Nome = dr["nm_crianca"].ToString();
                    objDados.Idade = Convert.ToInt32(dr["nr_idade"]);
                    objDados.MedidaIdade = dr["ds_medida_idade"].ToString();
                    objDados.DataNascimento = Convert.ToDateTime(dr["dt_nascimento"]);
                    objDados.Sexo = dr["ds_sexo"].ToString();
                    objDados.Calcado = Convert.ToInt32(dr["nr_calcado"]);
                    objDados.Roupa = dr["nr_roupa"].ToString();
                    objDados.Kit = new Model.Kit(Convert.ToInt32(dr["id_kit"]));
                    objDados.IsSacolinha = dr["is_sacolinha"].ToString();
                    objDados.IsConsistente = dr["is_consistente"].ToString();
                    objDados.IsMoralCrista = dr["is_moral_crista"].ToString();
                    objDados.Status = new Model.Status(Convert.ToInt32(dr["id_status"]), dr["ds_status"].ToString());
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

        public List<Model.Criancas> ObterCriancasByFamiliaWithRep(int intFamilia)
        {

            Command oDados = null;
            List<Model.Criancas> lstDados = null;
            Model.Criancas objDados = null;
            DataTable dtDados = null;

            try
            {
                oDados = new Command("CECAMKey");
                dtDados = new DataTable();

                oDados.CommandText = "pr_ObterCriancasFamiliarep";
                oDados.CommandType = CommandType.StoredProcedure;

                oDados.Parameters.Add(new Parameter("@id_familia", DbType.Int32, intFamilia));
                dtDados = oDados.GetDataTable();


                lstDados = new List<Model.Criancas>();

                foreach (DataRow dr in dtDados.Rows)
                {
                    objDados = new Model.Criancas();
                    objDados.Codigo = Convert.ToInt32(dr["id_crianca"]);
                    objDados.Nome = dr["nm_crianca"].ToString();
                    objDados.Idade = Convert.ToInt32(dr["nr_idade"]);
                    objDados.MedidaIdade = dr["ds_medida_idade"].ToString();
                    objDados.DataNascimento = Convert.ToDateTime(dr["dt_nascimento"]);
                    objDados.Sexo = dr["ds_sexo"].ToString();
                    objDados.Calcado = Convert.ToInt32(dr["nr_calcado"]);
                    objDados.Roupa = dr["nr_roupa"].ToString();
                    objDados.CalcadoPadrao = Convert.ToInt32(dr["nr_calcado_padrao"]);
                    objDados.RoupaPadrao = dr["nr_roupa_padrao"].ToString();
                    objDados.Kit = new Model.Kit(Convert.ToInt32(dr["id_kit"]));
                    objDados.IsSacolinha = dr["is_sacolinha"].ToString();
                    objDados.IsConsistente = dr["is_consistente"].ToString();
                    objDados.IsMoralCrista = dr["is_moral_crista"].ToString();
                    objDados.Status = new Model.Status(Convert.ToInt32(dr["id_status"]), dr["ds_status"].ToString());
                    objDados.NomeFamilia = dr["nm_mae"].ToString();
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
