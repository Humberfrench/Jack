using Consumer.Data.Basic.Data;
using System;
using System.Collections.Generic;
using System.Data;
using NHibernate;
using NHibernate.Transform;
using NHibernate.Criterion;
using System.Linq;
using Jack.DTO;
using Jack.Model;

namespace Jack.Repository
{
    public class FamiliaRep : Repository<Familia>, IFamiliaRep
    {
        private IUnitWork UnitWork;
        public FamiliaRep(IUnitWork unitWork) : base(unitWork)
        {
            UnitWork = unitWork;
        }

        /// <summary>
        /// Método para inserir o registro
        /// </summary>
        /// <param name="oTipo">Entidade com os dados Preenchidos</param>
        /// <returns>Boolean. Se a operação foi um sucesso, true.</returns>
        /// <remarks></remarks>
        public bool Insert(Familia oTipo)
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
        public bool Update(Familia oTipo)
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
        public bool Delete(Familia oTipo)
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
        public Familia Find(int Identifier)
        {
            Familia oReturn;
            oReturn  = base.GetById(Identifier);
            //return (Familia)oSession.GetSessionImplementation().PersistenceContext.Unproxy(oReturn);
            return (Familia) oReturn;

        }

        /// <summary>
        /// Método para carregar a lista dos registros
        /// </summary>
        /// <returns>Lista. Se a operação foi um sucesso, a lista virá carregada.</returns>
        /// <remarks></remarks>
        public IList<Familia> LoadAll()
        {

            return GetAll().ToList();

        }


        public string GravarLote(Familia oFamilia)
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

        public IList<DTOFamiliaChamada> ObterChamada(int intReuniao)
        {

            Command oCommand = null;
            List<DTOFamiliaChamada> lstDados = null;
            DTOFamiliaChamada objDados = null;
            DataTable dtDados = null;

            try
            {
                oCommand = new Command("CECAMKey");
                oCommand.CommandText = "pr_chamada_nomes";
                oCommand.Parameters.Add(new Parameter("@id_reuniao", DbType.Int16, intReuniao));
                oCommand.CommandType = CommandType.StoredProcedure;

                dtDados = oCommand.GetDataTable();

                lstDados = new List<DTOFamiliaChamada>();

                foreach (DataRow dr in dtDados.Rows)
                {
                    objDados = new DTOFamiliaChamada();
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

        public IList<DTOFamilia> Load()
        {
            IList<DTOFamilia> listaStatus;
            ICriteria criteria = Session.CreateCriteria(typeof(Familia), "F")
                                         .CreateAlias("Status", "S", NHibernate.SqlCommand.JoinType.InnerJoin)
                                         .SetProjection(Projections.ProjectionList()
                                         .Add(Projections.Property("F.Codigo"), "Codigo")
                                         .Add(Projections.Property("F.Nome"), "Nome")
                                         .Add(Projections.Property("F.IsConsistente"), "IsConsistente")
                                         .Add(Projections.Property("F.IsSacolinha"), "IsSacolinha")
                                         .Add(Projections.Property("F.DataAtualizacao"), "DataAtualizacao")
                                         .Add(Projections.Property("F.Contato"), "Contato")
                                         .Add(Projections.Property("S.Codigo"), "Status")
                                         .Add(Projections.Property("S.Descricao"), "StatusDescricao"));

            listaStatus = criteria.SetResultTransformer(Transformers.AliasToBean<DTOFamilia>()).List<DTOFamilia>();

            criteria = null;
            return listaStatus;
        }
    }
}
