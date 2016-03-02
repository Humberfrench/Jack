using System;
using System.Collections.Generic;

namespace Jack.Model
{
    [Serializable()]
    public class Colaborador: BaseModel<Colaborador>
    {

        #region Constructor
        public Colaborador()
        {
            Codigo = 0;
            nome = string.Empty;
            telefone = string.Empty;
            celular = string.Empty;
            cpf = string.Empty;
            email = string.Empty;
            anoNotificacao = 0;
            totalSacolas = 0;
            quantidadeSacolas = 0;
            percentualSacolas = 0;
        }
        #endregion

        #region Fields
        private string nome;
        private string telefone;
        private string celular;
        private string cpf;
        private string email;
        private int anoNotificacao;
        private int totalSacolas;
        private int quantidadeSacolas;
        private double percentualSacolas;

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

        public virtual int TotalSacolas
        {
            get
            {
                return totalSacolas;
            }
            set
            {
                totalSacolas = value;
            }
        }

        public virtual int QuantidadeSacolas
        {
            get
            {
                return quantidadeSacolas;
            }
            set
            {
                quantidadeSacolas = value;
            }
        }

        public virtual double PercentualSacolas
        {
            get
            {
                return percentualSacolas;
            }
            set
            {
                percentualSacolas = value;
            }
        }
        #endregion

    }
}
