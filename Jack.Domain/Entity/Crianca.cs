using Jack.Domain.Interfaces;
using System;
using System.Collections.Generic;
namespace Jack.Domain.Entity
{
    public class Crianca : IEntidade
    {

        public Crianca()
        {
            nome = string.Empty;
            idade = 0;
            dataNascimento = new DateTime();
            sexo = string.Empty;
            medidaIdade = string.Empty;
            calcado = 99;
            roupa = "99";
            idadeNominal = string.Empty;
            idadeNominalReduzida = string.Empty;
            criancaGrande = false;
            sacolinha = false;
            consistente = false;
            necessidadeEspecial = false;
            moralCrista = false;
            documentoOk = false;
            dataCriacao = new DateTime();
            dataAtualizacao = new DateTime();
            colaboradores = new List<ColaboradorCrianca>();
        }

        private int codigo;
        private Familia familia;
        private string nome;
        private int idade;
        private string medidaIdade;
        private DateTime dataNascimento;
        private string idadeNominal;
        private string idadeNominalReduzida;
        private string sexo;
        private int calcado;
        private string roupa;
        private Kit kit;
        private TipoParentesco tipoParentesco;
        private bool sacolinha;
        private bool consistente;
        private bool necessidadeEspecial;
        private bool moralCrista;
        private bool criancaGrande;
        private bool documentoOk;
        private StatusCrianca status;
        private DateTime dataAtualizacao;
        private DateTime dataCriacao;
        private DateTime dataAtualizacaoVestuario;
        private IList<ColaboradorCrianca> colaboradores;
        private Sacola sacola;

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

        public virtual Familia Familia
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

        public virtual DateTime DataNascimento
        {
            get
            {
                return dataNascimento;
            }
            set
            {
                dataNascimento = value;
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

        public virtual Kit Kit
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

        public virtual TipoParentesco TipoParentesco
        {
            get
            {
                return tipoParentesco;
            }
            set
            {
                tipoParentesco = value;
            }
        }

        public virtual bool Sacolinha
        {
            get
            {
                return sacolinha;
            }
            set
            {
                sacolinha = value;
            }
        }

        public virtual bool Consistente
        {
            get
            {
                return consistente;
            }
            set
            {
                consistente = value;
            }
        }

        public virtual bool NecessidadeEspecial
        {
            get
            {
                return necessidadeEspecial;
            }
            set
            {
                necessidadeEspecial = value;
            }
        }

        public virtual bool MoralCrista
        {
            get
            {
                return moralCrista;
            }
            set
            {
                moralCrista = value;
            }
        }

        public virtual bool CriancaGrande
        {
            get
            {
                return criancaGrande;
            }
            set
            {
                criancaGrande = value;
            }
        }

        public virtual bool DocumentoOk
        {
            get
            {
                return documentoOk;
            }
            set
            {
                documentoOk = value;
            }
        }

        public virtual string IdadeNominal
        {
            get
            {
                return idadeNominal;
            }
            set
            {
                idadeNominal = value;
            }
        }

        public virtual string IdadeNominalReduzida
        {
            get
            {
                return idadeNominalReduzida;
            }
            set
            {
                idadeNominalReduzida = value;
            }
        }

        public virtual StatusCrianca Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }

        public virtual DateTime DataAtualizacao
        {
            get
            {
                return dataAtualizacao;
            }
            set
            {
                dataAtualizacao = value;
            }
        }

        public virtual DateTime DataCriacao
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

        public virtual DateTime DataAtualizacaoVestuario
        {
            get
            {
                return dataAtualizacaoVestuario;
            }
            set
            {
                dataAtualizacaoVestuario = value;
            }
        }
        public virtual IList<ColaboradorCrianca> Colaboradores
        {
            get
            {
                return colaboradores;
            }
            set
            {
                colaboradores = value;
            }
        }

        public virtual Sacola Sacola
        {
            get
            {
                return sacola;
            }
            set
            {
                sacola = value;
            }
        }

        public virtual bool VerifyRoupa()
        {
            return Calcado != 99;
        }

        public virtual bool VerifyCalcado()
        {

            return Roupa != "99";
        }

        public virtual bool IdadePermitida()
        {
            DateTime dataBase = new DateTime(DateTime.Now.Year, 12, 31);
            int anos = idade; //dataBase.Year - dataNascimento.Year;

            if (dataBase.Month < dataNascimento.Month ||
                (dataBase.Month == dataNascimento.Month && dataBase.Day < dataNascimento.Day))
                anos--;

            if (anos < 11)
            {
                return true;
            }

            return MoralCrista;
        }

        public virtual bool CriancaMaiorMoralCrista()
        {
            DateTime dataBase = new DateTime(DateTime.Now.Year, 12, 31);
            int anos = dataBase.Year - dataNascimento.Year;

            if (dataBase.Month < dataNascimento.Month ||
                (dataBase.Month == dataNascimento.Month && dataBase.Day < dataNascimento.Day))
                anos--;

            return ((anos > 10) && (MoralCrista));
        }

        public virtual void CalculaIdade()
        {
            var oIdade = new Helpers.Idade(DataNascimento, new DateTime(DateTime.Now.Year, 12, 31));

            idade = oIdade.Anos;
            idadeNominal = $"{oIdade.Anos} anos e {oIdade.Meses} Meses";
            idadeNominalReduzida = $"{oIdade.Anos}A{oIdade.Meses}M";
            if (oIdade.Meses == 0)
            {
                idadeNominal = $"{oIdade.Anos} anos";
                idadeNominalReduzida = $"{oIdade.Anos}A";
            }
            if (oIdade.Anos == 0)
            {
                idadeNominal = $"{oIdade.Meses} meses";
                idadeNominalReduzida = $"{oIdade.Meses}M";
            }
            medidaIdade = "A";
            if (idade == 0)
            {
                medidaIdade = "M";
            }
        }

        public virtual bool ValidaPorStatus()
        {
            var statusAValidar = false;
            switch (status.Codigo)
            {
                case 1:
                case 7:
                case 11:
                    statusAValidar = true;
                    break;
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 8:
                case 9:
                case 10:
                case 12:
                case 13:
                case 14:
                case 15:
                case 16:
                case 17:
                    statusAValidar = false;
                    break;
                default:
                    statusAValidar = false;
                    break;
            }
            return statusAValidar;
        }

    }

}
