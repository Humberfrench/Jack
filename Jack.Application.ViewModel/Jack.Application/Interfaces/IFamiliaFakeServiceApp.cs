using System.Collections.Generic;
using Jack.Application.ViewModel;
using Jack.DomainValidator;

namespace Jack.Application.Interfaces
{
    public interface IFamiliaFakeServiceApp : IServiceBase<FamiliaFakeViewModel>
    {
        ValidationResult Gravar(FamiliaFakeViewModel entity);
        ValidationResult Excluir(int id);
    }
}