using Jack.Domain.Entity;
using Jack.DomainValidator;
using System.Collections.Generic;

namespace Jack.Domain.Interfaces.Services
{
    public interface IStatusFamiliaService : IServiceBase<StatusFamilia>
    {
        IEnumerable<StatusFamilia> Filtrar(string nome);
        ValidationResult Gravar(StatusFamilia entity);
        ValidationResult Excluir(int id);
    }
}