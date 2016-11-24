using System.Collections.Generic;
using Jack.Application.ViewModel;
using Jack.DomainValidator;

namespace Jack.Application.Interfaces
{
    public interface IRepresentanteServiceApp : IServiceBase<RepresentanteViewModel>
    {
        ValidationResult Gravar(RepresentanteViewModel entity);
        ValidationResult Excluir(int id);
    }
}