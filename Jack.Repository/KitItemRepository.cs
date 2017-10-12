using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Repository;
using Jack.Repository.UnityOfWork;

namespace Jack.Repository
{
    public class KitItemRepository : BaseRepository<KitItem>, IKitItemRepository
    {
        private readonly IUnityOfWork UnitWork;
        public KitItemRepository(IUnityOfWork unitWork)
            : base(unitWork)
        {
            UnitWork = unitWork;
        }

    }
}