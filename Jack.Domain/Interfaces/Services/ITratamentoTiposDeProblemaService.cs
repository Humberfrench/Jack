using Jack.Domain.Entity;
using Jack.DomainValidator;
using System.Collections.Generic;

namespace Jack.Domain.Interfaces.Services
{
    public interface ITratamentoTiposDeProblemaService : IServiceBase<TratamentoTipoDeProblema>
    {
        ValidationResult Gravar(TratamentoTipoDeProblema entity);
        ValidationResult Excluir(int id);
    }
}