using System.Collections.Generic;
using Jack.Application.ViewModel;
using Jack.DomainValidator;

namespace Jack.Application.Interfaces
{
    public interface IFamiliaServiceApp : IServiceBase<FamiliaViewModel>
    {
        IEnumerable<FamiliaViewModel> Filtrar(string nome);
        ValidationResult Gravar(FamiliaViewModel entity);
        ValidationResult Gravar(FamiliaViewModel entity, int reuniao);
        ValidationResult Excluir(int id);
        ValidationResult AtualizarFamilia(int id, bool gravar = true);
    }
}