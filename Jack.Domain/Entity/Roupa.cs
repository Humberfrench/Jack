using Jack.Domain.Interfaces;

namespace Jack.Domain.Entity
{
    public class Roupa : IEntidade
    {

        public Roupa()
        {
            codigo = 0;
            tamanho = string.Empty;
            idade = 0;
            medidaIdade = string.Empty;

        }

        private int codigo;
        private string descricao;
        private string tamanho;
        private string tamanhoMaior;
        private int idade;
        private string medidaIdade;

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

        public virtual string Descricao
        {
            get
            {
                return descricao;
            }
            set
            {
                descricao = value;
            }
        }


        public virtual string Tamanho
        {
            get
            {
                return tamanho;
            }
            set
            {
                tamanho = value;
            }
        }

        public virtual string TamanhoMaior
        {
            get
            {
                return tamanhoMaior;
            }
            set
            {
                tamanhoMaior = value;
            }
        }

        public virtual int Idade
        {
            get
            {
                return idade;
            }
            set
            {
                idade = value;
            }
        }

        public virtual string MedidaIdade
        {
            get
            {
                return medidaIdade;
            }
            set
            {
                medidaIdade = value;
            }
        }

    }

}
