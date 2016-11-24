using System;
using System.Collections.Generic;
using System.Linq;
using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Repository;
using Jack.Repository.UnityOfWork;

namespace Jack.Repository
{
    public class FeriadoRepository   : Repository<Feriado>, IFeriadoRepository
    {
        private readonly IUnityOfWork UnitWork;
        public FeriadoRepository(IUnityOfWork unitWork)
            : base(unitWork)
        {
            UnitWork = unitWork;
        }

        public void Adicionar(Feriado entity)
        {
            UnitWork.Salvar(entity);
        }

        public void Atualizar(Feriado entity)
        {
            UnitWork.Salvar(entity);
        }

        public void Excluir(Feriado entity)
        {
            UnitWork.Excluir(entity);
        }

        public Feriado ObterPorId(int id)
        {
            return base.GetById(id);
        }

        public IEnumerable<Feriado> ObterTodos()
        {
           return base.GetAll();
        }

        public IEnumerable<Feriado> ObterPorAnoEfetivo(int ano)
        {
            return base.GetAll().Where(f => f.AnoEfetivo == ano);
        }

        public Feriado ObterFeriado(int ano, DateTime dataReuniao)
        {
            return GetAll().FirstOrDefault(f => f.ProximaReuniao == dataReuniao 
                                        && f.AnoEfetivo == ano);
        }

    }
}