using Jack.Domain.Entity;
using Jack.DomainValidator;

namespace Jack.Domain.Interfaces.Services
{
    public interface IParametroService : IServiceBaseReadOnly<Parametro>
    {
        Parametro Obter();
        ValidationResult Gravar(Parametro item);
    }
}