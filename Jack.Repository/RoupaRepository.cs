using System;
using System.Collections.Generic;
using System.Linq;
using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Repository;
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

        //public Tuple<string,string> ObterPorSexoIdade(string sexo, int idade, string medidaIdade)
        //{
        //    var roupa = GetAll().FirstOrDefault(dado => dado.Idade <= idade
        //                                                && dado.MedidaIdade == medidaIdade);
            
        //    var retorno = new Tuple<string,string>("99","99");

        //    if (roupa == null)
        //    {
        //        return retorno;
        //    }
        //    retorno =  new Tuple<string, string>(roupa.Tamanho, roupa.TamanhoMaior);
        //    return retorno;
        //}
        public dynamic ObterPorSexoIdade(string sexo, int idade, string medidaIdade)
        {
            var roupa = GetAll().FirstOrDefault(dado => dado.Idade <= idade
                                                        && dado.MedidaIdade == medidaIdade);

            var retorno = new { Roupa = "99", RoupaGrande = "99" };

            if (roupa == null)
            {
                return retorno;
            }
            retorno =  new { Roupa = roupa.Tamanho,RoupaGrande =  roupa.TamanhoMaior};
            return retorno;
        }

    }
}