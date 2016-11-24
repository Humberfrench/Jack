using System.Collections.Generic;
using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Repository;
using Jack.Repository.UnityOfWork;

namespace Jack.Repository
{
    public class FamiliaFakeRepository   : Repository<FamiliaFake>, IFamiliaFakeRepository
    {
        private readonly IUnityOfWork UnitWork;
        public FamiliaFakeRepository(IUnityOfWork unitWork)
            : base(unitWork)
        {
            UnitWork = unitWork;
        }

        public void Adicionar(FamiliaFake entity)
        {
            UnitWork.Salvar(entity);
        }

        public void Atualizar(FamiliaFake entity)
        {
            UnitWork.Salvar(entity);
        }

        public void Excluir(FamiliaFake entity)
        {
            UnitWork.Excluir(entity);
        }

        public FamiliaFake ObterPorId(int id)
        {
            return base.GetById(id);
        }

        public IEnumerable<FamiliaFake> ObterTodos()
        {
           return base.GetAll();
        }
    }
}