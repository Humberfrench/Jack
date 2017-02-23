using Jack.Domain.Interfaces;
using System;

namespace Jack.Domain.Entity
{
    public class Log : IEntidade
    {
        
        private int id;
        private int codigo;
        private int statusEntidade;
        private string entidade;
        private string processo;
        private string mensagem;
        private DateTime data;

        public virtual int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

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

        public virtual int StatusEntidade
        {
            get
            {
                return statusEntidade;
            }
            set
            {
                statusEntidade = value;
            }
        }

        public virtual string Entidade
        {
            get
            {
                return entidade;
            }
            set
            {
                entidade = value;
            }
        }

        public virtual string Processo
        {
            get
            {
                return processo;
            }
            set
            {
                processo = value;
            }
        }

        public virtual string Mensagem
        {
            get
            {
                return mensagem;
            }
            set
            {
                mensagem = value;
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

    }
}