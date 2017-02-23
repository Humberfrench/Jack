using System.Collections.Generic;
using Jack.Domain.Entity;
using Jack.DomainValidator;

namespace Jack.Domain.Interfaces.Services
{
    public interface IKitItemService : IServiceBase<KitItem>
    {
        ValidationResult Gravar(KitItem entity);
        ValidationResult Excluir(int id);
        IEnumerable<KitItem> ObterTodos(int id);
    }
}