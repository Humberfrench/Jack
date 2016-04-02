using DomainValidation.Validation;
using Jack.Model.Specs;

namespace Jack.Model.Validations
{
    public class CriancaValidValidation : Validator<Criancas>
    {
        public CriancaValidValidation()
        {
            Rule<Criancas> ruleCriancasVazia = new Rule<Criancas>(new CriancaPreenchidaSpecs(), 
                                                             "Criança não pode ser nulo ou vazio");
            Rule<Criancas> ruleCriancasPermitida = new Rule<Criancas>(new CriancaPermitidaSpecs(), 
                                                             "Criança não permitida para Sacolinha. Criançã maior de 10 anos, não matriculada na Escolinha.");

            Rule<Criancas> ruleCriancaDeveTerMae = new Rule<Criancas>(new CriancaDeveTerMaeSpecs(), 
                                                             "Criança deve estar vinculada à mãe.");


            base.Add("CriancaPreenchidaSpecs", ruleCriancasVazia);
            base.Add("CriancaPermitidaSpecs", ruleCriancasPermitida);
            base.Add("CriancaDeveTerMaeSpecs", ruleCriancaDeveTerMae);

        }
    }
}
