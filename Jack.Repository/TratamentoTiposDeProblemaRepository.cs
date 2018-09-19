using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Repository;
using Jack.Repository.UnityOfWork;

namespace Jack.Repository
{
    public class TratamentoTiposDeProblemaRepository : BaseRepository<TratamentoTipoDeProblema>, ITratamentoTiposDeProblemaRepository
    {
        private readonly IUnityOfWork UnitWork;
        public TratamentoTiposDeProblemaRepository(IUnityOfWork unitWork)
            : base(unitWork)
        {
            UnitWork = unitWork;
        }

    }
}