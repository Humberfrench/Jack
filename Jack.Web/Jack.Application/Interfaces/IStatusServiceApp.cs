using System.Collections.Generic;
using Jack.Application.ViewModel;
using Jack.DomainValidator;

namespace Jack.Application.Interfaces
{
    public interface IStatusServiceApp : IServiceBase<StatusViewModel>
    {
        IEnumerable<StatusViewModel> Filtrar(string nome);
        ValidationResult Gravar(StatusViewModel entity);
        ValidationResult Excluir(int id);
    }
}