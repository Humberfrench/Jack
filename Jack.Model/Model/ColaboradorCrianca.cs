using System;

namespace Jack.Model
{
    [Serializable()]
    public class ColaboradorCrianca : BaseModel<ColaboradorCrianca>
    {

        #region "Construtor"

        public ColaboradorCrianca()
        {
            Crianca = new Criancas();
            Colaborador = new Colaborador();
        }

        #endregion

        #region "Fields"
        private Colaborador colaborador;
        private Criancas crianca;
        private int ano;
        private int numeroSacola;
        private string isDevolvida;
        private string nomeCrianca;
        private string nomeColaborador;
        private int numeroIdade;
        private string medidaIdade;
        private int calcado;
        private string roupa;

        #endregion

        #region "Properties"

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

        public virtual Criancas Crianca
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

        public virtual int NumeroSacola
        {
            get
            {
                return numeroSacola;
            }
            set
            {
                numeroSacola = value;
            }
        }

        public virtual string IsDevolvida
        {
            get
            {
                return isDevolvida;
            }
            set
            {
                isDevolvida = value;
            }
        }

        public virtual string NomeCrianca
        {
            get
            {
                return nomeCrianca;
            }
            set
            {
                nomeCrianca = value;
            }
        }

        public virtual string NomeColaborador
        {
            get
            {
                return nomeColaborador;
            }
            set
            {
                nomeColaborador = value;
            }
        }

        public virtual int NumeroIdade
        {
            get
            {
                return numeroIdade;
            }
            set
            {
                numeroIdade = value;
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

        public virtual string Roupa
        {
            get
            {
                return roupa;
            }
            set
            {
                roupa = value;
            }
        }

        public virtual int Calcado
        {
            get
            {
                return calcado;
            }
            set
            {
                calcado = value;
            }
        }

        public virtual string Idade
        {
            get
            {
                if (medidaIdade == "A")
                {
                    return numeroIdade.ToString() + " Anos";
                }
                else {
                    return numeroIdade.ToString() + " Meses";
                }
            }
        }
        
        #endregion

    }
}
