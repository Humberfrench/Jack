using Jack.Application.ViewModel;
using Jack.DomainValidator;
using System.Collections.Generic;

namespace Jack.Application.Interfaces
{
    public interface ITratamentoServiceApp : IServiceBaseApp<TratamentoViewModel>
    {
        IEnumerable<TratamentoViewModel> Filtrar(string nome);
        IEnumerable<TratamentoViewModel> ObterTodos(int familiaId);
        ValidationResult Gravar(TratamentoViewModel entity);
        ValidationResult Excluir(int id);
    }
}