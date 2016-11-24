using System.Collections.Generic;
using System.Linq;
using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Repository;
using Jack.Repository.UnityOfWork;

namespace Jack.Repository
{
    public class CalcadoRepository : Repository<Calcado>, ICalcadoRepository
    {
        private readonly IUnityOfWork UnitWork;
        public CalcadoRepository(IUnityOfWork unitWork)
            : base(unitWork)
        {
            UnitWork = unitWork;
        }

        public Calcado ObterPorId(int id)
        {
            return GetById(id);
        }

        public IEnumerable<Calcado> ObterTodos()
        {
           return GetAll();
        }
        public IEnumerable<Calcado> ObterPorSexo(string sexo)
        {
            return GetAll().Where(dado => dado.Sexo == sexo);
        }
        public int ObterPorSexoIdade(string sexo, int idade, string medidaIdade)
        {
            var calcado =  GetAll().FirstOrDefault(dado => dado.Sexo == sexo 
                                                        && dado.Inicio <= idade 
                                                        && dado.Fim >= idade
                                                        && dado.MedidaIdade == medidaIdade);

            if (calcado == null)
            {
                return 99;    
            }
            return calcado.Numero;
        }
    }
}