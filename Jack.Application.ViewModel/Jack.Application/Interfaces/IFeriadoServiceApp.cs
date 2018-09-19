using Jack.Application.ViewModel;
using Jack.DomainValidator;
using System.Collections.Generic;

namespace Jack.Application.Interfaces
{
    public interface IFeriadoServiceApp : IServiceBase<FeriadoViewModel>
    {
        IEnumerable<FeriadoViewModel> Filtrar(string nome);
        ValidationResult Gravar(FeriadoViewModel entity);
        ValidationResult Excluir(int id);
    }
}