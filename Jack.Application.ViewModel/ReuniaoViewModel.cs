using System;
using System.Collections.Generic;

namespace Jack.Application.ViewModel
{
    public class ReuniaoViewModel
    {

        public virtual int Codigo { get; set; }
        public virtual int Ano { get; set; }
        public virtual int AnoCorrente { get; set; }
        public virtual DateTime Data { get; set; }
        public virtual IList<PresencaViewModel> FamiliaPresenca { get; set; }

    }
}
