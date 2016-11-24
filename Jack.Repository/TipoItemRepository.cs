using System.Collections.Generic;
using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Repository;
using Jack.Repository.UnityOfWork;

namespace Jack.Repository
{
    public class TipoItemRepository   : Repository<TipoItem>, ITipoItemRepository
    {
        private readonly IUnityOfWork UnitWork;
        public TipoItemRepository(IUnityOfWork unitWork)
            : base(unitWork)
        {
            UnitWork = unitWork;
        }

        public void Adicionar(TipoItem entity)
        {
            UnitWork.Salvar(entity);
        }

        public void Atualizar(TipoItem entity)
        {
            UnitWork.Salvar(entity);
        }

        public void Excluir(TipoItem entity)
        {
            UnitWork.Excluir(entity);
        }

        public TipoItem ObterPorId(int id)
        {
            return base.GetById(id);
        }

        public IEnumerable<TipoItem> ObterTodos()
        {
           return base.GetAll();
        }
    }
}