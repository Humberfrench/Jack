using Jack.DTO;
using Jack.Model.DTOs;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Transform;
using System.Collections.Generic;
using System.Linq;

namespace Jack.Repository
{
    public class Reuniao : Repository<Model.Reuniao>
    {

        private IUnitWork UnitWork;
        public Reuniao(IUnitWork unitWork) : base(unitWork)
        {
            UnitWork = unitWork;
        }

        /// <summary>
        /// Método para inserir o registro
        /// </summary>
        /// <param name="oTipo">Entidade com os dados Preenchidos</param>
        /// <returns>Boolean. Se a operação foi um sucesso, true.</returns>
        /// <remarks></remarks>
        public bool Insert(Model.Reuniao oTipo)
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
        public bool Update(Model.Reuniao oTipo)
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
        public bool Delete(Model.Reuniao oTipo)
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
        public Model.Reuniao Find(int Identifier)
        {

            return GetById(Identifier);

        }

        /// <summary>
        /// Método para carregar a lista dos registros
        /// </summary>
        /// <returns>Lista. Se a operação foi um sucesso, a lista virá carregada.</returns>
        /// <remarks></remarks>
        public IList<Model.Reuniao> LoadAll()
        {

            return GetAll().ToList();

        }

        public IList<DTOReuniao> LoadByAnoCorrente(int intAno)
        {
            IList<DTOReuniao> listaReuniao = null;
            ICriteria criteria = Session.CreateCriteria(typeof(Model.Reuniao), "R")
                             .SetProjection(Projections.ProjectionList()
                             .Add(Projections.Property("R.Codigo"), "Codigo")
                             .Add(Projections.Property("R.Ano"), "Ano")
                             .Add(Projections.Property("R.AnoCorrente"), "AnoCorrente")
                             .Add(Projections.Property("R.Data"), "Data"))
                             .Add(Restrictions.Eq("R.Ano", intAno));

            listaReuniao = criteria.SetResultTransformer(Transformers.AliasToBean<DTOReuniao>()).List<DTOReuniao>();

            criteria = null;
            return listaReuniao;

        }

    }
}
