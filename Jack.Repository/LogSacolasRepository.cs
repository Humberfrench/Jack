using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Repository;
using Jack.Repository.UnityOfWork;

namespace Jack.Repository
{
    public class LogSacolasRepository : BaseRepository<LogSacolas>, ILogSacolasRepository
    {
        private readonly IUnityOfWork UnitWork;
        public LogSacolasRepository(IUnityOfWork unitWork)
            : base(unitWork)
        {
            UnitWork = unitWork;
        }

    }
}