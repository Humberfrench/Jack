using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainValidation;
using DomainValidation.Validation;
using Jack.Model.Specs;

namespace Jack.Model.Validations
{
    public class FamiliaValidValidation  : Validator<Familia>
    {
        public FamiliaValidValidation()
        {
            Rule <Familia> rulaFamilia = new Rule<Familia>(new FamiliaMaePreenchidaSpecs(), 
                                                           "Mãe não pode ser nulo ou vazio");


            base.Add("FamiliaMaePreenchidaSpecs", rulaFamilia);

        }
    }
}
