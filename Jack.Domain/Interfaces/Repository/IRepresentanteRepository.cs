using Jack.Domain.Entity;

namespace Jack.Domain.Interfaces.Repository
{
    public interface IRepresentanteRepository : IRepositoryBase<Representante>
    {
        Familia ObterRepresentante(int familiaRepresentada);     
    }
}