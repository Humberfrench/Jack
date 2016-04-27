using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Jack.Library.Extensions;

namespace Jack.DTO
{
    public class DTOCrianca :BaseDTO2
    {
        public DTOCrianca()
            :base()
        {
            codigoFamilia = 0;
            nomeFamilia = string.Empty;
            idade = 0;
            dataNascimento = new DateTime();
            sexo = string.Empty;
            codigoKit = 0;
            kit = string.Empty;
            statusCodigo = 0;
            statusDescricao = string.Empty;
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

        private int codigoFamilia;
        private string nomeFamilia;
        private int idade;
        private string medidaIdade;
        private DateTime dataNascimento;
        private string sexo;
        private int calcado;
        private string roupa;
        private int calcadoPadrao;
        private int statusCodigo;
        private string statusDescricao;
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

        [Display(Name = "Codigo da Familia:")]
        [ReadOnly(true)]
        public virtual int CodigoFamilia
        {
            get
            {
                return codigoFamilia;
            }
            set
            {
                codigoFamilia = value;
            }
        }

        [Display(Name = "Nome da Mãe:")]
        [MaxLength(100)]
        [ReadOnly(true)]
        public virtual string NomeFamilia
        {
            get
            {
                return nomeFamilia;
            }
            set
            {
                nomeFamilia = value;
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

        [Display(Name = "Medida da Idade:")]
        [MaxLength(1)]
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

        [Display(Name = "Data de Nascimento:")]
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

        [Display(Name = "Sexo:")]
        [MaxLength(1)]
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

        [Display(Name = "Calçado:")]
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

        [Display(Name = "Roupa:")]
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

        [Display(Name = "Calçado Padrao:")]
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

        [Display(Name = "Roupa Padrão:")]
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

        [Display(Name = "Código do Kit:")]
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

        [Display(Name = "Kit:")]
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

        [Display(Name = "Sacolinha?")]
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

        [Display(Name = "Consistente?")]
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

        [Display(Name = "Necessidade Especial?")]
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

        [Display(Name = "Escolinha Moral Cristã?")]
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

        [Display(Name = "Criança Maior?")]
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

        [Display(Name = "Idade Nominal:")]
        [ReadOnly(true)]
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

        [Display(Name = "Idade Nominal Reduzida:")]
        [ReadOnly(true)]
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

        [Display(Name = "Status:")]
        public virtual int Status
        {
            get
            {
                return statusCodigo;
            }
            set
            {
                statusCodigo = value;
            }
        }

        [ScaffoldColumn(false)]
        public virtual string StatusDescricao
        {
            get
            {
                return statusDescricao;
            }
            set
            {
                statusDescricao = value;
            }
        }

        // locais de uso local
        [ScaffoldColumn(false)]
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

        [ScaffoldColumn(false)]
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

        [ScaffoldColumn(false)]
        public virtual string DataCriacaoString
        {
            get
            {
                return dataCriacaoString;
            }
        }

        [ScaffoldColumn(false)]
        public virtual string DataCriacaoFormated
        {
            get
            {
                return dataCriacaoFormated;
            }
        }

        [ScaffoldColumn(false)]
        public virtual string DataAtualizacaoString
        {
            get
            {
                return dataAtualizacaoString;
            }
        }

        [ScaffoldColumn(false)]
        public virtual string DataAtualizacaoFormated
        {
            get
            {
                return dataAtualizacaoFormated;
            }
        }

        [ScaffoldColumn(false)]
        public virtual string DataNascimentoString
        {
            get
            {
                return dataNascimentoString;
            }
        }

        [ScaffoldColumn(false)]
        public virtual string DataNascimentoFormated
        {
            get
            {
                return dataNascimentoFormated;
            }
        }

        [ScaffoldColumn(false)]
        public virtual string IdadeCrianca
        {
            get
            {
                if (MedidaIdade == "A")
                {
                    return idade.ToString() + " Anos";
                }
                else
                {
                    return idade.ToString() + " Meses";
                }
            }
        }

        [ScaffoldColumn(false)]
        public virtual string NecessidadeEspecial
        {
            get
            {
                return vNecessidadeEspecial;
            }
        }

        [ScaffoldColumn(false)]
        public virtual string MoralCrista
        {
            get
            {
                return vMoralCrista;
            }
        }

        [ScaffoldColumn(false)]
        public virtual string Sacolinha
        {
            get
            {
                return vSacolinha;
            }
        }

        [ScaffoldColumn(false)]
        public virtual string Consistente
        {
            get
            {
                return vConsistente;
            }
        }

        [ScaffoldColumn(false)]
        public virtual string CriancaMaior
        {
            get
            {
                return vCriancaMaior;
            }
        }
    }
}