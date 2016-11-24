using System.Collections.Generic;
using Jack.Application.ViewModel;
using Jack.DomainValidator;

namespace Jack.Application.Interfaces
{
    public interface IKitItemServiceApp : IServiceBase<KitItemViewModel>
    {
        ValidationResult Gravar(KitItemViewModel entity);
        ValidationResult Excluir(int id);
    }
}