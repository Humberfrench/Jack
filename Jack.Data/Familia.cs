using Consumer.Data.Basic.Data;
using System;
using System.Collections.Generic;
using System.Data;

namespace Jack.Data
{
    public class Familia : BaseData<Model.Familia, int>
    {

        public Familia() : base()
        {
        }

        /// <summary>
        /// Método para inserir o registro
        /// </summary>
        /// <param name="oTipo">Entidade com os dados Preenchidos</param>
        /// <returns>Boolean. Se a operação foi um sucesso, true.</returns>
        /// <remarks></remarks>
        public override bool Insert(Model.Familia oTipo)
        {

            return base.Insert(oTipo);

        }

        /// <summary>
        /// Método para atualizar o registro
        /// </summary>
        /// <param name="oTipo">Entidade com os dados Preenchidos</param>
        /// <returns>Boolean. Se a operação foi um sucesso, true.</returns>
        /// <remarks></remarks>
        public override bool Update(Model.Familia oTipo)
        {

            return base.Update(oTipo);

        }

        /// <summary>
        /// Método para excluir o registro
        /// </summary>
        /// <param name="oTipo">Entidade com os dados Preenchidos</param>
        /// <returns>Boolean. Se a operação foi um sucesso, true.</returns>
        /// <remarks></remarks>
        public override bool Delete(Model.Familia oTipo)
        {

            return base.Delete(oTipo);

        }

        /// <summary>
        /// Método para procurar um registro
        /// </summary>
        /// <param name="Identifier">Código para a Procura do Valor</param>
        /// <returns>Entidade. Se a operação foi um sucesso, A Entidade Virá preenchida.</returns>
        /// <remarks></remarks>
        public override Model.Familia Find(int Identifier)
        {

            return base.Find(Identifier);

        }

        /// <summary>
        /// Método para carregar a lista dos registros
        /// </summary>
        /// <returns>Lista. Se a operação foi um sucesso, a lista virá carregada.</returns>
        /// <remarks></remarks>
        public override IList<Model.Familia> LoadAll()
        {

            return base.LoadAll();

        }

        //Overrides Function LoadAll2() As IList(Of Model.Familia)

        //    Dim oCriteria = oSession.CreateCriteria("Familia", "F").CreateAlias("F.Status", "S")




        //End Function

        public string GravarLote(Model.Familia oFamilia)
        {
            Command oCommand = null;
            string strRetorno = string.Empty;
            try
            {
                oCommand = new Command("CECAMKey");
                oCommand.CommandText = "pr_add_familia_lote";
                oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                oCommand.Parameters.Add(new Parameter("@nm_mae", System.Data.DbType.String, 75, oFamilia.Nome));
                oCommand.Parameters.Add(new Parameter("@is_sacolinha", System.Data.DbType.String, 1, oFamilia.IsSacolinha));
                oCommand.Parameters.Add(new Parameter("@is_consistente", System.Data.DbType.String, 1, oFamilia.IsConsistente));
                strRetorno = oCommand.Execute().ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oCommand.Dispose();
                oCommand = null;
            }
            return strRetorno;
        }

        public List<Model.Familia> ObterChamada(int intReuniao)
        {

            Command oCommand = null;
            List<Model.Familia> lstDados = null;
            Model.Familia objDados = null;
            DataTable dtDados = null;

            try
            {
                oCommand = new Command("CECAMKey");
                oCommand.CommandText = "pr_chamada_nomes";
                oCommand.Parameters.Add(new Parameter("@id_reuniao", DbType.Int16, intReuniao));
                oCommand.CommandType = CommandType.StoredProcedure;

                dtDados = oCommand.GetDataTable();

                lstDados = new List<Model.Familia>();

                foreach (DataRow dr in dtDados.Rows)
                {
                    objDados = new Model.Familia();
                    objDados.Codigo = Convert.ToInt32(dr["id_familia"]);
                    objDados.Nome = dr["nm_mae"].ToString();
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
                dtDados = null;
                objDados = null;
                oCommand.Dispose();
                oCommand = null;
            }

            return lstDados;

        }

    }
}
