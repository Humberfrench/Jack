using DomainValidation.Interfaces.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.Model.Specs
{
    class CriancaDataNascimentoValida : ISpecification<Criancas>
    {
        public bool IsSatisfiedBy(Criancas crianca)
        {
            DateTime dateToCompare = new DateTime();

            return crianca.DataNascimento.Date != dateToCompare;
        }
    }
}
