using Jack.Application.ViewModel;
using Jack.DomainValidator;
using System.Collections.Generic;

namespace Jack.Application.Interfaces
{
    public interface IStatusCriancaServiceApp : IServiceBase<StatusCriancaViewModel>
    {
        IEnumerable<StatusCriancaViewModel> Filtrar(string nome);
        ValidationResult Gravar(StatusCriancaViewModel entity);
        ValidationResult Excluir(int id);
    }
}