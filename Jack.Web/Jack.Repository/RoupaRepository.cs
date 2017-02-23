using System;
using System.Collections.Generic;
using System.Linq;
using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Repository;
using Jack.Domain.ObjectValue;
using Jack.Repository.UnityOfWork;

namespace Jack.Repository
{
    public class RoupaRepository : Repository<Roupa>, IRoupaRepository
    {
        private readonly IUnityOfWork UnitWork;
        public RoupaRepository(IUnityOfWork unitWork)
            : base(unitWork)
        {
            UnitWork = unitWork;
        }

        public Roupa ObterPorId(int id)
        {
            return base.GetById(id);
        }

        public IEnumerable<Roupa> ObterTodos()
        {
           return base.GetAll();
        }

        public RoupaValue ObterPorIdade(int idade, string medidaIdade)
        {
            var roupa = GetAll().FirstOrDefault(dado => dado.Idade == idade
                                                        && dado.MedidaIdade == medidaIdade);

            var retorno = new RoupaValue { Roupa = "99", RoupaGrande = "99" };

            if (roupa == null)
            {
                return retorno;
            }
            retorno = new RoupaValue { Roupa = roupa.Tamanho, RoupaGrande = roupa.TamanhoMaior };
            return retorno;
        }
        public string ObterPorIdade(int idade, string medidaIdade, bool isCriancaGrande)
        {
            var roupa = GetAll().FirstOrDefault(dado => dado.Idade == idade
                                                        && dado.MedidaIdade == medidaIdade);

            var retorno = "99";

            if (roupa == null)
            {
                return retorno;
            }

            retorno = roupa.Tamanho;

            if (isCriancaGrande)
            {
                retorno = roupa.TamanhoMaior;
            }

            return retorno;
        }

    }
}