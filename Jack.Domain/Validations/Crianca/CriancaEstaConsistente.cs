using Jack.Domain.Specification.Crianca;
using Jack.DomainValidator;

namespace Jack.Domain.Validations.Crianca
{
    public class CriancaEstaConsistente : Validator<Entity.Crianca>
    {
        public CriancaEstaConsistente()
        {
            var descricaoPreenchida = new DescricaoPreenchida();

            //implementação regras
            base.AdicionarRegra(nameof(descricaoPreenchida), new Rule<Entity.Crianca>(descricaoPreenchida, "Preencher a Descrição."));
        }
    }
}