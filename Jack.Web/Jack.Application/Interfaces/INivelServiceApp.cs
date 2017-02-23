using System.Collections.Generic;
using Jack.Application.ViewModel;
using Jack.DomainValidator;

namespace Jack.Application.Interfaces
{
    public interface INivelServiceApp : IServiceBase<NivelViewModel>
    {
        IEnumerable<NivelViewModel> Filtrar(string nome);
        ValidationResult Gravar(NivelViewModel entity);
        ValidationResult Excluir(int id);
    }
}