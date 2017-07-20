using Jack.DomainValidator.Interfaces;
using Jack.Extensions;

namespace Jack.Domain.Specification.Colaborador
{
    public class DescricaoPreenchida : ISpecification<Entity.Colaborador>
    {
        public bool IsSatisfiedBy(Entity.Colaborador entidade) => !entidade.Nome.IsNullOrEmptyOrWhiteSpace();
    }
}