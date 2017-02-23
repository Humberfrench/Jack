using System.Collections.Generic;
using Jack.Application.ViewModel;
using Jack.DomainValidator;

namespace Jack.Application.Interfaces
{
    public interface IFamiliaBlackListServiceApp : IServiceBase<FamiliaBlackListViewModel>
    {
        ValidationResult Gravar(FamiliaBlackListViewModel entity);
        ValidationResult Excluir(int id);
    }
}