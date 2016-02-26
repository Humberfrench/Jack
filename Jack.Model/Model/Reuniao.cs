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
            dataReuniao = data.ToDateFormated();
        }

        private int ano;
        private int anoCorrente;
        string dataReuniao;
        private DateTime data;
        private List<Presenca> familia;

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
                dataReuniao = data.ToDateFormated();

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
                return dataReuniao;
            }
        }

    }
}
