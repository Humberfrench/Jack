using System.Collections.Generic;
using Jack.Domain.Entity;
using Jack.DomainValidator;

namespace Jack.Domain.Interfaces.Services
{
    public interface IStatusCriancaService : IServiceBase<StatusCrianca>
    {
        IEnumerable<StatusCrianca> Filtrar(string nome);
        ValidationResult Gravar(StatusCrianca entity);
        ValidationResult Excluir(int id);
    }
}