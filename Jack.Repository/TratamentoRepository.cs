using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Repository;
using Jack.Repository.UnityOfWork;

namespace Jack.Repository
{
    public class TratamentoRepository : BaseRepository<Tratamento>, ITratamentoRepository
    {
        private readonly IUnityOfWork UnitWork;
        public TratamentoRepository(IUnityOfWork unitWork)
            : base(unitWork)
        {
            UnitWork = unitWork;
        }

    }
}