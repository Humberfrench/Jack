using System.Collections.Generic;
using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Repository;
using Jack.Repository.UnityOfWork;

namespace Jack.Repository
{
    public class StatusRepository   : Repository<Status>, IStatusRepository
    {
        private readonly IUnityOfWork UnitWork;
        public StatusRepository(IUnityOfWork unitWork)
            : base(unitWork)
        {
            UnitWork = unitWork;
        }

        public void Adicionar(Status entity)
        {
            UnitWork.Salvar(entity);
        }

        public void Atualizar(Status entity)
        {
            UnitWork.Salvar(entity);
        }

        public void Excluir(Status entity)
        {
            UnitWork.Excluir(entity);
        }

        public Status ObterPorId(int id)
        {
            return base.GetById(id);
        }

        public IEnumerable<Status> ObterTodos()
        {
           return base.GetAll();
        }
    }
}