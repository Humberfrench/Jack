using System;
using Jack.Domain.Interfaces;

namespace Jack.Domain.Entity
{
    public class Parametro : IEntidade
    {

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

        public Parametro()
        {
            codigo = 0;
            idadeLimite = 0;
            idadeLimiteExcecao = 0;
            temIdadeLimiteExcecao = false;
            calcadoLimite = 0;
            numeroMaximoCricancas = 0;
            numeroMaximoRepresentantes = 0;
            primeiroSabado = 0;
            segundoSabado = 0;
            terceiroSabado = 0;
            anoCorrente = 0;
        }

        private int codigo;
        private int idadeLimite;
        private int idadeLimiteExcecao;
        private bool temIdadeLimiteExcecao;
        private int calcadoLimite;
        private int numeroMaximoCricancas;
        private int numeroMaximoRepresentantes;
        private int primeiroSabado;
        private int segundoSabado;
        private int terceiroSabado;
        private int anoCorrente;
        private bool podeGerarNovasSacolas;

        public virtual int IdadeLimite
        {
            get
            {
                return idadeLimite;
            }
            set
            {
                idadeLimite = value;
            }
        }

        public virtual int IdadeLimiteExcecao
        {
            get
            {
                return idadeLimiteExcecao;
            }
            set
            {
                idadeLimiteExcecao = value;
            }
        }

        public virtual bool TemIdadeLimiteExcecao
        {
            get
            {
                return temIdadeLimiteExcecao;
            }
            set
            {
                temIdadeLimiteExcecao = value;
            }
        }

        public virtual int CalcadoLimite
        {
            get
            {
                return calcadoLimite;
            }
            set
            {
                calcadoLimite = value;
            }
        }

        public virtual int NumeroMaximoCricancas
        {
            get
            {
                return numeroMaximoCricancas;
            }
            set
            {
                numeroMaximoCricancas = value;
            }
        }

        public virtual int NumeroMaximoRepresentantes
        {
            get
            {
                return numeroMaximoRepresentantes;
            }
            set
            {
                numeroMaximoRepresentantes = value;
            }
        }

        public virtual int PrimeiroSabado
        {
            get
            {
                return primeiroSabado;
            }
            set
            {
                primeiroSabado = value;
            }
        }

        public virtual int SegundoSabado
        {
            get
            {
                return segundoSabado;
            }
            set
            {
                segundoSabado = value;
            }
        }

        public virtual int TerceiroSabado
        {
            get
            {
                return terceiroSabado;
            }
            set
            {
                terceiroSabado = value;
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

        public virtual bool PodeGerarNovasSacolas
        {
            get
            {
                return podeGerarNovasSacolas;
            }
            set
            {
                podeGerarNovasSacolas = value;
            }
        }

    }
}