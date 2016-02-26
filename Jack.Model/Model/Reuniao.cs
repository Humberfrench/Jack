using System;
using System.Collections.Generic;
using Jack.Library.Extensions;

namespace Jack.Model
{
    [Serializable()]
    public class Reuniao: BaseModel<Reuniao>
    {
        public Reuniao()
        {
            ano = 0;
            anoCorrente = 0;
            familia = new List<Presenca>();
            data = DateTime.Now;
        }

        private int ano { get; set; }
        private int anoCorrente { get; set; }
        private DateTime data { get; set; }
        private List<Presenca> familia { get; set; }

        public virtual int Ano
        {
            get
            {
                return ano;
            }
            set
            {
                ano = value;
            }
        }

        public virtual int AnoCorrente
        {
            get
            {
                return anoCorrente;
            }
            set
            {
                anoCorrente = value;
            }
        }

        public virtual System.DateTime Data
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
            }
        }

        public virtual List<Presenca> Familia
        {
            get
            {
                return familia;
            }
            set
            {
                familia = value;
            }
        }


        public virtual string DataFormated
        {
            get
            {
                return Data.ToDateFormated();
            }
        }

    }
}
