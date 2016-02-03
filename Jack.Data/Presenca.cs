using Consumer.Data.Basic.Data;
using System;
using System.Collections.Generic;
using System.Data;

namespace Jack.Data
{
    public class Presenca : BaseData<Model.Presenca, int>
    {

        public Presenca() : base()
        {
        }

        /// <summary>
        /// Método para inserir o registro
        /// </summary>
        /// <param name="oTipo">Entidade com os dados Preenchidos</param>
        /// <returns>Boolean. Se a operação foi um sucesso, true.</returns>
        /// <remarks></remarks>
        public override bool Insert(Model.Presenca oTipo)
        {

            return base.Insert(oTipo);

        }

        /// <summary>
        /// Método para atualizar o registro
        /// </summary>
        /// <param name="oTipo">Entidade com os dados Preenchidos</param>
        /// <returns>Boolean. Se a operação foi um sucesso, true.</returns>
        /// <remarks></remarks>
        public override bool Update(Model.Presenca oTipo)
        {

            return base.Update(oTipo);

        }

        /// <summary>
        /// Método para excluir o registro
        /// </summary>
        /// <param name="oTipo">Entidade com os dados Preenchidos</param>
        /// <returns>Boolean. Se a operação foi um sucesso, true.</returns>
        /// <remarks></remarks>
        public override bool Delete(Model.Presenca oTipo)
        {

            return base.Delete(oTipo);

        }

        /// <summary>
        /// Método para procurar um registro
        /// </summary>
        /// <param name="Identifier">Código para a Procura do Valor</param>
        /// <returns>Entidade. Se a operação foi um sucesso, A Entidade Virá preenchida.</returns>
        /// <remarks></remarks>
        public override Model.Presenca Find(int Identifier)
        {

            return base.Find(Identifier);

        }

        /// <summary>
        /// Método para carregar a lista dos registros
        /// </summary>
        /// <returns>Lista. Se a operação foi um sucesso, a lista virá carregada.</returns>
        /// <remarks></remarks>
        public override IList<Model.Presenca> LoadAll()
        {

            return base.LoadAll();

        }

        /// <summary>
        /// Método para carregar a lista dos registros
        /// </summary>
        /// <returns>Lista. Se a operação foi um sucesso, a lista virá carregada.</returns>
        /// <remarks></remarks>
        public IList<Model.Familia> Load(int intReuniao)
        {

            Command oCommand = null;
            IList<Model.Familia> lstRetorno = null;
            DataTable dtDados = null;
            Model.Familia objDados = null;
            try
            {
                lstRetorno = new List<Model.Familia>();
                oCommand = new Command("CECAMKey");
                oCommand.CommandText = "pr_lista_maes_reuniao";
                oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                oCommand.Parameters.Add(new Parameter("@id_reuniao", System.Data.DbType.Int32, 75, intReuniao));
                dtDados = oCommand.GetDataTable();
                foreach (DataRow dr in dtDados.Rows)
                {
                    objDados = new Model.Familia();
                    objDados.Codigo = Convert.ToInt32(dr["id_familia"].ToString());
                    objDados.Nome = dr["nm_mae"].ToString();
                    objDados.IsSacolinha = dr["is_sacolinha"].ToString();
                    objDados.IsConsistente = dr["is_consistente"].ToString();
                    objDados.Status = new Model.Status(Convert.ToInt32(dr["id_status"]), dr["ds_status"].ToString());
                    lstRetorno.Add(objDados);
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
                objDados = null;
                dtDados = null;
            }
            return lstRetorno;

        }

        public List<Model.FamiliaPresenca> ObterPresencaPorMae(int intFamilia, int intAno)
        {
            Command oDados = null;
            List<Model.FamiliaPresenca> lstDados = null;
            Model.FamiliaPresenca objDados = null;
            DataTable dtDados = null;

            try
            {
                oDados = new Command("CECAMKey");
                dtDados = new DataTable();

                oDados.CommandText = "pr_rel_resenca_reuniao_mae";
                oDados.CommandType = CommandType.StoredProcedure;

                oDados.Parameters.Add(new Parameter("@id_familia", DbType.Int32, intFamilia));
                oDados.Parameters.Add(new Parameter("@ano_corrente", DbType.Int32, intAno));
                dtDados = oDados.GetDataTable();

                //fa.nm_mae, fa.nr_nivel_espera, ra.dt_reuniao

                lstDados = new List<Model.FamiliaPresenca>();

                foreach (DataRow dr in dtDados.Rows)
                {
                    objDados = new Model.FamiliaPresenca();
                    objDados.Familia = dr["nm_mae"].ToString();
                    objDados.Nivel = Convert.ToInt32(dr["nr_nivel_espera"]);
                    objDados.Data = Convert.ToDateTime(dr["dt_reuniao"]);
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
