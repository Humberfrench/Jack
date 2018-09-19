using System.Collections.Generic;

namespace Jack.Application.ViewModel
{
    public class StatusCriancaViewModel
    {

        public virtual int Codigo { get; set; }
        public virtual string Descricao { get; set; }
        public virtual bool PermiteSacola { get; set; }
        public virtual bool ProcessaStatus { get; set; }
        public virtual IList<CriancaViewModel> Criancas { get; set; }

    }
}
