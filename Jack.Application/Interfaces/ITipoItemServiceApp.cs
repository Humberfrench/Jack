using Jack.Application.ViewModel;
using Jack.DomainValidator;
using System.Collections.Generic;

namespace Jack.Application.Interfaces
{
    public interface ITipoItemServiceApp : IServiceBaseApp<TipoItemViewModel>
    {
        IEnumerable<TipoItemViewModel> Filtrar(string nome);
        ValidationResult Gravar(TipoItemViewModel entity);
        ValidationResult Excluir(int id);
    }
}