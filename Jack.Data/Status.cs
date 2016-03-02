using Jack.Model.DTOs;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Transform;
using System.Collections.Generic;

namespace Jack.Data
{
    public class Status : BaseData<Model.Status, int>
    {

        public Status() : base()
        {
        }

        #region Nhibernate
        /// <summary>
        /// Método para inserir o registro
        /// </summary>
        /// <param name="oTipo">Entidade com os dados Preenchidos</param>
        /// <returns>Boolean. Se a operação foi um sucesso, true.</returns>
        /// <remarks></remarks>
        public override bool Insert(Model.Status oTipo)
        {

            return base.Insert(oTipo);

        }

        /// <summary>
        /// Método para atualizar o registro
        /// </summary>
        /// <param name="oTipo">Entidade com os dados Preenchidos</param>
        /// <returns>Boolean. Se a operação foi um sucesso, true.</returns>
        /// <remarks></remarks>
        public override bool Update(Model.Status oTipo)
        {

            return base.Update(oTipo);

        }

        /// <summary>
        /// Método para excluir o registro
        /// </summary>
        /// <param name="oTipo">Entidade com os dados Preenchidos</param>
        /// <returns>Boolean. Se a operação foi um sucesso, true.</returns>
        /// <remarks></remarks>
        public override bool Delete(Model.Status oTipo)
        {

            return base.Delete(oTipo);

        }

        /// <summary>
        /// Método para procurar um registro
        /// </summary>
        /// <param name="Identifier">Código para a Procura do Valor</param>
        /// <returns>Entidade. Se a operação foi um sucesso, A Entidade Virá preenchida.</returns>
        /// <remarks></remarks>
        public override Model.Status Find(int Identifier)
        {

            return base.Find(Identifier);

        }

        /// <summary>
        /// Método para carregar a lista dos registros
        /// </summary>
        /// <returns>Lista. Se a operação foi um sucesso, a lista virá carregada.</returns>
        /// <remarks></remarks>
        public override IList<Model.Status> LoadAll()
        {

            return base.LoadAll();

        }

        #endregion

        #region Other

        public IList<DTOStatus> Load()
        {
            IList<DTOStatus> listaStatus;
            ICriteria criteria = oSession.CreateCriteria(typeof(Model.Status), "S")
                                         .SetProjection(Projections.ProjectionList()
                                         .Add(Projections.Property("S.Codigo"), "codigo")
                                         .Add(Projections.Property("S.Descricao"), "descricao")
                                         .Add(Projections.Property("S.NivelStatus"), "nivelStatus")
                                         .Add(Projections.Property("S.PermiteSacola"), "permiteSacola"));

            listaStatus = criteria.SetResultTransformer(Transformers.AliasToBean<DTOStatus>()).List<DTOStatus>();

            criteria = null;
            return listaStatus;
        }
        #endregion
    }
}
