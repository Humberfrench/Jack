using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Repository;
using Jack.Repository.UnityOfWork;
using System.Collections.Generic;

namespace Jack.Repository
{
    public class StatusCriancaRepository   : Repository<StatusCrianca>, IStatusCriancaRepository
    {
        private readonly IUnityOfWork UnitWork;
        public StatusCriancaRepository(IUnityOfWork unitWork)
            : base(unitWork)
        {
            UnitWork = unitWork;
        }

        public void Adicionar(StatusCrianca entity)
        {
            UnitWork.Salvar(entity);
        }

        public void Atualizar(StatusCrianca entity)
        {
            UnitWork.Salvar(entity);
        }

        public void Excluir(StatusCrianca entity)
        {
            UnitWork.Excluir(entity);
        }

        public StatusCrianca ObterPorId(int id)
        {
            return base.GetById(id);
        }

        public IEnumerable<StatusCrianca> ObterTodos()
        {
           return base.GetAll();
        }
    }
}