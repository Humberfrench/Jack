using System.Collections.Generic;
using Jack.Application.ViewModel;
using Jack.DomainValidator;

namespace Jack.Application.Interfaces
{
    public interface IPresencaJustificadaServiceApp : IServiceBase<PresencaJustificadaViewModel>
    {
        ValidationResult Gravar(PresencaJustificadaViewModel entity);
        ValidationResult Excluir(int id);
    }
}