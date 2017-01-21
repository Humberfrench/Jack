using System;
using Jack.Domain.Interfaces;

namespace Jack.Domain.Entity
{
    public class Feriado : IEntidade
    {

        private int codigo;
        private string nome;
        private DateTime data;
        private int anoEfetivo;
        private DateTime reuniaoAnterior;
        private DateTime proximaReuniao;
        private bool podeTerReuniao;

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

        public virtual string Nome
        {
            get
            {
                return nome;
            }
            set
            {
                nome = value;
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
            }
        }

        public virtual int AnoEfetivo
        {
            get
            {
                return anoEfetivo;
            }
            set
            {
                anoEfetivo = value;
            }
        }

        public virtual DateTime ReuniaoAnterior
        {
            get
            {
                return reuniaoAnterior;
            }
            set
            {
                reuniaoAnterior = value;
            }
        }

        public virtual DateTime ProximaReuniao
        {
            get
            {
                return proximaReuniao;
            }
            set
            {
                proximaReuniao = value;
            }
        }

        public virtual bool PodeTerReuniao
        {
            get
            {
                return podeTerReuniao;
            }
            set
            {
                podeTerReuniao = value;
            }
        }

    }
}
