using System.Collections.Generic;
using Jack.Application.ViewModel;
using Jack.DomainValidator;

namespace Jack.Application.Interfaces
{
    public interface IFeriadoServiceApp : IServiceBase<FeriadoViewModel>
    {
        IEnumerable<FeriadoViewModel> Filtrar(string nome);
        ValidationResult Gravar(FeriadoViewModel entity);
        ValidationResult Excluir(int id);
    }
}