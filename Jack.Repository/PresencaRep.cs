using Consumer.Data.Basic.Data;
using Jack.DTO;
using Jack.Model;
using Jack.Model.Enum;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Jack.Repository
{
    public class PresencaRep : Repository<Model.Presenca>, IPresencaRep
    {

        private IUnitWork UnitWork;
        public PresencaRep(IUnitWork unitWork) : base(unitWork)
        {
            UnitWork = unitWork;
        }


        /// <summary>
        /// Método para inserir o registro
        /// </summary>
        /// <param name="oTipo">Entidade com os dados Preenchidos</param>
        /// <returns>Boolean. Se a operação foi um sucesso, true.</returns>
        /// <remarks></remarks>
        public bool Insert(Model.Presenca oTipo)
        {

            UnitWork.Salvar(oTipo);
            return true;

        }

        /// <summary>
        /// Método para atualizar o registro
        /// </summary>
        /// <param name="oTipo">Entidade com os dados Preenchidos</param>
        /// <returns>Boolean. Se a operação foi um sucesso, true.</returns>
        /// <remarks></remarks>
        public bool Update(Model.Presenca oTipo)
        {

            UnitWork.Salvar(oTipo);
            return true;

        }

        /// <summary>
        /// Método para excluir o registro
        /// </summary>
        /// <param name="oTipo">Entidade com os dados Preenchidos</param>
        /// <returns>Boolean. Se a operação foi um sucesso, true.</returns>
        /// <remarks></remarks>
        public bool Delete(Model.Presenca oTipo)
        {

            UnitWork.Excluir(oTipo);
            return true;

        }

        /// <summary>
        /// Método para procurar um registro
        /// </summary>
        /// <param name="Identifier">Código para a Procura do Valor</param>
        /// <returns>Entidade. Se a operação foi um sucesso, A Entidade Virá preenchida.</returns>
        /// <remarks></remarks>
        public Model.Presenca Find(int Identifier)
        {

            return GetById(Identifier);

        }

        /// <summary>
        /// Método para carregar a lista dos registros
        /// </summary>
        /// <returns>Lista. Se a operação foi um sucesso, a lista virá carregada.</returns>
        /// <remarks></remarks>
        public IList<Model.Presenca> LoadAll()
        {

            return GetAll().ToList();

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
                    objDados.Status = new Status(Convert.ToInt32(dr["id_status"]), dr["ds_status"].ToString());
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

        public IList<FamiliaPresenca> ObterPresencaPorMae(int intFamilia, int intAno)
        {
            Command oDados = null;
            List<FamiliaPresenca> lstDados = null;
            FamiliaPresenca objDados = null;
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

                lstDados = new List<FamiliaPresenca>();

                foreach (DataRow dr in dtDados.Rows)
                {
                    objDados = new FamiliaPresenca();
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
