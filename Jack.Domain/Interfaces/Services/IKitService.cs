using System.Collections.Generic;
using Jack.Domain.Entity;
using Jack.DomainValidator;

namespace Jack.Domain.Interfaces.Services
{
    public interface IKitService : IServiceBase<Kit>
    {
        IEnumerable<Kit> Filtrar(string nome);
        ValidationResult Gravar(Kit entity);
        ValidationResult Excluir(int id);
    }
}