using System.Collections.Generic;
using Jack.Domain.Entity;
using Jack.DomainValidator;

namespace Jack.Domain.Interfaces.Services
{
    public interface IPresencaJustificadaService : IServiceBase<PresencaJustificada>
    {
        ValidationResult Gravar(PresencaJustificada entity);
        ValidationResult Excluir(int id);
        ValidationResult Gravar(int familiaId);
        ValidationResult ProcessaPresenca(int reuniao);
        ValidationResult ProcessaPresencaNoAno(int ano);
    }
}