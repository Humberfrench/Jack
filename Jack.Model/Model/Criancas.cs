using System;
using Jack.Library.Extensions;
using System.Collections.Generic;
using DomainValidation.Interfaces.Validation;
using DomainValidation.Validation;
using Jack.Model.Validations;
using Jack.Model.Enum;

namespace Jack.Model
{
    [Serializable]
    public class Criancas:BaseModel<Criancas>, ISelfValidator
    {

        public Criancas():base()
        {
            nome = string.Empty;
            idade = 0;
            dataNascimento = new DateTime();
            sexo = string.Empty;
            kit = new Kit();
            medidaIdade = string.Empty;
            calcado = 99;
            roupa = "99";
            idadeNominal = string.Empty;
            idadeNominalReduzida = string.Empty;
            isSacolinha = string.Empty;
            isConsistente = string.Empty;
            isNecessidadeEspecial = string.Empty;
            isMoralCrista = string.Empty;
            status = StatusCrianca.CadastroNovo;
            nomeFamilia = string.Empty;
            familiaRepresentante = string.Empty;
            dataCriacao = new DateTime();
            dataAtualizacao = new DateTime();

        }

        private string nome;
        private int idade;
        private string medidaIdade;
        private DateTime dataNascimento;
        private string sexo;
        private int calcado;
        private string roupa;
        private int calcadoPadrao;
        private string roupaPadrao;
        private Kit kit;
        private string isSacolinha;
        private string isConsistente;
        private string isNecessidadeEspecial;
        private string isMoralCrista;
        private string isCriancaMaior;
        private StatusCrianca status;
        private IList<Familia> familia;
        private string idadeNominal;
        private string idadeNominalReduzida;
        private ValidationResult validationResult;

        private string nomeFamilia;
        private string familiaRepresentante;
        private int familiaCodigo;
        private int familiaRepresentanteCodigo;
        private DateTime dataAtualizacao;
        private DateTime dataCriacao;


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

        public virtual string IsSacolinha
        {
            get
            {
                return isSacolinha;
            }
            set
            {
                isSacolinha = value;
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

        public virtual IList<Familia> Familia
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

        // locais de uso local
        public virtual string DataCriacaoString
        {
            get
            {
                return DataCriacao.ToShortDateString();
            }
        }

        public virtual string DataCriacaoFormated
        {
            get
            {
                return DataCriacao.ToDateFormated();
            }
        }

        public virtual string DataAtualizacaoString
        {
            get { return DataAtualizacao.ToShortDateString(); }
        }

        public virtual string DataAtualizacaoFormated
        {
            get
            {
                return DataAtualizacao.ToDateFormated();
            }
        }

        public virtual string DataNascimentoString
        {
            get { return DataNascimento.ToShortDateString(); }
        }

        public virtual string DataFormated
        { 
            get
            {
                return DataNascimento.ToDateFormated();
            }
        }

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

        public virtual string FamiliaRepresentante
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

        public virtual int FamiliaCodigo
        {
            get
            {
                return familiaCodigo;
            }
            set
            {
                familiaCodigo = value;
            }
        }

        public virtual int FamiliaRepresentanteCodigo
        {
            get
            {
                return familiaRepresentanteCodigo;
            }
            set
            {
                familiaRepresentanteCodigo = value;
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
                else {
                    return Idade.ToString() + " Meses";
                }
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

        public virtual string Sacolinha
        {
            get
            {
                if (IsSacolinha == "S")
                {
                    return "Sim";
                }
                else {
                    return "Não";
                }
            }
        }

        public virtual string Consistente
        {
            get
            {
                if (IsConsistente == "S")
                {
                    return "Sim";
                }
                else {
                    return "Não";
                }
            }
        }

        public virtual string CriancaMaior
        {
            get
            {
                if (IsCriancaMaior == "S")
                {
                    return "Sim";
                }
                else {
                    return "Não";
                }
            }
        }

        public virtual ValidationResult ValidationResult
        {
            get
            {
                return validationResult;
            }
        }

        public virtual bool IsValid()
        {
            var criancaValidation = new CriancaValidValidation();
            validationResult = criancaValidation.Validate(this);
            return validationResult.IsValid;
        }

        public virtual void AcertaCrianca()
        {
            CalculaIdade();
            if (IdadePermitida() && VerifyRoupa() && VerifyCalcado())
            {
                //OK
            }
            else
            {
                //não OK
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
            int anos = dataBase.Year - dataNascimento.Year;

            if (dataBase.Month < dataNascimento.Month || 
                (dataBase.Month == dataNascimento.Month && dataBase.Day < dataNascimento.Day))
                anos--;

            return (anos < 11);
        }

        public virtual void CalculaIdade()
        {
            Helpers.Idade oIdade = new Helpers.Idade(DataNascimento,
                                                     new DateTime(DateTime.Now.Year, 12, 31));

            idade = oIdade.Anos;
            idadeNominal = string.Format("{0} anos e {1} Meses", oIdade.Anos, oIdade.Meses);
            idadeNominalReduzida = string.Format("{0}A{1}M", oIdade.Anos, oIdade.Meses);

            //acertar status
        }

    }

}
