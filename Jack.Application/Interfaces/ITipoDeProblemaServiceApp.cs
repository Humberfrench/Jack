using Jack.Application.ViewModel;
using Jack.DomainValidator;
using System.Collections.Generic;

namespace Jack.Application.Interfaces
{
    public interface ITipoDeProblemaServiceApp : IServiceBaseApp<TipoDeProblemaViewModel>
    {
        IEnumerable<TipoDeProblemaViewModel> Filtrar(string nome);
        ValidationResult Gravar(TipoDeProblemaViewModel entity);
        ValidationResult Excluir(int id);
    }
}
