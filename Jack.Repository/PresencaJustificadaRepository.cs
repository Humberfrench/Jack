using System.Collections.Generic;
using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Repository;
using Jack.Repository.UnityOfWork;

namespace Jack.Repository
{
    public class PresencaJustificadaRepository   : Repository<PresencaJustificada>, IPresencaJustificadaRepository
    {
        private readonly IUnityOfWork UnitWork;
        public PresencaJustificadaRepository(IUnityOfWork unitWork)
            : base(unitWork)
        {
            UnitWork = unitWork;
        }

        public void Adicionar(PresencaJustificada entity)
        {
            UnitWork.Salvar(entity);
        }

        public void Atualizar(PresencaJustificada entity)
        {
            UnitWork.Salvar(entity);
        }

        public void Excluir(PresencaJustificada entity)
        {
            UnitWork.Excluir(entity);
        }

        public PresencaJustificada ObterPorId(int id)
        {
            return base.GetById(id);
        }

        public IEnumerable<PresencaJustificada> ObterTodos()
        {
           return base.GetAll();
        }
    }
}