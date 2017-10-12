using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Repository;
using Jack.Repository.UnityOfWork;

namespace Jack.Repository
{
    public class ColaboradorCriancaRepository : BaseRepository<ColaboradorCrianca>, IColaboradorCriancaRepository
    {
        private readonly IUnityOfWork UnitWork;
        public ColaboradorCriancaRepository(IUnityOfWork unitWork)
            : base(unitWork)
        {
            UnitWork = unitWork;
        }

    }
}