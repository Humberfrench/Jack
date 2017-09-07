using Jack.Application.Interfaces;
using Jack.Application.ViewModel;
using Jack.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Jack.Application
{
    public class SacolaHistoricoServiceApp : AppServiceBase, ISacolaHistoricoServiceApp
    {

        private readonly ISacolaHistoricoService service;

        public SacolaHistoricoServiceApp(ISacolaHistoricoService sacolaService)
        {
            service = sacolaService;
        }

        public SacolaHistoricoViewModel ObterPorId(int id)
        {
            var sacola = service.ObterPorId(id);
            return Mapper.Map<SacolaHistoricoViewModel>(sacola);
        }

        public IEnumerable<SacolaHistoricoViewModel> ObterTodos()
        {
            var sacola = service.ObterTodos();
            return Mapper.Map<IEnumerable<SacolaHistoricoViewModel>>(sacola);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
