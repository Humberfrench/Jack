using Consumer.Data.Basic.Data;
using System;
using System.Collections.Generic;
using System.Data;

namespace Jack.Repository
{
    public class ColaboradorCrianca : BaseData<Model.ColaboradorCrianca, int>
    {

        public ColaboradorCrianca() : base()
        {
        }

        #region "Crud"

        /// <summary>
        /// Método para inserir o registro
        /// </summary>
        /// <param name="oTipo">Entidade com os dados Preenchidos</param>
        /// <returns>Boolean. Se a operação foi um sucesso, true.</returns>
        /// <remarks></remarks>
        public override bool Insert(Model.ColaboradorCrianca oTipo)
        {

            return base.Insert(oTipo);

        }

        /// <summary>
        /// Método para atualizar o registro
        /// </summary>
        /// <param name="oTipo">Entidade com os dados Preenchidos</param>
        /// <returns>Boolean. Se a operação foi um sucesso, true.</returns>
        /// <remarks></remarks>
        public override bool Update(Model.ColaboradorCrianca oTipo)
        {

            return base.Update(oTipo);

        }

        /// <summary>
        /// Método para excluir o registro
        /// </summary>
        /// <param name="oTipo">Entidade com os dados Preenchidos</param>
        /// <returns>Boolean. Se a operação foi um sucesso, true.</returns>
        /// <remarks></remarks>
        public override bool Delete(Model.ColaboradorCrianca oTipo)
        {

            return base.Delete(oTipo);

        }

        /// <summary>
        /// Método para procurar um registro
        /// </summary>
        /// <param name="Identifier">Código para a Procura do Valor</param>
        /// <returns>Entidade. Se a operação foi um sucesso, A Entidade Virá preenchida.</returns>
        /// <remarks></remarks>
        public override Model.ColaboradorCrianca Find(int Identifier)
        {

            return base.Find(Identifier);

        }

        /// <summary>
        /// Método para carregar a lista dos registros
        /// </summary>
        /// <returns>Lista. Se a operação foi um sucesso, a lista virá carregada.</returns>
        /// <remarks></remarks>
        public override IList<Model.ColaboradorCrianca> LoadAll()
        {

            return base.LoadAll();

        }

        #endregion

        #region "Outros"

        /// <summary>
        /// Lista Todas as Crianças que tem sacolinhas na mão de um colaborador
        /// </summary>
        /// <param name="intColaborador">Código do Colaborador</param>
        /// <returns>List(Of Model.ColaboradorCrianca) - Lista de Criancas por Colaborador </returns>
        /// <remarks></remarks>
        public IList<Model.ColaboradorCrianca> ObterCriancasPorColaborador(int intColaborador, int intAno)
        {

            Command oCommand = null;
            IList<Model.ColaboradorCrianca> lstRetorno = null;
            DataTable dtDados = null;
            Model.ColaboradorCrianca oRetorno = null;

            try
            {
                lstRetorno = new List<Model.ColaboradorCrianca>();
                oCommand = new Command("CECAMKey");
                oCommand.CommandText = "pr_list_sacola_colaborador";
                oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                oCommand.Parameters.Add(new Parameter("@id_colaborador", DbType.Int32, intColaborador));
                oCommand.Parameters.Add(new Parameter("@nr_ano", DbType.Int32, intAno));
                dtDados = oCommand.GetDataTable();
                foreach (DataRow dr in dtDados.Rows)
                {
                    oRetorno = new Model.ColaboradorCrianca();
                    oRetorno.Codigo = Convert.ToInt16(dr["id_colaborador_crianca"].ToString());
                    oRetorno.Colaborador.Codigo = intColaborador;
                    oRetorno.Crianca.Codigo = Convert.ToInt32(dr["id_crianca"].ToString());
                    oRetorno.NomeCrianca = dr["nm_crianca"].ToString();
                    oRetorno.NomeColaborador = dr["ds_nome"].ToString();
                    oRetorno.IsDevolvida = dr["is_devolvida"].ToString();
                    oRetorno.NumeroSacola =Convert.ToInt16(dr["id_sacolinha"].ToString());
                    oRetorno.NumeroIdade = Convert.ToInt16(dr["nr_idade"].ToString());
                    oRetorno.MedidaIdade = dr["ds_medida_idade"].ToString();
                    oRetorno.Roupa = dr["nr_roupa"].ToString();
                    oRetorno.Calcado = Convert.ToInt16(dr["nr_calcado"].ToString());
                    oRetorno.Ano = Convert.ToInt16(dr["nr_ano"].ToString());
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
