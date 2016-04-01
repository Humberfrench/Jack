using Jack.DTO;
using Jack.Model.DTOs;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Transform;
using System.Collections.Generic;
using System.Linq;

namespace Jack.Repository
{
    public class RepStatus : Repository<Model.Status>
    { 
        private IUnitWork UnitWork;
        public RepStatus(IUnitWork unitWork) : base(unitWork)
        {
            UnitWork = unitWork;
        }

    #region Nhibernate
        /// <summary>
    /// Método para inserir o registro
    /// </summary>
    /// <param name="oTipo">Entidade com os dados Preenchidos</param>
    /// <returns>Boolean. Se a operação foi um sucesso, true.</returns>
    /// <remarks></remarks>
        public bool Insert(Model.Status oTipo)
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
        public bool Update(Model.Status oTipo)
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
        public bool Delete(Model.Status oTipo)
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
        public Model.Status Find(int Identifier)
        {

            return GetById(Identifier);

        }

        /// <summary>
        /// Método para carregar a lista dos registros
        /// </summary>
        /// <returns>Lista. Se a operação foi um sucesso, a lista virá carregada.</returns>
        /// <remarks></remarks>
        public IList<Model.Status> LoadAll()
        {

            return GetAll().ToList();

        }

        #endregion

        #region Other

        public IList<DTOStatus> Load()
        {
            IList<DTOStatus> listaStatus;
            ICriteria criteria = Session.CreateCriteria(typeof(Model.Status), "S")
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
