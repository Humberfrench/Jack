using DomainValidation.Interfaces.Specification;

namespace Jack.Model.Specs
{
    class CriancaDeveTerMaeSpecs : ISpecification<Criancas>
    {
        public bool IsSatisfiedBy(Criancas crianca)
        {
            return crianca.Familia.Count > 1;
        }
    }
}
