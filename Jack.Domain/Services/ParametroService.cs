using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Repository;
using Jack.Domain.Interfaces.Services;
using Jack.DomainValidator;
using System.Linq;

namespace Jack.Domain.Services
{
    public class ParametroService : ServiceBaseReadOnly<Parametro>, IParametroService
    {

        private readonly IParametroRepository repStatus;
        private readonly ValidationResult validationResult = new ValidationResult();

        public ParametroService(IParametroRepository repStatus)
            : base(repStatus)
        {
            this.repStatus = repStatus;
        }

        public ValidationResult Gravar(Parametro item)
        {
            return validationResult;
        }

        public Parametro Obter()
        {
            return ObterTodos().FirstOrDefault();
        }
    }
}