using System.Collections.Generic;
using System.Linq;
using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Repository;
using Jack.Domain.Interfaces.Services;
using Jack.DomainValidator;

namespace Jack.Domain.Services
{
    public class SacolaService : ServiceBaseReadOnly<Sacola>, ISacolaService
    {

        private readonly ISacolaRepository repository;
        private readonly ValidationResult validationResult = new ValidationResult();

        public SacolaService(ISacolaRepository repository)
            : base(repository)
        {
            this.repository = repository;
        }

    }
}