using Jack.Domain.Entity;

namespace Jack.Domain.Interfaces.Repository
{
    public interface INivelRepository : IRepositoryBase<Nivel>
    {
        Nivel ObterNivelPorFaixaPresencial(float percPresenca);     
    }
}