using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Repository;
using Jack.Repository.UnityOfWork;

namespace Jack.Repository
{
    public class StatusTratamentoRepository : BaseRepository<StatusTratamento>, IStatusTratamentoRepository
    {
        private readonly IUnityOfWork UnitWork;
        public StatusTratamentoRepository(IUnityOfWork unitWork)
            : base(unitWork)
        {
            UnitWork = unitWork;
        }

    }
}