using System.Collections.Generic;
using Jack.Domain.Entity;
using Jack.Domain.Enum;
using Jack.DomainValidator;

namespace Jack.Domain.Interfaces.Services
{
    public interface IRepresentanteService : IServiceBase<Representante>
    {
        ValidationResult Gravar(int familiaRepresentante, int familiaRepresentada, int tipoParentesco);
        ValidationResult Gravar(int codigo, int tipoParentesco, bool ativo); ValidationResult Ativar(int id);
        ValidationResult Desativar(int id);
        ValidationResult Gravar(Representante representante);
        ValidationResult Excluir(int id);
        IEnumerable<Familia> ObterFamilias(int familia);
    }
}