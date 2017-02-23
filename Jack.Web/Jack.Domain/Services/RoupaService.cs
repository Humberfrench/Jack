using System;
using System.Collections.Generic;
using System.Linq;
using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Repository;
using Jack.Domain.Interfaces.Services;
using Jack.Domain.ObjectValue;
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

        public RoupaValue ObterPorSexoIdade(int idade, string medidaIdade)
        {
            return repRoupa.ObterPorIdade(idade, medidaIdade);
        }
        public string ObterPorSexoIdade(int idade, string medidaIdade, bool criancaGrande)
        {
            return repRoupa.ObterPorIdade(idade, medidaIdade, criancaGrande);
        }
    }
}