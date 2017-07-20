using Jack.Domain.Specification.Familia;
using Jack.DomainValidator;

namespace Jack.Domain.Validations.Familia
{
    public class FamiliaEstaConsistente : Validator<Entity.Familia>
    {
        public FamiliaEstaConsistente()
        {
            var descricaoPreenchida = new DescricaoPreenchida();
            var familiBanida = new FamiliaBanida();


            //implementação regras
            base.AdicionarRegra(nameof(descricaoPreenchida), new Rule<Entity.Familia>(descricaoPreenchida, "Preencher a Descrição."));
            base.AdicionarRegra(nameof(familiBanida), new Rule<Entity.Familia>(familiBanida, "Família Banida, não pode ser alterada."));
        }
    }
}