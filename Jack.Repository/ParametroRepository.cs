using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Repository;
using Jack.Repository.UnityOfWork;
using System.Collections.Generic;
using System.Linq;

namespace Jack.Repository
{
    public class ParametroRepository : Repository<Parametro>, IParametroRepository
    {
        private readonly IUnityOfWork UnitWork;
        public ParametroRepository(IUnityOfWork unitWork)
            : base(unitWork)
        {
            UnitWork = unitWork;
        }

        public Parametro ObterPorId(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Parametro> ObterTodos()
        {
           return base.GetAll();
        }

        public Parametro Obter()
        {
            return base.GetAll().FirstOrDefault();
        }
    }
}