using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Repository;
using Jack.Domain.Interfaces.Services;
using Jack.DomainValidator;
using System.Collections.Generic;
using System.Linq;

namespace Jack.Domain.Services
{
    public class RepresentanteService : ServiceBase<Representante>, IRepresentanteService
    {

        private readonly IRepresentanteRepository repRepresentante;
        private readonly IFamiliaRepository repFamilia;
        private readonly ITipoParentescoRepository repTipoParentesco;
        private readonly ValidationResult validationResult = new ValidationResult();

        public RepresentanteService(IRepresentanteRepository repRepresentante, 
                                    IFamiliaRepository repFamilia,
                                    ITipoParentescoRepository repTipoParentesco)
            : base(repRepresentante)
        {
            this.repRepresentante = repRepresentante;
            this.repFamilia = repFamilia;
            this.repTipoParentesco = repTipoParentesco;
        }

        public ValidationResult Gravar(Representante item)
        {
            if (item.Codigo == 0)
            {
                Adicionar(item);
            }
            else
            {
                Atualizar(item);
            }

            return validationResult;
        }

        public ValidationResult Gravar(int familiaRepresentante, int familiaRepresentada, int tipoParentesco)
        {
            var item = new Representante
            {
                Codigo = 0,
                Ativo = true,
                FamiliaRepresentada = repFamilia.ObterPorId(familiaRepresentada),
                FamiliaRepresentante = repFamilia.ObterPorId(familiaRepresentante),
                TipoParentesco = repTipoParentesco.ObterPorId(tipoParentesco)
            };
            return Gravar(item);
        }

        public ValidationResult Gravar(int codigo, int tipoParentesco, bool ativo)
        {
            var item = ObterPorId(codigo);
            if (item == null)
            {
                validationResult.Add(new ValidationError("Registro não encontrado"));
                return validationResult;
            }
            
            item.Codigo = codigo;
            item.Ativo = ativo;
            item.TipoParentesco = repTipoParentesco.ObterPorId(tipoParentesco);
            
            return Gravar(item);
        }

        public ValidationResult Ativar(int id)
        {
            var item = ObterPorId(id);
            if (item == null)
            {
                validationResult.Add(new ValidationError("Registro não encontrado"));
                return validationResult;
            }
            item.Ativo = true;
            Atualizar(item);
            return validationResult;
        }

        public ValidationResult Desativar(int id)
        {
            var item = ObterPorId(id);
            if (item == null)
            {
                validationResult.Add(new ValidationError("Registro não encontrado"));
                return validationResult;
            }
            item.Ativo = false;
            Atualizar(item);
            return validationResult;
        }

        public ValidationResult Excluir(int id)
        {
            var item = ObterPorId(id);

            if (item == null)
            {
                validationResult.Add(new ValidationError("Registro não encontrado"));
                return validationResult;
            }

            item.Ativo = false;
            repRepresentante.Excluir(item);

            return validationResult;

        }

        public IEnumerable<Familia> ObterFamilias(int familia)
        {

            var representantes = repFamilia.ObterPorId(familia).Representantes
                                           .Select(r => r.FamiliaRepresentada).ToList();

            var familias = repFamilia.ObterTodos().ToList();

            foreach (var rep in representantes)
            {
                familias.Remove(rep);    
            }
            
            return familias.OrderBy(f => f.Nome);

        }
    }
}