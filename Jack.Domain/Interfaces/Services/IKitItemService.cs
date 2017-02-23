using Jack.Domain.Entity;
using Jack.DomainValidator;
using System.Collections.Generic;

namespace Jack.Domain.Interfaces.Services
{
    public interface IKitItemService : IServiceBase<KitItem>
    {
        ValidationResult Gravar(KitItem entity);
        ValidationResult Excluir(int id);
        IEnumerable<KitItem> ObterTodos(int id);
    }
}