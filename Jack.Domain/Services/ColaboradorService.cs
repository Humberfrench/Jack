﻿using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Repository;
using Jack.Domain.Interfaces.Services;
using Jack.Domain.ObjectValue;
using Jack.DomainValidator;

namespace Jack.Domain.Services
{
    public class ColaboradorService : ServiceBase<Colaborador>, IColaboradorService
    {

        private readonly IColaboradorRepository repository;
        private readonly ISacolaRepository repSacola;
        private readonly ValidationResult validationResult = new ValidationResult();

        public ColaboradorService(IColaboradorRepository repository,
                                  ISacolaRepository repSacola)
            : base(repository)
        {
            this.repository = repository;
            this.repSacola = repSacola;
       }
        public IEnumerable<Colaborador> Filtrar(string nome)
        {
            var registros = Pesquisar(p => p.Nome.ToLower().Contains(nome.ToLower())).ToList();
            return registros;
        }

        public ValidationResult Gravar(Colaborador item)
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

        public ValidationResult Excluir(int id)
        {
            var item = ObterPorId(id);

            if (item == null)
            {
                validationResult.Add(new ValidationError("Registro não encontrado"));
                return validationResult;
            }

            repository.Excluir(item);

            return validationResult;

        }

        public IEnumerable<QuantidadeSacolasColaborador>ObterQuantidadeSacolasColaborador(int ano, int nivelMaximo)
        {
            return repository.ObterQuantidadeSacolasColaborador(ano, nivelMaximo);   
        }

        public IEnumerable<ColaboradorCrianca> ObterSacolasColaborador(int colaborador)
        {
            var colaboradores = ObterPorId(colaborador);

            //conferir se é lento
            colaboradores.Criancas.ToList().ForEach(
                sac => sac.Crianca.Sacola = repSacola.ObterSacolaPorCrianca(sac.Crianca.Codigo));

            return colaboradores.Criancas;
        }

    }
}