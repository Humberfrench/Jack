using Jack.Application.ViewModel;
using Jack.DomainValidator;
using System.Collections.Generic;

namespace Jack.Application.Interfaces
{
    public interface IKitItemServiceApp : IServiceBaseApp<KitItemViewModel>
    {
        ValidationResult Gravar(KitItemViewModel entity);
        ValidationResult Excluir(int id);
        IEnumerable<KitItemViewModel> ObterTodos(int id);
    }
}