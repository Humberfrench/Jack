using Jack.Domain.Entity;
using Jack.DomainValidator;
using System.Collections.Generic;

namespace Jack.Domain.Interfaces.Services
{
    public interface IKitService : IServiceBase<Kit>
    {
        IEnumerable<Kit> Filtrar(string nome);
        ValidationResult Gravar(Kit entity);
        ValidationResult Excluir(int id);
    }
}