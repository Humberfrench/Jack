using System.Collections.Generic;
using Jack.Domain.Entity;
using Jack.DomainValidator;

namespace Jack.Domain.Interfaces.Services
{
    public interface ITipoItemService : IServiceBase<TipoItem>
    {
        IEnumerable<TipoItem> Filtrar(string nome);
        ValidationResult Gravar(TipoItem entity);
        ValidationResult Excluir(int id);
    }
}