using Jack.Domain.Entity;
using Jack.DomainValidator;
using System.Collections.Generic;

namespace Jack.Domain.Interfaces.Services
{
    public interface ITipoDeProblemaService : IServiceBase<TipoDeProblema>
    {
        IEnumerable<TipoDeProblema> Filtrar(string nome);
        ValidationResult Gravar(TipoDeProblema entity);
        ValidationResult Excluir(int id);

    }
}