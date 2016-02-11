using System;

namespace Jack.Model
{
    [Serializable()]
    public class ColaboradorCrianca
    {

        #region "Construtor"

        public ColaboradorCrianca()
        {
            Crianca = new Criancas();
            Colaborador = new Colaborador();
        }

        #endregion

        #region "Fields"
        private int codigo { get; set; }
        private Colaborador colaborador { get; set; }
        private Criancas crianca { get; set; }
        private int ano { get; set; }
        private int numeroSacola { get; set; }
        private string isDevolvida { get; set; }
        private string nomeCrianca { get; set; }
        private string nomeColaborador { get; set; }
        private int numeroIdade { get; set; }
        private string medidaIdade { get; set; }
        private int calcado { get; set; }
        private string roupa { get; set; }

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
