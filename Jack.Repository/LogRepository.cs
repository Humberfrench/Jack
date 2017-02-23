using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Repository;
using Jack.Repository.UnityOfWork;

namespace Jack.Repository
{
    public class LogRepository : BaseRepository<Log>, ILogRepository
    {
        private readonly IUnityOfWork UnitWork;
        public LogRepository(IUnityOfWork unitWork)
            : base(unitWork)
        {
            UnitWork = unitWork;           
        }

    }
}