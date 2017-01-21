using System.Collections.Generic;
using Jack.Application.ViewModel;
using Jack.DomainValidator;

namespace Jack.Application.Interfaces
{
    public interface ITipoParentescoServiceApp : IServiceBase<TipoParentescoViewModel>
    {
        IEnumerable<TipoParentescoViewModel> Filtrar(string nome);
        ValidationResult Gravar(TipoParentescoViewModel entity);
        ValidationResult Excluir(int id);
    }
}