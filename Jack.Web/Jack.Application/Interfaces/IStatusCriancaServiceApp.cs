using System.Collections.Generic;
using Jack.Application.ViewModel;
using Jack.DomainValidator;

namespace Jack.Application.Interfaces
{
    public interface IStatusCriancaServiceApp : IServiceBase<StatusCriancaViewModel>
    {
        IEnumerable<StatusCriancaViewModel> Filtrar(string nome);
        ValidationResult Gravar(StatusCriancaViewModel entity);
        ValidationResult Excluir(int id);
    }
}