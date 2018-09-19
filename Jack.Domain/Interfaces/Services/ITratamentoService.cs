using Jack.Domain.Entity;
using Jack.DomainValidator;
using System.Collections.Generic;

namespace Jack.Domain.Interfaces.Services
{
    public interface ITratamentoService : IServiceBase<Tratamento>
    {
        IEnumerable<Tratamento> Filtrar(string nome);
        ValidationResult Gravar(Tratamento entity);
        ValidationResult Excluir(int id);
        IEnumerable<Tratamento> ObterTodos(int familiaId);

    }
}