using System.Collections.Generic;
using System.Linq;
using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Repository;
using Jack.Repository.UnityOfWork;

namespace Jack.Repository
{
    public class SacolaRepository : Repository<Sacola>, ISacolaRepository
    {
        private readonly IUnityOfWork UnitWork;
        public SacolaRepository(IUnityOfWork unitWork)
            : base(unitWork)
        {
            UnitWork = unitWork;
        }

        public Sacola ObterPorId(int id)
        {
            return base.GetById(id);
        }

        public IEnumerable<Sacola> ObterTodos()
        {
           return base.GetAll();
        }

        public Sacola ObterSacolaPorCrianca(int crianca)
        {
            return ObterTodos().FirstOrDefault(sac => sac.Crianca.Codigo == crianca);
        }
    }
}