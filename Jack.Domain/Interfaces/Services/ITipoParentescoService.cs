using Jack.Domain.Entity;
using Jack.DomainValidator;
using System.Collections.Generic;

namespace Jack.Domain.Interfaces.Services
{
    public interface ITipoParentescoService : IServiceBase<TipoParentesco>
    {
        IEnumerable<TipoParentesco> Filtrar(string nome);
        ValidationResult Gravar(TipoParentesco entity);
        ValidationResult Excluir(int id);
    }
}