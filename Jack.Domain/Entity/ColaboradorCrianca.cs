using Jack.Domain.Interfaces;
using System;

namespace Jack.Domain.Entity
{
    public class ColaboradorCrianca : IEntidade
    {

        #region "Fields"
        private int codigo;
        private Colaborador colaborador;
        private Crianca crianca;
        private int ano;
        private bool devolvida;
        private DateTime? dataCriacao;
        private DateTime? dataDevolucao;

        #endregion

        #region "Properties"

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

        public virtual Colaborador Colaborador
        {
            get
            {
                return colaborador;
            }
            set
            {
                colaborador = value;
            }
        }

        public virtual Crianca Crianca
        {
            get
            {
                return crianca;
            }
            set
            {
                crianca = value;
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

        public virtual bool Devolvida
        {
            get
            {
                return devolvida;
            }
            set
            {
                devolvida = value;
            }
        }

        public virtual DateTime? DataCriacao
        {
            get
            {
                return dataCriacao;
            }
            set
            {
                dataCriacao = value;
            }
        }

        public virtual DateTime? DataDevolucao
        {
            get
            {
                return dataDevolucao;
            }
            set
            {
                dataDevolucao = value;
            }
        }
        
        #endregion

    }
}
