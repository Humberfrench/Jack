using Jack.DomainValidator.Interfaces;
using Jack.Extensions;

namespace Jack.Domain.Specification.Crianca
{
    public class DescricaoPreenchida : ISpecification<Entity.Crianca>
    {
        public bool IsSatisfiedBy(Entity.Crianca entidade) => !entidade.Nome.IsNullOrEmptyOrWhiteSpace();
    }
}