using System.Collections.Generic;
using Jack.Application.ViewModel;
using Jack.DomainValidator;

namespace Jack.Application.Interfaces
{
    public interface ICriancaServiceApp : IServiceBase<CriancaViewModel>
    {
        IEnumerable<CriancaViewModel> ObterCriancas(int familia);
        ValidationResult Gravar(CriancaViewModel entity);
        ValidationResult Excluir(int id);
    }
}