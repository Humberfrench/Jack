using System.Collections.Generic;
using System.Linq;
using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Repository;
using Jack.Repository.UnityOfWork;

namespace Jack.Repository
{
    public class NivelRepository   : Repository<Nivel>, INivelRepository
    {
        private readonly IUnityOfWork UnitWork;
        public NivelRepository(IUnityOfWork unitWork)
            : base(unitWork)
        {
            UnitWork = unitWork;
        }

        public void Adicionar(Nivel entity)
        {
            UnitWork.Salvar(entity);
        }

        public void Atualizar(Nivel entity)
        {
            UnitWork.Salvar(entity);
        }

        public void Excluir(Nivel entity)
        {
            UnitWork.Excluir(entity);
        }

        public Nivel ObterPorId(int id)
        {
            return base.GetById(id);
        }

        public IEnumerable<Nivel> ObterTodos()
        {
           return base.GetAll();
        }

        public Nivel ObterNivelPorFaixaPresencial(float percPresenca)
        {
            var nivel = GetAll().FirstOrDefault(nvl => nvl.PercentualInicial <= percPresenca
                                                        && nvl.PercentualFinal >= percPresenca);

            if (nivel == null)
            {
                nivel = GetById(99);
            }
            return nivel;
        }
    }
}