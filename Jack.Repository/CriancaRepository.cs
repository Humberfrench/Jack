using System.Collections.Generic;
using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Repository;
using Jack.Repository.UnityOfWork;

namespace Jack.Repository
{
    public class CriancaRepository : Repository<Crianca>, ICriancaRepository
    {
        private readonly IUnityOfWork UnitWork;
        public CriancaRepository(IUnityOfWork unitWork)
            : base(unitWork)
        {
            UnitWork = unitWork;
        }

        public void Adicionar(Crianca entity)
        {
            UnitWork.Salvar(entity);
        }

        public void Atualizar(Crianca entity)
        {
            UnitWork.Salvar(entity);
        }

        public void Excluir(Crianca entity)
        {
            UnitWork.Excluir(entity);
        }

        public Crianca ObterPorId(int id)
        {
            return base.GetById(id);
        }

        public IEnumerable<Crianca> ObterTodos()
        {
           return base.GetAll();
        }
    }
}