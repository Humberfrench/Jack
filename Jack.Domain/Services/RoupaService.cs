using System;
using System.Collections.Generic;
using System.Linq;
using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Repository;
using Jack.Domain.Interfaces.Services;
using Jack.DomainValidator;

namespace Jack.Domain.Services
{
    public class RoupaService : ServiceBaseReadOnly<Roupa>, IRoupaService
    {

        private readonly IRoupaRepository repRoupa;
        private readonly ValidationResult validationResult = new ValidationResult();

        public RoupaService(IRoupaRepository repository)
            : base(repository)
        {
            this.repRoupa = repository;
        }

        //public Tuple<string, string> ObterPorSexoIdade(string sexo, int idade, string medidaIdade)
        //{
        //    return repRoupa.ObterPorSexoIdade(sexo,idade,medidaIdade);
        //}

        public dynamic ObterPorSexoIdade(string sexo, int idade, string medidaIdade)
        {
            return repRoupa.ObterPorSexoIdade(sexo,idade,medidaIdade);
        }
    }
}