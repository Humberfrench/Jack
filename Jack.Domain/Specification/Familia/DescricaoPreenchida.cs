using Jack.DomainValidator.Interfaces;
using Jack.Extensions;

namespace Jack.Domain.Specification.Familia
{
    public class DescricaoPreenchida : ISpecification<Entity.Familia>
    {
        public bool IsSatisfiedBy(Entity.Familia entidade) => !entidade.Nome.IsNullOrEmptyOrWhiteSpace();
    }
}