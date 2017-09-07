using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Repository;
using Jack.Repository.UnityOfWork;

namespace Jack.Repository
{
    public class SacolaHistoricoRepository : BaseRepository<SacolaHistorico>, ISacolaHistoricoRepository
    {
        private readonly IUnityOfWork UnitWork;
        public SacolaHistoricoRepository(IUnityOfWork unitWork)
            : base(unitWork)
        {
            UnitWork = unitWork;
        }

    }
}