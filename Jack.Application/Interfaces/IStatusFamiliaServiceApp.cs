using Jack.Application.ViewModel;
using Jack.DomainValidator;
using System.Collections.Generic;

namespace Jack.Application.Interfaces
{
    public interface IStatusFamiliaServiceApp : IServiceBase<StatusFamiliaViewModel>
    {
        IEnumerable<StatusFamiliaViewModel> Filtrar(string nome);
        ValidationResult Gravar(StatusFamiliaViewModel entity);
        ValidationResult Excluir(int id);
    }
}