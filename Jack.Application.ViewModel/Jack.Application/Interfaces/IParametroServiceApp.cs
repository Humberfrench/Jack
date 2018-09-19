using Jack.Application.ViewModel;
using Jack.DomainValidator;

namespace Jack.Application.Interfaces
{
    public interface IParametroServiceApp 
    {
        ParametroViewModel Obter();
        ValidationResult Gravar(ParametroViewModel item);
    }
}