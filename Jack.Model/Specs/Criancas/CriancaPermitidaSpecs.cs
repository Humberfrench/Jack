using DomainValidation.Interfaces.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.Model.Specs
{
    public class CriancaPermitidaSpecs : ISpecification<Criancas>
    {
        public bool IsSatisfiedBy(Criancas crianca)
        {
            return !IdadePermitida(crianca.DataNascimento) && (crianca.IsMoralCrista == "N");
        }

        private bool IdadePermitida(DateTime dataNasc)
        {
            DateTime dataBase = new DateTime(DateTime.Now.Year, 12, 31);
            int anos = dataBase.Year - dataNasc.Year;

            if (dataBase.Month < dataNasc.Month || (dataBase.Month == dataNasc.Month && dataBase.Day < dataNasc.Day))
                anos--;

            return (anos < 11);
        }
    }
}
