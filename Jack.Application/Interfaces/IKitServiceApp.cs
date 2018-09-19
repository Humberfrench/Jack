using Jack.Application.ViewModel;
using Jack.DomainValidator;
using System.Collections.Generic;

namespace Jack.Application.Interfaces
{
    public interface IKitServiceApp : IServiceBaseApp<KitViewModel>
    {
        IEnumerable<KitViewModel> Filtrar(string nome);
        ValidationResult Gravar(KitViewModel entity);
        ValidationResult Excluir(int id);
    }
}