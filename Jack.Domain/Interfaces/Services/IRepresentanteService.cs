using System.Collections.Generic;
using Jack.Domain.Entity;
using Jack.DomainValidator;

namespace Jack.Domain.Interfaces.Services
{
    public interface IRepresentanteService : IServiceBase<Representante>
    {
        ValidationResult Gravar(Representante entity);
        ValidationResult Excluir(int id);
    }
}