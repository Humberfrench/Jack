using DomainValidation.Interfaces.Specification;
using System;

namespace Jack.Model.Specs
{
    public class CriancaPreenchidaSpecs : ISpecification<Criancas>
    {
        public bool IsSatisfiedBy(Criancas crianca)
        {
            return !string.IsNullOrEmpty(crianca.Nome) && !string.IsNullOrWhiteSpace(crianca.Nome);
        }
    }
}
