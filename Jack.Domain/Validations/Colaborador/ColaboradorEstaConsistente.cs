using Jack.Domain.Specification.Colaborador;
using Jack.DomainValidator;

namespace Jack.Domain.Validations.Colaborador
{
    public class ColaboradorEstaConsistente : Validator<Entity.Colaborador>
    {
        public ColaboradorEstaConsistente()
        {
            var descricaoPreenchida = new DescricaoPreenchida();

            //implementação regras
            base.AdicionarRegra(nameof(descricaoPreenchida), new Rule<Entity.Colaborador>(descricaoPreenchida, "Preencher a Descrição."));
        }
    }
}