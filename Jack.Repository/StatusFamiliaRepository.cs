using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Repository;
using Jack.Repository.UnityOfWork;
using System.Collections.Generic;

namespace Jack.Repository
{
    public class StatusFamiliaRepository   : Repository<StatusFamilia>, IStatusFamiliaRepository
    {
        private readonly IUnityOfWork UnitWork;
        public StatusFamiliaRepository(IUnityOfWork unitWork)
            : base(unitWork)
        {
            UnitWork = unitWork;
        }

        public void Adicionar(StatusFamilia entity)
        {
            UnitWork.Salvar(entity);
        }

        public void Atualizar(StatusFamilia entity)
        {
            UnitWork.Salvar(entity);
        }

        public void Excluir(StatusFamilia entity)
        {
            UnitWork.Excluir(entity);
        }

        public StatusFamilia ObterPorId(int id)
        {
            return base.GetById(id);
        }

        public IEnumerable<StatusFamilia> ObterTodos()
        {
           return base.GetAll();
        }
    }
}