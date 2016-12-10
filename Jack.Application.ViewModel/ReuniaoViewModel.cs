using System;
using System.Collections.Generic;

namespace Jack.Application.ViewModel
{
    public class ReuniaoViewModel
    {
        public ReuniaoViewModel()
        {
            familiaPresenca = new List<PresencaViewModel>();
        }

        IList<PresencaViewModel> familiaPresenca;
        public virtual int Codigo { get; set; }
        public virtual int Ano { get; set; }
        public virtual int AnoCorrente { get; set; }
        public virtual DateTime Data { get; set; }
        public virtual string DataTexto
        {
            get
            {
                return Data.ToLongDateString();
            }
        }
        public virtual IList<PresencaViewModel> FamiliaPresenca
        {
            get
            {
                return familiaPresenca;
            }
            set
            {
                familiaPresenca = value;
            }
        }

    }
}
