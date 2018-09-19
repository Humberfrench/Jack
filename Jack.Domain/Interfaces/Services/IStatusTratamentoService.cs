using Jack.Domain.Entity;
using Jack.DomainValidator;
using System.Collections.Generic;

namespace Jack.Domain.Interfaces.Services
{
    public interface IStatusTratamentoService : IServiceBase<StatusTratamento>
    {
        IEnumerable<StatusTratamento> Filtrar(string nome);
        ValidationResult Gravar(StatusTratamento entity);
        ValidationResult Excluir(int id);

    }
}