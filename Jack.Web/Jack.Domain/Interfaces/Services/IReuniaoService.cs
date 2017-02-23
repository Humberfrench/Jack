using System.Collections.Generic;
using Jack.Domain.Entity;
using Jack.DomainValidator;

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