using Jack.Application.ViewModel;
using Jack.DomainValidator;
using System.Collections.Generic;

namespace Jack.Application.Interfaces
{
    public interface IPresencaServiceApp : IServiceBaseApp<PresencaViewModel>
    {
        ValidationResult Gravar(int reuniao, int familia);
        ValidationResult Gravar(ReuniaoViewModel reuniao, FamiliaViewModel familia);
        ValidationResult Excluir(int id);
        List<StatsViewModel> ObterDadosPresenca(int familiaId);
        IEnumerable<FamiliaViewModel> ObterFamiliasDisponiveis(int reuniao);
        IEnumerable<FamiliaViewModel> ObterFamiliasDisponiveis(int reuniao, string letra);
        ValidationResult ProcessarPresencaGarantida();
    }
}
