using System.Collections.Generic;
using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Repository;
using Jack.Repository.UnityOfWork;

namespace Jack.Repository
{
    public class FamiliaBlackListRepository   : Repository<FamiliaBlackList>, IFamiliaBlackListRepository
    {
        private readonly IUnityOfWork UnitWork;
        public FamiliaBlackListRepository(IUnityOfWork unitWork)
            : base(unitWork)
        {
            UnitWork = unitWork;
        }

        public void Adicionar(FamiliaBlackList entity)
        {
            UnitWork.Salvar(entity);
        }

        public void Atualizar(FamiliaBlackList entity)
        {
            UnitWork.Salvar(entity);
        }

        public void Excluir(FamiliaBlackList entity)
        {
            UnitWork.Excluir(entity);
        }

        public FamiliaBlackList ObterPorId(int id)
        {
            return base.GetById(id);
        }

        public IEnumerable<FamiliaBlackList> ObterTodos()
        {
           return base.GetAll();
        }
    }
}