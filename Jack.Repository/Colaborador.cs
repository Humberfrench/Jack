using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Consumer.Data.Basic.Data;
using System.Data;

namespace Jack.Repository
{
    public class Colaborador : BaseData<Model.Colaborador, int>
    {

        public Colaborador() : base()
        {
        }

        #region "Crud"
        /// <summary>
        /// Método para inserir o registro
        /// </summary>
        /// <param name="oTipo">Entidade com os dados Preenchidos</param>
        /// <returns>Boolean. Se a operação foi um sucesso, true.</returns>
        /// <remarks></remarks>
        public override bool Insert(Model.Colaborador oTipo)
        {

            return base.Insert(oTipo);

        }

        /// <summary>
        /// Método para atualizar o registro
        /// </summary>
        /// <param name="oTipo">Entidade com os dados Preenchidos</param>
        /// <returns>Boolean. Se a operação foi um sucesso, true.</returns>
        /// <remarks></remarks>
        public override bool Update(Model.Colaborador oTipo)
        {

            return base.Update(oTipo);

        }

        /// <summary>
        /// Método para excluir o registro
        /// </summary>
        /// <param name="oTipo">Entidade com os dados Preenchidos</param>
        /// <returns>Boolean. Se a operação foi um sucesso, true.</returns>
        /// <remarks></remarks>
        public override bool Delete(Model.Colaborador oTipo)
        {

            return base.Delete(oTipo);

        }

        /// <summary>
        /// Método para procurar um registro
        /// </summary>
        /// <param name="Identifier">Código para a Procura do Valor</param>
        /// <returns>Entidade. Se a operação foi um sucesso, A Entidade Virá preenchida.</returns>
        /// <remarks></remarks>
        public override Model.Colaborador Find(int Identifier)
        {

            return base.Find(Identifier);

        }

        /// <summary>
        /// Método para carregar a lista dos registros
        /// </summary>
        /// <returns>Lista. Se a operação foi um sucesso, a lista virá carregada.</returns>
        /// <remarks></remarks>
        public override IList<Model.Colaborador> LoadAll()
        {

            return base.LoadAll();

        }

        #endregion

        #region "Outros Métodos"

        public IList<Model.Colaborador> ListaQuantidadeSacolasPorColaborador(int intAno)
        {

            Command oCommand = null;
            IList<Model.Colaborador> lstRetorno = null;
            DataTable dtDados = null;
            Model.Colaborador oRetorno = null;

            try
            {
                lstRetorno = new List<Model.Colaborador>();
                oCommand = new Command("CECAMKey");
                oCommand.CommandText = "pr_list_qtde_sacola_colaborador";
                oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                oCommand.Parameters.Add(new Parameter("@nr_ano", DbType.Int32, intAno));
                dtDados = oCommand.GetDataTable();
                foreach (DataRow dr in dtDados.Rows)
                {
                    oRetorno = new Model.Colaborador();
                    oRetorno.Codigo = Convert.ToInt32(dr["id_colaborador"].ToString());
                    oRetorno.Nome = dr["ds_nome"].ToString();
                    oRetorno.TotalSacolas = Convert.ToInt32(dr["tt_sacolas"].ToString());
                    oRetorno.QuantidadeSacolas = Convert.ToInt32(dr["qt_sacolas"].ToString());
                    oRetorno.PercentualSacolas = Convert.ToDouble(dr["pc_sacola"].ToString());
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
