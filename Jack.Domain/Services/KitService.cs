﻿using System.Collections.Generic;
using System.Linq;
using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Repository;
using Jack.Domain.Interfaces.Services;
using Jack.DomainValidator;

namespace Jack.Domain.Services
{
    public class KitService : ServiceBase<Kit>, IKitService
    {

        private readonly IKitRepository repKit;
        private readonly ValidationResult validationResult = new ValidationResult();

        public KitService(IKitRepository repKit)
            : base(repKit)
        {
            this.repKit = repKit;
        }
        public IEnumerable<Kit> Filtrar(string nome)
        {
            var registros = Pesquisar(p => p.Descricao.ToLower().Contains(nome.ToLower())).ToList();
            return registros;
        }

        public ValidationResult Gravar(Kit item)
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

            repKit.Excluir(item);

            return validationResult;

        }

    }
}