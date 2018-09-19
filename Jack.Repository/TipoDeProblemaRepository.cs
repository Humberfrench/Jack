using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Repository;
using Jack.Repository.UnityOfWork;

namespace Jack.Repository
{
    public class TipoDeProblemaRepository : BaseRepository<TipoDeProblema>, ITipoDeProblemaRepository
    {
        private readonly IUnityOfWork UnitWork;
        public TipoDeProblemaRepository(IUnityOfWork unitWork)
            : base(unitWork)
        {
            UnitWork = unitWork;
        }

    }
}