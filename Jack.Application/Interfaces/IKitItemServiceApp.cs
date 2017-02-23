using Jack.Application.ViewModel;
using Jack.DomainValidator;
using System.Collections.Generic;

namespace Jack.Application.Interfaces
{
    public interface IKitItemServiceApp : IServiceBase<KitItemViewModel>
    {
        ValidationResult Gravar(KitItemViewModel entity);
        ValidationResult Excluir(int id);
        IEnumerable<KitItemViewModel> ObterTodos(int id);
    }
}