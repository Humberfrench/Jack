using System.Collections.Generic;
using Jack.Domain.Entity;
using Jack.DomainValidator;

namespace Jack.Domain.Interfaces.Services
{
    public interface IStatusService : IServiceBase<Status>
    {
        IEnumerable<Status> Filtrar(string nome);
        ValidationResult Gravar(Status entity);
        ValidationResult Excluir(int id);
    }
}