using System.Collections.Generic;
using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Repository;
using Jack.Repository.UnityOfWork;

namespace Jack.Repository
{
    public class RepresentanteRepository   : Repository<Representante>, IRepresentanteRepository
    {
        private readonly IUnityOfWork UnitWork;
        public RepresentanteRepository(IUnityOfWork unitWork)
            : base(unitWork)
        {
            UnitWork = unitWork;
        }

        public void Adicionar(Representante entity)
        {
            UnitWork.Salvar(entity);
        }

        public void Atualizar(Representante entity)
        {
            UnitWork.Salvar(entity);
        }

        public void Excluir(Representante entity)
        {
            UnitWork.Excluir(entity);
        }

        public Representante ObterPorId(int id)
        {
            return base.GetById(id);
        }

        public IEnumerable<Representante> ObterTodos()
        {
           return base.GetAll();
        }
    }
}