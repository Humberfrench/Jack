using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jack.Domain.Interfaces;

namespace Jack.Domain.Entity
{
    public class Feriado : IEntidade
    {

        private int codigo;
        private string nome;
        private DateTime data;
        private int anoEfetivo;
        private DateTime proximaReuniao;
        private bool temReuniao;


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

        public virtual bool TemReuniao
        {
            get
            {
                return temReuniao;
            }
            set
            {
                temReuniao = value;
            }
        }

    }
}
