using Jack.Application.ViewModel;
using Jack.DomainValidator;
using System.Collections.Generic;

namespace Jack.Application.Interfaces
{
    public interface IReuniaoServiceApp : IServiceBaseApp<ReuniaoViewModel>
    {
        ValidationResult Gravar(ReuniaoViewModel entity);
        ValidationResult Excluir(int id);
        IEnumerable<ReuniaoViewModel> ObterReunioesNoAno();
        IEnumerable<ReuniaoViewModel> ObterReunioesNoAno(int ano);
        ValidationResult MontarDataReuniao(int ano);
    }
}