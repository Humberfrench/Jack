using Jack.Application.ViewModel;
using Jack.DomainValidator;
using System.Collections.Generic;

namespace Jack.Application.Interfaces
{
    public interface ITipoParentescoServiceApp : IServiceBaseApp<TipoParentescoViewModel>
    {
        IEnumerable<TipoParentescoViewModel> Filtrar(string nome);
        ValidationResult Gravar(TipoParentescoViewModel entity);
        ValidationResult Excluir(int id);
    }
}