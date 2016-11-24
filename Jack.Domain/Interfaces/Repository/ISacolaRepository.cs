using Jack.Domain.Entity;

namespace Jack.Domain.Interfaces.Repository
{
    public interface ISacolaRepository : IRepositoryBaseReadOnly<Sacola>
    {
        Sacola ObterSacolaPorCrianca(int crianca);     
    }
}