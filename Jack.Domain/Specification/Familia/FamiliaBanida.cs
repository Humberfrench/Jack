using Jack.DomainValidator.Interfaces;
using Jack.Extensions;

namespace Jack.Domain.Specification.Familia
{
    public class FamiliaBanida : ISpecification<Entity.Familia>
    {
        public bool IsSatisfiedBy(Entity.Familia entidade) => entidade.Status.Codigo != Enum.EnumStatusFamilia.FamiliaBanidaPorProblemas.Int();
    }
}