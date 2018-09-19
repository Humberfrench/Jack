using Jack.Application.ViewModel;
using Jack.DomainValidator;
using System.Collections.Generic;

namespace Jack.Application.Interfaces
{
    public interface IFamiliaServiceApp : IServiceBaseApp<FamiliaViewModel>
    {
        IEnumerable<FamiliaViewModel> ObterNaoSacolas();
        IEnumerable<FamiliaViewModel> ObterTodosTratamento();
        IEnumerable<FamiliaViewModel> ObterPorStatus(int status);
        IEnumerable<FamiliaViewModel> Filtrar(string nome);
        string ObterRepresentante(int familiaId);
        ValidationResult Gravar(FamiliaViewModel entity);
        ValidationResult Gravar(FamiliaViewModel entity, int reuniao);
        ValidationResult Excluir(int id);
        ValidationResult AtualizarFamilia(int id, bool gravar = true);
        ValidationResult AtualizarPresencas(FamiliaViewModel familia);
        IEnumerable<FamiliaViewModel> ObterFamiliasBanidas();
        ValidationResult AtualizarFamiliaParaBanida(int familiaId);
        ValidationResult LiberarFamiliaBanida(int familiaId);
        ValidationResult AtualizarSimSacola(int familiaId);
        ValidationResult AtualizarFamiliaComPresencaParaRepresentantes(int id, bool gravar = true);
    }
}