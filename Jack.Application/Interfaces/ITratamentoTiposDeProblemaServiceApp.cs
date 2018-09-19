using Jack.Application.ViewModel;
using Jack.DomainValidator;

namespace Jack.Application.Interfaces
{
    public interface ITratamentoTiposDeProblemaServiceApp : IServiceBaseApp<TratamentoTipoDeProblemaViewModel>
    {
        ValidationResult Gravar(TratamentoTipoDeProblemaViewModel entity);
        ValidationResult Excluir(int id);
    }
}