using System.Collections.Generic;
using Jack.Domain.Entity;
using Jack.DomainValidator;

namespace Jack.Domain.Interfaces.Services
{
    public interface IFamiliaBlackListService : IServiceBase<FamiliaBlackList>
    {
        ValidationResult Gravar(FamiliaBlackList entity);
        ValidationResult Excluir(int id);
    }
}