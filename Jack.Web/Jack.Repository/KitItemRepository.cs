using System.Collections.Generic;
using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Repository;
using Jack.Repository.UnityOfWork;

namespace Jack.Repository
{
    public class KitItemRepository   : Repository<KitItem>, IKitItemRepository
    {
        private readonly IUnityOfWork UnitWork;
        public KitItemRepository(IUnityOfWork unitWork)
            : base(unitWork)
        {
            UnitWork = unitWork;
        }

        public void Adicionar(KitItem entity)
        {
            UnitWork.Salvar(entity);
        }

        public void Atualizar(KitItem entity)
        {
            UnitWork.Salvar(entity);
        }

        public void Excluir(KitItem entity)
        {
            UnitWork.Excluir(entity);
        }

        public KitItem ObterPorId(int id)
        {
            return base.GetById(id);
        }

        public IEnumerable<KitItem> ObterTodos()
        {
           return base.GetAll();
        }
    }
}