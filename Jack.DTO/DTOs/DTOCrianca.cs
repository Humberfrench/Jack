using Jack.Library.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jack.DTO
{
    public class DTOCrianca
    {
        public DTOCrianca()
        {
            codigo = 0;
            nome = string.Empty;
            idade = 0;
            dataNascimento = new DateTime();
            sexo = string.Empty;
            codigoKit = 0;
            kit = string.Empty;
            codigoStatus = 0;
            status = string.Empty;
            medidaIdade = string.Empty;
            calcado = 99;
            roupa = "99";
            idadeNominal = string.Empty;
            idadeNominalReduzida = string.Empty;
            isSacolinha = string.Empty;
            isConsistente = string.Empty;
            isNecessidadeEspecial = string.Empty;
            isMoralCrista = string.Empty;
            isCriancaMaior = string.Empty;
            dataCriacao = new DateTime();
            dataAtualizacao = new DateTime();
        }
        private int codigo;
        private int familia;
        private string nome;
        private int idade;
        private string medidaIdade;
        private DateTime dataNascimento;
        private string sexo;
        private int calcado;
        private string roupa;
        private int calcadoPadrao;
        private int codigoStatus;
        private string status;
        private int codigoKit;
        private string kit;
        private string roupaPadrao;
        private string isSacolinha;
        private string isConsistente;
        private string isNecessidadeEspecial;
        private string isMoralCrista;
        private string isCriancaMaior;
        private DateTime dataAtualizacao;
        private DateTime dataCriacao;
        private string idadeNominal;
        private string idadeNominalReduzida;
        //aux vars
        private string dataCriacaoString;
        private string dataCriacaoFormated;
        private string dataAtualizacaoString;
        private string dataAtualizacaoFormated;
        private string dataNascimentoString;
        private string dataNascimentoFormated;
        private string vSacolinha;
        private string vConsistente;
        private string vNecessidadeEspecial;
        private string vMoralCrista;
        private string vCriancaMaior;

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
                dataNascimentoString = dataNascimento.ToShortDateString();
                dataNascimentoFormated = dataNascimento.ToDateFormated();
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
        public virtual int CalcadoPadrao
        {
            get
            {
                return calcadoPadrao;
            }
            set
            {
                calcadoPadrao = value;
            }
        }
        public virtual string RoupaPadrao
        {
            get
            {
                return roupaPadrao;
            }
            set
            {
                roupaPadrao = value;
            }
        }
        public virtual int CodigoKit
        {
            get
            {
                return codigoKit;
            }
            set
            {
                codigoKit = value;
            }
        }
        public virtual string Kit
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
        public virtual string IsSacolinha
        {
            get
            {
                return isSacolinha;
            }
            set
            {
                isSacolinha = value;
                vSacolinha = IsSacolinha.ToSimNao();
            }
        }
        public virtual string IsConsistente
        {
            get
            {
                return isConsistente;
            }
            set
            {
                isConsistente = value;
                vConsistente = isConsistente.ToSimNao();
            }
        }
        public virtual string IsNecessidadeEspecial
        {
            get
            {
                return isNecessidadeEspecial;
            }
            set
            {
                isNecessidadeEspecial = value;
                vNecessidadeEspecial = isNecessidadeEspecial.ToSimNao();
            }
        }
        public virtual string IsMoralCrista
        {
            get
            {
                return isMoralCrista;
            }
            set
            {
                isMoralCrista = value;
                vMoralCrista = isMoralCrista.ToSimNao();
            }
        }
        public virtual string IsCriancaMaior
        {
            get
            {
                return isCriancaMaior;
            }
            set
            {
                isCriancaMaior = value;
                vCriancaMaior = IsCriancaMaior.ToSimNao();
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
        public virtual int CodigoStatus
        {
            get
            {
                return codigoStatus;
            }
            set
            {
                codigoStatus = value;
            }
        }
        public virtual string Status
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
        // locais de uso local
        public virtual DateTime DataAtualizacao
        {
            get
            {
                return dataAtualizacao;
            }
            set
            {
                dataAtualizacao = value;
                dataAtualizacaoString = dataAtualizacao.ToShortDateString();
                dataAtualizacaoFormated = dataAtualizacao.ToDateFormated();
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
                dataCriacaoString = dataCriacao.ToShortDateString();
                dataCriacaoFormated = dataCriacao.ToDateFormated();
            }
        }
        public virtual string DataCriacaoString
        {
            get
            {
                return dataCriacaoString;
            }
        }
        public virtual string DataCriacaoFormated
        {
            get
            {
                return dataCriacaoFormated;
            }
        }
        public virtual string DataAtualizacaoString
        {
            get
            {
                return dataAtualizacaoString;
            }
        }
        public virtual string DataAtualizacaoFormated
        {
            get
            {
                return dataAtualizacaoFormated;
            }
        }
        public virtual string DataNascimentoString
        {
            get
            {
                return dataNascimentoString;
            }
        }
        public virtual string DataNascimentoFormated
        {
            get
            {
                return dataNascimentoFormated;
            }
        }
        public virtual string IdadeCrianca
        {
            get
            {
                if (MedidaIdade == "A")
                {
                    return Idade.ToString() + " Anos";
                }
                else
                {
                    return Idade.ToString() + " Meses";
                }
            }
        }
        public virtual string NecessidadeEspecial
        {
            get
            {
                return vNecessidadeEspecial;
            }
        }
        public virtual string MoralCrista
        {
            get
            {
                return vMoralCrista;
            }
        }
        public virtual string Sacolinha
        {
            get
            {
                return vSacolinha;
            }
        }
        public virtual string Consistente
        {
            get
            {
                return vConsistente;
            }
        }
        public virtual string CriancaMaior
        {
            get
            {
                return vCriancaMaior;
            }
        }

    }

}