using System.Collections.Generic;
using Jack.Application.ViewModel;
using Jack.DomainValidator;

namespace Jack.Application.Interfaces
{
    public interface IReuniaoServiceApp : IServiceBase<ReuniaoViewModel>
    {
        ValidationResult Gravar(ReuniaoViewModel entity);
        ValidationResult Excluir(int id);
        IEnumerable<ReuniaoViewModel> ObterReunioesNoAno();
        IEnumerable<ReuniaoViewModel> ObterReunioesNoAno(int ano);
    }
}