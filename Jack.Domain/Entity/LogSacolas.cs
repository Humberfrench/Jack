using Jack.Domain.Interfaces;

namespace Jack.Domain.Entity
{
    public class LogSacolas : IEntidade
    {

        private int codigo;
        private int familia;
        private int familiaRepresentante;
        private int crianca;
        private int kit;
        private int ano;

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

        public virtual int Familia
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

        public virtual int FamiliaRepresentante
        {
            get
            {
                return familiaRepresentante;
            }
            set
            {
                familiaRepresentante = value;
            }
        }

        public virtual int Crianca
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

        public virtual int Kit
        {
            get
            {
                return kit;
            }
            set
            {
                kit = value;
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


    }
}