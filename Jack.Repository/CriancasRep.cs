using Consumer.Data.Basic.Data;
using System;
using System.Collections.Generic;
using System.Data;

namespace Jack.Repository
{
    public class CriancasRep : BaseData<Model.Criancas, int>
    {

        public CriancasRep() : base()
        {
        }

        /// <summary>
        /// Método para inserir o registro
        /// </summary>
        /// <param name="oTipo">Entidade com os dados Preenchidos</param>
        /// <returns>Boolean. Se a operação foi um sucesso, true.</returns>
        /// <remarks></remarks>
        public override bool Insert(Model.Criancas oTipo)
        {

            return base.Insert(oTipo);

        }

        /// <summary>
        /// Método para atualizar o registro
        /// </summary>
        /// <param name="oTipo">Entidade com os dados Preenchidos</param>
        /// <returns>Boolean. Se a operação foi um sucesso, true.</returns>
        /// <remarks></remarks>
        public override bool Update(Model.Criancas oTipo)
        {

            return base.Update(oTipo);

        }

        /// <summary>
        /// Método para excluir o registro
        /// </summary>
        /// <param name="oTipo">Entidade com os dados Preenchidos</param>
        /// <returns>Boolean. Se a operação foi um sucesso, true.</returns>
        /// <remarks></remarks>
        public override bool Delete(Model.Criancas oTipo)
        {

            return base.Delete(oTipo);

        }

        /// <summary>
        /// Método para procurar um registro
        /// </summary>
        /// <param name="Identifier">Código para a Procura do Valor</param>
        /// <returns>Entidade. Se a operação foi um sucesso, A Entidade Virá preenchida.</returns>
        /// <remarks></remarks>
        public override Model.Criancas Find(int Identifier)
        {

            return base.Find(Identifier);

        }

        /// <summary>
        /// Método para carregar a lista dos registros
        /// </summary>
        /// <returns>Lista. Se a operação foi um sucesso, a lista virá carregada.</returns>
        /// <remarks></remarks>
        public override IList<Model.Criancas> LoadAll()
        {

            return base.LoadAll();

        }
        public Model.Criancas ObterDados(int intIdade, string strMedidaIdade, string strSexo, bool blnIsNecessidadeEspecial)
        {

            Command oDados = null;
            Model.Criancas oCrianca = default(Model.Criancas);
            DataTable dtDados = null;

            try
            {
                oDados = new Command("CECAMKey");

                oDados.CommandText = "pr_obter_dados_gerais_crianca";
                oDados.CommandType = CommandType.StoredProcedure;

                oDados.Parameters.Add(new Parameter("@nr_idade", DbType.Int32, intIdade));
                oDados.Parameters.Add(new Parameter("@ds_medida_idade", DbType.String, 1, strMedidaIdade));
                oDados.Parameters.Add(new Parameter("@ds_sexo", DbType.String, 1, strSexo));
                if (blnIsNecessidadeEspecial)
                {
                    oDados.Parameters.Add(new Parameter("@is_necessidade_especial", DbType.String, 1, "S"));
                }

                dtDados = oDados.GetDataTable();

                oCrianca = new Model.Criancas();
                oCrianca.Idade = intIdade;
                oCrianca.MedidaIdade = strMedidaIdade;
                oCrianca.Sexo = strSexo;
                oCrianca.IsNecessidadeEspecial = (blnIsNecessidadeEspecial ? "S" : "N");
                if (dtDados.Rows.Count >= 1)
                {
                    oCrianca.Roupa = dtDados.Rows[0]["nr_roupa"].ToString();
                    oCrianca.Calcado = Convert.ToInt16(dtDados.Rows[0]["nr_calcado"].ToString());
                    oCrianca.Kit = new Model.Kit(Convert.ToInt16(dtDados.Rows[0]["id_kit"].ToString()));
                }
                else {
                    oCrianca.Roupa = "99";
                    oCrianca.Calcado = 99;
                    oCrianca.Kit = new Model.Kit(0);
                }

            }
            catch (Exception ex)
            {
                oCrianca = null;
                throw ex;
            }
            finally
            {
                dtDados = null;
                oDados.Dispose();
                oDados = null;
            }

            return oCrianca;

        }
        public Model.Criancas ObterDadosVestuario(int intIdade, string strMedidaIdade, string strSexo)
        {

            Command oDados = null;
            Model.Criancas oCrianca = default(Model.Criancas);
            DataTable dtDados = null;

            try
            {
                oDados = new Command("CECAMKey");

                oDados.CommandText = "pr_obter_dados_vestuario";
                oDados.CommandType = CommandType.StoredProcedure;

                oDados.Parameters.Add(new Parameter("@nr_idade", DbType.Int32, intIdade));
                oDados.Parameters.Add(new Parameter("@ds_medida_idade", DbType.String, 1, strMedidaIdade));
                oDados.Parameters.Add(new Parameter("@ds_sexo", DbType.String, 1, strSexo));

                dtDados = oDados.GetDataTable();

                oCrianca = new Model.Criancas();
                oCrianca.Idade = intIdade;
                oCrianca.Sexo = strSexo;
                if (dtDados.Rows.Count >= 1)
                {
                    oCrianca.Roupa = dtDados.Rows[0]["nr_roupa"].ToString();
                    oCrianca.Calcado = Convert.ToInt16(dtDados.Rows[0]["nr_calcado"].ToString());
                }
                else {
                    oCrianca.Roupa = "99";
                    oCrianca.Calcado = 99;
                }

            }
            catch (Exception ex)
            {
                oCrianca = null;
                throw ex;
            }
            finally
            {
                dtDados = null;
                oDados.Dispose();
                oDados = null;
            }

            return oCrianca;

        }

        public IList<Model.Criancas> ObterSacolasMae(int intMae)
        {

            Command oDados = null;
            Model.Criancas objDados = null;
            List<Model.Criancas> lCrianca = null;
            DataTable dtDados = null;

            try
            {
                oDados = new Command("CECAMKey");

                oDados.CommandText = "pr_obter_criancas_sacola";
                oDados.CommandType = CommandType.StoredProcedure;

                oDados.Parameters.Add(new Parameter("@id_familia", DbType.Int32, intMae));

                dtDados = oDados.GetDataTable();

                objDados = new Model.Criancas();
                lCrianca = new List<Model.Criancas>();
                if (dtDados.Rows.Count >= 1)
                {
                    foreach (DataRow drDados in dtDados.Rows)
                    {
                        objDados = new Model.Criancas();
                        objDados.Codigo = Convert.ToInt16(drDados["id_crianca"].ToString());
                        objDados.Nome = drDados["nm_crianca"].ToString();
                        objDados.FamiliaCodigo = Convert.ToInt16(drDados["id_familia"].ToString());
                        objDados.NomeFamilia = drDados["nm_familia"].ToString();
                        objDados.FamiliaRepresentanteCodigo = Convert.ToInt16(drDados["id_familia_rep"].ToString());
                        objDados.FamiliaRepresentante = drDados["nm_familia_rep"].ToString();
                        objDados.Idade = Convert.ToInt16(drDados["nr_idade"].ToString());
                        objDados.MedidaIdade = drDados["ds_medida_idade"].ToString();
                        objDados.Roupa = drDados["nr_roupa"].ToString();
                        objDados.Calcado = Convert.ToInt16(drDados["nr_calcado"].ToString());
                        objDados.Status = new Model.Status(Convert.ToInt32(drDados["id_status"]), drDados["ds_status"].ToString());
                        objDados.IsSacolinha = drDados["is_sacolinha"].ToString();
                        lCrianca.Add(objDados);
                    }
                }

            }
            catch (Exception ex)
            {
                lCrianca = null;
                throw ex;
            }
            finally
            {
                objDados = null;
                dtDados = null;
                oDados.Dispose();
                oDados = null;
            }

            return lCrianca;

        }


        /// <summary>
        /// Atualiza os Dados das Crianças
        /// </summary>
        /// <param name="intCrianca">Código da Criança</param>
        /// <param name="intCalcado">Número do Calçado</param>
        /// <param name="strRoupa">Número da Roupa</param>
        /// <returns>Boolean</returns>
        /// <remarks></remarks>
        public bool AtualizaDadosCrianca(int intCrianca, int intCalcado, string strRoupa)
        {
            Command oCommand = null;
            bool oRetorno = false;
            try
            {
                oCommand = new Command("CECAMKey");
                oCommand.CommandText = "pr_atualiza_vestimenta_crianca";
                oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                oCommand.Parameters.Add(new Parameter("@id_crianca", DbType.Int32, intCrianca));
                oCommand.Parameters.Add(new Parameter("@nr_calcado", DbType.Int32, intCalcado));
                oCommand.Parameters.Add(new Parameter("@nr_roupa", DbType.String, 5, strRoupa));
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

    }
}
