using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Repository;
using Jack.Extensions;
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

        //public Feriado ObterFeriado(int ano, DateTime dataReuniao)
        //{
        //    return GetAll().FirstOrDefault(f => f.ProximaReuniao == dataReuniao 
        //                                && f.AnoEfetivo == ano);
        //}

        public Feriado ObterFeriado(DateTime dataReuniao)
        {
            var sql = @"SELECT * FROM Feriado 
            WHERE convert(varchar(8), Data ,112) = @data";

            var dado = Conn.Query<Feriado>(sql, new { @data = dataReuniao.ToAnsiDate()});

            return dado.FirstOrDefault();
        }

        public Feriado ObterFeriadoAntesOuDepois(DateTime data)
        {
            var sql = @"SELECT * FROM Feriado 
            WHERE convert(varchar(8), ReuniaoAnterior ,112) = @data
            OR    convert(varchar(8), ProximaReuniao ,112)  = @data";

            var dado = Conn.Query<Feriado>(sql, new { @data = data.ToAnsiDate() });

            return dado.FirstOrDefault();
        }

    }
}