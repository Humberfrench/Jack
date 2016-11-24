using System.Collections.Generic;
using System.Linq;
using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Repository;
using Jack.Domain.Interfaces.Services;
using Jack.DomainValidator;

namespace Jack.Domain.Services
{
    public class FamiliaFakeService : ServiceBase<FamiliaFake>, IFamiliaFakeService
    {

        private readonly IFamiliaFakeRepository repository;
        private readonly ValidationResult validationResult = new ValidationResult();

        public FamiliaFakeService(IFamiliaFakeRepository repository)
            : base(repository)
        {
            this.repository = repository;
        }

        public ValidationResult Gravar(FamiliaFake item)
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

            item.Ativo = false;
            repository.Atualizar(item);

            return validationResult;

        }

    }
}