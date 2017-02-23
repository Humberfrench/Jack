using Jack.Domain.Entity;
using Jack.DomainValidator;
using System.Collections.Generic;

namespace Jack.Domain.Interfaces.Services
{
    public interface IStatusCriancaService : IServiceBase<StatusCrianca>
    {
        IEnumerable<StatusCrianca> Filtrar(string nome);
        ValidationResult Gravar(StatusCrianca entity);
        ValidationResult Excluir(int id);
    }
}