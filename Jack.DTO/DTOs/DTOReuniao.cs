using Jack.Library.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.DTO
{
    public class DTOReuniao
    {
        public DTOReuniao()
        {
            ano = 0;
            anoCorrente = 0;
            data = DateTime.Now;
            dataReuniao = data.ToDateFormated();
        }

        private int codigo;
        private int ano;
        private int anoCorrente;
        string dataReuniao;
        private DateTime data;

        public virtual int Codigo
        {
            get
            {
                return codigo;
            }
            set
            {
                codigo = value;
            }
        }

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

        public virtual DateTime Data
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

        public virtual string DataReuniao
        {
            get
            {
                return dataReuniao;
            }
        }

    }

}
