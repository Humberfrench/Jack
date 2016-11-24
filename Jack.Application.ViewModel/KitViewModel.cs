using System;
using System.Collections.Generic;

namespace Jack.Application.ViewModel
{
    public class KitViewModel 
    {

        public virtual int Codigo { get; set; }
        public virtual string Descricao { get; set; }
        public virtual float IdadeMinima { get; set; }
        public virtual float IdadeMaxima { get; set; }
        public virtual string Sexo { get; set; }
        public virtual bool NecessidadeEspecial { get; set; }
        public virtual IList<CriancaViewModel> Criancas { get; set; }
        public virtual IList<KitItemViewModel> Items { get; set; }

    }
}
