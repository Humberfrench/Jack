using System.Collections.Generic;
using System.Linq;
using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Repository;
using Jack.Domain.Interfaces.Services;
using Jack.DomainValidator;

namespace Jack.Domain.Services
{
    public class CalcadoService : ServiceBaseReadOnly<Calcado>, ICalcadoService
    {

        private readonly ICalcadoRepository repCalcado;
        private readonly ValidationResult validationResult = new ValidationResult();

        public CalcadoService(ICalcadoRepository repCalcado)
            : base(repCalcado)
        {
            this.repCalcado = repCalcado;
        }

        public Calcado ObterCalcadoCrianca(int idade,  string medidaIdade, string sexo)
        {
            var calcados = ObterTodos();

            return calcados.FirstOrDefault(c => c.Sexo == sexo
                                        && c.MedidaIdade == medidaIdade
                                        && c.Inicio <= idade
                                        && c.Fim >= idade);
        }

        public IEnumerable<Calcado> ObterPorSexo(string sexo)
        {
            return repCalcado.ObterPorSexo(sexo);
        }

    }
}