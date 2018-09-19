using Jack.Application.Interfaces;
using Jack.Application.ViewModel;
using Jack.Domain.Entity;
using Jack.Domain.Interfaces.Services;
using Jack.DomainValidator;

namespace Jack.Application
{
    public class ParametroServiceApp : AppServiceBase, IParametroServiceApp
    {
        private readonly IParametroService _service;

        public ParametroServiceApp(IParametroService parametroService)
        {
            _service = parametroService;
        }

        public ValidationResult Gravar(ParametroViewModel item)
        {
            return _service.Gravar(Mapper.Map<Parametro>(item));
        }

        public ParametroViewModel Obter()
        {
            return Mapper.Map<ParametroViewModel>(_service.Obter());
        }
    }
}