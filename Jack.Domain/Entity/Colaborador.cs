using System;
using System.Collections.Generic;
using Jack.Domain.Interfaces;

namespace Jack.Domain.Entity
{
    public class Colaborador : IEntidade
    {

        #region Constructor
        public Colaborador()
        {
            codigo = 0;
            nome = string.Empty;
            telefone = string.Empty;
            celular = string.Empty;
            cpf = string.Empty;
            email = string.Empty;
            anoNotificacao = 0;
        }
        #endregion

        #region Fields
        private int codigo;
        private string nome;
        private string telefone;
        private string celular;
        private string cpf;
        private string email;
        private int anoNotificacao;

        private IList<ColaboradorCrianca> criancas;

        #endregion

        #region Properties
        public virtual IList<ColaboradorCrianca> Criancas
        {
            get
            {
                return criancas;
            }
            set
            {
                criancas = value;
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

        public virtual string Telefone
        {
            get
            {
                return telefone;
            }
            set
            {
                telefone = value;
            }
        }

        public virtual string Celular
        {
            get
            {
                return celular;
            }
            set
            {
                celular = value;
            }
        }

        public virtual string Cpf
        {
            get
            {
                return cpf;
            }
            set
            {
                cpf = value;
            }
        }

        public virtual string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }

        public virtual int AnoNotificacao
        {
            get
            {
                return anoNotificacao;
            }
            set
            {
                anoNotificacao = value;
            }
        }

        #endregion

    }
}
