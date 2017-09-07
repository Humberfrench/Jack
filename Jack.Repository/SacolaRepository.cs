using Dapper;
using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Repository;
using Jack.Repository.UnityOfWork;
using System.Collections.Generic;
using System.Linq;

namespace Jack.Repository
{
    public class SacolaRepository : BaseRepository<Sacola>, ISacolaRepository
    {
        private readonly IUnityOfWork UnitWork;
        public SacolaRepository(IUnityOfWork unitWork)
            : base(unitWork)
        {
            UnitWork = unitWork;
        }

        public Sacola ObterSacolaPorCrianca(int crianca)
        {
            var sacola = ObterTodos().FirstOrDefault(sac => sac.Crianca.Codigo == crianca);
            return sacola;
        }

        public IEnumerable<Sacola> ObterSacolaParaImpressao(string sacolasNumero, int ano)
        {
            var sacola = ObterTodos();
            return sacola;
        }

        public IEnumerable<Familia> ObterFamilias(int nivel)
        {
            var sql = $@"SELECT	Distinct f.Codigo, f.Nome
                        FROM	Familia f
                        Join	Sacolas s
                        ON		f.Codigo = s.Familia
                        AND		s.Nivel = {nivel}
                        ORDER BY f.Nome";

            var familias = Conn.Query<Familia>(sql);

            return familias;
        }
        public IEnumerable<Sacola> PesquisarSacolas(int ano, int familia, int kit, int nivel)
        {
            var sacola = ObterTodos().ToList();

            if (familia != 0)
            {
                sacola = sacola.Where(s => s.Familia.Codigo == familia).ToList();
            }

            if (kit != 0)
            {
                sacola = sacola.Where(s => s.Kit.Codigo == kit).ToList();
            }

            if (nivel != 0)
            {
                sacola = sacola.Where(s => s.Nivel.Codigo == nivel).ToList();
            }

            sacola.ForEach(s => s.Crianca.Colaboradores = s.Crianca.Colaboradores.Where(c => c.Ano == ano).ToList());
            return sacola;
        }

        //public IEnumerable<SacolaValue> ObterSacolaParaImpressao(string sacolasNumero, int ano)
        // {
        //     var sql = $@"SELECT		sac.Codigo as Numero, sac.SacolaFamilia  as SacolaFamilia, sac.Familia as Familia, 
        //                    sac.FamiliaRepresentante as Representante, sac.Crianca as Crianca, sac.Sexo as Sexo, 
        //                    sac.Kit as Kit, fam.Nome as NomeFamilia, famRep.Nome as NomeRepresentante, 
        //                    cri.Nome as NomeCrianca, cri.Calcado as Calcado, cri.Roupa as Roupa, 
        //                    cri.IdadeNominal as IdadeNominal, col.Nome as Colaborador , kit.Codigo as Kit, 
        //                    kit.Descricao as KitNome, kitem.Ordem as Ordem, kitem.Observacao as Observacao, 
        //                    titem.Descricao as Item, 
        //                    titem.Opcional as Opcional
        //                 From		Sacolas sac
        //                 JOIN		Familia fam
        //                 ON			sac.Familia = fam.Codigo
        //                 JOIN		Familia famRep
        //                 ON			sac.FamiliaRepresentante = famRep.Codigo
        //                 JOIN		Crianca cri
        //                 ON			sac.Crianca = cri.Codigo
        //                 LEFT JOIN	ColaboradorCrianca colCri
        //                 ON			sac.Crianca = colCri.Crianca
        //                 LEFT JOIN	Colaborador col
        //                 ON			col.Codigo = colCri.Colaborador
        //                 JOIN		Kit kit
        //                 ON			sac.Kit = kit.Codigo
        //                 JOIN		KitItem kitem
        //                 ON			kitem.Kit = Kit.Codigo
        //                 JOIN		TipoItem titem
        //                 ON			kitem.TipoItem = titem.Codigo
        //                 WHERE		colCri.Ano = {ano} 
        //                 AND sac.Codigo IN ({sacolasNumero})";

        //     var sacolas = Conn.Query<SacolaValue, ItemValue, SacolaValue>(sql,
        //         (s, i) =>
        //             {
        //                 s.Itens = new List<ItemValue>
        //                 {
        //                     i
        //                 };
        //                 return s;

        //             },
        //             splitOn: "SacolaFamilia, Kit");


        //     return sacolas;
        // }

        // public IEnumerable<Sacola> PesquisarSacolas(int ano, int familia, int kit, int nivel)
        // {
        //     var sql = $@"SELECT		sac.*, fam.*, famRep.*,cri.*, col.*, kit.*
        //                 From		Sacolas sac
        //                 JOIN		Familia fam
        //                 ON			sac.Familia = fam.Codigo
        //                 JOIN		Familia famRep
        //                 ON			sac.FamiliaRepresentante = famRep.Codigo
        //                 JOIN		Crianca cri
        //                 ON			sac.Crianca = cri.Codigo
        //                 LEFT JOIN	ColaboradorCrianca colCri
        //                 ON			sac.Crianca = colCri.Crianca
        //                 LEFT JOIN	Colaborador col
        //                 ON			col.Codigo = colCri.Colaborador
        //                 JOIN		Kit kit
        //                 ON			sac.Kit = kit.Codigo
        //                 WHERE		colCri.Ano = {ano} ";

        //     if (familia != 0)
        //     {
        //         var familiaParam = $" AND         sac.Familia = {familia} ";
        //         sql = sql + familiaParam;
        //     }
        //     if (kit != 0)
        //     {
        //         var kitParam = $" AND         cri.Kit = {kit} ";
        //         sql = sql + kitParam;
        //     }
        //     if (nivel != 0)
        //     {
        //         var nivelParam = $" AND         sac.Nivel = {nivel} ";
        //         sql = sql + nivelParam;
        //     }

        //     sql = sql + " ORDER BY Numero, Ordem";

        //     var sacolas = Conn.Query<Sacola, Familia, Familia, Crianca, Colaborador, Kit, Sacola>(
        //         sql, 
        //         (sac, fam, rep, cri,col, kt) =>
        //         {
        //             sac.Crianca = cri;
        //             sac.Familia = fam;
        //             sac.FamiliaRepresentante = rep;
        //             sac.Kit = kt;
        //             return sac;
        //         },  "");

        //     return sacolas;
        // }
        // public IEnumerable<SacolaValue> PesquisarSacolas2(int ano, int familia, int kit, int nivel)
        // {
        //     var sql = $@"SELECT		sac.Codigo as Numero, sac.SacolaFamilia  as SacolaFamilia, sac.Familia as Familia, 
        //                    sac.FamiliaRepresentante as Representante, sac.Crianca as Crianca, sac.Sexo as Sexo, 
        //                    sac.Kit as Kit, fam.Nome as NomeFamilia, famRep.Nome as NomeRepresentante, 
        //                    cri.Nome as NomeCrianca, cri.Calcado as Calcado, cri.Roupa as Roupa, 
        //                    cri.IdadeNominal as IdadeNominal, col.Nome as Colaborador, kit.Descricao as KitNome,
        //                    kit.Codigo as Kit, kitem.Ordem as Ordem, kitem.Observacao as Observacao, 
        //                    titem.Descricao as Item, 
        //                    titem.Opcional as Opcional
        //                 From		Sacolas sac
        //                 JOIN		Familia fam
        //                 ON			sac.Familia = fam.Codigo
        //                 JOIN		Familia famRep
        //                 ON			sac.FamiliaRepresentante = famRep.Codigo
        //                 JOIN		Crianca cri
        //                 ON			sac.Crianca = cri.Codigo
        //                 LEFT JOIN	ColaboradorCrianca colCri
        //                 ON			sac.Crianca = colCri.Crianca
        //                 LEFT JOIN	Colaborador col
        //                 ON			col.Codigo = colCri.Colaborador
        //                 JOIN		Kit kit
        //                 ON			sac.Kit = kit.Codigo
        //                 JOIN		KitItem kitem
        //                 ON			kitem.Kit = Kit.Codigo
        //                 JOIN		TipoItem titem
        //                 ON			kitem.TipoItem = titem.Codigo
        //                 WHERE		colCri.Ano = {ano} ";

        //     if (familia != 0)
        //     {
        //         var familiaParam = $" AND         sac.Familia = {familia} ";
        //         sql = sql + familiaParam;
        //     }
        //     if (kit != 0)
        //     {
        //         var kitParam = $" AND         cri.Kit = {kit} ";
        //         sql = sql + kitParam;
        //     }
        //     if (nivel != 0)
        //     {
        //         var nivelParam = $" AND         sac.Nivel = {nivel} ";
        //         sql = sql + nivelParam;
        //     }

        //     sql = sql + " ORDER BY Numero, Ordem";

        //     var sacolas = Conn.Query<SacolaValue, ItemValue>(sql, sacola => sacola.Itens, null, null, false, "Ordem");

        //     return sacolas;
        // }

        // public IEnumerable<SacolaValue> PesquisarSacolas2(int ano, int familia, int kit, int nivel)
        // {
        //     var sql = $@"SELECT		sac.Codigo as Numero, sac.SacolaFamilia  as SacolaFamilia, sac.Familia as Familia, 
        //                    sac.FamiliaRepresentante as Representante, sac.Crianca as Crianca, sac.Sexo as Sexo, 
        //                    sac.Kit as Kit, fam.Nome as NomeFamilia, famRep.Nome as NomeRepresentante, 
        //                    cri.Nome as NomeCrianca, cri.Calcado as Calcado, cri.Roupa as Roupa, 
        //                    cri.IdadeNominal as IdadeNominal, col.Nome as Colaborador, kit.Descricao as KitNome,
        //                    kit.Codigo as Kit, kitem.Ordem as Ordem, kitem.Observacao as Observacao, 
        //                    titem.Descricao as Item, 
        //                    titem.Opcional as Opcional
        //                 From		Sacolas sac
        //                 JOIN		Familia fam
        //                 ON			sac.Familia = fam.Codigo
        //                 JOIN		Familia famRep
        //                 ON			sac.FamiliaRepresentante = famRep.Codigo
        //                 JOIN		Crianca cri
        //                 ON			sac.Crianca = cri.Codigo
        //                 LEFT JOIN	ColaboradorCrianca colCri
        //                 ON			sac.Crianca = colCri.Crianca
        //                 LEFT JOIN	Colaborador col
        //                 ON			col.Codigo = colCri.Colaborador
        //                 JOIN		Kit kit
        //                 ON			sac.Kit = kit.Codigo
        //                 JOIN		KitItem kitem
        //                 ON			kitem.Kit = Kit.Codigo
        //                 JOIN		TipoItem titem
        //                 ON			kitem.TipoItem = titem.Codigo
        //                 WHERE		colCri.Ano = {ano} ";

        //     if (familia != 0)
        //     {
        //         var familiaParam = $" AND         sac.Familia = {familia} ";
        //         sql = sql + familiaParam;
        //     }
        //     if (kit != 0)
        //     {
        //         var kitParam = $" AND         cri.Kit = {kit} ";
        //         sql = sql + kitParam;
        //     }
        //     if (nivel != 0)
        //     {
        //         var nivelParam = $" AND         sac.Nivel = {nivel} ";
        //         sql = sql + nivelParam;
        //     }

        //     sql = sql + " ORDER BY Numero, Ordem";

        //     var lookup = new Dictionary<int, SacolaValue>();
        //     var sacolas = Conn.Query<SacolaValue, ItemValue, SacolaValue>(sql,
        //         (s, i) =>
        //         {
        //             SacolaValue sacolaValue;
        //             if (!lookup.TryGetValue(s.Numero, out sacolaValue))
        //                 lookup.Add(s.Numero, sacolaValue = s);

        //             if (sacolaValue.Itens == null)
        //                 sacolaValue.Itens = new List<ItemValue>();

        //             if (sacolaValue.Itens.All(item => item.Kit != i.Kit))
        //             {
        //                 sacolaValue.Itens.Add(i);
        //             }
        //             //s.Itens = new List<ItemValue>();
        //             //s.Itens.Add(i);
        //             return sacolaValue;

        //         }, splitOn: "Numero, Kit,  Ordem");

        //     //var sacolas = Conn.Query<SacolaValue, ItemValue, SacolaValue>(sql,
        //     //   (s, i) =>
        //     //   {
        //     //       s.Itens = new List<ItemValue>
        //     //           {
        //     //                i
        //     //           };
        //     //       return s;

        //     //   },
        //     //       splitOn: "Kit");

        //     return sacolas;
        // }


        // //      public Usuario ObterPorLogin(string login)
        // //        {
        // //            var sql = $@"SELECT u.UsuarioId, u.Login, u.Senha, u.StatusUsuarioId, u.Nome, 
        // //		                        u.Sobrenome, u.Email, u.DataNascimento, u.Sexo, u.DataInclusao, 
        // //		                        u.DataAtualizacao, u.CodigoVerificacao, u.ValidadeCodigoVerificacao, 
        // //		                        u.DataUltimoAcesso, t.Ddd, t.Numero, t.Ramal, t.TelefoneId, t.TipoTelefoneId,
        // //                                t.UsuarioId, e.EnderecoId, e.Bairro, e.Cep, e.Cidade, e.Endereco as Descricao, 
        // //                                e.Estado, e.PaisId, e.UsuarioId, p.PaisId,
        // //		                        p.NomePt, p.NomeEn, p.CodigoAlfa2, p.CodigoAlfa3
        // //                        FROM    Usuario u
        // //                        JOIN	Telefone t
        // //                        ON		t.UsuarioId = u.UsuarioId
        // //                        JOIN	Endereco e
        // //                        ON		e.UsuarioId = u.UsuarioId
        // //                        JOIN	Pais p
        // //                        ON		e.PaisId = p.PaisId
        // //                        WHERE   Login = {login}";

        // //            var lookup = new Dictionary<int, Usuario>();

        // //            return Connection.Query<Usuario, Telefone, Endereco, Pais, Usuario>(sql,
        // //                          (u, t, e, p) =>
        // //                          {
        // //                              Usuario usuario;
        // //                              if (!lookup.TryGetValue(u.UsuarioId, out usuario))
        // //                                  lookup.Add(u.UsuarioId, usuario = u);

        // //                              if (usuario.Telefones == null)
        // //                                  usuario.Telefones = new List<Telefone>();

        // //                              if(usuario.Telefones.All(tel => tel.TelefoneId != t.TelefoneId))
        // //                              {
        // //                                  usuario.Telefones.Add(t);
        // //                              }

        // //                              if (usuario.Enderecos == null)
        // //                                  usuario.Enderecos = new List<Endereco>();

        // //                              e.Pais = p;
        // //                              if (usuario.Enderecos.All(end => end.EnderecoId != e.EnderecoId))
        // //                              {
        // //                                  usuario.Enderecos.Add(e);
        // //                              }

        // //                              return usuario;

        // //                          },
        // //                          splitOn: "UsuarioId,TelefoneId,EnderecoId,PaisId").FirstOrDefault();

        // //        }


    }
}