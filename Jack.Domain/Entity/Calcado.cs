using Jack.Domain.Interfaces;

namespace Jack.Domain.Entity
{
    public class Calcado : IEntidade
    {
        private int codigo;
        private int numero;
        private string sexo;
        private int inicio;
        private int fim; 
        private string medidaIdade;

        public Calcado()
        {
            codigo = 0;
            numero = 0;
            sexo = string.Empty;
            fim = 0;
            inicio = 0;
            medidaIdade = string.Empty;

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

        public virtual int Numero
        {
            get
            {
                return numero;
            }
            set
            {
                numero = value;
            }
        }

        public virtual string Sexo
        {
            get
            {
                return sexo;
            }
            set
            {
                sexo = value;
            }
        }

        public virtual int Inicio
        {
            get
            {
                return inicio;
            }
            set
            {
                inicio = value;
            }
        }

        public virtual int Fim
        {
            get
            {
                return fim;
            }
            set
            {
                fim = value;
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

