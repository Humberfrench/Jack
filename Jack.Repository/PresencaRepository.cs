using Dapper;
using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Repository;
using Jack.Repository.UnityOfWork;
using System.Collections.Generic;
using System.Linq;

namespace Jack.Repository
{
    public class PresencaRepository : Repository<Presenca>, IPresencaRepository
    {
        private readonly IUnityOfWork UnitWork;
        public PresencaRepository(IUnityOfWork unitWork)
            : base(unitWork)
        {
            UnitWork = unitWork;
        }

        public void Adicionar(Presenca entity)
        {
            UnitWork.Salvar(entity);
        }

        public void Atualizar(Presenca entity)
        {
            UnitWork.Salvar(entity);
        }

        public void Excluir(Presenca entity)
        {
            UnitWork.Excluir(entity);
        }

        public Presenca ObterPorId(int id)
        {
            return base.GetById(id);
        }

        public IEnumerable<Presenca> ObterTodos()
        {
            return base.GetAll();
        }

        public IEnumerable<Presenca> ObterFamiliaPorReuniao(int reuniao)
        {
            var sql = @"SELECT	p.*, f.*, r.*
						FROM	Presenca p
						JOIN	Familia f
						ON		p.Familia = f.Codigo
						JOIN	Reuniao r
						ON		p.Reuniao = r.Codigo
						WHERE	p.Reuniao = @reuniao)";
            var result = Conn.Query<Presenca, Familia, Reuniao, Presenca>(sql,
                (p, f, r) =>
                {
                    p.Familia = f;
                    p.Reuniao = r;
                    return p;
                },
                new { @reuniao = reuniao },
                splitOn: "p.Codigo,f.Codigo.r.Codigo"
                );
            return result;
        }

        public IEnumerable<Presenca> ObterFamiliaLivrePorReuniao(int reuniao)
        {
            var sql = @"SELECT	p.*, f.*, r.*
						FROM	Presenca p
						JOIN	Familia f
						ON		p.Familia = f.Codigo
						JOIN	Reuniao r
						ON		p.Reuniao = r.Codigo
						WHERE	f.Codigo NOT IN (
								SELECT	Familia
								FROM	Presenca
								WHERE	Reuniao = @reuniao)";
            var result = Conn.Query<Presenca, Familia, Reuniao, Presenca>(sql,
                (p, f, r) =>
                {
                    p.Familia = f;
                    p.Reuniao = r;
                    return p;
                },
                new { @reuniao = reuniao },
                splitOn: "p.Codigo,f.Codigo.r.Codigo");
            return result;
        }

        public IEnumerable<Familia> ObterFamiliasDisponiveis(int reuniao)
        {
            var sql = $@"SELECT	distinct Codigo, Nome
                         FROM	Familia 
                         WHERE	Codigo NOT IN(SELECT Familia 
					                         FROM	Presenca 
					                         WHERE	Reuniao = {reuniao})
                         AND Ativo = 1
                         ORDER BY Nome";
            var result = Conn.Query<Familia>(sql);
            return result;
        }

        public IEnumerable<Familia> ObterFamiliasDisponiveis(int reuniao, string letra)
        {
            var sql = $@"SELECT	distinct Codigo, Nome
                         FROM	Familia 
                         WHERE	Codigo NOT IN(SELECT Familia 
					                         FROM	Presenca 
					                         WHERE	Reuniao = {reuniao})
                         And		Nome like '{letra}%'
                        AND Ativo = 1
                        ORDER BY Nome";
            var result = Conn.Query<Familia>(sql);
            return result;
        }

        public int? ObterDadoPresencaExistente(int familia, int reuniao)
        {
            var sql = @"SELECT Codigo FROM Presenca 
						WHERE Reuniao = @reuniao
						AND   Familia = @familia";

            return Conn.Query<int?>(sql, new { @reuniao = reuniao, @familia = familia }).FirstOrDefault();
        }

        public IEnumerable<int> ObterTodosPorFamilia(int familia)
        {
            var sql = @"SELECT	distinct p.Reuniao
						FROM	Presenca p
						WHERE	p.Familia = @familia
						ORDER BY p.Reuniao";
            var result = Conn.Query<int>(sql, new { @familia = familia });

            return result;
        }
        public IEnumerable<int> ObterTodosPorFamilia(int familia, int ano)
        {
            var sql = $@"SELECT distinct Reuniao  
                        FROM Presenca p
                        WHERE Reuniao IN (SELECT Codigo FROM Reuniao
                        WHERE AnoCorrente = {ano})
						AND	p.Familia = {familia}
						ORDER BY p.Reuniao";
            var result = Conn.Query<int>(sql);

            return result;
        }
    }
}