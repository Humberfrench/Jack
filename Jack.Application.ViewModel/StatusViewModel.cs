using System;
using System.Collections.Generic;

namespace Jack.Application.ViewModel
{
    public class StatusViewModel
    {

        public virtual int Codigo { get; set; }
        public virtual string Descricao { get; set; }
        public virtual bool PermiteSacola { get; set; }
        public virtual string TipoStatus { get; set; }
        public virtual IList<FamiliaViewModel> Familias { get; set; }
        public virtual IList<CriancaViewModel> Criancas { get; set; }

    }
}
