using System.Collections.Generic;
using Jack.Domain.Entity;
using Jack.DomainValidator;

namespace Jack.Domain.Interfaces.Services
{
    public interface IFamiliaFakeService : IServiceBase<FamiliaFake>
    {
        ValidationResult Gravar(FamiliaFake entity);
        ValidationResult Excluir(int id);
    }
}