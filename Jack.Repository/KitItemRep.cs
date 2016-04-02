using Consumer.Data.Basic.Data;
using System;
using System.Collections.Generic;
using System.Data;

namespace Jack.Repository
{
    public class KitItemRep : BaseData<Model.KitItem, int>
    {

        public KitItemRep() : base()
        {
        }

        /// <summary>
        /// Método para inserir o registro
        /// </summary>
        /// <param name="oTipo">Entidade com os dados Preenchidos</param>
        /// <returns>Boolean. Se a operação foi um sucesso, true.</returns>
        /// <remarks></remarks>
        public override bool Insert(Model.KitItem oTipo)
        {

            return base.Insert(oTipo);

        }

        /// <summary>
        /// Método para atualizar o registro
        /// </summary>
        /// <param name="oTipo">Entidade com os dados Preenchidos</param>
        /// <returns>Boolean. Se a operação foi um sucesso, true.</returns>
        /// <remarks></remarks>
        public override bool Update(Model.KitItem oTipo)
        {

            return base.Update(oTipo);

        }

        /// <summary>
        /// Método para excluir o registro
        /// </summary>
        /// <param name="oTipo">Entidade com os dados Preenchidos</param>
        /// <returns>Boolean. Se a operação foi um sucesso, true.</returns>
        /// <remarks></remarks>
        public override bool Delete(Model.KitItem oTipo)
        {

            return base.Delete(oTipo);

        }

        /// <summary>
        /// Método para procurar um registro
        /// </summary>
        /// <param name="Identifier">Código para a Procura do Valor</param>
        /// <returns>Entidade. Se a operação foi um sucesso, A Entidade Virá preenchida.</returns>
        /// <remarks></remarks>
        public override Model.KitItem Find(int Identifier)
        {

            return base.Find(Identifier);

        }

        /// <summary>
        /// Método para carregar a lista dos registros
        /// </summary>
        /// <returns>Lista. Se a operação foi um sucesso, a lista virá carregada.</returns>
        /// <remarks></remarks>
        public override IList<Model.KitItem> LoadAll()
        {

            return base.LoadAll();

        }

        public IList<Model.KitItem> LoadKitItemByKit(int intKit)
        {

            Command oCommand = null;
            IList<Model.KitItem> lstRetorno = null;
            DataTable dtDados = null;
            Model.KitItem oRetorno = null;
            try
            {
                lstRetorno = new List<Model.KitItem>();
                oCommand = new Command("CECAMKey");
                oCommand.CommandText = "pr_get_kit_item";
                oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                oCommand.Parameters.Add(new Parameter("@id_kit", System.Data.DbType.Int32, 75, intKit));
                dtDados = oCommand.GetDataTable();

                foreach (DataRow dr in dtDados.Rows)
                {
                    oRetorno = new Model.KitItem();
                    oRetorno.Codigo = Convert.ToInt32(dr["id_kit_item"].ToString());
                    oRetorno.Kit.Codigo = Convert.ToInt32(dr["id_kit"].ToString());
                    oRetorno.Kit.Descricao = dr["ds_kit"].ToString();
                    oRetorno.TipoItem = new Model.TipoItem(Convert.ToInt32(dr["id_tipo_item"].ToString()), 
                                                           dr["ds_tipo_item"].ToString(),
                                                           dr["is_opcional"].ToString());
                    oRetorno.Observacao = dr["ds_observacao"].ToString();
                    oRetorno.Ordem = Convert.ToInt32(dr["nr_ordem"].ToString());
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
    }
}
