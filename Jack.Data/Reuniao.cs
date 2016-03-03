using Jack.Model.DTOs;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Transform;
using System.Collections.Generic;

namespace Jack.Data
{
    public class Reuniao : BaseData<Model.Reuniao, int>
    {

        public Reuniao() : base()
        {
        }


        /// <summary>
        /// Método para inserir o registro
        /// </summary>
        /// <param name="oTipo">Entidade com os dados Preenchidos</param>
        /// <returns>Boolean. Se a operação foi um sucesso, true.</returns>
        /// <remarks></remarks>
        public override bool Insert(Model.Reuniao oTipo)
        {

            return base.Insert(oTipo);

        }

        /// <summary>
        /// Método para atualizar o registro
        /// </summary>
        /// <param name="oTipo">Entidade com os dados Preenchidos</param>
        /// <returns>Boolean. Se a operação foi um sucesso, true.</returns>
        /// <remarks></remarks>
        public override bool Update(Model.Reuniao oTipo)
        {

            return base.Update(oTipo);

        }

        /// <summary>
        /// Método para excluir o registro
        /// </summary>
        /// <param name="oTipo">Entidade com os dados Preenchidos</param>
        /// <returns>Boolean. Se a operação foi um sucesso, true.</returns>
        /// <remarks></remarks>
        public override bool Delete(Model.Reuniao oTipo)
        {

            return base.Delete(oTipo);

        }

        /// <summary>
        /// Método para procurar um registro
        /// </summary>
        /// <param name="Identifier">Código para a Procura do Valor</param>
        /// <returns>Entidade. Se a operação foi um sucesso, A Entidade Virá preenchida.</returns>
        /// <remarks></remarks>
        public override Model.Reuniao Find(int Identifier)
        {

            return base.Find(Identifier);

        }

        /// <summary>
        /// Método para carregar a lista dos registros
        /// </summary>
        /// <returns>Lista. Se a operação foi um sucesso, a lista virá carregada.</returns>
        /// <remarks></remarks>
        public override IList<Model.Reuniao> LoadAll()
        {

            return base.LoadAll();

        }

        public IList<DTOReuniao> LoadByAnoCorrente(int intAno)
        {
            IList<DTOReuniao> listaReuniao = null;
            ICriteria criteria = oSession.CreateCriteria(typeof(Model.Reuniao), "R")
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
