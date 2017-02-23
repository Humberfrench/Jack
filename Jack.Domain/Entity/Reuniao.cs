using Jack.Domain.Interfaces;
using System;
using System.Collections.Generic;

//using Jack.Library.Extensions;

namespace Jack.Domain.Entity
{
    public class Reuniao : IEntidade
    {
        public Reuniao()
        {
            codigo = 0;
            ano = 0;
            anoCorrente = 0;
            familiaPresenca = new List<Presenca>();
            data = DateTime.Now;
        }

        private int codigo;
        private int ano;
        private int anoCorrente;
        private DateTime data;
        private IList<Presenca> familiaPresenca;

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

        public virtual IList<Presenca> FamiliaPresenca
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
