using Jack.Application.ViewModel;
using Jack.DomainValidator;
using System.Collections.Generic;

namespace Jack.Application.Interfaces
{
    public interface IStatusTratamentoServiceApp : IServiceBaseApp<StatusTratamentoViewModel>
    {
        IEnumerable<StatusTratamentoViewModel> Filtrar(string nome);
        ValidationResult Gravar(StatusTratamentoViewModel entity);
        ValidationResult Excluir(int id);
    }
}
