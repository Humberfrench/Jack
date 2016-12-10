using System.Collections.Generic;
using Jack.Application.ViewModel;
using Jack.DomainValidator;

namespace Jack.Application.Interfaces
{
    public interface IPresencaServiceApp : IServiceBase<PresencaViewModel>
    {
        ValidationResult Gravar(int reuniao, int familia);
        ValidationResult Excluir(int id);
        List<StatsViewModel> ObterDadosPresenca(int familiaId);
        IEnumerable<FamiliaViewModel> ObterFamiliasDisponiveis(int reuniao);
        IEnumerable<FamiliaViewModel> ObterFamiliasDisponiveis(int reuniao, string letra);
    }
}             
