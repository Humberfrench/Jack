using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using Dapper;
using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Repository;
using Jack.Extensions;
using Jack.Repository.UnityOfWork;

namespace Jack.Repository
{
    public class ReuniaoRepository   : Repository<Reuniao>, IReuniaoRepository
    {
        private readonly IUnityOfWork UnitWork;
        public ReuniaoRepository(IUnityOfWork unitWork)
            : base(unitWork)
        {
            UnitWork = unitWork;
        }

        public void Adicionar(Reuniao entity)
        {
            UnitWork.Salvar(entity);
        }

        public void Atualizar(Reuniao entity)
        {
            UnitWork.Salvar(entity);
        }

        public void Excluir(Reuniao entity)
        {
            UnitWork.Excluir(entity);
        }

        public Reuniao ObterPorId(int id)
        {
            return base.GetById(id);
        }

        public IEnumerable<Reuniao> ObterTodos()
        {
           return base.GetAll();
        }

        public bool ExisteData(DateTime data)
        {
            var sql = @"SELECT * FROM Reuniao WHERE convert(varchar(8), Data ,112) =" + data.ToAnsiDate();

            var dado = Conn.Query<Reuniao>(sql).ToList();

            return dado.Count > 0;
        }

        public IEnumerable<Reuniao> ObterTodosAteHoje(int ano, DateTime data)
        {
            var sql = @"SELECT  * 
                        FROM    Reuniao 
                        WHERE   AnoCorrente = @ano
                        AND     convert(varchar(8), Data ,112) = @data";

            var dado = Conn.Query<Reuniao>(sql, new { ano = ano, data = data.ToAnsiDate() }).ToList();

            return dado;
        }

    }
}