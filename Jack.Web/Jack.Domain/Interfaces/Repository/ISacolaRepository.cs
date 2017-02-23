using Jack.Domain.Entity;

namespace Jack.Domain.Interfaces.Repository
{
    public interface ISacolaRepository : IRepositoryBase<Sacola>
    {
        Sacola ObterSacolaPorCrianca(int crianca);     
    }
}