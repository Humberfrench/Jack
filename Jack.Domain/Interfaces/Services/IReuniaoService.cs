using Jack.Domain.Entity;
using Jack.DomainValidator;
using System.Collections.Generic;

namespace Jack.Domain.Interfaces.Services
{
    public interface IReuniaoService : IServiceBase<Reuniao>
    {
        ValidationResult Gravar(Reuniao entity);
        ValidationResult Excluir(int id);
        ValidationResult MontarDataReuniao(int ano);
        IEnumerable<Reuniao> ObterReunioesNoAno();
        IEnumerable<Reuniao> ObterReunioesNoAno(int ano);
    }
}