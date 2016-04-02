using DomainValidation.Interfaces.Specification;
using System;

namespace Jack.Model.Specs
{
    public class FamiliaMaePreenchidaSpecs : ISpecification<Familia>
    {
        public bool IsSatisfiedBy(Familia familia)
        {
            return !string.IsNullOrEmpty(familia.Nome) && !string.IsNullOrWhiteSpace(familia.Nome);
        }
    }
}
