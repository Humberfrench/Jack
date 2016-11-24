using Jack.Domain.Entity;

namespace Jack.Domain.Interfaces.Repository
{
    public interface IKitRepository : IRepositoryBase<Kit>
    {
        Kit ObterKitPorIdade(int idade, string sexo, bool necessidadeEspecial);     
    }
}